Imports System.ComponentModel

Public Interface IMember
    Inherits IDataElement

    Property firstName As String
    Property lastName As String
    Property contactNumber As String
    Property address As String
    Property email As String
    ''' <summary>
    ''' Use Date.MinValue if absent.
    ''' </summary>
    ''' <returns></returns>
    Property dob As Date
    Property gender As Gender
    Property photo As MaybeOption(Of Image)
    Property isActive As Boolean
    Property membershipTypeID As Integer

    Property paymentCredit As Double
End Interface

Public Enum Gender
    NONE
    Male
    Female
    Other
End Enum