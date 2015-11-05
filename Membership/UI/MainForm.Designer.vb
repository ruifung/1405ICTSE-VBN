<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDataSource = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.btnLogout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnAddMember = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRemoveMembers = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnManageUsers = New System.Windows.Forms.ToolStripButton()
        Me.btnChangePass = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New Membership.TextBoxEx()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.rbSearchName = New System.Windows.Forms.RadioButton()
        Me.rbSearchEmail = New System.Windows.Forms.RadioButton()
        Me.rbSearchContact = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbTypes = New System.Windows.Forms.ListBox()
        Me.rbInactive = New System.Windows.Forms.RadioButton()
        Me.rbActive = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgMemberView = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgMemberView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblDataSource, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 405)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(828, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripStatusLabel1.Text = "Data Source:"
        '
        'lblDataSource
        '
        Me.lblDataSource.Name = "lblDataSource"
        Me.lblDataSource.Size = New System.Drawing.Size(153, 17)
        Me.lblDataSource.Text = "TESTDATA\SOURCE.ACCDB"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(587, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "1405ICTSE-VBN Group Assignment, Authors: Lim Eng Shun, Yip Rui Fung, Balram "
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExit, Me.btnLogout, Me.ToolStripDropDownButton1, Me.btnManageUsers, Me.btnChangePass})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(828, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnExit
        '
        Me.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(29, 22)
        Me.btnExit.Text = "Exit"
        '
        'btnLogout
        '
        Me.btnLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(49, 22)
        Me.btnLogout.Text = "Logout"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddMember, Me.btnRemoveMembers})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripDropDownButton1.Text = "Member Operations"
        '
        'btnAddMember
        '
        Me.btnAddMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAddMember.Name = "btnAddMember"
        Me.btnAddMember.Size = New System.Drawing.Size(178, 22)
        Me.btnAddMember.Text = "Add Member"
        '
        'btnRemoveMembers
        '
        Me.btnRemoveMembers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnRemoveMembers.Name = "btnRemoveMembers"
        Me.btnRemoveMembers.Size = New System.Drawing.Size(178, 22)
        Me.btnRemoveMembers.Text = "Remove Member(s)"
        '
        'btnManageUsers
        '
        Me.btnManageUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnManageUsers.Image = CType(resources.GetObject("btnManageUsers.Image"), System.Drawing.Image)
        Me.btnManageUsers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnManageUsers.Name = "btnManageUsers"
        Me.btnManageUsers.Size = New System.Drawing.Size(108, 22)
        Me.btnManageUsers.Text = "User Management"
        '
        'btnChangePass
        '
        Me.btnChangePass.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnChangePass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnChangePass.Image = CType(resources.GetObject("btnChangePass.Image"), System.Drawing.Image)
        Me.btnChangePass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChangePass.Name = "btnChangePass"
        Me.btnChangePass.Size = New System.Drawing.Size(105, 22)
        Me.btnChangePass.Text = "Change Password"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgMemberView)
        Me.SplitContainer1.Size = New System.Drawing.Size(828, 380)
        Me.SplitContainer1.SplitterDistance = 191
        Me.SplitContainer1.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.rbSearchName)
        Me.GroupBox2.Controls.Add(Me.rbSearchEmail)
        Me.GroupBox2.Controls.Add(Me.rbSearchContact)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(174, 98)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.CustomBorder = False
        Me.txtSearch.CustomBorderColor = System.Drawing.Color.Red
        Me.txtSearch.Location = New System.Drawing.Point(7, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Placeholder = "Search"
        Me.txtSearch.PlaceholderColor = System.Drawing.Color.Silver
        Me.txtSearch.Size = New System.Drawing.Size(161, 20)
        Me.txtSearch.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(108, 65)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'rbSearchName
        '
        Me.rbSearchName.AutoSize = True
        Me.rbSearchName.Checked = True
        Me.rbSearchName.Location = New System.Drawing.Point(7, 45)
        Me.rbSearchName.Name = "rbSearchName"
        Me.rbSearchName.Size = New System.Drawing.Size(53, 17)
        Me.rbSearchName.TabIndex = 2
        Me.rbSearchName.TabStop = True
        Me.rbSearchName.Text = "Name"
        Me.rbSearchName.UseVisualStyleBackColor = True
        '
        'rbSearchEmail
        '
        Me.rbSearchEmail.AutoSize = True
        Me.rbSearchEmail.Location = New System.Drawing.Point(7, 68)
        Me.rbSearchEmail.Name = "rbSearchEmail"
        Me.rbSearchEmail.Size = New System.Drawing.Size(95, 17)
        Me.rbSearchEmail.TabIndex = 4
        Me.rbSearchEmail.TabStop = True
        Me.rbSearchEmail.Text = "E-Mail Address"
        Me.rbSearchEmail.UseVisualStyleBackColor = True
        '
        'rbSearchContact
        '
        Me.rbSearchContact.AutoSize = True
        Me.rbSearchContact.Location = New System.Drawing.Point(66, 45)
        Me.rbSearchContact.Name = "rbSearchContact"
        Me.rbSearchContact.Size = New System.Drawing.Size(102, 17)
        Me.rbSearchContact.TabIndex = 3
        Me.rbSearchContact.TabStop = True
        Me.rbSearchContact.Text = "Contact Number"
        Me.rbSearchContact.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Image = Global.Membership.My.Resources.Resources.logo_imperial_golf_club
        Me.PictureBox1.Location = New System.Drawing.Point(0, 262)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(191, 118)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbTypes)
        Me.GroupBox1.Controls.Add(Me.rbInactive)
        Me.GroupBox1.Controls.Add(Me.rbActive)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 149)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters"
        '
        'lbTypes
        '
        Me.lbTypes.FormattingEnabled = True
        Me.lbTypes.Location = New System.Drawing.Point(7, 36)
        Me.lbTypes.Name = "lbTypes"
        Me.lbTypes.Size = New System.Drawing.Size(158, 69)
        Me.lbTypes.TabIndex = 5
        '
        'rbInactive
        '
        Me.rbInactive.AutoSize = True
        Me.rbInactive.Location = New System.Drawing.Point(68, 125)
        Me.rbInactive.Name = "rbInactive"
        Me.rbInactive.Size = New System.Drawing.Size(63, 17)
        Me.rbInactive.TabIndex = 4
        Me.rbInactive.Text = "Inactive"
        Me.rbInactive.UseVisualStyleBackColor = True
        '
        'rbActive
        '
        Me.rbActive.AutoSize = True
        Me.rbActive.Checked = True
        Me.rbActive.Location = New System.Drawing.Point(7, 125)
        Me.rbActive.Name = "rbActive"
        Me.rbActive.Size = New System.Drawing.Size(55, 17)
        Me.rbActive.TabIndex = 3
        Me.rbActive.TabStop = True
        Me.rbActive.Text = "Active"
        Me.rbActive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Membership Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Membership Types"
        '
        'dgMemberView
        '
        Me.dgMemberView.AllowUserToAddRows = False
        Me.dgMemberView.AllowUserToDeleteRows = False
        Me.dgMemberView.BackgroundColor = System.Drawing.Color.White
        Me.dgMemberView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMemberView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMemberView.Location = New System.Drawing.Point(0, 0)
        Me.dgMemberView.Name = "dgMemberView"
        Me.dgMemberView.ReadOnly = True
        Me.dgMemberView.Size = New System.Drawing.Size(633, 380)
        Me.dgMemberView.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 427)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MinimumSize = New System.Drawing.Size(844, 466)
        Me.Name = "MainForm"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgMemberView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblDataSource As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtSearch As TextBoxEx
    Friend WithEvents btnSearch As Button
    Friend WithEvents rbSearchName As RadioButton
    Friend WithEvents rbSearchEmail As RadioButton
    Friend WithEvents rbSearchContact As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbTypes As ListBox
    Friend WithEvents rbInactive As RadioButton
    Friend WithEvents rbActive As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgMemberView As DataGridView
    Friend WithEvents btnExit As ToolStripButton
    Friend WithEvents btnLogout As ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents btnAddMember As ToolStripMenuItem
    Friend WithEvents btnRemoveMembers As ToolStripMenuItem
    Friend WithEvents btnManageUsers As ToolStripButton
    Friend WithEvents btnChangePass As ToolStripButton
End Class
