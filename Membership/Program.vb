Public Module Program
    Private running As Boolean = True
    Sub Main()
        Application.EnableVisualStyles()
        'Config Load.
        'ConfigManager.init()
        While running
            Dim test = New MainForm
            test.ShowDialog()
            Exit While
            Dim login = New LoginDialog
            Try
                If IsNothing(ConfigManager.currentUser) Then
                    login.ShowDialog()
                    If login.DialogResult = DialogResult.OK Then
                        ConfigManager.currentUser = login.user
                    ElseIf login.DialogResult = DialogResult.Cancel
                        quit()
                    End If
                Else
                    Application.Run(New ApplicationContext(New MainForm))
                End If

            Finally
                login.Dispose()
            End Try
        End While
    End Sub

    Public Sub logout()
        ConfigManager.currentUser = Nothing
        Application.Exit()
    End Sub

    Public Sub quit()
        Try
            ConfigManager.dataManager.dataStore.save()
            ConfigManager.dataManager.dataStore.close()
        Catch ex As Exception

        End Try
        running = False
        Application.Exit()
    End Sub
End Module
