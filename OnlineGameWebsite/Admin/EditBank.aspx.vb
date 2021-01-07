
Partial Class Admin_EditBank
    Inherits System.Web.UI.Page

    Private Sub Admin_EditBank_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Dim b = db.TblBanks.Single(Function(x) x.BankID = id)
                If b IsNot Nothing Then
                    txtBank.Text = b.BankName.Trim
                    txtName.Text = b.AccountName.Trim
                    txtAccNo.Text = b.AccountNo.Trim
                    txtWebsite.Text = b.BankWeb.Trim
                    txtMinCredit.Text = b.MinCredit.ToString("0.00")
                    txtMaxCredit.Text = b.MaxCredit.ToString("0.00")
                    txtMinDebit.Text = b.MinDebit.ToString("0.00")
                    txtMaxDebit.Text = b.MaxDebit.ToString("0.00")
                    cmbEnabled.SelectedValue = b.Status
                Else
                    JsMsgBox("Bank not found!")
                    btnSubmit.Enabled = False
                End If
            Else
                JsMsgBox("Bank not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim editBank = db.TblBanks.Single(Function(x) x.BankID = CInt(Request.QueryString("id")))
        With editBank
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
        JsMsgBox(editBank.BankName & " - " & editBank.AccountName & " (" & editBank.AccountNo & ") update successfully.")
    End Sub
End Class
