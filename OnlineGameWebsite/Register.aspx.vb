
Partial Class Register
    Inherits System.Web.UI.Page

    Public ref As String = ""
    Public agent As String = ""

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If IsEmailExists(txtEmail.Text) Then
            swal("Oops!", "Email is already been registered!", "error")
        ElseIf Not IsEmailValid(txtEmail.Text) Then
            swal("Oops!", "Email is not valid!", "error")
        ElseIf txtUserID.Text.Length < 6 Then
            swal("Oops!", "UserID is too short!", "error")
        ElseIf IsMemberExists(txtUserID.Text) Then
            swal("Oops!", "UserID already taken, please try another one.", "error")
        ElseIf txtPassword.Text <> txtPassword2.Text Then
            swal("Oops!", "Your password do not match!", "error")
        ElseIf Not cb18yo.Checked Then
            swal("Underage warning", "You have to be at least 18 years old to register.", "warning")
        ElseIf Not cbTnc.Checked Then
            swal("Terms & Conditions", "Please accept the Terms & Conditions in order to continue.", "warning")
        Else
            If RegisterMember() Then
                LogAction(txtUserID.Text.Trim, Request.UserHostAddress, eLogType.Register)
                If IsMemberLoginSuccess(txtUserID.Text, txtPassword.Text, Page) Then
                    LogAction(txtUserID.Text.Trim, Request.UserHostAddress, eLogType.Login)
                    Response.Redirect("Default.aspx")
                End If
            Else
                swal("Oops!", "Registration failed! Please contact Customer Service.", "error")
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
                    .Affiliate = agent.Trim
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

    Private Function LoadPromotions(text As String, icon As String) As HtmlGenericControl
        Dim i = New HtmlGenericControl("i")
        With i
            .Attributes("class") = "fa fa-" & icon
        End With
        Dim li = New HtmlGenericControl("li")
        With li
            .InnerText = text.Trim
            .Controls.Add(i)
        End With
        Return li
    End Function

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles Me.Load
        ref = Request.QueryString("ref")
        agent = Request.QueryString("agent")

        txtRegRefCode.Text = ref

        Using db As New DataClassesDataContext
            Dim promos = db.TblPromotions.Where(Function(x) x.Status = 1).ToList
            For Each promo As TblPromotion In promos
                benefitsList.Controls.Add(LoadPromotions(promo.EnglishName, "star"))
            Next
        End Using
    End Sub
End Class
