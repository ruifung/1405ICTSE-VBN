Public Interface IMembershipType
    Inherits IDataElement
    Property typeName As String
    Property registrationFees As Decimal
    Property transferFees As Decimal
    Property monthlyFees As Decimal
    Property description As String
    Property privilges As HashSet(Of EnumMemberPrivileges)
End Interface
