
Partial Class Admin_Transaction
    Inherits System.Web.UI.Page

    Private Sub Admin_Transaction_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim trans = db.TblTransactions.OrderByDescending(Function(x) x.TransactionID)
        For Each t As TblTransaction In trans
            Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
            Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
            Select Case t.TransType
                Case 0 'credit
                    dataTable.AddTableItem(t.TransactionID.ToString("00000"), t.TransactionDate.ToString(dateFormat), t.UserName.Trim, m.FullName.Trim, p.ProductName.Trim, t.Method, StatusToString(t.Status), t.Credit.ToString("0.00"), "", "Credit", TransactionTypeToString(t.TransType), If(t.Remark = Nothing, "", t.Remark.Trim), RB("EditTransaction.aspx?mode=edit&id=" & t.TransactionID, "fas fa-edit", tooltip:="Edit"))
                Case 1 'debit
                    dataTable.AddTableItem(t.TransactionID.ToString("00000"), t.TransactionDate.ToString(dateFormat), t.UserName.Trim, m.FullName.Trim, p.ProductName.Trim, t.Method, StatusToString(t.Status), "", t.Debit.ToString("0.00"), "Debit", TransactionTypeToString(t.TransType), If(t.Remark = Nothing, "", t.Remark.Trim), RB("EditTransaction.aspx?mode=edit&id=" & t.TransactionID, "fas fa-edit", tooltip:="Edit"))
                Case 2 'bonus
                    dataTable.AddTableItem(t.TransactionID.ToString("00000"), t.TransactionDate.ToString(dateFormat), t.UserName.Trim, m.FullName.Trim, p.ProductName.Trim, t.Method, StatusToString(t.Status), t.Promotion.ToString("0.00"), "", "Promotion", TransactionTypeToString(t.TransType), If(t.Remark = Nothing, "", t.Remark.Trim), RB("EditTransaction.aspx?mode=edit&id=" & t.TransactionID, "fas fa-edit", tooltip:="Edit"))
            End Select
        Next
    End Sub
End Class
