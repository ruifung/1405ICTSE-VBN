Imports Membership

Partial Public Class DB
    Public Class UserManager
        Implements IDataManager(Of IUser)

        Public Function addUser(userToAdd As IUser) As MaybeOption(Of IUser) Implements IDataManager(Of IUser).addEntry
            If userToAdd.passwordHashed Then
                Throw New ArgumentException("Password must be in plaintext!")
            End If
            Try
                Dim user As User = New User()
                user.userName = userToAdd.userName
                user.password = userToAdd.password
                user.permmission = userToAdd.accessLevel
                user.Insert()
                Return New Some(Of IUser)(user)
            Catch ex As Exception
                Return New None(Of IUser)
            End Try
        End Function

        Public Function delUser(toDel As IUser) As Boolean Implements IDataManager(Of IUser).removeEntry
            Dim theUser As User
            theUser = User.TryGet("username", toDel.userName)
            If IsNothing(theUser) And toDel.id >= 0 Then
                theUser = User.TryGet(toDel.id)
            End If
            If IsNothing(theUser) Then Return False
            theUser.Delete()
            Return True
        End Function

        Public Function getUser(id As Integer) As MaybeOption(Of IUser) Implements IDataManager(Of IUser).getEntry
            Return MaybeOption.create(DirectCast(User.TryGet(id), IUser))
        End Function

        Public Function getUsers() As List(Of IUser) Implements IDataManager(Of IUser).list
            Dim list As New List(Of IUser)(DB.DBList(Of User).Query())
            Return list
        End Function

        Public Function updateEntry(entry As IUser) As Boolean Implements IDataManager(Of IUser).updateEntry
            If TypeOf entry Is User Then
                DirectCast(entry, User).Update()
                Return True
            ElseIf Not entry.passwordHashed Then
                Dim theUser As User = Nothing
                If entry.id >= 0 Then
                    theUser = User.TryGet(entry.id)
                ElseIf Not IsNothing(entry.userName)
                    theUser = User.TryGet("username", entry.userName)
                End If
                If IsNothing(theUser) Then
                    Return False
                End If
                If Not IsNothing(entry.userName) Then
                    theUser.userName = entry.userName
                End If
                If Not IsNothing(entry.password) Then
                    theUser.password = entry.password
                End If
                If entry.accessLevel > 0 Then
                    theUser.permmission = entry.accessLevel
                End If
            Else
                Throw New ArgumentException("User must either be a DB user, or a PlainText user.")
            End If
        End Function

        Public Function search(searchParam As IUser, fuzzy As Boolean) As List(Of IUser) Implements IDataManager(Of IUser).search
            Throw New NotImplementedException()
        End Function

        Public Sub init() Implements IDataManager(Of IUser).init

        End Sub

        Public Sub load() Implements IDataManager(Of IUser).load

        End Sub

        Public Sub save() Implements IDataManager(Of IUser).save

        End Sub
    End Class
End Class
