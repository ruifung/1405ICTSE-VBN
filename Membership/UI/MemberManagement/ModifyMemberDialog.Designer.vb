<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModifyMemberDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModifyMemberDialog))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnPhoto = New System.Windows.Forms.ToolStripButton()
        Me.btnPhotoClear = New System.Windows.Forms.ToolStripButton()
        Me.seperatorEdit = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBilling = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.MemberDetails1 = New Membership.MemberDetails()
        Me.memberDetailsView = New Membership.MemberDetails()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPhoto, Me.btnPhotoClear, Me.seperatorEdit, Me.btnCancel, Me.btnSave, Me.btnClose, Me.ToolStripSeparator1, Me.btnBilling, Me.btnEdit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(469, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnPhoto
        '
        Me.btnPhoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPhoto.Image = CType(resources.GetObject("btnPhoto.Image"), System.Drawing.Image)
        Me.btnPhoto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPhoto.Name = "btnPhoto"
        Me.btnPhoto.Size = New System.Drawing.Size(62, 22)
        Me.btnPhoto.Text = "Set Photo"
        Me.btnPhoto.Visible = False
        '
        'btnPhotoClear
        '
        Me.btnPhotoClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPhotoClear.Image = CType(resources.GetObject("btnPhotoClear.Image"), System.Drawing.Image)
        Me.btnPhotoClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPhotoClear.Name = "btnPhotoClear"
        Me.btnPhotoClear.Size = New System.Drawing.Size(73, 22)
        Me.btnPhotoClear.Text = "Clear Photo"
        '
        'seperatorEdit
        '
        Me.seperatorEdit.Name = "seperatorEdit"
        Me.seperatorEdit.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel
        '
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(47, 22)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Visible = False
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(35, 22)
        Me.btnSave.Text = "Save"
        Me.btnSave.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 22)
        Me.btnClose.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnBilling
        '
        Me.btnBilling.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnBilling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnBilling.Image = CType(resources.GetObject("btnBilling.Image"), System.Drawing.Image)
        Me.btnBilling.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBilling.Name = "btnBilling"
        Me.btnBilling.Size = New System.Drawing.Size(76, 22)
        Me.btnBilling.Text = "Open Billing"
        '
        'btnEdit
        '
        Me.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(95, 22)
        Me.btnEdit.Text = "Enter Edit Mode"
        '
        'MemberDetails1
        '
        Me.MemberDetails1.BoundMember = Nothing
        Me.MemberDetails1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemberDetails1.Location = New System.Drawing.Point(0, 25)
        Me.MemberDetails1.Name = "MemberDetails1"
        Me.MemberDetails1.Size = New System.Drawing.Size(500, 313)
        Me.MemberDetails1.TabIndex = 3
        '
        'memberDetailsView
        '
        Me.memberDetailsView.BoundMember = Nothing
        Me.memberDetailsView.Location = New System.Drawing.Point(0, 23)
        Me.memberDetailsView.Name = "memberDetailsView"
        Me.memberDetailsView.Size = New System.Drawing.Size(470, 313)
        Me.memberDetailsView.TabIndex = 3
        '
        'ModifyMemberDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(469, 336)
        Me.Controls.Add(Me.memberDetailsView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(485, 375)
        Me.MinimumSize = New System.Drawing.Size(485, 375)
        Me.Name = "ModifyMemberDialog"
        Me.Text = "Member Profile"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnBilling As ToolStripButton
    Friend WithEvents btnClose As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnPhoto As ToolStripButton
    Friend WithEvents btnPhotoClear As ToolStripButton
    Friend WithEvents seperatorEdit As ToolStripSeparator
    Friend WithEvents MemberDetails1 As MemberDetails
    Friend WithEvents memberDetailsView As MemberDetails
End Class
