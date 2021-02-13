
Partial Class Partners_ViewMember
    Inherits System.Web.UI.Page

    Public mid As String = 0

    Private Sub Partners_ViewMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        mid = Request.QueryString("id")

        If Not IsNumeric(mid) Then
            Try
                Using db As New DataClassesDataContext
                    Dim mm = db.TblMembers.Single(Function(x) x.UserName = mid)
                    Response.Redirect("ViewMember.aspx?id=" & mm.UserID)
                End Using
            Catch ex As Exception
                Log(ex)
                swalBs("Oops!", "This Member ID does not exist.", "error")
                Exit Sub
            End Try
        End If

        If Not IsPostBack Then
            Try
                Using db As New DataClassesDataContext
                    Dim m = db.TblMembers.Single(Function(x) x.UserID = CInt(mid))
                    txtUserID.Text = m.UserName.Trim
                    txtPassword.Text = m.Password.Trim
                    txtEmail.Text = m.Email.Trim
                    txtPhone.Text = m.PhoneNo.Trim
                    txtFullName.Text = m.FullName.Trim
                    txtBirthday.Text = m.DateOfBirth.ToString("yyyy-MM-dd")
                    cmbLevel.SelectedValue = m.VipLevel
                    cmbEnabled.SelectedValue = m.Enabled
                    cmbBank.SelectedValue = m.BankName
                    txtAccNo.Text = If(m.AccountNo = Nothing, "", m.AccountNo.Trim)
                    txtRemarks.Text = If(m.Remark = Nothing, Nothing, m.Remark.Trim)

                    Dim mt = db.TblTransactions.Where(Function(x) x.UserName = m.UserName)
                    Dim log = db.TblLogs.Where(Function(x) x.LogMember = m.UserName)

                    lblTotalDeposit.InnerText = SumTransaction(mt, eSum.Credit).ToString("N") & " (" & CountTransaction(mt, eSum.Credit) & ")"
                    lblTotalWithdrawal.InnerText = SumTransaction(mt, eSum.Debit).ToString("N") & " (" & CountTransaction(mt, eSum.Debit) & ")"
                    lblTotalPromotion.InnerText = SumTransaction(mt, eSum.Promotion).ToString("N") & " (" & CountTransaction(mt, eSum.Promotion) & ")"

                    lblRegisterDate.InnerText = m.DateCreated.ToString(dateFormat)
                    lblLastLoginDate.InnerText = LogDate(log, eLogType.Login).ToString(dateFormat)
                    lbl1stDepDate.InnerText = TransactionDate(mt, eSum.Credit, True).ToString(dateFormat)
                    lblLstDepDate.InnerText = TransactionDate(mt, eSum.Credit, False).ToString(dateFormat)
                    lbl1stWtdDate.InnerText = TransactionDate(mt, eSum.Debit, True).ToString(dateFormat)
                    lblLstWtdDate.InnerText = TransactionDate(mt, eSum.Debit, False).ToString(dateFormat)
                    lblLastGADate.InnerText = LogDate(log, eLogType.RequestGameAcc).ToString(dateFormat)
                    lblLastModified.InnerText = m.LastModified.ToString(dateFormat)

                    lblRefCode.InnerText = m.RefCode.Trim
                    lblRegRefCode.InnerText = If(m.RefCodeReg = Nothing, "-", m.RefCodeReg.Trim)

                    lblRegisterIP.InnerText = m.IPAddress.Trim
                    lblLastLoginIP.InnerText = LogIP(log, eLogType.Login)
                    lblLastDepIP.InnerText = LogIP(log, eLogType.Credit)
                    lblLastWtdIP.InnerText = LogIP(log, eLogType.Debit)
                    lblLastTrfIP.InnerText = LogIP(log, eLogType.Transfer)
                    lblLastGAIP.InnerText = LogIP(log, eLogType.RequestGameAcc)

                    Dim tns = db.TblTransactions.Where(Function(x) x.UserName = m.UserName.Trim).OrderByDescending(Function(x) x.TransactionID)
                    If tns.Count <> 0 Then
                        For Each tn In tns
                            dataTable3.AddTransactionTableItem(tn.TransactionID, tn.TransactionDate, GetProductName(tn.ProductID), tn.ProductUserName, tn.Method, tn.Status, tn.Credit, tn.Debit, tn.Promotion, tn.TransType)
                        Next
                    End If

                    Dim tnf = db.TblTransfers.Where(Function(x) x.UserName = m.UserName.Trim).OrderByDescending(Function(x) x.TransferID)
                    If tnf.Count <> 0 Then
                        For Each tn In tnf
                            dataTable4.AddTransferTableItem(tn.TransferID, tn.TransferDate, GetProductName(tn.FromProductID), tn.FromUserName, GetProductName(tn.ToProductID), tn.ToUserName, tn.Amount, tn.Status)
                        Next
                    End If
                End Using
            Catch ex As Exception
                Log(ex)
                swalBs("Oops!", "This Member ID does not exist.", "error")
                Exit Sub
            End Try

            h1.InnerText = "Member View"
            txtPassword.ReadOnly = True
            txtEmail.ReadOnly = True
            txtPhone.ReadOnly = True
            txtFullName.ReadOnly = True
            txtBirthday.ReadOnly = True
            cmbLevel.Enabled = False
            cmbEnabled.Enabled = False
            cmbBank.Enabled = False
            txtAccNo.ReadOnly = True
            txtRemarks.ReadOnly = True

            Try
                Using db As New DataClassesDataContext
                    Dim m = db.TblMembers.Single(Function(x) x.UserID = CInt(mid))

                    Dim gas = (From acc In db.TblGameAccounts Where acc.MemberUserName = m.UserName)
                    If gas IsNot Nothing Then
                        For Each ga In gas
                            dataTable1.AddTableItem(ga.GameID.ToString("00000"), ga.UserName.Trim, ga.Password.Trim, GetProductName(ga.ProductID),
                                                                   RB("#", "fas fa-trash", "btn-danger"))
                        Next
                    End If
                End Using
            Catch ex As Exception
                Log(ex)
                swalBs("Oops!", "This Member ID does not exist.", "error")
                Exit Sub
            End Try
        End If
    End Sub
End Class
