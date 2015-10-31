Public Class DBConfigDialog
    Private Sub DSBtn_Click(sender As Object, e As EventArgs) Handles DSBtn.Click
        Dim dialog = New OpenFileDialog
        Dim result = dialog.ShowDialog()
        If result = DialogResult.OK Then

        End If
    End Sub
End Class