Imports System.ComponentModel

Public Class ModifyMemberDialog
    Private _member As IMember
    Private originalValues As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
    Private editMode As Boolean = False, newMode As Boolean = False

    Property member As IMember
        Get
            Return If(newMode, memberDetailsView, _member)
        End Get
        Set(value As IMember)
            If newMode Then
                Throw New InvalidOperationException("member cannot be set while in new member mode.")
            End If
            _member = value
            memberDetailsView.BoundMember = _member
        End Set
    End Property

    ''' <summary>
    ''' Construct a ModifyMemberDialog in New Member Mode
    ''' </summary>
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        newMode = True
        Enabled = True
        startEdit()
        btnClose.Visible = False
        Text = "Add New Member"
    End Sub

    ''' <summary>
    ''' Construct a ModifyMemberDialog in Bound Member Mode
    ''' </summary>
    ''' <param name="member">Member to bind to.</param>
    ''' <param name="editable">Is editable.</param>
    Sub New(member As WrappedMember, Optional editable As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _member = member
        memberDetailsView.Enabled = False
        memberDetailsView.BoundMember = _member
        btnEdit.Visible = editable
        Text = String.Concat("Member Details for: ", If(IsNothing(member), String.Empty, String.Concat("#", member.id.ToString)))
    End Sub

    Private Sub onEnableEdit(sender As Object, e As EventArgs) Handles btnEdit.Click
        startEdit()
    End Sub

    Private Sub startEdit()
        SuspendLayout()
        btnEdit.Visible = False
        btnCancel.Visible = True
        btnSave.Visible = True
        btnBilling.Visible = False
        memberDetailsView.Enabled = True
        btnClose.Enabled = False
        btnPhoto.Visible = True
        btnPhotoClear.Visible = True
        seperatorEdit.Visible = True
        editMode = True
        ResumeLayout()
    End Sub

    Private Sub endEdit()
        SuspendLayout()
        btnEdit.Visible = True
        btnCancel.Visible = False
        btnSave.Visible = False
        btnBilling.Visible = True
        memberDetailsView.Enabled = False
        btnClose.Enabled = True
        btnPhoto.Visible = False
        btnPhotoClear.Visible = False
        seperatorEdit.Visible = False
        editMode = True
        ResumeLayout()
    End Sub

    Private Sub onSave(sender As Object, e As EventArgs) Handles btnSave.Click
        endEdit()
        If Not (emailFilter.IsMatch(memberDetailsView.email) AndAlso contactFilter.IsMatch(memberDetailsView.contactNumber)) Then
            MsgBox("Invalid email or contact info!")
            Exit Sub
        End If

        If newMode Then
            DialogResult = DialogResult.OK
        Else
            originalValues.Clear()
            config.dataManager.memberManager.updateEntry(member)
        End If
    End Sub

    Private Sub onCancel(sender As Object, e As EventArgs) Handles btnCancel.Click
        endEdit()
        If newMode Then
            DialogResult = DialogResult.Cancel
        Else
            For Each kv In originalValues.ToList
                CallByName(memberDetailsView, kv.Key, CallType.Set, kv.Value)
            Next
        End If
    End Sub

    Private Sub formIsClosing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If editMode AndAlso originalValues.Count > 0 Then
            e.Cancel = True
            MsgBox("Please save or cancel your changes first.", MsgBoxStyle.Information, "Unsaved changes")
        End If
    End Sub

    Private Sub onPropChanging(sender As Object, e As PropertyChangingEventArgs)
        If Not originalValues.ContainsKey(e.PropertyName) Then
            originalValues.Add(e.PropertyName, CallByName(memberDetailsView, e.PropertyName, CallType.Get))
        End If
    End Sub

    Private Sub gotoBilling(sender As Object, e As EventArgs) Handles btnBilling.Click
        Dim billingForm = New MemberBilling(WrappedMember.wrap(member))
        Me.Visible = False
        billingForm.ShowDialog()
        Me.Visible = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub onChangePhoto(sender As Object, e As EventArgs) Handles btnPhoto.Click
        Dim dialog = New OpenFileDialog With {
            .Filter = GetImageFilter(),
            .CheckFileExists = True,
            .DereferenceLinks = True,
            .Multiselect = False,
            .Title = "Choose Member Photo"
        }
        Try
            Dim result = dialog.ShowDialog()
            If result = DialogResult.OK Then
                Dim stream = dialog.OpenFile
                Dim cid = New CropImageDialog With {
                    .ImageToCrop = Image.FromStream(stream),
                    .CropSize = New Size(170, 218),
                    .Text = "Crop Photo"
                }
                stream.Close()
                cid.ShowDialog()
                If cid.DialogResult = DialogResult.OK Then
                    memberDetailsView.photo = MaybeOption.create(Of Image)(cid.CropResult)
                End If
            End If
        Catch ex As Exception
        Finally
            dialog.Dispose()
        End Try
    End Sub
End Class