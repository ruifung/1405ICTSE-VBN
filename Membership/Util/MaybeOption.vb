Imports Membership


Public Module MaybeOption
    ''' <summary>
    ''' Get either a Some or a None based on the value passed in.
    ''' </summary>
    ''' <typeparam name="Type"></typeparam>
    ''' <param name="item"></param>
    ''' <returns>Some or None</returns>
    Function create(Of Type As Class)(item As Type) As MaybeOption(Of Type)
        If IsNothing(item) Then
            Return New None(Of Type)
        Else
            Return New Some(Of Type)(item)
        End If
    End Function

End Module

''' <summary>
''' Option implementation.
''' Inspired by scala.
''' </summary>
''' <typeparam name="T">Type of value this Option contains.</typeparam>
''' 
Public MustInherit Class MaybeOption(Of T As Class)

    ''' <summary>
    ''' Checks if the MaybeOption is empty
    ''' </summary>
    ''' <returns>True if its empty.</returns>
    MustOverride Function isEmpty() As Boolean

    ''' <summary>
    ''' Checks if the MaybeOption contains a value.
    ''' </summary>
    ''' <returns>True if it contains a value.</returns>
    MustOverride Function isDefined() As Boolean

    ''' <summary>
    ''' Maps the contents of a MaybeOption to another type.
    ''' </summary>
    ''' <typeparam name="R">Type to map to.</typeparam>
    ''' <param name="mapFunc">Map function</param>
    ''' <returns>Some(Of R) or None</returns>
    MustOverride Function map(Of R As Class)(mapFunc As Func(Of T, R)) As MaybeOption(Of R)
    ''' <summary>
    ''' Similar to map except the map function must return a MaybeOption
    ''' </summary>
    ''' <typeparam name="R">Type to map to.</typeparam>
    ''' <param name="mapFunc">Map function</param>
    ''' <returns></returns>
    MustOverride Function flatMap(Of R As Class)(mapFunc As Func(Of T, MaybeOption(Of R))) As MaybeOption(Of R)

    ''' <summary>
    ''' Does an action on the contents.
    ''' </summary>
    ''' <param name="action">Action to execute.</param>
    MustOverride Sub forEach(action As Action(Of T))

    ''' <summary>
    ''' Gets the value.
    ''' Throws a InvalidOperationException if its empty.
    ''' </summary>
    ''' <returns>Value contained.</returns>
    MustOverride Function getValue() As T
    ''' <summary>
    ''' Gets the value - or returns an alternative value.
    ''' </summary>
    ''' <param name="alternative">Alternative value</param>
    ''' <returns>Contained value or alternative value if empty.</returns>
    MustOverride Function getOrAlt(alternative As T) As T
    ''' <summary>
    ''' Gets a MaybeOption alternative if empty.
    ''' </summary>
    ''' <param name="altnernative">Alternative Option Value</param>
    ''' <returns>This object, or alternative if empty.</returns>
    MustOverride Function orAlt(altnernative As MaybeOption(Of T)) As MaybeOption(Of T)
    ''' <summary>
    ''' Gets the value, returns Nothing if empty.
    ''' </summary>
    ''' <returns>Contained value, Nothing if None.</returns>
    MustOverride Function orNothing() As T

    ''' <summary>
    ''' Turns a Some into a None depending if it matches the predicate.
    ''' </summary>
    ''' <param name="filterFunc">Predicate used for matching.</param>
    ''' <returns>MaybeOption result of filter. None if None.</returns>
    MustOverride Function filter(filterFunc As Predicate(Of T)) As MaybeOption(Of T)

    ''' <summary>
    ''' Does contents match the predicate?
    ''' </summary>
    ''' <param name="predicate">Match function</param>
    ''' <returns>Return value of predicate. - false if None</returns>
    MustOverride Function exists(predicate As Predicate(Of T)) As Boolean

    ''' <summary>
    ''' Does all contents match the predicate?
    ''' </summary>
    ''' <param name="predicate"></param>
    ''' <returns>Return value of predicate - true if None</returns>
    MustOverride Function forAll(predicate As Predicate(Of T)) As Boolean
End Class


Public Class Some(Of SomeType As Class)
    Inherits MaybeOption(Of SomeType)

    Private item As SomeType

    Sub New(obj As SomeType)
        item = obj
    End Sub

    Public Overrides Function flatMap(Of R As Class)(mapFunc As Func(Of SomeType, MaybeOption(Of R))) As MaybeOption(Of R)
        Return mapFunc(item)
    End Function

    Public Overrides Sub forEach(action As Action(Of SomeType))
        action(item)
    End Sub

    Public Overrides Function getOrAlt(alternative As SomeType) As SomeType
        Return item
    End Function

    Public Overrides Function getValue() As SomeType
        Return item
    End Function

    Public Overrides Function isDefined() As Boolean
        Return True
    End Function

    Public Overrides Function isEmpty() As Boolean
        Return False
    End Function

    Public Overrides Function map(Of R As Class)(mapFunc As Func(Of SomeType, R)) As MaybeOption(Of R)
        Return New Some(Of R)(mapFunc(item))
    End Function

    Public Overrides Function orAlt(altnernative As MaybeOption(Of SomeType)) As MaybeOption(Of SomeType)
        Return Me
    End Function

    Public Overrides Function orNothing() As SomeType
        Return item
    End Function

    Public Overrides Function filter(filterFunc As Predicate(Of SomeType)) As MaybeOption(Of SomeType)
        If (filterFunc(item)) Then
            Return Me
        Else
            Return New None(Of SomeType)
        End If
    End Function

    Public Overrides Function exists(predicate As Predicate(Of SomeType)) As Boolean
        Return predicate(item)
    End Function

    Public Overrides Function forAll(predicate As Predicate(Of SomeType)) As Boolean
        Return predicate(item)
    End Function
End Class

Public Class None(Of SomeType As Class)
    Inherits MaybeOption(Of SomeType)

    Public Overrides Function flatMap(Of R As Class)(mapFunc As Func(Of SomeType, MaybeOption(Of R))) As MaybeOption(Of R)
        Return New None(Of R)
    End Function

    Public Overrides Sub forEach(action As Action(Of SomeType))
    End Sub

    Public Overrides Function getOrAlt(alternative As SomeType) As SomeType
        Return alternative
    End Function

    Public Overrides Function getValue() As SomeType
        Throw New InvalidOperationException()
    End Function

    Public Overrides Function isDefined() As Boolean
        Return False
    End Function

    Public Overrides Function isEmpty() As Boolean
        Return True
    End Function

    Public Overrides Function map(Of R As Class)(mapFunc As Func(Of SomeType, R)) As MaybeOption(Of R)
        Return New None(Of R)
    End Function

    Public Overrides Function orAlt(altnernative As MaybeOption(Of SomeType)) As MaybeOption(Of SomeType)
        Return altnernative
    End Function

    Public Overrides Function orNothing() As SomeType
        Return Nothing
    End Function

    Public Overrides Function filter(filterFunc As Predicate(Of SomeType)) As MaybeOption(Of SomeType)
        Return Me
    End Function

    Public Overrides Function exists(predicate As Predicate(Of SomeType)) As Boolean
        Return False
    End Function

    Public Overrides Function forAll(predicate As Predicate(Of SomeType)) As Boolean
        Return True
    End Function
End Class
