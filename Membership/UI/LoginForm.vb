Public Class LoginForm

    Private Sub onThisLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Tag = lblUsername
        lblUsername.Tag = txtUsername
        txtPassword.Tag = lblPassword
        lblPassword.Tag = txtPassword
    End Sub

    Private Sub onLabelClick(sender As Object, e As EventArgs) Handles lblUsername.Click, lblPassword.Click
        CType(CType(sender, Label).Tag, TextBox).Focus()
        CType(sender, Label).Visible = False
    End Sub

    Private Sub onInputFocus(sender As Object, e As EventArgs) Handles txtUsername.Enter, txtPassword.Enter
        CType(CType(sender, TextBox).Tag, Label).Visible = False
    End Sub

    Private Sub onInputDone(sender As Object, e As EventArgs) Handles txtUsername.Leave, txtPassword.Leave
        CType(CType(sender, TextBox).Tag, Label).Visible = CType(sender, TextBox).Text.Length = 0
    End Sub

    Private Sub onExitClick(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub onLoginClick(sender As Object, e As EventArgs) Handles btnLogin.Click

    End Sub
End Class
