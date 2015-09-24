Public Module Program
    Private running = True
    Private exitHandler As EventHandler = AddressOf onApplicationClosing
    Sub Main()
        AddHandler Application.ApplicationExit, exitHandler
        Application.EnableVisualStyles()
        While running
            If Application.OpenForms.Count = 0 Then
                Dim form = New LoginForm
                Application.Run(New ProgramContext(New LoginForm))
            End If
        End While
    End Sub


    Private Sub onApplicationClosing(sender As Object, e As EventArgs)
        RemoveHandler Application.ApplicationExit, exitHandler
        running = False
    End Sub

    Private Class ProgramContext
        Inherits ApplicationContext

        Public Sub New(form As Form)
            Me.MainForm = form
            Dim form1 = New LoginForm
            form1.Show()
            Dim form2 = New LoginForm
            form2.Show()
        End Sub

        Protected Overrides Sub OnMainFormClosed(sender As Object, e As EventArgs)
        End Sub
    End Class
End Module
