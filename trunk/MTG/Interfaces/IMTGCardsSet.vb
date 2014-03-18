Public Interface IMTGCardsSet
    Function take(num As Integer) As LinkedList(Of MTGCard)
    ReadOnly Property count_cards As Integer
End Interface
