Public Class ModifyUserDialog
    Private Proceed As String

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        txtUsername.Text = txtUsername.Text

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.Text = txtPassword.Text
    End Sub

    Private Sub txtRePassword_TextChanged(sender As Object, e As EventArgs) Handles txtRePassword.TextChanged
        txtRePassword.Text = txtRePassword.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtPassword.Text = txtRePassword.Text Then
            ModifyMemberDialog.Update(txtUsername.Text, txtPassword.Text, txtRePassword.Text, numAccess.Handle)
        ElseIf txtPassword.Text IsNot txtRePassword.Text Then
            ModifyMemberDialog.ResetText()
        End If
    End Sub
End Class