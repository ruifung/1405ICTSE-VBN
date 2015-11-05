Imports MDB
Imports System.Data.OleDb

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

        Public Function listCharges(memberID As Integer, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberCharge) Implements IPaymentManager.listCharges
            Dim criteria As String = "member=?"
            Dim params As List(Of OleDbParameter) = New List(Of OleDbParameter)
            params.Add(MDBType.Number.asParam(memberID))
            If Not IsNothing(minDate) Then
                criteria += " AND time>=?"
                params.Add(MDBType.DateTime.asParam(minDate))
            End If
            If Not IsNothing(maxDate) Then
                criteria += " AND time<=?"
                params.Add(MDBType.DateTime.asParam(maxDate))
            End If
            Return New HashSet(Of IMemberCharge)(DBList(Of Charge).Query(criteria, params.ToArray()))
        End Function

        Public Function listCharges(member As IMember, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberCharge) Implements IPaymentManager.listCharges
            Return listCharges(member.id, minDate, maxDate)
        End Function

        Public Function listPayments(memberID As Integer, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberPayment) Implements IPaymentManager.listPayments
            Dim criteria As String = "member=?"
            Dim params As List(Of OleDbParameter) = New List(Of OleDbParameter)
            params.Add(MDBType.Number.asParam(memberID))
            If Not IsNothing(minDate) Then
                criteria += " AND time>=?"
                params.Add(MDBType.DateTime.asParam(minDate))
            End If
            If Not IsNothing(maxDate) Then
                criteria += " AND time<=?"
                params.Add(MDBType.DateTime.asParam(maxDate))
            End If
            Return New HashSet(Of IMemberPayment)(DBList(Of Payment).Query(criteria, params.ToArray()))
        End Function

        Public Function listPayments(member As IMember, Optional minDate As Date = Nothing, Optional maxDate As Date = Nothing) As HashSet(Of IMemberPayment) Implements IPaymentManager.listPayments
            Return listPayments(member.id, minDate, maxDate)
        End Function

        Public Function pay(invoice As IPaymentInvoice, amount As Decimal) As IMemberPayment Implements IPaymentManager.pay
            Dim m As Member = Member.TryGet(invoice.memberID)
            If IsNothing(m) Then Throw (New ArgumentException("Member Not Found!"))
            Dim pm As Payment = New Payment
            pm.memberID = m.id
            ' ==========================================
            '  to RUIFUNG: Any Operation PLS do it here
            ' ==========================================
            pm.Insert()
            Return pm
        End Function

        Public Function removeCharge(charge As IMemberCharge) As Boolean Implements IPaymentManager.removeCharge
            Dim c As New Charge
            c("id") = charge.id
            c.Delete()
            Return True
        End Function

        Public Function removePayment(payment As IMemberPayment) As Boolean Implements IPaymentManager.removePayment
            If (payment.id = 0) Then Throw (New ArgumentException("Invalid Payment ID!"))
            Dim p As New Payment
            p("id") = payment.id
            p.Delete()
            Return True
        End Function
    End Class
End Namespace
