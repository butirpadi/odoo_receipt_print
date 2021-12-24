Imports System.Windows.Forms

Public Class FormPassword

    Public Event OkButtonClicked As EventHandler

    Property AdminPassword As String
        Get
            Return Me.tbInputPassword.Text
        End Get
        Set(value As String)
            Me.tbInputPassword.Text = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.None
        RaiseEvent OkButtonClicked(Me, e)
        'Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
