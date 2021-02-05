
Partial Class MyProfile
    Inherits BasePage

    Private Sub MyProfile_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            LoginMsgBox
        Else
            If Not IsPostBack Then
                Try
                    Using db As New DataClassesDataContext
                        Dim m = db.TblMembers.Single(Function(x) x.UserID = CInt(Session("userid")))
                        txtUserID.Text = m.UserName.Trim
                        txtEmail.Text = m.Email.Trim
                        txtPhone.Text = m.PhoneNo.Trim
                        txtFullName.Text = m.FullName.Trim
                        txtBirthday.Text = m.DateOfBirth.ToString("yyyy-MM-dd")
                        txtRefCode.Text = m.RefCode.Trim
                        cmbBank.SelectedValue = m.BankName
                        txtBankAccNo.Text = If(m.AccountNo = Nothing, Nothing, m.AccountNo.Trim)
                    End Using
                Catch ex As Exception
                    Log(ex)
                    swal("Oops!", "Something went wrong, please contact customer service.", "error")
                End Try
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Using db As New DataClassesDataContext
                Dim editMember = db.TblMembers.Single(Function(x) x.UserID = CInt(Session("userid")))
                With editMember
                    .Email = txtEmail.Text.Trim
                    .PhoneNo = txtPhone.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .DateOfBirth = Date.ParseExact(txtBirthday.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    .LastModified = Now
                    .BankName = cmbBank.SelectedValue
                    .AccountNo = txtBankAccNo.Text.Trim
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            swal("Oops!", "Something went wrong, please contact customer service.", "error")
        End Try

        swalRedirect("MyProfile.aspx", "Success", "Your profile has updated successfully.", "success")
    End Sub
End Class
