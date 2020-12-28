
Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtFullName.Text = Nothing Then
            JsMsgBox("Full Name is required!")
        ElseIf txtBirthday.Text = Nothing Then
            JsMsgBox("Birthday is required!")
        ElseIf txtContact.Text = Nothing Then
            JsMsgBox("Contact No. is required!")
        ElseIf txtEmail.Text = Nothing Then
            JsMsgBox("Email is required!")
        ElseIf IsEmailExists(txtEmail.Text) Then
            JsMsgBox("Email is already been registered!")
        ElseIf Not IsEmailValid(txtEmail.Text) Then
            JsMsgBox("Email is not valid!")
        ElseIf txtUserID.Text = Nothing Then
            JsMsgBox("UserID is required!")
        ElseIf txtUserID.Text.Length < 6 Then
            JsMsgBox("UserID is too short!")
        ElseIf IsMemberExists(txtUserID.Text) Then
            JsMsgBox("UserID already taken, please try another one.")
        ElseIf txtPassword.Text = Nothing Then
            JsMsgBox("Password is required!")
        ElseIf txtPassword2.Text = Nothing Then
            JsMsgBox("Please confirm your password.")
        ElseIf txtPassword.Text <> txtPassword2.Text Then
            JsMsgBox("Your password did not match!")
        ElseIf Not cb18yo.Checked Then
            JsMsgBox("You have to be at least 18 years old to register.")
        ElseIf Not cbTnc.Checked Then
            JsMsgBox("Please accept the Terms & Conditions.")
        Else
            If RegisterMember() Then
                JsMsgBox("Registration completed!")
                If IsMemberLoginSuccess(txtUserID.Text, txtPassword.Text, Page) Then Response.Redirect("Default.aspx")
            Else
                JsMsgBox("Registration failed! Please contact Customer Service.")
            End If
        End If
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGender.SelectedIndexChanged

    End Sub

    Private Function RegisterMember() As Boolean
        Dim newMember As New TblMember
        With newMember
            .UserName = txtUserID.Text.Trim
            .Password = txtPassword.Text.Trim
            .Email = txtEmail.Text.Trim
            .PhoneNo = txtContact.Text.Trim
            .FullName = txtFullName.Text.Trim
            .DateOfBirth = Date.ParseExact(txtBirthday.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            .RefCode = txtUserID.Text.GetHashCode
            .RefCodeReg = txtRegRefCode.Text.Trim
            .VipLevel = 0
            .Promotion = 0F
            .DateCreated = Now
            .LastModified = Now
            .IPAddress = Request.UserHostAddress
            .GroupLeaderID = -1
            .Enabled = True
            .Remark = Nothing
        End With

        Try
            db.TblMembers.InsertOnSubmit(newMember)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


End Class
