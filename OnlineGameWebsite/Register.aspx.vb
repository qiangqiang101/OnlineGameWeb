
Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtFullName.Text = Nothing Then
            MsgBox("Full Name is required!", Me.Page, Me)
        ElseIf txtBirthday.Text = Nothing Then
            MsgBox("Birthday is required!", Me.Page, Me)
        ElseIf txtContact.Text = Nothing Then
            MsgBox("Contact No. is required!", Me.Page, Me)
        ElseIf txtEmail.Text = Nothing Then
            MsgBox("Email is required!", Me.Page, Me)
        ElseIf txtUserID.Text = Nothing Then
            MsgBox("UserID is required!", Me.Page, Me)
        ElseIf txtPassword.Text = Nothing Then
            MsgBox("Password is required!", Me.Page, Me)
        ElseIf txtPassword2.Text = Nothing Then
            MsgBox("Please confirm your password.", Me.Page, Me)
        ElseIf txtPassword.Text <> txtPassword2.Text Then
            MsgBox("Your password did not match!", Me.Page, Me)
        Else
            MsgBox("Registration completed!", Me.Page, Me)
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class
