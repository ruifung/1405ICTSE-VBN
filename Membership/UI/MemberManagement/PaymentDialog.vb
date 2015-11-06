Public Class PaymentDialog
    Private member As IMember
    Private sum, gst As Decimal
    Public Sub New(member As IMember)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.member = member
        dgView.MultiSelect = True
        dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Private Sub onFormLoad() Handles Me.Load
        WrappedChargeBindingSource.DataSource =
            config.dataManager.paymentManager.
            getUnpaidCharges(member).Select(WrappedCharge.wrap).ToList
        selectedChargeChanged()
    End Sub
    Private Sub selectedChargeChanged() Handles dgView.SelectionChanged
        sum = 0D
        For Each x As DataGridViewRow In dgView.SelectedRows
            sum += DirectCast(x.DataBoundItem, IMemberCharge).amount
        Next
        gst = sum * 0.06D
        lblGST.Text = gst.ToString("N2")
        lblSubtotal.Text = sum.ToString("N2")
        lblTotal.Text = (sum + gst).ToString("N2")
    End Sub
End Class