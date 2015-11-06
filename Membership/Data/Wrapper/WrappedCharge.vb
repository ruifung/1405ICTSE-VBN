Imports Membership

Public Class WrappedCharge
    Implements IMemberCharge
    Public ReadOnly _backingCharge As IMemberCharge
    Public Shared wrap As Func(Of IMemberCharge, WrappedCharge) =
        Function(x As IMemberCharge)
            Return If(TryCast(x, WrappedCharge), New WrappedCharge(x))
        End Function

    Public ReadOnly Property id As Integer Implements IDataElement.id
        Get
            Return _backingCharge.id
        End Get
    End Property

    Public Property memberID As Integer Implements IMemberCharge.memberID
        Get
            Return _backingCharge.memberID
        End Get
        Set(value As Integer)
            _backingCharge.memberID = value
        End Set
    End Property

    Public Property description As String Implements IMemberCharge.description
        Get
            Return _backingCharge.description
        End Get
        Set(value As String)
            _backingCharge.description = value
        End Set
    End Property

    Public Property timestamp As Date Implements IMemberCharge.timestamp
        Get
            Return _backingCharge.timestamp
        End Get
        Set(value As Date)
            _backingCharge.timestamp = value
        End Set
    End Property

    Public Property amount As Decimal Implements IMemberCharge.amount
        Get
            Return _backingCharge.amount
        End Get
        Set(value As Decimal)
            _backingCharge.amount = value
        End Set
    End Property

    Public Property paid As Boolean Implements IMemberCharge.paid
        Get
            Return _backingCharge.paid
        End Get
        Set(value As Boolean)
            _backingCharge.paid = value
        End Set
    End Property

    Sub New(charge As IMemberCharge)
        _backingCharge = charge
    End Sub
End Class
