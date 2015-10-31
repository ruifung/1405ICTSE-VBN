Imports Membership

Public Class MemberDetails
    Implements IMember

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim items = [Enum].GetValues(GetType(Gender))
        Dim genderList = New List(Of Tuple(Of Gender, String))
        For Each X As Gender In items
            Dim str = X.ToString
            str = String.Concat(str.Substring(0, 1).ToUpper, str.Substring(1).ToLower)
            genderList.Add(Tuple.Create(X, str))
        Next
        Me.cbGender.DisplayMember = "Item2"
        Me.cbGender.ValueMember = "Item1"

        Me.cbMembershipType.DataSource = dataManager.memberTypeManager.list
        Me.cbMembershipType.ValueMember = "typeID"
    End Sub

    Overrides Sub Refresh()
        MyBase.Refresh()
        Me.cbMembershipType.DataSource = dataManager.memberTypeManager.list
    End Sub

    WriteOnly Property displayMember As IMember
        Set(member As IMember)
            Me.id = member.id
            Me.firstName = member.firstName
            Me.lastName = member.lastName
            Me.contactNumber = member.contactNumber
            Me.email = member.email
            Me.dob = member.dob
            Me.gender = member.gender
            Me.photo = member.photo
            Me.isActive = member.isActive
            Me.membershipTypeID = member.membershipTypeID
        End Set
    End Property

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

    Public Property contactNumber As String Implements IMember.contactNumber
        Get
            Return txtContact.Text
        End Get
        Set(value As String)
            txtContact.Text = value
        End Set
    End Property

    Public Property email As String Implements IMember.email
        Get
            Return txtEmail.Text
        End Get
        Set(value As String)
            txtEmail.Text = value
        End Set
    End Property

    Public Property firstName As String Implements IMember.firstName
        Get
            Return txtFName.Text
        End Get
        Set(value As String)
            txtFName.Text = value
        End Set
    End Property

    Public Shadows Property id As Integer Implements IDataElement.id
        Get
            Return CInt(txtID.Text)
        End Get
        Set(value As Integer)
            txtID.Text = value.ToString
        End Set
    End Property

    Public Property isActive As Boolean Implements IMember.isActive
        Get
            Return cbStatus.SelectedIndex = 0
        End Get
        Set(value As Boolean)
            cbStatus.SelectedIndex = If(isActive, 0, 1)
        End Set
    End Property

    Public Property lastName As String Implements IMember.lastName
        Get
            Return txtLName.Text
        End Get
        Set(value As String)
            txtLName.Text = value
        End Set
    End Property

    Public Property membershipTypeID As Integer Implements IMember.membershipTypeID
        Get
            Return CInt(cbMembershipType.SelectedValue)
        End Get
        Set(value As Integer)
            For i = 0 To cbMembershipType.Items.Count - 1
                Dim item = CType(cbMembershipType.Items.Item(i), MembershipType)
                If item.typeID = value Then
                    cbMembershipType.SelectedIndex = i
                    Return
                End If
                cbMembershipType.SelectedIndex = -1
            Next

        End Set
    End Property

    Public Property photo As MaybeOption(Of Image) Implements IMember.photo
        Get
            Return MaybeOption.create(pbPhoto.Image)
        End Get
        Set(value As MaybeOption(Of Image))
            pbPhoto.Image = value.orNothing
        End Set
    End Property

    Public Property dob As Date Implements IMember.dob
        Get
            Return dtDOB.Value
        End Get
        Set(value As Date)
            dtDOB.Value = value
        End Set
    End Property

    Public Property gender As Gender Implements IMember.gender
        Get
            Return CType(cbGender.SelectedValue, Gender)
        End Get
        Set(value As Gender)
            For i = 0 To cbGender.Items.Count - 1
                Dim item = CType(cbGender.Items.Item(i), Tuple(Of Gender, String))
                If item.Item1.Equals(value) Then
                    cbGender.SelectedIndex = i
                End If
                cbGender.SelectedIndex = -1
            Next
        End Set
    End Property
End Class
