<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetting
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbServer = New System.Windows.Forms.TextBox()
        Me.tbUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDatabase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbDocType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbAdminPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbPrinter = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTestPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Location"
        '
        'tbServer
        '
        Me.tbServer.Location = New System.Drawing.Point(136, 36)
        Me.tbServer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbServer.Name = "tbServer"
        Me.tbServer.Size = New System.Drawing.Size(328, 22)
        Me.tbServer.TabIndex = 1
        '
        'tbUsername
        '
        Me.tbUsername.Location = New System.Drawing.Point(136, 63)
        Me.tbUsername.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbUsername.Name = "tbUsername"
        Me.tbUsername.Size = New System.Drawing.Size(328, 22)
        Me.tbUsername.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Username"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(136, 91)
        Me.tbPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(328, 22)
        Me.tbPassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Password"
        '
        'tbDatabase
        '
        Me.tbDatabase.Location = New System.Drawing.Point(136, 119)
        Me.tbDatabase.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbDatabase.Name = "tbDatabase"
        Me.tbDatabase.Size = New System.Drawing.Size(328, 22)
        Me.tbDatabase.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Database Name"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(403, 375)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 37)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(293, 375)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 37)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Location = New System.Drawing.Point(20, 375)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(139, 37)
        Me.btnConnect.TabIndex = 12
        Me.btnConnect.Text = "Test Connection"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbServer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbUsername)
        Me.GroupBox1.Controls.Add(Me.tbDatabase)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbPassword)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(487, 159)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'cbDocType
        '
        Me.cbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDocType.FormattingEnabled = True
        Me.cbDocType.Items.AddRange(New Object() {"Sales Order", "Purchase Order", "Delivery Order", "Customer Invoice", "Vendor Bill"})
        Me.cbDocType.Location = New System.Drawing.Point(151, 32)
        Me.cbDocType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbDocType.Name = "cbDocType"
        Me.cbDocType.Size = New System.Drawing.Size(313, 24)
        Me.cbDocType.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Default Document"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.tbAdminPassword)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.tbPrinter)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbDocType)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 181)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(487, 167)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Application Setting"
        '
        'tbAdminPassword
        '
        Me.tbAdminPassword.Location = New System.Drawing.Point(151, 97)
        Me.tbAdminPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbAdminPassword.Name = "tbAdminPassword"
        Me.tbAdminPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbAdminPassword.Size = New System.Drawing.Size(313, 22)
        Me.tbAdminPassword.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Admin Password"
        '
        'tbPrinter
        '
        Me.tbPrinter.Location = New System.Drawing.Point(151, 65)
        Me.tbPrinter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbPrinter.Name = "tbPrinter"
        Me.tbPrinter.Size = New System.Drawing.Size(313, 22)
        Me.tbPrinter.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Printer Name"
        '
        'btnTestPrint
        '
        Me.btnTestPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTestPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestPrint.Location = New System.Drawing.Point(168, 375)
        Me.btnTestPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnTestPrint.Name = "btnTestPrint"
        Me.btnTestPrint.Size = New System.Drawing.Size(116, 37)
        Me.btnTestPrint.TabIndex = 17
        Me.btnTestPrint.Text = "Test Print"
        Me.btnTestPrint.UseVisualStyleBackColor = True
        '
        'FormSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 427)
        Me.Controls.Add(Me.btnTestPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSetting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbServer As TextBox
    Friend WithEvents tbUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbDatabase As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnConnect As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbDocType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbPrinter As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnTestPrint As Button
    Friend WithEvents tbAdminPassword As TextBox
    Friend WithEvents Label7 As Label
End Class
