Imports System.Data.OleDb
Public Class Table
    Private Shared con As String() = {"UNIQUE({0})", "PRIMARY KEY({0})", "FOREIGN KEY({0}) REFERENCES {1}({2})"}
    Public Name As String, PrimaryKey As String, Constraints As List(Of Constraint) = New List(Of Constraint)
    Public Fields As Dictionary(Of String, Field) = New Dictionary(Of String, Field)
    Public Function CreateSQL() As String
        Dim sql As String = String.Format("CREATE TABLE `{0}` (", Name)
        For Each pair As KeyValuePair(Of String, Field) In Fields
            pair.Value.Name = pair.Key
            sql += String.Format("{0}, ", pair.Value.CreateSQL())
        Next
        Return sql
    End Function
    Public Sub Create()
        DB.conn.Open()
        Dim cmd As New OleDbCommand(CreateSQL(), DB.conn)
        For Each pair As KeyValuePair(Of String, Field) In Fields
            If Not IsNothing(pair.Value.DefaultValue) Then
                cmd.Parameters.Add(pair.Value.DataType.asParam(pair.Value.DefaultValue))
            End If
        Next
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
    Public Sub ApplyConstraint()
        If Constraints.Count = 0 Then Return
        DB.conn.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("", DB.conn)
        For Each c As Constraint In Constraints
            cmd.CommandText = String.Format("ALTER {0} ADD {1};", String.Format(con(c.type), c.field, c.refTable, c.refField))
            cmd.ExecuteNonQuery()
        Next
        DB.conn.Open()
    End Sub
    Public Sub Drop()
        DB.conn.Open()
        Dim cmd As New OleDbCommand(String.Format("DROP TABLE `{0}`;", Name), DB.conn)
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
End Class