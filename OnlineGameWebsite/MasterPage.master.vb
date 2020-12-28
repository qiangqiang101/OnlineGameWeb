Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public WriteOnly Property LiveGamesLink As String
        Set(ByVal value As String)
            lnkLive.Attributes.Add("class", value)
        End Set
    End Property

    Public WriteOnly Property SportsbookLink As String
        Set(ByVal value As String)
            lnkSport.Attributes.Add("class", value)
        End Set
    End Property

    Public WriteOnly Property OthersLink As String
        Set(ByVal value As String)
            lnkOther.Attributes.Add("class", value)
        End Set
    End Property

    Public WriteOnly Property PromotionLink As String
        Set(ByVal value As String)
            lnkPromo.Attributes.Add("class", value)
        End Set
    End Property

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        Select Case role
            Case "user"
                btnLogin.Visible = False
                btnRegister.Visible = False
                navbardrop.InnerText = "Hello, " & Session("fullname")
                lnkMemberPagesDropdown.Visible = True
                lnkAdminDb.Visible = False
                btnLogout.Visible = True
            Case "admin"
                btnLogin.Visible = False
                btnRegister.Visible = False
                navbardrop.InnerText = "Hello, " & Session("fullname")
                lnkMemberPagesDropdown.Visible = True
                lnkAdminDb.Visible = True
                btnLogout.Visible = True
            Case Else
                btnLogin.Visible = True
                btnRegister.Visible = True
                lnkMemberPagesDropdown.Visible = False
                btnLogout.Visible = False
        End Select

        Select Case Request.FilePath.ToLower
            Case "/default.aspx"
                lnkHome.Attributes.Add("class", "nav-link active")
            Case "/slotgames.aspx"
                lnkSlot.Attributes.Add("class", "nav-link active")
            Case Else

        End Select
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Clear()
        Response.Redirect("Default.aspx")
    End Sub
End Class

