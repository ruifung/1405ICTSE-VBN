<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemberDetails
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pbPhoto = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbMembershipType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtDOB = New System.Windows.Forms.DateTimePicker()
        Me.txtAddress = New Membership.TextBoxEx()
        Me.txtEmail = New Membership.TextBoxEx()
        Me.txtContact = New Membership.TextBoxEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtID = New Membership.TextBoxEx()
        Me.txtLName = New Membership.TextBoxEx()
        Me.txtFName = New Membership.TextBoxEx()
        Me.cbGender = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbPhoto
        '
        Me.pbPhoto.Location = New System.Drawing.Point(3, 3)
        Me.pbPhoto.Name = "pbPhoto"
        Me.pbPhoto.Size = New System.Drawing.Size(170, 218)
        Me.pbPhoto.TabIndex = 104
        Me.pbPhoto.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbMembershipType)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 76)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Membership Status"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(59, 46)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(109, 21)
        Me.cbStatus.TabIndex = 137
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "Status :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbMembershipType
        '
        Me.cbMembershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMembershipType.FormattingEnabled = True
        Me.cbMembershipType.Location = New System.Drawing.Point(59, 19)
        Me.cbMembershipType.Name = "cbMembershipType"
        Me.cbMembershipType.Size = New System.Drawing.Size(109, 21)
        Me.cbMembershipType.TabIndex = 135
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 134
        Me.Label9.Text = " Type:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtDOB)
        Me.GroupBox2.Controls.Add(Me.txtAddress)
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.txtContact)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.txtLName)
        Me.GroupBox2.Controls.Add(Me.txtFName)
        Me.GroupBox2.Controls.Add(Me.cbGender)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(179, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 297)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Member Information"
        '
        'dtDOB
        '
        Me.dtDOB.Location = New System.Drawing.Point(97, 224)
        Me.dtDOB.Name = "dtDOB"
        Me.dtDOB.Size = New System.Drawing.Size(160, 20)
        Me.dtDOB.TabIndex = 146
        '
        'txtAddress
        '
        Me.txtAddress.CustomBorder = False
        Me.txtAddress.CustomBorderColor = System.Drawing.Color.Red
        Me.txtAddress.Location = New System.Drawing.Point(97, 159)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Placeholder = "Address"
        Me.txtAddress.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtAddress.Size = New System.Drawing.Size(160, 59)
        Me.txtAddress.TabIndex = 145
        '
        'txtEmail
        '
        Me.txtEmail.CustomBorder = False
        Me.txtEmail.CustomBorderColor = System.Drawing.Color.Red
        Me.txtEmail.Location = New System.Drawing.Point(97, 130)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Placeholder = "example@example.com"
        Me.txtEmail.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtEmail.Size = New System.Drawing.Size(160, 20)
        Me.txtEmail.TabIndex = 144
        '
        'txtContact
        '
        Me.txtContact.CustomBorder = False
        Me.txtContact.CustomBorderColor = System.Drawing.Color.Red
        Me.txtContact.Location = New System.Drawing.Point(97, 103)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Placeholder = "Contact #"
        Me.txtContact.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtContact.Size = New System.Drawing.Size(163, 20)
        Me.txtContact.TabIndex = 143
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "E-Mail Address :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.CustomBorder = False
        Me.txtID.CustomBorderColor = System.Drawing.Color.Red
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(97, 25)
        Me.txtID.Name = "txtID"
        Me.txtID.Placeholder = "Member #"
        Me.txtID.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtID.Size = New System.Drawing.Size(160, 20)
        Me.txtID.TabIndex = 141
        '
        'txtLName
        '
        Me.txtLName.CustomBorder = False
        Me.txtLName.CustomBorderColor = System.Drawing.Color.Red
        Me.txtLName.Location = New System.Drawing.Point(97, 77)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Placeholder = "Last Name"
        Me.txtLName.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtLName.Size = New System.Drawing.Size(160, 20)
        Me.txtLName.TabIndex = 140
        '
        'txtFName
        '
        Me.txtFName.CustomBorder = False
        Me.txtFName.CustomBorderColor = System.Drawing.Color.Red
        Me.txtFName.Location = New System.Drawing.Point(97, 51)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Placeholder = "First Name"
        Me.txtFName.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtFName.Size = New System.Drawing.Size(160, 20)
        Me.txtFName.TabIndex = 139
        '
        'cbGender
        '
        Me.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGender.FormattingEnabled = True
        Me.cbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cbGender.Location = New System.Drawing.Point(97, 250)
        Me.cbGender.Name = "cbGender"
        Me.cbGender.Size = New System.Drawing.Size(160, 21)
        Me.cbGender.TabIndex = 138
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Address :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Contact Nmber :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 253)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Gender :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Date of Birth :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Member Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Member ID :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MemberDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbPhoto)
        Me.Name = "MemberDetails"
        Me.Size = New System.Drawing.Size(442, 303)
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbPhoto As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbMembershipType As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtDOB As DateTimePicker
    Friend WithEvents txtAddress As TextBoxEx
    Friend WithEvents txtEmail As TextBoxEx
    Friend WithEvents txtContact As TextBoxEx
    Friend WithEvents Label8 As Label
    Friend WithEvents txtID As TextBoxEx
    Friend WithEvents txtLName As TextBoxEx
    Friend WithEvents txtFName As TextBoxEx
    Friend WithEvents cbGender As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
