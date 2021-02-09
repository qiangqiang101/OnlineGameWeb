
Partial Class Partners_AddMember
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtFullName.Text = Nothing Then
            JsMsgBox("Full Name is required!")
        ElseIf txtBirthday.Text = Nothing Then
            JsMsgBox("Birthday is required!")
        ElseIf txtPhone.Text = Nothing Then
            JsMsgBox("Contact No. is required!")
        ElseIf txtEmail.Text = Nothing Then
            JsMsgBox("Email is required!")
        ElseIf IsEmailExists(txtEmail.Text) Then
            JsMsgBox("Email is already been registered!")
        ElseIf txtUserID.Text = Nothing Then
            JsMsgBox("UserID is required!")
        ElseIf txtUserID.Text.Length < 6 Then
            JsMsgBox("UserID is too short!")
        ElseIf IsMemberExists(txtUserID.Text) Then
            JsMsgBox("UserID already taken, please try another one.")
        ElseIf txtPassword.Text = Nothing Then
            JsMsgBox("Password is required!")
        Else
            If RegisterMember() Then
                JsMsgBoxRedirect("Member created successfully.", "Members.aspx")
            Else
                JsMsgBox("Registration failed! Please contact Administrator.")
            End If
        End If
    End Sub

    Private Function RegisterMember() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newMember As New TblMember
                With newMember
                    .UserName = txtUserID.Text.Trim
                    .Password = txtPassword.Text.Trim
                    .Email = txtEmail.Text.Trim
                    .PhoneNo = txtPhone.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .DateOfBirth = Date.ParseExact(txtBirthday.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    .RefCode = txtUserID.Text.GetHashCode
                    .RefCodeReg = txtRegRefCode.Text.Trim
                    .VipLevel = 0
                    .Promotion = 0F
                    .DateCreated = Now
                    .LastModified = Now
                    .IPAddress = "127.0.0.1"
                    .GroupLeaderID = -1
                    .Enabled = CBool(cmbEnabled.SelectedValue)
                    .Remark = txtRemarks.Text.Trim
                    .Affiliate = Session("code").ToString.Trim
                End With

                db.TblMembers.InsertOnSubmit(newMember)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
        Return True
    End Function

End Class
