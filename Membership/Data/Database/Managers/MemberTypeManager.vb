Imports Membership

Public Class MemberTypeManager
    Implements IDataManager(Of IMembershipType)

    Public Sub init() Implements IDataManager(Of IMembershipType).init
        Throw New NotImplementedException()
    End Sub

    Public Sub load() Implements IDataManager(Of IMembershipType).load
        Throw New NotImplementedException()
    End Sub

    Public Sub save() Implements IDataManager(Of IMembershipType).save
        Throw New NotImplementedException()
    End Sub

    Public Function addEntry(entry As IMembershipType) As MaybeOption(Of IMembershipType) Implements IDataManager(Of IMembershipType).addEntry
        Throw New NotImplementedException()
    End Function

    Public Function getEntry(id As Integer) As MaybeOption(Of IMembershipType) Implements IDataManager(Of IMembershipType).getEntry
        Throw New NotImplementedException()
    End Function

    Public Function list() As List(Of IMembershipType) Implements IDataManager(Of IMembershipType).list
        Throw New NotImplementedException()
    End Function

    Public Function removeEntry(entry As IMembershipType) As Boolean Implements IDataManager(Of IMembershipType).removeEntry
        Throw New NotImplementedException()
    End Function

    Public Function search(searchParam As IMembershipType, matchAll As Boolean, fuzzy As Boolean) As List(Of IMembershipType) Implements IDataManager(Of IMembershipType).search
        Throw New NotImplementedException()
    End Function

    Public Function updateEntry(entry As IMembershipType) As Boolean Implements IDataManager(Of IMembershipType).updateEntry
        Throw New NotImplementedException()
    End Function
End Class
