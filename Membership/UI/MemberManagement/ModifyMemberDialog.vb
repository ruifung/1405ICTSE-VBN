Public Class ModifyMemberDialog
    Private _member As IMember

    Sub New(member As IMember, Optional editable As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _member = member
        memberDetailsView.Enabled = False
        btnEdit.Visible = editable
    End Sub

    Private Sub onEnableEdit(sender As Object, e As EventArgs) Handles btnEdit.Click
        DirectCast(sender, ToolStripButton).Visible = False
        btnCancel.Visible = True
        btnSave.Visible = True
        btnBilling.Visible = False
        memberDetailsView.Enabled = True
    End Sub

    Private Sub onEndEdit(sender As Object, e As EventArgs) Handles btnCancel.Click, btnSave.Click
        btnEdit.Visible = True
        btnCancel.Visible = False
        btnSave.Visible = False
        btnBilling.Visible = True
        memberDetailsView.Enabled = False
    End Sub

    Private Sub gotoBilling(sender As Object, e As EventArgs) Handles btnBilling.Click
        Dim billingForm = New MemberBilling(_member)
        Me.Visible = False
        billingForm.ShowDialog()
        Me.Visible = True
    End Sub
End Class