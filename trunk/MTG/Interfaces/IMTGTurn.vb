Public Interface IMTGTurn

    Sub draw()
    Sub playland()
    Sub play(card As MTGCard)

    ReadOnly Property nextcardtoplay As MTGCard
    ReadOnly Property turnnumber As Integer
End Interface
