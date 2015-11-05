Imports System.Collections.Immutable
Imports System.Configuration
Imports Membership.Exceptions
Imports Newtonsoft.Json
Imports System.IO
Imports System.Text

Namespace config
    Public Module ConfigManager
        Private configPath As String = String.Concat(Path.GetDirectoryName(GetType(Program).Assembly.Location), Path.DirectorySeparatorChar, "MembershipProgramConfig.json")
        Private config As ProgramConfig
        Private noneString As None(Of String) = New None(Of String)
        Public dataManager As DataStoreManager
        Public currentUser As IUser

        Private dataInit As Boolean

        Public ReadOnly Property configuration As ProgramConfig
            Get
                Return New ProgramConfig With {
                    .DataSourceType = config.DataSourceType,
                    .DataSourcePath = config.DataSourcePath,
                    .DataSourceAuth = config.DataSourceAuth,
                    .DataSourceUser = config.DataSourceUser,
                    .DataSourcePass = config.DataSourcePass
                }
            End Get
        End Property

        Private Function loadSettings() As ImmutableHashSet(Of ErrorFlags)
            Dim errorFlagsB = ImmutableHashSet.CreateBuilder(Of ErrorFlags)
            If File.Exists(configPath) Then
                Dim configText = File.ReadAllText(configPath)
                configText = Encoding.UTF8.GetString(Convert.FromBase64String(configText))
                config = DirectCast(JsonConvert.DeserializeObject(configText, GetType(ProgramConfig)), ProgramConfig)

                'validate
                If Not (config.validateDataSource AndAlso
                        config.validateDataPath AndAlso
                        config.validateDataUser AndAlso
                        config.validateDataPass) Then
                    errorFlagsB.Add(ErrorFlags.DATABASE_CONFIG)
                End If
            Else
                config = New ProgramConfig
                errorFlagsB.Add(ErrorFlags.NEW_CONFIG)
            End If

            Return errorFlagsB.ToImmutableHashSet
        End Function



        Sub init()
            Dim flags = New HashSet(Of ErrorFlags)(loadSettings())

            While isRunning AndAlso Not (dataInit)
                If Not flags.Contains(ErrorFlags.NEW_CONFIG) Then
                    If Not dataInit AndAlso Not flags.Contains(ErrorFlags.DATABASE_CONFIG) Then
                        Try
                            initData()
                            dataInit = True
                        Catch ex As DataSourceException
                            flags.Add(ErrorFlags.DATABASE_CONFIG)
                            MsgBox(String.Format("Database Error: {0} {1}", ex.Message, Util.exec(ex.InnerException, Function(x) x.ToString)))
                            Console.Write(ex.ToString)
                        End Try
                    End If
                End If
                With flags
                    If .Contains(ErrorFlags.DATABASE_CONFIG) OrElse .Contains(ErrorFlags.NEW_CONFIG) Then
                        Dim dbConfig = New DBConfigDialog With {
                            .DSTypes = supportedDataSources,
                            .DSType = config.DataSourceType,
                            .DSPath = config.DataSourcePath,
                            .DSAuth = config.DataSourceAuth,
                            .DSUser = config.DataSourceUser,
                            .DSPass = config.DataSourcePass
                        }
                        Try
                            Dim result = dbConfig.ShowDialog
                            If result = DialogResult.OK Then
                                With dbConfig
                                    config.DataSourceType = .DSType
                                    config.DataSourcePath = .DSPath
                                    config.DataSourceAuth = .DSAuth
                                    config.DataSourceUser = .DSUser
                                    config.DataSourcePass = .DSPass
                                    flags.Remove(ErrorFlags.DATABASE_CONFIG)
                                End With
                            Else
                                quit()
                            End If
                        Finally
                            dbConfig.Dispose()
                        End Try
                    End If
                    flags.Remove(ErrorFlags.NEW_CONFIG)
                End With
            End While
        End Sub

        Public Sub save()
            Dim outString = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(config)))
            File.WriteAllText(configPath, outString)
        End Sub

        Private Enum ErrorFlags
            NEW_CONFIG
            DATABASE_CONFIG
        End Enum
    End Module
End Namespace
