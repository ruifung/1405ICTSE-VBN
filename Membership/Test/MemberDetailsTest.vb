Imports Membership

Public Class MemberDetailsTest
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim member = New TestMember With {
            .address = "Somewhere on Earth",
            .contactNumber = "0123456789",
            .dob = New Date(1996, 06, 19),
            .email = "example@example.com",
            .firstName = "MyFirstName",
            .gender = Gender.Male,
            .isActive = True,
            .lastName = "MyLastName",
            .membershipTypeID = -1,
            .photo = New None(Of Image)
        }
        MemberDetails1.BoundMember = member
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MemberDetails1.BoundMember = Nothing
    End Sub

    Private Class TestMember
        Implements IMember
        Public Property address As String Implements IMember.address
        Public Property contactNumber As String Implements IMember.contactNumber
        Public Property dob As Date Implements IMember.dob
        Public Property email As String Implements IMember.email
        Public Property firstName As String Implements IMember.firstName
        Public Property gender As Gender Implements IMember.gender
        Public ReadOnly Property id As Integer Implements IDataElement.id
        Public Property isActive As Boolean Implements IMember.isActive
        Public Property lastName As String Implements IMember.lastName
        Public Property membershipTypeID As Integer Implements IMember.membershipTypeID
        Public Property photo As MaybeOption(Of Image) Implements IMember.photo
    End Class
End Class