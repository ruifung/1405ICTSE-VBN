Public Class PaymentViewDialog
    Private payment As IMemberPayment

    Public Sub New(payment As IMemberPayment)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.payment = payment
    End Sub

    Private Sub onFromLoad() Handles Me.Load
        dgView.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgView.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Text = String.Format("Payment Result #{0}", payment.id)

        Dim displaylist = New List(Of DisplayAdditionalPayments)
        For Each x In payment.chargesPaid
            displaylist.Add(New DisplayAdditionalPayments With {
                .desc = x.description,
                .amt = x.amount.ToString("N2")
            })
        Next
        displaylist.Add(New DisplayAdditionalPayments)
        displaylist.Add(New DisplayAdditionalPayments With {
            .desc = "Subtotal",
            .amt = payment.chargesPaid.Sum(Function(x) x.amount).ToString("N2")
        })
        displaylist.Add(New DisplayAdditionalPayments)
        For Each x In payment.additionalCharges
            displaylist.Add(New DisplayAdditionalPayments With {
                .desc = x.Key,
                .amt = x.Value.ToString("N2")
            })
        Next
        displaylist.Add(New DisplayAdditionalPayments With {
            .desc = "Total",
            .amt = payment.totalPayable.ToString("N2")
        })
        displaylist.Add(New DisplayAdditionalPayments)
        displaylist.Add(New DisplayAdditionalPayments With {
            .desc = "Amount Paid",
            .amt = payment.amountPaid.ToString("N2")
        })
        displaylist.Add(New DisplayAdditionalPayments With {
            .desc = "Balance",
            .amt = payment.balance.ToString("N2")
        })
        DisplayAdditionalPaymentsBindingSource.DataSource = displaylist
    End Sub

    Public Class DisplayAdditionalPayments
        Property desc As String = String.Empty
        Property amt As String = String.Empty
    End Class

End Class