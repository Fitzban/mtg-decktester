Public Interface IMTGDeck
    Function play() As MTGMatchResult
    Function draw() As MTGCard
    Function getCardsByNAme(name As String) As IEnumerable(Of MTGCard)

    Sub shuffle()
    Sub remove(card As MTGCard)
    Sub addRange(cards As List(Of MTGCard))

    Property algorithm As IMTGAlgorithm
    ReadOnly Property cards As List(Of MTGCard)
    ''' <summary>
    ''' This return the average damage done at the turn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property aggressivity() As IMTGAggressivity
End Interface
