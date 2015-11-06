Imports System.Text.RegularExpressions

Public Class ModifyUserDialog
    Public editing As IUser
    Public createMode As Boolean
    Private usercheck As Boolean, pwdcheck As Boolean, repwdchk As Boolean
    Public Sub New(toBeEdit As IUser, Optional createMode As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        editing = toBeEdit
        Me.createMode = createMode
        Me.Text = If(createMode, "New User", String.Format("Edit User: #{0}", toBeEdit.id))
    End Sub
    Private Sub validateUsername(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        usercheck = False
        Dim u = New PlainUser
        u.userName = txtUsername.Text
        If txtUsername.Text.Length <= 0 Then
            ep.SetError(txtUsername, "Username may not be empty!")
        ElseIf Regex.IsMatch(txtUsername.Text, "[^A-Za-z0-9]")
            ep.SetError(txtUsername, "Username may only contain A-Z and 0-9")
        ElseIf txtUsername.Text = editing.userName Then
            ep.SetError(txtUsername, String.Empty)
            usercheck = True
        ElseIf config.dataManager.userManager.search(u, False, False).Count <> 0 Then
            ep.SetError(txtUsername, "Username already existed!")
        Else
            ep.SetError(txtUsername, String.Empty)
            usercheck = True
        End If
        updateBtnSave()
    End Sub

    Private Sub validatePassword(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtRePassword.TextChanged
        If If(createMode, True, Not txtPassword.TextLength = 0) AndAlso
                (Not (Regex.IsMatch(txtPassword.Text, "[a-zA-Z]") _
                AndAlso Regex.IsMatch(txtPassword.Text, "[0-9]"))) Then
            ep.SetError(txtPassword, "Password must be alphanumeric!")
            pwdcheck = False
        ElseIf createMode And txtPassword.Text.Length <= 0 Then
            ep.SetError(txtPassword, "Password can't be empty!")
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
        Dim iu As IUser = If(createMode, New PlainUser, config.dataManager.userManager.getEntry(editing.id).orNothing())
        iu.userName = txtUsername.Text
        iu.accessLevel = CInt(numAccess.Value)
        If txtPassword.Text.Length > 0 Or createMode Then
            iu.password = txtPassword.Text
        End If
        If createMode Then
            config.dataManager.userManager.addEntry(iu)
        Else
            config.dataManager.userManager.updateEntry(iu)
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ModifyUserDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = editing.userName
        numAccess.Value = editing.accessLevel
        validatePassword(Nothing, Nothing)
        validateUsername(Nothing, Nothing)
        If createMode Then
            txtPassword.Placeholder = "Alphanumeric Password"
        End If
    End Sub
    Private Sub updateBtnSave()
        btnSave.Enabled = usercheck And pwdcheck And repwdchk
    End Sub
End Class