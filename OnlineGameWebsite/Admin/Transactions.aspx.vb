
Partial Class Admin_Transaction
    Inherits System.Web.UI.Page

    Private Sub Admin_Transaction_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim trans = db.TblTransactions.OrderByDescending(Function(x) x.TransactionID)
        For Each t As TblTransaction In trans
            Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
            Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
            dataTable.AddTransactionTableItem(t.TransactionID, t.TransactionDate, t.UserName, m.FullName, p.ProductName, t.Method, t.Status, t.Credit, t.Debit, t.Promotion, t.TransType, t.Remark)
        Next
    End Sub
End Class
