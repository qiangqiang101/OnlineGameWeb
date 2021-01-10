
Partial Class Admin_Banks
    Inherits System.Web.UI.Page

    Private Sub Admin_Banks_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim bank = db.TblBanks.OrderByDescending(Function(x) x.BankID)
        For Each b As TblBank In bank
            dataTable.AddTableItem(b.BankID.ToString("00000"), b.BankName.Trim, b.AccountName.Trim, b.AccountNo.Trim,
                                   IntStatusToString(b.Status), RB("EditBank.aspx?mode=edit&id=" & b.BankID, "fas fa-edit"))
        Next
    End Sub

    Private Sub btnAddBank_Click(sender As Object, e As EventArgs) Handles btnAddBank.Click
        Response.Redirect("EditBank.aspx?mode=new&id=-1")
    End Sub
End Class
