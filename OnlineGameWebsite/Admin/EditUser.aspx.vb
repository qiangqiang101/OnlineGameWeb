
Partial Class Admin_EditUser
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public uid As String = 0

    Private Sub Admin_EditUser_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        uid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "profile"
                    Try
                        Using db As New DataClassesDataContext
                            Dim u = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                            txtUserName.Text = u.UserName.Trim
                            txtPassword.Text = u.Password.Trim
                            txtFullName.Text = u.FullName.Trim
                            txtEmail.Text = u.Email.Trim
                            cmbCategory.SelectedValue = u.UserRole
                            cmbEnabled.SelectedValue = u.Status
                            txtUserName.ReadOnly = True
                            cmbCategory.Enabled = False
                            cmbEnabled.Enabled = False

                            h6.InnerText = "Edit Profile"
                            h1.InnerText = "My Profile"
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        JsMsgBox("User not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "edit"
                    Try
                        Using db As New DataClassesDataContext
                            Dim u = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                            txtUserName.Text = u.UserName.Trim
                            txtPassword.Text = u.Password.Trim
                            txtFullName.Text = u.FullName.Trim
                            txtEmail.Text = u.Email.Trim
                            cmbCategory.SelectedValue = u.UserRole
                            cmbEnabled.SelectedValue = u.Status
                            txtUserName.ReadOnly = True

                            h6.InnerText = "Edit " & u.UserID.ToString("00000")
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        JsMsgBox("User not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Using db As New DataClassesDataContext
                            Dim u = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                            txtUserName.Text = u.UserName.Trim
                            txtPassword.Text = u.Password.Trim
                            txtFullName.Text = u.FullName.Trim
                            txtEmail.Text = u.Email.Trim
                            cmbCategory.SelectedValue = u.UserRole
                            cmbEnabled.SelectedValue = u.Status

                            txtUserName.ReadOnly = True
                            txtPassword.ReadOnly = True
                            txtFullName.ReadOnly = True
                            txtEmail.ReadOnly = True
                            cmbCategory.Enabled = False
                            cmbEnabled.Enabled = False

                            h6.InnerText = "Are you sure you want to delete " & u.UserName & " (" & u.UserID.ToString("00000") & ")?"
                            btnSubmit.Text = "Delete"
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        JsMsgBox("User not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New User"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "profile"
                Using db As New DataClassesDataContext
                    Dim editUser = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))

                    If TryEditUser() Then
                        JsMsgBox(editUser.UserName & " update successfully.")
                        Response.Redirect("Default.aspx")
                    Else
                        JsMsgBox(editUser.UserName & " edit failed! Please contact Administrator.")
                    End If
                End Using
            Case "edit"
                Using db As New DataClassesDataContext
                    Dim editUser = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))

                    If TryEditUser() Then
                        JsMsgBox(editUser.UserName & " update successfully.")
                        Response.Redirect("Users.aspx")
                    Else
                        JsMsgBox(editUser.UserName & " edit failed! Please contact Administrator.")
                    End If
                End Using
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim userToDelete = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                        db.TblUsers.DeleteOnSubmit(userToDelete)
                        db.SubmitChanges()

                        JsMsgBox("User delete successfully.")
                        Response.Redirect("Users.aspx")
                    End Using
                Catch ex As Exception
                    Log(ex)
                    JsMsgBox("Delete user failed! Please contact Administrator.")
                End Try
            Case Else
                If IsUserExists(txtUserName.Text.Trim) Then
                    JsMsgBox("User ID already exist, please try another.")
                ElseIf IsEmailExists(txtEmail.Text.Trim, eCheckEmail.User) Then
                    JsMsgBox("Email already exist, please try another.")
                Else
                    If AddNewUser() Then
                        JsMsgBox("User added successfully.")
                        Response.Redirect("Users.aspx")
                    Else
                        JsMsgBox("Add user failed! Please contact Administrator.")
                    End If
                End If
        End Select
    End Sub

    Private Function TryEditUser() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editUser = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                With editUser
                    .UserName = txtUserName.Text.Trim
                    .Password = txtPassword.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .Email = txtEmail.Text.Trim
                    .DateCreated = editUser.DateCreated
                    .UserRole = cmbCategory.SelectedValue
                    .Status = cmbEnabled.SelectedValue
                    .LastLoginDate = editUser.LastLoginDate
                    .LastLoginIP = editUser.LastLoginIP
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewUser() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newUser As New TblUser
                With newUser
                    .UserName = txtUserName.Text.Trim
                    .Password = txtPassword.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .Email = txtEmail.Text.Trim
                    .DateCreated = Now
                    .UserRole = cmbCategory.SelectedValue
                    .Status = cmbEnabled.SelectedValue
                    .LastLoginDate = Now
                    .LastLoginIP = "127.0.0.1"
                End With

                db.TblUsers.InsertOnSubmit(newUser)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

End Class
