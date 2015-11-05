Imports System.Data.OleDb

Public Class MDBType
#Region "Types"
    Public Shared ReadOnly Text As New MDBType("VARCHAR", OleDbType.VarWChar, GetType(String), True)
    Public Shared ReadOnly Memo As New MDBType("LONGTEXT", OleDbType.LongVarWChar, GetType(String))
    Public Shared ReadOnly [Byte] As New MDBType("BYTE", OleDbType.UnsignedTinyInt, GetType(Byte))
    Public Shared ReadOnly DateTime As New MDBType("DATETIME", OleDbType.Date, GetType(Date))
    Public Shared ReadOnly Currency As New MDBType("CURRENCY", OleDbType.Numeric, GetType([Decimal]))
    Public Shared ReadOnly Numeric As New MDBType("NUMERIC", OleDbType.Numeric, GetType([Decimal]))
    Public Shared ReadOnly [Double] As New MDBType("DOUBLE", OleDbType.Double, GetType(Double))
    Public Shared ReadOnly Number As New MDBType("LONG", OleDbType.Integer, GetType(Int32))
    Public Shared ReadOnly [Integer] As New MDBType("SHORT", OleDbType.SmallInt, GetType(Int16))
    Public Shared ReadOnly Binary As New MDBType("VARBINARY", OleDbType.VarBinary, GetType(Byte()), True)
    Public Shared ReadOnly OLE As New MDBType("LONGBINARY", OleDbType.LongVarBinary, GetType(Byte()))
    Public Shared ReadOnly AutoNumber As New MDBType("AUTOINCREMENT", OleDbType.Integer, GetType(Int32))
#End Region
#Region "Instance Properties & Functions"
    ''' <summary>
    ''' Data Type in SQL
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly SQL As String
    ''' <summary>
    ''' Data Type for OleDb
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly DBType As OleDbType
    ''' <summary>
    ''' Data Type in .Net
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly NetType As Type
    ''' <summary>
    ''' does this data type require size
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly SizeRequired As Boolean
    Private Sub New(sql As String, dbtype As OleDbType, t As Type, Optional sr As Boolean = False)
        Me.SQL = sql
        Me.DBType = dbtype
        Me.NetType = t
        Me.SizeRequired = sr
    End Sub
    ''' <summary>
    ''' Create a OleDbParameter as current datatype
    ''' </summary>
    ''' <param name="value">value of the parameter</param>
    ''' <returns>the parameter</returns>
    ''' <remarks></remarks>
    Public Function asParam(value As Object) As OleDbParameter
        Dim param As OleDbParameter = New OleDbParameter()
        param.OleDbType = Me.DBType
        param.Value = value
        Return param
    End Function
#End Region
End Class
