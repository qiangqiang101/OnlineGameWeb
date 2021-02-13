
Partial Class Admin_GeneralSettings
    Inherits System.Web.UI.Page

    Dim _logo As String = Nothing

    Private Sub Admin_GeneralSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtCompany.Text = ConfigSettings.ReadSetting(Of String)("CompanyName", "355Club")
            imgLogo.ImageUrl = "..\" & ConfigSettings.ReadSetting(Of String)("CompanyLogo", "images/logo.png")
            _logo = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "images/logo.png")
            txtCopyright.Text = ConfigSettings.ReadSetting(Of String)("CopyrightText", "© 2020 Online Game Website")
            txtRecBonusPercent.Text = ConfigSettings.ReadSetting(Of Single)("RecPercent", 0.1F).ToString("0.00")
            txtRecBonusMinAmount.Text = ConfigSettings.ReadSetting(Of Single)("RecMinAmmount", 10.0F).ToString("0.00")

            cmbTwilioEnabled.SelectedValue = ConfigSettings.ReadSetting(Of Boolean)("TwilioEnable", False)
            txtTwilioPhone.Text = ConfigSettings.ReadSetting(Of String)("TwilioPhone", "")
            txtTwilioSID.Text = ConfigSettings.ReadSetting(Of String)("TwilioSID", "")
            txtTwilioToken.Text = ConfigSettings.ReadSetting(Of String)("TwilioAuthToken", "")

            txtHTML.Text = ConfigSettings.ReadSetting(Of String)("HTMLCode", "").Base64ToString

            txtFacebook.Text = ConfigSettings.ReadSetting(Of String)("HeadFacebook", "#")
            txtTwitter.Text = ConfigSettings.ReadSetting(Of String)("HeadTwitter", "#")
            txtInstagram.Text = ConfigSettings.ReadSetting(Of String)("HeadInstagram", "#")
            txtTikTok.Text = ConfigSettings.ReadSetting(Of String)("HeadTikTok", "#")
            txtYoutube.Text = ConfigSettings.ReadSetting(Of String)("HeadYoutube", "#")
            txtWhatsapp.Text = ConfigSettings.ReadSetting(Of String)("HeadWhatsApp", "")
            txtTelegram.Text = ConfigSettings.ReadSetting(Of String)("HeadTelegram", "")
            txtWechat.Text = ConfigSettings.ReadSetting(Of String)("HeadWeChat", "")
        End If
    End Sub

    Private Sub btnHTML_Click(sender As Object, e As EventArgs) Handles btnHTML.Click
        Try
            Dim encoded As String = txtHTML.Text.ToBase64

            ConfigSettings.WriteSetting(Of String)("HTMLCode", encoded)
            swalBsRedirect("AdminLogin.aspx", "Success", "HTML is successfully saved. System will restart and your session will end.", "success")
        Catch ex As Exception
            Log(ex)
            swalBs("Oops!", ex.Message, "error")
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If fileUploader.HasFile Then
            Dim file As String = Server.MapPath(upload & fileUploader.FileName)
            Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
            Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
            If IsImage(ext) Then
                If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                fileUploader.SaveAs(file)
                _logo = fileUrl
            Else
                swalBs("Oops!", "Failed to upload image, please try again with supported image format.", "error")
                _logo = imgLogo.ImageUrl
                Exit Sub
            End If
        Else
            _logo = imgLogo.ImageUrl
        End If

        ConfigSettings.WriteSettings(New CfgWrite("CompanyName", txtCompany.Text.Trim), New CfgWrite("CopyrightText", txtCopyright.Text.Trim), New CfgWrite("CompanyLogo", If(_logo = Nothing, _logo, _logo.Trim)),
                                     New CfgWrite("RecPercent", CSng(txtRecBonusPercent.Text.Trim)), New CfgWrite("RecMinAmmount", CSng(txtRecBonusMinAmount.Text.Trim)))

        swalBsRedirect("AdminLogin.aspx", "Success", "Settings are successfully saved. System will restart and your session will end.", "success")
    End Sub

    Private Sub btnSubmitSocial_Click(sender As Object, e As EventArgs) Handles btnSubmitSocial.Click
        ConfigSettings.WriteSettings(New CfgWrite("HeadFacebook", txtFacebook.Text.Trim), New CfgWrite("HeadTwitter", txtTwitter.Text.Trim), New CfgWrite("HeadInstagram", txtInstagram.Text.Trim), New CfgWrite("HeadTikTok", txtTikTok.Text.Trim), New CfgWrite("HeadYoutube", txtYoutube.Text.Trim),
                                     New CfgWrite("HeadWhatsApp", txtWhatsapp.Text.Trim), New CfgWrite("HeadTelegram", txtTelegram.Text.Trim), New CfgWrite("HeadWeChat", txtWechat.Text.Trim))
        swalBsRedirect("AdminLogin.aspx", "Success", "Social settings are successfully saved. System will restart and your session will end.", "success")
    End Sub

    Private Sub btnSubmitTwilio_Click(sender As Object, e As EventArgs) Handles btnSubmitTwilio.Click
        ConfigSettings.WriteSettings(New CfgWrite("TwilioEnable", cmbTwilioEnabled.SelectedValue), New CfgWrite("TwilioPhone", txtTwilioPhone.Text.Trim),
                                     New CfgWrite("TwilioSID", txtTwilioSID.Text.Trim), New CfgWrite("TwilioAuthToken", txtTwilioToken.Text.Trim))
        swalBsRedirect("AdminLogin.aspx", "Success", "Twilio SMS API settings are successfully saved. System will restart and your session will end.", "success")
    End Sub
End Class
