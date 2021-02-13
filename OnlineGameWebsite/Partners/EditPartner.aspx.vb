
Partial Class Partners_EditPartner
    Inherits System.Web.UI.Page

    Private Sub Partners_EditPartner_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim partnerid As String = HttpContext.Current.Session("partnerid")

        If Not IsPostBack Then
            Try
                Using db As New DataClassesDataContext
                    Dim a = db.TblAffiliates.Single(Function(x) x.AffiliateID = CInt(partnerid))
                    txtUserName.Text = a.UserName.Trim
                    txtPassword.Text = a.Password.Trim
                    txtFullName.Text = a.FullName.Trim
                    txtEmail.Text = a.Email.Trim
                    txtCode.Text = a.Code.Trim
                    txtPhoneNo.Text = a.PhoneNo.Trim

                    txtCode.ReadOnly = True
                    txtUserName.ReadOnly = True

                    h6.InnerText = "Edit Profile"
                    h1.InnerText = "My Profile"
                End Using
            Catch ex As Exception
                Log(ex)
                swalBs("Oops!", "This Partner ID does not exist.", "error")
                btnSubmit.Enabled = False
            End Try
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Using db As New DataClassesDataContext
            If TryEditUser() Then
                swalBsRedirect("Default.aspx", "Success", "This Partner is successfully update.", "success")
            Else
                swalBs("Oops!", "Failed to edit this Partner, Please contact Administrator.", "error")
            End If
        End Using
    End Sub

    Private Function TryEditUser() As Boolean
        Dim partnerid As String = HttpContext.Current.Session("partnerid")

        Try
            Using db As New DataClassesDataContext
                Dim editUser = db.TblAffiliates.Single(Function(x) x.AffiliateID = CInt(partnerid))
                With editUser
                    .Password = txtPassword.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .Email = txtEmail.Text.Trim
                    .PhoneNo = txtPhoneNo.Text.Trim
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

End Class
