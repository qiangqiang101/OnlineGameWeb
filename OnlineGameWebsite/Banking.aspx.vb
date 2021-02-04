
Partial Class Banking
    Inherits BasePage

    Private Sub Banking_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            Using db As New DataClassesDataContext
                Dim banks = db.TblBanks.Where(Function(x) x.Status = 1 And x.AllowCredit = True)
                For Each b In banks
                    bankList.Controls.Add(LoadBanks(b.BankLogo.Trim, b.BankName.Trim, b.BankWeb.Trim, b.MinCredit.ToString("N"), b.MinDebit.ToString("N"), b.MaxCredit.ToString("N"), b.MaxDebit.ToString("N")))
                Next
            End Using
        Else
            Using db As New DataClassesDataContext
                Dim banks = db.TblBanks.Where(Function(x) x.Status = 1 And x.AllowCredit = True)
                For Each b In banks
                    bankList.Controls.Add(LoadBanksWithAcc(b.BankLogo.Trim, b.BankName.Trim, b.BankWeb.Trim, b.MinCredit.ToString("N"), b.MinDebit.ToString("N"), b.MaxCredit.ToString("N"), b.MaxDebit.ToString("N"), b.AccountName.Trim, b.AccountNo.Trim))
                Next
            End Using
        End If
    End Sub

    Private Function LoadBanks(image As String, bankName As String, website As String, minDep As String, minWth As String, maxDep As String, maxWth As String) As HtmlGenericControl
        Dim logo = New HtmlGenericControl("img")
        With logo
            .Attributes("src") = image
            .Attributes("style") = "width: 100%; height: auto;"
            .Attributes("alt") = bankName
        End With

        Dim logoLi = New HtmlGenericControl("li")
        With logoLi
            .Controls.Add(logo)
        End With

        Dim price = New HtmlGenericControl("ul")
        With price
            .Attributes("class") = "price"
            .Controls.Add(logoLi)
        End With

        Dim title = New HtmlGenericControl("h3") With {.InnerText = bankName}

        Dim feature = New HtmlGenericControl("ul")
        With feature
            .Attributes("class") = "plan-features"
            .Controls.Add(GenerateLi(Resources.Resource.PaymentMethods))
            .Controls.Add(GenerateLi(Resources.Resource.DepositMinMaxP1 & minDep & Resources.Resource.DepositMinMaxP2 & maxDep & Resources.Resource.DepositMinMaxP3))
            .Controls.Add(GenerateLi(Resources.Resource.DepositMinMaxP4 & minWth & Resources.Resource.DepositMinMaxP2 & maxWth & Resources.Resource.DepositMinMaxP3))
            .Controls.Add(GenerateLi(Resources.Resource.DepositTime))
            .Controls.Add(GenerateLi(Resources.Resource.WithdrawalTime))
        End With

        Dim button = New HtmlGenericControl("a")
        With button
            .Attributes("class") = "btn btn-slider-black"
            .Attributes("href") = website
            .Attributes("target") = "_blank"
            .InnerText = Resources.Resource.DepositNowU
        End With

        Dim pricing = New HtmlGenericControl("div")
        With pricing
            .Attributes("class") = "pricing"
            .Controls.Add(price)
            .Controls.Add(title)
            .Controls.Add(feature)
            .Controls.Add(button)
        End With

        Dim col_md_3 = New HtmlGenericControl("div")
        With col_md_3
            .Attributes("class") = "col-sm-4"
            .Controls.Add(pricing)
        End With

        Return col_md_3
    End Function

    Private Function LoadBanksWithAcc(image As String, bankName As String, website As String, minDep As String, minWth As String, maxDep As String, maxWth As String, accName As String, accNo As String) As HtmlGenericControl
        Dim logo = New HtmlGenericControl("img")
        With logo
            .Attributes("src") = image
            .Attributes("style") = "width: 100%; height: auto;"
            .Attributes("alt") = bankName
        End With

        Dim logoLi = New HtmlGenericControl("li")
        With logoLi
            .Controls.Add(logo)
        End With

        Dim price = New HtmlGenericControl("ul")
        With price
            .Attributes("class") = "price"
            .Controls.Add(logoLi)
        End With

        Dim title = New HtmlGenericControl("h3") With {.InnerText = bankName}
        Dim accNameH4 = New HtmlGenericControl("h4") With {.InnerText = accName}
        Dim accNoH4 = New HtmlGenericControl("h4") With {.InnerText = accNo}

        Dim feature = New HtmlGenericControl("ul")
        With feature
            .Attributes("class") = "plan-features"
            .Controls.Add(GenerateLi(Resources.Resource.PaymentMethods))
            .Controls.Add(GenerateLi(Resources.Resource.DepositMinMaxP1 & minDep & Resources.Resource.DepositMinMaxP2 & maxDep & Resources.Resource.DepositMinMaxP3))
            .Controls.Add(GenerateLi(Resources.Resource.DepositMinMaxP4 & minWth & Resources.Resource.DepositMinMaxP2 & maxWth & Resources.Resource.DepositMinMaxP3))
            .Controls.Add(GenerateLi(Resources.Resource.DepositTime))
            .Controls.Add(GenerateLi(Resources.Resource.WithdrawalTime))
        End With

        Dim button = New HtmlGenericControl("a")
        With button
            .Attributes("class") = "btn btn-slider-black"
            .Attributes("href") = website
            .Attributes("target") = "_blank"
            .InnerText = "DEPOSIT NOW"
        End With

        Dim pricing = New HtmlGenericControl("div")
        With pricing
            .Attributes("class") = "pricing"
            .Controls.Add(price)
            .Controls.Add(title)
            .Controls.Add(accNameH4)
            .Controls.Add(accNoH4)
            .Controls.Add(feature)
            .Controls.Add(button)
        End With

        Dim col_md_3 = New HtmlGenericControl("div")
        With col_md_3
            .Attributes("class") = "col-sm-4"
            .Controls.Add(pricing)
        End With

        Return col_md_3
    End Function

    Private Function GenerateLi(inHtml As String) As HtmlGenericControl
        Dim li = New HtmlGenericControl("li")
        With li
            .InnerHtml = inHtml
        End With

        Return li
    End Function

End Class
