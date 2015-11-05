Imports System.Data.OleDb

Public MustInherit Class DBObject
#Region "Static"
    Public Shared Function Find(Of T As DBObject)(pkey As Object) As T
        Dim obj As DBObject = DirectCast(Activator.CreateInstance(GetType(T)), DBObject)
        Return Find(Of T)(obj.table.PrimaryKey, pkey)
    End Function
    Public Shared Function Find(Of T As DBObject)(field As String, value As Object) As T
        Dim obj As DBObject = DirectCast(Activator.CreateInstance(GetType(T)), DBObject)
        obj(field) = value
        DB.conn.Open()
        Dim cmd As New OleDbCommand("", DB.conn)
        cmd.CommandText = String.Format("SELECT * FROM `{0}` WHERE `{1}`=?", obj.table.Name, field)
        cmd.Parameters.Add(obj.AsParam(field))
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        Dim success As Boolean = reader.Read()
        If success Then
            Dim keys As List(Of String) = obj.table.Fields.Keys.ToList()
            For i As Integer = 0 To keys.Count - 1
                obj(keys(i)) = If(IsDBNull(reader(i)), Nothing, reader(i))
            Next
        End If
        reader.Close()
        DB.conn.Close()
        If success Then
            Return DirectCast(obj, T)
        End If
        Return Nothing
    End Function
#End Region
#Region "Instance"
    Private data As Dictionary(Of String, Object)
    Public Sub New()
        data = New Dictionary(Of String, Object)()
    End Sub
    Public Overridable Sub Refresh()
        DB.conn.Open()
        Dim cmd As New OleDbCommand("", DB.conn)
        cmd.CommandText = String.Format("SELECT * FROM `{0}` SET WHERE `{1}`=?", table.Name, table.PrimaryKey)
        cmd.Parameters.Add(AsParam(table.PrimaryKey))
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        If reader.Read() Then
            Dim keys As List(Of String) = table.Fields.Keys.ToList()
            For i As Integer = 0 To keys.Count - 1
                Me(keys(i)) = reader(i)
            Next
        End If
        reader.Close()
        DB.conn.Close()
    End Sub
    Public Overridable Sub Insert()
        DB.conn.Open()
        Dim values As String = "("
        Dim cmd As New OleDbCommand("", DB.conn)
        cmd.CommandText = String.Format("INSERT INTO `{0}` (", table.Name)
        For Each field As String In data.Keys
            If table.Fields(field).DataType.Equals(MDBType.AutoNumber) Then
                Continue For
            End If
            If Not data.ContainsKey(field) Then
                Continue For
            End If
            cmd.CommandText += String.Format("`{0}`,", field)
            values += "?,"
            cmd.Parameters.Add(AsParam(field))
        Next
        cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1)
        values = values.Remove(values.Length - 1)
        cmd.CommandText += (Convert.ToString(") VALUES ") & values) + ");"
        cmd.ExecuteNonQuery()
        If table.Fields(table.PrimaryKey).DataType.Equals(MDBType.AutoNumber) Then
            cmd = New OleDbCommand("SELECT @@Identity;", DB.conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Me(table.PrimaryKey) = reader(0)
            End If
            reader.Close()
        End If
        DB.conn.Close()
    End Sub
    Public Overridable Sub Update()
        DB.conn.Open()
        Dim cmd As New OleDbCommand("", DB.conn)
        cmd.CommandText = String.Format("UPDATE `{0}` SET ", table.Name)
        For Each field As String In data.Keys
            If field.Equals(table.PrimaryKey) Then
                Continue For
            End If
            If Not data.ContainsKey(field) Then
                Continue For
            End If
            cmd.CommandText += String.Format(" `{0}`=?,", field)
            cmd.Parameters.Add(AsParam(field))
        Next
        cmd.CommandText.Remove(cmd.CommandText.Length - 1)
        cmd.CommandText += String.Format(" WHERE `{0}`=?", table.PrimaryKey)
        cmd.Parameters.Add(AsParam(table.PrimaryKey))
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
    Public Overridable Sub Delete()
        DB.conn.Open()
        Dim cmd As New OleDbCommand("", DB.conn)
        cmd.CommandText = String.Format("DELETE FROM `{0}` SET WHERE `{1}`=?", table.Name, table.PrimaryKey)
        cmd.Parameters.Add(AsParam(table.PrimaryKey))
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
    Default Public Property Item(field As String) As Object
        Get
            If data.ContainsKey(field) Then
                Return data(field)
            End If
            Return Nothing
        End Get
        Set(value As Object)
            If table.Fields.ContainsKey(field) Then
                data(field) = value
            End If
        End Set
    End Property
    Public Function AsParam(field As String) As OleDbParameter
        If Not table.Fields.ContainsKey(field) Then
            Return Nothing
        End If
        Dim p As OleDbParameter = table.Fields(field).DataType.asParam(Me(field))
        p.Size = table.Fields(field).Size
        Return p
    End Function
    Public MustOverride Function table() As Table
#End Region
End Class