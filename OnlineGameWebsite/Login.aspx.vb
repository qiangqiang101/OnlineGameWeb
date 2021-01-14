
Partial Class Login
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserID.Text = Nothing Then
            JsMsgBox("UserID is required!")
        ElseIf txtPassword.Text = Nothing Then
            JsMsgBox("Password is required!")
        Else
            If IsMemberLoginSuccess(txtUserID.Text.Trim, txtPassword.Text.Trim, Page) Then
                LogAction(txtUserID.Text.Trim, Request.UserHostAddress, eLogType.Login)
                Response.Redirect("Default.aspx")
            Else
                JsMsgBox("Incorrect UserID or Password.")
            End If
        End If
    End Sub
End Class
