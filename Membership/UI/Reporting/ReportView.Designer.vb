<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportView
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.memberReport = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.reportMember = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.reportStatus = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.paymentReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SourceMemberPayments = New System.Windows.Forms.BindingSource(Me.components)
        Me.sourceStatus = New System.Windows.Forms.BindingSource(Me.components)
        Me.sourceMember = New System.Windows.Forms.BindingSource(Me.components)
        Me.IMemberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportPaymentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.memberReport.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.SourceMemberPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sourceStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sourceMember, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMemberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportPaymentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'memberReport
        '
        Me.memberReport.Controls.Add(Me.TabPage1)
        Me.memberReport.Controls.Add(Me.TabPage2)
        Me.memberReport.Controls.Add(Me.TabPage3)
        Me.memberReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.memberReport.Location = New System.Drawing.Point(0, 0)
        Me.memberReport.Name = "memberReport"
        Me.memberReport.SelectedIndex = 0
        Me.memberReport.Size = New System.Drawing.Size(562, 418)
        Me.memberReport.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.reportMember)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(554, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Member Report"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'reportMember
        '
        Me.reportMember.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.IMemberBindingSource
        Me.reportMember.LocalReport.DataSources.Add(ReportDataSource1)
        Me.reportMember.LocalReport.ReportEmbeddedResource = "Membership.Report3.rdlc"
        Me.reportMember.Location = New System.Drawing.Point(3, 3)
        Me.reportMember.Name = "reportMember"
        Me.reportMember.Size = New System.Drawing.Size(548, 386)
        Me.reportMember.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.reportStatus)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(554, 392)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Member Status Report"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'reportStatus
        '
        Me.reportStatus.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.ReportPaymentBindingSource
        Me.reportStatus.LocalReport.DataSources.Add(ReportDataSource2)
        Me.reportStatus.LocalReport.ReportEmbeddedResource = "Membership.Report2.rdlc"
        Me.reportStatus.Location = New System.Drawing.Point(3, 3)
        Me.reportStatus.Name = "reportStatus"
        Me.reportStatus.Size = New System.Drawing.Size(548, 386)
        Me.reportStatus.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.paymentReport)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(554, 392)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Member Payment Report"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'paymentReport
        '
        Me.paymentReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paymentReport.LocalReport.ReportEmbeddedResource = "Membership.Report1.rdlc"
        Me.paymentReport.Location = New System.Drawing.Point(0, 0)
        Me.paymentReport.Name = "paymentReport"
        Me.paymentReport.Size = New System.Drawing.Size(554, 392)
        Me.paymentReport.TabIndex = 0
        '
        'IMemberBindingSource
        '
        Me.IMemberBindingSource.DataSource = GetType(Membership.IMember)
        '
        'ReportPaymentBindingSource
        '
        Me.ReportPaymentBindingSource.DataSource = GetType(Membership.ReportPayment)
        '
        'ReportView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 418)
        Me.Controls.Add(Me.memberReport)
        Me.Name = "ReportView"
        Me.Text = "ReportView"
        Me.memberReport.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.SourceMemberPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sourceStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sourceMember, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMemberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportPaymentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents memberReport As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents reportMember As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents reportStatus As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents paymentReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents SourceMemberPayments As BindingSource
    Friend WithEvents sourceStatus As BindingSource
    Friend WithEvents sourceMember As BindingSource
    Friend WithEvents IMemberBindingSource As BindingSource
    Friend WithEvents ReportPaymentBindingSource As BindingSource
End Class
