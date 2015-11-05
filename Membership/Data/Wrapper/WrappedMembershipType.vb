Imports Membership

Public Class WrappedMembershipType
    Implements IMembershipType

    Public Shared wrap As Func(Of IMembershipType, WrappedMembershipType) =
        Function(Type As IMembershipType) As WrappedMembershipType
            Return If(TryCast(Type, WrappedMembershipType), New WrappedMembershipType(Type))
        End Function

    Private _backingType As IMembershipType

    Public Property description As String Implements IMembershipType.description
        Get
            Return _backingType.description
        End Get
        Set(value As String)
            _backingType.description = value
        End Set
    End Property

    Public ReadOnly Property id As Integer Implements IDataElement.id
        Get
            Return _backingType.id
        End Get
    End Property

    Public Property monthlyFees As Double Implements IMembershipType.monthlyFees
        Get
            Return _backingType.monthlyFees
        End Get
        Set(value As Double)
            _backingType.monthlyFees = value
        End Set
    End Property

    Public Property privilges As HashSet(Of EnumMemberPrivileges) Implements IMembershipType.privilges
        Get
            Return _backingType.privilges
        End Get
        Set(value As HashSet(Of EnumMemberPrivileges))
            _backingType.privilges = value
        End Set
    End Property

    Public Property registrationFees As Double Implements IMembershipType.registrationFees
        Get
            Return _backingType.registrationFees
        End Get
        Set(value As Double)
            _backingType.registrationFees = value
        End Set
    End Property

    Public Property transferFees As Double Implements IMembershipType.transferFees
        Get
            Return _backingType.transferFees
        End Get
        Set(value As Double)
            _backingType.transferFees = value
        End Set
    End Property

    Public Property typeName As String Implements IMembershipType.typeName
        Get
            Return _backingType.typeName
        End Get
        Set(value As String)
            _backingType.typeName = value
        End Set
    End Property

    Public Sub New(backingType As IMembershipType)
        _backingType = backingType
    End Sub
End Class
