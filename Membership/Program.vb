Public Module Program
    Private running = True
    Sub Main()
        Application.EnableVisualStyles()
        'Config Load.
        ConfigManager.init()
        ConfigManager.load()
        ConfigManager.save()
        While running
            Dim login = New LoginDialog
            Try
                login.ShowDialog()
                If login.DialogResult = DialogResult.OK Then
                    Application.Run(New ApplicationContext(New MainForm))
                ElseIf login.DialogResult = DialogResult.Cancel
                    quit()
                End If
            Finally
                login.Dispose()
            End Try
        End While
    End Sub


    Public Sub quit()
        ConfigManager.save()
        running = False
        Application.Exit()
    End Sub
End Module
