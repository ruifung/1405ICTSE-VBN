Partial Public Class DB
    Public Shared UsersTable As Table = Nothing
    Public Shared Sub InitUsersTable()
        If Not IsNothing(UsersTable) Then Return
        UsersTable = New Table
        UsersTable.Name = "users"
        UsersTable.Fields.Add("id", New Field(MDBType.AutoNumber))
        UsersTable.Fields.Add("username", New Field(MDBType.Text, 20))
        UsersTable.Fields.Add("authkey", New Field(MDBType.Binary, 16))
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
    End Class
End Class