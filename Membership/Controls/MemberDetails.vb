Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Membership

Public Class MemberDetails
    Implements IMember

    Private selfBind As BindingSource = New BindingSource With {.DataSource = Me}
    Private memberBinding As BindingSource = New BindingSource
    Private propBindings As List(Of Binding) = New List(Of Binding)

    Overloads Property Enabled As Boolean
        Get
            Return MyBase.Enabled
        End Get
        Set(value As Boolean)
            MyBase.Enabled = value
            txtAddress.Enabled = value
            txtContact.Enabled = value
            txtFName.Enabled = value
            txtLName.Enabled = value
            txtEmail.Enabled = value
            dtDOB.Enabled = value
            cbGender.Enabled = value
            cbStatus.Enabled = value
            cbMembershipType.Enabled = value
        End Set
    End Property

    Public Property id As Integer Implements IDataElement.id
    Public Property firstName As String Implements IMember.firstName
    Public Property lastName As String Implements IMember.lastName
    Public Property contactNumber As String Implements IMember.contactNumber
    Public Property address As String Implements IMember.address
    Public Property email As String Implements IMember.email
    Public Property dob As Date Implements IMember.dob
    Public Property gender As Gender Implements IMember.gender
    Public Property photo As MaybeOption(Of Image) Implements IMember.photo
    Public Property isActive As Boolean Implements IMember.isActive
    Public Property membershipTypeID As Integer Implements IMember.membershipTypeID

    ''' <summary>
    ''' Helper property for data binding.
    ''' </summary>
    Public Property image As Image
        Get
            Return photo.orNothing
        End Get
        Set(value As Image)
            photo = MaybeOption.create(value)
        End Set
    End Property

    Public Property BoundMember As IMember
        Get
            Return CType(memberBinding.DataSource, IMember)
        End Get
        Set(value As IMember)
            If value Is Nothing AndAlso BoundMember IsNot Nothing Then
                propBindings.ForEach(Sub(x) Me.DataBindings.Remove(x))
                propBindings.Clear()
            ElseIf value IsNot Nothing AndAlso BoundMember Is Nothing Then
                Dim m = DataSourceUpdateMode.OnPropertyChanged
                With propBindings
                    .Add(New Binding("id", memberBinding, "id", False, m))
                    .Add(New Binding("firstName", memberBinding, "firstName", False, m))
                    .Add(New Binding("lastName", memberBinding, "lastName", False, m))
                    .Add(New Binding("contactNumber", memberBinding, "contactNumber", False, m))
                    .Add(New Binding("address", memberBinding, "address", False, m))
                    .Add(New Binding("email", memberBinding, "email", False, m))
                    .Add(New Binding("dob", memberBinding, "dob", False, m))
                    .Add(New Binding("gender", memberBinding, "gender", False, m))
                    .Add(New Binding("photo", memberBinding, "photo", False, m))
                    .Add(New Binding("isActive", memberBinding, "isActive", False, m))
                    .Add(New Binding("membershipTypeID", memberBinding, "membershipTypeID", False, m))
                End With
                For Each x In propBindings
                    Me.DataBindings.Add(x)
                Next
            End If
            memberBinding.DataSource = value
        End Set
    End Property

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.clear()
        ' So the designer doesn't throw a big bunch of errors!
        If Not Util.IsInDesignMode Then
            Dim genderDisplay = New List(Of DisplayGender)
            For Each x As Gender In [Enum].GetValues(GetType(Gender))
                genderDisplay.Add(New DisplayGender(x, If(x = Gender.NONE, String.Empty, x.ToString)))
            Next
            cbGender.DataSource = genderDisplay
            cbGender.ValueMember = "gender"
            cbGender.DisplayMember = "display"

            cbMembershipType.DataSource = New BindingSource With {.DataSource = dataManager.memberTypeManager.list}
            cbMembershipType.DisplayMember = "typeName"
            cbMembershipType.ValueMember = "typeID"

            cbStatus.DataSource = New List(Of DisplayStatus) From {
                New DisplayStatus(True, "Active"),
                New DisplayStatus(False, "Inactive")
            }
            cbStatus.DisplayMember = "display"
            cbStatus.ValueMember = "status"

            ' Bindings
            txtID.DataBindings.Add("Text", selfBind, "id", True)
            txtFName.DataBindings.Add("Text", selfBind, "firstName")
            txtLName.DataBindings.Add("Text", selfBind, "lastName")
            txtContact.DataBindings.Add("Text", selfBind, "contactNumber")
            txtAddress.DataBindings.Add("Text", selfBind, "address")
            txtEmail.DataBindings.Add("Text", selfBind, "email")
            dtDOB.DataBindings.Add("Value", selfBind, "dob")
            cbGender.DataBindings.Add("SelectedValue", selfBind, "gender")
            cbMembershipType.DataBindings.Add("SelectedValue", selfBind, "membershipTypeID")
            cbStatus.DataBindings.Add("SelectedValue", selfBind, "isActive")
            pbPhoto.DataBindings.Add("Image", selfBind, "image")
        End If
    End Sub

    Sub clear()
        id = -1
        firstName = String.Empty
        lastName = String.Empty
        contactNumber = String.Empty
        address = String.Empty
        email = String.Empty
        dob = New Date
        gender = Gender.NONE
        photo = New None(Of Image)
        isActive = False
        membershipTypeID = -1
    End Sub

    ' Container Classes for display.

    Private Class DisplayGender
        Property gender As Gender
        Property display As String
        Sub New(g As Gender, d As String)
            Me.gender = g
            Me.display = d
        End Sub
    End Class

    Private Class DisplayStatus
        Property status As Boolean
        Property display As String
        Sub New(b As Boolean, d As String)
            Me.status = b
            Me.display = d
        End Sub
    End Class
End Class
