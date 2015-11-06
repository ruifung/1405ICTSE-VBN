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
                If Not IO.Directory.Exists(IO.Path.GetDirectoryName(csb.DataSource)) Then
                    Throw New Exceptions.DataSourceException(String.Format("Invalid File Path: {0}", csb.DataSource))
                End If
                If Not IO.File.Exists(csb.DataSource) Then
                    MsgBox(String.Format("Database not found, creating new database at {0}", csb.DataSource), MsgBoxStyle.Information)
                End If
                If IsNothing(csb) Then Throw (New ArgumentException("Parameters is not a OleDbConnectionStringBuilder!"))
                Tables.InitMembersTable()
                Tables.InitMShipsTable()
                Tables.InitUsersTable()
                Tables.InitPaymentTable()
                Tables.InitChargesTable()
                DB.init(csb)
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