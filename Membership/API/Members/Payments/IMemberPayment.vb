Public Interface IMemberPayment
    Inherits IDataElement

    Property memberID As Integer
    Property chargesPaid As HashSet(Of IMemberCharge)
    Property additionalCharges As Dictionary(Of String, Decimal)
    Property totalPayable As Decimal
    Property amountPaid As Decimal
    Property balance As Decimal
End Interface
