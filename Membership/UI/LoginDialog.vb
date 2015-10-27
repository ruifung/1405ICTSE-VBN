Public Class LoginDialog
    Private Sub onExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub onLoginClick(sender As Object, e As EventArgs) Handles btnLogin.Click
        If ConfigManager.userManager.checkUser(txtUsername.Text, txtPassword.Text) Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
End Class
