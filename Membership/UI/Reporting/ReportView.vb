Imports Microsoft.Reporting.WinForms

Public Class ReportView
    Private Sub ReportView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SourceMemberPayments.DataSource = config.dataManager.paymentManager.listPayments().Select(WrappedPayment.wrap).ToList
        sourceMember.DataSource = config.dataManager.memberManager.list.Select(WrappedMember.wrap).ToList
        sourceStatus.DataSource = config.dataManager.memberTypeManager.list.Select(WrappedMembershipType.wrap).ToList

        paymentReport.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", SourceMemberPayments))
        reportMember.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", sourceMember))
        reportStatus.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", sourceStatus))

        Me.reportMember.RefreshReport()
        Me.reportStatus.RefreshReport()
        Me.paymentReport.RefreshReport()
    End Sub

    Private Sub ReportViewer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class