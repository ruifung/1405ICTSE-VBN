<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemberBilling
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemberBilling))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAddPayment = New System.Windows.Forms.ToolStripButton()
        Me.btnViewCharges = New System.Windows.Forms.ToolStripButton()
        Me.btnViewHistory = New System.Windows.Forms.ToolStripButton()
        Me.txtMemberCredit = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgView = New System.Windows.Forms.DataGridView()
        Me.checked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Charges = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Payable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddPayment, Me.btnViewCharges, Me.btnViewHistory, Me.txtMemberCredit, Me.ToolStripLabel1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(506, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddPayment
        '
        Me.btnAddPayment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAddPayment.Image = CType(resources.GetObject("btnAddPayment.Image"), System.Drawing.Image)
        Me.btnAddPayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddPayment.Name = "btnAddPayment"
        Me.btnAddPayment.Size = New System.Drawing.Size(83, 22)
        Me.btnAddPayment.Text = "Add Payment"
        '
        'btnViewCharges
        '
        Me.btnViewCharges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnViewCharges.Image = CType(resources.GetObject("btnViewCharges.Image"), System.Drawing.Image)
        Me.btnViewCharges.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewCharges.Name = "btnViewCharges"
        Me.btnViewCharges.Size = New System.Drawing.Size(82, 22)
        Me.btnViewCharges.Text = "View Charges"
        '
        'btnViewHistory
        '
        Me.btnViewHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnViewHistory.Image = CType(resources.GetObject("btnViewHistory.Image"), System.Drawing.Image)
        Me.btnViewHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewHistory.Name = "btnViewHistory"
        Me.btnViewHistory.Size = New System.Drawing.Size(127, 22)
        Me.btnViewHistory.Text = "View Payment History"
        '
        'txtMemberCredit
        '
        Me.txtMemberCredit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtMemberCredit.Enabled = False
        Me.txtMemberCredit.Name = "txtMemberCredit"
        Me.txtMemberCredit.Size = New System.Drawing.Size(100, 25)
        Me.txtMemberCredit.Text = "0000"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripLabel1.Text = "Member Credit:"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        Me.dgView.AllowUserToDeleteRows = False
        Me.dgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.checked, Me.ID, Me.Charges, Me.Remarks, Me.Payable, Me.Paid, Me.Balance})
        Me.dgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgView.Location = New System.Drawing.Point(0, 25)
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.Size = New System.Drawing.Size(506, 368)
        Me.dgView.TabIndex = 1
        '
        'checked
        '
        Me.checked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.checked.FillWeight = 17.7665!
        Me.checked.HeaderText = ""
        Me.checked.Name = "checked"
        Me.checked.ReadOnly = True
        Me.checked.Width = 5
        '
        'ID
        '
        Me.ID.FillWeight = 113.7056!
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Charges
        '
        Me.Charges.FillWeight = 113.7056!
        Me.Charges.HeaderText = "Charges"
        Me.Charges.Name = "Charges"
        Me.Charges.ReadOnly = True
        '
        'Remarks
        '
        Me.Remarks.FillWeight = 113.7056!
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        '
        'Payable
        '
        Me.Payable.FillWeight = 113.7056!
        Me.Payable.HeaderText = "Total Payable"
        Me.Payable.Name = "Payable"
        Me.Payable.ReadOnly = True
        '
        'Paid
        '
        Me.Paid.FillWeight = 113.7056!
        Me.Paid.HeaderText = "Total Paid"
        Me.Paid.Name = "Paid"
        Me.Paid.ReadOnly = True
        '
        'Balance
        '
        Me.Balance.FillWeight = 113.7056!
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        '
        'MemberBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 393)
        Me.Controls.Add(Me.dgView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MinimumSize = New System.Drawing.Size(522, 256)
        Me.Name = "MemberBilling"
        Me.Text = "MemberBilling"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnAddPayment As ToolStripButton
    Friend WithEvents btnViewCharges As ToolStripButton
    Friend WithEvents btnViewHistory As ToolStripButton
    Friend WithEvents dgView As DataGridView
    Friend WithEvents checked As DataGridViewCheckBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Charges As DataGridViewComboBoxColumn
    Friend WithEvents Remarks As DataGridViewTextBoxColumn
    Friend WithEvents Payable As DataGridViewTextBoxColumn
    Friend WithEvents Paid As DataGridViewTextBoxColumn
    Friend WithEvents Balance As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents txtMemberCredit As ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
End Class
