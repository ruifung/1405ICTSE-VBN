Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class MainForm
    Implements INotifyPropertyChanged

    Private dataMembers As IDataManager(Of IMember) = dataManager.memberManager
    Private _memberList As List(Of IMember)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Property memberList As List(Of IMember)
        Get
            Return _memberList
        End Get
        Set(value As List(Of IMember))
            _memberList = value
            onPropertyChanged()
            onFilteredChange()
        End Set
    End Property

    ReadOnly Property filteredMembers As List(Of IMember)
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

    Sub onFilteredChange()
        onPropertyChanged("filteredMembers")
    End Sub


    Private Sub onFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        memberList = New List(Of IMember)
        lbTypes.DataSource = New BindingSource With {
            .DataSource = dataManager.memberTypeManager.list
        }
        lbTypes.DisplayMember = "typeName"
        lbTypes.ValueMember = "typeID"
    End Sub

    Private Sub onSearch(sender As Object, e As EventArgs) Handles btnSearch.Click
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
        memberList = If(dataMembers.search(searchParam, False, True), New List(Of IMember))
    End Sub

    Private Sub onPropertyChanged(<CallerMemberName> Optional propName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))

    End Sub

End Class