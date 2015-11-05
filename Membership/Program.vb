Imports Membership.config

Public Module Program
    Private running As Boolean = True
    Private context As ApplicationContext

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
            context = New ApplicationContext(New MainForm)
            Dim login = New LoginDialog
            Try
                If IsNothing(currentUser) Then
                    Dim result = login.ShowDialog()
                    If result = DialogResult.OK Then
                        currentUser = login.user
                    ElseIf result = DialogResult.Cancel
                        quit()
                    End If
                End If
            Finally
                login.Dispose()
            End Try
            If running Then
                Application.Run(context)
                context.Dispose()
            End If
        End While
    End Sub

    Public Sub logout()
        currentUser = Nothing
        Dim list = New List(Of Form)
        For Each x As Form In Application.OpenForms
            list.Add(x)
        Next
        list.ForEach(Sub(x) x.Close())
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
