Imports System.ComponentModel
''' <summary>
''' Utility methods.
''' </summary>
Module Util
    ''' <summary>
    ''' Executes a Action on an Object if it is not null.
    ''' </summary>
    ''' <typeparam name="T">Type of object to execute on.</typeparam>
    ''' <param name="obj">Object to execute on.</param>
    ''' <param name="func">Function to execute.</param>
    Sub exec(Of T)(obj As T, func As Action(Of T))
        If obj IsNot Nothing AndAlso func IsNot Nothing Then
            func(obj)
        End If
    End Sub
    ''' <summary>
    ''' Executes a Func on an Object if it is not null/
    ''' </summary>
    ''' <typeparam name="T">Type of object to execute on.</typeparam>
    ''' <typeparam name="R">Return value type.</typeparam>
    ''' <param name="obj">Object to execute on.</param>
    ''' <param name="func">Function to execute.</param>
    ''' <returns></returns>
    Function exec(Of T, R)(obj As T, func As Func(Of T, R)) As R
        If obj IsNot Nothing AndAlso func IsNot Nothing Then
            Return func(obj)
        Else
            Return Nothing
        End If
    End Function

    Function IsInDesignMode() As Boolean
        Dim designMode = LicenseManager.UsageMode = LicenseUsageMode.Designtime
        If Not designMode Then
            Using proc = Process.GetCurrentProcess
                Return proc.ProcessName.ToLowerInvariant.Contains("devenv")
            End Using
        End If
        Return designMode
    End Function
End Module
