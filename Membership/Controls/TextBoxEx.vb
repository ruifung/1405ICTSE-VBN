Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class TextBoxEx

    <Category("Appearance")>
    Public Property Placeholder As String = ""

    <Category("Appearance")>
    Public Property PlaceholderColor As Color = Color.Silver

    <Category("Appearance")>
    Public Property CustomBorderColor As Color = Color.Red

    <Category("Behavior")>
    Public Property CustomBorder As Boolean = False

    Private _phShow As Boolean = False

    <DllImport("User32.dll")>
    Private Shared Function GetWindowDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    Protected Overrides Sub WndProc(ByRef msg As Message)
        MyBase.WndProc(msg)
        If (_phShow Or Me.CustomBorder) AndAlso msg.Msg = &HF Then
            Dim hdc = GetWindowDC(Me.Handle)
            Using g = Graphics.FromHdc(hdc)
                Dim rect = New Rectangle(Me.ClientRectangle.Location, Me.ClientRectangle.Size)
                rect.X = CInt((Me.Width - Me.ClientRectangle.Width) / 2)
                rect.Y = CInt((Me.Height - Me.ClientRectangle.Height) / 2)
                If Me.CustomBorder Then
                    g.DrawRectangle(New Pen(Me.CustomBorderColor), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                End If
                If _phShow Then
                    g.FillRectangle(New SolidBrush(Me.BackColor), rect)
                    Dim sf = New StringFormat()
                    sf.Alignment = CType(Me.TextAlign, StringAlignment)
                    sf.LineAlignment = StringAlignment.Center
                    g.DrawString(Placeholder, Me.Font, New SolidBrush(PlaceholderColor), rect, sf)
                End If
            End Using
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        _phShow = (Me.Text.Length = 0 And Not Me.Focused)
        Me.Update()
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        _phShow = False
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        _phShow = Me.Text.Length = 0
        Me.Invalidate()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _phShow = Me.Text.Length = 0 And Not Me.Focused
        Me.Invalidate()
    End Sub
End Class
