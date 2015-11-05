Imports System.ComponentModel

Public Interface IMemberCharge
    Inherits IDataElement

    <DisplayName("Member ID")>
    Property memberID As Integer
    <DisplayName("Timestamp")>
    Property timestamp As Date
    <DisplayName("Description")>
    Property description As String
    <DisplayName("Amount")>
    Property amount As Decimal
    <DisplayName("Settled")>
    Property paid As Boolean
End Interface
