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
            t.Fields("paid_in") = New Field(MDBType.Number)
            t.PrimaryKey = "id"
            t.Constraints.Add(New Constraint(Constraint.ConsType.PrimaryKey, "id"))
            t.Constraints.Add(New Constraint(Constraint.ConsType.ForeignKey, "member", MembersTable.Name, "id"))
            t.Constraints.Add(New Constraint(Constraint.ConsType.ForeignKey, "paid_in", PaymentsTable.Name, "id"))
            DB.RegisterTable(t)
            ChargesTable = t
        End Sub
    End Class
    Public Class Charge
        Inherits DBObject
        Implements IMemberCharge
        Public PaymentId As Integer
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
                Return CDec(Me("amount"))
            End Get
            Set(value As Decimal)
                Me("amount") = value
            End Set
        End Property

        Public Property description As String Implements IMemberCharge.description
            Get
                Return CStr(Me("desc"))
            End Get
            Set(value As String)
                Me("desc") = value
            End Set
        End Property
        Public Property memberID As Integer Implements IMemberCharge.memberID
            Get
                Return CInt(Me("member"))
            End Get
            Set(value As Integer)
                Me("member") = value
            End Set
        End Property

        ''' <summary>
        ''' Have to set paymentId before set it to true
        ''' </summary>
        ''' <value>Paid or not</value>
        ''' <returns>Paid or not</returns>
        ''' <remarks></remarks>
        Public Property paid As Boolean Implements IMemberCharge.paid
            Get
                Return CInt(Me("paid_in")) <> 0
            End Get
            Set(value As Boolean)
                Me("paid_in") = If(value, PaymentId, 0)
            End Set
        End Property

        Public Property timestamp As Date Implements IMemberCharge.timestamp
            Get
                Return CDate(Me("time"))
            End Get
            Set(value As Date)
                Me("time") = value
            End Set
        End Property

    End Class
End Namespace
