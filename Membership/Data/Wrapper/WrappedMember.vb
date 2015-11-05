Imports System.ComponentModel

Public Class WrappedMember
    Implements IMember

    Public Shared wrap As Func(Of IMember, WrappedMember) =
        Function(member As IMember) As WrappedMember
            Return If(TryCast(member, WrappedMember), New WrappedMember(member))
        End Function

    Public ReadOnly _backingMember As IMember

    <DisplayName("ID")>
    Public ReadOnly Property id As Integer Implements IDataElement.id
        Get
            Return _backingMember.id
        End Get
    End Property

    <DisplayName("First Name")>
    Public Property firstName As String Implements IMember.firstName
        Get
            Return _backingMember.firstName
        End Get
        Set(value As String)
            _backingMember.firstName = value
        End Set
    End Property

    <DisplayName("Last Name")>
    Public Property lastName As String Implements IMember.lastName
        Get
            Return _backingMember.lastName
        End Get
        Set(value As String)
            _backingMember.lastName = value
        End Set
    End Property

    <DisplayName("Telephone Number")>
    Public Property contactNumber As String Implements IMember.contactNumber
        Get
            Return _backingMember.contactNumber
        End Get
        Set(value As String)
            _backingMember.contactNumber = value
        End Set
    End Property

    <DisplayName("E-Mail")>
    Public Property email As String Implements IMember.email
        Get
            Return _backingMember.email
        End Get
        Set(value As String)
            _backingMember.email = value
        End Set
    End Property

    <DisplayName("Address")>
    Public Property address As String Implements IMember.address
        Get
            Return _backingMember.address
        End Get
        Set(value As String)
            _backingMember.address = value
        End Set
    End Property

    <DisplayName("Birthday")>
    Public Property dob As Date Implements IMember.dob
        Get
            Return _backingMember.dob
        End Get
        Set(value As Date)
            _backingMember.dob = value
        End Set
    End Property

    <DisplayName("Gender")>
    Public Property gender As Gender Implements IMember.gender
        Get
            Return _backingMember.gender
        End Get
        Set(value As Gender)
            _backingMember.gender = value
        End Set
    End Property

    <DisplayName("Membership State")>
    Public Property isActive As Boolean Implements IMember.isActive
        Get
            Return _backingMember.isActive
        End Get
        Set(value As Boolean)
            _backingMember.isActive = value
        End Set
    End Property

    <DisplayName("Membership Type")>
    Public Property membershipTypeID As Integer Implements IMember.membershipTypeID
        Get
            Return _backingMember.membershipTypeID
        End Get
        Set(value As Integer)
            _backingMember.membershipTypeID = value
        End Set
    End Property

    <DisplayName("Payment Credit")>
    Public Property paymentCredit As Decimal Implements IMember.paymentCredit
        Get
            Return _backingMember.paymentCredit
        End Get
        Set(value As Decimal)
            _backingMember.paymentCredit = value
        End Set
    End Property

    <DisplayName("Payment Term")>
    Public Property paymentTerm As PaymentTerm Implements IMember.paymentTerm
        Get
            Return _backingMember.paymentTerm
        End Get
        Set(value As PaymentTerm)
            _backingMember.paymentTerm = value
        End Set
    End Property

    <DisplayName("Payment Term Due")>
    Public Property paymentTermDue As Date Implements IMember.paymentTermDue
        Get
            Return _backingMember.paymentTermDue
        End Get
        Set(value As Date)
            _backingMember.paymentTermDue = value
        End Set
    End Property

    <DisplayName("Photo")>
    Public Property photo As MaybeOption(Of Image) Implements IMember.photo
        Get
            Return _backingMember.photo
        End Get
        Set(value As MaybeOption(Of Image))
            _backingMember.photo = value
        End Set
    End Property

    Sub New(backingMember As IMember)
        _backingMember = backingMember
    End Sub
End Class
