Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic

Public Module Helper

    Public db As New DataClassesDataContext

    Public dateFormat As String = "yyyy-MM-dd HH:mm:ss"
    Public upload As String = "~/Upload/" & Now.Year & "/" & Now.Month & "/" & Now.Day & "/"
    Public promoTnc As String = "~/Promo/" & Now.Year & "/" & Now.Month & "/" & Now.Day & "/"
    Public settings As SettingsData = New SettingsData(HttpRuntime.AppDomainAppPath & "\settings.xml").Instance

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

    Public Function IsEmailExists(email As String) As Boolean
        Dim check = (From m In db.TblMembers Where m.Email = email).ToList
        Dim members = (From m In db.TblMembers)
        If members.Contains(check.FirstOrDefault) Then Return True
        Return False
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
            Dim member = (From m In db.TblMembers Where m.Email = username And m.Password = password).FirstOrDefault
            If member IsNot Nothing Then
                If member.Enabled AndAlso member.VipLevel = 32 Then
                    page.Session("userid") = member.UserID
                    page.Session("username") = member.UserName
                    page.Session("fullname") = member.FullName
                    page.Session("email") = member.Email
                    page.Session("role") = "admin"

                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Dim member = (From m In db.TblMembers Where m.UserName = username And m.Password = password).FirstOrDefault
            If member IsNot Nothing Then
                If member.Enabled AndAlso member.VipLevel = 32 Then
                    page.Session("userid") = member.UserID
                    page.Session("username") = member.UserName
                    page.Session("fullname") = member.FullName
                    page.Session("email") = member.Email
                    page.Session("role") = "admin"

                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return False
    End Function

    Public Function RB(action As String, css As String, Optional button As String = "btn-primary") As String
        Return RoundButton(action, css, button)
    End Function

    Public Function RoundButton(action As String, css As String, Optional button As String = "btn-primary") As String
        Return "<a href=""" & action & """ class=""btn " & button & " btn-circle btn-sm""><i class=""" & css & """></i></a>"
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

    Public Function ProductCategoryToString(category As Integer) As String
        Select Case category
            Case 1
                Return "Slot Games"
            Case 2
                Return "Live Casino"
            Case 3
                Return "Sportsbook"
            Case 4
                Return "Other"
            Case 5
                Return "Slot Games & Live Casino"
            Case 6
                Return "Slot Games & Sportsbook"
            Case 7
                Return "Slot Games & Other"
            Case 8
                Return "Live Casino & Sportsbook"
            Case 9
                Return "Live Casino & Other"
            Case 10
                Return "Sportsbook & Other"
            Case 11
                Return "Slot Games, Live Casino & Sportsbook"
            Case 12
                Return "Slot Games, Live Casino & Other"
            Case 13
                Return "Slot Games, Sportsbook & Other"
            Case 14
                Return "Live Casino, Sportsbook & Other"
            Case 15
                Return "All"
            Case Else
                Return "None"
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

    Public Function PromotionStatusToString(status As Integer) As String
        Select Case status
            Case 0
                Return "Disabled"
            Case 1
                Return "Enabled"
            Case Else
                Return "Hidden"
        End Select
    End Function

    Public Function Img(path As String, alt As String) As String
        Return "<img src=""" & path & """ alt=""" & alt & """ height=""30px"" />"
    End Function

    Public Function IsImage(ext As String) As Boolean
        Dim imageExts As New List(Of String) From {"gif", "jpg", "jpeg", "jfif", "pjpeg", "pjp", "png", "svg", "webp", "bmp", "apng", "avif"}
        Return imageExts.Contains(ext)
    End Function

End Module
