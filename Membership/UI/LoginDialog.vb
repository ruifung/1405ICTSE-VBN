Public Class LoginDialog
    Private Sub onExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub onLoginClick(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim userCheckResult = ConfigManager.userManager _
            .map(Of Boolean)(Function(x) x.checkUser(txtUsername.Text, txtPassword.Text))
        If userCheckResult.isDefined Then
            If userCheckResult.getValue Then
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("Invalid Login!", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Internal Error!", MsgBoxStyle.Critical)
            Program.quit()
        End If
    End Sub
End Class
