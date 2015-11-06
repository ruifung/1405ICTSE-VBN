Imports Membership

Public Class WrappedPayment
    Implements IMemberPayment
    Public ReadOnly _backingPayment As IMemberPayment
    Public Shared wrap As Func(Of IMemberPayment, WrappedPayment) =
        Function(x)
            Return If(TryCast(x, WrappedPayment), New WrappedPayment(x))
        End Function

    Public Property additionalCharges As Dictionary(Of String, Decimal) Implements IPaymentInvoice.additionalCharges
        Get
            Return _backingPayment.additionalCharges
        End Get
        Set(value As Dictionary(Of String, Decimal))
            _backingPayment.additionalCharges = value
        End Set
    End Property

    Public Property amountPaid As Decimal Implements IMemberPayment.amountPaid
        Get
            Return _backingPayment.amountPaid
        End Get
        Set(value As Decimal)
            _backingPayment.amountPaid = value
        End Set
    End Property

    Public Property balance As Decimal Implements IMemberPayment.balance
        Get
            Return _backingPayment.balance
        End Get
        Set(value As Decimal)
            _backingPayment.balance = value
        End Set
    End Property

    Public Property chargesPaid As HashSet(Of IMemberCharge) Implements IPaymentInvoice.chargesPaid
        Get
            Return _backingPayment.chargesPaid
        End Get
        Set(value As HashSet(Of IMemberCharge))
            _backingPayment.chargesPaid = value
        End Set
    End Property

    Public ReadOnly Property id As Integer Implements IDataElement.id
        Get
            Return _backingPayment.id
        End Get
    End Property

    Public Property memberID As Integer Implements IPaymentInvoice.memberID
        Get
            Return _backingPayment.memberID
        End Get
        Set(value As Integer)
            _backingPayment.memberID = value
        End Set
    End Property

    Public Property totalPayable As Decimal Implements IPaymentInvoice.totalPayable
        Get
            Return _backingPayment.totalPayable
        End Get
        Set(value As Decimal)
            _backingPayment.totalPayable = value
        End Set
    End Property

    Public Property userID As Integer Implements IMemberPayment.userID
        Get
            Return _backingPayment.userID
        End Get
        Set(value As Integer)
            _backingPayment.userID = value
        End Set
    End Property

    Sub New(payment As IMemberPayment)
        _backingPayment = payment
    End Sub
End Class
