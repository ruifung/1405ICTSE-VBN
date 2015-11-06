Imports Membership

Public Class WrappedUser
    Implements IUser

    Public ReadOnly _backingUser As IUser

    Public Shared wrap As Func(Of IUser, WrappedUser) =
        Function(user As IUser) As WrappedUser
            Return If(TryCast(user, WrappedUser), New WrappedUser(user))
        End Function

    Public Property accessLevel As Integer Implements IUser.accessLevel
        Get
            Return _backingUser.accessLevel
        End Get
        Set(value As Integer)
            _backingUser.accessLevel = value
        End Set
    End Property

    Public ReadOnly Property id As Integer Implements IDataElement.id
        Get
            Return _backingUser.id
        End Get
    End Property

    Public Property password As String Implements IUser.password
        Get
            Return _backingUser.password
        End Get
        Set(value As String)
            _backingUser.password = value
        End Set
    End Property

    Public ReadOnly Property passwordHashed As Boolean Implements IUser.passwordHashed
        Get
            Return _backingUser.passwordHashed
        End Get
    End Property

    Public Property userName As String Implements IUser.userName
        Get
            Return _backingUser.userName
        End Get
        Set(value As String)
            _backingUser.userName = value
        End Set
    End Property

    Public Function verifyPass(pass As String) As Boolean Implements IUser.verifyPass
        Return _backingUser.verifyPass(pass)
    End Function

    Public Sub New(backingUser As IUser)
        _backingUser = backingUser
    End Sub
End Class
