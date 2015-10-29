Imports System.Configuration

Public Module ConfigManager
    Private appSettings As AppSettingsSection
    Private noneString = New None(Of String)
    Public dataManager As DataStoreManager

    ''' <summary>
    ''' Dictionary of all configuration keys.
    ''' Value is if the key must NEVER be missing.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property configurationKeys As Dictionary(Of String, Boolean) =
        New Dictionary(Of String, Boolean) From {
            {"DataMode", True},
            {"DataSource", True},
            {"DataAuth", True},
            {"DataUser", False},
            {"DataPass", False}
        }

    Public ReadOnly Property configuration As Dictionary(Of String, MaybeOption(Of String)) =
        New Dictionary(Of String, MaybeOption(Of String))


    Private Function loadSetting(key As String,
                         Optional verify As Predicate(Of String) = Nothing) As MaybeOption(Of String)
        Dim setting = MaybeOption.create(appSettings.Settings.Item(key)) _
            .map(Of String)(Function(x) x.Value)
        If Not IsNothing(verify) Then
            setting = setting.filter(verify)
        End If
        Return setting
    End Function

    Private Sub loadSettings()
        Try
            appSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings
        Catch ex As ConfigurationErrorsException
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Critical Error!")
            Program.quit()
        End Try

        For Each k In configuration.Keys
            Dim val = loadSetting(k)
            val.forEach(Sub(x) configuration(k) = val)
        Next
    End Sub

    Private Sub initData()
        Try

            If (configuration("DataMode").Equals("OLEDB-ACCESS")) Then
                'Initialize oledb-access

            Else
                'Handle invalid db type.
                Throw New InvalidOperationException("Invalid DB Type")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub init()

    End Sub
End Module
