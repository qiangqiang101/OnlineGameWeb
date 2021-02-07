
Imports System.Drawing

Partial Class Admin_Transaction
    Inherits System.Web.UI.Page

    Public cdtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue}
    Public dbtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red}

    Private Sub Admin_Transaction_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
            txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")

            Using db As New DataClassesDataContext
                Dim cdt, dbt As Single
                Dim trans = (From t In db.TblTransactions Where t.TransactionDate >= start AndAlso t.TransactionDate <= [end]).OrderByDescending(Function(x) x.TransactionID)
                For Each t As TblTransaction In trans
                    Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
                    Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                    dataTable.AddTransactionTableItem(t.TransactionID, t.TransactionDate, t.UserName, m.FullName, p.ProductName, t.ProductUserName, t.Method, t.Status, t.Credit, t.Debit, t.Promotion, t.TransType)
                    If t.Status = 2 Then
                        cdt += t.Credit
                        dbt += t.Debit
                    End If
                Next
                cdtTotal.Text = Strong(cdt.ToString("N"))
                dbtTotal.Text = Strong(dbt.ToString("N"))
            End Using
            dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        Using db As New DataClassesDataContext
            Dim cdt, dbt As Single
            Dim trans = (From t In db.TblTransactions Where t.TransactionDate >= start AndAlso t.TransactionDate <= [end]).OrderByDescending(Function(x) x.TransactionID)
            For Each t As TblTransaction In trans
                Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
                Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                dataTable.AddTransactionTableItem(t.TransactionID, t.TransactionDate, t.UserName, m.FullName, p.ProductName, t.ProductUserName, t.Method, t.Status, t.Credit, t.Debit, t.Promotion, t.TransType)
                cdt += t.Credit
                dbt += t.Debit
            Next
            cdtTotal.Text = Strong(cdt.ToString("N"))
            dbtTotal.Text = Strong(dbt.ToString("N"))
        End Using
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub

    Private Sub all_Click(sender As Object, e As EventArgs) Handles all.Click
        Dim start As Date = Date.ParseExact("1990-01-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & DateTime.DaysInMonth(Now.Year, Now.Month).ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub

    Private Sub mtl_Click(sender As Object, e As EventArgs) Handles mtl.Click
        Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & DateTime.DaysInMonth(Now.Year, Now.Month).ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub

    Private Sub n1d_Click(sender As Object, e As EventArgs) Handles n1d.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.AddDays(-1).ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].AddDays(-1).ToString("yyyy-MM-ddTHH:mm")
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub

    Private Sub n7d_Click(sender As Object, e As EventArgs) Handles n7d.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.AddDays(-7).ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub

    Private Sub p1d_Click(sender As Object, e As EventArgs) Handles p1d.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.AddDays(1).ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].AddDays(1).ToString("yyyy-MM-ddTHH:mm")
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub

    Private Sub today_Click(sender As Object, e As EventArgs) Handles today.Click
        Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
        txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")
    End Sub
End Class
