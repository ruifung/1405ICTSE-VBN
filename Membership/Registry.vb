Public Module Registry
    Private userManagerVar As IUserManager
    Public Property userManager As IUserManager
        Get
            Return userManagerVar
        End Get
        Set(value As IUserManager)
            If userManagerVar Is Nothing Then
                userManagerVar = value
            End If
        End Set
    End Property
End Module
