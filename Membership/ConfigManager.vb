

Public Module ConfigManager
    Private userManagerVar As MaybeOption(Of IUserManager) = New None(Of IUserManager)
    ReadOnly Property userManager As MaybeOption(Of IUserManager)
        Get
            Return userManagerVar
        End Get
    End Property
    Sub setUserManager(obj As IUserManager)
        userManagerVar = MaybeOption(Of IUserManager).apply(obj)
    End Sub

    Private memberManagerVar As MaybeOption(Of IMemberManager) = New None(Of IMemberManager)
    ReadOnly Property memberManager As MaybeOption(Of IMemberManager)
        Get
            Return memberManagerVar
        End Get
    End Property
    Sub setMemberManager(obj As IMemberManager)
        memberManagerVar = MaybeOption(Of IMemberManager).apply(obj)
    End Sub

    Private memberTypeManagerVar As MaybeOption(Of IMemberTypeManager) = New None(Of IMemberTypeManager)
    ReadOnly Property memberTypeManager As MaybeOption(Of IMemberTypeManager)
        Get
            Return memberTypeManagerVar
        End Get
    End Property
    Sub setmemberTypeManager(obj As IMemberTypeManager)
        memberTypeManagerVar = MaybeOption(Of IMemberTypeManager).apply(obj)
    End Sub




    Sub init()
        userManager.forEach(Sub(x) x.init())
        memberTypeManager.forEach(Sub(x) x.init())
        memberManager.forEach(Sub(x) x.init())
    End Sub

    Sub load()
        userManager.forEach(Sub(x) x.load())
        memberTypeManager.forEach(Sub(x) x.load())
        memberManager.forEach(Sub(x) x.load())
    End Sub

    Sub save()
        userManager.forEach(Sub(x) x.load())
        memberTypeManager.forEach(Sub(x) x.load())
        memberManager.forEach(Sub(x) x.load())
    End Sub

End Module
