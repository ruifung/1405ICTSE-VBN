Imports MDB
Namespace Database
    Public Class PaymentManager
        Implements IPaymentManager

        Public Function addCharge(member As IMember, timestamp As Date, desc As String, amount As Decimal) As IMemberCharge Implements IPaymentManager.addCharge
            Dim c As Charge = New Charge
            c.amount = amount
            c.memberID = member.id
            c.timestamp = timestamp
            c.description = desc
            c.Insert()
            Return c
        End Function

        Public Function getCharge(chargeID As Integer) As IMemberCharge Implements IPaymentManager.getCharge
            Return DBObject.Find(Of Charge)(chargeID)
        End Function

        Public Function getPayment(paymentID As Integer) As IMemberPayment Implements IPaymentManager.getPayment
            Return DBObject.Find(Of Payment)(paymentID)
        End Function

        Public Function getUnpaidCharges(member As IMember) As HashSet(Of IMemberCharge) Implements IPaymentManager.getUnpaidCharges
            Return New HashSet(Of IMemberCharge)(DBList(Of Charge).Query("member=? AND paid_in=0", MDBType.Number.asParam(member.id)))
        End Function

        Public Function invoice(charges As HashSet(Of IMemberCharge)) As IPaymentInvoice Implements IPaymentManager.invoice

        End Function

        Public Function listCharges(memberID As Integer, Optional minDate As Date = #12:00:00 AM#, Optional maxDate As Date = #12:00:00 AM#) As HashSet(Of IMemberCharge) Implements IPaymentManager.listCharges

            Return New HashSet(Of IMemberCharge)(DBList(Of Charge).Query("member=?", MDBType.Number.asParam(memberID)))
        End Function

        Public Function listCharges(member As IMember, Optional minDate As Date = #12:00:00 AM#, Optional maxDate As Date = #12:00:00 AM#) As HashSet(Of IMemberCharge) Implements IPaymentManager.listCharges

        End Function

        Public Function listPayments(memberID As Integer, Optional minDate As Date = #12:00:00 AM#, Optional maxDate As Date = #12:00:00 AM#) As HashSet(Of IMemberPayment) Implements IPaymentManager.listPayments

        End Function

        Public Function listPayments(member As IMember, Optional minDate As Date = #12:00:00 AM#, Optional maxDate As Date = #12:00:00 AM#) As HashSet(Of IMemberPayment) Implements IPaymentManager.listPayments

        End Function

        Public Function pay(invoice As IPaymentInvoice, amount As Decimal) As IMemberPayment Implements IPaymentManager.pay

        End Function

        Public Function removeCharge(charge As IMemberCharge) As Boolean Implements IPaymentManager.removeCharge

        End Function

        Public Function removePayment(payment As IMemberPayment) As Boolean Implements IPaymentManager.removePayment

        End Function
    End Class
End Namespace
