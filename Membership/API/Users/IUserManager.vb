Public Interface IUserManager
    Function getUser(name As String) As IUser
    Function addUser(name As String, pass As String) As Boolean
    Function delUser(name As String) As Boolean
End Interface
