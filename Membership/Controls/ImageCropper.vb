Imports System.ComponentModel
Imports System.IO

Public Class ImageCropper

    Private _cropsize As Size = New Size(120, 160)
    <Category("Data")>
    Public Property CorpSize As Size
        Get
            Return _cropsize
        End Get
        Set(value As Size)
            _cropsize = value
            Me.Invalidate()
        End Set
    End Property

    Private _imgcrop As Image = Nothing
    Public Property ImageToCrop As Image
        Get
            Return _imgcrop
        End Get
        Set(value As Image)
            _imgcrop = value
            _imgscale = 100
            btnPercent.Text = String.Format("{0}%", _imgscale)
            If value IsNot Nothing Then
                _imgrect.X = CInt((Me.Width - value.Width) / 2)
                _imgrect.Y = CInt((Me.Height - value.Height) / 2)
                _imgrect.Size = value.Size
            End If
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property CroppedImage As Image
        Get
            If ImageToCrop Is Nothing Then Return Nothing
            Dim si As Image = New Bitmap(_imgrect.Width, _imgrect.Height)
            Dim rect1 As Rectangle = New Rectangle
            Dim rect2 As Rectangle = New Rectangle
            Using g As Graphics = Graphics.FromImage(si)
                rect1 = New Rectangle(New Point(0, 0), _imgrect.Size)
                rect2.Size = ImageToCrop.Size
                rect2.Location = New Point(0, 0)
                rect2.Size = ImageToCrop.Size
                g.DrawImage(ImageToCrop, rect1, rect2, GraphicsUnit.Pixel)
            End Using
            Dim ci As Image = New Bitmap(_cropsize.Width, _cropsize.Height)
            Using g As Graphics = Graphics.FromImage(ci)
                rect1 = New Rectangle(New Point(0, 0), _cropsize)
                rect2.Size = _cropsize
                rect2.X = _imgrect.X - CInt((Me.Width - rect2.Width) / 2)
                rect2.Y = _imgrect.Y - CInt((Me.Height - rect2.Height) / 2)
                g.DrawImage(si, rect1, rect2, GraphicsUnit.Pixel)
            End Using
            Return ci
        End Get
    End Property

    Private _imgrect As Rectangle
    Private _imgscale As Integer = 100

    Private _grabbing As Boolean = False
    Private _grabpos As Point = New Point(0, 0)

    Private curs(1) As Cursor
    Public Sub New()
        InitializeComponent()
        Dim ms As MemoryStream = New MemoryStream(My.Resources.grab)
        curs(0) = New Cursor(ms)
        ms.Close()
        ms = New MemoryStream(My.Resources.grabbing)
        curs(1) = New Cursor(ms)
        ms.Close()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rect As New Rectangle()
        If _imgcrop IsNot Nothing Then
            rect.Size = _imgcrop.Size
            rect.Location = New Point(0, 0)
            e.Graphics.DrawImage(_imgcrop, _imgrect, rect, GraphicsUnit.Pixel)
        End If
        rect.Size = _cropsize
        rect.X = CInt((Me.Width - rect.Width) / 2)
        rect.Y = CInt((Me.Height - rect.Height) / 2)
        Dim _pen As Pen = New Pen(Color.White, 2)
        e.Graphics.DrawRectangle(_pen, rect)
        _pen.Color = Color.Black
        _pen.DashStyle = Drawing2D.DashStyle.Dot
        e.Graphics.DrawRectangle(_pen, rect)
    End Sub

    Private Sub ImageCropper_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Me.Cursor = If(inRect(e.Location), If(_grabbing, curs(1), curs(0)), Cursors.Default)
        If _grabbing Then
            _imgrect.X += e.X - _grabpos.X
            _imgrect.Y += e.Y - _grabpos.Y
            _grabpos = e.Location
            Me.Invalidate()
        End If
    End Sub

    Private Sub ImageCropper_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If inRect(e.Location) Then
            _grabpos = e.Location
            Me.Cursor = curs(1)
            _grabbing = True
        End If
    End Sub

    Private Sub ImageCropper_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If _grabbing Then
            _grabbing = False
            Me.Cursor = curs(0)
        End If
    End Sub

    Private Function inRect(pos As Point) As Boolean
        Return pos.X >= _imgrect.X And pos.X <= _imgrect.Right And
               pos.Y >= _imgrect.Top And pos.Y <= _imgrect.Bottom
    End Function

    Private Sub ImageCropper_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        _imgrect.X = CInt((Me.Width - _imgrect.Width) / 2)
        _imgrect.Y = CInt((Me.Height - _imgrect.Height) / 2)
        Me.Invalidate()
    End Sub

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        If _imgscale < 300 Then _imgscale += 10
        rescale()
    End Sub

    Private Sub btnPercent_Click(sender As Object, e As EventArgs) Handles btnPercent.Click
        _imgscale = 100
        rescale()
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        If _imgscale > 50 Then _imgscale -= 10
        rescale()
    End Sub

    Private Sub ImageCropper_Wheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        _imgscale += If(e.Delta > 0, 5, -5)
        rescale()
    End Sub

    Private Sub rescale()
        If _imgscale > 300 Then _imgscale = 300
        If _imgscale < 50 Then _imgscale = 50
        btnPercent.Text = String.Format("{0}%", _imgscale)
        If ImageToCrop Is Nothing Then Return
        Dim rect As Rectangle = New Rectangle
        rect.Width = CInt(Math.Round(ImageToCrop.Width * _imgscale / 100, 0))
        rect.Height = CInt(Math.Round(ImageToCrop.Height * _imgscale / 100, 0))
        rect.X = _imgrect.X + CInt((_imgrect.Width - rect.Width) / 2)
        rect.Y = _imgrect.Y + CInt((_imgrect.Height - rect.Height) / 2)
        _imgrect = rect
        Me.Invalidate()
    End Sub
End Class
