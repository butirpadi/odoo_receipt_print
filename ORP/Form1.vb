Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Dim WithEvents fsetting As New FormSetting

    Private Sub fsetting_on_datasaved(sender As Object, e As EventArgs) Handles fsetting.DataSaved
        Console.WriteLine("Data Setting Saved -----------------------------")
        Me.doc_type_idx = fsetting.DocumentTypeIndex
        Me.cbDocType.SelectedIndex = fsetting.DocumentTypeIndex
        Me.server_location = fsetting.ServerLocation
        Me.username = fsetting.Username
        Me.password = fsetting.Password
        Me.dbname = fsetting.Database
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

        fsetting.ShowDialog()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Console.WriteLine("Begin connection ......")
            Dim session_id As String = OdooConnection.GetSessionId(Me.server_location, Me.dbname, Me.username, Me.password)
            Dim jsonData = OdooConnection.GetConnectionString(Me.dbname, Me.username, Me.password)

            'Dim postDataAccountInvoice = "{
            '                  ""jsonrpc"":  ""2.0"",
            '                  ""method"": ""call"",
            '                  ""id"": 1,
            '                  ""params"": {
            '                    ""model"": ""account.invoice"",
            '                    ""domain"": [[""number"", ""="", """ & tbDocNumber.Text & """]]
            '                  }
            '                }"
            Dim postDataAccountInvoice = "{
                  ""jsonrpc"":   ""2.0"",
                  ""method"": ""call"",
                  ""id"": 1,
                  ""params"": {
                    ""number"": """ & tbDocNumber.Text & """
                  }
                }"

            Console.WriteLine("Session ID : " & session_id)
            If session_id <> "" Then
                Console.WriteLine("Begin http request ......")
                ' search document 
                Dim postData = Encoding.ASCII.GetBytes(postDataAccountInvoice)

                Dim myReq As HttpWebRequest = HttpWebRequest.Create(Me.server_location & "/get/customer/invoice")
                'Dim myReq As HttpWebRequest = HttpWebRequest.Create(Me.server_location & "/web/dataset/search_read")

                myReq.Method = "POST"
                myReq.ContentType = "application/json"
                myReq.ContentLength = postData.Length
                myReq.UserAgent = "Microsoft VB.Net"
                myReq.Timeout = 30000
                myReq.Headers.Add("Cookie", session_id)

                Try
                    Using stream = myReq.GetRequestStream()
                        stream.Write(postData, 0, postData.Length)
                    End Using

                    Dim response As HttpWebResponse = myReq.GetResponse()
                    Dim dataStream As Stream = response.GetResponseStream()
                    Dim reader As StreamReader = New StreamReader(dataStream)
                    Dim responseString = reader.ReadToEnd()

                    Dim invoiceJobj As JObject = JObject.Parse(responseString)
                    Dim resultsObj As JObject = invoiceJobj("result")
                    Dim invoiceLines As JArray = resultsObj("invoice_lines")

                    For Each line As JObject In invoiceLines
                        Console.WriteLine(line("no"))
                        Console.WriteLine(line("code"))
                        Console.WriteLine(line("name"))
                        Console.WriteLine(line("qty"))
                        Console.WriteLine(line("uom"))
                        Console.WriteLine(line("price_unit"))
                        Console.WriteLine(line("disc"))
                        Console.WriteLine(line("subtotal"))
                        Console.WriteLine("---------------------------------------------")
                    Next

                Catch ex As WebException
                    Console.WriteLine(ex.ToString)
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error Connection")
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

    Private server_location As String
    Private dbname As String
    Private username As String
    Private password As String
    Private doc_type_idx As Integer = -1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' load credential from sqlite 
        Dim myconn As New SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "\orpsqlite.db" + "; Integrated Security=true")
        myconn.Open()
        Dim selectCmd As New SQLiteCommand(myconn)
        selectCmd.CommandText = "select * from orp_setting where id = 1"
        Dim reader = selectCmd.ExecuteReader()

        ' show data to text box
        While reader.Read()
            Me.server_location = reader("server_location").ToString
            Me.username = reader("username").ToString
            Me.password = reader("password").ToString
            Me.dbname = reader("db_name").ToString

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
End Class

