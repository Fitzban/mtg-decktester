Public Interface IMTGDeck
    Function play() As MTGMatchResult
    Function draw() As MTGCard
    Function add(c As MTGCard) As Boolean
    Function getCardsByNAme(name As String) As IEnumerable(Of MTGCard)

    Sub shuffle()
    Sub remove(card As MTGCard)

    Property algorithm As IMTGAlgorithm
    ReadOnly Property cards As LinkedList(Of MTGCard)
    ''' <summary>
    ''' This return the average damage done at the turn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property aggressivity() As IMTGAggressivity

    ReadOnly Property count_lands As Integer
End Interface
