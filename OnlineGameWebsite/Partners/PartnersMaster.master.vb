
Partial Class Partners_PartnersMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Partners_PartnersMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game") & " - Partners"

        Dim role As String = HttpContext.Current.Session("role")
        Dim partnerid As String = HttpContext.Current.Session("partnerid")

        If Not Page.IsPostBack Then
            If role = "partner" Then
                navbaruser.InnerText = Session("fullname")
                navbarProfile.HRef = "EditUser.aspx?mode=profile&id=" & partnerid
            Else
                JsMsgBox(Page, "Please Login")
                Response.Redirect("PartnerLogin.aspx")
            End If
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Abandon()
        Response.Redirect("PartnerLogin.aspx")
    End Sub
End Class

