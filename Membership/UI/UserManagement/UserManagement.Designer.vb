<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserManagement
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Adbtn = New System.Windows.Forms.Button()
        Me.Delbtn = New System.Windows.Forms.Button()
        Me.UDbtn = New System.Windows.Forms.Button()
        Me.CLbtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Logo = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Logo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CLbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.UDbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Delbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Adbtn)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(527, 265)
        Me.SplitContainer1.SplitterDistance = 175
        Me.SplitContainer1.TabIndex = 0
        '
        'Adbtn
        '
        Me.Adbtn.Location = New System.Drawing.Point(13, 13)
        Me.Adbtn.Name = "Adbtn"
        Me.Adbtn.Size = New System.Drawing.Size(150, 23)
        Me.Adbtn.TabIndex = 0
        Me.Adbtn.Text = "Add"
        Me.Adbtn.UseVisualStyleBackColor = True
        '
        'Delbtn
        '
        Me.Delbtn.Location = New System.Drawing.Point(13, 43)
        Me.Delbtn.Name = "Delbtn"
        Me.Delbtn.Size = New System.Drawing.Size(150, 23)
        Me.Delbtn.TabIndex = 1
        Me.Delbtn.Text = "Delete"
        Me.Delbtn.UseVisualStyleBackColor = True
        '
        'UDbtn
        '
        Me.UDbtn.Location = New System.Drawing.Point(13, 73)
        Me.UDbtn.Name = "UDbtn"
        Me.UDbtn.Size = New System.Drawing.Size(150, 23)
        Me.UDbtn.TabIndex = 2
        Me.UDbtn.Text = "Update"
        Me.UDbtn.UseVisualStyleBackColor = True
        '
        'CLbtn
        '
        Me.CLbtn.Location = New System.Drawing.Point(13, 103)
        Me.CLbtn.Name = "CLbtn"
        Me.CLbtn.Size = New System.Drawing.Size(150, 23)
        Me.CLbtn.TabIndex = 3
        Me.CLbtn.Text = "Clear"
        Me.CLbtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(345, 254)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Username"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Password"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Confirm Password"
        Me.Column3.Name = "Column3"
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.Transparent
        Me.Logo.Image = Global.Membership.My.Resources.Resources.logo_imperial_golf_club
        Me.Logo.Location = New System.Drawing.Point(15, 133)
        Me.Logo.Margin = New System.Windows.Forms.Padding(4)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(144, 120)
        Me.Logo.TabIndex = 4
        Me.Logo.TabStop = False
        '
        'UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 265)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserManagement"
        Me.Text = "UserManagement"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CLbtn As Button
    Friend WithEvents UDbtn As Button
    Friend WithEvents Delbtn As Button
    Friend WithEvents Adbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Logo As PictureBox
End Class
