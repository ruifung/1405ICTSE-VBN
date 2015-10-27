Public Interface IMemberTypeManager
    Function getMemberType(id As Integer) As MembershipType
    Function addMemberType(memberType As MembershipType) As Integer
    Function getMembershipTypes() As List(Of MembershipType)

    Sub init()
    Sub load()
    Sub save()
End Interface
