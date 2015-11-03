Public Interface IMemberCharge
    Inherits IDataElement
    Property memberID As Integer
    Property timestamp As Date
    Property description As String
    Property amount As Double
    Property paid As Boolean
End Interface
