Public Interface IMember
    ReadOnly Property id As Integer
    Property firstName As String
    Property lastName As String
    Property contactNumber As String
    Property email As String
    Property photo As MaybeOption(Of Image)

    Property isActive As Boolean
    Property membershipTypeID As Integer
End Interface
