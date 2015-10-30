Imports Membership

Public Class MemberDetails
    Implements IMember

    WriteOnly Property displayMember As IMember
        Set(member As IMember)
            Me.id = member.id
            Me.firstName = member.firstName
            Me.lastName = member.lastName
            Me.contactNumber = member.contactNumber
            Me.email = member.email
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
            numAge.Enabled = value
            cbGender.Enabled = value
            cbStatus.Enabled = value
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
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
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
End Class
