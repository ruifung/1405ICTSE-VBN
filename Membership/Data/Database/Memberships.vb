Imports MDB
Namespace Database
    Partial Class Tables
        Public Shared MembershipsTable As Table
        Public Shared Sub InitMShipsTable()
            Dim t As Table = New Table
            t.Name = "Memberships"
            t.Fields("id") = New Field(MDBType.AutoNumber)
            t.Fields("type") = New Field(MDBType.Text, 20)
            t.Fields("reg_fee") = New Field(MDBType.Currency)
            t.Fields("month_fee") = New Field(MDBType.Currency)
            t.Fields("trans_fee") = New Field(MDBType.Currency)
            t.Fields("desc") = New Field(MDBType.Text, 200)
            t.PrimaryKey = "id"
            t.Constraints.Add(New Constraint(Constraint.ConsType.PrimaryKey, "id"))
            DB.RegisterTable(t)
            MembershipsTable = t
        End Sub
    End Class
    Public Class Membership
        Inherits DBObject
        Public ReadOnly Property id As Integer
            Get
                Return CInt(Me("id"))
            End Get
        End Property
        Public Property type As String
            Get
                Return CStr(Me("type"))
            End Get
            Set(value As String)
                Me("type") = value
            End Set
        End Property
        Public Property RegistrationFee As Decimal
            Get
                Return CDec(Me("reg_fee"))
            End Get
            Set(value As Decimal)
                Me("reg_fee") = value
            End Set
        End Property
        Public Property MonthlyFee As Decimal
            Get
                Return CDec(Me("month_fee"))
            End Get
            Set(value As Decimal)
                Me("month_fee") = value
            End Set
        End Property
        Public Property TransferFee As Decimal
            Get
                Return CDec(Me("trans_fee"))
            End Get
            Set(value As Decimal)
                Me("trans_fee") = value
            End Set
        End Property
        Public Property Description As String
            Get
                Return CStr(Me("desc"))
            End Get
            Set(value As String)
                Me("desc") = value
            End Set
        End Property
        Public Overrides Function table() As Table
            Return Tables.MembershipsTable
        End Function
    End Class
End Namespace
