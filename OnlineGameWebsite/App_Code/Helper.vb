Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic

Public Module Helper

    Public db As New DataClassesDataContext

    Public dateFormat As String = "yyyy-MM-dd HH:mm:ss"
    Public upload As String = "~/Upload/" & Now.Year & "/" & Now.Month & "/" & Now.Day & "/"
    Public promoTnc As String = "~/Promo/" & Now.Year & "/" & Now.Month & "/" & Now.Day & "/"

    <Extension>
    Public Sub JsMsgBox(page As Page, text As String)
        page.Response.Write("<script>alert('" & text & "');</script>")
    End Sub

    Public Function IsMemberExists(username As String) As Boolean
        Dim check = (From m In db.TblMembers Where m.UserName = username).ToList
        Dim members = (From m In db.TblMembers)
        If members.Contains(check.FirstOrDefault) Then Return True
        Return False
    End Function

    Public Function IsUserExists(username As String) As Boolean
        Dim check = (From u In db.TblUsers Where u.UserName = username).ToList
        Dim users = (From m In db.TblUsers)
        If users.Contains(check.FirstOrDefault) Then Return True
        Return False
    End Function

    Public Function IsEmailExists(email As String, Optional checkMember As Boolean = True) As Boolean
        If checkMember Then
            Dim check = (From m In db.TblMembers Where m.Email = email).ToList
            Dim members = (From m In db.TblMembers)
            If members.Contains(check.FirstOrDefault) Then Return True
            Return False
        Else
            Dim check = (From u In db.TblUsers Where u.Email = email).ToList
            Dim users = (From m In db.TblUsers)
            If users.Contains(check.FirstOrDefault) Then Return True
            Return False
        End If
    End Function

    Public Function IsEmailValid(email As String) As Boolean
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As Match = Regex.Match(email, pattern, RegexOptions.IgnoreCase)
        Return match.Success
    End Function

    Public Function IsMemberLoginSuccess(username As String, password As String, page As Page) As Boolean
        If IsEmailValid(username) Then
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
        Else
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
        End If
        Return False
    End Function

    Public Function IsAdminLoginSuccess(username As String, password As String, page As Page) As Boolean
        If IsEmailValid(username) Then
            Try
                Dim user = db.TblUsers.Single(Function(x) x.Email = username AndAlso x.Password = password)
                If user.Status Then
                    page.Session("userid") = user.UserID
                    page.Session("username") = user.UserName
                    page.Session("fullname") = user.FullName
                    page.Session("email") = user.Email
                    page.Session("role") = UserRoleToString(user.UserRole)

                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        Else
            Try
                Dim user = db.TblUsers.Single(Function(x) x.UserName = username AndAlso x.Password = password)
                If user.Status Then
                    page.Session("userid") = user.UserID
                    page.Session("username") = user.UserName
                    page.Session("fullname") = user.FullName
                    page.Session("email") = user.Email
                    page.Session("role") = UserRoleToString(user.UserRole)

                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End If
        Return False
    End Function

    Public Sub UpdateUserLastLogin(username As String, ip As String)
        Dim user = db.TblUsers.Single(Function(x) x.UserName = username)
        With user
            .LastLoginDate = Now
            .LastLoginIP = ip
        End With
        db.SubmitChanges()
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

    <Extension>
    Public Sub AddTableItem(table As Table, ParamArray items As String())
        Dim row As New TableRow()
        For Each item In items
            row.Cells.Add(New TableCell() With {.Text = item})
        Next
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
            Case Else
                Return "Error"
        End Select
    End Function

    Public Function GenerateCategoryString(slot As Boolean, live As Boolean, sport As Boolean, rng As Boolean, fish As Boolean, poker As Boolean, other As Boolean) As String
        Dim result As New List(Of String)
        If slot Then result.Add("Slot Games")
        If live Then result.Add("Live Casino")
        If sport Then result.Add("Sportsbook")
        If rng Then result.Add("RNG")
        If fish Then result.Add("Fish Hunter")
        If poker Then result.Add("Poker")
        If other Then result.Add("Other")
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

    Public Function ProductName(id As Integer) As String
        Try
            Return db.TblProducts.Single(Function(x) x.ProductID = id).ProductName
        Catch ex As Exception
            Return id
        End Try
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
            db.TblLogs.InsertOnSubmit(newLog)
            db.SubmitChanges()
        Catch ex As Exception

        End Try
    End Sub

    Public Function LastLoginIP(username As String) As String
        Try
            Dim log = db.TblLogs.Where(Function(x) x.LogMember = username And x.LogType = 1).OrderByDescending(Function(x) x.LogDate).FirstOrDefault
            Return log.LogIP.Trim
        Catch ex As Exception
            Return "127.0.0.1"
        End Try
    End Function

End Module
