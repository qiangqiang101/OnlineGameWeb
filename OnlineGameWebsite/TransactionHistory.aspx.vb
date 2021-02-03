
Partial Class TransactionHistory
    Inherits System.Web.UI.Page

    Private Sub TransactionHistory_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            LoginMsgBox
        Else
            Using db As New DataClassesDataContext
                Dim trans = db.TblTransactions.Where(Function(x) x.UserName = Session("username").ToString.Trim And x.TransType = 0).OrderByDescending(Function(x) x.TransactionID).Take(30).ToList
                For Each t As TblTransaction In trans
                    Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                    Dim pdtName As String = Nothing
                    If String.IsNullOrWhiteSpace(p.ProductAlias) Then pdtName = p.ProductName.Trim Else pdtName = p.ProductAlias.Trim
                    Dim atnStr As String = String.Empty
                    Select Case t.Status
                        Case 0
                            atnStr = DeleteButton("Action.aspx?mode=cancel&redirect=history&id=" & t.TransactionID, tooltip:="Cancel")
                        Case 3
                            atnStr = RRButton("'Reject Reason', '" & t.Reason.Trim & "', 'info'", "fa-eye", "Reject Reason")
                        Case Else
                            atnStr = String.Empty
                    End Select
                    tblDeposit.AddTableItem(t.TransactionDate.ToString(dateFormat), pdtName & " (" & t.ProductUserName.Trim & ")", t.Method.Trim, StatusToString(t.Status), t.Credit.ToString("N"), atnStr)
                Next

                trans = db.TblTransactions.Where(Function(x) x.UserName = Session("username").ToString.Trim And x.TransType = 2).OrderByDescending(Function(x) x.TransactionID).Take(30).ToList
                For Each t As TblTransaction In trans
                    Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                    Dim pdtName As String = Nothing
                    If String.IsNullOrWhiteSpace(p.ProductAlias) Then pdtName = p.ProductName.Trim Else pdtName = p.ProductAlias.Trim
                    Dim atnStr As String = String.Empty
                    Select Case t.Status
                        Case 0
                            atnStr = DeleteButton("Action.aspx?mode=cancel&redirect=history&id=" & t.TransactionID, tooltip:="Cancel")
                        Case 3
                            atnStr = RRButton("'Reject Reason', '" & t.Reason.Trim & "', 'info'", "fa-eye", "Reject Reason")
                        Case Else
                            atnStr = String.Empty
                    End Select
                    tblPromotion.AddTableItem(t.TransactionDate.ToString(dateFormat), pdtName & " (" & t.ProductUserName.Trim & ")", t.Method.Trim, StatusToString(t.Status), t.Promotion.ToString("N"), atnStr)
                Next

                trans = db.TblTransactions.Where(Function(x) x.UserName = Session("username").ToString.Trim And x.TransType = 1).OrderByDescending(Function(x) x.TransactionID).Take(30).ToList
                For Each t As TblTransaction In trans
                    Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                    Dim pdtName As String = Nothing
                    If String.IsNullOrWhiteSpace(p.ProductAlias) Then pdtName = p.ProductName.Trim Else pdtName = p.ProductAlias.Trim
                    Dim atnStr As String = String.Empty
                    Select Case t.Status
                        Case 0
                            atnStr = DeleteButton("Action.aspx?mode=cancel&redirect=history&id=" & t.TransactionID, tooltip:="Cancel")
                        Case 3
                            atnStr = RRButton("'Reject Reason', '" & t.Reason.Trim & "', 'info'", "fa-eye", "Reject Reason")
                        Case Else
                            atnStr = String.Empty
                    End Select
                    tblWithdraw.AddTableItem(t.TransactionDate.ToString(dateFormat), pdtName & " (" & t.ProductUserName.Trim & ")", t.Method.Trim, StatusToString(t.Status), t.Debit.ToString("N"), atnStr)
                Next

                Dim tranf = db.TblTransfers.Where(Function(x) x.UserName = Session("username").ToString.Trim).OrderByDescending(Function(x) x.TransferID).Take(30).ToList
                For Each t As TblTransfer In tranf
                    Dim pf As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.FromProductID)
                    Dim pt As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ToProductID)
                    Dim pfName As String = String.Empty
                    If String.IsNullOrWhiteSpace(pf.ProductAlias) Then pfName = pf.ProductName.Trim Else pfName = pf.ProductAlias.Trim
                    Dim ptName As String = String.Empty
                    If String.IsNullOrWhiteSpace(pt.ProductAlias) Then ptName = pt.ProductName.Trim Else ptName = pt.ProductAlias.Trim
                    Dim atnStr As String = String.Empty
                    Select Case t.Status
                        Case 0
                            atnStr = DeleteButton("Action.aspx?mode=cancel2&redirect=history&id=" & t.TransferID, tooltip:="Cancel")
                        Case 3
                            atnStr = RRButton("'Reject Reason', '" & t.Reason.Trim & "', 'info'", "fa-eye", "Reject Reason")
                        Case Else
                            atnStr = String.Empty
                    End Select
                    tblTransfer.AddTableItem(t.TransferDate.ToString(dateFormat), pfName & " (" & t.FromUserName.Trim & ")", ptName & " (" & t.ToUserName.Trim & ")", StatusToString(t.Status), t.Amount.ToString("N"), atnStr)
                Next
            End Using
        End If
    End Sub
End Class
