<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PaymentViewDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgView = New System.Windows.Forms.DataGridView()
        Me.DescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisplayAdditionalPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisplayAdditionalPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        Me.dgView.AllowUserToDeleteRows = False
        Me.dgView.AutoGenerateColumns = False
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DescDataGridViewTextBoxColumn, Me.AmtDataGridViewTextBoxColumn})
        Me.dgView.DataSource = Me.DisplayAdditionalPaymentsBindingSource
        Me.dgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgView.Location = New System.Drawing.Point(0, 0)
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.Size = New System.Drawing.Size(422, 219)
        Me.dgView.TabIndex = 0
        '
        'DescDataGridViewTextBoxColumn
        '
        Me.DescDataGridViewTextBoxColumn.DataPropertyName = "desc"
        Me.DescDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescDataGridViewTextBoxColumn.Name = "DescDataGridViewTextBoxColumn"
        Me.DescDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AmtDataGridViewTextBoxColumn
        '
        Me.AmtDataGridViewTextBoxColumn.DataPropertyName = "amt"
        Me.AmtDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmtDataGridViewTextBoxColumn.Name = "AmtDataGridViewTextBoxColumn"
        Me.AmtDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DisplayAdditionalPaymentsBindingSource
        '
        Me.DisplayAdditionalPaymentsBindingSource.DataSource = GetType(Membership.PaymentViewDialog.DisplayAdditionalPayments)
        '
        'PaymentViewDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 219)
        Me.Controls.Add(Me.dgView)
        Me.Name = "PaymentViewDialog"
        Me.Text = "PaymentViewDialog"
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisplayAdditionalPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgView As DataGridView
    Friend WithEvents DisplayAdditionalPaymentsBindingSource As BindingSource
    Friend WithEvents DescDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AmtDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
