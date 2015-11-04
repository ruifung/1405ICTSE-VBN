﻿Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Membership.config

Public Class DBConfigDialog
    Implements INotifyPropertyChanged

    Private _DSPath, _DSType, _DSUser, _DSPass As String
    Private _DSAuth As Boolean, _DSTypes As List(Of DBType)
    Private selfBind As BindingSource = New BindingSource With {.DataSource = Me}
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Property DSType As String
        Get
            Return _DSType
        End Get
        Set(value As String)
            _DSType = value
            onPropertyChanged()
        End Set
    End Property
    Property DSPath As String
        Get
            Return _DSPath
        End Get
        Set(value As String)
            _DSPath = value
            onPropertyChanged()
        End Set
    End Property
    Property DSAuth As Boolean
        Get
            Return _DSAuth
        End Get
        Set(value As Boolean)
            _DSAuth = value
            onPropertyChanged()
        End Set
    End Property
    Property DSUser As String
        Get
            Return _DSUser
        End Get
        Set(value As String)
            _DSUser = value
            onPropertyChanged()
        End Set
    End Property
    Property DSPass As String
        Get
            Return _DSPass
        End Get
        Set(value As String)
            _DSPass = value
            onPropertyChanged()
        End Set
    End Property

    Private Sub onCancel(sender As Object, e As EventArgs) Handles btnCancel.Click
        cbDSSelector.DataBindings.Clear()
        txtDSPath.DataBindings.Clear()
        chkDSAuth.DataBindings.Clear()
        txtDSAuthName.DataBindings.Clear()
        txtDSAuthPass.DataBindings.Clear()
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub onSave(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub chkDSAuth_CheckedChanged(sender As Object, e As EventArgs) Handles chkDSAuth.CheckedChanged
        txtDSAuthName.Enabled = chkDSAuth.Checked
        txtDSAuthPass.Enabled = chkDSAuth.Checked
    End Sub

    Private Sub cbDSSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDSSelector.SelectedIndexChanged
        Dim item = CType(cbDSSelector.SelectedItem, DBType)
        Util.exec(item, Sub(x) DSBtn.Visible = x.isFileBased)
    End Sub

    Property DSTypes As List(Of DBType)
        Get
            Return If(_DSTypes, New List(Of DBType))
        End Get
        Set(value As List(Of DBType))
            If IsNothing(value) Then
                _DSTypes = New List(Of DBType)
            Else
                _DSTypes = value
            End If
            onPropertyChanged()
        End Set
    End Property

    Sub onFormLoad() Handles Me.Load
        cbDSSelector.DataBindings.Add("SelectedValue", selfBind, "DSType")
        txtDSPath.DataBindings.Add("Text", selfBind, "DSPath")
        chkDSAuth.DataBindings.Add("Checked", selfBind, "DSAuth")
        txtDSAuthName.DataBindings.Add("Text", selfBind, "DSUser")
        txtDSAuthPass.DataBindings.Add("Text", selfBind, "DSPass")

        cbDSSelector.DataSource = DSTypes
        cbDSSelector.DisplayMember = "display"
        cbDSSelector.ValueMember = "type"
    End Sub

    Sub onPropertyChanged(<CallerMemberName> Optional propName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub

    Private Sub DSBtn_Click(sender As Object, e As EventArgs) Handles DSBtn.Click
        Dim dialog = New SaveFileDialog With {
            .Title = "Select Database File"
        }
        Dim result = dialog.ShowDialog()
        If result = DialogResult.OK Then
            DSPath = dialog.FileName
        End If
    End Sub
End Class