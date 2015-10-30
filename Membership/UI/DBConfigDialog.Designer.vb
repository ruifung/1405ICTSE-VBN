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
        Me.DSSelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DSPath = New System.Windows.Forms.TextBox()
        Me.DSBtn = New System.Windows.Forms.Button()
        Me.DSAuth = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DSAuthPass = New Membership.TextBoxEx()
        Me.DSAuthName = New Membership.TextBoxEx()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DSSelector
        '
        Me.DSSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DSSelector.FormattingEnabled = True
        Me.DSSelector.Location = New System.Drawing.Point(118, 12)
        Me.DSSelector.Name = "DSSelector"
        Me.DSSelector.Size = New System.Drawing.Size(229, 21)
        Me.DSSelector.TabIndex = 0
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
        'DSPath
        '
        Me.DSPath.Location = New System.Drawing.Point(118, 40)
        Me.DSPath.Name = "DSPath"
        Me.DSPath.Size = New System.Drawing.Size(229, 20)
        Me.DSPath.TabIndex = 3
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
        'DSAuth
        '
        Me.DSAuth.AutoSize = True
        Me.DSAuth.Location = New System.Drawing.Point(86, 0)
        Me.DSAuth.Name = "DSAuth"
        Me.DSAuth.Size = New System.Drawing.Size(15, 14)
        Me.DSAuth.TabIndex = 6
        Me.DSAuth.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DSAuthPass)
        Me.GroupBox1.Controls.Add(Me.DSAuthName)
        Me.GroupBox1.Controls.Add(Me.DSAuth)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 74)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Authentication"
        '
        'DSAuthPass
        '
        Me.DSAuthPass.CustomBorder = False
        Me.DSAuthPass.CustomBorderColor = System.Drawing.Color.Red
        Me.DSAuthPass.Enabled = False
        Me.DSAuthPass.Location = New System.Drawing.Point(6, 46)
        Me.DSAuthPass.Name = "DSAuthPass"
        Me.DSAuthPass.Placeholder = "Password"
        Me.DSAuthPass.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.DSAuthPass.Size = New System.Drawing.Size(188, 20)
        Me.DSAuthPass.TabIndex = 8
        '
        'DSAuthName
        '
        Me.DSAuthName.CustomBorder = False
        Me.DSAuthName.CustomBorderColor = System.Drawing.Color.Red
        Me.DSAuthName.Enabled = False
        Me.DSAuthName.Location = New System.Drawing.Point(6, 20)
        Me.DSAuthName.Name = "DSAuthName"
        Me.DSAuthName.Placeholder = "Username"
        Me.DSAuthName.PlaceholderColor = System.Drawing.Color.DarkGray
        Me.DSAuthName.Size = New System.Drawing.Size(188, 20)
        Me.DSAuthName.TabIndex = 7
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
        Me.Controls.Add(Me.DSPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DSSelector)
        Me.Name = "DBConfigDialog"
        Me.Text = "Configure Data Source"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DSSelector As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DSPath As TextBox
    Friend WithEvents DSBtn As Button
    Friend WithEvents DSAuth As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DSAuthName As TextBoxEx
    Friend WithEvents DSAuthPass As TextBoxEx
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
