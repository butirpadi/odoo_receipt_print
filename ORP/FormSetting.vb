Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class FormSetting

    Dim myconn As SQLiteConnection
    Public Event DataSaved As EventHandler

    Property FontStyleIndex() As Integer
        Get
            Return Me.cbFontStyle.SelectedIndex
        End Get
        Set(value As Integer)
            Me.cbFontStyle.SelectedIndex = value
        End Set
    End Property

    Property ServerLocation() As String
        Get
            Return Me.tbServer.Text.Trim
        End Get
        Set(ByVal Value As String)
            Me.tbServer.Text = Value
        End Set
    End Property

    Property Username() As String
        Get
            Return Me.tbUsername.Text.Trim
        End Get
        Set(ByVal Value As String)
            Me.tbUsername.Text = Value
        End Set
    End Property

    Property Password() As String
        Get
            Return Me.tbPassword.Text.Trim
        End Get
        Set(ByVal Value As String)
            Me.tbPassword.Text = Value
        End Set
    End Property

    Property Database() As String
        Get
            Return Me.tbDatabase.Text.Trim
        End Get
        Set(ByVal Value As String)
            Me.tbDatabase.Text = Value
        End Set
    End Property

    Property DocumentTypeIndex() As Integer
        Get
            Return Me.cbDocType.SelectedIndex
        End Get
        Set(ByVal Value As Integer)
            Me.cbDocType.SelectedIndex = Value
        End Set
    End Property

    Property FontTypeIndex() As Integer
        Get
            Return Me.cbFont.SelectedIndex
        End Get
        Set(ByVal Value As Integer)
            Me.cbFont.SelectedIndex = Value
        End Set
    End Property

    Property PrinterName As String
        Get
            Return Me.tbPrinter.Text.Trim
        End Get
        Set(value As String)
            Me.tbPrinter.Text = value
        End Set
    End Property

    Property AdminPassword As String
        Get
            Return Me.tbAdminPassword.Text.Trim
        End Get
        Set(value As String)
            Me.tbAdminPassword.Text = value
        End Set
    End Property




    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' SAVE SETTING TO SQLITE DATABASE
        Dim query As String = "UPDATE orp_setting SET server_location = @server, database = @dbname, username = @username, password = @password, doc_type_idx= @doc_type_idx, printer_name = @printer_name, admin_password=@admin_password, font_type_index=@font_type_index, font_style_index=@font_style_index, is_testing=@is_testing"
        myconn = New SQLiteConnection(Form1.DBConnectionString)
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
                        .Add(New SQLiteParameter("@doc_type_idx", cbDocType.SelectedIndex))
                        .Add(New SQLiteParameter("@printer_name", tbPrinter.Text))
                        .Add(New SQLiteParameter("@admin_password", tbAdminPassword.Text))
                        .Add(New SQLiteParameter("@font_type_index", cbFont.SelectedIndex))
                        .Add(New SQLiteParameter("@font_style_index", cbFontStyle.SelectedIndex))
                        .Add(New SQLiteParameter("@is_testing", IIf(cbTesting.Checked, 1, 0)))
                    End With
                    'Dim dr As SQLiteDataReader
                    'dr = cmd.ExecuteReader()
                    cmd.ExecuteNonQuery()
                End Using
                'myconn.Close()
            End Using

            RaiseEvent DataSaved(Me, e)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error")
        End Try

        'Me.Close()
    End Sub

    Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' OPEN SETTING FROM DATABASE
        myconn = New SQLiteConnection(Form1.DBConnectionString)
        myconn.Open()
        Dim selectCmd As New SQLiteCommand(myconn)
        selectCmd.CommandText = "select * from orp_setting limit 1"
        Dim reader = selectCmd.ExecuteReader()

        ' show data to text box
        While reader.Read()
            tbServer.Text = reader("server_location").ToString
            tbUsername.Text = reader("username").ToString
            tbPassword.Text = reader("password").ToString
            tbDatabase.Text = reader("database").ToString
            tbPrinter.Text = reader("printer_name").ToString
            tbAdminPassword.Text = reader("admin_password").ToString

            If reader("doc_type_idx").ToString.Trim = "" Then
                cbDocType.SelectedIndex = -1
            Else
                cbDocType.SelectedIndex = CInt(reader("doc_type_idx").ToString.Trim)
            End If

            If reader("font_type_index").ToString.Trim = "" Then
                cbFont.SelectedIndex = -1
            Else
                cbFont.SelectedIndex = CInt(reader("font_type_index").ToString.Trim)
            End If

            If reader("font_style_index").ToString.Trim = "" Then
                cbFontStyle.SelectedIndex = -1
            Else
                cbFontStyle.SelectedIndex = CInt(reader("font_style_index").ToString.Trim)
            End If

            If reader("is_testing").ToString.Trim = "" Then
                cbTesting.Checked = False
            Else
                Dim Val As Integer = CInt(reader("is_testing").ToString.Trim)
                If Val = 0 Then
                    cbTesting.Checked = False
                Else
                    cbTesting.Checked = True
                End If
            End If

        End While

        reader.Close()
        myconn.Close()
    End Sub



    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            Dim session_id As String = OdooConnection.GetSessionId(tbServer.Text, tbDatabase.Text, tbUsername.Text, tbPassword.Text)
            If session_id <> "" Then
                MessageBox.Show("Connection Success", "Info")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error Connection")
        End Try

    End Sub

    Private Sub btnTestPrint_Click(sender As Object, e As EventArgs) Handles btnTestPrint.Click
        ' Testing printer 
        Try
            Dim aPrinter As New ESC_POS_USB_NET.Printer.Printer(Me.tbPrinter.Text)
            aPrinter.TestPrinter()
            aPrinter.PrintDocument()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class



