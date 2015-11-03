Public Class Field
    Public Name As String
    Public DataType As MDBType
    Public Size As Integer
    Public NotNull As Boolean = False
    Public DefaultValue As Object = Nothing
    Public Sub New(datatype As MDBType, Optional size As Integer = 0)
        Me.Name = ""
        Me.DataType = datatype
        Me.Size = size
    End Sub
    Public Function CreateSQL() As String
        Dim s As String = If(DataType.SizeRequired, String.Format("({0})", Size), "")
        Return String.Format("`{0}` {1}{2}{3}{4}", Me.Name, Me.DataType.SQL, s, If(Me.NotNull, " NOT NULL", ""), If(IsNothing(Me.DefaultValue), "", " DEFAULT ?"))
    End Function
End Class