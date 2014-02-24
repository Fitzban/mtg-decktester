Public Interface IMTGDeck
    Function play() As MTGMatchResult
    Function draw() As MTGCard
    Function getCardsByNAme(name As String) As IEnumerable(Of MTGCard)

    Sub shuffle()
    Sub remove(card As MTGCard)
    Sub addRange(cards As List(Of MTGCard))

    Property algorithm As IMTGAlgorithm
End Interface
