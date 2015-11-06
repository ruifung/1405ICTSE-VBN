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
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnAddPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddCharge = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRemoveCharges = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewCharges = New System.Windows.Forms.ToolStripButton()
        Me.btnViewHistory = New System.Windows.Forms.ToolStripButton()
        Me.txtMemberCredit = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgView = New System.Windows.Forms.DataGridView()
        Me.btnRemovePayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.btnViewCharges, Me.btnViewHistory, Me.txtMemberCredit, Me.ToolStripLabel1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(506, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddPayment, Me.btnAddCharge, Me.btnRemoveCharges, Me.btnRemovePayment})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripDropDownButton1.Text = "Operations"
        '
        'btnAddPayment
        '
        Me.btnAddPayment.Name = "btnAddPayment"
        Me.btnAddPayment.Size = New System.Drawing.Size(180, 22)
        Me.btnAddPayment.Text = "Add Payment"
        '
        'btnAddCharge
        '
        Me.btnAddCharge.Name = "btnAddCharge"
        Me.btnAddCharge.Size = New System.Drawing.Size(180, 22)
        Me.btnAddCharge.Text = "Add Charge"
        '
        'btnRemoveCharges
        '
        Me.btnRemoveCharges.Name = "btnRemoveCharges"
        Me.btnRemoveCharges.Size = New System.Drawing.Size(180, 22)
        Me.btnRemoveCharges.Text = "Remove Charge(s)"
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
        Me.dgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgView.Location = New System.Drawing.Point(0, 25)
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.Size = New System.Drawing.Size(506, 368)
        Me.dgView.TabIndex = 1
        '
        'btnRemovePayment
        '
        Me.btnRemovePayment.Name = "btnRemovePayment"
        Me.btnRemovePayment.Size = New System.Drawing.Size(180, 22)
        Me.btnRemovePayment.Text = "Remove Payment(s)"
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
    Friend WithEvents btnViewCharges As ToolStripButton
    Friend WithEvents btnViewHistory As ToolStripButton
    Friend WithEvents dgView As DataGridView
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents txtMemberCredit As ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents btnAddPayment As ToolStripMenuItem
    Friend WithEvents btnAddCharge As ToolStripMenuItem
    Friend WithEvents btnRemoveCharges As ToolStripMenuItem
    Friend WithEvents btnRemovePayment As ToolStripMenuItem
End Class
