Imports System.Text.RegularExpressions

Public Class ChangePasswordDialog
    Private user As WrappedUser
    Private pass1check, pass2check As Boolean

    Sub New(user As WrappedUser)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.user = user
    End Sub

    Private Sub onformload() Handles Me.Load
        lblUsername.Text = user.userName
    End Sub

    Private Sub validatePassword(sender As Object, e As EventArgs) Handles txtNewP.TextChanged, txtNewP.LostFocus
        With txtNewP
            pass1check = False
            If .Text.Length < 6 Then
                errorProvider.SetError(txtNewP, "Password must be at least 6 characters long.")
            ElseIf Not (Regex.IsMatch(.Text, "[a-zA-Z]") AndAlso Regex.IsMatch(.Text, "[0-9]")) Then
                errorProvider.SetError(txtNewP, "Password must be alphanumeric.")
            Else
                errorProvider.SetError(txtNewP, String.Empty)
                pass1check = True
            End If
        End With
        updateButtonStates()
        validateConfirmPassword(sender, e)
    End Sub

    Private Sub validateConfirmPassword(sender As Object, e As EventArgs) _
        Handles txtConfirmP.TextChanged, txtConfirmP.LostFocus
        If Not txtNewP.Text.Equals(txtConfirmP.Text) Then
            errorProvider.SetError(txtConfirmP, "Passwords do not match!")
            pass2check = False
        Else
            errorProvider.SetError(txtConfirmP, String.Empty)
            pass2check = True
        End If
        updateButtonStates()
    End Sub

    Private Sub updateButtonStates()
        btnSave.Enabled = pass1check AndAlso pass2check
    End Sub

    Private Sub onBtnSave() Handles btnSave.Click
        If user.verifyPass(txtOldP.Text) Then
            errorProvider.SetError(txtOldP, String.Empty)
            user.password = txtNewP.Text
            config.dataManager.userManager.updateEntry(user)
            DialogResult = DialogResult.OK
        Else
            errorProvider.SetError(txtOldP, "Invalid Password")
        End If
    End Sub

    Private Sub onBtnCancel() Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class