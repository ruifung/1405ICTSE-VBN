Public Interface IMemberTransaction
    Inherits IDataElement
    Property memberID As Integer
    Property timestamp As Date
    Property description As String
    Property completed As Boolean
End Interface
