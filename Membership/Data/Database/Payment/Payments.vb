Imports MDB
Namespace Database
    Partial Public Class Tables
        Public Shared PaymentsTable As Table
        Public Shared Sub InitPaymentTable()
            Dim t As Table = New Table
            t.Name = "payments"
            t.Fields("id") = New Field(MDBType.AutoNumber)
            t.Fields("member") = New Field(MDBType.Number)
            t.Fields("time") = New Field(MDBType.DateTime)
            t.Fields("total") = New Field(MDBType.Currency)
            t.Fields("paid") = New Field(MDBType.Currency)
            t.Fields("balance") = New Field(MDBType.Currency)
            t.PrimaryKey = "id"
            t.Constraints.Add(New Constraint(Constraint.ConsType.PrimaryKey, "id"))
            t.Constraints.Add(New Constraint(Constraint.ConsType.ForeignKey, "member", MembersTable.Name, "id"))
            DB.RegisterTable(t)
            PaymentsTable = t
        End Sub
    End Class
    Public Class Payments
        Inherits DBObject
        Implements IMemberPayment

        Public Overrides Function table() As Table
            Return Tables.PaymentsTable
        End Function

        Public ReadOnly Property id As Integer Implements IDataElement.id
            Get
                Return CInt(Me("id"))
            End Get
        End Property

        Public Property additionalCharges As Dictionary(Of String, Decimal) Implements IMemberPayment.additionalCharges
            Get

            End Get
            Set(value As Dictionary(Of String, Decimal))

            End Set
        End Property

        Public Property amountPaid As Decimal Implements IMemberPayment.amountPaid
            Get
                Return CDec(Me("paid"))
            End Get
            Set(value As Decimal)
                Me("paid") = value
            End Set
        End Property

        Public Property balance As Decimal Implements IMemberPayment.balance
            Get
                Return CDec(Me("balance"))
            End Get
            Set(value As Decimal)
                Me("balance") = value
            End Set
        End Property

        Public Property chargesPaid As HashSet(Of IMemberCharge) Implements IMemberPayment.chargesPaid
            Get
                Return New HashSet(Of IMemberCharge)(DBList(Of Charges).Query("paid_in=?", MDBType.Number.asParam(Me.id)))
            End Get
            Set(value As HashSet(Of IMemberCharge))

            End Set
        End Property

        Public Property memberID As Integer Implements IMemberPayment.memberID
            Get
                Return CInt(Me("member"))
            End Get
            Set(value As Integer)
                Me("member") = value
            End Set
        End Property

        Public Property totalPayable As Decimal Implements IMemberPayment.totalPayable
            Get
                Return CDec(Me("total"))
            End Get
            Set(value As Decimal)
                Me("total") = value
            End Set
        End Property
    End Class
End Namespace
