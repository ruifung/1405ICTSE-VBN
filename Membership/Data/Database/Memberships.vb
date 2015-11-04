Imports MDB
Namespace Database
    Partial Class Tables
        Public Shared MembershipsTable As Table
        Public Shared Sub InitMShipsTable()
            Dim t As Table = New Table
            t.Name = "memberships"
            t.Fields("id") = New Field(MDBType.AutoNumber)
            t.Fields("type") = New Field(MDBType.Text, 20)
            t.Fields("reg_fee") = New Field(MDBType.Currency)
            t.Fields("month_fee") = New Field(MDBType.Currency)
            t.Fields("trans_fee") = New Field(MDBType.Currency)
            t.Fields("desc") = New Field(MDBType.Text, 200)
            t.Fields("privileges") = New Field(MDBType.Number)
            t.PrimaryKey = "id"
            t.Constraints.Add(New Constraint(Constraint.ConsType.PrimaryKey, "id"))
            DB.RegisterTable(t)
            MembershipsTable = t
        End Sub
    End Class
    Public Class Membership
        Inherits DBObject
        Implements IMembershipType

        Public Shared Function TryGet(id As Integer) As Membership
            Return DBObject.Find(Of Membership)(id)
        End Function

        Public Property id As Integer Implements IDataElement.id
            Get
                Return CInt(Me("id"))
            End Get
            Set(value As Integer)

            End Set
        End Property
        Public Property type As String Implements IMembershipType.typeName
            Get
                Return CStr(Me("type"))
            End Get
            Set(value As String)
                Me("type") = value
            End Set
        End Property
        Public Property RegistrationFee As Double Implements IMembershipType.registrationFees
            Get
                Return CDbl(Me("reg_fee"))
            End Get
            Set(value As Double)
                Me("reg_fee") = value
            End Set
        End Property
        Public Property MonthlyFee As Double Implements IMembershipType.monthlyFees
            Get
                Return CDbl(Me("month_fee"))
            End Get
            Set(value As Double)
                Me("month_fee") = value
            End Set
        End Property
        Public Property TransferFee As Double Implements IMembershipType.transferFees
            Get
                Dim result = Me("trans_fee")
                Return If(IsNothing(result) OrElse IsDBNull(result), 0, CDbl(result))
            End Get
            Set(value As Double)
                Me("trans_fee") = value
            End Set
        End Property
        Public Property Description As String Implements IMembershipType.description
            Get
                Return TryCast(Me("desc"), String)
            End Get
            Set(value As String)
                Me("desc") = value
            End Set
        End Property

        Public Property privilges As HashSet(Of EnumMemberPrivileges) Implements IMembershipType.privilges
            Get
                Dim result = Me("privileges")
                Dim bits As Integer = If(IsNothing(result) OrElse IsDBNull(result), 0, CInt(result))
                Dim hs As HashSet(Of EnumMemberPrivileges) = New HashSet(Of EnumMemberPrivileges)
                For Each i As Integer In [Enum].GetValues(GetType(EnumMemberPrivileges))
                    If (bits And i) <> 0 Then
                        hs.Add(DirectCast(i, EnumMemberPrivileges))
                    End If
                Next
                Return hs
            End Get
            Set(value As HashSet(Of EnumMemberPrivileges))
                Dim v As Integer = 0
                For Each bit As Integer In value
                    v = v Or bit
                Next

            End Set
        End Property

        Public Overrides Function table() As Table
            Return Tables.MembershipsTable
        End Function
    End Class
End Namespace
