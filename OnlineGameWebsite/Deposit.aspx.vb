
Partial Class Deposit
    Inherits System.Web.UI.Page

    Dim captcha As String = String.Empty

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtVerification.Text.Trim.Equals(Session("captcha").ToString.Trim) Then
            If Deposit() AndAlso Promotion() Then
                LogAction(Session("username").ToString.Trim, Request.UserHostAddress, eLogType.Credit)
                JsMsgBoxRedirect("Deposit request sent.", "TransactionHistory.aspx")
            Else
                JsMsgBox("Deposit failed! Please contact Customer Service.")
            End If
        Else
            JsMsgBox("Incorrect Verification code, please try again.")
        End If
    End Sub

    Private Sub Deposit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            LoginMsgBox
        End If

        Dim banks = db.TblBanks.Where(Function(x) x.Status = 1).ToList
        For Each bank As TblBank In banks
            cmbBank.Items.Add(New ListItem(bank.BankName.Trim, bank.BankID))
        Next
        Dim promos = db.TblPromotions.Where(Function(x) x.Status = 1).ToList
        For Each promo As TblPromotion In promos
            cmbPromotion.Items.Add(New ListItem(promo.EnglishName.Trim, promo.PromoID))
        Next
        Dim products = db.TblProducts.Where(Function(x) x.Status = True).ToList
        For Each pdt As TblProduct In products
            Dim pdtName As String = Nothing
            If String.IsNullOrWhiteSpace(pdt.ProductAlias) Then pdtName = pdt.ProductName.Trim Else pdtName = pdt.ProductAlias.Trim
            cmbProduct.Items.Add(New ListItem(pdtName, pdt.ProductID))
        Next

        txtAmount.Text = "30.00"
        txtDepositDate.Text = Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm")

        If Not IsPostBack Then
            captcha = New Random().Next(0, 999999)
            Session("captcha") = captcha
            captchaImg.Attributes("src") = "data:image/png;base64, " & TextToImage(captcha)
        End If
    End Sub

    Private Function Deposit() As Boolean
        Dim newTransaction As New TblTransaction
        With newTransaction
            .TransactionDate = Now
            .UserName = Session("username").ToString.Trim
            .Method = cmbBank.SelectedItem.Text
            .TransType = 0 'credit
            .Debit = 0F
            .Credit = CSng(txtAmount.Text.Trim)
            .Promotion = 0F
            .Channel = cmbDepositType.SelectedValue
            .Reason = Nothing
            .ProductID = cmbProduct.SelectedValue
            .ProductUserName = GetProductUserName(cmbProduct.SelectedValue, Session("username").ToString.Trim)
            .Bank = Nothing
            .BankAccount = Nothing
            If fileUploader.HasFile Then
                Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                If CanUpload(ext) Then
                    If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                    fileUploader.SaveAs(file)
                    .UploadFile = fileUrl
                Else
                    JsMsgBox("Receipt upload failed, please try upload supported format.")
                    .UploadFile = Nothing
                End If
            Else
                .UploadFile = Nothing
            End If
            .Reference = If(String.IsNullOrWhiteSpace(txtRefCode.Text), Nothing, txtRefCode.Text.Trim)
            .Status = 0
            .IPAddress = Request.UserHostAddress.Trim
            .ApproveByUser = "None"
            .ApproveDate = Now
            .Remark = Nothing
            .TransactionDateUser = Date.ParseExact(txtDepositDate.Text.Trim, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        End With

        Try
            db.TblTransactions.InsertOnSubmit(newTransaction)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function Promotion() As Boolean
        If cmbPromotion.SelectedValue = "-1" Then
            Return True
        Else
            Dim newTransaction As New TblTransaction
            With newTransaction
                .TransactionDate = Now.AddSeconds(5)
                .UserName = Session("username").ToString.Trim
                .Method = cmbPromotion.SelectedItem.Text
                .TransType = 2 'promotion
                .Debit = 0F
                .Credit = 0F
                .Promotion = CalcPromotion(cmbPromotion.SelectedValue, CSng(txtAmount.Text.Trim))
                .Channel = 3 'other
                .Reason = Nothing
                .ProductID = cmbProduct.SelectedValue
                .ProductUserName = GetProductUserName(cmbProduct.SelectedValue, Session("username").ToString.Trim)
                .Bank = Nothing
                .BankAccount = Nothing
                .UploadFile = Nothing
                .Reference = Nothing
                .Status = 0
                .IPAddress = Request.UserHostAddress.Trim
                .ApproveByUser = "None"
                .ApproveDate = Now
                .Remark = Nothing
                .TransactionDateUser = Now
            End With

            Try
                db.TblTransactions.InsertOnSubmit(newTransaction)
                db.SubmitChanges()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End If
    End Function

End Class
