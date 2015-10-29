Public Class LoginDialog
    Private Sub onExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub onLoginClick(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim matchingUsernames = ConfigManager.dataManager.userManager _
            .search(New PlainUser(username:=txtUsername.Text), False)
        Dim userCheckResult = matchingUsernames.Count = 1 AndAlso
            matchingUsernames.Exists(Function(x) x.verifyPass(txtPassword.Text))
        If userCheckResult Then
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Invalid Login!", MsgBoxStyle.Exclamation)
            End If
    End Sub
End Class
