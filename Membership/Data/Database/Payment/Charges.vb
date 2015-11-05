Imports MDB
Namespace Database
    Partial Class Tables
        Public Shared ChargesTable As Table
        Public Shared Sub InitChargesTable()
            Dim t As Table = New Table
            t.Name = "charges"
            t.Fields("id") = New Field(MDBType.AutoNumber)
            t.Fields("member") = New Field(MDBType.Number)
            t.Fields("time") = New Field(MDBType.DateTime)
            t.Fields("desc") = New Field(MDBType.Text, 200)
            t.Fields("amount") = New Field(MDBType.Currency)
            t.Fields("paid") = New Field(MDBType.Byte)
            t.PrimaryKey = "id"
            t.Constraints.Add(New Constraint(Constraint.ConsType.PrimaryKey, "id"))
            t.Constraints.Add(New Constraint(Constraint.ConsType.ForeignKey, "member", MembersTable.Name, "id"))
            DB.RegisterTable(t)
            ChargesTable = t
        End Sub
    End Class
    Public Class Charges
        Inherits DBObject
        Implements IMemberCharge
        Public Overrides Function table() As Table
            Return Tables.ChargesTable
        End Function

        Public ReadOnly Property id As Integer Implements IDataElement.id
            Get
                Return CInt(Me("id"))
            End Get
        End Property

        Public Property amount As Decimal Implements IMemberCharge.amount
            Get

            End Get
            Set(value As Decimal)

            End Set
        End Property

        Public Property description As String Implements IMemberCharge.description
            Get

            End Get
            Set(value As String)

            End Set
        End Property
        Public Property memberID As Integer Implements IMemberCharge.memberID
            Get

            End Get
            Set(value As Integer)

            End Set
        End Property
        Public Property paid As Boolean Implements IMemberCharge.paid
            Get

            End Get
            Set(value As Boolean)

            End Set
        End Property
        Public Property timestamp As Date Implements IMemberCharge.timestamp
            Get

            End Get
            Set(value As Date)

            End Set
        End Property

    End Class
End Namespace
