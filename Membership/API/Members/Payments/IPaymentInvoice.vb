Public Interface IPaymentInvoice
    Inherits IDataElement

    Property memberID As Integer
    Property chargesPaid As HashSet(Of IMemberCharge)
    Property additionalCharges As Dictionary(Of String, Decimal)
    Property totalPayable As Decimal
End Interface
