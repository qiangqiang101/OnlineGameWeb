
Partial Class Partners_PartnersMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Partners_PartnersMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game") & " - Partners"

        Dim role As String = HttpContext.Current.Session("role")

        If Not Page.IsPostBack Then
            If role = "partner" Then
                navbaruser.InnerText = Session("fullname")
                navbarProfile.HRef = "EditPartner.aspx"
            Else
                Page.swalBsRedirect("PartnerLogin.aspx", "Hello", "Please Login to continue.", "warning")
            End If
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Abandon()
        Response.Redirect("PartnerLogin.aspx")
    End Sub
End Class

