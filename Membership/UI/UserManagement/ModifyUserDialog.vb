Imports System.Text.RegularExpressions

Public Class ModifyUserDialog
    Public editing As IUser
    Private usercheck As Boolean, pwdcheck As Boolean, repwdchk As Boolean
    Public Sub New(toBeEdit As IUser)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        editing = toBeEdit
    End Sub
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        usercheck = True
        If txtUsername.Text = editing.userName Then
            ep.SetError(txtUsername, String.Empty)
            updateBtnSave()
            Return
        End If
        Dim u = New PlainUser
        u.userName = txtUsername.Text
        If config.dataManager.userManager.search(u, False, False).Count <> 0 Then
            ep.SetError(txtUsername, "Username already existed!")
            usercheck = False
        End If
        ep.SetError(txtUsername, String.Empty)
        updateBtnSave()
    End Sub

    Private Sub validatePassword(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtRePassword.TextChanged
        If (New Regex("^([^a-z]+|[^A-Z]+|[^0-9]+)$")).IsMatch(txtPassword.Text) Then
            ep.SetError(txtPassword, "Password must be alphanumeric!")
            pwdcheck = False
        Else
            pwdcheck = True
            ep.SetError(txtPassword, String.Empty)
        End If
        If Not txtPassword.Text.Equals(txtRePassword.Text) Then
            ep.SetError(txtRePassword, "Password doesn't matched!")
            repwdchk = False
        Else
            ep.SetError(txtRePassword, String.Empty)
            repwdchk = True
        End If
        updateBtnSave()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim iu As IUser = config.dataManager.userManager.getEntry(editing.id).orNothing()
        iu.userName = editing.userName
        iu.accessLevel = editing.accessLevel
        If txtPassword.Text.Length > 0 Then
            iu.password = txtPassword.Text
        End If
        config.dataManager.userManager.updateEntry(iu)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ModifyUserDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = editing.userName
        numAccess.Value = editing.accessLevel
    End Sub
    Private Sub updateBtnSave()
        btnSave.Enabled = usercheck And pwdcheck And repwdchk
    End Sub
End Class