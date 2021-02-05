
Imports System.Drawing

Partial Class Admin_TransactionReminder
    Inherits System.Web.UI.Page

    Public cdtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue}
    Public dbtTotal As New TableCell() With {.Text = "<b>0.00</b>", .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red}

    Dim PlayWhat As ePlayWhat = ePlayWhat.Nope

    Private Sub Admin_TransactionReminder_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim cdt, dbt As Single
            Dim trans = db.TblTransactions.Where(Function(x) x.Status <= 1).OrderByDescending(Function(x) x.TransactionID)
            For Each t As TblTransaction In trans
                Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
                Dim p As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ProductID)
                dataTable.AddTransactionTableItem(t.TransactionID, t.TransactionDate, t.UserName, m.FullName, p.ProductName, t.ProductUserName, t.Method, t.Status, t.Credit, t.Debit, t.Promotion, t.TransType)
                If t.Status = 2 Then
                    cdt += t.Credit
                    dbt += t.Debit
                End If
            Next
            If Not trans.Count = 0 Then
                Dim first = trans.First
                Select Case trans.First.TransType
                    Case 0, 2
                        PlayWhat = ePlayWhat.Deposit
                    Case 1
                        PlayWhat = ePlayWhat.Withdrawal
                End Select
            End If
            cdtTotal.Text = Strong(cdt.ToString("N"))
            dbtTotal.Text = Strong(dbt.ToString("N"))
        End Using
        dataTable.AddTableFooter("", "", "", "", "", "", cdtTotal, dbtTotal, "", "", "")

        Using db As New DataClassesDataContext
            Dim trans = db.TblTransfers.Where(Function(x) x.Status <= 1).OrderByDescending(Function(x) x.TransferID)
            For Each t As TblTransfer In trans
                Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
                Dim pf As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.FromProductID)
                Dim pt As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ToProductID)
                dataTable2.AddTransferTableItem(t.TransferID, t.TransferDate, t.UserName.Trim, m.FullName.Trim, pf.ProductName.Trim, t.FromUserName.Trim, pt.ProductName.Trim, t.ToUserName.Trim, t.Amount, t.Status)
            Next
            If Not trans.Count = 0 AndAlso PlayWhat = ePlayWhat.Nope Then
                PlayWhat = ePlayWhat.Transfer
            End If
        End Using

        Select Case PlayWhat
            Case ePlayWhat.Deposit
                PlaySound("deposit.mp3")
            Case ePlayWhat.Withdrawal
                PlaySound("withdraw.mp3")
            Case ePlayWhat.Transfer
                PlaySound("transfer.mp3")
        End Select
    End Sub

    Private Enum ePlayWhat
        Nope
        Deposit
        Withdrawal
        Transfer
    End Enum

    Private Sub PlaySound(file As String)
        depositAlert.Src = "sound/" & file
        depositAlert.Attributes.Add("autoplay", "autoplay")
        depositAlert.Visible = True
    End Sub

End Class
