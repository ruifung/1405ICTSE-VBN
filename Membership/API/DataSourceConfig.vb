Namespace API.config.data
    Public Enum DSAuthMode
        NONE
        PASSWORDONLY
        USERPASS
    End Enum

    Public Class DSType
        Property display As String
        Property type As String
        Property isFileBased As Boolean
        Property authMode As DSAuthMode
        Property initializer As Func(Of DSConfigItem, DataStoreManager)
    End Class

    Public Class DSConfigItem
        Property DataSource As String
        Property Auth As Boolean
        Property User As String
        Property Pass As String
    End Class
End Namespace