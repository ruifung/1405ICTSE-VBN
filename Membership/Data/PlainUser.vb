Imports Membership

''' <summary>
''' User class that stores everything in plaintext.
''' </summary>
Public Class PlainUser
    Implements IUser

    Sub New(Optional id As Integer = -1,
            Optional username As String = Nothing,
            Optional password As String = Nothing,
            Optional accessLevel As Integer = -1)
        Me.id = id
        Me.userName = username
        Me.password = password
        Me.accessLevel = accessLevel
    End Sub

    Public Property accessLevel As Integer Implements IUser.accessLevel

    Public ReadOnly Property id As Integer Implements IDataElement.id

    Public Property password As String Implements IUser.password

    Public ReadOnly Property passwordHashed As Boolean Implements IUser.passwordHashed
        Get
            Return False
        End Get
    End Property

    Public Property userName As String Implements IUser.userName

    Public Function verifyPass(pass As String) As Boolean Implements IUser.verifyPass
        Return password.Equals(pass)
    End Function
End Class
