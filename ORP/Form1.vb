Public Class Form1
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
        Dim fsetting As New FormSetting
        fsetting.ShowDialog()

    End Sub
End Class

