
Partial Class _404
    Inherits BasePage

    Public aspxerrorpath As String = ""

    Private Sub _404_Load(sender As Object, e As EventArgs) Handles Me.Load
        'aspxerrorpath = Request.QueryString("aspxerrorpath")

        'If aspxerrorpath.Contains("/Admin/") Then
        '    Response.Redirect("/Admin/404.aspx")
        'End If
    End Sub
End Class
