
Partial Class Partners_Transfers
    Inherits System.Web.UI.Page

    Private Sub Partners_Transfers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If Not IsPostBack Then
            If role = "partner" Then
                Dim start As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Dim [end] As Date = Date.ParseExact(Now.Year & "-" & Now.Month.ToString("00") & "-" & Now.Day.ToString("00") & "T23:59", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                txtDateFrom.Text = start.ToString("yyyy-MM-ddTHH:mm")
                txtDateTo.Text = [end].ToString("yyyy-MM-ddTHH:mm")

                Using db As New DataClassesDataContext
                    Dim trans = (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                                 From t In db.TblTransfers Where t.UserName = m.UserName And t.TransferDate >= start AndAlso t.TransferDate <= [end]
                                 Select t).OrderByDescending(Function(x) x.TransferID)
                    For Each t As TblTransfer In trans
                        Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
                        Dim pf As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.FromProductID)
                        Dim pt As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ToProductID)
                        dataTable.AddPTransferTableItem(t.TransferID, t.TransferDate, t.UserName.Trim, m.FullName.Trim, pf.ProductName.Trim, t.FromUserName.Trim, pt.ProductName.Trim, t.ToUserName.Trim, t.Amount, t.Status)
                    Next
                End Using
            Else
                swalBsRedirect("PartnerLogin.aspx", "Hello", "Please Login to continue.", "warning")
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim start As Date = Date.ParseExact(txtDateFrom.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Dim [end] As Date = Date.ParseExact(txtDateTo.Text, "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        Using db As New DataClassesDataContext
            Dim trans = (From m In db.TblMembers Where m.Affiliate = Session("code").ToString.Trim
                         From t In db.TblTransfers Where t.UserName = m.UserName And t.TransferDate >= start AndAlso t.TransferDate <= [end]
                         Select t).OrderByDescending(Function(x) x.TransferID)
            For Each t As TblTransfer In trans
                Dim m As TblMember = db.TblMembers.Single(Function(x) x.UserName = t.UserName)
                Dim pf As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.FromProductID)
                Dim pt As TblProduct = db.TblProducts.Single(Function(x) x.ProductID = t.ToProductID)
                dataTable.AddPTransferTableItem(t.TransferID, t.TransferDate, t.UserName.Trim, m.FullName.Trim, pf.ProductName.Trim, t.FromUserName.Trim, pt.ProductName.Trim, t.ToUserName.Trim, t.Amount, t.Status)
            Next
        End Using
    End Sub

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
