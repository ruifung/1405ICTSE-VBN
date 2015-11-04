Imports System.Data.OleDb
Imports System.IO
Public Module DB
    Private tables As List(Of Table) = New List(Of Table)
    Public conn As OleDbConnection
    Public Sub init(csb As OleDbConnectionStringBuilder)
        Dim constr As String = csb.ToString()
        If Not File.Exists(csb.DataSource) Then
            Dim cat As New ADOX.Catalog()
            cat.Create(constr)
            DirectCast(cat.ActiveConnection, ADODB.Connection).Close()
            conn = New OleDbConnection(constr)
            For Each t As Table In tables
                t.Create()
            Next
            For Each t As Table In tables
                t.ApplyConstraint()
            Next
        Else
            conn = New OleDbConnection(constr)
        End If
    End Sub
    Public Function Test(csb As OleDbConnectionStringBuilder) As Boolean
        Try
            Dim db = New OleDbConnection(csb.ToString())
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function RegisterTable(table As Table) As Table
        If Not tables.Contains(table) Then
            tables.Add(table)
        End If
        Return table
    End Function
End Module