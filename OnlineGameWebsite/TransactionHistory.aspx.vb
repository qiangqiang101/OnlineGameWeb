
Partial Class TransactionHistory
    Inherits System.Web.UI.Page

    Private Sub TransactionHistory_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            LoginMsgBox
        End If

        Dim trans = db.TblTransactions.Where(Function(x) x.UserName = Session("username").ToString.Trim And x.TransType = 0).OrderByDescending(Function(x) x.TransactionID).Take(5).ToList
        For Each t As TblTransaction In trans
            Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
            Dim pdtName As String = Nothing
            If String.IsNullOrWhiteSpace(p.ProductAlias) Then pdtName = p.ProductName.Trim Else pdtName = p.ProductAlias.Trim
            tblDeposit.AddTableItem(t.TransactionDate.ToString(dateFormat), pdtName, t.Method.Trim, StatusToString(t.Status), t.Credit.ToString("0.00"), DeleteButton("CancelTransaction.aspx?id=" & t.TransactionID))
        Next

        trans = db.TblTransactions.Where(Function(x) x.UserName = Session("username").ToString.Trim And x.TransType = 2).OrderByDescending(Function(x) x.TransactionID).Take(5).ToList
        For Each t As TblTransaction In trans
            Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
            Dim pdtName As String = Nothing
            If String.IsNullOrWhiteSpace(p.ProductAlias) Then pdtName = p.ProductName.Trim Else pdtName = p.ProductAlias.Trim
            tblPromotion.AddTableItem(t.TransactionDate.ToString(dateFormat), pdtName, t.Method.Trim, StatusToString(t.Status), t.Promotion.ToString("0.00"), DeleteButton("CancelTransaction.aspx?id=" & t.TransactionID))
        Next

        trans = db.TblTransactions.Where(Function(x) x.UserName = Session("username").ToString.Trim And x.TransType = 1).OrderByDescending(Function(x) x.TransactionID).Take(5).ToList
        For Each t As TblTransaction In trans
            Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
            Dim pdtName As String = Nothing
            If String.IsNullOrWhiteSpace(p.ProductAlias) Then pdtName = p.ProductName.Trim Else pdtName = p.ProductAlias.Trim
            tblWithdraw.AddTableItem(t.TransactionDate.ToString(dateFormat), pdtName, t.Method.Trim, StatusToString(t.Status), t.Debit.ToString("0.00"), DeleteButton("CancelTransaction.aspx?id=" & t.TransactionID))
        Next
    End Sub
End Class
