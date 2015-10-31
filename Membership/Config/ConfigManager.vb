Imports System.Collections.Immutable
Imports System.Configuration

Public Module ConfigManager
    Private appSettings As AppSettingsSection
    Private noneString As None(Of String) = New None(Of String)
    Public dataManager As DataStoreManager
    Public currentUser As IUser

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
                {"DataUser", True},
                {"DataPass", True}
            }
        )
    Public ReadOnly Property configuration As Dictionary(Of String, MaybeOption(Of String)) =
        New Dictionary(Of String, MaybeOption(Of String))


    Private Function loadSetting(key As String,
                         Optional verify As Predicate(Of String) = Nothing) As MaybeOption(Of String)
        Dim setting = MaybeOption.create(appSettings.Settings.Item(key)) _
            .map(Function(x) x.Value)
        Dim maybeVerify = MaybeOption.create(verify)
        If If(configurationKeys(key), setting.isDefined, True) AndAlso
                maybeVerify.forAll(Function(x) setting.forAll(Function(y) x(y))) Then
            Return setting
        Else
            Throw New InvalidSettingException(key)
        End If
    End Function

    Private Sub loadSettings()
        Dim errorFlagsB = ImmutableHashSet.CreateBuilder(Of ErrorFlags)
        For Each k In configuration.Keys
            Try
                Dim val = loadSetting(k)
                val.forEach(Sub(x) configuration(k) = val)
            Catch ex As InvalidSettingException
                'Load default setting for key?
                Select Case ex.settingKey
                    Case "DataMode"
                        errorFlagsB.Add(ErrorFlags.DATABASE_CONFIG)
                    Case "DataSource"
                        errorFlagsB.Add(ErrorFlags.DATABASE_CONFIG)
                    Case "DataAuth"
                        errorFlagsB.Add(ErrorFlags.DATABASE_CONFIG)
                    Case "DataUser"
                        errorFlagsB.Add(ErrorFlags.DATABASE_CONFIG)
                    Case "DataPass"
                        errorFlagsB.Add(ErrorFlags.DATABASE_CONFIG)
                End Select
                configuration(k) = New None(Of String)
                Continue For
            End Try
        Next
        Dim flags = errorFlagsB.ToImmutableHashSet
        With flags
            If .Contains(ErrorFlags.DATABASE_CONFIG) Then
                Dim dbConfig = New DBConfigDialog
            End If
        End With
    End Sub

    Private Sub initData()
        Try
            Dim dataMode = configuration("DataMode").getValue
            Dim dataAuth = CBool(configuration("DataAuth").getValue)
            If dataMode.Contains("OLEDB") Then
                Dim csb = New OleDb.OleDbConnectionStringBuilder
                csb.Add("Data Source", configuration("DataSource").getValue)
                Select Case configuration("DataMode").getValue
                    Case DBModes.OLEDB_ACCESS_JET.ToString
                        csb.Add("Provider", "Microsoft.Jet.OLEDB.4.0")
                    Case DBModes.OLEDB_ACCESS_ACE.ToString
                        csb.Add("Provider", "Microsoft.ACE.OLEDB.12.0")
                    Case Else
                        Throw New Exception
                End Select
                'TODO: Add actual IDataStore implementation.
                dataManager = New DataStoreManager(New DB.DataStore, csb)
            End If
        Catch ex As Exception
            Throw New DataSourceException
        End Try
    End Sub

    Sub init()
        Try
            appSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings
        Catch ex As ConfigurationErrorsException
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Critical Error!")
            Program.quit()
        End Try

        loadSettings()
        initData()
    End Sub

    Public Enum DBModes
        OLEDB_ACCESS_JET
        OLEDB_ACCESS_ACE
    End Enum

    Private Enum ErrorFlags
        DATABASE_CONFIG
    End Enum
End Module