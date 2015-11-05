Imports Membership
Imports MDB

Namespace Database
    Public Class MemberTypeManager
        Implements IDataManager(Of IMembershipType)

        Public Sub init() Implements IDataManager(Of IMembershipType).init

        End Sub

        Public Sub load() Implements IDataManager(Of IMembershipType).load

        End Sub

        Public Sub save() Implements IDataManager(Of IMembershipType).save

        End Sub

        Public Function addEntry(entry As IMembershipType) As MaybeOption(Of IMembershipType) Implements IDataManager(Of IMembershipType).addEntry
            Dim mship As Membership = TryCast(entry, Membership)
            If Not IsNothing(mship) Then
                mship.Insert()
            Else
                mship = New Membership
                Dim imship As IMembershipType = mship
                imship.description = entry.description
                imship.monthlyFees = entry.monthlyFees
                imship.privilges = entry.privilges
                imship.registrationFees = entry.registrationFees
                imship.transferFees = entry.transferFees
                imship.typeName = entry.typeName
                mship.Insert()
            End If
            Return MaybeOption.create(DirectCast(mship, IMembershipType))
        End Function

        Public Function count() As ULong Implements IDataManager(Of IMembershipType).count
            Return CType(DBList(Of Membership).RowsCount(), ULong)
        End Function

        Public Function getEntry(id As Integer) As MaybeOption(Of IMembershipType) Implements IDataManager(Of IMembershipType).getEntry
            Return MaybeOption.create(Of IMembershipType)(TryCast(Member.TryGet(id), IMembershipType))
        End Function

        Public Function list() As List(Of IMembershipType) Implements IDataManager(Of IMembershipType).list
            Return New List(Of IMembershipType)(DBList(Of Membership).Query())
        End Function

        Public Function removeEntry(entry As IMembershipType) As Boolean Implements IDataManager(Of IMembershipType).removeEntry
            Dim m As Member = New Member
            m("id") = entry.id
            m.Delete()
            Return True
        End Function

        Public Function search(searchParam As IMembershipType, matchAll As Boolean, fuzzy As Boolean) As List(Of IMembershipType) Implements IDataManager(Of IMembershipType).search
            Throw New NotImplementedException()
        End Function

        Public Function updateEntry(entry As IMembershipType) As Boolean Implements IDataManager(Of IMembershipType).updateEntry
            Dim m As Membership = New Membership
            Dim im As IMembershipType = m
            m("id") = entry.id
            im.description = entry.description
            im.monthlyFees = entry.monthlyFees
            im.privilges = entry.privilges
            im.registrationFees = entry.registrationFees
            im.transferFees = entry.transferFees
            im.typeName = entry.typeName
            m.Update()
            Return True
        End Function
    End Class
End Namespace