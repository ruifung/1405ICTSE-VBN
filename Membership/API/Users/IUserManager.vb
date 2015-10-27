Public Interface IUserManager
    Function getUsers() As List(Of IUser)
    Function getUser(id As Integer) As MaybeOption(Of IUser)
    Function getUser(name As String) As MaybeOption(Of IUser)
    Function addUser(name As String, pass As String) As Boolean
    Function delUser(name As String) As Boolean
    Function checkUser(userName As String, pass As String) As Boolean
    Sub init()
    Sub load()
    Sub save()
End Interface
