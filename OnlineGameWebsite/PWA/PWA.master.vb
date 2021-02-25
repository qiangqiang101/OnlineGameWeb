
Partial Class PWA_PWA
    Inherits System.Web.UI.MasterPage

    Private Sub PWA_PWA_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        siteTitle.InnerText = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        headerTitle.InnerText = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game").Split(" "c)(0)
    End Sub
End Class

