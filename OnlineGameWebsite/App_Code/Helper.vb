Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
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

    <Extension>
    Public Sub LoginMsgBox(page As Page)
        page.Response.Write("<script>alert('Please log in to continue.');</script>")
        page.Response.Write("<script>window.location.href='Default.aspx';</script>")
    End Sub

    <Extension>
    Public Sub JsMsgBoxRedirect(page As Page, text As String, redirect As String)
        page.Response.Write("<script>alert('" & text & "');</script>")
        page.Response.Write("<script>window.location.href='" & redirect & "';</script>")
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

    Public Function DeleteButton(action As String, Optional button As String = "fa-times") As String
        Return String.Format("<a href={0}{1}{0}><i class={0}fa {2}{0}></i></a>", """", action, button)
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

    Public Function TransactionChannelToString(chan As Integer) As String
        Select Case chan
            Case 0
                Return "Cash Deposit Machine"
            Case 1
                Return "ATM Transfer"
            Case 2
                Return "Internet Transfer"
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
        Dim font As New Font("Arial", 40, FontStyle.Strikeout, GraphicsUnit.Pixel)
        Dim graphics As Graphics = Graphics.FromImage(bitmap)
        Dim width As Integer = CInt(graphics.MeasureString(text, font).Width)
        Dim height As Integer = CInt(graphics.MeasureString(text, font).Height)
        bitmap = New Bitmap(bitmap, New Size(width, height))
        graphics = Graphics.FromImage(bitmap)
        graphics.Clear(Color.White)
        graphics.SmoothingMode = SmoothingMode.AntiAlias
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias
        graphics.DrawString(text, font, New SolidBrush(Color.FromArgb(255, 0, 0)), 0, 0)
        graphics.Flush()
        graphics.Dispose()

        Dim ms As New MemoryStream()
        bitmap.Save(ms, Imaging.ImageFormat.Jpeg)
        Return Convert.ToBase64String(ms.ToArray)
        ms.Dispose()
    End Function

    Public Function GetProductUserName(productID As Integer, username As String) As String
        Try
            Dim result = db.TblGameAccounts.Single(Function(x) x.MemberUserName = username And x.ProductID = productID)
            Return result.UserName
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function

    Public Function GetProductName(productID As Integer) As String
        Try
            Dim result = db.TblGameAccounts.Single(Function(x) x.ProductID = productID)
            Return result.UserName
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function

    Public Function CalcPromotion(promoID As Integer, amount As Single) As Single
        Try
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
        Catch ex As Exception
            Return 0F
        End Try
    End Function

End Module
