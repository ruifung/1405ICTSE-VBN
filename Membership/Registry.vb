Public Module Registry
    Private userManagerVar As IUserManager
    Public Property userManager As IUserManager
        Get
            Return userManagerVar
        End Get
        Set(value As IUserManager)
            If IsNothing(userManagerVar) Then
                userManagerVar = value
            End If
        End Set
    End Property

    Private memberManagerVar As IMemberManager
    Public Property memberManager As IMemberManager
        Get
            Return memberManagerVar
        End Get
        Set(value As IMemberManager)
            If IsNothing(memberManagerVar) Then
                memberManagerVar = value
            End If
        End Set
    End Property
End Module
