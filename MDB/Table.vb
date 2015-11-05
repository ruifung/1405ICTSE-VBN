Imports System.Data.OleDb
Public Class Table
    Private Shared con As String() = {"UNIQUE({0})", "PRIMARY KEY({0})", "FOREIGN KEY({0}) REFERENCES {1}({2})"}
    Public Name As String, PrimaryKey As String, Constraints As List(Of Constraint) = New List(Of Constraint)
    Public Fields As Dictionary(Of String, Field) = New Dictionary(Of String, Field)
    ''' <summary>
    ''' Get SQL for create the table
    ''' </summary>
    ''' <returns>SQL for create the table</returns>
    ''' <remarks></remarks>
    Public Function CreateSQL() As String
        Dim sql As String = String.Format("CREATE TABLE `{0}` (", Name)
        Dim fs As List(Of String) = New List(Of String)
        For Each pair As KeyValuePair(Of String, Field) In Fields
            pair.Value.Name = pair.Key
            fs.Add(String.Format("{0}", pair.Value.CreateSQL()))
        Next
        sql += String.Join(", ", fs.ToArray()) + ")"
        Return sql
    End Function
    ''' <summary>
    ''' Create the table
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Create()
        DB.conn.Open()
        Dim cmd As New OleDbCommand(CreateSQL(), DB.conn)
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
    ''' <summary>
    ''' Apply Constraint to the table
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ApplyConstraint(Optional primary As Boolean = False)
        If Constraints.Count = 0 Then Return
        DB.conn.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("", DB.conn)
        For Each c As Constraint In Constraints
            If primary And c.type <> Constraint.ConsType.PrimaryKey Then
                Continue For
            ElseIf (Not primary) And c.type = Constraint.ConsType.PrimaryKey
                Continue For
            End If
            cmd.CommandText = String.Format("ALTER TABLE {0} ADD {1};", Name, String.Format(con(CInt(c.type)), c.field, c.refTable, c.refField))
            cmd.ExecuteNonQuery()
        Next
        DB.conn.Close()
    End Sub
    ''' <summary>
    ''' Drop the table
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Drop()
        DB.conn.Open()
        Dim cmd As New OleDbCommand(String.Format("DROP TABLE `{0}`;", Name), DB.conn)
        cmd.ExecuteNonQuery()
        DB.conn.Close()
    End Sub
End Class