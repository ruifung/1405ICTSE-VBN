Public Class InvalidSettingException
    Inherits ApplicationException
    ReadOnly settingKey As String
    Shadows ReadOnly InnerException As Exception

    Sub New(settingKey As String)
        Me.settingKey = settingKey
    End Sub

    Sub New(settingKey As String, innerException As Exception)
        Me.New(settingKey)
        Me.InnerException = innerException
    End Sub
End Class
