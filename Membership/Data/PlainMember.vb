Imports Membership

Public Class PlainMember
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

    Public Property paymentCredit As Double Implements IMember.paymentCredit

    Sub New()
        _dob = Date.MinValue
        _gender = Gender.NONE
        _id = -1
        _isActive = False
        _membershipTypeID = -1
        _photo = New None(Of Image)
    End Sub
End Class
