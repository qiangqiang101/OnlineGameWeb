
Partial Class Admin_Summary
    Inherits System.Web.UI.Page

    Private Sub Admin_Summary_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim start, [end] As Date

        If Not IsPostBack Then
            start = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            [end] = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
            txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
        End If

        Try
            Using db As New DataClassesDataContext
                Dim products = db.TblProducts.Where(Function(x) x.Status = True).OrderBy(Function(x) x.ProductID)
                For Each p In products
                    Dim thc As New TableHeaderCell()
                    With thc
                        .Text = p.ProductName.Trim
                        .HorizontalAlign = HorizontalAlign.Right
                        .Attributes.Add("style", "text-align: right !important;")
                    End With
                    tableSummaryHeader.Cells.Add(thc)
                Next
                Dim thcBal As New TableHeaderCell()
                With thcBal
                    .Text = "Balance"
                    .HorizontalAlign = HorizontalAlign.Right
                    .Attributes.Add("style", "text-align: right !important;")
                End With
                tableSummaryHeader.Cells.Add(thcBal)

                Dim memCount = (From m In db.TblMembers Where m.DateCreated >= start AndAlso m.DateCreated <= [end]).Count
                Dim balance = TotalSummaryBalanceToday(start, [end])
                Dim productDic As New Dictionary(Of Integer, String)
                For Each p In products
                    productDic.Add(p.ProductID, TotalSummaryToday(p.ProductID, start, [end]).ToString("N"))
                Next
                tableSummary.AddSummaryTableItem(memCount, balance.ToString("N"), productDic.Values.ToArray)

                For Each p In products
                    Dim gameAccounts = db.TblGameAccounts.Where(Function(x) x.ProductID = p.ProductID AndAlso x.MemberUserName Is Nothing).Count
                    dataTable.AddSummaryReportTableItem(p.ProductName.Trim, TotalMemberDepositToday(p.ProductID, start, [end]), SummaryToday(p.ProductID, start, [end], eSum.Credit), SummaryToday(p.ProductID, start, [end], eSum.Debit), SummaryToday(p.ProductID, start, [end], eSum.Promotion), gameAccounts)
                Next

                transTable.AddTableItem("Credit", TransactionCount(start, [end], eSum.Credit), New TableCell() With {.Text = TransactionSum(start, [end], eSum.Credit).ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
                transTable.AddTableItem("Debit", TransactionCount(start, [end], eSum.Debit), New TableCell() With {.Text = TransactionSum(start, [end], eSum.Debit).ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
                transTable.AddTableItem("Promotion", TransactionCount(start, [end], eSum.Promotion), New TableCell() With {.Text = TransactionSum(start, [end], eSum.Promotion).ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
            End Using
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)

            Using db As New DataClassesDataContext
                Dim products = db.TblProducts.Where(Function(x) x.Status = True).OrderBy(Function(x) x.ProductID)
                Dim memCount = (From m In db.TblMembers Where m.DateCreated >= start AndAlso m.DateCreated <= [end]).Count
                Dim balance = TotalSummaryBalanceToday(start, [end])
                Dim productDic As New Dictionary(Of Integer, String)

                For Each p In products
                    productDic.Add(p.ProductID, TotalSummaryToday(p.ProductID, start, [end]).ToString("N"))
                Next
                tableSummary.AddSummaryTableItem(memCount, balance.ToString("N"), productDic.Values.ToArray)

                For Each p In products
                    Dim gameAccounts = db.TblGameAccounts.Where(Function(x) x.ProductID = p.ProductID AndAlso x.MemberUserName Is Nothing).Count
                    dataTable.AddSummaryReportTableItem(p.ProductName.Trim, TotalMemberDepositToday(p.ProductID, start, [end]), SummaryToday(p.ProductID, start, [end], eSum.Credit), SummaryToday(p.ProductID, start, [end], eSum.Debit), SummaryToday(p.ProductID, start, [end], eSum.Promotion), gameAccounts)
                Next

                transTable.AddTableItem("Credit", TransactionCount(start, [end], eSum.Credit), New TableCell() With {.Text = TransactionSum(start, [end], eSum.Credit).ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
                transTable.AddTableItem("Debit", TransactionCount(start, [end], eSum.Debit), New TableCell() With {.Text = TransactionSum(start, [end], eSum.Debit).ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
                transTable.AddTableItem("Promotion", TransactionCount(start, [end], eSum.Promotion), New TableCell() With {.Text = TransactionSum(start, [end], eSum.Promotion).ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
            End Using
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Function TransactionCount(startDate As Date, endDate As Date, type As eSum) As Integer
        Try
            Using db As New DataClassesDataContext
                Return (From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate).Where(Function(x) x.Status = 2 And x.TransType = type).Count
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function TransactionSum(startDate As Date, endDate As Date, type As eSum) As Single
        Try
            Using db As New DataClassesDataContext
                Select Case type
                    Case eSum.Credit
                        Return (From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate).Where(Function(x) x.Status = 2 And x.TransType = type).Sum(Function(x) x.Credit)
                    Case eSum.Debit
                        Return (From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate).Where(Function(x) x.Status = 2 And x.TransType = type).Sum(Function(x) x.Debit)
                    Case Else
                        Return (From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate).Where(Function(x) x.Status = 2 And x.TransType = type).Sum(Function(x) x.Promotion)
                End Select
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function TotalMemberDepositToday(pid As Integer, startDate As Date, endDate As Date) As Integer
        Try
            Using db As New DataClassesDataContext
                Return (From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate).Where(Function(x) x.Status = 2 And x.ProductID = pid).Count
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function TotalSummaryBalanceToday(startDate As Date, endDate As Date) As Single
        Try
            Using db As New DataClassesDataContext
                Return SummaryTodayTotal(startDate, endDate, eSum.Credit) + SummaryTodayTotal(startDate, endDate, eSum.Promotion) - SummaryTodayTotal(startDate, endDate, eSum.Debit)
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function TotalSummaryToday(pid As Integer, startDate As Date, endDate As Date) As Single
        Try
            Using db As New DataClassesDataContext
                Return SummaryToday(pid, startDate, endDate, eSum.Credit) + SummaryToday(pid, startDate, endDate, eSum.Promotion) - SummaryToday(pid, startDate, endDate, eSum.Debit)
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function SummaryToday(pid As Integer, startDate As Date, endDate As Date, sum As eSum) As Single
        Try
            Using db As New DataClassesDataContext
                Select Case sum
                    Case eSum.Credit
                        Return (From s In db.TblTransactions Where s.TransactionDate >= startDate AndAlso s.TransactionDate <= endDate).Where(Function(x) x.ProductID = pid And x.Status = 2).Sum(Function(x) x.Credit)
                    Case eSum.Promotion
                        Return (From s In db.TblTransactions Where s.TransactionDate >= startDate AndAlso s.TransactionDate <= endDate).Where(Function(x) x.ProductID = pid And x.Status = 2).Sum(Function(x) x.Promotion)
                    Case eSum.Debit
                        Return (From s In db.TblTransactions Where s.TransactionDate >= startDate AndAlso s.TransactionDate <= endDate).Where(Function(x) x.ProductID = pid And x.Status = 2).Sum(Function(x) x.Debit)
                    Case Else
                        Return 0F
                End Select
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function SummaryTodayTotal(startDate As Date, endDate As Date, sum As eSum) As Single
        Try
            Using db As New DataClassesDataContext
                Select Case sum
                    Case eSum.Credit
                        Return (From s In db.TblTransactions Where s.TransactionDate >= startDate AndAlso s.TransactionDate <= endDate).Where(Function(x) x.Status = 2).Sum(Function(x) x.Credit)
                    Case eSum.Promotion
                        Return (From s In db.TblTransactions Where s.TransactionDate >= startDate AndAlso s.TransactionDate <= endDate).Where(Function(x) x.Status = 2).Sum(Function(x) x.Promotion)
                    Case eSum.Debit
                        Return (From s In db.TblTransactions Where s.TransactionDate >= startDate AndAlso s.TransactionDate <= endDate).Where(Function(x) x.Status = 2).Sum(Function(x) x.Debit)
                    Case Else
                        Return 0F
                End Select
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Sub all_Click(sender As Object, e As EventArgs) Handles all.Click
        Dim start As Date = Date.ParseExact("1990-01-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & DateTime.DaysInMonth(Now.Year, Now.Month).ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
    End Sub

    Private Sub mtl_Click(sender As Object, e As EventArgs) Handles mtl.Click
        Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & DateTime.DaysInMonth(Now.Year, Now.Month).ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
    End Sub

    Private Sub n1d_Click(sender As Object, e As EventArgs) Handles n1d.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.AddDays(-1).ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].AddDays(-1).ToString("yyyy-MM-ddTHH:mm")
    End Sub

    Private Sub n7d_Click(sender As Object, e As EventArgs) Handles n7d.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.AddDays(-7).ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
    End Sub

    Private Sub p1d_Click(sender As Object, e As EventArgs) Handles p1d.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.AddDays(1).ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].AddDays(1).ToString("yyyy-MM-ddTHH:mm")
    End Sub

    Private Sub today_Click(sender As Object, e As EventArgs) Handles today.Click
        Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
    End Sub

End Class
