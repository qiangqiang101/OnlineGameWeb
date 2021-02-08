
Partial Class Partners_Default
    Inherits System.Web.UI.Page

    Public thisMonth, lastMonth, last2Month, last3Month, last4Month, last5Month, last6Month, last7Month, last8Month, last9Month, last10Month, last11Month As Single
    Public thisMonthName, lastMonthName, last2MonthName, last3MonthName, last4MonthName, last5MonthName, last6MonthName, last7MonthName, last8MonthName, last9MonthName, last10MonthName, last11MonthName As String

    Private Sub Partners_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim todayStart = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim todayEnd = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim monthStart As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim monthEnd As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & DateTime.DaysInMonth(Now.Year, Now.Month).ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        todayEarning.InnerText = SumTotal(todayStart, todayEnd).ToString("N") & " MYR"
        monthlyEarning.InnerText = SumTotal(monthStart, monthEnd).ToString("N") & " MYR"
        Using db As New DataClassesDataContext
            newMember.InnerText = MemberCount(todayStart, todayEnd)
            pendingRequest.InnerText = TransactionCount(todayStart, todayEnd) + TransferCount(todayStart, todayEnd)
        End Using

        LoadChart()
    End Sub

    Private Function MemberCount(todayStart As Date, todayEnd As Date) As Integer
        Try
            Using db As New DataClassesDataContext
                Return (From m In db.TblMembers Where m.DateCreated >= todayStart AndAlso m.DateCreated <= todayEnd AndAlso m.Affiliate = Session("code").ToString.Trim).Count
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function TransactionCount(todayStart As Date, todayEnd As Date) As Integer
        Try
            Using db As New DataClassesDataContext
                Return (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                        From t In db.TblTransactions Where t.Status <= 1 And t.UserName = m.UserName
                        Select t).Count
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function TransferCount(todayStart As Date, todayEnd As Date) As Integer
        Try
            Using db As New DataClassesDataContext
                Return (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                        From t In db.TblTransfers Where t.Status <= 1 And t.UserName = m.UserName
                        Select t).Count
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function SumTotal(startDate As Date, endDate As Date) As Single
        Try
            Using db As New DataClassesDataContext
                Return SumCredit(startDate, endDate) - SumDebit(startDate, endDate) - SumPromotion(startDate, endDate)
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function SumCredit(startDate As Date, endDate As Date) As Single
        Try
            Using db As New DataClassesDataContext
                Return (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                        From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate AndAlso t.Status = 2 AndAlso t.UserName = m.UserName
                        Select t).Sum(Function(x) x.Credit)
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function SumDebit(startDate As Date, endDate As Date) As Single
        Try
            Using db As New DataClassesDataContext
                Return (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                        From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate AndAlso t.Status = 2 AndAlso t.UserName = m.UserName
                        Select t).Sum(Function(x) x.Debit)
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Function SumPromotion(startDate As Date, endDate As Date) As Single
        Try
            Using db As New DataClassesDataContext
                Return (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                        From t In db.TblTransactions Where t.TransactionDate >= startDate AndAlso t.TransactionDate <= endDate AndAlso t.Status = 2 AndAlso t.UserName = m.UserName
                        Select t).Sum(Function(x) x.Promotion)
            End Using
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Private Sub LoadChart()
        thisMonth = SumTotal(Now.AddDays(-Now.Day), Now.AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        lastMonth = SumTotal(Now.AddMonths(-1).AddDays(-Now.Day), Now.AddMonths(-1).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last2Month = SumTotal(Now.AddMonths(-2).AddDays(-Now.Day), Now.AddMonths(-2).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last3Month = SumTotal(Now.AddMonths(-3).AddDays(-Now.Day), Now.AddMonths(-3).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last4Month = SumTotal(Now.AddMonths(-4).AddDays(-Now.Day), Now.AddMonths(-4).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last5Month = SumTotal(Now.AddMonths(-5).AddDays(-Now.Day), Now.AddMonths(-5).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last6Month = SumTotal(Now.AddMonths(-6).AddDays(-Now.Day), Now.AddMonths(-6).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last7Month = SumTotal(Now.AddMonths(-7).AddDays(-Now.Day), Now.AddMonths(-7).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last8Month = SumTotal(Now.AddMonths(-8).AddDays(-Now.Day), Now.AddMonths(-8).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last9Month = SumTotal(Now.AddMonths(-9).AddDays(-Now.Day), Now.AddMonths(-9).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last10Month = SumTotal(Now.AddMonths(-10).AddDays(-Now.Day), Now.AddMonths(-10).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last11Month = SumTotal(Now.AddMonths(-11).AddDays(-Now.Day), Now.AddMonths(-11).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))

        thisMonthName = GetMonthName(0)
        lastMonthName = GetMonthName(-1)
        last2MonthName = GetMonthName(-2)
        last3MonthName = GetMonthName(-3)
        last4MonthName = GetMonthName(-4)
        last5MonthName = GetMonthName(-5)
        last6MonthName = GetMonthName(-6)
        last7MonthName = GetMonthName(-7)
        last8MonthName = GetMonthName(-8)
        last9MonthName = GetMonthName(-9)
        last10MonthName = GetMonthName(-10)
        last11MonthName = GetMonthName(-11)

        ClientScript.RegisterStartupScript(Page.GetType(), "OnLoad", "loadChart();", True)
    End Sub

    Private Sub LoadChartCredit()
        thisMonth = SumCredit(Now.AddDays(-Now.Day), Now.AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        lastMonth = SumCredit(Now.AddMonths(-1).AddDays(-Now.Day), Now.AddMonths(-1).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last2Month = SumCredit(Now.AddMonths(-2).AddDays(-Now.Day), Now.AddMonths(-2).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last3Month = SumCredit(Now.AddMonths(-3).AddDays(-Now.Day), Now.AddMonths(-3).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last4Month = SumCredit(Now.AddMonths(-4).AddDays(-Now.Day), Now.AddMonths(-4).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last5Month = SumCredit(Now.AddMonths(-5).AddDays(-Now.Day), Now.AddMonths(-5).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last6Month = SumCredit(Now.AddMonths(-6).AddDays(-Now.Day), Now.AddMonths(-6).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last7Month = SumCredit(Now.AddMonths(-7).AddDays(-Now.Day), Now.AddMonths(-7).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last8Month = SumCredit(Now.AddMonths(-8).AddDays(-Now.Day), Now.AddMonths(-8).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last9Month = SumCredit(Now.AddMonths(-9).AddDays(-Now.Day), Now.AddMonths(-9).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last10Month = SumCredit(Now.AddMonths(-10).AddDays(-Now.Day), Now.AddMonths(-10).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last11Month = SumCredit(Now.AddMonths(-11).AddDays(-Now.Day), Now.AddMonths(-11).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))

        thisMonthName = GetMonthName(0)
        lastMonthName = GetMonthName(-1)
        last2MonthName = GetMonthName(-2)
        last3MonthName = GetMonthName(-3)
        last4MonthName = GetMonthName(-4)
        last5MonthName = GetMonthName(-5)
        last6MonthName = GetMonthName(-6)
        last7MonthName = GetMonthName(-7)
        last8MonthName = GetMonthName(-8)
        last9MonthName = GetMonthName(-9)
        last10MonthName = GetMonthName(-10)
        last11MonthName = GetMonthName(-11)

        ClientScript.RegisterStartupScript(Page.GetType(), "OnLoad", "loadChart();", True)
    End Sub

    Private Sub LoadChartDebit()
        thisMonth = SumDebit(Now.AddDays(-Now.Day), Now.AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        lastMonth = SumDebit(Now.AddMonths(-1).AddDays(-Now.Day), Now.AddMonths(-1).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last2Month = SumDebit(Now.AddMonths(-2).AddDays(-Now.Day), Now.AddMonths(-2).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last3Month = SumDebit(Now.AddMonths(-3).AddDays(-Now.Day), Now.AddMonths(-3).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last4Month = SumDebit(Now.AddMonths(-4).AddDays(-Now.Day), Now.AddMonths(-4).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last5Month = SumDebit(Now.AddMonths(-5).AddDays(-Now.Day), Now.AddMonths(-5).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last6Month = SumDebit(Now.AddMonths(-6).AddDays(-Now.Day), Now.AddMonths(-6).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last7Month = SumDebit(Now.AddMonths(-7).AddDays(-Now.Day), Now.AddMonths(-7).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last8Month = SumDebit(Now.AddMonths(-8).AddDays(-Now.Day), Now.AddMonths(-8).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last9Month = SumDebit(Now.AddMonths(-9).AddDays(-Now.Day), Now.AddMonths(-9).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last10Month = SumDebit(Now.AddMonths(-10).AddDays(-Now.Day), Now.AddMonths(-10).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last11Month = SumDebit(Now.AddMonths(-11).AddDays(-Now.Day), Now.AddMonths(-11).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))

        thisMonthName = GetMonthName(0)
        lastMonthName = GetMonthName(-1)
        last2MonthName = GetMonthName(-2)
        last3MonthName = GetMonthName(-3)
        last4MonthName = GetMonthName(-4)
        last5MonthName = GetMonthName(-5)
        last6MonthName = GetMonthName(-6)
        last7MonthName = GetMonthName(-7)
        last8MonthName = GetMonthName(-8)
        last9MonthName = GetMonthName(-9)
        last10MonthName = GetMonthName(-10)
        last11MonthName = GetMonthName(-11)

        ClientScript.RegisterStartupScript(Page.GetType(), "OnLoad", "loadChart();", True)
    End Sub

    Private Sub LoadChartPromotion()
        thisMonth = SumPromotion(Now.AddDays(-Now.Day), Now.AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        lastMonth = SumPromotion(Now.AddMonths(-1).AddDays(-Now.Day), Now.AddMonths(-1).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last2Month = SumPromotion(Now.AddMonths(-2).AddDays(-Now.Day), Now.AddMonths(-2).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last3Month = SumPromotion(Now.AddMonths(-3).AddDays(-Now.Day), Now.AddMonths(-3).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last4Month = SumPromotion(Now.AddMonths(-4).AddDays(-Now.Day), Now.AddMonths(-4).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last5Month = SumPromotion(Now.AddMonths(-5).AddDays(-Now.Day), Now.AddMonths(-5).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last6Month = SumPromotion(Now.AddMonths(-6).AddDays(-Now.Day), Now.AddMonths(-6).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last7Month = SumPromotion(Now.AddMonths(-7).AddDays(-Now.Day), Now.AddMonths(-7).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last8Month = SumPromotion(Now.AddMonths(-8).AddDays(-Now.Day), Now.AddMonths(-8).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last9Month = SumPromotion(Now.AddMonths(-9).AddDays(-Now.Day), Now.AddMonths(-9).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last10Month = SumPromotion(Now.AddMonths(-10).AddDays(-Now.Day), Now.AddMonths(-10).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))
        last11Month = SumPromotion(Now.AddMonths(-11).AddDays(-Now.Day), Now.AddMonths(-11).AddDays(DateTime.DaysInMonth(Now.Year, Now.Month) - Now.Day))

        thisMonthName = GetMonthName(0)
        lastMonthName = GetMonthName(-1)
        last2MonthName = GetMonthName(-2)
        last3MonthName = GetMonthName(-3)
        last4MonthName = GetMonthName(-4)
        last5MonthName = GetMonthName(-5)
        last6MonthName = GetMonthName(-6)
        last7MonthName = GetMonthName(-7)
        last8MonthName = GetMonthName(-8)
        last9MonthName = GetMonthName(-9)
        last10MonthName = GetMonthName(-10)
        last11MonthName = GetMonthName(-11)

        ClientScript.RegisterStartupScript(Page.GetType(), "OnLoad", "loadChart();", True)
    End Sub

    Private Function GetMonthName(months As Integer) As String
        Dim _date = Now.AddMonths(months)
        Return MonthName(_date.Month, True) & " " & _date.Year
    End Function

    Private Sub lbCredit_Click(sender As Object, e As EventArgs) Handles lbCredit.Click
        LoadChartCredit()
    End Sub

    Private Sub lbDebit_Click(sender As Object, e As EventArgs) Handles lbDebit.Click
        LoadChartDebit()
    End Sub

    Private Sub lbPromo_Click(sender As Object, e As EventArgs) Handles lbPromo.Click
        LoadChartPromotion()
    End Sub

    Private Sub lbTotal_Click(sender As Object, e As EventArgs) Handles lbTotal.Click
        LoadChart()
    End Sub

End Class
