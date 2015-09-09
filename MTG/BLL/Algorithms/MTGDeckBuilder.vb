Public Class MTGDeckBuilder

    Private _db As MTGCardsDatabase

    ''' <summary>
    ''' takes 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function buildDeck(mountainsn As Integer, cardsn As Integer) As IMTGDeck

        Dim ret As New MTGDeck
        Dim x As Integer = mountainsn
        If x < ret.min_lands Then x = ret.min_lands

        ' add the lands
        While x > 0
            ret.Add(New MTGCard("Mountain", 0, 0, True))
            x -= 1
        End While

        _db = New MTGCardsDatabase
        Dim rnd As New Random
        Dim tmp As Integer
        Dim card As MTGCard

        While ret.count_cards < cardsn

            If _db.cards.Count = 0 Then ret.Add(New MTGCard("Mountain", 0, 0, True)) : Continue While

            tmp = rnd.Next(_db.cards.Count)
            card = _db.cards(tmp)
            ret.Add(card)
            _db.cards.Remove(card)

        End While


        Return ret

    End Function


    Public Function cloneDeck(mdeck As IMTGDeck) As IMTGDeck
        Dim ret As New MTGDeck

        For Each c As MTGCard In mdeck.cards
            ret.Add(c)
        Next

        ret.algorithm = New BurnPlayalgorithms

        Return ret
    End Function


End Class
