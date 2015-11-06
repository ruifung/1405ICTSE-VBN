<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddChargeDialog
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
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numAmount = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.dtTimestamp = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.errors = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(32, 108)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(222, 112)
        Me.txtDesc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Description"
        '
        'numAmount
        '
        Me.numAmount.DecimalPlaces = 2
        Me.numAmount.Location = New System.Drawing.Point(32, 243)
        Me.numAmount.Name = "numAmount"
        Me.numAmount.Size = New System.Drawing.Size(222, 20)
        Me.numAmount.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Amount"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(45, 274)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(156, 274)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Add Charge"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Member to Charge:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(115, 9)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(39, 13)
        Me.lblUsername.TabIndex = 8
        Me.lblUsername.Text = "Label4"
        '
        'dtTimestamp
        '
        Me.dtTimestamp.Location = New System.Drawing.Point(32, 55)
        Me.dtTimestamp.Name = "dtTimestamp"
        Me.dtTimestamp.Size = New System.Drawing.Size(222, 20)
        Me.dtTimestamp.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Charge On"
        '
        'errors
        '
        Me.errors.ContainerControl = Me
        '
        'AddChargeDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 312)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtTimestamp)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDesc)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(298, 351)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(298, 351)
        Me.Name = "AddChargeDialog"
        Me.Text = "AddChargeDialog"
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents numAmount As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents dtTimestamp As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents errors As ErrorProvider
End Class
