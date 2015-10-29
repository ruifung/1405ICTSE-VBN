﻿Public Module Program
    Private running As Boolean = True
    Sub Main()
        Application.EnableVisualStyles()
        'Config Load.
        ConfigManager.init()
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
        Try
            ConfigManager.dataManager.dataStore.save()
            ConfigManager.dataManager.dataStore.close()
        Catch ex As Exception

        End Try
        running = False
        Application.Exit()
    End Sub
End Module
