
Partial Class Action
    Inherits BasePage

    Public mode As String = "cancel"
    Public redirect As String = "history"
    Public tid As String = 0
    Public mid As String = 0

    Private Sub Action_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        redirect = Request.QueryString("redirect")
        tid = Request.QueryString("id")
        mid = Request.QueryString("mid")

        Dim role As String = HttpContext.Current.Session("role")
        If role <> "user" Then
            LoginMsgBox
        Else
            If Not IsPostBack Then
                Select Case mode
                    Case "cancel"
                        Try
                            Using db As New DataClassesDataContext
                                Dim t = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid) And x.UserName = Session("username").ToString.Trim)
                                If t.Status = 0 Then
                                    t.Status = 4
                                    db.SubmitChanges()
                                End If
                            End Using
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Transaction not found!", "error")
                        End Try
                        Response.Redirect(GetRedirect)
                    Case "cancel2"
                        Try
                            Using db As New DataClassesDataContext
                                Dim t = db.TblTransfers.Single(Function(x) x.TransferID = CInt(tid) And x.UserName = Session("username").ToString.Trim)
                                If t.Status = 0 Then
                                    t.Status = 4
                                    db.SubmitChanges()
                                End If
                            End Using
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Transaction not found!", "error")
                        End Try
                        Response.Redirect(GetRedirect)
                    Case "account"
                        Dim gotError As Boolean = True
                        Try
                            Using db As New DataClassesDataContext
                                Dim ga = db.TblGameAccounts.Where(Function(x) x.ProductID = CInt(tid) AndAlso x.MemberUserName Is Nothing)
                                Dim m = db.TblMembers.Single(Function(x) x.UserID = CInt(mid))
                                If Not ga.Count = 0 Then
                                    ga.First.MemberUserName = m.UserName.Trim
                                    db.SubmitChanges()
                                    gotError = False
                                End If
                            End Using

                            LogAction(Session("username").ToString.Trim, Request.UserHostAddress, eLogType.RequestGameAcc)
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Something went wrong! Please contact customer service.", "error")
                        End Try

                        Response.Redirect(GetRedirect() & If(gotError, "?swal='Oops!', 'Something went wrong! Please contact customer service.', 'error'", ""))
                End Select
            End If
        End If
    End Sub

    Private Function GetRedirect() As String
        Select Case redirect
            Case "history"
                Return "TransactionHistory.aspx"
            Case "account"
                Return "MyAccounts.aspx"
            Case Else
                Return "Default.aspx"
        End Select
    End Function

End Class
