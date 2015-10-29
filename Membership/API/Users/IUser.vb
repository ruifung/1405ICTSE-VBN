Public Interface IUser
    Inherits IDataElement

    Property userName As String
    Property password As String
    ReadOnly Property passwordHashed As Boolean
    Property accessLevel As Integer

    Function verifyPass(pass As String) As Boolean
End Interface
