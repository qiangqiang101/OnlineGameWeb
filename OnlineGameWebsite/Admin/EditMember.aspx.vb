﻿
Partial Class Admin_EditMember
    Inherits System.Web.UI.Page


    Private Sub Admin_EditMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Try
                    Dim m = db.TblMembers.Single(Function(x) x.UserID = id)
                    txtUserID.Text = m.UserName.Trim
                    txtPassword.Text = m.Password.Trim
                    txtEmail.Text = m.Email.Trim
                    txtPhone.Text = m.PhoneNo.Trim
                    txtFullName.Text = m.FullName.Trim
                    txtBirthday.Text = m.DateOfBirth.ToString("yyyy-MM-dd")
                    lblRefCode.InnerText = m.RefCode.Trim
                    lblRegRefCode.InnerText = If(m.RefCodeReg.Trim = Nothing, "-", m.RefCodeReg.Trim)
                    lblRegisterDate.InnerText = m.DateCreated.ToString(dateFormat)
                    lblLastModified.InnerText = m.LastModified.ToString(dateFormat)
                    lblRegisterIP.InnerText = m.IPAddress.Trim
                    cmbLevel.SelectedValue = m.VipLevel
                    cmbEnabled.SelectedValue = m.Enabled
                    txtRemarks.Text = If(m.Remark = Nothing, Nothing, m.Remark.Trim)

                    Dim gas = (From acc In db.TblGameAccounts Where acc.MemberUserName = m.UserName)
                    If gas IsNot Nothing Then
                        For Each ga In gas
                            dataTable1.AddTableItem(ga.GameID, ga.UserName.Trim, ga.Password.Trim, ga.Product.Trim,
                                                   RB("DeleteGameAcc.aspx?id=" & ga.GameID, "fas fa-trash", "btn-danger"))
                        Next
                    End If

                    Dim mbs = (From bnk In db.TblMemberBanks Where bnk.MemberUserName = m.UserName)
                    If mbs IsNot Nothing Then
                        For Each mb In mbs
                            dataTable2.AddTableItem(mb.MemberBankID, mb.BankName.Trim, mb.AccountName.Trim, mb.AccountNo.Trim,
                                                    RB("DeleteMemberBank.aspx?id=" & mb.MemberBankID, "fas fa-trash", "btn-danger"))
                        Next
                    End If

                    Dim tns = (From tran In db.TblTransactions Where tran.UserName = m.UserName)
                    If tns IsNot Nothing Then
                        For Each tn In tns
                            dataTable3.AddTableItem(tn.TransactionID, tn.TransactionDate, ProductName(tn.ProductID), tn.ProductUserName, tn.Method, tn.Debit.ToString("0.00"),
                                                    If(tn.Promotion = 0F, tn.Credit.ToString("0.00"), tn.Promotion.ToString("0.00")), StatusToString(tn.Status))
                        Next
                    End If
                Catch ex As Exception
                    JsMsgBox("Member not found!")
                    btnSubmit.Enabled = False
                End Try
            Else
                JsMsgBox("Member not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim editMember = db.TblMembers.Single(Function(x) x.UserID = CInt(Request.QueryString("id")))

        If TryEditMember() Then
            JsMsgBox("Member " & editMember.UserName & " update successfully.")
            Response.Redirect("Members.aspx")
        Else
            JsMsgBox("Member " & editMember.UserName & " edit failed! Please contact Administrator.")
        End If
    End Sub

    Private Function TryEditMember() As Boolean
        Try
            Dim editMember = db.TblMembers.Single(Function(x) x.UserID = CInt(Request.QueryString("id")))
            With editMember
                .UserName = txtUserID.Text.Trim
                .Password = txtPassword.Text.Trim
                .Email = txtEmail.Text.Trim
                .PhoneNo = txtPhone.Text.Trim
                .FullName = txtFullName.Text.Trim
                .DateOfBirth = Date.ParseExact(txtBirthday.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                .RefCode = .RefCode
                .RefCodeReg = .RefCodeReg
                .VipLevel = cmbLevel.SelectedValue
                .Promotion = .Promotion
                .DateCreated = .DateCreated
                .LastModified = Now
                .IPAddress = .IPAddress
                .GroupLeaderID = .GroupLeaderID
                .Enabled = cmbEnabled.SelectedValue
                .Remark = txtRemarks.Text.Trim
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
