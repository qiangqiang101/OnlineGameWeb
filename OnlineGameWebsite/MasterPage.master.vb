Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub btnHead_Click(sender As Object, e As EventArgs) Handles btnHead.Click
        Dim role As String = HttpContext.Current.Session("role")

        Select Case role
            Case "user", "admin"
                Response.Redirect("Deposit.aspx")
            Case Else
                Response.Redirect("Register.aspx")
        End Select
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserID.Text = Nothing Then
            JsMsgBox(Me.Page, "UserID is required!")
        ElseIf txtPassword.Text = Nothing Then
            JsMsgBox(Me.Page, "Password is required!")
        Else
            If IsMemberLoginSuccess(txtUserID.Text.Trim, txtPassword.Text.Trim, Page) Then
                LogAction(txtUserID.Text.Trim, Request.UserHostAddress, eLogType.Login)
                Response.Redirect("Default.aspx")
            Else
                JsMsgBox(Me.Page, "Incorrect UserID or Password.")
            End If
        End If
    End Sub

    Private Sub logout_ServerClick(sender As Object, e As EventArgs) Handles logout.ServerClick
        Session.Clear()
        Response.Redirect("Default.aspx")
    End Sub

    'Public WriteOnly Property LiveGamesLink As String
    '    Set(ByVal value As String)
    '        lnkLive.Attributes.Add("class", value)
    '    End Set
    'End Property

    'Public WriteOnly Property SportsbookLink As String
    '    Set(ByVal value As String)
    '        lnkSport.Attributes.Add("class", value)
    '    End Set
    'End Property

    'Public WriteOnly Property OthersLink As String
    '    Set(ByVal value As String)
    '        lnkOther.Attributes.Add("class", value)
    '    End Set
    'End Property

    'Public WriteOnly Property PromotionLink As String
    '    Set(ByVal value As String)
    '        lnkPromo.Attributes.Add("class", value)
    '    End Set
    'End Property

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        siteLogo.Src = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "Theme/img/logo.png")
        siteLogo2.src = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "Theme/img/logo.png")
        siteTitle.InnerText = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        copyright.InnerText = ConfigSettings.ReadSetting(Of String)("CopyrightText", "Copyright 2020. All Rights Reserved.")

        If Not IsPostBack Then

        End If

        Dim role As String = HttpContext.Current.Session("role")

        Select Case role
            Case "user", "admin"
                memberLogin.Visible = False
                memberMenu.Visible = True
                memberName.Visible = True
                memberName.InnerText = "Hello, " & Session("fullname")
                btnHead.Text = "Deposit"
            Case Else
                memberLogin.Visible = True
                memberMenu.Visible = False
                memberName.Visible = False
                btnHead.Text = "Sign Up Now"
        End Select

        'Select Case Request.FilePath.ToLower
        '    Case "/default.aspx"
        '        lnkHome.Attributes.Add("class", "nav-link active")
        '    Case "/slotgames.aspx"
        '        lnkSlot.Attributes.Add("class", "nav-link active")
        '    Case Else

        'End Select
    End Sub

    'Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
    '    Session.Clear()
    '    Response.Redirect("Default.aspx")
    'End Sub
End Class

