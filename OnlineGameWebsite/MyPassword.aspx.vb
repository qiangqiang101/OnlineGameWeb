
Partial Class MyPassword
    Inherits BasePage

    Private Sub MyPassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")
        If role <> "user" Then LoginMsgBox
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Using db As New DataClassesDataContext
                Dim member = db.TblMembers.Single(Function(x) x.UserID = CInt(Session("userid")))
                Dim password As String = member.Password.Trim

                If txtOldPassword.Text.Trim <> password Then
                    swal("Oops!", "Current Password is incorrect.", "error")
                ElseIf txtNewPassword.Text.Trim <> txtConfirmPassword.Text.Trim Then
                    swal("Oops!", "New Password do not match!", "error")
                Else
                    With member
                        .Password = txtConfirmPassword.Text.Trim
                        .LastModified = Now
                    End With

                    db.SubmitChanges()
                    swalRedirect("MyPassword.aspx", "Success", "Your password has updated successfully.", "success")
                End If
            End Using
        Catch ex As Exception
            Log(ex)
            swal("Oops!", "Something went wrong, please contact customer service.", "error")
        End Try
    End Sub
End Class
