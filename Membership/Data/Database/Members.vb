﻿Imports System.Drawing.Imaging
Imports System.IO
Imports MDB
Namespace Database
    Partial Public Class Tables
        Public Shared MembersTable As Table
        Public Shared Sub InitMembersTable()
            MembersTable = New Table()
            MembersTable.Name = "members"
            MembersTable.Fields("id") = New Field(MDBType.AutoNumber)
            MembersTable.Fields("firstname") = New Field(MDBType.Text, 50)
            MembersTable.Fields("lastname") = New Field(MDBType.Text, 50)
            MembersTable.Fields("dob") = New Field(MDBType.DateTime)
            MembersTable.Fields("gender") = New Field(MDBType.Number)
            MembersTable.Fields("mship") = New Field(MDBType.Number)
            MembersTable.Fields("mship").DefaultValue = "-1"
            MembersTable.Fields("contact") = New Field(MDBType.Text, 15)
            MembersTable.Fields("email") = New Field(MDBType.Text, 50)
            MembersTable.Fields("photo") = New Field(MDBType.OLE)
            MembersTable.Fields("credit") = New Field(MDBType.Currency)
            MembersTable.Fields("addr") = New Field(MDBType.Text, 255)
            MembersTable.Fields("term") = New Field(MDBType.Number)
            MembersTable.Fields("term_due") = New Field(MDBType.DateTime)
            MembersTable.Fields("activate") = New Field(MDBType.Byte)
            MembersTable.PrimaryKey = "id"
            MembersTable.Constraints.Add(New MDB.Constraint(MDB.Constraint.ConsType.PrimaryKey, "id"))
            MembersTable.Constraints.Add(
                New Constraint(Constraint.ConsType.ForeignKey,
                               "mship", "memberships", "id"))
            DB.RegisterTable(MembersTable)
        End Sub
    End Class
    Public Class Member
        Inherits DBObject
        Implements IMember

        Public Shared Function TryGet(id As Integer) As Member
            Return DBObject.Find(Of Member)(id)
        End Function

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
                Return CInt(Me("mship"))
            End Get
            Set(value As Integer)
                Me("mship") = value
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
                If IsNothing(Me("photo")) Then Return MaybeOption.create(Of Image)(My.Resources.noimage)
                If _photo.isEmpty Then
                    Dim stream As MemoryStream = New MemoryStream(DirectCast(Me("photo"), Byte()))
                    Try
                        _photo = MaybeOption.create(Image.FromStream(stream))
                    Catch ex As ArgumentException
                        _photo = New None(Of Image)
                        Update()
                    End Try
                    stream.Close()
                End If
                Return _photo
            End Get
            Set(value As MaybeOption(Of Image))
                _photo = value
                _photo.forEach(Sub(x)
                                   Dim stream As MemoryStream = New MemoryStream()
                                   x.Save(stream, ImageFormat.Jpeg)
                                   Dim bytes() = stream.ToArray
                                   stream.Dispose()
                                   Me("photo") = bytes
                               End Sub)
            End Set
        End Property
        Public Property activated As Boolean Implements IMember.isActive
            Get
                Return CInt(Me("activate")) > 0
            End Get
            Set(value As Boolean)
                Me("activate") = If(value, 1, 0)
            End Set
        End Property
        'TODO: IMPLEMENT
        Public Property dob As Date Implements IMember.dob
            Get
                Return CDate(Me("dob"))
            End Get
            Set(value As Date)
                Me("dob") = value
            End Set
        End Property

        Public Property gender As Gender Implements IMember.gender
            Get
                Return DirectCast(Me("gender"), Gender)
            End Get
            Set(value As Gender)
                Me("gender") = CInt(value)
            End Set
        End Property

        Public Property address As String Implements IMember.address
            Get
                Return CStr(Me("addr"))
            End Get
            Set(value As String)
                Me("addr") = value
            End Set
        End Property

        Public Property paymentCredit As Decimal Implements IMember.paymentCredit
            Get
                Return CDec(Me("credit"))
            End Get
            Set(value As Decimal)
                Me("credit") = value
            End Set
        End Property

        Public Property paymentTerm As PaymentTerm Implements IMember.paymentTerm
            Get
                Return CType(Me("term"), PaymentTerm)
            End Get
            Set(value As PaymentTerm)
                Me("term") = value
            End Set
        End Property

        Public Property paymentTermDue As Date Implements IMember.paymentTermDue
            Get
                Return CDate(Me("term_due"))
            End Get
            Set(value As Date)
                Me("term_due") = value
            End Set
        End Property

        Public Sub setAll(entry As IMember)
            With Me
                .firstName = entry.firstName
                .lastName = entry.lastName
                .contact = entry.contactNumber
                .address = entry.address
                .email = entry.email
                .dob = entry.dob
                .gender = entry.gender
                .photo = entry.photo
                .activated = entry.isActive
                .membership = entry.membershipTypeID
                .paymentCredit = entry.paymentCredit
            End With
        End Sub

        Public Overrides Function table() As Table
            Return Tables.MembersTable
        End Function
    End Class
End Namespace