Public Module ConfigManager
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

    Private memberTypeManagerVar As IMemberTypeManager
    Public Property memberTypeManager As IMemberTypeManager
        Get
            Return memberTypeManagerVar
        End Get
        Set(value As IMemberTypeManager)
            If IsNothing(memberTypeManagerVar) Then
                memberTypeManagerVar = value
            End If
        End Set
    End Property

    Sub init()
        'temporary
        DB.InitUsersTable()
        DB.init("test.mdb")
        userManager.init()
        memberTypeManager.init()
        memberManager.init()
    End Sub

    Sub load()
        userManager.load()
        memberTypeManager.load()
        memberManager.load()
    End Sub

    Sub save()
        userManager.load()
        memberTypeManager.save()
        memberManager.load()
    End Sub

End Module
