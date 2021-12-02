<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDocType = New System.Windows.Forms.ComboBox()
        Me.tbDocNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.contextMenuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSetting = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenuTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter document number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Document to print"
        '
        'cbDocType
        '
        Me.cbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDocType.FormattingEnabled = True
        Me.cbDocType.Items.AddRange(New Object() {"Sales Order", "Purchase Order", "Delivery Order", "Customer Invoice", "Vendor Bill"})
        Me.cbDocType.Location = New System.Drawing.Point(145, 14)
        Me.cbDocType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbDocType.Name = "cbDocType"
        Me.cbDocType.Size = New System.Drawing.Size(276, 24)
        Me.cbDocType.TabIndex = 2
        '
        'tbDocNumber
        '
        Me.tbDocNumber.Location = New System.Drawing.Point(20, 80)
        Me.tbDocNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbDocNumber.Name = "tbDocNumber"
        Me.tbDocNumber.Size = New System.Drawing.Size(401, 22)
        Me.tbDocNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 124)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data preview"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(215, 562)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 28)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(323, 562)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 28)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colValue})
        Me.DataGridView1.Location = New System.Drawing.Point(20, 144)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(403, 401)
        Me.DataGridView1.TabIndex = 8
        '
        'colName
        '
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'colValue
        '
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        Me.colValue.ReadOnly = True
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
        Me.btnSetting.Location = New System.Drawing.Point(20, 562)
        Me.btnSetting.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(100, 28)
        Me.btnSetting.TabIndex = 9
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 606)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbDocNumber)
        Me.Controls.Add(Me.cbDocType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Odoo Receipt Print Manager"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenuTray.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbDocType As ComboBox
    Friend WithEvents tbDocNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents contextMenuTray As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colValue As DataGridViewTextBoxColumn
    Friend WithEvents btnSetting As Button
End Class
