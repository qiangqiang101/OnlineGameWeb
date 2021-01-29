Imports System.IO
Imports Microsoft.VisualBasic

Public Module Logger

    Public Sub Log(ex As Exception)
        Log(ex.Message & ex.StackTrace)
    End Sub

    Public Sub Log(message As String)
        If Not Directory.Exists(logPath) Then Directory.CreateDirectory(logPath)
        File.AppendAllText(logPath & "\Log-" & Now.Month & "-" & Now.Day & "-" & Now.Year & ".log", Now.ToString(dateFormat) & ": " & message & vbNewLine)
    End Sub

End Module
