Public Class StockChecker

    Public Sub getArticlesInStock(ByVal output As RichTextBox)

        ' https://www.mkmapi.eu/ws/v1.1/stock

        Dim stock As MKMStock = New MKMRequestHandler().downloadStock
        Dim under_evaluated As New System.Text.StringBuilder()
        Dim over_evaluated As New System.Text.StringBuilder()
        Dim neverSold As New System.Text.StringBuilder()
        For Each article As MKMArticle In stock.article

            Dim tmp As String = chekUnderevaluated(article)
            If Not String.IsNullOrEmpty(tmp) Then
                ' chekc for never sold cards
                If tmp.EndsWith(":0]") Then
                    neverSold.AppendLine(tmp)
                Else
                    under_evaluated.AppendLine(tmp)
                End If
                Continue For
            End If

            tmp = chekOverevaluated(article)
            If Not String.IsNullOrEmpty(tmp) Then

                ' chekc for never sold cards
                If tmp.EndsWith(":0]") Then
                    neverSold.AppendLine(tmp)
                Else
                    over_evaluated.AppendLine(tmp)
                End If

            End If

        Next

        output.Text = "never sold" + vbNewLine + neverSold.ToString
        output.Text = output.Text + vbNewLine + vbNewLine
        output.Text = output.Text + "Under Evaluated" + vbNewLine + under_evaluated.ToString
        output.Text = output.Text + vbNewLine + vbNewLine
        output.Text = output.Text + "Over Evaluated" + vbNewLine + over_evaluated.ToString

    End Sub

    ''' <summary>
    ''' This checks if I'm selling cards with low price
    ''' </summary>
    ''' <param name="article"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function chekUnderevaluated(ByVal article As MKMArticle) As String

        Dim idPRoduct As String = article.idProduct
        Dim requestHandler As New MKMRequestHandler
        Dim mkm_products As MKMProducts = requestHandler.downloadProduct(idPRoduct)
        Dim mkm_product As MKMProduct = mkm_products.product

        Dim stockPrice As Double = Double.Parse(article.price)
        Dim selling_price As Double = Double.Parse(mkm_product.priceGuide.SELL) ' Average price of articles ever sold of this product
        If selling_price = 0 Then Return idPRoduct + "| https://www.magiccardmarket.eu" + mkm_product.website + "| stock price:" + stockPrice.ToString + " | selling price:" + selling_price.ToString

        If stockPrice <= 0.2 Then Return ""

        If selling_price - stockPrice >= 0.2D Then
            ' candidate but we don't want to write cards with stock price 0.5 and selling price 0.49. We add 10%
            stockPrice = stockPrice + stockPrice / 10
            If selling_price > stockPrice Then Return idPRoduct + "| https://www.magiccardmarket.eu" + mkm_product.website + "| stock price:" + stockPrice.ToString + " | selling price:" + selling_price.ToString
        End If

        Return ""

    End Function


    ''' <summary>
    ''' This checks if I'm selling cards with high price
    ''' </summary>
    ''' <param name="article"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function chekOverevaluated(ByVal article As MKMArticle) As String

        Dim idPRoduct As String = article.idProduct
        Dim requestHandler As New MKMRequestHandler
        Dim mkm_products As MKMProducts = requestHandler.downloadProduct(idPRoduct)
        Dim mkm_product As MKMProduct = mkm_products.product

        Dim stockPrice As Double = Double.Parse(article.price)
        Dim selling_price As Double = Double.Parse(mkm_product.priceGuide.SELL) ' Average price of articles ever sold of this product
        If selling_price = 0.0 Then Return idPRoduct + "| https://www.magiccardmarket.eu" + mkm_product.website + "| stock price:" + stockPrice.ToString + " | selling price:" + selling_price.ToString

        If stockPrice <= 0.2 Then Return ""

        If stockPrice - selling_price >= 0.2D Then
            ' candidate but we don't want to write cards with stock price 0.5 and selling price 0.49. We add 10%
            selling_price = selling_price + selling_price / 10
            If selling_price < stockPrice Then Return idPRoduct + "| https://www.magiccardmarket.eu" + mkm_product.website + "| stock price" + stockPrice.ToString + " | selling price:" + selling_price.ToString
        End If

        Return ""

    End Function
End Class
