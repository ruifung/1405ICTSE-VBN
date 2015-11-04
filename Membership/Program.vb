Imports Membership.config

Public Module Program
    Private running As Boolean = True

    ReadOnly Property isRunning As Boolean
        Get
            Return running
        End Get
    End Property


    Sub Main()
        Application.EnableVisualStyles()
        'Config Load.
        init()
        While running
            Dim login = New LoginDialog
            Try
                If IsNothing(currentUser) Then
                    login.ShowDialog()
                    If login.DialogResult = DialogResult.OK Then
                        currentUser = login.user
                    ElseIf login.DialogResult = DialogResult.Cancel
                        quit()
                    End If
                End If
            Finally
                login.Dispose()
            End Try
            If running Then
                Application.Run(New ApplicationContext(New MainForm))
            End If
        End While
    End Sub

    Public Sub logout()
        currentUser = Nothing
        Application.Exit()
    End Sub

    Public Sub quit()
        Try
            dataManager.dataStore.save()
            dataManager.dataStore.close()
        Catch ex As Exception

        End Try
        running = False
        Application.Exit()
    End Sub
End Module
