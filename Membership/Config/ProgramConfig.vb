Namespace config
    Public Class ProgramConfig
        Private _DataSourceType, _DataSourcePath, _DataSourceUser, _DataSourcePass As String
        Private _DataSourceAuth As Boolean

        Public Property DataSourceType As String
            Get
                Return If(_DataSourceType, String.Empty)
            End Get
            Friend Set(value As String)
                _DataSourceType = value
            End Set
        End Property
        Function validateDataSource() As Boolean
            Return DataSourceType.Length > 0 AndAlso supportedDataSources.Exists(Function(y) y.type.Equals(DataSourceType))
        End Function

        Public Property DataSourcePath As String
            Get
                Return If(_DataSourcePath, String.Empty)
            End Get
            Friend Set(value As String)
                _DataSourcePath = value
            End Set
        End Property
        Function validateDataPath() As Boolean
            Return DataSourcePath.Length > 0
        End Function

        Public Property DataSourceAuth As Boolean
            Get
                Return _DataSourceAuth
            End Get
            Friend Set(value As Boolean)
                _DataSourceAuth = value
            End Set
        End Property

        Public Property DataSourceUser As String
            Get
                Return If(_DataSourceUser, String.Empty)
            End Get
            Friend Set(value As String)
                _DataSourceUser = value
            End Set
        End Property
        Function validateDataUser() As Boolean
            Return If(DataSourceAuth, DataSourceUser.Length > 0, True)
        End Function


        Public Property DataSourcePass As String
            Get
                Return If(_DataSourcePass, String.Empty)
            End Get
            Friend Set(value As String)
                _DataSourcePass = value
            End Set
        End Property
        Function validateDataPass() As Boolean
            Return If(DataSourceAuth, DataSourcePass.Length > 0, True)
        End Function
    End Class
End Namespace
