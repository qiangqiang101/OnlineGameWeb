
Partial Class Partners_AddMember
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtFullName.Text = Nothing Then
            swalBs("Oops!", "Please enter Full Name.", "error")
        ElseIf txtBirthday.Text = Nothing Then
            swalBs("Oops!", "Please enter Birthday.", "error")
        ElseIf txtPhone.Text = Nothing Then
            swalBs("Oops!", "Please enter Phone Contact Number.", "error")
        ElseIf txtEmail.Text = Nothing Then
            swalBs("Oops!", "Please enter Email Address.", "error")
        ElseIf IsEmailExists(txtEmail.Text) Then
            swalBs("Oops!", "This Email is already exist.", "error")
        ElseIf txtUserID.Text = Nothing Then
            swalBs("Oops!", "Please enter User ID.", "error")
        ElseIf txtUserID.Text.Length < 6 Then
            swalBs("Oops!", "User ID is too short, please enter at least 6 characters.", "error")
        ElseIf IsMemberExists(txtUserID.Text) Then
            swalBs("Oops!", "User ID you entered is already taken, please try again.", "error")
        ElseIf txtPassword.Text = Nothing Then
            swalBs("Oops!", "Please enter Password.", "error")
        Else
            If RegisterMember() Then
                swalBsRedirect("Members.aspx", "Success", "This member is successfully created.", "success")
            Else
                swalBs("Oops!", "Failed to create account! Please contact Adminstrator.", "error")
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
