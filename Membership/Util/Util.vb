Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Text
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

    Public Function GetImageFilter() As String
        Dim allImageExtensions As New StringBuilder()
        Dim separator As String = ""
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        Dim images As New Dictionary(Of String, String)()
        For Each codec As ImageCodecInfo In codecs
            allImageExtensions.Append(separator)
            allImageExtensions.Append(codec.FilenameExtension.ToLower)
            separator = ";"
            images.Add(String.Format("{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension.ToLower), codec.FilenameExtension.ToLower)
        Next
        Dim sb As New StringBuilder()
        If allImageExtensions.Length > 0 Then
            sb.AppendFormat("{0}|{1}", "All Images", allImageExtensions.ToString())
        End If
        images.Add("All Files", "*.*")
        For Each image As KeyValuePair(Of String, String) In images
            sb.AppendFormat("|{0}|{1}", image.Key, image.Value)
        Next
        Return sb.ToString()
    End Function
End Module
