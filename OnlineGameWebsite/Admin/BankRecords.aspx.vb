
Imports System.Drawing

Partial Class Admin_BankRecords
    Inherits System.Web.UI.Page

    Public bid As String = -1

    Public cdtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue}
    Public dbtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red}

    Private Sub Admin_BankRecords_Load(sender As Object, e As EventArgs) Handles Me.Load
        bid = Request.QueryString("id")

        If Not IsPostBack Then
            Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
            txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")

            If bid <> Nothing Then
                Using db As New DataClassesDataContext
                    Dim bankInfo = db.TblBanks.Single(Function(x) x.BankID = bid)
                    h6.InnerText = bankInfo.BankName & " (" & bankInfo.AccountName.Trim & ")"

                    Dim cdt, dbt As Single
                    Dim records = (From r In db.TblBankRecords Where r.RecordDatetime >= start AndAlso r.RecordDatetime <= [end]).OrderByDescending(Function(x) x.RecordDatetime)
                    For Each r As TblBankRecord In records
                        dataTable.AddBankRecordTableItem(r.BRecordID, r.TransactionID, r.RecordDatetime, r.Description, r.Credit, r.Debit)
                        cdt += r.Credit
                        dbt += r.Debit
                    Next
                    cdtTotal.Text = Strong(cdt.ToString("N"))
                    dbtTotal.Text = Strong(dbt.ToString("N"))
                    dataTable.AddTableFooter("", "", "", "", cdtTotal, dbtTotal, "")
                End Using
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        Using db As New DataClassesDataContext
            Dim cdt, dbt As Single
            Dim records = (From r In db.TblBankRecords Where r.RecordDatetime >= start AndAlso r.RecordDatetime <= [end]).OrderByDescending(Function(x) x.RecordDatetime)
            For Each r As TblBankRecord In records
                dataTable.AddBankRecordTableItem(r.BRecordID, r.TransactionID, r.RecordDatetime, r.Description, r.Credit, r.Debit)
                cdt += r.Credit
                dbt += r.Debit
            Next
            cdtTotal.Text = Strong(cdt.ToString("N"))
            dbtTotal.Text = Strong(dbt.ToString("N"))
            dataTable.AddTableFooter("", "", "", "", cdtTotal, dbtTotal, "")
        End Using
    End Sub

    Private Sub btnCredit_Click(sender As Object, e As EventArgs) Handles btnCredit.Click
        Response.Redirect("AddBankSummary.aspx?mode=credit&id=" & bid)
    End Sub

    Private Sub btnDebit_Click(sender As Object, e As EventArgs) Handles btnDebit.Click
        Response.Redirect("AddBankSummary.aspx?mode=debit&id=" & bid)
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        Response.Redirect("AddBankSummary.aspx?mode=transfer&id=" & bid)
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
