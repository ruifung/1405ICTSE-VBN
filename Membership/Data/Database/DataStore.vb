Imports System.Data.OleDb
Imports MDB
Namespace Database
    Public Class DataStore
        Implements IDataStore

        Public Sub close() Implements IDataStore.close

        End Sub

        Public Sub init(manager As DataStoreManager, param As MaybeOption(Of Object)) Implements IDataStore.init
            Try
                Tables.InitMembersTable()
                Tables.InitMShipsTable()
                Tables.InitUsersTable()
                Tables.InitPaymentTable()
                Tables.InitChargesTable()
                manager.userManager = New UserManager()
                manager.memberManager = New MemberManager()
                manager.memberTypeManager = New MemberTypeManager()
                manager.paymentManager = New PaymentManager()
                Dim csb As OleDbConnectionStringBuilder = TryCast(param.orNothing, OleDbConnectionStringBuilder)
                If IsNothing(csb) Then Throw (New ArgumentException("Parameters is not a OleDbConnectionStringBuilder!"))
                DB.init(csb)
            Catch ex As Exception When TypeOf ex Is OleDbException OrElse TypeOf ex Is Runtime.InteropServices.COMException
                Throw New Exceptions.DataSourceException(ex.Message, ex)
            End Try

        End Sub

        Public Sub load() Implements IDataStore.load

        End Sub

        Public Sub save() Implements IDataStore.save

        End Sub
    End Class
End Namespace