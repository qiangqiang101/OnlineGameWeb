Imports Microsoft.VisualBasic

Public Module Helper

    Public Sub MsgBox(text As String, page As Page, obj As Object)
        Dim s As String = "<SCRIPT language='javascript'>alert('" + text.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>"
        Dim cstype As Type = obj.GetType()
        Dim cs As ClientScriptManager = page.ClientScript
        cs.RegisterClientScriptBlock(cstype, s, s.ToString)
    End Sub

End Module
