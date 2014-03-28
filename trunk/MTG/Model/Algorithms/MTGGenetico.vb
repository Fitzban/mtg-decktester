Imports System.Text

Public Class MTGGenetico

    Private best As IMTGDeck
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
            Dim mdeck As IMTGDeck = _deckbuilder.buildDeck(New Random().Next(MAX_DECK_NUM_CARDS), MAX_DECK_NUM_CARDS)
            mdeck.algorithm = New BurnPlayalgorithms
            Dim test As New LinkedList(Of MTGMatchResult)

            ' test it
            For index2 = 1 To tests

                Dim tmpdeck As IMTGDeck = _deckbuilder.cloneDeck(mdeck)
                tmpdeck.shuffle()
                Dim result As MTGMatchResult = tmpdeck.play
                test.AddLast(result)

            Next

            ' read the results
            Dim counts(7) As Integer
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
        Dim database As MTGCardsDatabase
        Dim lands As Integer
        Dim missing As Integer

        ' prendere due deck
        For index = 0 To decks.Count - 2 Step 2

            Dim tmpdeck As New MTGDeck
            Dim tmpdeck2 As New MTGDeck
            decks(index).shuffle()

            ' creare deck con deck1(0-30), deck2(0-N)
            Dim index2 As Integer = 0
            For index2 = 0 To New Random().Next(60)
                tmpdeck.Add(decks(index).draw)
            Next

            decks(index + 1).shuffle()
            While tmpdeck.count_cards < 60

                Dim c As MTGCard = decks(index + 1).draw
                If Not tmpdeck.Add(c) Then tmpdeck2.Add(c)

            End While
            If tmpdeck.count_cards >= 60 Then
                ' the deck is valid, go on. (maybe too much lands)
                ret.Add(tmpdeck)
            Else
                ' this deck is invalid
                ' add the lands
                lands = tmpdeck.count_lands
                missing = tmpdeck.min_lands - lands
                While missing > 0
                    tmpdeck.Add(New MTGCard("Mountain", 0, 0, True))
                End While
                ' still invalid?
                If tmpdeck.count_cards < 60 Then
                    database = New MTGCardsDatabase

                    While tmpdeck.count_cards < 60

                        Dim card As MTGCard = database.cards.FirstOrDefault
                        tmpdeck.Add(card)
                        database.cards.RemoveFirst()

                    End While
                End If

                ret.Add(tmpdeck)


            End If

            ' creare deck con le rimanenti del deck2
            While decks(index + 1).cards.Count > 0 AndAlso decks(index + 1).cards.Count > 0
                tmpdeck2.Add(decks(index + 1).draw)
            End While

            ' aggiungere dal deck 1 fino ad arrivare a 60  
            While tmpdeck2.count_cards < 60 AndAlso decks(index).cards.Count > 0
                tmpdeck2.Add(decks(index).draw)
            End While

            If tmpdeck2.count_cards >= 60 Then ret.Add(tmpdeck2) : Continue For

            ' this deck is invalid
            ' add the lands
            lands = tmpdeck2.count_lands
            missing = tmpdeck2.min_lands - lands
            While missing > 0
                tmpdeck2.Add(New MTGCard("Mountain", 0, 0, True))
                missing -= 1
            End While

            If tmpdeck2.count_cards >= 60 Then ret.Add(tmpdeck2) : Continue For

            Dim i As Integer = 0

            ' still invalid.
            Dim random As New Random
            database = New MTGCardsDatabase
            Dim rnd_limit As Integer = database.cards.Count
            While tmpdeck2.count_cards < 60

                Dim card As MTGCard = database.cards(random.Next(rnd_limit))
                i += 1
                tmpdeck2.Add(card)

                If i > database.cards.Count Then Exit While

            End While

            ret.Add(tmpdeck2)

        Next

        Return ret
    End Function


    Public Sub run(num_deck As Integer, num_tests As Integer, numero_iterazioni As Integer, numero_popolazioni As Integer, turn_log As Boolean)


        Dim guid As String = Now.Date.Ticks.ToString
        For index = 1 To numero_popolazioni

            Dim decks As New List(Of IMTGDeck)(num_deck)

            ' generare popolazione
            For index2 = 1 To num_deck

                ' generare 100 deck e testarli per estrare il migliore (quello che chiude meglio su 50 match)
                decks.Add(bestDeckOutOf100(num_tests))
            Next



            ' qui mettiamo tutto, chiusure e deck
            Dim resultf As New System.IO.StreamWriter(guid & "_popolazione_" & index.ToString & ".txt")

            iterate(numero_iterazioni, num_deck, num_tests, decks, turn_log, resultf, guid, index.ToString)

            resultf.Close()

        Next


    End Sub



    Private Sub iterate(numero_iterazioni As Integer, num_deck As Integer, num_tests As Integer, decks As List(Of IMTGDeck), _
                        turn_log As Boolean, resultf As IO.StreamWriter, guid As String, popolazione As String)

        Dim results As New MTGMatchResult
        results.percentage = Integer.MinValue
        results.turn = Integer.MaxValue

        ' cross over
        Dim newdecks As New List(Of IMTGDeck)(num_deck)
        newdecks.AddRange(accoppiareDeck(decks))


        ' iterate
        For iteration_index = 1 To numero_iterazioni

            ' estrarre il migliore
            For deck_index = 1 To decks.Count - 1

                ' build the deck
                If newdecks(deck_index).algorithm Is Nothing Then newdecks(deck_index).algorithm = New BurnPlayalgorithms
                Dim test_list As New LinkedList(Of MTGMatchResult)

                ' test it
                For index2 = 1 To num_tests
                    Dim tmpdeck As IMTGDeck = _deckbuilder.cloneDeck(newdecks(deck_index))
                    tmpdeck.shuffle()
                    Dim result As MTGMatchResult = tmpdeck.play
                    test_list.AddLast(result)
                Next

                ' read the results
                Dim counts(7) As Integer
                Dim lost_num As Integer = 0
                For Each match_result As MTGMatchResult In test_list
                    If Not match_result.turns(0).lost Then
                        counts(match_result.turns(0).turnnumber) += 1
                    Else
                        lost_num += 1
                    End If


                Next

                If lost_num > 50 Then Continue For

                '' store the maximum victories
                Dim percentage As Integer = counts(4) * 8 + counts(5) * 4 + counts(6) * 2 + counts(7)

                If results.percentage < percentage Then
                    results.percentage = percentage
                    results.deck = newdecks(deck_index).ToString
                    Dim tmp As New StringBuilder
                    tmp.Append("value: ")
                    tmp.Append(percentage.ToString)
                    tmp.Append("/")
                    tmp.AppendLine((num_tests * 8).ToString)
                    tmp.Append("lost: ")
                    tmp.AppendLine(lost_num.ToString)
                    tmp.Append("chiusure 4: ")
                    tmp.AppendLine(counts(4).ToString)
                    tmp.Append("chiusure 5: ")
                    tmp.AppendLine(counts(5).ToString)
                    tmp.Append("chiusure 6: ")
                    tmp.AppendLine(counts(6).ToString)
                    tmp.Append("chiusure 7: ")
                    tmp.AppendLine(counts(7).ToString)
                    tmp.AppendLine()
                    tmp.AppendLine(results.deck)
                    resultf.Write(tmp.ToString)

                    If turn_log Then
                        ' I generate a file with all the turns.
                        Dim mlog As New System.IO.StreamWriter(guid & "_popolazione_" & popolazione & "_value_" & results.percentage.ToString & " out of " & (num_tests * 8).ToString & ".txt")
                        tmp = New StringBuilder
                        For Each test As MTGMatchResult In test_list
                            mlog.WriteLine()
                            mlog.WriteLine(test.result)
                        Next
                        mlog.Close()
                    End If

                    ' found something new, set the counter to 0. The iterations stops when no more able to find someting better.
                    iteration_index = 0
                End If

            Next

            ' trovato il migliore ulteriore iterazione con cross over
            Dim tmpdecks As New List(Of IMTGDeck)(newdecks.AsEnumerable)
            newdecks = New List(Of IMTGDeck)(accoppiareDeck(tmpdecks).AsEnumerable)



        Next
    End Sub


End Class
