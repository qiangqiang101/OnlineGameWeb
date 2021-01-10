
Partial Class Admin_EditBank
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public bid As String = 0

    Private Sub Admin_EditBank_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mode = Request.QueryString("mode")
            bid = Request.QueryString("id")

            Select Case mode
                Case "edit"
                    If bid <> Nothing Then
                        Try
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
                            h6.InnerText = "Edit " & b.BankID.ToString("00000")
                        Catch ex As Exception
                            JsMsgBox("Bank not found!")
                            btnSubmit.Enabled = False
                        End Try
                    Else
                        JsMsgBox("Bank not found!")
                        btnSubmit.Enabled = False
                    End If
                Case "delete"

                Case Else
                    h6.InnerText = "Add New Bank"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Dim editbank = db.TblBanks.Single(Function(x) x.BankID = CInt(bid))

                If TryEditBank() Then
                    JsMsgBox(editbank.BankName & " - " & editbank.AccountName & " (" & editbank.AccountNo & ") update successfully.")
                    Response.Redirect("Banks.aspx")
                Else
                    JsMsgBox(editbank.BankName & " - " & editbank.AccountName & " (" & editbank.AccountNo & ") edit failed! Please contact Administrator.")
                End If
            Case "delete"

            Case Else
                If AddNewBank() Then
                    JsMsgBox("Bank added successfully.")
                    Response.Redirect("Banks.aspx")
                Else
                    JsMsgBox("Add bank failed! Please contact Administrator.")
                End If
        End Select
    End Sub

    Private Function TryEditBank() As Boolean
        Try
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
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewBank() As Boolean
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
        End With

        Try
            db.TblBanks.InsertOnSubmit(newBank)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
