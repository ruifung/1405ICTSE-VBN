Imports Membership

Public Class MemberDetailsTest
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim member = New PlainMember With {
            .address = "Somewhere on Earth",
            .contactNumber = "0123456789",
            .dob = New Date(1996, 06, 19),
            .email = "example@example.com",
            .firstName = "MyFirstName",
            .gender = Gender.Male,
            .isActive = True,
            .lastName = "MyLastName",
            .membershipTypeID = -1,
            .photo = New None(Of Image),
            .id = (New Random).Next()
        }
        MemberDetails1.BoundMember = member
        MemberDetails2.BoundMember = member
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MemberDetails1.BoundMember = Nothing
        MemberDetails2.BoundMember = Nothing
    End Sub
End Class