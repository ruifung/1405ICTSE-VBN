Public Interface IMembershipType
    Inherits IDataElement
    Property typeName As String
    Property registrationFees As Double
    Property transferFees As Double
    Property monthlyFees As Double
    Property description As String
    Property privilges As HashSet(Of EnumMemberPrivileges)
End Interface
