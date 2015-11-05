Option Infer On
Imports Membership.API.config.data

Namespace config
    Module DataSourceConfig
        Private dsList As List(Of DSType) = New List(Of DSType) From {
            New DSType With {
                .type = "OLEDB_ACCESS_JET",
                .display = "Microsoft Access JET Database Engine",
                .authMode = DSAuthMode.PASSWORDONLY,
                .isFileBased = True,
                .initializer = Function(x)
                                   Dim csb = New OleDb.OleDbConnectionStringBuilder
                                   csb.Add("Data Source", x.DataSource)
                                   csb.Add("Provider", "Microsoft.Jet.OLEDB.4.0")
                                   If x.Auth Then
                                       csb.Add("Jet OLEDB:Database Password", x.Pass)
                                   End If
                                   Return New DataStoreManager(New Database.DataStore, csb)
                               End Function
            },
            New DSType With {
                .type = "OLEDB_ACCESS_ACE",
                .display = "Microsoft Access ACE Database Engine",
                .authMode = DSAuthMode.PASSWORDONLY,
                .isFileBased = True,
                .initializer = Function(x)
                                   Dim csb = New OleDb.OleDbConnectionStringBuilder
                                   csb.Add("Data Source", x.DataSource)
                                   csb.Add("Provider", "Microsoft.ACE.OLEDB.12.0")
                                   If x.Auth Then
                                       csb.Add("Jet OLEDB:Database Password", x.Pass)
                                   End If
                                   Return New DataStoreManager(New Database.DataStore, csb)
                               End Function
            }
        }

        ReadOnly Property supportedDataSources As List(Of DSType)
            Get
                'So it cannot be modified externally.
                Return New List(Of DSType)(dsList)
            End Get
        End Property

        Public Sub registerDSType(type As DSType)
            With type
                If .type Is Nothing OrElse .initializer Is Nothing Then
                    Throw New ArgumentException("type or initializer property cannot be null!")
                End If
                If .display Is Nothing OrElse .display.Length <= 0 Then
                    .display = .type
                End If
            End With
            dsList.Add(type)
        End Sub

        Friend Sub initData()
            Dim dataMode = configuration("DataMode").getOrAlt(String.Empty)
            Dim dataAuth As Boolean = False
            Boolean.TryParse(configuration("DataAuth").orNothing, dataAuth)
            Dim DSConfig = New DSConfigItem With {
                .DataSource = configuration("DataSource").getOrAlt(String.Empty),
                .Auth = dataAuth,
                .User = configuration("DataUser").getOrAlt(String.Empty),
                .Pass = configuration("DataPass").getOrAlt(String.Empty)
            }
            Dim type = dsList.Find(Function(x) x.type.ToLower.Equals(dataMode.ToLower))
            If type IsNot Nothing Then
                dataManager = type.initializer()(DSConfig)
            Else
                Throw New Exceptions.DataSourceException("Invalid Data Source!")
            End If
        End Sub
    End Module
End Namespace