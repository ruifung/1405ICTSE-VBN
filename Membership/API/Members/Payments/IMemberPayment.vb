Public Interface IMemberPayment
    Inherits IDataElement

    Property memberID As Integer
    Property chargesPaid As HashSet(Of IMemberCharge)
    Property additionalCharges As Dictionary(Of String, Double)
    Property totalPayable As Double
    Property amountPaid As Double
    Property balance As Double
End Interface
