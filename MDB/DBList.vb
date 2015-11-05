Imports System.Data.OleDb
''' <summary>
''' List of DBObject which represent a query or a table
''' </summary>
''' <typeparam name="T">Sub class of DBObject</typeparam>
''' <remarks></remarks>
Public Class DBList(Of T As DBObject)
    Inherits List(Of T)
#Region "Static"
    ''' <summary>
    ''' Get all records in the table of T
    ''' </summary>
    ''' <returns>The list</returns>
    ''' <remarks></remarks>
    Public Shared Function Query() As DBList(Of T)
        Return Query(Nothing)
    End Function
    ''' <summary>
    ''' Query from the table of T
    ''' </summary>
    ''' <param name="criteria">criteria for select</param>
    ''' <param name="params">parameters for the criteria</param>
    ''' <returns>The result</returns>
    ''' <remarks></remarks>
    Public Shared Function Query(criteria As String, ParamArray params() As OleDbParameter) As DBList(Of T)
        Dim list As New DBList(Of T)()
        DB.conn.Open()
        Dim cmd As New OleDbCommand(String.Format("SELECT * FROM `{0}`", list.table.Name), DB.conn)
        If criteria IsNot Nothing Then
            cmd.CommandText += Convert.ToString(" WHERE ") & criteria
            cmd.Parameters.AddRange(params)
        End If
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        While reader.Read()
            Dim obj As DBObject = DirectCast(Activator.CreateInstance(GetType(T)), DBObject)
            Dim keys As List(Of String) = obj.table.Fields.Keys.ToList()
            For i As Integer = 0 To keys.Count - 1
                obj(keys(i)) = If(IsDBNull(reader(i)), Nothing, reader(i))
            Next
            list.Add(DirectCast(obj, T))
        End While
        reader.Close()
        DB.conn.Close()
        Return DirectCast(list, DBList(Of T))
    End Function
    ''' <summary>
    ''' Count the records in the table of T
    ''' </summary>
    ''' <returns>the numbers of rows</returns>
    ''' <remarks></remarks>
    Public Shared Function RowsCount() As Integer
        Return RowsCount(Nothing)
    End Function
    ''' <summary>
    ''' Count the rows in the table of T which matched with the criteria
    ''' </summary>
    ''' <param name="criteria">criteria for match</param>
    ''' <param name="params">parameters for criteria</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RowsCount(criteria As String, ParamArray params() As OleDbParameter) As Integer
        Dim result As Integer = 0
        DB.conn.Open()
        Dim table As Table = DirectCast(Activator.CreateInstance(GetType(T)), DBObject).table()
        Dim cmd As New OleDbCommand(String.Format("SELECT count(*) FROM `{0}`", table.Name), DB.conn)
        If criteria IsNot Nothing Then
            cmd.CommandText += Convert.ToString(" WHERE ") & criteria
            cmd.Parameters.AddRange(params)
        End If
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        If reader.Read() Then
            result = CInt(reader(0))
        End If
        reader.Close()
        DB.conn.Close()
        Return result
    End Function
#End Region
#Region "Instance"
    Private table As Table = DirectCast(Activator.CreateInstance(Of T)(), DBObject).table
    ''' <summary>
    ''' Refresh all the objects in list
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Refresh()
        For Each obj As DBObject In Me
            obj.Refresh()
        Next
    End Sub
    ''' <summary>
    ''' Insert all the objects in list into databse
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub InsertDB()
        For Each obj As DBObject In Me
            obj.Insert()
        Next
    End Sub
    ''' <summary>
    ''' update all the objects in list
    ''' </summary>
    ''' <param name="field">field to update</param>
    ''' <value>new value of the field</value>
    ''' <remarks></remarks>
    Public Overridable WriteOnly Property Update(field As String) As Object
        Set(value As Object)
            DB.conn.Open()
            Dim temp As DBObject = DirectCast(Activator.CreateInstance(Of T)(), DBObject)
            If Me.Count = 0 Then
                Return
            End If
            temp(field) = value
            Dim sql As String = String.Format("UPDATE `{0}` SET `{1}`=? WHERE ", table.Name, field)
            Dim cmd As New OleDbCommand(sql, DB.conn)
            cmd.Parameters.Add(temp.AsParam(field))
            Dim llist As New LinkedList(Of DBObject)(Me)
            Dim node As LinkedListNode(Of DBObject) = llist.First
            While node IsNot Nothing
                node.Value(field) = value
                cmd.CommandText += String.Format("{0}=?", table.PrimaryKey)
                cmd.Parameters.Add(node.Value.AsParam(table.PrimaryKey))
                If node.[Next] IsNot Nothing Then
                    cmd.CommandText += " OR "
                End If
                node = node.[Next]
            End While
            cmd.ExecuteNonQuery()
            DB.conn.Close()
        End Set
    End Property
    ''' <summary>
    ''' delete all the objects in list from database
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Delete()
        DB.conn.Open()
        If Me.Count = 0 Then
            Return
        End If
        Dim sql As String = String.Format("DELETE FROM `{0}` WHERE ", table.Name)
        Dim cmd As New OleDbCommand(sql, DB.conn)
        Dim llist As New LinkedList(Of DBObject)(Me)
        Dim node As LinkedListNode(Of DBObject) = llist.First
        While node IsNot Nothing
            cmd.CommandText += String.Format("{0}=?", table.PrimaryKey)
            cmd.Parameters.Add(node.Value.AsParam(table.PrimaryKey))
            If node.[Next] IsNot Nothing Then
                cmd.CommandText += " OR "
            End If
            node = node.[Next]
        End While
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
#End Region
End Class