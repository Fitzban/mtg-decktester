Public Class MTGGenetico

    Private best As IMTGDeck
    Private _db As New MTGCardsDatabase
    Private _deckbuilder As New MTGDeckBuilder
    Const MAX_DECK_NUM_CARDS As Integer = 60

    ''' <summary>
    ''' this function returns the best deck out of 100 random deck created.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function bestDeckOutOf100(Optional tests As Integer = 50) As IMTGDeck

        Dim ret As IMTGDeck = Nothing

        Dim results As New MTGMatchResult
        results.percentage = Integer.MinValue
        results.turn = Integer.MaxValue

        For index = 1 To 100

            ' build the deck
            Dim mdeck As IMTGDeck = _deckbuilder.buildDeck(New Random().Next(MAX_DECK_NUM_CARDS), MAX_DECK_NUM_CARDS, _db.cards)
            mdeck.algorithm = New BurnPlayalgorithms
            Dim test As New LinkedList(Of MTGMatchResult)

            ' test it
            For index2 = 1 To tests

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
    ''' dal momento che l'ordine non e' importante e devo evitare i doppioni:
    ''' - creo il primo deck prendendo le prime 30 carte dal primo deck e poi le prime N carte dal secondo deck fino ad averne 60
    ''' - creo il secondo deck prendendo le ultime 30 carte dal primo deck e le rimanenti 30 dall'ultima del secondo deck evitando i doppioni fino ad arrivare a 60
    ''' ripetere fino ad esaurimento deck
    ''' </summary>
    ''' <param name="decks"></param>
    ''' <remarks></remarks>
    Public Function accoppiareDeck(decks As List(Of IMTGDeck)) As List(Of IMTGDeck)

        Dim rnd As New Random
        Dim ret As New List(Of IMTGDeck)

        ' prendere due deck
        For index = 0 To decks.Count - 2 Step 2

            Dim tmpdeck As New MTGDeck

            ' creare deck con deck1(0-30), deck2(0-N)
            Dim index2 As Integer = 0
            For index2 = 0 To 30
                tmpdeck.Add(decks(index).draw)
            Next

            While tmpdeck.count_cards < 60
                tmpdeck.Add(decks(index + 1).draw)
            End While

            ret.Add(tmpdeck)

            ' creare deck con le rimanenti del deck2
            tmpdeck = New MTGDeck
            While decks(index + 1).cards.Count > 0
                tmpdeck.Add(decks(index + 1).draw)
            End While

            ' aggiungere dal deck 1 fino ad arrivare a 60  
            While tmpdeck.count_cards < 60
                tmpdeck.Add(decks(index).draw)
            End While

            If tmpdeck.count_cards >= 60 Then ret.Add(tmpdeck) : Continue For

            Dim database As New MTGCardsDatabase

            ' ecco che il crossover non ha prodotto un deck valido. Aggiungo carte pescando dalla base ed ho implementato la mutazione genetica.
            While tmpdeck.count_cards < 60

                Dim card As MTGCard = database.cards.library.FirstOrDefault
                tmpdeck.Add(card)
                database.cards.library.RemoveFirst()

            End While

            ret.Add(tmpdeck)

        Next

        Return ret
    End Function


End Class
