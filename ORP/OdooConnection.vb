Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Public Class OdooConnection

    Public Shared Function GetConnectionString(dbname As String, username As String, password As String)
        Dim jsonData = "{
              ""jsonrpc"":     ""2.0"",
              ""method"": ""call"",
              ""id"": 1,
              ""params"": {
                ""login"": """ & username & """,
                ""password"": """ & password & """,
                ""db"": """ & dbname & """,
                ""context"": {}
              }
            }"
        Return jsonData
    End Function


    Public Shared Function GetSessionId(server As String, dbname As String, username As String, password As String)
        ' test connectino and get session
        Dim jsonData = OdooConnection.GetConnectionString(dbname, username, password)

        Dim postData = Encoding.ASCII.GetBytes(jsonData)

        Dim myReq As HttpWebRequest = HttpWebRequest.Create(server & "/web/session/authenticate")
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
            Dim odooResp As OdooResponse = JsonConvert.DeserializeObject(Of OdooResponse)(responseString)


            'Dim i As Integer
            'While i < response.Headers.Count
            '    Console.WriteLine(ControlChars.Cr + "Header Name:{0}, Value :{1}", response.Headers.Keys(i), response.Headers(i))
            '    i = i + 1
            'End While

            ' extract session id from response headers
            Dim cookie_str As String = response.Headers.Get("Set-Cookie")
            Dim cookie_arr() As String = cookie_str.Split(";")

            ' Closing
            reader.Close()
            dataStream.Close()
            response.Close()
            myReq.Abort()

            Return cookie_arr(0)
            'Return odooResp.result.session_id

        Catch ex As WebException
            Console.WriteLine(ex.ToString)
        End Try

        Return False
    End Function

End Class
