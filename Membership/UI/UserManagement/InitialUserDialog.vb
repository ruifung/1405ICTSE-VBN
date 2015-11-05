Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class InitialUserDialog
    Private unameCheck, pass1Check, pass2Check As Boolean

    ReadOnly Property username As String
        Get
            Return txtUsername.Text
        End Get
    End Property
    ReadOnly Property password As String
        Get
            Return txtPassword.Text
        End Get
    End Property

    Private Sub validateUsername(sender As Object, e As CancelEventArgs) Handles txtUsername.Validating
        With txtUsername
            unameCheck = False
            If .Text.Length <= 0 Then
                errorProvider.SetError(txtUsername, "Username may not be empty!")
            ElseIf Regex.IsMatch(.Text, "[^A-Za-z0-9]")
                errorProvider.SetError(txtUsername, "Username may only contain A-Z and 0-9")
            Else
                errorProvider.SetError(txtUsername, String.Empty)
                unameCheck = True
            End If
        End With
        updateButtonStates()
    End Sub

    Private Sub validatePassword(sender As Object, e As CancelEventArgs) Handles txtPassword.Validating
        With txtPassword
            pass1Check = False
            If .Text.Length < 6 Then
                errorProvider.SetError(txtPassword, "Password must be at least 6 characters long.")
            ElseIf Not (Regex.IsMatch(.Text, "[a-zA-Z]") AndAlso Regex.IsMatch(.Text, "[0-9]")) Then
                errorProvider.SetError(txtPassword, "Password must be alphanumeric.")
            Else
                errorProvider.SetError(txtPassword, String.Empty)
                pass1Check = True
            End If
        End With
        updateButtonStates()
    End Sub

    Private Sub validateConfirmPassword(sender As Object, e As CancelEventArgs) Handles txtPasswordConfirm.Validating, txtPassword.Validating
        If Not txtPassword.Text.Equals(txtPasswordConfirm.Text) Then
            errorProvider.SetError(txtPasswordConfirm, "Passwords do not match!")
            pass2Check = False
        Else
            errorProvider.SetError(txtPasswordConfirm, String.Empty)
            pass2Check = True
        End If
        updateButtonStates()
    End Sub

    Private Sub updateButtonStates()
        btnOK.Enabled = unameCheck AndAlso pass1Check AndAlso pass2Check
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        DialogResult = DialogResult.OK
    End Sub
End Class