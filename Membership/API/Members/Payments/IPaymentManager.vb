Public Interface IPaymentManager
    'Probably should cache the result from this.
    Function getUnpaidCharges(member As IMember) As HashSet(Of IMemberCharge)

    Function addCharge(member As IMember, timestamp As Date, desc As String, amount As Decimal) As IMemberCharge

    Function invoice(member As IMember, charges As HashSet(Of IMemberCharge)) As IPaymentInvoice
    Function pay(invoice As IPaymentInvoice, amount As Decimal) As IMemberPayment

    Function removePayment(payment As IMemberPayment) As Boolean
    ''' <summary>
    ''' Must have no payment referencing this charge to remove.
    ''' </summary>
    ''' <param name="charge">Charge to remove</param>
    ''' <returns></returns>
    Function removeCharge(charge As IMemberCharge) As Boolean

    Function getCharge(chargeID As Integer) As IMemberCharge
    Function listCharges(member As IMember, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberCharge)
    Function listCharges(memberID As Integer, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberCharge)
    Function updateCharge(charge As IMemberCharge) As Boolean

    Function getPayment(paymentID As Integer) As IMemberPayment
    Function listPayments(member As IMember, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberPayment)
    Function listPayments(memberID As Integer, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberPayment)
    Function updatePayment(payment As IMemberPayment) As Boolean
End Interface
