Public Class MTGGenetico

    Private best As IMTGDeck
    Private _db As New MTGCardsDatabase
    Private _deckbuilder As New MTGDeckBuilder

    ''' <summary>
    ''' this function returns the best deck out of 100 random deck created.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function bestDeckOutOf100() As IMTGDeck

        Dim ret As IMTGDeck = Nothing

        Dim results As New MTGMatchResult
        results.percentage = Integer.MinValue
        results.turn = Integer.MaxValue

        For index = 1 To 100

            ' build the deck
            Dim mdeck As IMTGDeck = _deckbuilder.buildDeck(19, 60, _db.cards)
            mdeck.algorithm = New BurnPlayalgorithms
            Dim test As New LinkedList(Of MTGMatchResult)

            ' test it
            For index2 = 1 To 50

                mdeck.shuffle()
                Dim result As MTGMatchResult = mdeck.play
                test.AddLast(result)

            Next

            ' read the results
            Dim counts(6) As Integer
            For Each r As MTGMatchResult In test
                counts(r.turns(0).turnnumber) += 1
            Next

            '' store the maximum victories
            Dim percentage As Integer = counts(3) * 8 + counts(4) * 4 + counts(5) * 2 + counts(6)
            If results.percentage < percentage Then
                results.percentage = percentage
                ret = mdeck
            End If

        Next

        Return ret

    End Function

    
    ''' <summary>
    ''' prendere due deck
    ''' scegliere un taglio
    ''' creare deck con deck1(0-taglio),deck2(taglio+1,end)
    ''' ripetere fino ad esaurimento deck
    ''' </summary>
    ''' <param name="decks"></param>
    ''' <remarks></remarks>
    Public Function accoppiareDeck(decks As List(Of IMTGDeck)) As List(Of IMTGDeck)

        Dim rnd As New Random
        Dim ret As New List(Of IMTGDeck)

        ' prendere due deck
        For index = 0 To decks.Count - 2 Step 2

            ' scegliere un taglio
            Dim cut As Integer = rnd.Next(60)
            Dim tmpdeck As New MTGDeck

            ' creare deck con deck1(0-taglio),deck2(taglio+1,end)
            Dim index2 As Integer = 0
            For index2 = 0 To cut
                tmpdeck.library.AddLast(decks(index).draw)
                decks(index + 1).draw()
            Next

            While index2 < 60
                tmpdeck.library.AddLast(decks(index + 1).draw)
                index2 += 1
            End While

            ret.Add(tmpdeck)

            ' creare deck con deck2(0-taglio),deck1(taglio+1,end)
            tmpdeck = New MTGDeck
            For index2 = 0 To cut
                tmpdeck.library.AddLast(decks(index + 1).draw)
                decks(index).draw()
            Next

            While index2 < 60
                tmpdeck.library.AddLast(decks(index).draw)
                index2 += 1
            End While

            ret.Add(tmpdeck)

        Next

        Return ret
    End Function


End Class
