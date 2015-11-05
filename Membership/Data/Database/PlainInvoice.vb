Public Class PlainInvoice
    Implements IPaymentInvoice

    Public invoiceID As Integer

    Public ReadOnly Property id As Integer Implements IDataElement.id
        Get
            Return invoiceID
        End Get
    End Property

    Public Property additionalCharges As Dictionary(Of String, Decimal) Implements IPaymentInvoice.additionalCharges

    Public Property chargesPaid As HashSet(Of IMemberCharge) Implements IPaymentInvoice.chargesPaid

    Public Property memberID As Integer Implements IPaymentInvoice.memberID

    Public Property totalPayable As Decimal Implements IPaymentInvoice.totalPayable

    Public Sub New()
        additionalCharges = New Dictionary(Of String, Decimal)
        chargesPaid = New HashSet(Of IMemberCharge)
        memberID = 0
        totalPayable = 0
    End Sub
End Class
