
Partial Class Admin_AddBankSummary
    Inherits System.Web.UI.Page

    Public mode As String = "credit"
    Public bid As String = 0

    Private Sub Admin_AddBankSummary_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        bid = Request.QueryString("id")

        If Not IsPostBack Then
            Try
                Using db As New DataClassesDataContext
                    Dim banks = db.TblBanks.Where(Function(x) x.Status = 1)

                    Select Case mode
                        Case "credit"
                            h6.InnerText = "Add Credit Summary"
                            transferForm.Visible = False

                            For Each b In banks
                                cmbBank.Items.Add(New ListItem(b.BankName.Trim & " (" & b.AccountName.Trim & ")", b.BankID))
                            Next

                            cmbBank.SelectedValue = bid
                        Case "debit"
                            h6.InnerText = "Add Debit Summary"
                            transferForm.Visible = False

                            For Each b In banks
                                cmbBank.Items.Add(New ListItem(b.BankName.Trim & " (" & b.AccountName.Trim & ")", b.BankID))
                            Next

                            cmbBank.SelectedValue = bid
                        Case "transfer"
                            cdtdbtForm.Visible = False

                            For Each b In banks
                                cmbFromBank.Items.Add(New ListItem(b.BankName.Trim & " (" & b.AccountName.Trim & ")", b.BankID))
                                cmbToBank.Items.Add(New ListItem(b.BankName.Trim & " (" & b.AccountName.Trim & ")", b.BankID))
                            Next

                            cmbFromBank.SelectedValue = bid
                        Case "delete"
                            Dim bs = db.TblBankRecords.Single(Function(x) x.BRecordID = bid)
                            h6.InnerText = "Are you sure you want to delete Bank Summary?"
                            transferForm.Visible = False

                            For Each b In banks
                                cmbBank.Items.Add(New ListItem(b.BankName.Trim & " (" & b.AccountName.Trim & ")", b.BankID))
                            Next

                            cmbBank.SelectedValue = bs.BankID
                            txtDate.Text = bs.RecordDatetime.ToString("yyyy-MM-ddTHH:mm")
                            If bs.Credit = 0F Then
                                txtAmount.Text = bs.Debit.ToString("0.00")
                            Else
                                txtAmount.Text = bs.Credit.ToString("0.00")
                            End If
                            txtDesc.Text = bs.Description.Trim

                            cmbBank.Enabled = False
                            txtDate.ReadOnly = True
                            txtAmount.ReadOnly = True
                            txtDesc.ReadOnly = True
                            btnSubmit.Text = "Delete"
                    End Select
                End Using
            Catch ex As Exception
                Log(ex)
            End Try
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "credit"
                If TryCredit() Then
                    swalBsRedirect("BankSummary.aspx", "Success", "Credit to bank is successfully added.", "success")
                Else
                    swalBs("Oops!", "An error occurred while adding Credit to bank, Please contact Adminstrator.", "error")
                End If
            Case "debit"
                If TryDebit() Then
                    swalBsRedirect("BankSummary.aspx", "Success", "Debit to bank is successfully added.", "success")
                Else
                    swalBs("Oops!", "An error occurred while adding Debit to bank, Please contact Adminstrator.", "error")
                End If
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim bs = db.TblBankRecords.Single(Function(x) x.BRecordID = bid)

                        db.TblBankRecords.DeleteOnSubmit(bs)
                        db.SubmitChanges()

                        swalBsRedirect("BankSummary.aspx", "Success", "This Bank Summary is successfully delete.", "success")
                    End Using
                Catch ex As Exception
                    Log(ex)
                    swalBs("Oops!", "This Bank Summary is failed to delete! Please contact Adminstrator.", "error")
                End Try
        End Select
    End Sub

    Private Sub btnSubmitT_Click(sender As Object, e As EventArgs) Handles btnSubmitT.Click
        Select Case mode
            Case "transfer"
                If TryTransfer() Then
                    swalBsRedirect("BankSummary.aspx", "Success", "Transfer to bank is successfully added.", "success")
                Else
                    swalBs("Oops!", "An error occurred while transferring, Please contact Adminstrator.", "error")
                End If
        End Select
    End Sub

    Private Function TryTransfer() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newDebit As New TblBankRecord
                With newDebit
                    .BankID = cmbFromBank.SelectedValue
                    .TransactionID = -1
                    .Credit = 0F
                    .Debit = CSng(txtAmountT.Text)
                    .Description = txtDescT.Text.Trim
                    .RecordDatetime = Date.ParseExact(txtDateT.Text.Trim, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End With

                db.TblBankRecords.InsertOnSubmit(newDebit)

                Dim newCredit As New TblBankRecord
                With newCredit
                    .BankID = cmbToBank.SelectedValue
                    .TransactionID = -1
                    .Credit = CSng(txtAmountT.Text)
                    .Debit = 0F
                    .Description = txtDescT.Text.Trim
                    .RecordDatetime = Date.ParseExact(txtDateT.Text.Trim, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End With

                db.TblBankRecords.InsertOnSubmit(newCredit)
                db.SubmitChanges()
            End Using

            Return True
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
    End Function

    Private Function TryCredit() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newCredit As New TblBankRecord
                With newCredit
                    .BankID = cmbBank.SelectedValue
                    .TransactionID = -1
                    .Credit = CSng(txtAmount.Text)
                    .Debit = 0F
                    .Description = txtDesc.Text.Trim
                    .RecordDatetime = Date.ParseExact(txtDate.Text.Trim, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End With

                db.TblBankRecords.InsertOnSubmit(newCredit)
                db.SubmitChanges()
            End Using

            Return True
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
    End Function

    Private Function TryDebit() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newDebit As New TblBankRecord
                With newDebit
                    .BankID = cmbBank.SelectedValue
                    .TransactionID = -1
                    .Credit = 0F
                    .Debit = CSng(txtAmount.Text)
                    .Description = txtDesc.Text.Trim
                    .RecordDatetime = Date.ParseExact(txtDate.Text.Trim, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End With

                db.TblBankRecords.InsertOnSubmit(newDebit)
                db.SubmitChanges()
            End Using

            Return True
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
    End Function


End Class
