Public Class AddChargeDialog
    Private member As IMember

    Property result As IMemberCharge

    Sub New(member As IMember)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.member = member
        dtTimestamp.Value = Date.Now
    End Sub

    Private Sub onFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        numAmount.Maximum = Decimal.MaxValue
        lblUsername.Text = String.Format("#{0} {1} {2}", member.id, member.firstName, member.lastName)
    End Sub

    Private Sub validateDesc() Handles txtDesc.TextChanged, txtDesc.LostFocus
        If txtDesc.Text.Length > 0 Then
            errors.SetError(txtDesc, String.Empty)
        End If
    End Sub

    Private Sub validateAmount() Handles numAmount.ValueChanged, numAmount.LostFocus
        If numAmount.Value > 0 Then
            errors.SetError(numAmount, String.Empty)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If numAmount.Value <= 0 Then
            errors.SetError(numAmount, "Value must be more then 0.")
            Exit Sub
        End If
        If txtDesc.Text.Length <= 0 Then
            errors.SetError(txtDesc, "Field can not be empty!")
            Exit Sub
        End If
        result = config.dataManager.paymentManager.addCharge(member, dtTimestamp.Value, txtDesc.Text, numAmount.Value)
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class