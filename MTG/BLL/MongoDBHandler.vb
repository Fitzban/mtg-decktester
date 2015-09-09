Public Class MongoDBHandler

    Public Function readProducts() As ICollection(Of MKMProduct)
        Dim ret As New List(Of MKMProduct)

        ' to be implemented

        Return ret
    End Function

    ''' <summary>
    ''' Qui salviamo un centinaio di articoli di un prodotto. 
    ''' Il crawler si fa un giro sui meta prodotti, per ognuno di essi si scarica i primi 100 articoli. 
    ''' L'articolo contiene il seller. A me servira' sapere gli articoli che vende un seller.
    ''' Non rigiro la collezione prima di salvarla ma vedo di usare le potenzialita' di MongoDB per cui quando salvo un articolo
    ''' salvo anche il seller nella sua collezione. 
    ''' In questo modo il buyer carichera' i seller e per ognuno di essi cerchera' i suoi articoli in vendita. 
    ''' </summary>
    ''' <param name="pdictionary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function storeArticles(ByVal pdictionary As Dictionary(Of String, MKMArticle())) As Boolean

        Dim tmp_seller As MKMSeller = Nothing
        For Each article As MKMArticle In pdictionary.Values(0)
            ' prendi il seller
            tmp_seller = article.seller
            storeSeller(tmp_seller)
        Next
        
        ' ed ora salvo l'articolo. Se non c'e' lo inserisco altrimenti lo aggiorno.


        Return False
    End Function


    ''' <summary>
    ''' Qui implementare quella funzione se non c'e' inseriscilo altrimenti aggiornalo.
    ''' </summary>
    ''' <param name="pseller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function storeSeller(ByVal pseller As MKMSeller) As Boolean

        Return False
    End Function
End Class
