Public Interface IMTGTurn

    Sub draw()
    Sub playland()
    Sub play(card As MTGCard)

    ReadOnly Property nextcardtoplay As MTGCard
    ReadOnly Property turnnumber As Integer
    ReadOnly Property totaldamage As Integer
    ReadOnly Property damagedone As Integer
    ReadOnly Property playground As MTGPlayGround
    ReadOnly Property deck As IMTGDeck


End Interface
