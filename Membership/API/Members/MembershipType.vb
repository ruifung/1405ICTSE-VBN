Public Class MembershipType
    Implements IDataElement
    Private id As Integer = -1
    Property typeID As Integer Implements IDataElement.id
        Set(value As Integer)
            If id = -1 Then
                id = value
            End If
        End Set
        Get
            Return id
        End Get
    End Property
    ReadOnly Property typeName As String
    ReadOnly Property registrationFees As Double
    ReadOnly Property transferFees As Double
    ReadOnly Property monthlyFees As Double
    ReadOnly Property privilges As HashSet(Of EnumMemberPrivileges)

    Sub New(name As String,
            registFees As Double, transferFees As Double,
            monthlyFees As Double, privilges As HashSet(Of EnumMemberPrivileges))
        Me.typeName = name
        Me.registrationFees = registFees
        Me.transferFees = transferFees
        Me.monthlyFees = monthlyFees
        Me.privilges = privilges
    End Sub

    Overrides Function ToString() As String
        Return typeName
    End Function
End Class
