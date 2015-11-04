Imports System.Collections.Immutable
Imports System.Configuration
Imports Membership.Exceptions
Namespace config
    Public Module ConfigManager
        Private appSettings As AppSettingsSection
        Private noneString As None(Of String) = New None(Of String)
        Public dataManager As DataStoreManager
        Public currentUser As IUser

        Private dataInit As Boolean

        ''' <summary>
        ''' Dictionary of all configuration keys.
        ''' Value is if the key must NEVER be missing.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property configurationKeys As ImmutableDictionary(Of String, Func(Of String, Boolean)) =
        ImmutableDictionary.CreateRange(
            New Dictionary(Of String, Func(Of String, Boolean)) From {
                {"DataMode", Function(x) getDSTypes.Exists(Function(y) y.type.Equals(x))},
                {"DataSource", Function(x) (Not IsNothing(x)) AndAlso x.Length > 0},
                {"DataAuth", Function(x)
                                 Dim temp As Boolean
                                 Return Boolean.TryParse(x, temp)
                             End Function},
                {"DataUser", Function(x)
                                 Dim temp As Boolean
                                 Dim required = If(Boolean.TryParse(configuration("DataAuth").orNothing, temp), temp, False)
                                 If required Then
                                     Return Not IsNothing(x)
                                 Else
                                     Return False
                                 End If
                             End Function},
                {"DataPass", Function(x)
                                 Dim temp As Boolean
                                 Dim required = If(Boolean.TryParse(configuration("DataAuth").orNothing, temp), temp, False)
                                 If required Then
                                     Return Not IsNothing(x)
                                 Else
                                     Return False
                                 End If
                             End Function}
            }
        )
        Public ReadOnly Property configuration As Dictionary(Of String, MaybeOption(Of String)) =
        New Dictionary(Of String, MaybeOption(Of String))


        Private Function loadSetting(key As String,
                         Optional verify As Predicate(Of String) = Nothing) As MaybeOption(Of String)
            Dim setting = MaybeOption.create(appSettings.Settings.Item(key)) _
            .map(Function(x) x.Value)
            Dim maybeVerify = MaybeOption.create(configurationKeys(key))
            If maybeVerify.forAll(Function(x) x(setting.orNothing)) Then
                Return setting
            Else
                Throw New InvalidSettingException(key)
            End If
        End Function

        Private Function loadSettings() As ImmutableHashSet(Of ErrorFlags)
            Dim errorFlagsB = ImmutableHashSet.CreateBuilder(Of ErrorFlags)
            For Each k In configurationKeys.Keys
                Dim val As MaybeOption(Of String)
                Try
                    val = loadSetting(k)
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
                    val = New None(Of String)
                End Try
                configuration.Add(k, val)
            Next
            Return errorFlagsB.ToImmutableHashSet
        End Function



        Sub init()
            Try
                appSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings
            Catch ex As ConfigurationErrorsException
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Critical Error!")
                quit()
            End Try
            Dim flags = New HashSet(Of ErrorFlags)(loadSettings())

            While isRunning AndAlso Not (dataInit)
                If Not dataInit AndAlso Not flags.Contains(ErrorFlags.DATABASE_CONFIG) Then
                    Try
                        initData()
                        dataInit = True
                    Catch ex As DataSourceException
                        flags.Add(ErrorFlags.DATABASE_CONFIG)
                        Console.Write(ex.ToString)
                    End Try
                End If

                With flags
                    If .Contains(ErrorFlags.DATABASE_CONFIG) Then
                        Dim dbConfig = New DBConfigDialog With {
                            .DSTypes = getDSTypes(),
                            .DSType = configuration("DataMode").orNothing,
                            .DSPath = configuration("DataSource").orNothing,
                            .DSUser = configuration("DataUser").orNothing,
                            .DSPass = configuration("DataPass").orNothing
                        }
                        Boolean.TryParse(configuration("DataAuth").orNothing, dbConfig.DSAuth)
                        Try
                            Dim result = dbConfig.ShowDialog
                            If result = DialogResult.OK Then
                                With dbConfig
                                    configuration("DataMode") = create(.DSType)
                                    configuration("DataSource") = create(.DSPath)
                                    configuration("DataAuth") = create(.DSAuth.ToString)
                                    configuration("DataUser") = create(.DSUser)
                                    configuration("DataPass") = create(.DSPass)
                                    flags.Remove(ErrorFlags.DATABASE_CONFIG)
                                End With
                            Else
                                quit()
                            End If
                        Finally
                            dbConfig.Dispose()
                        End Try
                    End If

                End With
            End While
        End Sub



        Private Enum ErrorFlags
            DATABASE_CONFIG
        End Enum
    End Module
End Namespace
