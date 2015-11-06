Imports MDB
Imports Newtonsoft.Json
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
            t.Fields("addition") = New Field(MDBType.Memo)
            t.Fields("userID") = New Field(MDBType.Number)
            t.PrimaryKey = "id"
            t.Constraints.Add(New Constraint(Constraint.ConsType.PrimaryKey, "id"))
            t.Constraints.Add(New Constraint(Constraint.ConsType.ForeignKey, "member", MembersTable.Name, "id"))
            DB.RegisterTable(t)
            PaymentsTable = t
        End Sub
    End Class
    Public Class Payment
        Inherits DBObject
        Implements IMemberPayment

        Private charges As HashSet(Of IMemberCharge) = Nothing

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
                Return JsonConvert.DeserializeObject(Of Dictionary(Of String, Decimal))(Me("addition").ToString())
            End Get
            Set(value As Dictionary(Of String, Decimal))
                Me("addition") = JsonConvert.SerializeObject(value)
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
                If charges Is Nothing Then _
                    charges = New HashSet(Of IMemberCharge)(DBList(Of Charge).Query("paid_in=?", MDBType.Number.asParam(Me.id)))
                Return charges
            End Get
            Set(value As HashSet(Of IMemberCharge))
                charges = value
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

        Public Property userID As Integer Implements IMemberPayment.userID
            Get
                Return CInt(Me("userID"))
            End Get
            Set(value As Integer)
                Me("userID") = value
            End Set
        End Property

        Public Overrides Sub Insert()
            MyBase.Insert()
            Dim oc = New DBList(Of Charge)
            For Each c As Charge In charges
                Dim dc As Charge = New Charge
                dc("id") = c.id
                oc.Add(dc)
            Next
            oc.Update("paid_in") = id
        End Sub

        Public Overrides Sub Update()
            Dim oc As DBList(Of Charge) = DBList(Of Charge).Query("paid_in=?", MDBType.Number.asParam(Me.id))
            oc.Update("paid_in") = 0
            oc = New DBList(Of Charge)
            For Each c As Charge In charges
                Dim dc As Charge = New Charge
                dc("id") = c.id
                oc.Add(dc)
            Next
            oc.Update("paid_in") = id
            MyBase.Update()
        End Sub

        Public Overrides Sub Delete()
            DBList(Of Charge).Query("paid_in=?", MDBType.Number.asParam(Me.id)).Update("paid_in") = 0
            MyBase.Delete()
        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            charges = New HashSet(Of IMemberCharge)(DBList(Of Charge).Query("paid_in=?", MDBType.Number.asParam(Me.id)))
        End Sub
    End Class
End Namespace
