Imports System.Collections.Immutable
Imports System.Configuration

Public Module ConfigManager
    Private appSettings As AppSettingsSection
    Private noneString As None(Of String) = New None(Of String)
    Public dataManager As DataStoreManager

    ''' <summary>
    ''' Dictionary of all configuration keys.
    ''' Value is if the key must NEVER be missing.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property configurationKeys As ImmutableDictionary(Of String, Boolean) =
        ImmutableDictionary.CreateRange(
            New Dictionary(Of String, Boolean) From {
                {"DataMode", True},
                {"DataSource", True},
                {"DataAuth", True},
                {"DataUser", False},
                {"DataPass", False}
            }
        )
    Public ReadOnly Property configuration As Dictionary(Of String, MaybeOption(Of String)) =
        New Dictionary(Of String, MaybeOption(Of String))


    Private Function loadSetting(key As String,
                         Optional verify As Predicate(Of String) = Nothing) As MaybeOption(Of String)
        Dim setting = MaybeOption.create(appSettings.Settings.Item(key)) _
            .map(Function(x) x.Value)
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
            Dim dataMode = configuration("DataMode").getValue
            Dim dataAuth = CBool(configuration("DataAuth").getValue)
            If dataMode.Contains("OLEDB") Then
                Dim csb = New OleDb.OleDbConnectionStringBuilder
                csb.Add("Data Source", configuration("DataSource").getValue)
                Select Case configuration("DataMode").getValue
                    Case "OLEDB-ACCESS-JET"
                        csb.Add("Provider", "Microsoft.Jet.OLEDB.4.0")
                    Case "OLEDB-ACCESS-ACE"
                        csb.Add("Provider", "Microsoft.ACE.OLEDB.12.0")
                    Case Else
                        Throw New Exception
                End Select
                'TODO: Add actual IDataStore implementation.
                dataManager = New DataStoreManager(Nothing, csb)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub init()
    End Sub
End Module
