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
        Implements IMember

        Private emailFilter As Regex = New Regex("^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$")
        Private contactFilter As Regex = New Regex("^\+{0,1}\d{9,}$")
        Private _photo As MaybeOption(Of Image) = New None(Of Image)
        Public ReadOnly Property id As Integer Implements IMember.id
            Get
                Return CInt(Me("id"))
            End Get
        End Property
        Public Property firstName As String Implements IMember.firstName
            Get
                Return CType(Me("firstname"), String)
            End Get
            Set(value As String)
                Me("firstname") = value
            End Set
        End Property
        Public Property lastName As String Implements IMember.lastName
            Get
                Return CType(Me("lastname"), String)
            End Get
            Set(value As String)
                Me("lastname") = value
            End Set
        End Property
        Public Property membership As Integer Implements IMember.membershipTypeID
            Get
                Return CInt(Me("membership"))
            End Get
            Set(value As Integer)
                Me("membership") = value
            End Set
        End Property
        Public Property contact As String Implements IMember.contactNumber
            Get
                Return CType(Me("contact"), String)
            End Get
            Set(value As String)
                If contactFilter.IsMatch(value) Then
                    Me("contact") = value
                Else
                    Throw New ArgumentException("Invalid contact number!")
                End If
            End Set
        End Property
        Public Property email As String Implements IMember.email
            Get
                Return CType(Me("email"), String)
            End Get
            Set(value As String)
                If emailFilter.IsMatch(value) Then
                    Me("email") = value
                Else
                    Throw New ArgumentException("Invalid e-mail number!")
                End If
            End Set
        End Property
        Public Property photo As MaybeOption(Of Image) Implements IMember.photo
            Get
                If IsNothing(Me("photo")) Then Return New None(Of Image)
                If _photo.isEmpty Then
                    Dim stream As MemoryStream = New MemoryStream(DirectCast(Me("photo"), Byte()))
                    _photo = MaybeOption.create(Image.FromStream(stream))
                    stream.Close()
                End If
                Return _photo
            End Get
            Set(value As MaybeOption(Of Image))
                _photo = value
                _photo.forEach(Sub(x)
                                   Dim stream As MemoryStream = New MemoryStream()
                                   x.Save(stream, ImageFormat.Jpeg)
                                   Dim bytes(CInt(stream.Length)) As Byte
                                   stream.Read(bytes, 0, CInt(stream.Length))
                                   stream.Close()
                                   Me("photo") = bytes
                               End Sub)
            End Set
        End Property
        Public Property activated As Boolean Implements IMember.isActive
            Get
                Return CInt(Me("active")) > 0
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
