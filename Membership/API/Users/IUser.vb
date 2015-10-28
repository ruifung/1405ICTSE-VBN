Public Interface IUser
    ReadOnly Property userID As Integer
    Property userName As String
    WriteOnly Property password As String
    Property accessLevel As Integer
End Interface
