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
        Dim None_12 As Membership.None(Of System.Drawing.Image) = New Membership.None(Of System.Drawing.Image)()
        Me.tabView = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.memberDetailsView = New Membership.MemberDetails()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tabView.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabView
        '
        Me.tabView.Controls.Add(Me.TabPage1)
        Me.tabView.Controls.Add(Me.TabPage2)
        Me.tabView.Location = New System.Drawing.Point(2, 3)
        Me.tabView.Name = "tabView"
        Me.tabView.SelectedIndex = 0
        Me.tabView.Size = New System.Drawing.Size(465, 349)
        Me.tabView.TabIndex = 57
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnAccept)
        Me.TabPage1.Controls.Add(Me.memberDetailsView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(457, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Member Profile"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'memberDetailsView
        '
        Me.memberDetailsView.address = Nothing
        Me.memberDetailsView.BoundMember = Nothing
        Me.memberDetailsView.contactNumber = ""
        Me.memberDetailsView.dob = New Date(2015, 10, 31, 12, 18, 58, 628)
        Me.memberDetailsView.email = ""
        Me.memberDetailsView.firstName = ""
        Me.memberDetailsView.gender = Membership.Gender.NONE
        Me.memberDetailsView.id = 0
        Me.memberDetailsView.image = Nothing
        Me.memberDetailsView.isActive = False
        Me.memberDetailsView.lastName = ""
        Me.memberDetailsView.Location = New System.Drawing.Point(12, 12)
        Me.memberDetailsView.membershipTypeID = 0
        Me.memberDetailsView.Name = "memberDetailsView"
        Me.memberDetailsView.photo = None_12
        Me.memberDetailsView.Size = New System.Drawing.Size(442, 303)
        Me.memberDetailsView.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(457, 323)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Transactions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(291, 297)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 61
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(372, 297)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(75, 23)
        Me.btnAccept.TabIndex = 60
        Me.btnAccept.Text = "Save"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(4, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(448, 315)
        Me.DataGridView1.TabIndex = 0
        '
        'ModifyMemberDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(468, 352)
        Me.Controls.Add(Me.tabView)
        Me.Name = "ModifyMemberDialog"
        Me.Text = "Member Profile"
        Me.tabView.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabView As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents memberDetailsView As MemberDetails
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAccept As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
