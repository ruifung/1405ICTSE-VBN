Public Class Constraint
    Public Enum ConsType As Byte
        Unique
        PrimaryKey
        ForeignKey
    End Enum
    Public type As ConsType
    Public field As String
    Public refTable As String
    Public refField As String
    Public Sub New(t As ConsType, f As String, Optional rt As _
                   String = Nothing, Optional rf As String = Nothing)
        Me.type = t
        Me.field = f
        Me.refField = rf
        Me.refTable = rt
    End Sub
End Class
