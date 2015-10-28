Public Class DataManager
    ReadOnly dataStore As IDataStore

    Private userManagerVar As IUserManager
    Property userManager As IUserManager
        Get
            Return userManagerVar
        End Get
        Set(value As IUserManager)
            If (Not IsNothing(userManagerVar)) Then
                userManagerVar = value
            End If
        End Set
    End Property

    Private memberManagerVar As IMemberManager
    Property memberManager As IMemberManager
        Get
            Return memberManagerVar
        End Get
        Set(value As IMemberManager)
            If (Not IsNothing(memberManagerVar)) Then
                memberManagerVar = value
            End If
        End Set
    End Property

    Private memberTypeManagerVar As IMemberTypeManager)
    Property memberTypeManager As IMemberTypeManager
        Get
            Return memberTypeManagerVar
        End Get
        Set(value As IMemberTypeManager)
            If (Not IsNothing(memberTypeManagerVar)) Then
                memberTypeManagerVar = value
            End If
        End Set
    End Property

    Sub New(dataStore As IDataStore)
        Me.dataStore = dataStore
        dataStore.init(Me)
        dataStore.load()
        dataStore.save()
    End Sub
End Class
