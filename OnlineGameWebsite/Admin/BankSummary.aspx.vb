
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
                dataTable.AddBankSummaryTableItem(b.BankID, If(hasImage, Img("..\" & b.BankLogo.Trim, b.BankName.Trim), ""), b.BankName, b.AccountName, b.AccountNo, credit, debit, balance)
                credit = 0F
                debit = 0F
                balance = 0F
            Next
        End Using
    End Sub

End Class
