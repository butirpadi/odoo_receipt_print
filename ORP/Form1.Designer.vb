﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDocType = New System.Windows.Forms.ComboBox()
        Me.tbDocNumber = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.contextMenuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbPreviewNumber = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTesting = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbPreviewDate = New System.Windows.Forms.TextBox()
        Me.btnGeneratePrinterData = New System.Windows.Forms.Button()
        Me.cbPreviewAvailable = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPreviewPartner = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.contextMenuTray.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter document number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Document to print"
        '
        'cbDocType
        '
        Me.cbDocType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDocType.FormattingEnabled = True
        Me.cbDocType.Items.AddRange(New Object() {"Sales Order", "Purchase Order", "Delivery Order", "Customer Invoice", "Vendor Bill"})
        Me.cbDocType.Location = New System.Drawing.Point(145, 14)
        Me.cbDocType.Margin = New System.Windows.Forms.Padding(4)
        Me.cbDocType.Name = "cbDocType"
        Me.cbDocType.Size = New System.Drawing.Size(396, 24)
        Me.cbDocType.TabIndex = 2
        '
        'tbDocNumber
        '
        Me.tbDocNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDocNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDocNumber.Location = New System.Drawing.Point(20, 80)
        Me.tbDocNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.tbDocNumber.Name = "tbDocNumber"
        Me.tbDocNumber.Size = New System.Drawing.Size(457, 29)
        Me.tbDocNumber.TabIndex = 3
        Me.tbDocNumber.Text = "INV/KS/2112002006"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(335, 373)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 37)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(443, 373)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 37)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.contextMenuTray
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Odoo Receipt Print Manager"
        Me.NotifyIcon1.Visible = True
        '
        'contextMenuTray
        '
        Me.contextMenuTray.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.contextMenuTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.contextMenuTray.Name = "contextMenuTray"
        Me.contextMenuTray.Size = New System.Drawing.Size(115, 52)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(114, 24)
        Me.ToolStripMenuItem1.Text = "Show"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(114, 24)
        Me.ToolStripMenuItem2.Text = "Exit"
        '
        'btnSetting
        '
        Me.btnSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetting.Location = New System.Drawing.Point(20, 373)
        Me.btnSetting.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(100, 37)
        Me.btnSetting.TabIndex = 9
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Image = Global.ORP.My.Resources.Resource1.search_black
        Me.btnSearch.Location = New System.Drawing.Point(485, 78)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(57, 34)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 33)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Document Number"
        '
        'tbPreviewNumber
        '
        Me.tbPreviewNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPreviewNumber.BackColor = System.Drawing.Color.White
        Me.tbPreviewNumber.Enabled = False
        Me.tbPreviewNumber.Location = New System.Drawing.Point(177, 30)
        Me.tbPreviewNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPreviewNumber.Name = "tbPreviewNumber"
        Me.tbPreviewNumber.Size = New System.Drawing.Size(324, 22)
        Me.tbPreviewNumber.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnTesting)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.tbPreviewDate)
        Me.GroupBox1.Controls.Add(Me.btnGeneratePrinterData)
        Me.GroupBox1.Controls.Add(Me.cbPreviewAvailable)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbPreviewPartner)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbPreviewNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 140)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(523, 225)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Preview"
        '
        'btnTesting
        '
        Me.btnTesting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTesting.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTesting.Location = New System.Drawing.Point(415, 181)
        Me.btnTesting.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTesting.Name = "btnTesting"
        Me.btnTesting.Size = New System.Drawing.Size(100, 37)
        Me.btnTesting.TabIndex = 20
        Me.btnTesting.Text = "-- TEST --"
        Me.btnTesting.UseVisualStyleBackColor = False
        Me.btnTesting.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 64)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Date"
        '
        'tbPreviewDate
        '
        Me.tbPreviewDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPreviewDate.BackColor = System.Drawing.Color.White
        Me.tbPreviewDate.Enabled = False
        Me.tbPreviewDate.Location = New System.Drawing.Point(177, 60)
        Me.tbPreviewDate.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPreviewDate.Name = "tbPreviewDate"
        Me.tbPreviewDate.Size = New System.Drawing.Size(324, 22)
        Me.tbPreviewDate.TabIndex = 19
        '
        'btnGeneratePrinterData
        '
        Me.btnGeneratePrinterData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGeneratePrinterData.Location = New System.Drawing.Point(177, 153)
        Me.btnGeneratePrinterData.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGeneratePrinterData.Name = "btnGeneratePrinterData"
        Me.btnGeneratePrinterData.Size = New System.Drawing.Size(187, 37)
        Me.btnGeneratePrinterData.TabIndex = 14
        Me.btnGeneratePrinterData.Text = "Generate Printer Data"
        Me.btnGeneratePrinterData.UseVisualStyleBackColor = True
        Me.btnGeneratePrinterData.Visible = False
        '
        'cbPreviewAvailable
        '
        Me.cbPreviewAvailable.AutoSize = True
        Me.cbPreviewAvailable.Enabled = False
        Me.cbPreviewAvailable.ForeColor = System.Drawing.Color.Black
        Me.cbPreviewAvailable.Location = New System.Drawing.Point(177, 124)
        Me.cbPreviewAvailable.Margin = New System.Windows.Forms.Padding(4)
        Me.cbPreviewAvailable.Name = "cbPreviewAvailable"
        Me.cbPreviewAvailable.Size = New System.Drawing.Size(86, 20)
        Me.cbPreviewAvailable.TabIndex = 17
        Me.cbPreviewAvailable.Text = "Available"
        Me.cbPreviewAvailable.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 126)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Print Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Partner"
        '
        'tbPreviewPartner
        '
        Me.tbPreviewPartner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPreviewPartner.BackColor = System.Drawing.Color.White
        Me.tbPreviewPartner.Enabled = False
        Me.tbPreviewPartner.Location = New System.Drawing.Point(177, 92)
        Me.tbPreviewPartner.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPreviewPartner.Name = "tbPreviewPartner"
        Me.tbPreviewPartner.Size = New System.Drawing.Size(324, 22)
        Me.tbPreviewPartner.TabIndex = 14
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 417)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Maximum = 250
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(527, 12)
        Me.ProgressBar1.TabIndex = 14
        Me.ProgressBar1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 433)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.tbDocNumber)
        Me.Controls.Add(Me.cbDocType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Odoo Receipt Print Manager"
        Me.contextMenuTray.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbDocType As ComboBox
    Friend WithEvents tbDocNumber As TextBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents contextMenuTray As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents btnSetting As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tbPreviewNumber As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGeneratePrinterData As Button
    Friend WithEvents cbPreviewAvailable As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbPreviewPartner As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label6 As Label
    Friend WithEvents tbPreviewDate As TextBox
    Friend WithEvents btnTesting As Button
End Class
