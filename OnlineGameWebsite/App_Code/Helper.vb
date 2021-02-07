Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic

Public Module Helper

    Public dateFormat As String = "yyyy-MM-dd HH:mm:ss"
    Public upload As String = "~/Upload/" & Now.Year & "/" & Now.Month & "/" & Now.Day & "/"
    Public promoTnc As String = "~/Promo/" & Now.Year & "/" & Now.Month & "/" & Now.Day & "/"
    Public logPath As String = HttpContext.Current.ApplicationInstance.Server.MapPath("~\App_Data\")

    <Extension>
    Public Sub JsMsgBox(page As Page, text As String)
        page.Response.Write("<script>alert('" & text & "');</script>")
    End Sub

    ''' <summary>
    ''' And with a third argument, you can add an icon to your alert! There are 4 predefined ones: "warning", "error", "success" and "info".
    ''' </summary>
    ''' <param name="page"></param>
    ''' <param name="texts"></param>
    <Extension>
    Public Sub swal(page As Page, ParamArray texts As String())
        Dim texts2 As New List(Of String)
        For Each txt In texts
            texts2.Add("'" & txt & "'")
        Next
        Dim result = String.Join(", ", texts2)
        page.ClientScript.RegisterStartupScript(page.GetType, "SweetAlert", "swalTheme.fire(" & result & ");", True)
    End Sub

    <Extension>
    Public Sub swal(page As Page, text As String)
        page.ClientScript.RegisterStartupScript(page.GetType, "SweetAlert", "swalTheme.fire(" & text & ");", True)
    End Sub

    ''' <summary>
    ''' And with a third argument, you can add an icon to your alert! There are 4 predefined ones: "warning", "error", "success" and "info".
    ''' </summary>
    ''' <param name="page"></param>
    ''' <param name="redirect"></param>
    ''' <param name="texts"></param>
    <Extension>
    Public Sub swalRedirect(page As Page, redirect As String, ParamArray texts As String())
        Dim texts2 As New List(Of String)
        For Each txt In texts
            texts2.Add("'" & txt & "'")
        Next
        Dim result = String.Join(", ", texts2)
        page.ClientScript.RegisterStartupScript(page.GetType, "SweetAlert", "swalTheme.fire(" & result & ").then(function() {window.location = '" & redirect & "';});", True)
    End Sub

    <Extension>
    Public Sub LoginMsgBox(page As Page)
        swalRedirect(page, "Default.aspx", Resources.Resource.LoginHello, Resources.Resource.PleaseLogin, "warning")
    End Sub

    <Extension>
    Public Sub JsMsgBoxRedirect(page As Page, text As String, redirect As String)
        page.Response.Write("<script>alert('" & text & "');</script>")
        page.Response.Write("<script>window.location.href='" & redirect & "';</script>")
    End Sub

    Public Function IsMemberExists(username As String) As Boolean
        Using db As New DataClassesDataContext
            Dim check = (From m In db.TblMembers Where m.UserName = username).ToList
            Dim members = (From m In db.TblMembers)
            If members.Contains(check.FirstOrDefault) Then Return True
            Return False
        End Using
    End Function

    Public Function IsUserExists(username As String) As Boolean
        Using db As New DataClassesDataContext
            Dim check = (From u In db.TblUsers Where u.UserName = username).ToList
            Dim users = (From m In db.TblUsers)
            If users.Contains(check.FirstOrDefault) Then Return True
            Return False
        End Using
    End Function

    Public Function IsEmailExists(email As String, Optional checkMember As Boolean = True) As Boolean
        If checkMember Then
            Using db As New DataClassesDataContext
                Dim check = (From m In db.TblMembers Where m.Email = email).ToList
                Dim members = (From m In db.TblMembers)
                If members.Contains(check.FirstOrDefault) Then Return True
                Return False
            End Using
        Else
            Using db As New DataClassesDataContext
                Dim check = (From u In db.TblUsers Where u.Email = email).ToList
                Dim users = (From m In db.TblUsers)
                If users.Contains(check.FirstOrDefault) Then Return True
                Return False
            End Using
        End If
    End Function

    Public Function IsEmailValid(email As String) As Boolean
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As Match = Regex.Match(email, pattern, RegexOptions.IgnoreCase)
        Return match.Success
    End Function

    Public Function IsMemberLoginSuccess(username As String, password As String, page As Page) As Boolean
        If IsEmailValid(username) Then
            Using db As New DataClassesDataContext
                Dim member = (From m In db.TblMembers Where m.Email = username And m.Password = password).FirstOrDefault
                If member IsNot Nothing Then
                    If member.Enabled Then
                        page.Session("userid") = member.UserID
                        page.Session("username") = member.UserName
                        page.Session("fullname") = member.FullName
                        page.Session("email") = member.Email
                        page.Session("role") = "user"

                        Return True
                    Else
                        Return False
                    End If
                End If
            End Using
        Else
            Using db As New DataClassesDataContext
                Dim member = (From m In db.TblMembers Where m.UserName = username And m.Password = password).FirstOrDefault
                If member IsNot Nothing Then
                    If member.Enabled Then
                        page.Session("userid") = member.UserID
                        page.Session("username") = member.UserName
                        page.Session("fullname") = member.FullName
                        page.Session("email") = member.Email
                        page.Session("role") = "user"

                        Return True
                    Else
                        Return False
                    End If
                End If
            End Using
        End If
        Return False
    End Function

    Public Function IsAdminLoginSuccess(username As String, password As String, page As Page) As Boolean
        If IsEmailValid(username) Then
            Try
                Using db As New DataClassesDataContext
                    Dim user = db.TblUsers.Single(Function(x) x.Email = username AndAlso x.Password = password)
                    If user.Status Then
                        page.Session("userid") = user.UserID
                        page.Session("username") = user.UserName
                        page.Session("fullname") = user.FullName
                        page.Session("email") = user.Email
                        page.Session("role") = UserRoleToString(user.UserRole)

                        Return True
                    End If
                End Using
            Catch ex As Exception
                Log(ex)
                Return False
            End Try
        Else
            Try
                Using db As New DataClassesDataContext
                    Dim user = db.TblUsers.Single(Function(x) x.UserName = username AndAlso x.Password = password)
                    If user.Status Then
                        page.Session("userid") = user.UserID
                        page.Session("username") = user.UserName
                        page.Session("fullname") = user.FullName
                        page.Session("email") = user.Email
                        page.Session("role") = UserRoleToString(user.UserRole)

                        Return True
                    End If
                End Using
            Catch ex As Exception
                Log(ex)
                Return False
            End Try
        End If
        Return False
    End Function

    Public Sub UpdateUserLastLogin(username As String, ip As String)
        Using db As New DataClassesDataContext
            Dim user = db.TblUsers.Single(Function(x) x.UserName = username)
            With user
                .LastLoginDate = Now
                .LastLoginIP = ip
            End With
            db.SubmitChanges()
        End Using
    End Sub

    Public Function RB(action As String, css As String, Optional button As String = "btn-primary", Optional tooltip As String = "") As String
        Return RoundButton(action, css, button, tooltip) & " "
    End Function

    Public Function RoundButton(action As String, css As String, Optional button As String = "btn-primary", Optional tooltip As String = "") As String
        Return String.Format("<a href={0}{1}{0} class={0}btn {2} btn-circle btn-sm{0} data-toggle={0}tooltip{0} title={0}{3}{0}><i class={0}{4}{0}></i></a>", """", action, button, tooltip, css)
    End Function

    Public Function RoundModalButton(target As String, css As String, id As String, Optional button As String = "btn-primary") As String
        Return "<a href=""#" & id & """ data-toggle=""modal"" data-target=""" & target & """ class=""btn " & button & " btn-circle btn-sm""><i class=""" & css & """></i></a>"
    End Function

    Public Function DeleteButton(url As String, Optional button As String = "fa-times", Optional tooltip As String = Nothing) As String
        Return "<a href=""javascript:swalTheme.fire({title: '" & Resources.Resource.RuSure & "', text: '" & Resources.Resource.OnceCancelled & "', icon: 'warning', showCancelButton: true, confirmButtonText: '" & Resources.Resource.Yes & "', cancelButtonText: '" & Resources.Resource.No & "'})" &
            ".then((result) => {if (result.isConfirmed) {swalTheme.fire('" & Resources.Resource.Success & "', '" & Resources.Resource.TransactionCancelled & "', 'success').then(function() {window.location = '" & url & "';})} else if (result.dismiss === swal.DismissReason.cancel)" &
            " {swalTheme.fire('Okay', '" & Resources.Resource.OperationCancelled & "', 'success')}})"" data-toggle=""tooltip"" title=""" & tooltip & """><i class=""fas " & button & """></i></a>"
    End Function

    Public Function RRButton(swal As String, Optional button As String = "fa-times", Optional tooltip As String = Nothing) As String
        Return String.Format("<a href={0}javascript:swalTheme.fire({1});{0} data-toggle={0}tooltip{0} title={0}{3}{0}><i class={0}fas {2}{0}></i></a>", """", swal, button, tooltip)
    End Function

    Public Function GAButton(swal As String, Optional button As String = "fa-times", Optional tooltip As String = Nothing) As String
        Return String.Format("<a href={0}javascript:swalTheme.fire({1});{0} data-toggle={0}tooltip{0} title={0}{3}{0}><i class={0}fas {2}{0}></i></a>", """", swal, button, tooltip)
    End Function

    <Extension>
    Public Sub AddTableItem(table As Table, ParamArray items As String())
        Dim row As New TableRow()
        For Each item In items
            row.Cells.Add(New TableCell() With {.Text = item})
        Next
        table.Rows.Add(row)
    End Sub

    <Extension>
    Public Sub AddTableFooter(table As Table, ParamArray items As Object())
        Dim frow As New TableFooterRow() With {.TableSection = TableRowSection.TableFooter}
        For Each item In items
            If TypeOf item Is TableCell Then
                frow.Cells.Add(item)
            Else
                frow.Cells.Add(New TableCell() With {.Text = ""})
            End If
        Next
        frow.BackColor = Color.WhiteSmoke
        table.Rows.Add(frow)
    End Sub

    <Extension>
    Public Sub AddBankSummaryTableItem(table As Table, id As Integer, img As String, bank As String, name As String, account As String, credit As Single, debit As Single, balance As Single)
        Dim row As New TableRow()
        row.Cells.Add(New TableCell() With {.Text = id.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = img})
        row.Cells.Add(New TableCell() With {.Text = bank.Trim})
        row.Cells.Add(New TableCell() With {.Text = name.Trim})
        row.Cells.Add(New TableCell() With {.Text = account.Trim})
        row.Cells.Add(New TableCell() With {.Text = credit.ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
        row.Cells.Add(New TableCell() With {.Text = debit.ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
        row.Cells.Add(New TableCell() With {.Text = balance.ToString("N"), .HorizontalAlign = HorizontalAlign.Right})
        row.Cells.Add(New TableCell() With {.Text = RB("BankRecords.aspx?id=" & id, "fas fa-eye", tooltip:="Bank Record") & RB("AddBankSummary.aspx?mode=credit&id=" & id, "fas fa-coins", "btn-success", "Add Credit") &
                                       RB("AddBankSummary.aspx?mode=debit&id=" & id, "fas fa-hand-holding-usd", "btn-danger", "Add Debit") & RB("AddBankSummary.aspx?mode=transfer&id=" & id, "fas fa-exchange-alt", "btn-warning", "Add Transfer")})
        table.Rows.Add(row)
    End Sub

    <Extension>
    Public Sub AddBankRecordTableItem(table As Table, bid As Integer, tid As Integer, tdate As Date, desc As String, credit As Single, debit As Single)
        Dim row As New TableRow()
        row.Cells.Add(New TableCell() With {.Text = bid.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = tid.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = tdate.ToString(dateFormat)})
        row.Cells.Add(New TableCell() With {.Text = desc.Trim})
        row.Cells.Add(New TableCell() With {.Text = If(credit <> 0F, credit.ToString("N"), ""), .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue})
        row.Cells.Add(New TableCell() With {.Text = If(debit <> 0F, debit.ToString("N"), ""), .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red})
        row.Cells.Add(New TableCell() With {.Text = RB("AddBankSummary.aspx?mode=delete&id=" & bid, "fas fa-trash", "btn-danger", "Delete")})
        table.Rows.Add(row)
    End Sub

    <Extension>
    Public Sub AddTransactionTableItem(table As Table, id As Integer, tdate As Date, userid As String, fullname As String, productname As String, productUN As String, method As String, status As Integer, credit As Single, debit As Single, promo As Single, type As Integer)
        Dim row As New TableRow()
        row.Cells.Add(New TableCell() With {.Text = id.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = tdate.ToString(dateFormat)})
        row.Cells.Add(New TableCell() With {.Text = userid.Trim})
        row.Cells.Add(New TableCell() With {.Text = fullname.Trim})
        row.Cells.Add(New TableCell() With {.Text = productname.Trim & " (" & productUN.Trim & ")"})
        row.Cells.Add(New TableCell() With {.Text = method.Trim})
        row.Cells.Add(New TableCell() With {.Text = If(credit <> 0F, credit.ToString("N"), If(promo <> 0F, promo.ToString("N"), "")), .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue})
        row.Cells.Add(New TableCell() With {.Text = If(debit <> 0F, debit.ToString("N"), ""), .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red})
        row.Cells.Add(New TableCell() With {.Text = If(type = 0, "Credit", If(type = 2, "Promotion", "Debit"))})
        Dim statusColor As Color = Color.Blue
        Select Case status
            Case 0, 1
                statusColor = Color.Blue
            Case 2
                statusColor = Color.Green
            Case Else
                statusColor = Color.Red
        End Select
        row.Cells.Add(New TableCell() With {.Text = StatusToString(status), .BackColor = statusColor, .ForeColor = Color.White})
        Select Case type
            Case 0
                row.Cells.Add(New TableCell() With {.Text = RB("EditDeposit.aspx?mode=edit&id=" & id, "fas fa-eye", tooltip:="Edit")})
            Case 1
                row.Cells.Add(New TableCell() With {.Text = RB("EditWithdrawal.aspx?mode=edit&id=" & id, "fas fa-eye", tooltip:="Edit")})
            Case Else
                If status <= 1 Then
                    row.Cells.Add(New TableCell() With {.Text = RB("EditDeposit.aspx?mode=promo&id=" & id, "fas fa-eye", tooltip:="Edit") &
                                  RB("EditDeposit.aspx?mode=approve&id=" & id, "fas fa-check", "btn-success", "Approve") &
                                  RB("EditDeposit.aspx?mode=reject&id=" & id, "fas fa-times", "btn-danger", "Reject")})
                Else
                    row.Cells.Add(New TableCell() With {.Text = RB("EditDeposit.aspx?mode=promo&id=" & id, "fas fa-eye", tooltip:="Edit")})
                End If
        End Select
        table.Rows.Add(row)
    End Sub

    <Extension>
    Public Sub AddTransactionTableItem(table As Table, id As Integer, tdate As Date, productname As String, productUN As String, method As String, status As Integer, credit As Single, debit As Single, promo As Single, type As Integer)
        Dim row As New TableRow()
        row.Cells.Add(New TableCell() With {.Text = id.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = tdate.ToString(dateFormat)})
        row.Cells.Add(New TableCell() With {.Text = productname.Trim & " (" & productUN.Trim & ")"})
        row.Cells.Add(New TableCell() With {.Text = method.Trim})
        row.Cells.Add(New TableCell() With {.Text = If(credit <> 0F, credit.ToString("N"), If(promo <> 0F, promo.ToString("N"), "")), .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Blue})
        row.Cells.Add(New TableCell() With {.Text = If(debit <> 0F, debit.ToString("N"), ""), .HorizontalAlign = HorizontalAlign.Right, .ClientIDMode = ClientIDMode.Static, .ForeColor = Color.Red})
        row.Cells.Add(New TableCell() With {.Text = If(type = 0, "Credit", If(type = 2, "Promotion", "Debit"))})
        Dim statusColor As Color = Color.Blue
        Select Case status
            Case 0, 1
                statusColor = Color.Blue
            Case 2
                statusColor = Color.Green
            Case Else
                statusColor = Color.Red
        End Select
        row.Cells.Add(New TableCell() With {.Text = StatusToString(status), .BackColor = statusColor, .ForeColor = Color.White})
        table.Rows.Add(row)
    End Sub

    <Extension>
    Public Sub AddTransferTableItem(table As Table, id As Integer, tdate As Date, userid As String, fullname As String, frPdtName As String, frPdtUN As String, toPdtName As String, toPdtUN As String, amount As Single, status As Integer)
        Dim row As New TableRow()
        row.Cells.Add(New TableCell() With {.Text = id.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = tdate.ToString(dateFormat)})
        row.Cells.Add(New TableCell() With {.Text = userid.Trim})
        row.Cells.Add(New TableCell() With {.Text = fullname.Trim})
        row.Cells.Add(New TableCell() With {.Text = frPdtName.Trim & " (" & frPdtUN.Trim & ")"})
        row.Cells.Add(New TableCell() With {.Text = toPdtName.Trim & " (" & toPdtUN.Trim & ")"})
        row.Cells.Add(New TableCell() With {.Text = amount.ToString("N")})
        Dim statusColor As Color = Color.Blue
        Select Case status
            Case 0, 1
                statusColor = Color.Blue
            Case 2
                statusColor = Color.Green
            Case Else
                statusColor = Color.Red
        End Select
        row.Cells.Add(New TableCell() With {.Text = StatusToString(status), .BackColor = statusColor, .ForeColor = Color.White})
        If status <= 1 Then
            row.Cells.Add(New TableCell() With {.Text = RB("EditTransfer.aspx?mode=edit&id=" & id, "fas fa-eye", tooltip:="Edit") &
                                  RB("EditTransfer.aspx?mode=approve&id=" & id, "fas fa-check", "btn-success", "Approve") &
                                  RB("EditTransfer.aspx?mode=reject&id=" & id, "fas fa-times", "btn-danger", "Reject")})
        Else
            row.Cells.Add(New TableCell() With {.Text = RB("EditTransfer.aspx?mode=edit&id=" & id, "fas fa-eye", tooltip:="Edit")})
        End If
        table.Rows.Add(row)
    End Sub

    <Extension>
    Public Sub AddTransferTableItem(table As Table, id As Integer, tdate As Date, frPdtName As String, frPdtUN As String, toPdtName As String, toPdtUN As String, amount As Single, status As Integer)
        Dim row As New TableRow()
        row.Cells.Add(New TableCell() With {.Text = id.ToString("00000")})
        row.Cells.Add(New TableCell() With {.Text = tdate.ToString(dateFormat)})
        row.Cells.Add(New TableCell() With {.Text = frPdtName.Trim & " (" & frPdtUN.Trim & ")"})
        row.Cells.Add(New TableCell() With {.Text = toPdtName.Trim & " (" & toPdtUN.Trim & ")"})
        row.Cells.Add(New TableCell() With {.Text = amount.ToString("N")})
        Dim statusColor As Color = Color.Blue
        Select Case status
            Case 0, 1
                statusColor = Color.Blue
            Case 2
                statusColor = Color.Green
            Case Else
                statusColor = Color.Red
        End Select
        row.Cells.Add(New TableCell() With {.Text = StatusToString(status), .BackColor = statusColor, .ForeColor = Color.White})
        table.Rows.Add(row)
    End Sub

    Public Function StatusToString(status As Integer) As String
        Select Case status
            Case 0
                Return "New"
            Case 1
                Return "Pending"
            Case 2
                Return "Approved"
            Case 3
                Return "Rejected"
            Case 4
                Return "Cancelled"
            Case Else
                Return "Error"
        End Select
    End Function

    Public Enum ePending
        Transaction
        Transfer
    End Enum

    Public Sub Pending(tid As Integer, Optional ePen As ePending = ePending.Transaction)
        Try
            Using db As New DataClassesDataContext
                Select Case ePen
                    Case ePending.Transaction
                        Dim t = db.TblTransactions.Single(Function(x) x.TransactionID = tid)
                        If t.Status = 0 Then
                            t.Status = 1
                            db.SubmitChanges()
                        End If
                    Case Else
                        Dim t = db.TblTransfers.Single(Function(x) x.TransferID = tid)
                        If t.Status = 0 Then
                            t.Status = 1
                            db.SubmitChanges()
                        End If
                End Select
            End Using
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    <Extension>
    Public Function MemberBank(member As TblMember) As String
        Try
            Select Case member.BankName
                Case 0
                    Return "Maybank"
                Case 1
                    Return "CIMB Bank"
                Case 2
                    Return "Public Bank"
                Case 3
                    Return "RHB Bank"
                Case 4
                    Return "Hong Leong Bank"
                Case 5
                    Return "AmBank"
                Case 6
                    Return "UOB Bank"
                Case 7
                    Return "Bank Rakyat"
                Case 8
                    Return "OCBC Bank"
                Case 9
                    Return "HSBC Bank"
                Case 10
                    Return "Affin Bank"
                Case 11
                    Return "Bank Islam"
                Case 12
                    Return "Standard Chartered Bank"
                Case 13
                    Return "CitiBank"
                Case 14
                    Return "Bank Simpanan Nasional"
                Case 15
                    Return "Bank Muamalat"
                Case 16
                    Return "Alliance Bank"
                Case 17
                    Return "Agro Bank"
                Case 18
                    Return "Al Rajhi"
                Case 19
                    Return "MBSB Bank"
                Case 20
                    Return "Co-opBank Pertama"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    'Public Function UpdateProductBalance(pid As Integer, amount As Single) As Boolean
    '    Try
    '        Using db As New DataClassesDataContext
    '            Dim p = db.TblProducts.Single(Function(x) x.ProductID = pid)
    '            p.Balance += amount
    '        End Using
    '    Catch ex As Exception
    '        Log(ex)
    '        Return False
    '    End Try

    '    Return True
    'End Function

    Public Function GenerateCategoryString(slot As Boolean, live As Boolean, sport As Boolean, rng As Boolean, fish As Boolean, poker As Boolean, other As Boolean) As String
        Dim result As New List(Of String)
        If slot Then result.Add(Resources.Resource.SlotGame)
        If live Then result.Add(Resources.Resource.LiveCasino)
        If sport Then result.Add(Resources.Resource.Sportsbook)
        If rng Then result.Add(Resources.Resource.Rng)
        If fish Then result.Add(Resources.Resource.FishHunter)
        If poker Then result.Add(Resources.Resource.Poker)
        If other Then result.Add(Resources.Resource.Other)
        If slot And live And sport And rng And fish And poker And other Then result.Clear() : result.Add(Resources.Resource.AllProducts)
        Return String.Join(", ", result)
    End Function

    Public Function TransactionTypeToString(type As Integer) As String
        Select Case type
            Case 0
                Return "Credit"
            Case 1
                Return "Debit"
            Case Else
                Return "Promotion"
        End Select
    End Function

    Public Function TransactionChannelToString(chan As Integer) As String
        Select Case chan
            Case 0
                Return "Cash Deposit Machine"
            Case 1
                Return "ATM Transfer"
            Case 2
                Return "Internet Transfer"
            Case 3
                Return "Promotion"
            Case 4
                Return "Withdrawal"
            Case 5
                Return "Adjustment"
            Case Else
                Return "Other"
        End Select
    End Function

    Public Function PromotionTypeToString(type As Integer) As String
        Select Case type
            Case 0
                Return "Percentage"
            Case 1
                Return "Fixed Amount"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Public Function IntStatusToString(status As Integer) As String
        Select Case status
            Case 0
                Return "Disabled"
            Case Else
                Return "Enabled"
        End Select
    End Function

    Public Function BoolStatusToString(status As Boolean) As String
        Select Case status
            Case False
                Return "Disabled"
            Case Else
                Return "Enabled"
        End Select
    End Function

    Public Function UserRoleToString(role As Integer) As String
        Select Case role
            Case 1
                Return "Agent/Affiliate"
            Case 2
                Return "Administrator"
            Case 3
                Return "Full Administrator"
            Case Else
                Return "Customer Serivce"
        End Select
    End Function

    Public Function ContactTypeToString(type As Integer) As String
        Select Case type
            Case 0
                Return "Chat App"
            Case Else
                Return "Social Media"
        End Select
    End Function

    Public Function Img(path As String, alt As String, Optional link As Boolean = True) As String
        'Return "<img src=""" & path & """ alt=""" & alt & """ height=""30px"" />"
        If link Then
            Return String.Format("<a href={0}{1}{0} target={0}_blank{0}><img src={0}{1}{0} alt={0}{2}{0} height={0}30px{0} /></a>", """", path, alt)
        Else
            Return String.Format("<img src={0}{1}{0} alt={0}{2}{0} height={0}30px{0} />", """", path, alt)
        End If
    End Function

    Public Function IsImage(ext As String) As Boolean
        Dim imageExts As New List(Of String) From {"gif", "jpg", "jpeg", "jfif", "pjpeg", "pjp", "png", "svg", "webp", "bmp", "apng", "avif"}
        Return imageExts.Contains(ext)
    End Function

    Public Function CanUpload(ext As String) As Boolean
        Dim exts As New List(Of String) From {"gif", "jpg", "jpeg", "jfif", "pjpeg", "pjp", "png", "svg", "webp", "bmp", "apng", "avif", "pdf"}
        Return exts.Contains(ext)
    End Function

    Public Function LogTypeToString(log As Integer) As String
        Select Case log
            Case 0
                Return "Register"
            Case 1
                Return "Login"
            Case 2
                Return "Credit"
            Case 3
                Return "Debit"
            Case 4
                Return "Transfer"
            Case Else
                Return "Request Game Account"
        End Select
    End Function

    Public Enum eLogType
        Register
        Login
        Credit
        Debit
        Transfer
        RequestGameAcc
    End Enum

    Public Sub LogAction(username As String, ip As String, type As eLogType)
        Dim newLog As New TblLog
        With newLog
            .LogMember = username
            .LogIP = ip
            .LogType = CInt(type)
            .LogDate = Now
        End With

        Try
            Using db As New DataClassesDataContext
                db.TblLogs.InsertOnSubmit(newLog)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Public Function LogIP(log As IQueryable(Of TblLog), type As eLogType) As String
        Try
            Return log.Where(Function(x) x.LogType = type).OrderByDescending(Function(x) x.LogDate).First.LogIP.Trim
        Catch ex As Exception
            Return "127.0.0.1"
        End Try
    End Function

    Public Function LogDate(log As IQueryable(Of TblLog), type As eLogType) As Date
        Try
            Return log.Where(Function(x) x.LogType = type).OrderByDescending(Function(x) x.LogDate).First.LogDate
        Catch ex As Exception
            Return Date.ParseExact("1990-01-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        End Try
    End Function

    Public Enum eSum
        Credit
        Debit
        Promotion
    End Enum

    Public Function SumTransaction(mt As IQueryable(Of TblTransaction), sum As eSum) As Single
        Try
            Select Case sum
                Case eSum.Credit
                    Return mt.Sum(Function(x) x.Credit)
                Case eSum.Debit
                    Return mt.Sum(Function(x) x.Debit)
                Case eSum.Promotion
                    Return mt.Sum(Function(x) x.Promotion)
                Case Else
                    Return 0F
            End Select
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function CountTransaction(mt As IQueryable(Of TblTransaction), sum As eSum) As Integer
        Try
            Select Case sum
                Case eSum.Credit
                    Return mt.Count(Function(x) x.Credit)
                Case eSum.Debit
                    Return mt.Count(Function(x) x.Debit)
                Case eSum.Promotion
                    Return mt.Count(Function(x) x.Promotion)
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            Log(ex)
            Return 0
        End Try
    End Function

    Public Function TransactionDate(mt As IQueryable(Of TblTransaction), sum As eSum, first As Boolean) As Date
        Try
            Select Case sum
                Case eSum.Credit
                    If first Then
                        Return mt.Where(Function(x) x.TransType = 0).OrderBy(Function(x) x.TransactionDate).First.TransactionDate
                    Else
                        Return mt.Where(Function(x) x.TransType = 0).OrderByDescending(Function(x) x.TransactionDate).First.TransactionDate
                    End If
                Case eSum.Debit
                    If first Then
                        Return mt.Where(Function(x) x.TransType = 1).OrderBy(Function(x) x.TransactionDate).First.TransactionDate
                    Else
                        Return mt.Where(Function(x) x.TransType = 1).OrderByDescending(Function(x) x.TransactionDate).First.TransactionDate
                    End If
                Case eSum.Promotion
                    If first Then
                        Return mt.Where(Function(x) x.TransType = 2).OrderBy(Function(x) x.TransactionDate).First.TransactionDate
                    Else
                        Return mt.Where(Function(x) x.TransType = 2).OrderByDescending(Function(x) x.TransactionDate).First.TransactionDate
                    End If
                Case Else
                    Return Date.ParseExact("1990-01-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            End Select
        Catch ex As Exception
            Return Date.ParseExact("1990-01-01T00:00", "yyyy-MM-ddTHH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        End Try
    End Function

    Public Function IsClientOnMobileDevice(request As HttpRequest) As Boolean
        Dim userAgent As String = request.ServerVariables("HTTP_USER_AGENT")
        Dim OS As New Regex("(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device As New Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device_info As String = String.Empty
        If OS.IsMatch(userAgent) Then device_info = OS.Match(userAgent).Groups(0).Value
        If device.IsMatch(userAgent.Substring(0, 4)) Then device_info += device.Match(userAgent).Groups(0).Value
        Return Not String.IsNullOrEmpty(device_info)
    End Function

    Public Function TextToImage(text As String) As String
        Dim bitmap As New Bitmap(1, 1)
        Dim font As New Font("Comic Sans MS, Verdana, Courier", 40, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim graphics As Graphics = Graphics.FromImage(bitmap)
        Dim width As Integer = CInt(graphics.MeasureString(text, font).Width)
        Dim height As Integer = CInt(graphics.MeasureString(text, font).Height)
        bitmap = New Bitmap(bitmap, New Size(width, height))
        graphics = Graphics.FromImage(bitmap)
        graphics.Clear(Color.White)
        graphics.SmoothingMode = SmoothingMode.AntiAlias
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias
        graphics.DrawString(text, font, New SolidBrush(Color.FromArgb(255, 0, 0)), 0, 0)
        graphics.FillRectangle(New HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(255, 0, 0, 0), Color.Transparent), graphics.ClipBounds)
        graphics.FillRectangle(New HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(255, 0, 0, 0), Color.Transparent), graphics.ClipBounds)
        graphics.Flush()
        graphics.Dispose()

        Dim ms As New MemoryStream()
        bitmap.Save(ms, Imaging.ImageFormat.Jpeg)
        Return Convert.ToBase64String(ms.ToArray)
        ms.Dispose()
    End Function

    Public Function GetProductUserName(productID As Integer, username As String) As String
        Try
            Using db As New DataClassesDataContext
                Dim result = db.TblGameAccounts.Single(Function(x) x.MemberUserName = username And x.ProductID = productID)
                Return result.UserName.Trim
            End Using
        Catch ex As Exception
            Log(ex)
            Return "ERROR"
        End Try
    End Function

    Public Function GetProductName(productID As Integer) As String
        Try
            Using db As New DataClassesDataContext
                Dim result = db.TblProducts.Single(Function(x) x.ProductID = productID)
                Return result.ProductName.Trim
            End Using
        Catch ex As Exception
            Log(ex)
            Return "ERROR"
        End Try
    End Function

    Public Function CalcPromotion(promoID As Integer, amount As Single) As Single
        Try
            Using db As New DataClassesDataContext
                Dim promo = db.TblPromotions.Single(Function(x) x.PromoID = promoID)
                Dim percent = promo.PromoPercent
                Dim type = promo.PromoType
                If type = 0 Then
                    'percent
                    Return (amount * percent)
                Else
                    'fixed
                    Return amount + percent
                End If
            End Using
        Catch ex As Exception
            Log(ex)
            Return 0F
        End Try
    End Function

    Public Function RandomText(r As Random, Optional min As Integer = 15, Optional max As Integer = 33) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(min, max)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Public Function Strong(str As String) As String
        Return "<b>" & str & "</b>"
    End Function

    Public Function Camoflauge(userid As String) As String
        Try
            Dim cutDown As String = userid.Substring(0, 5)
            Return cutDown & "xxxxxx"
        Catch ex As Exception
            Return userid & "xxxxxx"
        End Try
    End Function

    <Extension>
    Public Function HowLong(start As Date, Optional [end] As Date = Nothing) As String
        If [end] = Nothing Then [end] = Now

        Dim result As String = String.Empty
        Dim timeSpan = [end].Subtract(start)

        If timeSpan <= TimeSpan.FromSeconds(20) Then
            result = Resources.Resource.JustNow
        ElseIf timeSpan <= TimeSpan.FromSeconds(60) Then
            result = String.Format("{0}{1}", timeSpan.Seconds, Resources.Resource.SecsAgo)
        ElseIf timeSpan <= TimeSpan.FromMinutes(60) Then
            result = If(timeSpan.Minutes > 1, String.Format("{0}{1}", timeSpan.Minutes, Resources.Resource.MinsAgo), Resources.Resource.AMinAgo)
        ElseIf timeSpan <= TimeSpan.FromHours(24) Then
            result = If(timeSpan.Hours > 1, String.Format("{0}{1}", timeSpan.Hours, Resources.Resource.HoursAgo), Resources.Resource.AnHourAgo)
        ElseIf timeSpan <= TimeSpan.FromDays(30) Then
            result = If(timeSpan.Days > 1, String.Format("{0}{1}", timeSpan.Days, Resources.Resource.DaysAgo), Resources.Resource.Yesterday)
        ElseIf timeSpan <= TimeSpan.FromDays(365) Then
            result = If(timeSpan.Days > 30, String.Format("{0}{1}", timeSpan.Days / 30, Resources.Resource.MonsAgo), Resources.Resource.AMonAgo)
        Else
            result = If(timeSpan.Days > 365, String.Format("{0}{1}", timeSpan.Days / 365, Resources.Resource.YearsAgo), Resources.Resource.AYearAgo)
        End If

        Return result
    End Function

    Public Function GetContactPreset(value As Integer) As Tuple(Of Integer, String)
        Select Case value
            Case 0 'Telegram
                Return New Tuple(Of Integer, String)(0, "fab fa-telegram-plane")
            Case 1 'WhatsApp
                Return New Tuple(Of Integer, String)(0, "fab fa-whatsapp")
            Case 2 'phone
                Return New Tuple(Of Integer, String)(0, "fas fa-phone")
            Case 3 'QQ
                Return New Tuple(Of Integer, String)(0, "fab fa-qq")
            Case 4 'WeChat
                Return New Tuple(Of Integer, String)(0, "fab fa-weixin")
            Case 5 'Line
                Return New Tuple(Of Integer, String)(0, "fab fa-line")
            Case 6 'Skype
                Return New Tuple(Of Integer, String)(0, "fab fa-skype")
            Case 7 'Discord
                Return New Tuple(Of Integer, String)(0, "fab fa-discord")
            Case 8 'Facebook
                Return New Tuple(Of Integer, String)(1, "fab fa-facebook-f")
            Case 9 'Twitter
                Return New Tuple(Of Integer, String)(1, "fab fa-twitter")
            Case 10 'Youtube
                Return New Tuple(Of Integer, String)(1, "fab fa-youtube")
            Case 11 'Tiktok
                Return New Tuple(Of Integer, String)(1, "fab fa-tiktok")
            Case 12 'Instagram
                Return New Tuple(Of Integer, String)(1, "fab fa-instagram")
            Case 13 'Email
                Return New Tuple(Of Integer, String)(1, "fas fa-envelope")
            Case 14 'LiveChat
                Return New Tuple(Of Integer, String)(1, "far fa-comment")
            Case Else 'Custom
                Return New Tuple(Of Integer, String)(1, "fas fa-wifi")
        End Select
    End Function

    Public Function GetContactPresetFromCss(fafa As String) As Integer
        Select Case fafa
            Case "fab fa-telegram-plane"
                Return 0
            Case "fab fa-whatsapp"
                Return 1
            Case "fas fa-phone"
                Return 2
            Case "fab fa-qq"
                Return 3
            Case "fab fa-weixin"
                Return 4
            Case "fab fa-line"
                Return 5
            Case "fab fa-skype"
                Return 6
            Case "fab fa-discord"
                Return 7
            Case "fab fa-facebook-f"
                Return 8
            Case "fab fa-twitter"
                Return 9
            Case "fab fa-youtube"
                Return 10
            Case "fab fa-tiktok"
                Return 11
            Case "fab fa-instagram"
                Return 12
            Case "fas fa-envelope"
                Return 13
            Case "far fa-comment"
                Return 14
            Case Else
                Return 15
        End Select
    End Function

    <Extension>
    Public Function ToBase64(text As String) As String
        If text = Nothing Then Return text

        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text)
        Return System.Convert.ToBase64String(plainTextBytes)
    End Function

    <Extension>
    Public Function Base64ToString(base64 As String) As String
        If base64 = Nothing Then Return base64

        Try
            Dim base64Bytes = System.Convert.FromBase64String(base64)
            Return System.Text.Encoding.UTF8.GetString(base64Bytes)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPromotionName(id As Integer, defaultString As String) As String
        Try
            Using db As New DataClassesDataContext
                Return db.TblPromotions.Single(Function(x) x.PromoID = id).PromoName
            End Using
        Catch ex As Exception
            Return defaultString
        End Try
    End Function

    Public Function GetPromotionLocalizedName(name As String, lang As String) As String
        Try
            Using db As New DataClassesDataContext
                Select Case lang.Trim
                    Case "zh-CN"
                        Return db.TblPromotions.Single(Function(x) x.PromoName = name).ChineseName
                    Case "my-MY"
                        Return db.TblPromotions.Single(Function(x) x.PromoName = name).MalayName
                    Case Else
                        Return db.TblPromotions.Single(Function(x) x.PromoName = name).EnglishName
                End Select
            End Using
        Catch ex As Exception
            Return name
        End Try
    End Function

End Module
