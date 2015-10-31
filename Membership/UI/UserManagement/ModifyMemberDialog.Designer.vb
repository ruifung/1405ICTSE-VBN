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
        Dim None_11 As Membership.None(Of System.Drawing.Image) = New Membership.None(Of System.Drawing.Image)()
        Me.tabView = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MemberDetails1 = New Membership.MemberDetails()
        Me.tabView.SuspendLayout()
        Me.TabPage1.SuspendLayout()
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
        Me.TabPage1.Controls.Add(Me.MemberDetails1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(457, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Member Profile"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(457, 323)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Transactions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MemberDetails1
        '
        Me.MemberDetails1.contactNumber = ""
        Me.MemberDetails1.dob = New Date(2015, 10, 31, 12, 18, 58, 628)
        Me.MemberDetails1.email = ""
        Me.MemberDetails1.firstName = ""
        Me.MemberDetails1.gender = Membership.Gender.MALE
        Me.MemberDetails1.id = 0
        Me.MemberDetails1.isActive = False
        Me.MemberDetails1.lastName = ""
        Me.MemberDetails1.Location = New System.Drawing.Point(12, 12)
        Me.MemberDetails1.membershipTypeID = 0
        Me.MemberDetails1.Name = "MemberDetails1"
        Me.MemberDetails1.photo = None_11
        Me.MemberDetails1.Size = New System.Drawing.Size(442, 303)
        Me.MemberDetails1.TabIndex = 0
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
        Me.Text = "ModifyMemberDialog"
        Me.tabView.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabView As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents MemberDetails1 As MemberDetails
End Class
