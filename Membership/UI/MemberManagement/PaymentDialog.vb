Public Class PaymentDialog
    Private member As IMember
    Private sum, gst As Decimal
    Private initialized As Boolean
    Private WithEvents timer As Timer = New Timer

    Public Sub New(member As IMember)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.member = member
    End Sub
    Private Sub onFormLoad() Handles Me.Load
        dgView.MultiSelect = True
        dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        WrappedChargeBindingSource.DataSource = config.dataManager.paymentManager.getUnpaidCharges(member).Select(WrappedCharge.wrap).ToList
        dgView.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgView.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        initialized = True
    End Sub


    Private Sub selectedChargeChanged() Handles dgView.SelectionChanged
        If Not initialized Then Exit Sub
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