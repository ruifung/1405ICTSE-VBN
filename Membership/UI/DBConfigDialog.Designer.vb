<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBConfigDialog
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
        Me.cbDSSelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDSPath = New System.Windows.Forms.TextBox()
        Me.DSBtn = New System.Windows.Forms.Button()
        Me.chkDSAuth = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDSAuthPass = New Membership.TextBoxEx()
        Me.txtDSAuthName = New Membership.TextBoxEx()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbDSSelector
        '
        Me.cbDSSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDSSelector.FormattingEnabled = True
        Me.cbDSSelector.Location = New System.Drawing.Point(118, 12)
        Me.cbDSSelector.Name = "cbDSSelector"
        Me.cbDSSelector.Size = New System.Drawing.Size(229, 21)
        Me.cbDSSelector.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data Source Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Data Source"
        '
        'txtDSPath
        '
        Me.txtDSPath.Location = New System.Drawing.Point(118, 40)
        Me.txtDSPath.Name = "txtDSPath"
        Me.txtDSPath.Size = New System.Drawing.Size(229, 20)
        Me.txtDSPath.TabIndex = 3
        '
        'DSBtn
        '
        Me.DSBtn.Location = New System.Drawing.Point(353, 38)
        Me.DSBtn.Name = "DSBtn"
        Me.DSBtn.Size = New System.Drawing.Size(60, 23)
        Me.DSBtn.TabIndex = 4
        Me.DSBtn.Text = "Browse"
        Me.DSBtn.UseVisualStyleBackColor = True
        '
        'chkDSAuth
        '
        Me.chkDSAuth.AutoSize = True
        Me.chkDSAuth.Location = New System.Drawing.Point(86, 0)
        Me.chkDSAuth.Name = "chkDSAuth"
        Me.chkDSAuth.Size = New System.Drawing.Size(15, 14)
        Me.chkDSAuth.TabIndex = 6
        Me.chkDSAuth.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDSAuthPass)
        Me.GroupBox1.Controls.Add(Me.txtDSAuthName)
        Me.GroupBox1.Controls.Add(Me.chkDSAuth)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 74)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Authentication"
        '
        'txtDSAuthPass
        '
        Me.txtDSAuthPass.CustomBorder = False
        Me.txtDSAuthPass.CustomBorderColor = System.Drawing.Color.Red
        Me.txtDSAuthPass.Enabled = False
        Me.txtDSAuthPass.Location = New System.Drawing.Point(6, 46)
        Me.txtDSAuthPass.Name = "txtDSAuthPass"
        Me.txtDSAuthPass.Placeholder = "Password"
        Me.txtDSAuthPass.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtDSAuthPass.Size = New System.Drawing.Size(188, 20)
        Me.txtDSAuthPass.TabIndex = 8
        '
        'txtDSAuthName
        '
        Me.txtDSAuthName.CustomBorder = False
        Me.txtDSAuthName.CustomBorderColor = System.Drawing.Color.Red
        Me.txtDSAuthName.Enabled = False
        Me.txtDSAuthName.Location = New System.Drawing.Point(6, 20)
        Me.txtDSAuthName.Name = "txtDSAuthName"
        Me.txtDSAuthName.Placeholder = "Username"
        Me.txtDSAuthName.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.txtDSAuthName.Size = New System.Drawing.Size(188, 20)
        Me.txtDSAuthName.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(340, 130)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(259, 130)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DBConfigDialog
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(427, 164)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DSBtn)
        Me.Controls.Add(Me.txtDSPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDSSelector)
        Me.Name = "DBConfigDialog"
        Me.Text = "Configure Data Source"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbDSSelector As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDSPath As TextBox
    Friend WithEvents DSBtn As Button
    Friend WithEvents chkDSAuth As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDSAuthName As TextBoxEx
    Friend WithEvents txtDSAuthPass As TextBoxEx
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
