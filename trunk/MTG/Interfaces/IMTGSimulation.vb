Public Interface IMTGSimulation

    ReadOnly Property mydeck As IMTGDeck
    ReadOnly Property opponent As IMTGDeck
    ReadOnly Property match As MTGMatch
    ReadOnly Property matchresult As MTGMatchResult

    ''' <summary>
    ''' this subroutine simulate a match turn by turn.
    ''' </summary>
    ''' <remarks></remarks>
    Sub simulatematch()

End Interface
