Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class DBConfigDialog
    Implements INotifyPropertyChanged

    Private _DSPath, _DSType, _DSUser, _DSPass As String
    Private _DSAuth As Boolean, _DSTypes As List(Of DBTypes)
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

    Property DSTypes As List(Of DBTypes)
        Get
            Return _DSTypes
        End Get
        Set(value As List(Of DBTypes))
            If IsNothing(value) Then
                _DSTypes = New List(Of DBTypes)
            Else
                _DSTypes = value
            End If
            onPropertyChanged()
        End Set
    End Property


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cbDSSelector.DataBindings.Add("SelectedValue", selfBind, "DSType")
        txtDSPath.DataBindings.Add("Text", selfBind, "DSPath")
        chkDSAuth.DataBindings.Add("Checked", selfBind, "DSAuth")
        txtDSAuthName.DataBindings.Add("Text", selfBind, "DSUser")
        txtDSAuthPass.DataBindings.Add("Text", selfBind, "DSPass")
    End Sub

    Sub onPropertyChanged(<CallerMemberName> Optional propName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub

    Private Sub DSBtn_Click(sender As Object, e As EventArgs) Handles DSBtn.Click
        Dim dialog = New OpenFileDialog With {
            .Multiselect = False
        }
        Dim result = dialog.ShowDialog()
        If result = DialogResult.OK Then
            DSPath = dialog.FileName
        End If
    End Sub
End Class