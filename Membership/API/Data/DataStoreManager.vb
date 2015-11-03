Public Class DataStoreManager
    Public ReadOnly dataStore As IDataStore

    Private userManagerVar As IDataManager(Of IUser)
    Property userManager As IDataManager(Of IUser)
        Get
            Return userManagerVar
        End Get
        Set(value As IDataManager(Of IUser))
            If (Not IsNothing(userManagerVar)) Then
                userManagerVar = value
            End If
        End Set
    End Property

    Private memberManagerVar As IDataManager(Of IMember)
    Property memberManager As IDataManager(Of IMember)
        Get
            Return memberManagerVar
        End Get
        Set(value As IDataManager(Of IMember))
            If (Not IsNothing(memberManagerVar)) Then
                memberManagerVar = value
            End If
        End Set
    End Property

    Private memberTypeManagerVar As IDataManager(Of MembershipType)
    Property memberTypeManager As IDataManager(Of MembershipType)
        Get
            Return memberTypeManagerVar
        End Get
        Set(value As IDataManager(Of MembershipType))
            If (Not IsNothing(memberTypeManagerVar)) Then
                memberTypeManagerVar = value
            End If
        End Set
    End Property

    Private transactionManagerVar As IDataManager(Of IMemberCharge)
    Property transactionManager As IDataManager(Of IMemberCharge)
        Get
            Return transactionManagerVar
        End Get
        Set(value As IDataManager(Of IMemberCharge))
            If (Not IsNothing(transactionManagerVar)) Then
                transactionManagerVar = value
            End If
        End Set
    End Property

    Sub New(dataStore As IDataStore, Optional dataStoreParam As Object = Nothing)
        Me.dataStore = dataStore
        dataStore.init(Me, MaybeOption.create(dataStoreParam))
        dataStore.load()
        dataStore.save()
    End Sub
End Class
