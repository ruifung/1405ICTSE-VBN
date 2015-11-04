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

    Private memberTypeManagerVar As IDataManager(Of IMembershipType)
    Property memberTypeManager As IDataManager(Of IMembershipType)
        Get
            Return memberTypeManagerVar
        End Get
        Set(value As IDataManager(Of IMembershipType))
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
        Try
            Me.dataStore = dataStore
            dataStore.init(Me, MaybeOption.create(dataStoreParam))
            dataStore.load()
            dataStore.save()
        Catch ex As Exception When TypeOf ex IsNot OleDb.OleDbException
            Throw New Exceptions.DataSourceException(ex.Message, ex)
        End Try
    End Sub
End Class
