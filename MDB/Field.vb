Public Class Field
    Public Name As String
    Public DataType As MDBType
    Public Size As Integer
    Public NotNull As Boolean = False
    ''' <summary>
    ''' in sql
    ''' </summary>
    Public DefaultValue As String = Nothing
    ''' <summary>
    ''' New instance of field
    ''' </summary>
    ''' <param name="datatype">datatype of this field</param>
    ''' <param name="size">size of this field, required when the datatype require size</param>
    ''' <remarks></remarks>
    Public Sub New(datatype As MDBType, Optional size As Integer = 0)
        Me.Name = ""
        Me.DataType = datatype
        Me.Size = size
    End Sub
    ''' <summary>
    ''' Get SQL for the field
    ''' </summary>
    ''' <returns>the sql</returns>
    ''' <remarks></remarks>
    Public Function CreateSQL() As String
        Dim s As String = If(DataType.SizeRequired, String.Format("({0})", Size), "")
        Return String.Format("`{0}` {1}{2}{3}{4}", Me.Name, Me.DataType.SQL, s, If(Me.NotNull, " NOT NULL", ""), If(IsNothing(Me.DefaultValue), "", " DEFAULT " & DefaultValue))
    End Function
End Class