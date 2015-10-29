Imports System.Security.Cryptography
Imports System.Text

Partial Public Class DB
    Public Shared UsersTable As Table = Nothing
    Public Shared Sub InitUsersTable()
        If Not IsNothing(UsersTable) Then Return
        UsersTable = New Table
        UsersTable.Name = "users"
        UsersTable.Fields("id") = New Field(MDBType.AutoNumber)
        UsersTable.Fields("username") = New Field(MDBType.Text, 20)
        UsersTable.Fields("authkey") = New Field(MDBType.Binary, 32)
        UsersTable.Fields("permissions") = New Field(MDBType.Number)
        UsersTable.PrimaryKey = "id"
        DB.RegisterTable(UsersTable)
    End Sub
    Public Class User
        Inherits DBObject
        Implements IUser
        Public Shared Function TryGet(id As Integer) As User
            Return User.Find(Of User)(id)
        End Function
        Public Shared Function TryGet(field As String, value As Object) As User
            Return User.Find(Of User)(field, value)
        End Function
        Public Overrides Function table() As Table
            Return UsersTable
        End Function
        Public ReadOnly Property userID As Integer _
            Implements IUser.id
            Get
                Return CInt(Me("id"))
            End Get
        End Property
        Public Property userName As String _
            Implements IUser.userName
            Get
                Return CType(Me("username"), String)
            End Get
            Set(value As String)
                Me("username") = value
            End Set
        End Property
        Public Property password As String _
            Implements IUser.password
            Get
                Return Convert.ToBase64String(CType(Me("authkey"), Byte()))
            End Get
            Set(value As String)
                Me("authkey") = hash(value, userName)
            End Set
        End Property
        ReadOnly Property passwordHashed As Boolean _
            Implements IUser.passwordHashed
            Get
                Return True
            End Get
        End Property
        Public Property permmission As Integer Implements IUser.accessLevel
            Get
                Return CInt(Me("permission"))
            End Get
            Set(value As Integer)
                Me("permisson") = value
            End Set
        End Property
        Public Function validate(pass As String) As Boolean Implements IUser.verifyPass
            Return hash(pass, userName).SequenceEqual(CType(Me("authkey"), IEnumerable(Of Byte)))
        End Function

        Private Function hash(str As String, salt As String) As Byte()
            Dim saltPos As Integer = CInt(Math.Round(Math.Min(Math.Max(
                (str.Length + salt.Length) / 2, 0), str.Length)))
            Dim salted = String.Concat(str.Substring(0, saltPos), salt, str.Substring(saltPos))
            Dim bytes = Encoding.UTF8.GetBytes(salted.ToCharArray())
            Dim sha = SHA256Managed.Create()
            Return sha.ComputeHash(bytes)
        End Function
    End Class
End Class