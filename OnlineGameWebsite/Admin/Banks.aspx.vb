
Partial Class Admin_Banks
    Inherits System.Web.UI.Page

    Private Sub Admin_Banks_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim bank = db.TblBanks.OrderByDescending(Function(x) x.BankID)
            For Each b As TblBank In bank
                Dim hasImage As Boolean = b.BankLogo <> Nothing
                dataTable.AddTableItem(b.BankID.ToString("00000"), If(hasImage, Img("..\" & b.BankLogo.Trim, b.BankName.Trim), ""), b.BankName.Trim, b.AccountName.Trim, b.AccountNo.Trim, If(b.AllowCredit, "Yes", "No"), If(b.AllowDebit, "Yes", "No"), IntStatusToString(b.Status),
                                       RB("EditBank.aspx?mode=edit&id=" & b.BankID, "fas fa-edit", tooltip:="Edit") & RB("EditBank.aspx?mode=delete&id=" & b.BankID, "fas fa-trash", "btn-danger", "Delete") &
                                       RB("EditBank.aspx?mode=duplicate&id=" & b.BankID, "fas fa-clone", "btn-info", "Duplicate"))
            Next
        End Using
    End Sub

    Private Sub btnAddBank_Click(sender As Object, e As EventArgs) Handles btnAddBank.Click
        Response.Redirect("EditBank.aspx?mode=new&id=-1")
    End Sub
End Class
