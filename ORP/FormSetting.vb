Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json


Public Class FormSetting

    Dim mydata As DataTable
    Dim myconn As SQLiteConnection

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' SAVE SETTING TO SQLITE DATABASE
        Dim query As String = "UPDATE orp_setting SET server_location = @server, db_name = @dbname, username = @username, password = @password WHERE id = 1;"
        Try
            Using myconn
                myconn.Open()
                Using cmd As New SQLiteCommand(myconn)
                    cmd.CommandTimeout = 20
                    cmd.CommandText = query
                    With cmd.Parameters
                        .Add(New SQLiteParameter("@server", tbServer.Text))
                        .Add(New SQLiteParameter("@dbname", tbDatabase.Text))
                        .Add(New SQLiteParameter("@username", tbUsername.Text))
                        .Add(New SQLiteParameter("@password", tbPassword.Text))
                    End With
                    'Dim dr As SQLiteDataReader
                    'dr = cmd.ExecuteReader()
                    cmd.ExecuteNonQuery()
                End Using
                myconn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error")
        End Try

        Me.Close()
    End Sub

    Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' OPEN SETTING FROM DATABASE
        myconn = New SQLiteConnection("Data Source=" + Directory.GetCurrentDirectory() + "\orpsqlite.db" + "; Integrated Security=true")
        myconn.Open()
        Dim selectCmd As New SQLiteCommand(myconn)
        selectCmd.CommandText = "select * from orp_setting where id = 1"
        Dim reader = selectCmd.ExecuteReader()

        ' show data to text box
        While reader.Read()
            tbServer.Text = reader("server_location").ToString
            tbUsername.Text = reader("username").ToString
            tbPassword.Text = reader("password").ToString
            tbDatabase.Text = reader("db_name").ToString
        End While

        reader.Close()
        myconn.Close()
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Console.WriteLine("Testing connection .........")
        ' test connectino and get session


        'Dim NewData As New JSON_Post
        'NewData.username = "Service_Provider_Username"
        'NewData.password = "Service_Provider_Password"
        'NewData.client_id = "client_id"
        'NewData.client_secret = "client_secret"
        'NewData.grant_type = "password"

        'Dim PostString As String = JsonConvert.SerializeObject(NewData)
        'Dim byteArray As Byte() = Encoding.UTF8.GetBytes(PostString)
        'myReq.ContentLength = byteArray.Length

        Dim jsonData = "{
              ""jsonrpc"":     ""2.0"",
              ""method"": ""call"",
              ""id"": 1,
              ""params"": {
                ""login"": """ & tbUsername.Text & """,
                ""password"": """ & tbPassword.Text & """,
                ""db"": """ & tbDatabase.Text & """,
                ""context"": {}
              }
            }"

        Console.WriteLine("JSON Data")
        Console.WriteLine(jsonData)

        Dim postData = Encoding.ASCII.GetBytes(jsonData)

        Dim myReq As HttpWebRequest = HttpWebRequest.Create(tbServer.Text & "/web/session/authenticate")
        myReq.Method = "POST"
        myReq.ContentType = "application/json"
        myReq.ContentLength = postData.Length
        myReq.UserAgent = "Microsoft VB.Net"
        myReq.Timeout = 30000

        Try
            Using stream = myReq.GetRequestStream()
                stream.Write(postData, 0, postData.Length)
            End Using

            Dim response As HttpWebResponse = myReq.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim responseString = reader.ReadToEnd()

            'Dim ThisData As JObject = JsonConvert.DeserializeObject(Of JObject)(responseString)


            Console.WriteLine(responseString)
        Catch ex As WebException
            Console.WriteLine(ex.ToString)
        End Try




    End Sub
End Class