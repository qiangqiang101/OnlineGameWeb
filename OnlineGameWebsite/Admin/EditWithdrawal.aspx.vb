﻿
Partial Class Admin_EditWithdrawal
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public tid As String = 0
    Public bankList As New Dictionary(Of Integer, String)

    Private Sub Admin_EditWithdrawal_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        tid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Pending(CInt(tid))

                        Using db As New DataClassesDataContext
                            Dim banks = db.TblBanks.Where(Function(x) x.Status = 1).ToList
                            For Each bank As TblBank In banks
                                cmbPaymentMethod.Items.Add(New ListItem(bank.BankName.Trim & " (" & bank.AccountName.Trim & ")", bank.BankName.Trim))
                                bankList.Add(bank.BankID, bank.BankName.Trim & " (" & bank.AccountName.Trim & ")")
                            Next
                            Dim rejects = db.TblTRejectReasons.Where(Function(x) x.Status = True).ToList
                            cmbRejectReason.Items.Add(New ListItem("", ""))
                            For Each reason As TblTRejectReason In rejects
                                cmbRejectReason.Items.Add(New ListItem(reason.TrReason.Trim, reason.TrReason.Trim))
                            Next

                            Dim t = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid))
                            Dim p = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                            Dim m = db.TblMembers.Single(Function(x) x.UserName = t.UserName)

                            h6Title.InnerText = "Transaction " & t.TransactionID.ToString("00000")
                            lblID.InnerText = t.TransactionID.ToString("00000")
                            lblProduct.InnerText = p.ProductName.Trim
                            lblProductUsername.InnerText = t.ProductUserName.Trim
                            lblUserID.InnerText = t.UserName.Trim
                            lblFullName.InnerText = m.FullName.Trim
                            lblIpAddress.InnerText = t.IPAddress.Trim
                            lblTime.InnerText = t.TransactionDate.ToString(dateFormat)
                            lblAmount.InnerText = t.Debit.ToString("0.00")
                            lblMethod.InnerText = t.Method.Trim
                            lblRemarks.InnerText = If(t.Reference = Nothing, "-", t.Reference.Trim)
                            lblAffiliate.InnerText = If(m.Affiliate = Nothing, "-", m.Affiliate.Trim)
                            lblStatus.InnerText = StatusToString(t.Status)
                            If t.Status <= 1 Then
                                btnApprove.Visible = True
                                btnReject.Visible = True
                            Else
                                btnApprove.Visible = False
                                btnReject.Visible = False
                            End If
                            If Not t.ApproveBank = Nothing Then cmbPaymentMethod.SelectedValue = t.ApproveBank.Trim
                            If Not t.Reason = Nothing Then cmbRejectReason.SelectedValue = t.Reason.Trim
                            If Not t.Remark = Nothing Then txtRemarks.Text = t.Remark.Trim
                            If t.ApproveByUser.Trim <> "None" Then
                                txtConfirmUser.Text = t.ApproveByUser.Trim
                                txtConfirmDate.Text = t.ApproveDate.ToString(dateFormat)
                            End If
                        End Using
                    Catch ex As Exception
                        JsMsgBox("Transaction not found!")
                        btnApprove.Enabled = False
                        btnReject.Enabled = False
                        Exit Sub
                    End Try
            End Select
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Transactions.aspx")
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Select Case mode
            Case "edit"
                If TryApproveTransaction() Then
                    If TryDebitToBank() Then
                        If TryDebitToSummary() Then
                            Response.Redirect("Transactions.aspx")
                        Else
                            JsMsgBox("Debit to summary failed! Please contact Administrator.")
                        End If
                    Else
                        JsMsgBox("Debit to bank record failed! Please contact Administrator.")
                    End If
                Else
                    JsMsgBox("Transaction failed to Approve! Please contact Administrator.")
                End If
        End Select
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Select Case mode
            Case "edit"
                If TryRejectTransaction() Then
                    Response.Redirect("Transactions.aspx")
                Else
                    JsMsgBox("Transaction failed to Reject! Please contact Administrator.")
                End If
        End Select
    End Sub

    Private Function TryRejectTransaction() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editTransaction = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid))
                With editTransaction
                    .Reason = cmbRejectReason.SelectedValue.Trim
                    .Remark = txtRemarks.Text.Trim
                    .Status = 3
                    .ApproveByUser = Session("username").ToString.Trim
                    .ApproveDate = Now
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function TryApproveTransaction() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editTransaction = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid))
                With editTransaction
                    .Remark = txtRemarks.Text.Trim
                    .Status = 2
                    .ApproveByUser = Session("username").ToString.Trim
                    .ApproveDate = Now
                    .ApproveBank = cmbPaymentMethod.SelectedValue
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function TryDebitToBank() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim t = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid))

                Dim addBankRecord As New TblBankRecord
                With addBankRecord
                    .BankID = bankList.Single(Function(x) x.Value = cmbPaymentMethod.SelectedItem.Text).Key
                    .TransactionID = CInt(tid)
                    .Credit = t.Credit
                    .Debit = t.Debit
                    .Description = lblUserID.InnerText.Trim & " withdrew " & lblAmount.InnerText & " from " & lblProduct.InnerText & "."
                    .RecordDatetime = Now
                End With

                db.TblBankRecords.InsertOnSubmit(addBankRecord)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function TryDebitToSummary() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim t = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid))

                Dim addSummary As New TblSummary
                With addSummary
                    .ProductID = t.ProductID
                    .Debit = t.Debit
                    .Credit = t.Credit
                    .Promotion = t.Promotion
                    .SummaryDate = Now
                    .TransactionID = CInt(tid)
                End With


                db.TblSummaries.InsertOnSubmit(addSummary)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
End Class
