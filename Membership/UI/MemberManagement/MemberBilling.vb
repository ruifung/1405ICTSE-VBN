Imports Membership.config
Public Class MemberBilling
    Private WithEvents binding As BindingSource
    Private historyView As Boolean = False

    Public Property member As WrappedMember

    Sub New(member As WrappedMember)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.member = member
        binding = New BindingSource With {.DataSource = member}
    End Sub

    Sub onFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        dgView.DataSource = binding
        txtMemberCredit.Text = member.paymentCredit.ToString
    End Sub

    Private Sub updateView()
        If Not historyView Then
            btnAddPayment.Visible = True
            btnViewCharges.Visible = False
            btnViewHistory.Visible = True
            Dim charges = dataManager.paymentManager.getUnpaidCharges(member)
            binding.DataSource = charges
        Else
            btnAddPayment.Visible = False
            btnViewCharges.Visible = True
            btnViewHistory.Visible = False
            Dim payments = dataManager.paymentManager.listPayments(member)
            binding.DataSource = payments
        End If
    End Sub

    Private Sub btnViewHistory_Click(sender As Object, e As EventArgs) Handles btnViewHistory.Click
        historyView = True
        updateView()
    End Sub
End Class