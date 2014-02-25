Public Class BurnPlayalgorithms
    Implements IMTGAlgorithm

    Dim hand As New LinkedList(Of MTGCard)
    Dim playground As New LinkedList(Of MTGCard)
    Dim cemetery As New LinkedList(Of MTGCard)

    ''' <summary>
    ''' draw, play land fire
    ''' draw, play land fire
    ''' draw, play land fire
    ''' draw, play land fire
    ''' draw, play land fire
    ''' draw, play land fire
    ''' draw, play land fire
    ''' </summary>
    ''' <param name="deck"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function play(deck As IMTGDeck) As MTGMatchResult Implements IMTGAlgorithm.play

        Dim match As New MTGMatch
        Dim result As New MTGMatchResult

        Dim PV As Integer = 20
        Dim hand As New LinkedList(Of MTGCard)
        hand.AddLast(deck.draw())
        hand.AddLast(deck.draw())
        hand.AddLast(deck.draw())
        hand.AddLast(deck.draw())
        hand.AddLast(deck.draw())
        hand.AddLast(deck.draw())
        hand.AddLast(deck.draw())

        Dim turnnumber As Integer = 0
        Dim turn As MTGTurn = New MTGTurn(hand, New LinkedList(Of MTGCard), New LinkedList(Of MTGCard), deck, turnnumber, 0)


        result.turns.AddLast(turn)
        deck.shuffle()
        While PV > 0 AndAlso turnnumber < 6

            turnnumber += 1
            turn = New MTGTurn(turn.playground.hand, turn.playground.cardsingame, turn.playground.cemetery, deck, turnnumber, turn.totaldamage)


            ' draw
            turn.draw()

            ' play land
            turn.playland()

            ' pickup
            Dim cardtoplay As MTGCard = turn.nextcardtoplay

            While cardtoplay IsNot Nothing AndAlso turn.playground.availablelands >= cardtoplay.converted_cost

                turn.play(cardtoplay)
                cardtoplay = turn.nextcardtoplay

            End While

            result.turns.AddLast(turn)
            PV -= turn.damagedone


        End While

        Dim finalturn As New MTGLastTurn(PV, turnnumber)
        result.turns.AddFirst(finalturn)

        Return result

    End Function

End Class
