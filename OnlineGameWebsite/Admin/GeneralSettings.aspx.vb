
Partial Class Admin_GeneralSettings
    Inherits System.Web.UI.Page

    Dim _logo As String = Nothing

    Private Sub Admin_GeneralSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtCompany.Text = settings.CompanyName
            imgLogo.ImageUrl = "..\" & settings.CompanyLogo
            _logo = settings.CompanyLogo

            txtRecBonusPercent.Text = settings.RecommendPercentage.ToString("0.00")
            txtRecBonusMinAmount.Text = settings.RecommendMinimumAmount.ToString("0.00")
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If fileUpload.HasFile Then
            Dim file As String = Server.MapPath(upload & fileUpload.FileName)
            Dim fileUrl As String = (upload & fileUpload.FileName).Replace("~/", "")
            Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
            If IsImage(ext) Then
                If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                fileUpload.SaveAs(file)
                _logo = fileUrl
            Else
                JsMsgBox("Image upload failed, please try upload only supported image format.")
                _logo = Nothing
                Exit Sub
            End If
        Else
            _logo = _logo
        End If

        settings = New SettingsData(HttpRuntime.AppDomainAppPath & "\settings.xml")
        With settings
            .CompanyName = txtCompany.Text.Trim
            .CompanyLogo = _logo
            .RecommendPercentage = CSng(txtRecBonusPercent.Text.Trim)
            .RecommendMinimumAmount = CSng(txtRecBonusMinAmount.Text.Trim)
        End With
        settings.Save()
        JsMsgBox("Settings saved successfully.")
    End Sub
End Class
