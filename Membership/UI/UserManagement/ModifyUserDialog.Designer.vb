<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModifyUserDialog
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.numAccess = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPassword = New Membership.TextBoxEx()
        Me.txtRePassword = New Membership.TextBoxEx()
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.numAccess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(113, 12)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(169, 20)
        Me.txtUsername.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Access level:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(168, 151)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = " New Password:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(75, 151)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'numAccess
        '
        Me.numAccess.Location = New System.Drawing.Point(113, 38)
        Me.numAccess.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.numAccess.Name = "numAccess"
        Me.numAccess.Size = New System.Drawing.Size(169, 20)
        Me.numAccess.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Confirm Password:"
        '
        'txtPassword
        '
        Me.txtPassword.CustomBorder = False
        Me.txtPassword.CustomBorderColor = System.Drawing.Color.Red
        Me.txtPassword.Location = New System.Drawing.Point(113, 64)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Placeholder = "Leave it empty if not changing"
        Me.txtPassword.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtPassword.Size = New System.Drawing.Size(169, 20)
        Me.txtPassword.TabIndex = 15
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtRePassword
        '
        Me.txtRePassword.CustomBorder = False
        Me.txtRePassword.CustomBorderColor = System.Drawing.Color.Red
        Me.txtRePassword.Location = New System.Drawing.Point(113, 90)
        Me.txtRePassword.Name = "txtRePassword"
        Me.txtRePassword.Placeholder = "Re-type Password"
        Me.txtRePassword.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtRePassword.Size = New System.Drawing.Size(169, 20)
        Me.txtRePassword.TabIndex = 16
        Me.txtRePassword.UseSystemPasswordChar = True
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'ModifyUserDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 186)
        Me.Controls.Add(Me.txtRePassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numAccess)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ModifyUserDialog"
        Me.Text = "ModifyUserDialog"
        CType(Me.numAccess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents numAccess As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassword As TextBoxEx
    Friend WithEvents txtRePassword As TextBoxEx
    Friend WithEvents ep As ErrorProvider
End Class
