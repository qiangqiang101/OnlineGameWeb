
Partial Class Admin_EditBank
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public bid As String = 0
    Public imageUrl As String = Nothing

    Private Sub Admin_EditBank_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        bid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Using db As New DataClassesDataContext
                            Dim b = db.TblBanks.Single(Function(x) x.BankID = CInt(bid))
                            txtBank.Text = b.BankName.Trim
                            txtName.Text = b.AccountName.Trim
                            txtAccNo.Text = b.AccountNo.Trim
                            txtWebsite.Text = b.BankWeb.Trim
                            txtMinCredit.Text = b.MinCredit.ToString("0.00")
                            txtMaxCredit.Text = b.MaxCredit.ToString("0.00")
                            txtMinDebit.Text = b.MinDebit.ToString("0.00")
                            txtMaxDebit.Text = b.MaxDebit.ToString("0.00")
                            cmbEnabled.SelectedValue = b.Status
                            cmbAllowCredit.SelectedValue = b.AllowCredit
                            cmbAllowDebit.SelectedValue = b.AllowDebit
                            imgBank.ImageUrl = If(b.BankLogo = Nothing, "", "..\" & b.BankLogo.Trim)
                            imageUrl = b.BankLogo

                            h6.InnerText = "Edit " & b.BankID.ToString("00000")
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Bank ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Using db As New DataClassesDataContext
                            Dim b = db.TblBanks.Single(Function(x) x.BankID = CInt(bid))
                            txtBank.Text = b.BankName.Trim
                            txtName.Text = b.AccountName.Trim
                            txtAccNo.Text = b.AccountNo.Trim
                            txtWebsite.Text = b.BankWeb.Trim
                            txtMinCredit.Text = b.MinCredit.ToString("0.00")
                            txtMaxCredit.Text = b.MaxCredit.ToString("0.00")
                            txtMinDebit.Text = b.MinDebit.ToString("0.00")
                            txtMaxDebit.Text = b.MaxDebit.ToString("0.00")
                            cmbEnabled.SelectedValue = b.Status
                            cmbAllowCredit.SelectedValue = b.AllowCredit
                            cmbAllowDebit.SelectedValue = b.AllowDebit
                            imgBank.ImageUrl = If(b.BankLogo = Nothing, "", "..\" & b.BankLogo.Trim)
                            imageUrl = b.BankLogo

                            txtBank.ReadOnly = True
                            txtName.ReadOnly = True
                            txtAccNo.ReadOnly = True
                            txtWebsite.ReadOnly = True
                            txtMinDebit.ReadOnly = True
                            txtMaxDebit.ReadOnly = True
                            txtMinCredit.ReadOnly = True
                            txtMaxCredit.ReadOnly = True
                            cmbEnabled.Enabled = False
                            cmbAllowCredit.Enabled = False
                            cmbAllowDebit.Enabled = False

                            h6.InnerText = "Are you sure you want to delete " & b.BankName & " (" & b.BankID.ToString("00000") & ")?"
                            btnSubmit.Text = "Delete"
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Bank ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Bank"
                    btnSubmit.Text = "Insert"

                    Try
                        Using db As New DataClassesDataContext
                            Dim b = db.TblBanks.Single(Function(x) x.BankID = CInt(bid))
                            txtBank.Text = "Copy of " & b.BankName.Trim
                            txtName.Text = b.AccountName.Trim
                            txtAccNo.Text = b.AccountNo.Trim
                            txtWebsite.Text = b.BankWeb.Trim
                            txtMinCredit.Text = b.MinCredit.ToString("0.00")
                            txtMaxCredit.Text = b.MaxCredit.ToString("0.00")
                            txtMinDebit.Text = b.MinDebit.ToString("0.00")
                            txtMaxDebit.Text = b.MaxDebit.ToString("0.00")
                            cmbEnabled.SelectedValue = b.Status
                            cmbAllowCredit.SelectedValue = b.AllowCredit
                            cmbAllowDebit.SelectedValue = b.AllowDebit
                            imgBank.ImageUrl = If(b.BankLogo = Nothing, "", "..\" & b.BankLogo.Trim)
                            imageUrl = b.BankLogo
                        End Using

                        If AddNewBank() Then
                            swalBsRedirect("Banks.aspx", "Success", "This Bank is successfully duplicated.", "success")
                        Else
                            swalBs("Oops!", "Failed to duplicate Bank, Please contact Adminstrator.", "error")
                        End If
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Bank ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New Bank"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Using db As New DataClassesDataContext
                    If TryEditBank() Then
                        swalBsRedirect("Banks.aspx", "Success", "This Bank is successfully update.", "success")
                    Else
                        swalBs("Oops!", "Failed to edit this Bank, Please contact Administrator.", "error")
                    End If
                End Using
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim bankToDelete = db.TblBanks.Single(Function(x) x.BankID = CInt(bid))
                        db.TblBanks.DeleteOnSubmit(bankToDelete)
                        db.SubmitChanges()
                    End Using

                    swalBsRedirect("Banks.aspx", "Success", "This Bank is successfully delete.", "success")
                Catch ex As Exception
                    Log(ex)
                    swalBs("Oops!", "This Bank is failed to delete! Please contact Adminstrator.", "error")
                End Try
            Case Else
                If AddNewBank() Then
                    swalBsRedirect("Banks.aspx", "Success", "This Bank is successfully added.", "success")
                Else
                    swalBs("Oops!", "Failed to add Bank, Please contact Adminstrator.", "error")
                End If
        End Select
    End Sub

    Private Function TryEditBank() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editbank = db.TblBanks.Single(Function(x) x.BankID = CInt(bid))
                With editbank
                    .BankName = txtBank.Text.Trim
                    .AccountName = txtName.Text.Trim
                    .AccountNo = txtAccNo.Text.Trim
                    .Status = cmbEnabled.SelectedValue
                    .BankWeb = txtWebsite.Text.Trim
                    .MinCredit = CSng(txtMinCredit.Text.Trim)
                    .MaxCredit = CSng(txtMaxCredit.Text.Trim)
                    .MinDebit = CSng(txtMinDebit.Text.Trim)
                    .MaxDebit = CSng(txtMaxDebit.Text.Trim)
                    .AllowCredit = cmbAllowCredit.SelectedValue
                    .AllowDebit = cmbAllowDebit.SelectedValue
                    If fileUploader.HasFile Then
                        Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                        Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                        Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                        If IsImage(ext) Then
                            If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                            fileUploader.SaveAs(file)
                            .BankLogo = fileUrl
                        Else
                            swalBs("Oops!", "Failed to upload image, please try again with supported image format.", "error")
                            .BankLogo = imgBank.ImageUrl
                        End If
                    Else
                        .BankLogo = imgBank.ImageUrl
                    End If
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewBank(Optional image As String = "Theme/img/empty_box.png") As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newBank As New TblBank
                With newBank
                    .BankName = txtBank.Text.Trim
                    .AccountName = txtName.Text.Trim
                    .AccountNo = txtAccNo.Text.Trim
                    .Status = cmbEnabled.SelectedValue
                    .BankWeb = txtWebsite.Text.Trim
                    .MinCredit = CSng(txtMinCredit.Text.Trim)
                    .MaxCredit = CSng(txtMaxCredit.Text.Trim)
                    .MinDebit = CSng(txtMinDebit.Text.Trim)
                    .MaxDebit = CSng(txtMaxDebit.Text.Trim)
                    .AllowCredit = cmbAllowCredit.SelectedValue
                    .AllowDebit = cmbAllowDebit.SelectedValue
                    If fileUploader.HasFile Then
                        Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                        Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                        Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                        If IsImage(ext) Then
                            If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                            fileUploader.SaveAs(file)
                            .BankLogo = fileUrl
                        Else
                            swalBs("Oops!", "Failed to upload image, please try again with supported image format.", "error")
                            .BankLogo = Nothing
                        End If
                    Else
                        .BankLogo = image
                    End If
                End With

                db.TblBanks.InsertOnSubmit(newBank)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

End Class
