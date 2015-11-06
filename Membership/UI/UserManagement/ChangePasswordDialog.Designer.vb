<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePasswordDialog
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
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtNewP = New Membership.TextBoxEx()
        Me.txtConfirmP = New Membership.TextBoxEx()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtOldP = New Membership.TextBoxEx()
        Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Changing Password For User:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(166, 9)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(39, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Label2"
        '
        'txtNewP
        '
        Me.txtNewP.CustomBorder = False
        Me.txtNewP.CustomBorderColor = System.Drawing.Color.Red
        Me.txtNewP.Location = New System.Drawing.Point(12, 57)
        Me.txtNewP.Name = "txtNewP"
        Me.txtNewP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewP.Placeholder = "New Password"
        Me.txtNewP.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtNewP.Size = New System.Drawing.Size(256, 20)
        Me.txtNewP.TabIndex = 2
        '
        'txtConfirmP
        '
        Me.txtConfirmP.CustomBorder = False
        Me.txtConfirmP.CustomBorderColor = System.Drawing.Color.Red
        Me.txtConfirmP.Location = New System.Drawing.Point(12, 83)
        Me.txtConfirmP.Name = "txtConfirmP"
        Me.txtConfirmP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmP.Placeholder = "Confirm Password"
        Me.txtConfirmP.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtConfirmP.Size = New System.Drawing.Size(256, 20)
        Me.txtConfirmP.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(53, 115)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(147, 115)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtOldP
        '
        Me.txtOldP.CustomBorder = False
        Me.txtOldP.CustomBorderColor = System.Drawing.Color.Red
        Me.txtOldP.Location = New System.Drawing.Point(12, 30)
        Me.txtOldP.Name = "txtOldP"
        Me.txtOldP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldP.Placeholder = "Old Password"
        Me.txtOldP.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtOldP.Size = New System.Drawing.Size(256, 20)
        Me.txtOldP.TabIndex = 6
        '
        'errorProvider
        '
        Me.errorProvider.ContainerControl = Me
        '
        'ChangePasswordDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 151)
        Me.Controls.Add(Me.txtOldP)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtConfirmP)
        Me.Controls.Add(Me.txtNewP)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ChangePasswordDialog"
        Me.Text = "ChangePasswordDialog"
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtNewP As TextBoxEx
    Friend WithEvents txtConfirmP As TextBoxEx
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtOldP As TextBoxEx
    Friend WithEvents errorProvider As ErrorProvider
End Class
