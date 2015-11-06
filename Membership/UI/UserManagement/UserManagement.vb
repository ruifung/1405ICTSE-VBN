﻿Public Class UserManagement

    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        showAll(Nothing, Nothing)
    End Sub

    Private Sub dropDownItem_Click(sender As Object, e As EventArgs) Handles tsByID.Click, tsAccess.Click, tsByUsername.Click
        ddFilter.Text = DirectCast(sender, ToolStripMenuItem).Text + ":"
        tsAccess.Checked = False
        tsByID.Checked = False
        tsByUsername.Checked = False
        DirectCast(sender, ToolStripMenuItem).Checked = True
    End Sub

    Private Sub showAll(sender As Object, e As EventArgs) Handles btnShowAll.Click
        setList(config.dataManager.userManager.list)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dialog = New ModifyUserDialog(New PlainUser With {.accessLevel = 0}, True)
        dialog.ShowDialog()
        showAll(Nothing, Nothing)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dataView.SelectedRows.Count = 0 Or dataView.RowCount = 0 Then Return
        Dim u As IUser = DirectCast(dataView.SelectedRows.Item(0).DataBoundItem, IUser)
        Dim dialog = New ModifyUserDialog(u)
        dialog.ShowDialog()
        showAll(Nothing, Nothing)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dataView.SelectedRows.Count = 0 Or dataView.RowCount = 0 Then Return
        Dim dr As DialogResult = MessageBox.Show("Are u sure to remove the selected users?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Not (dr = DialogResult.Yes) Then Return
        For Each row As DataGridViewRow In dataView.SelectedRows
            config.dataManager.userManager.removeEntry(DirectCast(row.DataBoundItem, IUser))
        Next
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim user As PlainUser = New PlainUser
        Dim lst As List(Of IUser) = New List(Of IUser)
        If tsByID.Checked Then
            Dim id As Integer
            If Int32.TryParse(txtSearch.Text, id) Then
                Dim result As MaybeOption(Of IUser) = config.dataManager.userManager.getEntry(id)
                result.forEach(Sub(x) lst.Add(x))
            End If
        ElseIf tsAccess.Checked Then
            Dim ac As Integer
            If Int32.TryParse(txtSearch.Text, ac) Then
                user.accessLevel = ac
                lst = config.dataManager.userManager.search(user, False, False)
            End If
        ElseIf tsByUsername.Checked Then
            user.userName = txtSearch.Text
            lst = config.dataManager.userManager.search(user, False, True)
        End If
        setList(lst)
    End Sub
    Private Sub setList(lst As List(Of IUser))
        WrappedUserBindingSource.DataSource = lst.Select(WrappedUser.wrap)
        If lst.Count = 0 Then
            dataView.DataSource = Nothing
        Else
            dataView.DataSource = WrappedUserBindingSource
        End If
    End Sub
End Class