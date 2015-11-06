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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserManagement))
        Me.dataView = New System.Windows.Forms.DataGridView()
        Me.cmDGV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts = New System.Windows.Forms.ToolStrip()
        Me.btnShowAll = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.txtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ddFilter = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsByID = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsByUsername = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAccess = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccessLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WrappedUserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmDGV.SuspendLayout()
        Me.ts.SuspendLayout()
        CType(Me.WrappedUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataView
        '
        Me.dataView.AllowUserToAddRows = False
        Me.dataView.AllowUserToDeleteRows = False
        Me.dataView.AutoGenerateColumns = False
        Me.dataView.BackgroundColor = System.Drawing.Color.White
        Me.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.UserNameDataGridViewTextBoxColumn, Me.AccessLevelDataGridViewTextBoxColumn})
        Me.dataView.ContextMenuStrip = Me.cmDGV
        Me.dataView.DataSource = Me.WrappedUserBindingSource
        Me.dataView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataView.Location = New System.Drawing.Point(0, 25)
        Me.dataView.Name = "dataView"
        Me.dataView.ReadOnly = True
        Me.dataView.Size = New System.Drawing.Size(351, 298)
        Me.dataView.TabIndex = 4
        '
        'cmDGV
        '
        Me.cmDGV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEdit, Me.btnRemove})
        Me.cmDGV.Name = "cmDGV"
        Me.cmDGV.Size = New System.Drawing.Size(118, 48)
        '
        'btnEdit
        '
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(117, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnRemove
        '
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(117, 22)
        Me.btnRemove.Text = "Remove"
        '
        'ts
        '
        Me.ts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShowAll, Me.btnSearch, Me.txtSearch, Me.btnAdd, Me.ddFilter})
        Me.ts.Location = New System.Drawing.Point(0, 0)
        Me.ts.Name = "ts"
        Me.ts.Size = New System.Drawing.Size(351, 25)
        Me.ts.TabIndex = 5
        Me.ts.Text = "ToolStrip1"
        '
        'btnShowAll
        '
        Me.btnShowAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnShowAll.Image = CType(resources.GetObject("btnShowAll.Image"), System.Drawing.Image)
        Me.btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(57, 22)
        Me.btnShowAll.Text = "Show All"
        '
        'btnSearch
        '
        Me.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(46, 22)
        Me.btnSearch.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 25)
        '
        'btnAdd
        '
        Me.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(33, 22)
        Me.btnAdd.Text = "Add"
        '
        'ddFilter
        '
        Me.ddFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ddFilter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsByID, Me.tsByUsername, Me.tsAccess})
        Me.ddFilter.Image = CType(resources.GetObject("ddFilter.Image"), System.Drawing.Image)
        Me.ddFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ddFilter.Name = "ddFilter"
        Me.ddFilter.Size = New System.Drawing.Size(34, 22)
        Me.ddFilter.Text = "ID:"
        '
        'tsByID
        '
        Me.tsByID.Checked = True
        Me.tsByID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsByID.Name = "tsByID"
        Me.tsByID.Size = New System.Drawing.Size(140, 22)
        Me.tsByID.Text = "ID"
        '
        'tsByUsername
        '
        Me.tsByUsername.Name = "tsByUsername"
        Me.tsByUsername.Size = New System.Drawing.Size(140, 22)
        Me.tsByUsername.Text = "Username"
        '
        'tsAccess
        '
        Me.tsAccess.Name = "tsAccess"
        Me.tsAccess.Size = New System.Drawing.Size(140, 22)
        Me.tsAccess.Text = "Access Level"
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "userName"
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "Username"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        Me.UserNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AccessLevelDataGridViewTextBoxColumn
        '
        Me.AccessLevelDataGridViewTextBoxColumn.DataPropertyName = "accessLevel"
        Me.AccessLevelDataGridViewTextBoxColumn.HeaderText = "Access Level"
        Me.AccessLevelDataGridViewTextBoxColumn.Name = "AccessLevelDataGridViewTextBoxColumn"
        Me.AccessLevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WrappedUserBindingSource
        '
        Me.WrappedUserBindingSource.DataSource = GetType(Membership.WrappedUser)
        '
        'UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 323)
        Me.Controls.Add(Me.dataView)
        Me.Controls.Add(Me.ts)
        Me.MinimumSize = New System.Drawing.Size(367, 362)
        Me.Name = "UserManagement"
        Me.Text = "UserManagement"
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmDGV.ResumeLayout(False)
        Me.ts.ResumeLayout(False)
        Me.ts.PerformLayout()
        CType(Me.WrappedUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dataView As DataGridView
    Friend WithEvents ts As ToolStrip
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents txtSearch As ToolStripTextBox
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents ddFilter As ToolStripDropDownButton
    Friend WithEvents tsByID As ToolStripMenuItem
    Friend WithEvents tsByUsername As ToolStripMenuItem
    Friend WithEvents tsAccess As ToolStripMenuItem
    Friend WithEvents WrappedUserBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UserNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AccessLevelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents btnShowAll As ToolStripButton
    Friend WithEvents cmDGV As ContextMenuStrip
    Friend WithEvents btnEdit As ToolStripMenuItem
    Friend WithEvents btnRemove As ToolStripMenuItem
End Class
