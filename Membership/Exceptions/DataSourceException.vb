Namespace Exceptions
    Public Class DataSourceException
        Inherits ApplicationException

        Sub New()
            MyBase.New
        End Sub
        Sub New(message As String, innerException As Exception)
            MyBase.New(message, innerException)
        End Sub
    End Class
End Namespace
