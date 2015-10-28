Partial Public Class DB
    Public Class UserManager
        Implements IUserManager

        Public Function addUser(name As String, pass As String) As Boolean Implements IUserManager.addUser
            Dim user As User = New User()
            user.userName = name
            user.password = pass
            user.Insert()
        End Function

        Public Function checkUser(userName As String, pass As String) As Boolean Implements IUserManager.checkUser
            Dim user As User = user.TryGet("username", userName)
            If IsNothing(user) Then Return False
            Return user.validate(pass)
        End Function

        Public Function delUser(name As String) As Boolean Implements IUserManager.delUser
            Dim user As User = user.TryGet("username", name)
            If IsNothing(user) Then Return False
            user.Delete()
            Return True
        End Function

        Public Function getUser(id As Integer) As MaybeOption(Of IUser) Implements IUserManager.getUser
            Return MaybeOption(Of IUser).apply(DirectCast(User.TryGet(id), IUser))
        End Function

        Public Function getUser(name As String) As MaybeOption(Of IUser) Implements IUserManager.getUser
            Return MaybeOption(Of IUser).apply(DirectCast(User.TryGet("username", name), IUser))
        End Function

        Public Function getUsers() As List(Of IUser) Implements IUserManager.getUsers
            Dim list As New List(Of IUser)(DB.DBList(Of User).Query())
            Return list
        End Function

        Public Sub init() Implements IUserManager.init

        End Sub

        Public Sub load() Implements IUserManager.load

        End Sub

        Public Sub save() Implements IUserManager.save

        End Sub
    End Class
End Class
