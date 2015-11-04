Imports Membership.config

Public Class LoginDialog
    Property user As IUser

    Private Sub onExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub onLoginClick(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim matchingUsers = dataManager.userManager _
            .search(New PlainUser(username:=txtUsername.Text), True, False)
        Dim userCheckResult = matchingUsers.Count = 1 AndAlso
            matchingUsers.Exists(Function(x) x.verifyPass(txtPassword.Text))
        If userCheckResult Then
            Me.user = matchingUsers(0)
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Invalid Login!", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class
