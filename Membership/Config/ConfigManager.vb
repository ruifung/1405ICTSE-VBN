Imports System.Configuration

Public Module ConfigManager
    Private cfg As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    Private appSettings As AppSettingsSection = cfg.AppSettings
    Public dataManager As DataManager


    Sub init()
        Try
            Dim dataMode As String = appSettings.Settings.Item("DataMode").Value.ToUpper
            If (dataMode.Equals("OLEDB-ACCESS")) Then
                'Initialize oledb-access

            Else
                'Handle invalid db type.
                Throw New InvalidOperationException("Invalid DB Type")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Module
