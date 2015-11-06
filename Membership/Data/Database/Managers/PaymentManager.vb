Imports MDB
Imports System.Data.OleDb
Imports Membership.config

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

        Public Function invoice(member As IMember, charges As HashSet(Of IMemberCharge)) As IPaymentInvoice Implements IPaymentManager.invoice
            Dim inv = New PlainInvoice With {
                .additionalCharges = New Dictionary(Of String, Decimal),
                .chargesPaid = charges,
                .memberID = member.id
            }
            Dim subtotal As Decimal = 0
            For Each x In charges
                subtotal += x.amount
            Next

            inv.additionalCharges.Add("6% GST", subtotal * 0.06D)

            inv.totalPayable = subtotal
            For Each x In inv.additionalCharges.Values
                inv.totalPayable += x
            Next
            Return inv
        End Function

        Public Function listCharges(memberID As Integer, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberCharge) Implements IPaymentManager.listCharges
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

        Public Function listCharges(member As IMember, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberCharge) Implements IPaymentManager.listCharges
            Return listCharges(member.id, minDate, maxDate)
        End Function

        Public Function listPayments(memberID As Integer, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberPayment) Implements IPaymentManager.listPayments
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

        Public Function listPayments(member As IMember, Optional minDate As Date? = Nothing, Optional maxDate As Date? = Nothing) As HashSet(Of IMemberPayment) Implements IPaymentManager.listPayments
            Return listPayments(member.id, minDate, maxDate)
        End Function

        Public Function pay(invoice As IPaymentInvoice, amount As Decimal) As IMemberPayment Implements IPaymentManager.pay
            Dim m As Member = Member.TryGet(invoice.memberID)
            If IsNothing(m) Then Throw (New ArgumentException("Member Not Found!"))
            Dim pm As Payment = New Payment With {
                .additionalCharges = invoice.additionalCharges,
                .chargesPaid = invoice.chargesPaid,
                .memberID = invoice.memberID,
                .totalPayable = invoice.totalPayable,
                .amountPaid = amount,
                .userID = currentUser.id
            }
            pm.memberID = m.id

            Dim effectivePayable = invoice.totalPayable
            Dim creditApplied As Decimal
            If m.paymentCredit >= invoice.totalPayable Then
                creditApplied = invoice.totalPayable * -1
            Else
                creditApplied = m.paymentCredit * -1
            End If
            effectivePayable += creditApplied

            Dim credit = amount - effectivePayable
            m.paymentCredit += (credit + creditApplied)

            pm.balance = effectivePayable - amount
            If pm.balance > 0 Then
                addCharge(m, m.paymentTermDue.AddDays(1), "Carried Forward Charges", pm.balance)
            End If

            For Each c In invoice.chargesPaid
                c.paid = True
                updateCharge(c)
            Next
            dataManager.userManager.updateEntry(DirectCast(m, IUser))
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

        Public Function updateCharge(charge As IMemberCharge) As Boolean Implements IPaymentManager.updateCharge
            Dim ch = TryCast(charge, Charge)
            If ch Is Nothing Then
                ch = DBObject.Find(Of Charge)(charge.id)
                If ch IsNot Nothing Then
                    With ch
                        .amount = charge.amount
                        .description = charge.description
                        .memberID = charge.memberID
                        .paid = charge.paid
                        .timestamp = charge.timestamp
                    End With
                Else
                    Return False
                End If
            End If
            Util.exec(ch, Sub(x) x.Update())
            Return True
        End Function

        Public Function updatePayment(payment As IMemberPayment) As Boolean Implements IPaymentManager.updatePayment
            Dim pay = TryCast(payment, Payment)
            If pay Is Nothing Then
                pay = DBObject.Find(Of Payment)(payment.id)
                If pay IsNot Nothing Then
                    With pay
                        .memberID = payment.memberID
                        .totalPayable = payment.totalPayable
                        .additionalCharges = payment.additionalCharges
                        .amountPaid = payment.amountPaid
                        .balance = payment.balance
                        .chargesPaid = payment.chargesPaid
                    End With
                Else
                    Return False
                End If
            End If
            Util.exec(pay, Sub(x) x.Update())
            Return True
        End Function
    End Class
End Namespace
