Imports System.Data.OleDb
Partial Public Class DB
    Public Class DataStore
        Implements IDataStore

        Public Sub close() Implements IDataStore.close

        End Sub

        Public Sub init(manager As DataStoreManager, param As MaybeOption(Of Object)) Implements IDataStore.init
            manager.userManager = New DB.UserManager()
            Dim csb As OleDbConnectionStringBuilder = TryCast(param.orNothing, OleDbConnectionStringBuilder)
            If IsNothing(csb) Then Throw (New ArgumentException("Parameters is not a OleDbConnectionStringBuilder!"))
            DB.init(csb)
        End Sub

        Public Sub load() Implements IDataStore.load

        End Sub

        Public Sub save() Implements IDataStore.save

        End Sub
    End Class
End Class