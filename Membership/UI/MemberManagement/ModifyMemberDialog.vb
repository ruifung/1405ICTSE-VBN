Imports System.ComponentModel

Public Class ModifyMemberDialog
    Private _member As IMember
    Private originalValues As Dictionary(Of String, Object)
    Private editMode As Boolean = False

    Property member As IMember
        Get
            Return _member
        End Get
        Set(value As IMember)
            _member = value
            memberDetailsView.BoundMember = _member
        End Set
    End Property

    Sub New(member As IMember, Optional editable As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _member = member
        memberDetailsView.Enabled = False
        btnEdit.Visible = editable
        Me.Text = String.Concat("Member Details for: ", If(IsNothing(member), String.Empty, String.Concat("#", member.id.ToString)))
    End Sub

    Private Sub onEnableEdit(sender As Object, e As EventArgs) Handles btnEdit.Click
        DirectCast(sender, ToolStripButton).Visible = False
        btnCancel.Visible = True
        btnSave.Visible = True
        btnBilling.Visible = False
        memberDetailsView.Enabled = True
        btnClose.Enabled = False
        editMode = True
    End Sub

    Private Sub endEdit()
        btnEdit.Visible = True
        btnCancel.Visible = False
        btnSave.Visible = False
        btnBilling.Visible = True
        memberDetailsView.Enabled = False
        btnClose.Enabled = True
        editMode = True
    End Sub

    Private Sub onSave(sender As Object, e As EventArgs) Handles btnSave.Click
        endEdit()
        originalValues.Clear()
        config.dataManager.memberManager.updateEntry(member)
    End Sub

    Private Sub onCancel(sender As Object, e As EventArgs) Handles btnCancel.Click
        endEdit()
        For Each kv In originalValues.ToList
            CallByName(memberDetailsView, kv.Key, CallType.Set, kv.Value)
        Next
    End Sub

    Private Sub formIsClosing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If editMode AndAlso originalValues.Count > 0 Then
            e.Cancel = True
            MsgBox("Please save or cancel your changes first.", MsgBoxStyle.Information, "Unsaved changes")
        End If
    End Sub

    Private Sub onPropChanging(sender As Object, e As PropertyChangingEventArgs) Handles memberDetailsView.MemberDataChanging
        If Not originalValues.ContainsKey(e.PropertyName) Then
            originalValues.Add(e.PropertyName, CallByName(memberDetailsView, e.PropertyName, CallType.Get))
        End If
    End Sub

    Private Sub gotoBilling(sender As Object, e As EventArgs) Handles btnBilling.Click
        Dim billingForm = New MemberBilling(member)
        Me.Visible = False
        billingForm.ShowDialog()
        Me.Visible = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class