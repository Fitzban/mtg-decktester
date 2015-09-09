''' <summary>
''' Quest classe implementa il buyer.
''' Inizialmente il buyer si limita a caricare i possibili ordini. Un ordine sono tutte quelle carte di un venditore
''' che hanno un delta > MIN_GAIN.
''' delta = (1 - (prezzo di vendita / prezzo medio)) * 100 
''' </summary>
''' <remarks></remarks>
Public Class MKMBuyer

    Const MIN_GAIN As Integer = 40

    ' la preparazione di un ordine di acquisto non potrebbe essere una semplice query sul database a meno di non ricostruire una collezione.
    ' MongoDB mette Article in una collection e product in un altra collection e non ci sono le join.
    ' Mi devo quindi fare un listino (productId, max_price_allowed) e carico gli articoli di un venditore che hanno:
    ' Article.productID = productID & price < max_price_allowed



End Class
