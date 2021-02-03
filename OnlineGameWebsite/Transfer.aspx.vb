
Partial Class Transfer
    Inherits BasePage

    Dim captcha As String = String.Empty

    Private Sub Transfer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            LoginMsgBox
        Else
            If Not IsPostBack Then
                Using db As New DataClassesDataContext
                    Dim products = db.TblProducts.Where(Function(x) x.Status = True).ToList
                    For Each pdt As TblProduct In products
                        Dim acc = db.TblGameAccounts.Where(Function(x) x.ProductID = pdt.ProductID And x.MemberUserName = Session("username").ToString.Trim)
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(pdt.ProductAlias) Then pdtName = pdt.ProductName.Trim Else pdtName = pdt.ProductAlias.Trim
                        If acc.Count <> 0 Then
                            For Each ac In acc
                                Dim li = New ListItem(pdtName, pdt.ProductID)
                                cmbProductFrom.Items.Add(li)
                                cmbProductTo.Items.Add(li)
                            Next
                        End If
                    Next
                End Using
            End If
        End If

        If Not IsPostBack Then
            captcha = RandomText(New Random, 6, 6)
            Session("captcha") = captcha
            captchaImg.Attributes("src") = "data:image/png;base64, " & TextToImage(captcha)
        End If
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If CInt(txtAmount.Text) < 0 Then txtAmount.Text = 0
        If txtAmount.Text.Length >= 8 Then txtAmount.Text = 0
        txtAmount.Text = CSng(txtAmount.Text).ToString("0.00")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cmbProductFrom.SelectedValue = cmbProductTo.SelectedValue Then
            swal("Oops!", "Transfer to same product account is prohibited.", "error")
        ElseIf Not txtVerification.Text.Trim.Equals(Session("captcha").ToString.Trim) Then
            swal("Oops!", "Incorrect captcha code, please try again.", "error")
        Else
            If Transfer() Then
                LogAction(Session("username").ToString.Trim, Request.UserHostAddress, eLogType.Transfer)
                swalRedirect("TransactionHistory.aspx", "Success", "Your transfer request has been submitted successfully.", "success")
            Else
                swal("Oops!", "Transfer failed! Please contact Customer Service.", "error")
            End If
        End If
    End Sub

    Private Function Transfer() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newTransfer As New TblTransfer
                With newTransfer
                    .TransferDate = Now
                    .UserName = Session("username").ToString.Trim
                    .FromProductID = cmbProductFrom.SelectedValue
                    .FromUserName = GetProductUserName(cmbProductFrom.SelectedValue, Session("username").ToString.Trim)
                    .ToProductID = cmbProductTo.SelectedValue
                    .ToUserName = GetProductUserName(cmbProductTo.SelectedValue, Session("username").ToString.Trim)
                    .Amount = CSng(txtAmount.Text.Trim)
                    .Status = 0
                    .IPAddress = Request.UserHostAddress.Trim
                    .Reason = Nothing
                    .ApproveByUser = "None"
                    .ApproveDate = Now
                    .Remark = Nothing
                End With

                db.TblTransfers.InsertOnSubmit(newTransfer)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
        Return True
    End Function

    Private Sub refreshCaptcha_ServerClick(sender As Object, e As EventArgs) Handles refreshCaptcha.ServerClick
        captcha = RandomText(New Random, 6, 6)
        Session("captcha") = captcha
        captchaImg.Attributes("src") = "data:image/png;base64, " & TextToImage(captcha)
    End Sub

End Class
