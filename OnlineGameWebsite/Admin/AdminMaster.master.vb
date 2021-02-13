
Partial Class Admin_AdminMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Admin_AdminMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game") & " - Back Office"
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Abandon()
        Response.Redirect("AdminLogin.aspx")
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Dim role As String = HttpContext.Current.Session("role")
        Dim userid As String = HttpContext.Current.Session("userid")

        If Not Page.IsPostBack Then
            Select Case role
                Case "Administrator", "Full Administrator", "Customer Serivce"
                    navbaruser.InnerText = Session("fullname")
                    navbarProfile.HRef = "EditUser.aspx?mode=profile&id=" & userid
                Case Else
                    Page.swalBsRedirect("AdminLogin.aspx", "Hello", "Please Login to continue.", "warning")
            End Select
        End If

        Using db As New DataClassesDataContext
            Dim transactions = db.TblTransactions.Where(Function(x) x.Status <= 1)
            Dim transfers = db.TblTransfers.Where(Function(x) x.Status <= 1)
            Dim alertCount As Integer = transactions.Count + transfers.Count
            If alertCount = 0 Then
                alertNumber.Visible = False
            Else
                If alertCount >= 9 Then
                    alertNumber.InnerText = "9+"
                Else
                    alertNumber.InnerText = alertCount
                End If

                Dim transactions9 = transactions.OrderByDescending(Function(x) x.TransactionDate).Take(9)
                For Each t In transactions9
                    Dim bold = t.Status = 0
                    If t.TransType = 0 Then
                        Dim msg = t.UserName.Trim & " sent a deposit request amount of " & t.Credit.ToString("N") & " MYR."
                        alertDropdown.Controls.Add(GenerateAlert("fas fa-coins", t.TransactionDate.ToString(dateFormat), msg, bold:=bold))
                    ElseIf t.TransType = 1 Then
                        Dim msg = t.UserName.Trim & " sent a withdrawal request amount of " & t.Debit.ToString("N") & " MYR."
                        alertDropdown.Controls.Add(GenerateAlert("fas fa-hand-holding-usd", t.TransactionDate.ToString(dateFormat), msg, "bg-danger", bold:=bold))
                    Else
                        Dim msg = t.UserName.Trim & " sent a promotion request amount of " & t.Promotion.ToString("N") & " MYR."
                        alertDropdown.Controls.Add(GenerateAlert("fas fa-percentage", t.TransactionDate.ToString(dateFormat), msg, "bg-warning", bold:=bold))
                    End If
                Next
                If transactions9.Count <= 9 Then
                    Dim transfer_ = transfers.OrderByDescending(Function(x) x.ApproveDate).Take(9 - transactions9.Count)
                    For Each t In transfer_
                        Dim msg = t.UserName.Trim & " sent a transfer request amount of " & t.Amount.ToString("N") & " MYR from " & GetProductName(t.FromProductID) & " to " & GetProductName(t.ToProductID) & "."
                        Dim bold = t.Status = 0
                        alertDropdown.Controls.Add(GenerateAlert("fas fa-exchange-alt", t.TransferDate.ToString(dateFormat), msg, "bg-success", "Transfers.aspx", bold))
                    Next
                End If
            End If
            alertDropdown.Controls.Add(New HtmlGenericControl("a") With {.InnerHtml = "<a class=""dropdown-item text-center small text-gray-500"" href=""TransactionReminder.aspx"">Show All Alerts</a>"})
        End Using

    End Sub

    ''' <summary>
    ''' bg-primary, bg-success, bg-warning
    ''' </summary>
    ''' <param name="fafa"></param>
    ''' <param name="[date]"></param>
    ''' <param name="text"></param>
    ''' <param name="bg"></param>
    ''' <returns></returns>
    Private Function GenerateAlert(fafa As String, [date] As String, text As String, Optional bg As String = "bg-primary", Optional href As String = "Transactions.aspx", Optional bold As Boolean = False) As HtmlGenericControl
        Dim n = vbNewLine
        Dim a = New HtmlGenericControl("a")
        With a
            .Attributes("class") = "dropdown-item d-flex align-items-center"
            .Attributes("href") = href
            .InnerHtml = n & "<div class=""mr-3"">" & n & "<div class=""icon-circle " & bg & """>" & n & "<i class=""" & fafa & " text-white""></i>" & n & "</div>" & n & "</div><div><div class=""small text-gray-500"">" & [date] & "</div>" & n & If(bold, "<span class=""font-weight-bold"">" & text & "</span>", text) & n & "</div>" & n
        End With
        Return a
    End Function

End Class

