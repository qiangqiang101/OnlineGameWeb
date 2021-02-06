
Imports System.Drawing

Partial Class Admin_BankRecords
    Inherits System.Web.UI.Page

    Public bid As String = -1

    Public cdtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue}
    Public dbtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red}

    Private Sub Admin_BankRecords_Load(sender As Object, e As EventArgs) Handles Me.Load
        bid = Request.QueryString("id")

        If bid <> Nothing Then
            Using db As New DataClassesDataContext
                Dim bankInfo = db.TblBanks.Single(Function(x) x.BankID = bid)
                h6.InnerText = bankInfo.BankName & " (" & bankInfo.AccountName.Trim & ")"

                Dim cdt, dbt As Single
                Dim records = db.TblBankRecords.Where(Function(x) x.BankID = bid).OrderByDescending(Function(x) x.RecordDatetime)
                For Each r As TblBankRecord In records
                    dataTable.AddTableItem(r.BRecordID.ToString("00000"), r.TransactionID.ToString("00000"), r.RecordDatetime.ToString(dateFormat), r.Description.Trim, r.Credit.ToString("N"), r.Debit.ToString("N"),
                                           RB("AddBankSummary.aspx?mode=delete&id=" & r.BRecordID, "fas fa-trash", "btn-danger", "Delete"))
                    cdt += r.Credit
                    dbt += r.Debit
                Next
                cdtTotal.Text = Strong(cdt.ToString("N"))
                dbtTotal.Text = Strong(dbt.ToString("N"))
                dataTable.AddTableFooter("", "", "", "", cdtTotal, dbtTotal, "")
            End Using
        End If
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
End Class
