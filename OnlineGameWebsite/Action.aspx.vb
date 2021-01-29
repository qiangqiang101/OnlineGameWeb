
Partial Class Action
    Inherits System.Web.UI.Page

    Public mode As String = "cancel"
    Public redirect As String = "history"
    Public tid As String = 0

    Private Sub Action_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        redirect = Request.QueryString("redirect")
        tid = Request.QueryString("id")

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
                            Response.Redirect(GetRedirect)
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Transaction not found!", "error")
                        End Try
                    Case "reason"
                        Try
                            Using db As New DataClassesDataContext
                                Dim t = db.TblTransactions.Single(Function(x) x.TransactionID = CInt(tid) And x.UserName = Session("username").ToString.Trim)
                                swalRedirect(GetRedirect, "Reject Reason", t.Reason.Trim, "info")
                            End Using
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Transaction not found!", "error")
                        End Try
                    Case "cancel2"
                        Try
                            Using db As New DataClassesDataContext
                                Dim t = db.TblTransfers.Single(Function(x) x.TransferID = CInt(tid) And x.UserName = Session("username").ToString.Trim)
                                If t.Status = 0 Then
                                    t.Status = 4
                                    db.SubmitChanges()
                                End If
                            End Using
                            Response.Redirect(GetRedirect)
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Transaction not found!", "error")
                        End Try
                    Case "reason2"
                        Try
                            Using db As New DataClassesDataContext
                                Dim t = db.TblTransfers.Single(Function(x) x.TransferID = CInt(tid) And x.UserName = Session("username").ToString.Trim)
                                swalRedirect(GetRedirect, "Reject Reason", t.Reason.Trim, "info")
                            End Using
                        Catch ex As Exception
                            Log(ex)
                            swalRedirect(GetRedirect, "Oops!", "Transaction not found!", "error")
                        End Try
                End Select
            End If
        End If
    End Sub

    Private Function GetRedirect() As String
        Select Case redirect
            Case "history"
                Return "TransactionHistory.aspx"
            Case Else
                Return "Default.aspx"
        End Select
    End Function

End Class
