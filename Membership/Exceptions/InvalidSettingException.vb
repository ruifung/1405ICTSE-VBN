Public Class InvalidSettingException
    Inherits ApplicationException
    Public ReadOnly Property settingKey As String
    Public Shadows ReadOnly InnerException As Exception

    Sub New(settingKey As String)
        Me.settingKey = settingKey
    End Sub

    Sub New(settingKey As String, innerException As Exception)
        Me.New(settingKey)
        Me.InnerException = innerException
    End Sub
End Class
