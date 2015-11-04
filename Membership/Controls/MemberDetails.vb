Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Membership

Public Class MemberDetails
    Implements IMember
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private selfBind As BindingSource = New BindingSource With {.DataSource = Me}
    Private memberBinding As BindingSource = New BindingSource
    Private propBindings As List(Of Binding) = New List(Of Binding)

    Private _firstName, _lastName, _contactNumber, _address, _email As String
    Private _dob As Date, _gender As Gender, _photo As MaybeOption(Of Image)
    Private _id, _membershipTypeID As Integer, _isActive As Boolean
    Private _paymentCredit As Double, initialized As Boolean

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
            onPropertyChanged()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property id As Integer Implements IDataElement.id
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property firstName As String Implements IMember.firstName
        Get
            Return _firstName
        End Get
        Set(value As String)
            _firstName = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property lastName As String Implements IMember.lastName
        Get
            Return _lastName
        End Get
        Set(value As String)
            _lastName = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property contactNumber As String Implements IMember.contactNumber
        Get
            Return _contactNumber
        End Get
        Set(value As String)
            _contactNumber = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property address As String Implements IMember.address
        Get
            Return _address
        End Get
        Set(value As String)
            _address = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property email As String Implements IMember.email
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property dob As Date Implements IMember.dob
        Get
            Return _dob
        End Get
        Set(value As Date)
            If value >= MinDate AndAlso value <= MaxDate Then
                _dob = value
            Else
                _dob = MinDate
            End If
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property gender As Gender Implements IMember.gender
        Get
            Return _gender
        End Get
        Set(value As Gender)
            _gender = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property photo As MaybeOption(Of Image) Implements IMember.photo
        Get
            Return _photo
        End Get
        Set(value As MaybeOption(Of Image))
            _photo = If(IsNothing(value), New None(Of Image), value)
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property isActive As Boolean Implements IMember.isActive
        Get
            Return _isActive
        End Get
        Set(value As Boolean)
            _isActive = value
            onPropertyChanged()
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property membershipTypeID As Integer Implements IMember.membershipTypeID
        Get
            Return _membershipTypeID
        End Get
        Set(value As Integer)
            _membershipTypeID = value
            onPropertyChanged()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property paymentCredit As Double Implements IMember.paymentCredit
        Get
            Return _paymentCredit
        End Get
        Set(value As Double)
            _paymentCredit = value
            onPropertyChanged()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property MinDate As Date
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property MaxDate As Date
    Public noIDString As String = "*new*"

    Public Property BoundMember As IMember
        Get
            Return CType(memberBinding.DataSource, IMember)
        End Get
        Set(value As IMember)
            Dim oldV = BoundMember
            If value Is Nothing Then
                propBindings.ForEach(Sub(x) Me.DataBindings.Remove(x))
                propBindings.Clear()
                memberBinding.DataSource = value
                clear()
            ElseIf value IsNot Nothing AndAlso oldV Is Nothing Then
                memberBinding.DataSource = value
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
                propBindings.ForEach(Sub(x) Me.DataBindings.Add(x))
            Else
                memberBinding.DataSource = value
            End If
            onPropertyChanged()
        End Set
    End Property

    Sub initializeControl() Handles Me.ControlAdded
        If initialized Then
            Exit Sub
        End If

        Me.clear()
        MinDate = Date.MinValue
        MaxDate = Date.MaxValue

        Dim genderDisplay = New List(Of DisplayGender)
        For Each x As Gender In [Enum].GetValues(GetType(Gender))
            genderDisplay.Add(New DisplayGender(x, If(x = Gender.NONE, String.Empty, x.ToString)))
        Next
        cbGender.DataSource = genderDisplay
        cbGender.ValueMember = "gender"
        cbGender.DisplayMember = "display"

        cbMembershipType.DataSource = New BindingSource With {
            .DataSource = MaybeOption.create(Util.exec(dataManager, Function(x) x.memberTypeManager)) _
                .map(Function(x) x.list) _
                .getOrAlt(New List(Of IMembershipType))
        }
        cbMembershipType.DisplayMember = "typeName"
        cbMembershipType.ValueMember = "typeID"

        cbStatus.DataSource = New List(Of DisplayStatus) From {
            New DisplayStatus(True, "Active"),
            New DisplayStatus(False, "Inactive")
        }
        cbStatus.DisplayMember = "display"
        cbStatus.ValueMember = "status"

        ' Bindings
        Dim binding As Binding
        binding = New Binding("Text", selfBind, "id", True)
        AddHandler binding.Format, Sub(s As Object, e As ConvertEventArgs)
                                       If IsDBNull(e.Value) Then
                                           e.Value = -1
                                           Exit Sub
                                       End If
                                       e.Value = If(CInt(e.Value) >= 0, e.Value.ToString, noIDString)
                                   End Sub
        AddHandler binding.Parse, Sub(s As Object, e As ConvertEventArgs)
                                      If IsDBNull(e.Value) Then
                                          e.Value = -1
                                          Exit Sub
                                      End If
                                      Dim tID As Integer
                                      If CStr(e.Value) = noIDString Then
                                          e.Value = -1
                                      ElseIf Integer.TryParse(CStr(e.Value), tID) Then
                                          e.Value = tID
                                      Else
                                          e.Value = -1
                                      End If
                                  End Sub

        txtID.DataBindings.Add(binding)
        txtFName.DataBindings.Add("Text", selfBind, "firstName")
        txtLName.DataBindings.Add("Text", selfBind, "lastName")
        txtContact.DataBindings.Add("Text", selfBind, "contactNumber")
        txtAddress.DataBindings.Add("Text", selfBind, "address")
        txtEmail.DataBindings.Add("Text", selfBind, "email")
        dtDOB.DataBindings.Add("MinDate", selfBind, "MinDate", False, DataSourceUpdateMode.OnPropertyChanged)
        dtDOB.DataBindings.Add("MaxDate", selfBind, "MaxDate", False, DataSourceUpdateMode.OnPropertyChanged)
        dtDOB.DataBindings.Add("Value", selfBind, "dob", False, DataSourceUpdateMode.OnPropertyChanged)
        cbGender.DataBindings.Add("SelectedValue", selfBind, "gender", False, DataSourceUpdateMode.OnPropertyChanged)
        binding = New Binding("SelectedValue", selfBind, "isActive", True, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler binding.Format, Sub(s As Object, e As ConvertEventArgs)
                                       If IsDBNull(e.Value) Then
                                           e.Value = -1
                                           Exit Sub
                                       End If
                                       e.Value = If(CBool(e.Value), 1, 0)
                                   End Sub
        AddHandler binding.Parse, Sub(s As Object, e As ConvertEventArgs)
                                      If IsDBNull(e.Value) Then
                                          e.Value = -1
                                          Exit Sub
                                      End If
                                      Select Case CInt(e.Value)
                                          Case 0
                                              e.Value = False
                                          Case 1
                                              e.Value = True
                                      End Select
                                  End Sub
        cbStatus.DataBindings.Add(binding)
        binding = New Binding("SelectedIndex", selfBind, "membershipTypeID", True, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler binding.Format, Sub(s As Object, e As ConvertEventArgs)
                                       If IsDBNull(e.Value) Then
                                           e.Value = -1
                                           Exit Sub
                                       End If
                                       Dim tID = CInt(e.Value)
                                       If tID >= 0 Then
                                           For x = 0 To cbMembershipType.Items.Count - 1
                                               If CType(cbMembershipType.Items(x), IMembershipType).id = tID Then
                                                   e.Value = x
                                                   Exit Sub
                                               End If
                                           Next
                                       End If
                                       e.Value = -1
                                   End Sub
        AddHandler binding.Parse, Sub(s As Object, e As ConvertEventArgs)
                                      If IsDBNull(e.Value) Then
                                          e.Value = -1
                                          Exit Sub
                                      End If
                                      Dim tID = CInt(e.Value)
                                      If tID >= 0 Then
                                          e.Value = CType(cbMembershipType.Items(tID), IMembershipType).id
                                      End If
                                      e.Value = -1
                                  End Sub
        cbMembershipType.DataBindings.Add(binding)
        binding = New Binding("Image", selfBind, "photo", True, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler binding.Format, Sub(s As Object, e As ConvertEventArgs)
                                       If IsDBNull(e.Value) Then
                                           e.Value = Nothing
                                       Else
                                           e.Value = CType(e.Value, MaybeOption(Of Image)).orNothing
                                       End If
                                   End Sub
        AddHandler binding.Parse, Sub(s As Object, e As ConvertEventArgs)
                                      If IsDBNull(e.Value) Then
                                          e.Value = New None(Of Image)
                                      Else
                                          e.Value = MaybeOption.create(CType(e.Value, Image))
                                      End If
                                  End Sub
        pbPhoto.DataBindings.Add(binding)
        initialized = True
    End Sub

    Sub clear()
        id = -1
        firstName = String.Empty
        lastName = String.Empty
        contactNumber = String.Empty
        address = String.Empty
        email = String.Empty
        dob = DateTime.Now
        gender = Gender.NONE
        photo = New None(Of Image)
        isActive = False
        membershipTypeID = -1
    End Sub

    Sub onPropertyChanged(<CallerMemberName> Optional propName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
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
        Property status As Integer
        Property display As String
        Sub New(b As Boolean, d As String)
            Me.status = If(b, 1, 0)
            Me.display = d
        End Sub
    End Class
End Class
