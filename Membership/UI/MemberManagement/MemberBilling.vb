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
        dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub onFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        If currentUser.accessLevel < 2 Then
            btnRemoveCharges.Enabled = False
            btnRemovePayment.Enabled = False
        End If
        dgView.DataSource = binding
        txtMemberCredit.Text = member.paymentCredit.ToString
        Me.Text = String.Format("Member Billing for: #{0} {1} {2}", member.id, member.firstName, member.lastName)
        updateView()
    End Sub

    Private Sub updateView()
        With dataManager.paymentManager
            If Not historyView Then
                btnAddPayment.Visible = True
                btnViewCharges.Visible = False
                btnViewHistory.Visible = True
                btnRemoveCharges.Visible = True
                Dim charges = .listCharges(member).Select(WrappedCharge.wrap).ToList
                binding.DataSource = charges
            Else
                btnAddPayment.Visible = False
                btnViewCharges.Visible = True
                btnViewHistory.Visible = False
                btnRemoveCharges.Visible = False
                Dim payments = .listPayments(member).Select(WrappedPayment.wrap).ToList
                binding.DataSource = payments
            End If
        End With
    End Sub

    Private Sub btnViewHistory_Click(sender As Object, e As EventArgs) Handles btnViewHistory.Click
        historyView = True
        updateView()
    End Sub

    Private Sub btnViewCharges_Click(sender As Object, e As EventArgs) Handles btnViewCharges.Click
        historyView = False
        updateView()
    End Sub

    Private Sub btnAddPayment_Click(sender As Object, e As EventArgs) Handles btnAddPayment.Click
        Dim dialog = New PaymentDialog(member)
        Dim result = dialog.ShowDialog()
        updateView()
    End Sub

    Private Sub btnAddCharge_Click(sender As Object, e As EventArgs) Handles btnAddCharge.Click
        Dim dialog = New AddChargeDialog(member)
        Dim result = dialog.ShowDialog
        If result = DialogResult.OK Then
            updateView()
        End If
    End Sub

    Private Sub btnRemoveCharges_Click(sender As Object, e As EventArgs) Handles btnRemoveCharges.Click
        If Not historyView Then
            Dim list = New List(Of IMemberCharge)
            For Each x As DataGridViewRow In dgView.SelectedRows
                exec(TryCast(x.DataBoundItem, IMemberCharge), Sub(y) list.Add(y))
            Next
            list.ForEach(Sub(x) dataManager.paymentManager.removeCharge(x))
        End If
        updateView()
    End Sub

    Private Sub dgView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellContentDoubleClick
        If Not historyView Then

        Else
            Dim item = DirectCast(dgView.Rows(e.RowIndex).DataBoundItem, IMemberPayment)
            Dim dialog = New PaymentViewDialog(item)
            dialog.ShowDialog()
        End If
        updateView()
    End Sub

    Private Sub btnRemovePayment_Click(sender As Object, e As EventArgs) Handles btnRemovePayment.Click
        If historyView Then
            For Each x As DataGridViewRow In dgView.SelectedRows
                Dim item = DirectCast(x.DataBoundItem, IMemberPayment)
                dataManager.paymentManager.removePayment(item)
            Next
        End If
        updateView()
    End Sub
End Class