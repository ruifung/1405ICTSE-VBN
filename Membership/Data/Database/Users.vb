Imports System.Security.Cryptography
Imports System.Text
Imports MDB
Namespace Database
    Partial Public Class Tables
        Public Shared UsersTable As Table = Nothing
        Public Shared Sub InitUsersTable()
            If Not IsNothing(UsersTable) Then Return
            UsersTable = New Table
            UsersTable.Name = "users"
            UsersTable.Fields("id") = New Field(MDBType.AutoNumber)
            UsersTable.Fields("username") = New Field(MDBType.Text, 20)
            UsersTable.Fields("authkey") = New Field(MDBType.Binary, 32)
            UsersTable.Fields("salt") = New Field(MDBType.Binary, 16)
            UsersTable.Fields("permissions") = New Field(MDBType.Number)
            UsersTable.PrimaryKey = "id"
            UsersTable.Constraints.Add(New MDB.Constraint(MDB.Constraint.ConsType.PrimaryKey, "id"))
            DB.RegisterTable(UsersTable)
        End Sub
    End Class
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
            Return Tables.UsersTable
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
                Dim salt(16) As Byte
                RNGCryptoServiceProvider.Create().GetBytes(salt)
                Me("salt") = salt
                Me("authkey") = hash(Encoding.UTF8.GetBytes(value), salt)
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
            Return hash(Encoding.UTF8.GetBytes(pass),
                        CType(Me("salt"), Byte())) _
                            .SequenceEqual(CType(Me("authkey"), IEnumerable(Of Byte)))
        End Function

        Private Function hash(toHash As Byte(), salt As Byte()) As Byte()
            Dim salted As Byte() = toHash.Concat(salt).ToArray
            Dim sha = SHA256Managed.Create()
            Return sha.ComputeHash(salted)
        End Function
    End Class
End Namespace