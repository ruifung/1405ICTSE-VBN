Public Class CropImageDialog
    Public Property CropSize As Size
        Get
            Return cropper.CorpSize
        End Get
        Set(value As Size)
            cropper.CorpSize = value
        End Set
    End Property
    Public Property ImageToCrop As Image
        Get
            Return cropper.ImageToCrop
        End Get
        Set(value As Image)
            cropper.ImageToCrop = value
        End Set
    End Property
    Private _cropped As Image = Nothing
    Public ReadOnly Property CropResult As Image
        Get
            Return _cropped
        End Get
    End Property
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        _cropped = cropper.CroppedImage
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class