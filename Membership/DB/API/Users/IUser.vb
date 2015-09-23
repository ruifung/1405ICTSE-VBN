Public Interface IUser
    ReadOnly Property userID As Integer
    Property userName As String
    WriteOnly Property password As String
    Function checkPassword(password As String) As Boolean
End Interface
