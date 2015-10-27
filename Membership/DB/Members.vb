Imports System.Text.RegularExpressions
Imports System.Drawing.Imaging
Imports System.IO

Partial Public Class DB
    Public Shared MembersTable As Table
    Public Shared Sub InitMembersTable()
        MembersTable = New Table()
        MembersTable.Fields("id") = New Field(MDBType.AutoNumber)
        MembersTable.Fields("firstname") = New Field(MDBType.Text, 50)
        MembersTable.Fields("lastname") = New Field(MDBType.Text, 50)
        MembersTable.Fields("membership") = New Field(MDBType.Number)
        MembersTable.Fields("contact") = New Field(MDBType.Text, 15)
        MembersTable.Fields("email") = New Field(MDBType.Text, 50)
        MembersTable.Fields("photo") = New Field(MDBType.Binary, 5 * 1024 * 1024)
        MembersTable.Fields("activate") = New Field(MDBType.Byte)
        MembersTable.PrimaryKey = "id"
        DB.RegisterTable(MembersTable)
    End Sub
    Public Class Member
        Inherits DBObject
        Private emailFilter As Regex = New Regex("^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$")
        Private contactFilter As Regex = New Regex("^\+{0,1}\d{9,}$")
        Private _photo As Image = Nothing
        Public ReadOnly Property id As Integer
            Get
                Return Me("id")
            End Get
        End Property
        Public Property firstName As String
            Get
                Return Me("firstname")
            End Get
            Set(value As String)
                Me("firstname") = value
            End Set
        End Property
        Public Property lastName As String
            Get
                Return Me("lastname")
            End Get
            Set(value As String)
                Me("lastname") = value
            End Set
        End Property
        Public Property membership As Integer
            Get
                Return Me("membership")
            End Get
            Set(value As Integer)
                Me("membership") = value
            End Set
        End Property
        Public Property contact As String
            Get
                Return Me("contact")
            End Get
            Set(value As String)
                If contactFilter.IsMatch(value) Then
                    Me("contact") = value
                Else
                    Throw New ArgumentException("Invalid contact number!")
                End If
            End Set
        End Property
        Public Property email As String
            Get
                Return Me("email")
            End Get
            Set(value As String)
                If emailFilter.IsMatch(value) Then
                    Me("email") = value
                Else
                    Throw New ArgumentException("Invalid e-mail number!")
                End If
            End Set
        End Property
        Public Property photo As Image
            Get
                If IsNothing(Me("photo")) Then Return Nothing
                If IsNothing(_photo) Then
                    Dim stream As MemoryStream = New MemoryStream(DirectCast(Me("photo"), Byte()))
                    _photo = Image.FromStream(stream)
                    stream.Close()
                End If
                Return _photo
            End Get
            Set(value As Image)
                _photo = value
                Dim stream As MemoryStream = New MemoryStream()
                _photo.Save(stream, ImageFormat.Jpeg)
                Dim bytes(stream.Length) As Byte
                stream.Read(bytes, 0, stream.Length)
                stream.Close()
                Me("photo") = bytes
            End Set
        End Property
        Public Property activated As Boolean
            Get
                Return Me("active") > 0
            End Get
            Set(value As Boolean)
                Me("active") = If(value, 1, 0)
            End Set
        End Property
        Public Overrides Function table() As Table
            Return MembersTable
        End Function
    End Class
End Class
