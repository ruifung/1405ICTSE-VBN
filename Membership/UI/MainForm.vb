﻿Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Membership.config

Public Class MainForm
    Implements INotifyPropertyChanged

    Private loggingOut, hasSearch As Boolean
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
                                          Return (rbAllStates.Checked OrElse active) AndAlso typeSelected
                                      End Function)
        End Get
    End Property

    Sub updateFilter() Handles rbActive.CheckedChanged, rbInactive.CheckedChanged, rbAllStates.CheckedChanged, lbTypes.SelectedIndexChanged
        onPropertyChanged("filteredMembers")
        dataSource.DataSource = filteredMembers
    End Sub


    Private Sub onFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        hasSearch = False

        lblDataSource.Text = configuration.DataSourcePath

        If currentUser.accessLevel > 1 Then
            btnManageUsers.Visible = False
            btnManageUsers.Enabled = False
        End If
        If currentUser.accessLevel > 2 Then
            btnReports.Visible = False
            btnReports.Enabled = False
            btnRemoveMembers.Enabled = False
        End If

        memberList = New List(Of WrappedMember)
        lbTypes.DataSource = New BindingSource With {
            .DataSource = (dataManager.memberTypeManager.list.Select(WrappedMembershipType.wrap).ToList)
        }
        lbTypes.DisplayMember = "typeName"
        lbTypes.ValueMember = "id"

        dgMemberView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgMemberView.DataSource = dataSource
        onClearFilters(Me, New EventArgs)
        reload()
    End Sub

    Private Sub onSearch(sender As Object, e As EventArgs) Handles btnSearch.Click
        hasSearch = True
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

    Private Sub openMember(sender As Object, e As DataGridViewCellEventArgs) Handles dgMemberView.CellDoubleClick
        Dim member = TryCast(dgMemberView.Rows(e.RowIndex).DataBoundItem, IMember)
        If member IsNot Nothing Then
            Dim memberDetails = New ModifyMemberDialog(WrappedMember.wrap(member), True)
            memberDetails.ShowDialog()
            reload()
        End If
    End Sub

    Private Sub onExitBtn(sender As Object, e As EventArgs) Handles btnExit.Click
        quit()
    End Sub

    Private Sub onLogoutBtn(sender As Object, e As EventArgs) Handles btnLogout.Click
        loggingOut = True
        logout()
    End Sub

    Private Sub onBtnRemoveMembers(sender As Object, e As EventArgs) Handles btnRemoveMembers.Click
        Dim deleteBilling As Boolean? = Nothing
        Dim list = New List(Of IMember)
        For Each x As DataGridViewRow In dgMemberView.SelectedRows
            exec(TryCast(x.DataBoundItem, IMember), Sub(y) list.Add(y))
        Next
        Dim result = MsgBox(String.Format("Are you sure you want to delete {0} members?", list.Count), MsgBoxStyle.YesNo)
        If result = MsgBoxResult.Yes Then
            list.ForEach(Sub(x)
                             Dim charges = dataManager.paymentManager.listCharges(x).ToList
                             Dim payments = dataManager.paymentManager.listPayments(x).ToList
                             If charges.Count > 0 OrElse payments.Count > 0 Then
                                 If deleteBilling Is Nothing Then
                                     Dim msgResult = MsgBox("Delete related billing information?", MsgBoxStyle.YesNo)
                                     If msgResult = MsgBoxResult.Yes Then
                                         deleteBilling = True
                                     Else
                                         deleteBilling = False
                                     End If
                                 End If

                                 If deleteBilling Then
                                     payments.ForEach(Sub(y) dataManager.paymentManager.removePayment(y))
                                     charges.ForEach(Sub(y) dataManager.paymentManager.removeCharge(y))
                                 Else
                                     MsgBox("Unable to delete member(s) without deleting billing information.", MsgBoxStyle.Information)
                                     Exit Sub
                                 End If
                             End If
                             dataManager.memberManager.removeEntry(x)
                         End Sub)
        End If
        reload()
    End Sub

    Private Sub onClearFilters(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        txtSearch.Clear()
        lbTypes.ClearSelected()
        rbAllStates.Checked = True
        hasSearch = False
        reload()
    End Sub

    Private Sub onBtnChangePass(sender As Object, e As EventArgs) Handles btnChangePass.Click
        Dim dialog = New ChangePasswordDialog(WrappedUser.wrap(currentUser))
        dialog.ShowDialog()
    End Sub

    Private Sub lnkClearTypes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkClearTypes.LinkClicked
        lbTypes.ClearSelected()
    End Sub

    Private Sub btnManageUsers_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        UserManagement.ShowDialog()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Dim form = New ReportView
        form.Show()
    End Sub

    Private Sub reload()
        If hasSearch Then
            onSearch(Me, New EventArgs)
        Else
            memberList = dataManager.memberManager.list.Select(WrappedMember.wrap).ToList
        End If
    End Sub

    Private Sub addNewMember(sender As Object, e As EventArgs) Handles btnAddMember.Click
        Dim dialog = New ModifyMemberDialog()
        Dim result = dialog.ShowDialog
        If result = DialogResult.OK Then
            Dim m = dataManager.memberManager.addEntry(dialog.member)
            If m.isDefined Then
                Dim type = dataManager.memberTypeManager.getEntry(m.getValue.membershipTypeID)
                If type.isDefined Then
                    dataManager.paymentManager.addCharge(m.getValue, Date.Today, "Registration Fees", type.getValue.registrationFees)
                    dataManager.paymentManager.addCharge(m.getValue, Date.Today,
                                                         String.Format("Membership fees - {0}", m.getValue.paymentTerm.ToString),
                                                         type.getValue.monthlyFees * m.getValue.paymentTerm)
                    m.getValue.paymentTermDue = Date.Today
                    dataManager.memberManager.updateEntry(m.getValue)
                End If
            End If
        End If
        onClearFilters(Me, New EventArgs)
    End Sub
End Class