Public Class AddUserDialog
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Sub onBtnClick(sender As Button, e As EventArgs) Handles btnAdd.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class