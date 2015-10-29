Public Class MembershipType
    Implements IDataElement
    Private id = -1
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
    ReadOnly typeName As String
    ReadOnly registrationFees As Double
    ReadOnly transferFees As Double
    ReadOnly monthlyFees As Double
    ReadOnly privilges As HashSet(Of EnumMemberPrivileges)

    Sub New(name As String,
            registFees As Double, transferFees As Double,
            monthlyFees As Double, privilges As HashSet(Of EnumMemberPrivileges))
        Me.typeName = name
        Me.registrationFees = registFees
        Me.transferFees = transferFees
        Me.monthlyFees = monthlyFees
        Me.privilges = privilges
    End Sub
End Class
