Imports System.Data.OleDb
Imports MDB
Namespace Database
    Public Class MemberManager
        Implements IDataManager(Of IMember)

        Public Function addEntry(entry As IMember) As MaybeOption(Of IMember) Implements IDataManager(Of IMember).addEntry
            Dim member = New Member
            member.setAll(entry)
            member.Insert()
            Return MaybeOption.create(DirectCast(member, IMember))
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
            Dim m As Member = If(TryCast(entry, Member), Member.TryGet(entry.id))
            Util.exec(m, Sub(x) x.Delete())
            Return Not IsNothing(m)
        End Function

        Public Sub save() Implements IDataManager(Of IMember).save

        End Sub

        Public Function search(searchParam As IMember, matchAll As Boolean, fuzzyMatching As Boolean) As List(Of IMember) Implements IDataManager(Of IMember).search
            Dim criteria As String = ""
            Dim match_op As String = If(fuzzyMatching, " Like ", "=")
            Dim params As List(Of OleDbParameter) = New List(Of OleDbParameter)
            If fuzzyMatching Then
                If searchParam.firstName IsNot Nothing Then searchParam.firstName = String.Format("*{0}*", searchParam.firstName)
                If searchParam.lastName IsNot Nothing Then searchParam.lastName = String.Format("*{0}*", searchParam.lastName)
                If searchParam.email IsNot Nothing Then searchParam.email = String.Format("*{0}*", searchParam.email)
                If searchParam.contactNumber IsNot Nothing Then searchParam.contactNumber = String.Format("*{0}*", searchParam.contactNumber)
            End If
            If matchAll Then
                criteria += "firstname{0}? OR "
                criteria += "lastname{0}? OR "
                criteria += "email{0}? OR "
                criteria += "contact{0}?"
                params.Add(MDBType.Text.asParam(searchParam.firstName))
                params.Add(MDBType.Text.asParam(searchParam.lastName))
                params.Add(MDBType.Text.asParam(searchParam.email))
                params.Add(MDBType.Text.asParam(searchParam.contactNumber))
            Else
                If searchParam.firstName IsNot Nothing Then
                    criteria += "firstname{0}?"
                    params.Add(MDBType.Text.asParam(searchParam.firstName))
                ElseIf searchParam.lastName IsNot Nothing Then
                    criteria += "lastname{0}?"
                    params.Add(MDBType.Text.asParam(searchParam.lastName))
                ElseIf searchParam.email IsNot Nothing Then
                    criteria += "email{0}?"
                    params.Add(MDBType.Text.asParam(searchParam.email))
                Else
                    criteria += "contact{0}?"
                    params.Add(MDBType.Text.asParam(searchParam.contactNumber))
                End If
            End If
            criteria = String.Format(criteria, match_op)
            Return New List(Of IMember)(DBList(Of Member).Query(criteria, params.ToArray()))
        End Function

        Public Function updateEntry(entry As IMember) As Boolean Implements IDataManager(Of IMember).updateEntry
            Dim m As Member = TryCast(entry, Member)
            If IsNothing(m) Then
                m = Member.TryGet(entry.id)
                Util.exec(m, Sub(x) x.setAll(entry))
            End If
            Util.exec(m, Sub(x) x.Update())
            Return Not IsNothing(m)
        End Function

        Public Function count() As ULong Implements IDataManager(Of IMember).count
            Return CType(DBList(Of Member).RowsCount(), ULong)
        End Function
    End Class
End Namespace