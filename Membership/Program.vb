Imports Membership.config

Public Module Program
    Private running As Boolean = True

    Public ReadOnly Property isRunning As Boolean
        Get
            Return running
        End Get
    End Property


    Sub Main()
        Application.EnableVisualStyles()
        'Config Load.
        init()
        save()
        'First time run stuff
        If running AndAlso dataManager.userManager.count = 0 Then
            Dim initUserDialog = New InitialUserDialog
            Dim result = initUserDialog.ShowDialog
            If result = DialogResult.OK Then
                Dim newUser = New PlainUser With {
                    .userName = initUserDialog.username,
                    .password = initUserDialog.password,
                    .accessLevel = 1
                }
                If dataManager.userManager.addEntry(newUser).isEmpty Then
                    quit()
                End If
            Else
                quit()
            End If
        End If
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
        save()
    End Sub
End Module
