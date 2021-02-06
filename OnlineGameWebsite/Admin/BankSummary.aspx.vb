
Partial Class Admin_BankSummary
    Inherits System.Web.UI.Page

    Private Sub Admin_BankSummary_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim bank = db.TblBanks.Where(Function(x) x.Status = 1).OrderByDescending(Function(x) x.BankID)
            For Each b As TblBank In bank
                Dim hasImage As Boolean = b.BankLogo <> Nothing
                Dim bankRecords = db.TblBankRecords.Where(Function(x) x.BankID = b.BankID)
                Dim credit, debit, balance As Single
                If bankRecords.Count <> 0 Then
                    If Not bankRecords.Count(Function(x) x.Credit) = 0 Then credit = bankRecords.Sum(Function(x) x.Credit)
                    If Not bankRecords.Count(Function(x) x.Debit) = 0 Then debit = bankRecords.Sum(Function(x) x.Debit)
                    balance = credit - debit
                End If
                dataTable.AddTableItem(b.BankID.ToString("00000"), If(hasImage, Img("..\" & b.BankLogo.Trim, b.BankName.Trim), ""), b.BankName.Trim, b.AccountName.Trim, b.AccountNo.Trim, credit.ToString("N"), debit.ToString("N"), balance.ToString("N"),
                                       RB("BankRecords.aspx?id=" & b.BankID, "fas fa-eye", tooltip:="Bank Record") & RB("AddBankSummary.aspx?mode=credit&id=" & b.BankID, "fas fa-coins", "btn-success", "Add Credit") &
                                       RB("AddBankSummary.aspx?mode=debit&id=" & b.BankID, "fas fa-hand-holding-usd", "btn-danger", "Add Debit") & RB("AddBankSummary.aspx?mode=transfer&id=" & b.BankID, "fas fa-exchange-alt", "btn-warning", "Add Transfer"))
                credit = 0F
                debit = 0F
                balance = 0F
            Next
        End Using
    End Sub

End Class
