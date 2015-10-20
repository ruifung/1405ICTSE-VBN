Public Class LoginDialog

    Private Sub onThisLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        DB.InitUsersTable()
        DB.init("test.mdb")
    End Sub

    Private Sub onExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Abort
    End Sub

    Private Sub onLoginClick(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Registry.userManager.checkUser(txtUsername.Text, txtPassword.Text) Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
End Class
