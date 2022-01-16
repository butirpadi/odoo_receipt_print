Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports ESC_POS_USB_NET


Public Class Form1

    Dim WithEvents fsetting As New FormSetting
    Dim WithEvents fpassword As New FormPassword
    Private server_location As String
    Private dbname As String
    Private username As String
    Private password As String
    Private adminPassword As String
    Private printerName As String
    Private doc_type_idx As Integer = -1
    Private font_index As Integer = -1
    Private font_style_index As Integer = -1
    Private session_id As String
    Private printer_data As String

    ' FONT
    Private ROMAN_FONT As String = Chr(27) & Chr(107) & Chr(48)
    Private SANS_FONT As String = Chr(27) & Chr(107) & Chr(49)
    Private DRAFT_FONT As String = Chr(27) & Chr(120) & Chr(48)
    Private NLQ_FONT As String = Chr(27) & Chr(120) & Chr(49)

    ' STYLE
    Private STYLE_PICA As String = Chr(27) & Chr(33) & Chr(0)
    Private STYLE_ELITE As String = Chr(27) & Chr(33) & Chr(1)
    Private STYLE_CONDENSED As String = Chr(27) & Chr(33) & Chr(4)
    Private STYLE_EMPHASIZED As String = Chr(27) & Chr(33) & Chr(8)
    Private STYLE_DOUBLE_STRIKE As String = Chr(27) & Chr(33) & Chr(16)
    Private STYLE_DOUBLE_WIDE As String = Chr(27) & Chr(33) & Chr(32)
    Private STYLE_ITALIC As String = Chr(27) & Chr(33) & Chr(64)
    Private STYLE_UNDERLINE As String = Chr(27) & Chr(33) & Chr(128)

    Private SIZE_CONDENSED As String = Chr(15)
    Private SIZE_ELITE As String = Chr(27) & Chr(77)
    Private SIZE_PICA As String = Chr(27) & Chr(77)

    Private CANCEL_CONDENSED As String = Chr(18)
    Private CANCEL_COMMAND As String = Chr(27) & Chr(55)

    Public Shared DBConnectionString As String = "Data Source=" + Directory.GetCurrentDirectory() + "\mydb.sqlite" + "; Integrated Security=true"

    Private Sub fsetting_on_datasaved(sender As Object, e As EventArgs) Handles fsetting.DataSaved
        Me.doc_type_idx = fsetting.DocumentTypeIndex
        Me.font_index = fsetting.FontTypeIndex
        Me.font_style_index = fsetting.FontStyleIndex
        Me.cbDocType.SelectedIndex = fsetting.DocumentTypeIndex
        Me.server_location = fsetting.ServerLocation
        Me.username = fsetting.Username
        Me.password = fsetting.Password
        Me.dbname = fsetting.Database
        Me.adminPassword = fsetting.AdminPassword
        Me.printerName = fsetting.PrinterName
        Console.WriteLine("Update Setting")
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        closingForm()
    End Sub

    Private Sub closingForm()
        If MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        closingForm()
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        'Open Form setting

        'fsetting.ShowDialog()
        fpassword.tbInputPassword.Clear()
        fpassword.ShowDialog()

    End Sub

    Private Sub _initConnection()
        Me.session_id = OdooConnection.GetSessionId(Me.server_location, Me.dbname, Me.username, Me.password)
    End Sub

    Private Function GetOdooWebRequest(address As String, data As Byte()) As HttpWebRequest
        Dim myReq As HttpWebRequest = HttpWebRequest.Create(address)
        myReq.Method = "POST"
        myReq.ContentType = "application/json"
        myReq.ContentLength = data.Length
        myReq.UserAgent = "Microsoft VB.Net"
        myReq.Timeout = 30000

        If Me.session_id = "" Then
            Me._initConnection()
        End If

        myReq.Headers.Add("Cookie", session_id)

        Return myReq

    End Function

    Private Sub toggleComponent(val As Boolean)
        Me.btnClose.Enabled = val
        Me.btnSetting.Enabled = val
        Me.btnSearch.Enabled = val
        Me.tbDocNumber.Enabled = val
        Me.cbDocType.Enabled = val
    End Sub

    Private Sub clearPreview()
        Me.tbPreviewDate.Clear()
        Me.tbPreviewNumber.Clear()
        Me.tbPreviewPartner.Clear()
        Me.cbPreviewAvailable.Checked = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.toggleComponent(False)
        Me.clearPreview()
        Me.btnPrint.Enabled = False

        Try
            Dim jsonData = OdooConnection.GetConnectionString(Me.dbname, Me.username, Me.password)
            Dim postDataAccountInvoice = "{
                  ""jsonrpc"":   ""2.0"",
                  ""method"": ""call"",
                  ""id"": 1,
                  ""params"": {
                    ""number"": """ & tbDocNumber.Text & """,
                    ""font_type"": """ & CStr(Me.font_style_index) & """
                  }
                }"

            'Document Type :
            '1. Sales Order
            '2. Purchase Order
            '3. Delivery Order
            '4. Customer Invoice
            '5. Vendor Bill

            ' default document type is sales order
            Dim request_url = Me.server_location & "/get/sales/order" 'OK

            If Me.cbDocType.SelectedItem = "Customer Invoice" Then 'OK
                request_url = Me.server_location & "/get/customer/invoice"
            ElseIf Me.cbDocType.SelectedItem = "Purchase Order" Then 'OK
                request_url = Me.server_location & "/get/purchase/order"
            ElseIf Me.cbDocType.SelectedItem = "Delivery Order" Then
                request_url = Me.server_location & "/get/delivery/order" ' OK
            ElseIf Me.cbDocType.SelectedItem = "Vendor Bill" Then 'OK
                request_url = Me.server_location & "/get/vendor/bill"
            End If

            ' search document 
            Dim postData = Encoding.ASCII.GetBytes(postDataAccountInvoice)
            Dim myReq = Me.GetOdooWebRequest(request_url, postData)
            Dim stream = myReq.GetRequestStream()
            stream.Write(postData, 0, postData.Length)

            Dim response As HttpWebResponse = myReq.GetResponse()
            If response.StatusCode = 200 Then
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(dataStream)
                Dim responseString = reader.ReadToEnd()


                If responseString.ToLower.Contains("error") Then
                    MessageBox.Show("500 Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.toggleComponent(True)
                Else


                    Dim invoiceJobj As JObject = JObject.Parse(responseString)
                    Dim resultsObj As JObject = invoiceJobj("result")
                    'Dim invoiceLines As JArray = resultsObj("invoice_lines")

                    ' Show data to input
                    Me.tbPreviewNumber.Text = resultsObj("number")
                    Me.tbPreviewPartner.Text = resultsObj("partner")
                    Me.tbPreviewDate.Text = resultsObj("date")
                    If resultsObj("printer_data") <> "" Then
                        Me.cbPreviewAvailable.Checked = True
                        Me.btnGeneratePrinterData.Visible = False
                        Me.btnPrint.Enabled = True
                        Me.printer_data = resultsObj("printer_data").ToString.Replace("<p>", "").Replace("</p>", "").Replace("< / p >", "").Replace("< p >", "").Replace("&amp;", "&")
                    Else
                        Me.cbPreviewAvailable.Checked = False
                        Me.btnGeneratePrinterData.Visible = True
                        Me.btnPrint.Enabled = False
                    End If

                End If

                ' closing
                reader.Close()
                dataStream.Close()
                response.Close()
                stream.Close()
                myReq.Abort()

            ElseIf response.StatusCode = 500 Then
                MessageBox.Show("500 Internal Server Erro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As WebException
            Console.WriteLine(ex.ToString)
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Me.toggleComponent(True)
        End Try

    End Sub

    Private Sub search_customer_invoice(number As String)

    End Sub

    Private Sub search_vendor_bill(number As String)

    End Sub

    Private Sub search_delivery_order(number As String)

    End Sub

    Private Sub search_purchase_order(number As String)

    End Sub

    Private Sub search_sale_order(number As String)

    End Sub

    Private Sub initDb(conn As SQLiteConnection)
        conn.Open()
        Dim createCmd As SQLiteCommand = conn.CreateCommand()
        Using createCmd
            With createCmd
                .CommandText = "CREATE TABLE IF NOT EXISTS orp_setting (id INTEGER NOT NULL, server_location TEXT, username TEXT, password TEXT, database TEXT, printer_name TEXT,admin_password TEXT, doc_type_idx INTEGER, font_type_index INTEGER,font_style_index INTEGER,PRIMARY KEY(id AUTOINCREMENT) )"
                .ExecuteNonQuery()
            End With
        End Using

        Dim selectCmd As SQLiteCommand = conn.CreateCommand()
        Dim reader As SQLiteDataReader
        With selectCmd
            .CommandText = "select * from orp_setting"
            reader = .ExecuteReader()
            Using reader
                If Not reader.HasRows Then
                    Dim insertCmd As SQLiteCommand = conn.CreateCommand()
                    With insertCmd
                        .CommandText = "INSERT INTO orp_setting (server_location,username,password,database,printer_name,admin_password,doc_type_idx) values (@server,@username,@password,@database,@printer_name,@admin_password, @doc_type_idx)"
                        With .Parameters
                            .Add(New SQLiteParameter("@server", "dummy"))
                            .Add(New SQLiteParameter("@username", "dummy"))
                            .Add(New SQLiteParameter("@password", "dummy"))
                            .Add(New SQLiteParameter("@database", "dummy"))
                            .Add(New SQLiteParameter("@printer_name", "dummy"))
                            .Add(New SQLiteParameter("@admin_password", "admin"))
                            .Add(New SQLiteParameter("@doc_type_idx", "0"))
                        End With
                        .ExecuteNonQuery()
                    End With
                End If

                reader.Close()
            End Using
        End With



        conn.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' load credential from sqlite 
        Dim myconn As New SQLiteConnection(Form1.DBConnectionString)

        initDb(myconn)

        myconn.Open()
        Dim selectCmd As New SQLiteCommand(myconn)
        selectCmd.CommandText = "select * from orp_setting limit 1"
        Dim reader = selectCmd.ExecuteReader()

        ' show data to text box
        While reader.Read()
            Me.server_location = reader("server_location").ToString
            Me.username = reader("username").ToString
            Me.password = reader("password").ToString
            Me.dbname = reader("database").ToString
            Me.printerName = reader("printer_name").ToString
            Me.adminPassword = reader("admin_password").ToString

            'Dim index As Integer = reader.GetOrdinal("doc_type_idx")
            'If Not reader.IsDBNull(index) Then
            '    Me.doc_type_idx = CInt(reader("doc_type_idx"))
            'Else
            '    Me.doc_type_idx = -1
            'End If

            'Me.doc_type_idx = IIf(reader("doc_type_idx").ToString.Trim = "", -1, CInt(reader("doc_type_idx").ToString))

            If reader("doc_type_idx").ToString.Trim = "" Then
                Me.doc_type_idx = -1
            Else
                Me.doc_type_idx = CInt(reader("doc_type_idx").ToString.Trim)
            End If

            Me.cbDocType.SelectedIndex = Me.doc_type_idx

            If reader("font_type_index").ToString.Trim = "" Then
                Me.font_index = -1
            Else
                Me.font_index = CInt(reader("font_type_index").ToString.Trim)
            End If

            If reader("font_style_index").ToString.Trim = "" Then
                Me.font_style_index = -1
            Else
                Me.font_style_index = CInt(reader("font_style_index").ToString.Trim)
            End If

            'Me.font_index = IIf(reader("font_type_index").ToString.Trim = "", -1, CInt(reader("font_type_index").ToString))
            'Me.font_style_index = IIf(reader("font_style_index").ToString.Trim = "", -1, CInt(reader("font_style_index").ToString))

        End While

        reader.Close()
        myconn.Close()
        ' ---------------------------------------------------------------
    End Sub

    Private Sub tbDocNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDocNumber.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            btnSearch.PerformClick()

        End If
    End Sub

    Private Sub _printing_task()
        Try
            Dim printer As New ESC_POS_USB_NET.Printer.Printer(Me.printerName)
            Dim can_print As Boolean = False

            '' font type
            '' 0 ROMAN
            '' 1 SANS SERIF
            '' 2 DRAFT
            '' 3 NLQ
            '' 4 PICA ROMAN
            '' 5 PICA SANS SERIF
            '' 6 PICA DRAFT
            '' 7 PICA NLQ
            '' 8 ELITE ROMAN
            '' 9 ELITE SANS SERIF
            '' 10 ELITE DRAFT
            '' 11 ELITE NLQ
            '' 12 CONDENSED ROMAN
            '' 13 CONDENSED SANS SERIF
            '' 14 CONDENSED DRAFT
            '' 15 CONDENSED NLQ
            '' 16 EMPHASIZED ROMAN
            '' 17 EMPHASIZED SANS SERIF
            '' 18 EMPHASIZED DRAFT
            '' 19 EMPHASIZED NLQ
            '' 20 DOUBLE STRIKE ROMAN
            '' 21 DOUBLE STRIKE SANS SERIF
            '' 22 DOUBLE STRIKE DRAFT
            '' 23 DOUBLE STRIKE NLQ
            '' 24 DOUBLE WIDE ROMAN
            '' 25 DOUBLE WIDE SANS SERIF
            '' 26 DOUBLE WIDE DRAFT
            '' 27 DOUBLE WIDE NLQ


            Dim printer_content As String = ""
            'Dim printer_content As String = "1  5021533        LAMPU NATAL KABEL HITAM POLOS ECO A 100M                 1          KTN/5        214,000              0        214,000"
            'Dim printer_content As String = "1  5021533   LAMPU NATAL KABEL HITAM POLOS EC     1     KTN/5        214,000         0        214,000"
            'Dim printer_content As String = "XXXYYYYYYYYYYDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDQQQQQWWWWWWWWWWTTTTTTTTTTTTTTTPPPPPJJJJJJJJJJJJJJJ"

            ''printer_content = "Font Index : " & Me.font_index & "\n" & printer_content
            ''printer_content = Me.CANCEL_COMMAND & Me.CANCEL_CONDENSED & printer_content

            ' 0 : Normal
            ' 1 : Condensed
            'Console.WriteLine(printer_content)

            ' Font :::
            ' Roman
            ' Sans
            ' Draft
            ' NLQ
            If Me.font_index = 0 Then
                printer_content = Me.ROMAN_FONT & Me.printer_data
            ElseIf Me.font_index = 2 Then
                printer_content = Me.DRAFT_FONT & Me.printer_data
            ElseIf Me.font_index = 3 Then
                printer_content = Me.NLQ_FONT & Me.printer_data
            Else
                printer_content = Me.SANS_FONT & Me.printer_data
            End If

            'Font STYLE
            'Normal
            'Condensed
            If Me.font_style_index = 0 Then
                printer_content = Me.STYLE_ELITE & printer_content
            Else
                printer_content = Me.STYLE_CONDENSED & printer_content
            End If


            'printer.Append(Me.ROMAN_FONT & printer_content)
            'printer.Append(Me.SANS_FONT & printer_content)
            'printer.Append(Me.DRAFT_FONT & printer_content)
            'printer.Append(Me.NLQ_FONT & printer_content)
            'printer.Append("---------------------------------------------------------------------------------------")
            'printer.Append(Me.STYLE_PICA & Me.ROMAN_FONT & printer_content)
            'printer.Append(Me.STYLE_PICA & Me.SANS_FONT & printer_content)
            'printer.Append(Me.STYLE_PICA & Me.DRAFT_FONT & printer_content)
            'printer.Append(Me.STYLE_PICA & Me.NLQ_FONT & printer_content)
            'printer.Append("---------------------------------------------------------------------------------------")
            'printer.Append(Me.STYLE_ELITE & Me.ROMAN_FONT & printer_content)
            'printer.Append(Me.STYLE_ELITE & Me.SANS_FONT & printer_content)
            'printer.Append(Me.STYLE_ELITE & Me.DRAFT_FONT & printer_content)
            'printer.Append(Me.STYLE_ELITE & Me.NLQ_FONT & printer_content)
            'printer.Append("---------------------------------------------------------------------------------------")
            'printer.Append(Me.STYLE_CONDENSED & Me.ROMAN_FONT & printer_content)
            'printer.Append(Me.STYLE_CONDENSED & Me.SANS_FONT & printer_content)
            'printer.Append(Me.STYLE_CONDENSED & Me.DRAFT_FONT & printer_content)
            'printer.Append(Me.STYLE_CONDENSED & Me.NLQ_FONT & printer_content)
            'printer.Append("---------------------------------------------------------------------------------------")
            'printer.Append(Me.STYLE_DOUBLE_STRIKE & Me.ROMAN_FONT & printer_content)
            'printer.Append(Me.STYLE_DOUBLE_STRIKE & Me.SANS_FONT & printer_content)
            'printer.Append(Me.STYLE_DOUBLE_STRIKE & Me.DRAFT_FONT & printer_content)
            'printer.Append(Me.STYLE_DOUBLE_STRIKE & Me.NLQ_FONT & printer_content)
            'printer.Append("---------------------------------------------------------------------------------------")
            'printer.Append(Me.STYLE_DOUBLE_WIDE & Me.ROMAN_FONT & printer_content)
            'printer.Append(Me.STYLE_DOUBLE_WIDE & Me.SANS_FONT & printer_content)
            'printer.Append(Me.STYLE_DOUBLE_WIDE & Me.DRAFT_FONT & printer_content)
            'printer.Append(Me.STYLE_DOUBLE_WIDE & Me.NLQ_FONT & printer_content)

            'can_print = True


            'If Me.font_index = 0 Then
            '    'printer_content = Chr(27) & Chr(33) & Chr(0) & printer_content & Chr(27) & Chr(33) & Chr(0)
            '    'printer_content = Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 1 Then
            '    'printer_content = Chr(27) & Chr(33) & Chr(1) & printer_content & Chr(27) & Chr(33) & Chr(1)
            '    'printer_content = Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 2 Then
            '    'printer_content = Chr(27) & Chr(33) & Chr(4) & printer_content & Chr(27) & Chr(33) & Chr(4)
            '    'printer_content = Me.DRAFT_FONT & printer_content & Me.DRAFT_FONT
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 3 Then
            '    'printer_content = Chr(27) & Chr(33) & Chr(8) & printer_content & Chr(27) & Chr(33) & Chr(8)
            '    'printer_content = Me.NLQ_FONT & printer_content & Me.NLQ_FONT
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 4 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    'printer_content = Me.STYLE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.STYLE_PICA
            '    printer.Append(Me.STYLE_PICA)
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 5 Then
            '    'printer_content = Me.SIZE_CONDE NSED & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_PICA)
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 6 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.STYLE_PICA)
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 7 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_PICA)
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 8 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    'printer_content = Me.STYLE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.STYLE_PICA
            '    printer.Append(Me.STYLE_ELITE)
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 9 Then
            '    'printer_content = Me.SIZE_CONDE NSED & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_ELITE)
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 10 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.STYLE_ELITE)
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 11 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_ELITE)
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 12 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    'printer_content = Me.STYLE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.STYLE_PICA
            '    printer.Append(Me.STYLE_CONDENSED)
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 13 Then
            '    'printer_content = Me.SIZE_CONDE NSED & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_CONDENSED)
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 14 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.STYLE_CONDENSED)
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 15 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_CONDENSED)
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 16 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    'printer_content = Me.STYLE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.STYLE_PICA
            '    printer.Append(Me.STYLE_EMPHASIZED)
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 17 Then
            '    'printer_content = Me.SIZE_CONDE NSED & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_EMPHASIZED)
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 18 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.STYLE_EMPHASIZED)
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 19 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_EMPHASIZED)
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 20 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    'printer_content = Me.STYLE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.STYLE_PICA
            '    printer.Append(Me.STYLE_DOUBLE_STRIKE)
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 21 Then
            '    'printer_content = Me.SIZE_CONDE NSED & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_DOUBLE_STRIKE)
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 22 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.STYLE_DOUBLE_STRIKE)
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 23 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_DOUBLE_STRIKE)
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 24 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT
            '    'printer_content = Me.STYLE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.STYLE_PICA
            '    printer.Append(Me.STYLE_DOUBLE_WIDE)
            '    printer.Append(Me.ROMAN_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 25 Then
            '    'printer_content = Me.SIZE_CONDE NSED & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_DOUBLE_WIDE)
            '    printer.Append(Me.SANS_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 26 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SANS_FONT & printer_content & Me.SANS_FONT
            '    printer.Append(Me.STYLE_DOUBLE_WIDE)
            '    printer.Append(Me.DRAFT_FONT)
            '    can_print = True
            'ElseIf Me.font_index = 27 Then
            '    'printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    printer.Append(Me.STYLE_DOUBLE_WIDE)
            '    printer.Append(Me.NLQ_FONT)
            '    can_print = True
            '    'ElseIf Me.font_index = 8 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.CANCEL_CONDENSED & Me.DRAFT_FONT & printer_content & Me.DRAFT_FONT
            '    'ElseIf Me.font_index = 9 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.DRAFT_FONT & printer_content & Me.DRAFT_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 10 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.NLQ_FONT & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.NLQ_FONT
            '    'ElseIf Me.font_index = 11 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_CONDENSED & Me.NLQ_FONT & printer_content & Me.NLQ_FONT & Me.SIZE_CONDENSED & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 12 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_PICA & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_PICA & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 13 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_PICA & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_PICA & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 14 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_PICA & Me.NLQ_FONT & printer_content & Me.NLQ_FONT & Me.SIZE_PICA & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 15 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_PICA & Me.DRAFT_FONT & printer_content & Me.DRAFT_FONT & Me.SIZE_PICA & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 16 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_ELITE & Me.ROMAN_FONT & printer_content & Me.ROMAN_FONT & Me.SIZE_ELITE & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 17 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_ELITE & Me.SANS_FONT & printer_content & Me.SANS_FONT & Me.SIZE_ELITE & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 18 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_ELITE & Me.NLQ_FONT & printer_content & Me.NLQ_FONT & Me.SIZE_ELITE & Me.CANCEL_COMMAND
            '    'ElseIf Me.font_index = 19 Then
            '    '    printer_content = Me.CANCEL_COMMAND & Me.SIZE_ELITE & Me.DRAFT_FONT & printer_content & Me.DRAFT_FONT & Me.SIZE_ELITE & Me.CANCEL_COMMAND

            'End If

            ''printer_content = printer_content & Me.CANCEL_CONDENSED & Me.CANCEL_COMMAND
            ''printer_content = printer_content & "\n -------------------------------------------------------------"

            'printer.Append(printer_content)

            printer.Append(printer_content)
            printer.PrintDocument()
            printer.Clear()

            ' delaying on printing and progressbar
            Me.btnPrint.Enabled = False
            'For i As Integer = 10 To Me.ProgressBar1.Maximum
            '    Me.ProgressBar1.Value = i
            '    Threading.Thread.Sleep(100)
            'Next
            'Me.ProgressBar1.Value = 0
            Me.btnPrint.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        'Me.font_index = Me.cbFont.SelectedIndex
        Me._printing_task()

        ' testing
        'For i As Integer = 0 To 19
        '    Me.font_index = i
        '    Me._printing_task()
        'Next

    End Sub

    Private Sub cbDocType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDocType.SelectedIndexChanged
        Me.clearPreview()
        Me.tbDocNumber.Clear()
    End Sub

    Private Sub fpassword_OkButtonClicked(sender As Object, e As EventArgs) Handles fpassword.OkButtonClicked
        If fpassword.AdminPassword = Me.adminPassword Then
            fpassword.DialogResult = DialogResult.OK
            fsetting.ShowDialog()
        Else
            MessageBox.Show("Password is not valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnTesting_Click(sender As Object, e As EventArgs) Handles btnTesting.Click
        MsgBox(Me.printer_data)
        'Try
        '    Dim printer As New ESC_POS_USB_NET.Printer.Printer(Me.printerName)
        '    printer.Append("&")
        '    printer.PrintDocument()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
End Class

