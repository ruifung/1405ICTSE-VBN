Imports System.Data.OleDb
Imports System.IO

Public Class DB
    Private Const ConnFormat As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};"
    Private Shared tables As List(Of Table) = New List(Of Table)
    Public Shared self As OleDbConnection
    Public Shared Sub init(path As String, Optional pass As String = "bU6S1JnPTM95")
        ' Random generated password
        Dim constr As String = [String].Format(ConnFormat, path, pass)
        If Not File.Exists(path) Then
            Dim cat As New ADOX.Catalog()
            cat.Create(constr)
            CType(cat.ActiveConnection, ADODB.Connection).Close()
            self = New OleDbConnection(constr)
            For Each t As Table In tables
                t.Create()
            Next
        Else
            self = New OleDbConnection(constr)
        End If
    End Sub
    Public Shared Function RegisterTable(table As Table) As Table
        If Not tables.Contains(table) Then
            tables.Add(table)
        End If
        Return table
    End Function

    Public Class MDBType
#Region "Types"
        Public Shared ReadOnly Text As New MDBType("VARCHAR", OleDbType.VarWChar, GetType(String))
        Public Shared ReadOnly Memo As New MDBType("LONGTEXT", OleDbType.LongVarWChar, GetType(String))
        Public Shared ReadOnly [Byte] As New MDBType("BYTE", OleDbType.UnsignedTinyInt, GetType(Byte))
        Public Shared ReadOnly DateTime As New MDBType("DATETIME", OleDbType.Date, GetType(System.DateTime))
        Public Shared ReadOnly Currency As New MDBType("CURRENCY", OleDbType.Numeric, GetType([Decimal]))
        Public Shared ReadOnly Numeric As New MDBType("NUMERIC", OleDbType.Numeric, GetType([Decimal]))
        Public Shared ReadOnly [Double] As New MDBType("DOUBLE", OleDbType.Double, GetType(System.Double))
        Public Shared ReadOnly Number As New MDBType("LONG", OleDbType.Integer, GetType(Int32))
        Public Shared ReadOnly [Integer] As New MDBType("SHORT", OleDbType.SmallInt, GetType(Int16))
        Public Shared ReadOnly Binary As New MDBType("VARBINARY", OleDbType.VarBinary, GetType(Byte()))
        Public Shared ReadOnly AutoNumber As New MDBType("AUTOINCREMENT", OleDbType.Integer, GetType(Int32))
#End Region
#Region "Instance Properties & Functions"
        Public ReadOnly SQL As String
        Public ReadOnly DBType As OleDbType
        Public ReadOnly NetType As Type
        Public ReadOnly Property SizeRequired As Boolean
            Get
                Return NetType = GetType(String) Or NetType = GetType(Byte())
            End Get
        End Property
        Private Sub New(sql As String, dbtype As OleDbType, t As Type)
            Me.SQL = sql
            Me.DBType = dbtype
            Me.NetType = t
        End Sub
#End Region
    End Class
    Public Class Field
        Public Name As String
        Public DataType As MDBType
        Public Size As Integer
        Public NotNull As Boolean = False
        Public Sub New(datatype As MDBType, Optional size As Integer = 0)
            Me.Name = ""
            Me.DataType = datatype
            Me.Size = size
        End Sub
        Public Function CreateSQL() As String
            Dim s As String = If(DataType.SizeRequired, String.Format("({0})", Size), "")
            Return [String].Format("`{0}` {1}{2}{3}", Me.Name, Me.DataType.SQL, s, If(Me.NotNull, " NOT NULL", ""))
        End Function
    End Class
    Public Class Table
        Public Name As String, PrimaryKey As String
        Public Fields As Dictionary(Of String, Field) = New Dictionary(Of String, Field)
        Public Function CreateSQL() As String
            Dim sql As String = [String].Format("CREATE TABLE `{0}` (", Name)
            For Each pair As KeyValuePair(Of String, Field) In Fields
                pair.Value.Name = pair.Key
                sql += [String].Format("{0}, ", pair.Value.CreateSQL())
            Next
            sql += String.Format("PRIMARY KEY(`{0}`));", PrimaryKey)
            Return sql
        End Function
        Public Sub Create()
            self.Open()
            Dim cmd As New OleDbCommand(CreateSQL(), self)
            cmd.ExecuteNonQuery()
            self.Close()
        End Sub
        Public Sub Drop()
            self.Open()
            Dim cmd As New OleDbCommand([String].Format("DROP TABLE `{0}`;", Name), self)
            cmd.ExecuteNonQuery()
            self.Close()
        End Sub
    End Class

    Public Class DBList(Of T As DBObject)
        Inherits List(Of T)
#Region "Static"
        Public Shared Function Query(Optional criteria As String = Nothing) As DBList(Of T)
            Dim list As New DBList(Of T)()
            self.Open()
            Dim cmd As New OleDbCommand([String].Format("SELECT * FROM `{0}`", list.table.Name), self)
            If criteria IsNot Nothing Then
                cmd.CommandText += Convert.ToString(" WHERE ") & criteria
            End If
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim obj As DBObject = CType(Activator.CreateInstance(GetType(T)), DBObject)
                Dim keys As List(Of String) = obj.table.Fields.Keys.ToList()
                For i As Integer = 0 To keys.Count - 1
                    obj(keys(i)) = reader(i)
                Next
                list.Add(CType(obj, T))
            End While
            reader.Close()
            self.Close()
            Return CType(list, DBList(Of T))
        End Function
        Public Shared Function RowsCount(Optional criteria As String = Nothing) As Integer
            Dim result As Integer = 0
            self.Open()
            Dim table As Table = CType(Activator.CreateInstance(Of T)(), DBObject).table
            Dim cmd As New OleDbCommand([String].Format("SELECT count(*) FROM `{0}`", table.Name), self)
            If criteria IsNot Nothing Then
                cmd.CommandText += Convert.ToString(" WHERE ") & criteria
            End If
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                result = CInt(reader(0))
            End If
            reader.Close()
            self.Close()
            Return result
        End Function
#End Region
#Region "Instance"
        Private table As Table = CType(Activator.CreateInstance(Of T)(), DBObject).table
        Public Sub Refresh()
            For Each obj As DBObject In Me
                obj.Refresh()
            Next
        End Sub
        Public Sub InsertDB()
            For Each obj As DBObject In Me
                obj.Insert()
            Next
        End Sub
        Public Sub Update(field As String, value As Object)
            self.Open()
            Dim temp As DBObject = CType(Activator.CreateInstance(Of T)(), DBObject)
            If Me.Count = 0 Then
                Return
            End If
            temp(field) = value
            Dim sql As String = [String].Format("UPDATE `{0}` SET `{1}`=? WHERE ", table.Name, field)
            Dim cmd As New OleDbCommand(sql, self)
            cmd.Parameters.Add(temp.AsParam(field))
            Dim llist As New LinkedList(Of DBObject)(Me)
            Dim node As LinkedListNode(Of DBObject) = llist.First
            While node IsNot Nothing
                node.Value(field) = value
                cmd.CommandText += [String].Format("{0}=?", table.PrimaryKey)
                cmd.Parameters.Add(node.Value.AsParam(table.PrimaryKey))
                If node.[Next] IsNot Nothing Then
                    cmd.CommandText += " OR "
                End If
                node = node.[Next]
            End While
            cmd.ExecuteNonQuery()
            self.Close()
        End Sub
        Public Sub Delete()
            self.Open()
            If Me.Count = 0 Then
                Return
            End If
            Dim sql As String = [String].Format("DELETE FROM `{0}` WHERE ", table.Name)
            Dim cmd As New OleDbCommand(sql, self)
            Dim llist As New LinkedList(Of DBObject)(Me)
            Dim node As LinkedListNode(Of DBObject) = llist.First
            While node IsNot Nothing
                cmd.CommandText += [String].Format("{0}=?", table.PrimaryKey)
                cmd.Parameters.Add(node.Value.AsParam(table.PrimaryKey))
                If node.[Next] IsNot Nothing Then
                    cmd.CommandText += " OR "
                End If
                node = node.[Next]
            End While
            cmd.ExecuteNonQuery()
            self.Close()
        End Sub
#End Region
    End Class

    Public Class DBObject
#Region "Static"
        Public Shared Function Find(Of T As DBObject)(pkey As Object) As T
            Dim obj As DBObject = CType(Activator.CreateInstance(GetType(T)), DBObject)
            Return Find(Of T)(obj.table.PrimaryKey, pkey)
        End Function
        Public Shared Function Find(Of T As DBObject)(field As String, value As Object) As T
            Dim obj As DBObject = CType(Activator.CreateInstance(GetType(T)), DBObject)
            obj(field) = value
            self.Open()
            Dim cmd As New OleDbCommand("", self)
            cmd.CommandText = [String].Format("SELECT * FROM `{0}` WHERE `{1}`=?", obj.table.Name, field)
            cmd.Parameters.Add(obj.AsParam(field))
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            Dim success As Boolean = reader.Read()
            If success Then
                Dim keys As List(Of String) = obj.table.Fields.Keys.ToList()
                For i As Integer = 0 To keys.Count - 1
                    obj(keys(i)) = reader(i)
                Next
            End If
            reader.Close()
            self.Close()
            If success Then
                Return CType(obj, T)
            End If
            Return Nothing
        End Function
#End Region
#Region "Instance"
        Public ReadOnly table As Table
        Private data As Dictionary(Of String, Object)
        Public Sub New()
            data = New Dictionary(Of String, Object)()
        End Sub
        Public Sub Refresh()
            self.Open()
            Dim cmd As New OleDbCommand("", self)
            cmd.CommandText = [String].Format("SELECT * FROM `{0}` SET WHERE `{1}`=?", table.Name, table.PrimaryKey)
            cmd.Parameters.Add(AsParam(table.PrimaryKey))
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim keys As List(Of String) = table.Fields.Keys.ToList()
                For i As Integer = 0 To keys.Count - 1
                    Me(keys(i)) = reader(i)
                Next
            End If
            reader.Close()
            self.Close()
        End Sub
        Public Sub Insert()
            self.Open()
            Dim values As String = "("
            Dim cmd As New OleDbCommand("", self)
            cmd.CommandText = [String].Format("INSEERT INTO `{0}` (", table.Name)
            For Each field As String In data.Keys
                If table.Fields(table.PrimaryKey).DataType.Equals(MDBType.AutoNumber) Then
                    Continue For
                End If
                If Not data.ContainsKey(field) Then
                    Continue For
                End If
                cmd.CommandText += [String].Format("`{0}`,", field)
                values += "?,"
                cmd.Parameters.Add(AsParam(field))
            Next
            cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            values.Remove(values.Length - 1)
            cmd.CommandText += (Convert.ToString(") VALUES ") & values) + ");"
            cmd.ExecuteNonQuery()
            If table.Fields(table.PrimaryKey).DataType.Equals(MDBType.AutoNumber) Then
                cmd = New OleDbCommand("SELECT @@Identity;", self)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Me(table.PrimaryKey) = reader(0)
                End If
                reader.Close()
            End If
            self.Close()
        End Sub
        Public Sub Update()
            self.Open()
            Dim cmd As New OleDbCommand("", self)
            cmd.CommandText = [String].Format("UPDATE `{0}` SET ", table.Name)
            For Each field As String In data.Keys
                If field.Equals(table.PrimaryKey) Then
                    Continue For
                End If
                If Not data.ContainsKey(field) Then
                    Continue For
                End If
                cmd.CommandText += [String].Format(" `{0}`=?,", field)
                cmd.Parameters.Add(AsParam(field))
            Next
            cmd.CommandText.Remove(cmd.CommandText.Length - 1)
            cmd.CommandText += [String].Format(" WHERE `{0}`=?", table.PrimaryKey)
            cmd.Parameters.Add(AsParam(table.PrimaryKey))
            cmd.ExecuteNonQuery()
            self.Close()
        End Sub
        Public Sub Delete()
            self.Open()
            Dim cmd As New OleDbCommand("", self)
            cmd.CommandText = [String].Format("DELETE FROM `{0}` SET WHERE `{1}`=?", table.Name, table.PrimaryKey)
            cmd.Parameters.Add(AsParam(table.PrimaryKey))
            cmd.ExecuteNonQuery()
            self.Close()
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
            Dim p As New OleDbParameter()
            p.OleDbType = table.Fields(field).DataType.DBType
            p.Value = Me(field)
            p.Size = table.Fields(field).Size
            Return p
        End Function
#End Region
    End Class
End Class