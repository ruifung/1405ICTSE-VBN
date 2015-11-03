Public Interface IPaymentManager
    Function getUnpaidCharges(member As IMember) As HashSet(Of IMemberCharge)
    Function pay(charges As HashSet(Of IMemberCharge), amount As Double) As IMemberPayment
    Function undo(payment As IMemberPayment) As IMemberPayment

    Function listCharges(member As IMember, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberCharge)
    Function listCharges(memberID As Integer, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberCharge)

    Function listPayments(member As IMember, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberPayment)
    Function listPayments(memberID As Integer, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberPayment)
End Interface
