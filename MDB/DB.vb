Imports System.Data.OleDb
Imports System.IO
Public Module DB
    Private tables As List(Of Table) = New List(Of Table)
    Public conn As OleDbConnection
    ''' <summary>
    ''' Initialize the Database module
    ''' </summary>
    ''' <param name="csb">Connection String Builder for connection</param>
    ''' <remarks>Data Source must be local file</remarks>
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
    ''' <summary>
    ''' Test the connection string builder
    ''' </summary>
    ''' <param name="csb">the connection string builder</param>
    ''' <returns>true if success</returns>
    ''' <remarks></remarks>
    Public Function Test(csb As OleDbConnectionStringBuilder) As Boolean
        Try
            Dim db = New OleDbConnection(csb.ToString())
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' Register a table to Database module so the table will create when the database created
    ''' </summary>
    ''' <param name="table">the table</param>
    ''' <remarks></remarks>
    Public Sub RegisterTable(table As Table)
        If Not tables.Contains(table) Then
            tables.Add(table)
        End If
    End Sub
End Module