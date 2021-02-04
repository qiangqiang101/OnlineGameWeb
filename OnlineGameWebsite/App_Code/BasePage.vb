Imports System.Threading
Imports System.Globalization

Public Class BasePage
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        Dim language As String = "en-US"

        If Request.Cookies("Lang") Is Nothing Then
            With Response.Cookies("Lang")
                .Value = "en-US"
                .Expires = Now.AddYears(1)
            End With
        End If
        language = Request.Cookies("Lang").Value

        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
    End Sub

End Class
