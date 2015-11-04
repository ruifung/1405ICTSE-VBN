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
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.memberDetailsView = New Membership.MemberDetails()
        Me.btnBilling = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEdit, Me.btnCancel, Me.btnSave, Me.btnBilling})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(443, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnEdit
        '
        Me.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(86, 22)
        Me.btnEdit.Text = "Enable Editing"
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
        'memberDetailsView
        '
        Me.memberDetailsView.BoundMember = Nothing
        Me.memberDetailsView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.memberDetailsView.Enabled = False
        Me.memberDetailsView.Location = New System.Drawing.Point(0, 0)
        Me.memberDetailsView.MinimumSize = New System.Drawing.Size(455, 321)
        Me.memberDetailsView.Name = "memberDetailsView"
        Me.memberDetailsView.Size = New System.Drawing.Size(455, 321)
        Me.memberDetailsView.TabIndex = 1
        '
        'btnBilling
        '
        Me.btnBilling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnBilling.Image = CType(resources.GetObject("btnBilling.Image"), System.Drawing.Image)
        Me.btnBilling.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBilling.Name = "btnBilling"
        Me.btnBilling.Size = New System.Drawing.Size(44, 22)
        Me.btnBilling.Text = "Billing"
        '
        'ModifyMemberDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(443, 302)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.memberDetailsView)
        Me.MinimumSize = New System.Drawing.Size(459, 341)
        Me.Name = "ModifyMemberDialog"
        Me.Text = "Member Profile"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents memberDetailsView As MemberDetails
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnBilling As ToolStripButton
End Class
