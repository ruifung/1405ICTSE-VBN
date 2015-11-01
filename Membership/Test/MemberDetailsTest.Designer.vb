<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemberDetailsTest
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
        Dim None_12 As Membership.None(Of System.Drawing.Image) = New Membership.None(Of System.Drawing.Image)()
        Me.MemberDetails1 = New Membership.MemberDetails()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MemberDetails1
        '
        Me.MemberDetails1.address = ""
        Me.MemberDetails1.BoundMember = Nothing
        Me.MemberDetails1.contactNumber = ""
        Me.MemberDetails1.dob = New Date(CType(0, Long))
        Me.MemberDetails1.email = ""
        Me.MemberDetails1.firstName = ""
        Me.MemberDetails1.gender = Membership.Gender.NONE
        Me.MemberDetails1.id = -1
        Me.MemberDetails1.image = Nothing
        Me.MemberDetails1.isActive = False
        Me.MemberDetails1.lastName = ""
        Me.MemberDetails1.Location = New System.Drawing.Point(-2, -2)
        Me.MemberDetails1.membershipTypeID = -1
        Me.MemberDetails1.Name = "MemberDetails1"
        Me.MemberDetails1.photo = None_12
        Me.MemberDetails1.Size = New System.Drawing.Size(442, 303)
        Me.MemberDetails1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(505, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Bind"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(505, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Unbind"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MemberDetailsTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 317)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MemberDetails1)
        Me.Name = "MemberDetailsTest"
        Me.Text = "MemberDetailsTest"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MemberDetails1 As MemberDetails
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
