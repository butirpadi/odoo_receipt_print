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
    Private session_id As String
    Private printer_data As String

    Public Shared DBConnectionString As String = "Data Source=" + Directory.GetCurrentDirectory() + "\orpsqlite.sqlite" + "; Integrated Security=true"

    Private Sub fsetting_on_datasaved(sender As Object, e As EventArgs) Handles fsetting.DataSaved
        Console.WriteLine("Data Setting Saved -----------------------------")
        Me.doc_type_idx = fsetting.DocumentTypeIndex
        Me.cbDocType.SelectedIndex = fsetting.DocumentTypeIndex
        Me.server_location = fsetting.ServerLocation
        Me.username = fsetting.Username
        Me.password = fsetting.Password
        Me.dbname = fsetting.Database
        Me.adminPassword = fsetting.AdminPassword
        Me.printerName = fsetting.PrinterName
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
                    ""number"": """ & tbDocNumber.Text & """
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

                Console.WriteLine(responseString)

                If responseString.ToLower.Contains("error") Then
                    MessageBox.Show("500 Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.toggleComponent(True)
                Else


                    Dim invoiceJobj As JObject = JObject.Parse(responseString)
                    Dim resultsObj As JObject = invoiceJobj("result")
                    'Dim invoiceLines As JArray = resultsObj("invoice_lines")

                    Console.WriteLine("Invoice Data")
                    Console.WriteLine(resultsObj("number"))

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
                .CommandText = "CREATE TABLE IF NOT EXISTS orp_setting (id INTEGER NOT NULL, server_location TEXT, username TEXT, password TEXT, database TEXT, printer_name TEXT,admin_password TEXT, doc_type_idx INTEGER,PRIMARY KEY(id AUTOINCREMENT) )"
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

            Dim index As Integer = reader.GetOrdinal("doc_type_idx")
            If Not reader.IsDBNull(index) Then
                Me.doc_type_idx = CInt(reader("doc_type_idx"))
            Else
                Me.doc_type_idx = -1
            End If
            Me.cbDocType.SelectedIndex = Me.doc_type_idx
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim printer As New ESC_POS_USB_NET.Printer.Printer(Me.printerName)
            printer.Append(Chr(27) & Chr(33) & Chr(4) & Me.printer_data & Chr(27) & Chr(33) & Chr(4))
            printer.PrintDocument()

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

    Private Sub cbDocType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDocType.SelectedIndexChanged
        Me.clearPreview()
        Me.tbDocNumber.Clear()
    End Sub

    Private Sub fpassword_OkButtonClicked(sender As Object, e As EventArgs) Handles fpassword.OkButtonClicked
        Console.WriteLine(fpassword.AdminPassword)
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

