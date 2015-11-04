Option Infer On

Namespace config
    Module DataSourceConfig
        Friend Sub initData()
            Dim dataMode = configuration("DataMode").getOrAlt(String.Empty)
            Dim dataAuth As Boolean = False
            Boolean.TryParse(configuration("DataAuth").orNothing, dataAuth)
            If dataMode.Contains("OLEDB") Then
                Dim csb = New OleDb.OleDbConnectionStringBuilder
                csb.Add("Data Source", configuration("DataSource").orNothing)
                Select Case configuration("DataMode").getValue
                    Case DBModes.OLEDB_ACCESS_JET.ToString
                        csb.Add("Provider", "Microsoft.Jet.OLEDB.4.0")
                    Case DBModes.OLEDB_ACCESS_ACE.ToString
                        csb.Add("Provider", "Microsoft.ACE.OLEDB.12.0")
                    Case Else
                        Throw New Exception
                End Select
                dataManager = New DataStoreManager(New Database.DataStore, csb)
            End If
        End Sub

        'Also hardcoded for now.
        Public Function getDSTypes() As List(Of DBType)
            Dim list = New List(Of DBType)
            For Each x As DBModes In [Enum].GetValues(GetType(DBModes))
                list.Add(New DBType(x.ToString.Replace("_", " "), x, True))
            Next
            Return list
        End Function
    End Module

    'If this was a deployment system, this would be modular instead of hardcoded.
    Public Enum DBModes
        OLEDB_ACCESS_JET
        OLEDB_ACCESS_ACE
    End Enum


    Public Class DBType
        Property display As String
        Property type As String
        Property typeID As Integer
        Property isFileBased As Boolean

        Sub New(display As String, type As DBModes, isFileBased As Boolean)
            Me.display = display
            Me.type = type.ToString
            typeID = type
            Me.isFileBased = isFileBased
        End Sub
    End Class
End Namespace