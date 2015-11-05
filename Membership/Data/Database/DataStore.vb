Imports System.Data.OleDb
Imports MDB
Namespace Database
    Public Class DataStore
        Implements IDataStore

        Public Sub close() Implements IDataStore.close

        End Sub

        Public Sub init(manager As DataStoreManager, param As MaybeOption(Of Object)) Implements IDataStore.init
            Try
                Dim csb As OleDbConnectionStringBuilder = TryCast(param.orNothing, OleDbConnectionStringBuilder)
                If IsNothing(csb) Then Throw (New ArgumentException("Parameters is not a OleDbConnectionStringBuilder!"))
                DB.init(csb)
                Tables.InitMembersTable()
                Tables.InitMShipsTable()
                Tables.InitUsersTable()
                Tables.InitPaymentTable()
                Tables.InitChargesTable()
                manager.userManager = New UserManager()
                manager.memberManager = New MemberManager()
                manager.memberTypeManager = New MemberTypeManager()
                manager.paymentManager = New PaymentManager()
                If manager.memberTypeManager.count() = 0 Then
                    manager.memberTypeManager.addEntry(New Membership With {
                                                       .type = "Week-Day",
                                                       .RegistrationFee = 180,
                                                       .MonthlyFee = 75,
                                                       .TransferFee = 100,
                                                       .privilges = New HashSet(Of EnumMemberPrivileges),
                                                       .Description = "Only week-day bookings"})
                    manager.memberTypeManager.addEntry(New Membership With {
                                                       .type = "Non-Deluxe",
                                                       .RegistrationFee = 300,
                                                       .MonthlyFee = 100,
                                                       .TransferFee = 500,
                                                       .privilges = New HashSet(Of EnumMemberPrivileges)({EnumMemberPrivileges.WEEKEND_BOOKINGS}),
                                                       .Description = "Weekend bookings available"})
                    manager.memberTypeManager.addEntry(New Membership With {
                                                       .type = "Deluxe",
                                                       .RegistrationFee = 500,
                                                       .MonthlyFee = 120,
                                                       .TransferFee = 1000,
                                                       .privilges = New HashSet(Of EnumMemberPrivileges)({EnumMemberPrivileges.AFFLIATED, EnumMemberPrivileges.EQUITY_RIGHTS, EnumMemberPrivileges.RECIPROCAL, EnumMemberPrivileges.VOTING_RIGHTS, EnumMemberPrivileges.WEEKEND_BOOKINGS}),
                                                       .Description = "All Rights"})
                End If
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