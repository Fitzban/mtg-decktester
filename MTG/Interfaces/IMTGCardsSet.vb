Public Interface IMTGCardsSet

    Function take(num As Integer) As LinkedList(Of MTGCard)
    ReadOnly Property count_cards As Integer
    ReadOnly Property library As LinkedList(Of MTGCard)
End Interface
