Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Membership.config

Public Class MainForm
    Implements INotifyPropertyChanged

    Private loggingOut As Boolean
    Private dataMembers As IDataManager(Of IMember) = dataManager.memberManager
    Private _memberList As List(Of WrappedMember), dataSource As BindingSource = New BindingSource With {.DataSource = filteredMembers}
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Property memberList As List(Of WrappedMember)
        Get
            Return If(_memberList, New List(Of WrappedMember))
        End Get
        Set(value As List(Of WrappedMember))
            _memberList = value
            onPropertyChanged()
            updateFilter()
        End Set
    End Property

    ReadOnly Property filteredMembers As List(Of WrappedMember)
        Get
            Return memberList.FindAll(Function(x)
                                          Dim active As Boolean
                                          If rbActive.Checked Then
                                              active = True
                                          ElseIf rbInactive.Checked
                                              active = False
                                          End If
                                          active = x.isActive.Equals(active)
                                          Dim typeSelected As Boolean
                                          For Each y As IMembershipType In lbTypes.SelectedItems
                                              If y.id = x.membershipTypeID Then
                                                  typeSelected = True
                                              End If
                                          Next
                                          typeSelected = If(lbTypes.SelectedItems.Count = 0, True, typeSelected)
                                          Return active AndAlso typeSelected
                                      End Function)
        End Get
    End Property

    Sub updateFilter()
        onPropertyChanged("filteredMembers")
        dataSource.DataSource = filteredMembers
    End Sub


    Private Sub onFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        lblDataSource.Text = configuration.DataSourcePath

        If ConfigManager.currentUser.accessLevel > 1 Then
            btnManageUsers.Visible = False
            btnManageUsers.Enabled = False
        End If

        memberList = New List(Of WrappedMember)
        lbTypes.DataSource = New BindingSource With {
            .DataSource = (dataManager.memberTypeManager.list.Select(WrappedMembershipType.wrap).ToList)
        }
        lbTypes.DisplayMember = "typeName"
        lbTypes.ValueMember = "id"

        dgMemberView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgMemberView.DataSource = dataSource
        memberList = dataManager.memberManager.list.Select(WrappedMember.wrap).ToList
    End Sub

    Private Sub onSearch(sender As Object, e As EventArgs)
        Dim searchParam As PlainMember = Nothing
        If rbSearchName.Checked Then
            searchParam = New PlainMember With {
                .firstName = txtSearch.Text,
                .lastName = txtSearch.Text
            }
        ElseIf rbSearchEmail.Checked
            searchParam = New PlainMember With {
                .email = txtSearch.Text
            }
        ElseIf rbSearchContact.Checked
            searchParam = New PlainMember With {
                .contactNumber = txtSearch.Text
            }
        End If
        If IsNothing(searchParam) Then
            Exit Sub
        End If
        memberList = If(dataMembers.search(searchParam, False, True).Select(WrappedMember.wrap).ToList, New List(Of WrappedMember))
    End Sub

    Private Sub onPropertyChanged(<CallerMemberName> Optional propName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))

    End Sub

    Private Sub formIsClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing AndAlso Not loggingOut Then
            quit()
        End If
    End Sub

    Private Sub openMember(sender As Object, e As DataGridViewCellEventArgs)
        Dim member = TryCast(dgMemberView.Rows(e.RowIndex).DataBoundItem, IMember)
        Dim memberDetails = New ModifyMemberDialog(member, True)
    End Sub

    Private Sub onExitBtn(sender As Object, e As EventArgs) Handles btnExit.Click
        quit()
    End Sub

    Private Sub onLogoutBtn(sender As Object, e As EventArgs) Handles btnLogout.Click
        loggingOut = True
        logout()
    End Sub

    Private Sub addNewMember(sender As Object, e As EventArgs) Handles btnAddMember.Click
        Dim dialog = New ModifyMemberDialog()
        Dim result = dialog.ShowDialog
        If result = DialogResult.OK Then
            dataManager.memberManager.addEntry(dialog.member)
        End If
    End Sub
End Class