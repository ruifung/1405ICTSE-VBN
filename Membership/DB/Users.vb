Imports System.Security.Cryptography
Imports System.Text

Partial Public Class DB
    Public Shared UsersTable As Table = Nothing
    Public Shared Sub InitUsersTable()
        If Not IsNothing(UsersTable) Then Return
        UsersTable = New Table
        UsersTable.Name = "users"
        UsersTable.Fields.Add("id", New Field(MDBType.AutoNumber))
        UsersTable.Fields.Add("username", New Field(MDBType.Text, 20))
        UsersTable.Fields.Add("authkey", New Field(MDBType.Binary, 32))
        UsersTable.Fields.Add("role", New Field(MDBType.Byte))
        UsersTable.PrimaryKey = "id"
        DB.RegisterTable(UsersTable)
    End Sub
    Public Class User
        Inherits DBObject
        Public Property id As Integer
            Get
                Return Me("id")
            End Get
            Set(value As Integer)
                Me("id") = value
            End Set
        End Property
        Public Property username As String
            Get
                Return Me("username")
            End Get
            Set(value As String)
                Me("username") = value
            End Set
        End Property
        Public WriteOnly Property password As String
            Set(value As String)
                Dim pwd = Encoding.UTF8.GetBytes(value.ToCharArray())
                Dim sha = SHA256Managed.Create()
                Me("authkey") = sha.ComputeHash(pwd)
            End Set
        End Property
        Public Function validate(ByVal password As String) As Boolean
            Dim pwd = Encoding.UTF8.GetBytes(password.ToCharArray())
            Dim sha = SHA256Managed.Create()
            Return DirectCast(Me("authkey"), Byte()).SequenceEqual(sha.ComputeHash(pwd))
        End Function
    End Class
End Class