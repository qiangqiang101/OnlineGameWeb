
Partial Class Admin_AdminMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Admin_AdminMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game") & " - Back Office"
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Clear()
        Response.Redirect("AdminLogin.aspx")
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Dim role As String = HttpContext.Current.Session("role")

        If Not Page.IsPostBack Then
            If Not role = "admin" Then
                JsMsgBox(Page, "Please Login")
                Response.Redirect("AdminLogin.aspx")
            Else
                navbaruser.InnerText = Session("fullname")
            End If
        End If
    End Sub
End Class

