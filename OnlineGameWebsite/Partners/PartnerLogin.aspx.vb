
Partial Class Partners_PartnerLogin
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserID.Text = Nothing Then
            swalBs("Oops!", "Please enter your User ID.", "error")
        ElseIf txtPassword.Text = Nothing Then
            swalBs("Oops!", "Please enter your password.", "error")
        Else
            If IsPartnerLoginSuccess(txtUserID.Text.Trim, txtPassword.Text.Trim, Page) Then
                UpdatePartnerLastLogin(txtUserID.Text.Trim, Request.UserHostAddress)
                Response.Redirect("Default.aspx")
            Else
                swalBs("Oops!", "The User ID or Password you entered is incorrect.", "error")
            End If
        End If
    End Sub
End Class
