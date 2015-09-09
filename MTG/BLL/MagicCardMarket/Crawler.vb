''' <summary>
''' This class reads MKM and store everything in MongoDB.
''' The goal: given a list of cards download their prices and who is selling them.
''' The algorithm:
''' Scarica i prodotti e da essi gli articoli. 
''' Negli articoli abbiamo: prezzo, condizione, lingua, nazione e venditore.
''' Manca: prezzo medio ed andamento (carta in salita o carta in discesa? Quelle in discesa non le vogliamo comprare)
''' 
''' The components
''' /products/:name/:idGame/:idLanguage/:isExact[/:start]
''' Dall'URL qua sopra si scaricano i product. Product.priceGuide.AVG restituisce il prezzo medio.
''' 
''' /articles/:idProduct[/:start]
''' si scaricano gli articoli dando un product id. Article.seller e' la lista di utenti che vendono l'articolo. 
''' </summary>
''' <remarks></remarks>
Public Class Crawler

    Dim metaproduct As MKMMetaproduct
    ''' <summary>
    ''' Questa routine dovrebbe girare una sola volta e si passa tutti i metaproduct e se li salva.
    ''' </summary>
    ''' <remarks>TESTED</remarks>
    Public Sub crawlMetaproducts()

        Dim request_handler As New MKMRequestHandler
        Dim tmp As Dictionary(Of String, MKMMetaproduct)
        For i = 1 To 100000 Step 1
            tmp = request_handler.downloadMKMMetaproduct(i.ToString)
            If tmp Is Nothing Then Continue For

            metaproduct = tmp.Values(0)
            Exit For
            'tmp.storeToDB()
        Next

        crawlArticles()
    End Sub

    ''' <summary>
    ''' quando il sistema scarica i metaprodotti si porta appresso anche i prodotti.
    ''' Sui prodotti iniziamo la ricerca degli articoli in vendita. Gli articoli si portano appresso gli utenti.
    ''' </summary>
    ''' <remarks>TESTED</remarks>
    Public Sub crawlArticles()

        Dim request_handler As New MKMRequestHandler
        
        Dim tmp As Dictionary(Of String, MKMArticle())
        tmp = request_handler.downloadMKMArticle(metaproduct.products.idProduct(0))
        

    End Sub


End Class
