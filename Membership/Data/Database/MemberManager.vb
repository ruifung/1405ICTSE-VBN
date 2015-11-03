Imports MDB
Namespace Database
    Public Class MemberManager
        Implements IDataManager(Of IMember)

        Public Function addEntry(entry As IMember) As MaybeOption(Of IMember) Implements IDataManager(Of IMember).addEntry
            Dim member As IMember = New Member
            member.address = entry.address
            member.contactNumber = entry.contactNumber
            member.dob = entry.dob
            member.email = entry.email
            member.firstName = entry.firstName
            member.gender = entry.gender
            member.isActive = entry.isActive
            member.lastName = entry.lastName
            member.membershipTypeID = entry.membershipTypeID
            member.photo = entry.photo
            DirectCast(member, Member).Insert()
            Return MaybeOption.create(member)
        End Function

        Public Function getEntry(id As Integer) As MaybeOption(Of IMember) Implements IDataManager(Of IMember).getEntry
            Dim m As IMember = Member.TryGet(id)
            Return MaybeOption.create(Of IMember)(m)
        End Function

        Public Sub init() Implements IDataManager(Of IMember).init

        End Sub

        Public Function list() As List(Of IMember) Implements IDataManager(Of IMember).list
            Return New List(Of IMember)(DBList(Of Member).Query())
        End Function

        Public Sub load() Implements IDataManager(Of IMember).load

        End Sub

        Public Function removeEntry(entry As IMember) As Boolean Implements IDataManager(Of IMember).removeEntry
            Dim m As Member = TryCast(entry, Member)
            If IsNothing(m) Then
                Throw (New ArgumentException("entry is not a Database.Member!"))
            End If
            m.Delete()
            Return True
        End Function

        Public Sub save() Implements IDataManager(Of IMember).save

        End Sub

        Public Function search(searchParam As IMember, fuzzy As Boolean) As List(Of IMember) Implements IDataManager(Of IMember).search

        End Function

        Public Function updateEntry(entry As IMember) As Boolean Implements IDataManager(Of IMember).updateEntry
            Dim m As Member = TryCast(entry, Member)
            If IsNothing(m) Then
                Throw (New ArgumentException("entry is not a Database.Member!"))
            End If
            m.Update()
            Return True
        End Function
    End Class
End Namespace