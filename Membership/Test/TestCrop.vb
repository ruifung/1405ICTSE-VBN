Public Class TestCrop
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog
        dialog.ShowDialog()
        PictureBox1.Image = Image.FromFile(dialog.FileName)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim dialog As CropImageDialog = New CropImageDialog
        dialog.ImageToCrop = PictureBox1.Image
        dialog.ShowDialog()
        PictureBox2.Image = dialog.CropResult
    End Sub
End Class