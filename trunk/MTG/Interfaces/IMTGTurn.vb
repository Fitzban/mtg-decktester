Public Interface IMTGTurn

    Sub draw()
    Sub playland()
    Sub play(card As MTGCard)

    ReadOnly Property nextcardtoplay As MTGCard
End Interface
