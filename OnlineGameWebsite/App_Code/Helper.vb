Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic

Public Module Helper

    Public db As New DataClassesDataContext

    Public dateFormat As String = "yyyy-MM-dd HH:mm:ss"

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

                    JsMsgBox(page, "yes")
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

                    JsMsgBox(page, "yes")
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return False
    End Function

End Module
