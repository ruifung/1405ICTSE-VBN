Public Interface IMemberCharge
    Inherits IDataElement
    Property memberID As Integer
    Property timestamp As Date
    Property description As String
    Property amount As Decimal
    Property paid As Boolean
End Interface
