<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MemberDetailsTest
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MemberDetails1 = New Membership.MemberDetails()
        Me.MemberDetails2 = New Membership.MemberDetails()
        Me.SuspendLayout()
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
        'MemberDetails1
        '
        Me.MemberDetails1.BoundMember = Nothing
        Me.MemberDetails1.Location = New System.Drawing.Point(12, 12)
        Me.MemberDetails1.Name = "MemberDetails1"
        Me.MemberDetails1.Size = New System.Drawing.Size(442, 303)
        Me.MemberDetails1.TabIndex = 3
        '
        'MemberDetails2
        '
        Me.MemberDetails2.BoundMember = Nothing
        Me.MemberDetails2.Enabled = False
        Me.MemberDetails2.Location = New System.Drawing.Point(12, 316)
        Me.MemberDetails2.Name = "MemberDetails2"
        Me.MemberDetails2.Size = New System.Drawing.Size(442, 303)
        Me.MemberDetails2.TabIndex = 4
        '
        'MemberDetailsTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 631)
        Me.Controls.Add(Me.MemberDetails2)
        Me.Controls.Add(Me.MemberDetails1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "MemberDetailsTest"
        Me.Text = "MemberDetailsTest"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents MemberDetails1 As MemberDetails
    Friend WithEvents MemberDetails2 As MemberDetails
End Class
