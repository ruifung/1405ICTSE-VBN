Public Interface IMemberPayment
    Inherits IPaymentInvoice

    Property amountPaid As Decimal
    Property balance As Decimal
    Property userID As Integer
End Interface
