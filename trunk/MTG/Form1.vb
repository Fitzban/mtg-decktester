Imports System.Text

Public Class Form1

    Public db As New MTGCardsDatabase
    Public mdeck As IMTGDeck
    Private _deckbuilder As New MTGDeckBuilder

    ''' <summary>
    ''' Loads the library
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_BuildAndTest(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim test As New LinkedList(Of MTGMatchResult)

        mdeck = _deckbuilder.buildDeck(19, 60, db.cards)
        deck.Text = mdeck.ToString
        Me.Refresh()

        For index = 1 To Integer.Parse(MaskedTextBox1.Text)

            mdeck.shuffle()

            mdeck.algorithm = New BurnPlayalgorithms
            Dim result As MTGMatchResult = mdeck.play
            test.AddLast(result)

        Next

        Dim counts(6) As Integer
        For Each r As MTGMatchResult In test

            counts(r.turns(0).turnnumber) += 1

        Next

        Dim ret As New StringBuilder
        ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
        ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
        ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
        ret.AppendLine("chiusure di sesto: " + counts(6).ToString)

        RichTextBox1.Text = ret.ToString

    End Sub

    ''' <summary>
    ''' Main algorithm.
    ''' 1) build a deck
    ''' 2) play the deck 100 times
    ''' 3) store the stats
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_BuildAndTestOneTime(sender As System.Object, e As System.EventArgs) Handles Button2.Click


        mdeck = _deckbuilder.buildDeck(19, 60, db.cards)
        mdeck.shuffle()
        deck.Text = mdeck.ToString
        Me.Refresh()

        mdeck.algorithm = New BurnPlayalgorithms
        Dim result As MTGMatchResult = mdeck.play

        RichTextBox1.Text = result.result

    End Sub

    Private Function buildCapodanno() As IMTGDeck
        Dim ret As New MTGDeck
        Dim x As Integer = 20

        ' add the lands
        While x > 0
            ret.Add(New MTGCard("Mountain", 0, 0, True))
            x -= 1
        End While

        ' add the cards
        Dim sourceries As Integer = 40

        ret.Add(New MTGCard("fulmine", 3, 1))
        ret.Add(New MTGCard("fulmine", 3, 1))
        ret.Add(New MTGCard("fulmine", 3, 1))
        ret.Add(New MTGCard("fulmine", 3, 1))

        ret.Add(New MTGCard("chain lightning", 3, 1))
        ret.Add(New MTGCard("chain lightning", 3, 1))
        ret.Add(New MTGCard("chain lightning", 3, 1))
        ret.Add(New MTGCard("chain lightning", 3, 1))

        ret.Add(New MTGCard("incinerate", 3, 2))
        ret.Add(New MTGCard("incinerate", 3, 2))
        ret.Add(New MTGCard("incinerate", 3, 2))
        ret.Add(New MTGCard("incinerate", 3, 2))

        ret.Add(New MTGCard("firebolt", 2, 1))
        ret.Add(New MTGCard("firebolt", 2, 1))
        ret.Add(New MTGCard("firebolt", 2, 1))
        ret.Add(New MTGCard("firebolt", 2, 1))

        ret.Add(New MTGCard("flame rift", 1, 1))
        ret.Add(New MTGCard("flame rift", 1, 1))
        ret.Add(New MTGCard("flame rift", 1, 1))
        ret.Add(New MTGCard("flame rift", 1, 1))

        ret.Add(New MTGCard("chain of plasma", 3, 2))
        ret.Add(New MTGCard("chain of plasma", 3, 2))
        ret.Add(New MTGCard("chain of plasma", 3, 2))
        ret.Add(New MTGCard("chain of plasma", 3, 2))

        ret.Add(New MTGCard("magma jet", 2, 2))
        ret.Add(New MTGCard("magma jet", 2, 2))
        ret.Add(New MTGCard("magma jet", 2, 2))
        ret.Add(New MTGCard("magma jet", 2, 2))

        ret.Add(New MTGCard("rift bolt", 3, 1))
        ret.Add(New MTGCard("rift bolt", 3, 1))
        ret.Add(New MTGCard("rift bolt", 3, 1))
        ret.Add(New MTGCard("rift bolt", 3, 1))

        ret.Add(New MTGCard("lava spike", 3, 1))
        ret.Add(New MTGCard("lava spike", 3, 1))
        ret.Add(New MTGCard("lava spike", 3, 1))
        ret.Add(New MTGCard("lava spike", 3, 1))

        ret.Add(New MTGCard("burst lightning", 2, 1))
        ret.Add(New MTGCard("burst lightning", 2, 1))
        ret.Add(New MTGCard("burst lightning", 2, 1))
        ret.Add(New MTGCard("burst lightning", 2, 1))

        Return ret
    End Function

    Private Function takeordered() As IMTGDeck
        Dim ret As New MTGDeck
        Dim x As Integer = 20

        ' add the lands
        While x > 0
            ret.Add(New MTGCard("Mountain", 0, 0, True))
            x -= 1
        End While

        ' add the cards taking by rateo from the higest
        Dim sourceries As Integer = 40
        Dim pick As List(Of MTGCard) = (From y As MTGCard In db.cards.library.AsEnumerable Select y Order By y.rateo Descending).Take(sourceries).ToList
        ret.addRange(pick)

        Return ret
    End Function

    ''' <summary>
    ''' Takes the cards ordered by rateo descending.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_BiuldOrderedAndTest(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        deck.Text = ""
        deck.Refresh()
        Dim test As New LinkedList(Of MTGMatchResult)

        mdeck = takeordered()
        deck.Text = mdeck.ToString
        Me.Refresh()

        For index = 1 To Integer.Parse(MaskedTextBox1.Text)

            mdeck.shuffle()

            mdeck.algorithm = New BurnPlayalgorithms
            Dim result As MTGMatchResult = mdeck.play
            test.AddLast(result)

        Next

        Dim counts(6) As Integer
        For Each r As MTGMatchResult In test

            counts(r.turns(0).turnnumber) += 1

        Next

        Dim ret As New StringBuilder
        ret.AppendLine("value: " + (counts(3) * 8 + counts(4) * 4 + counts(5) * 2 + counts(6)).ToString)
        ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
        ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
        ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
        ret.AppendLine("chiusure di sesto: " + counts(6).ToString)

        RichTextBox1.Text = ret.ToString
    End Sub

    ''' <summary>
    ''' THis will generate 100 decks random and will test them 1000 of times. Will give back the best as percentage of victories.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button4_Test1000decks(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim results As New MTGMatchResult
        results.percentage = Integer.MinValue
        results.turn = Integer.MaxValue

        For index = 1 To 5000

            ' build the deck
            Dim mdeck As IMTGDeck = _deckbuilder.buildDeck(19, 60, db.cards)
            Me.Label1.Text = "test : " & index.ToString
            Me.Label1.Refresh()

            mdeck.algorithm = New BurnPlayalgorithms

            Dim test As New LinkedList(Of MTGMatchResult)

            ' test it
            For index2 = 1 To 250

                mdeck.shuffle()

                Dim result As MTGMatchResult = mdeck.play
                test.AddLast(result)

            Next

            ' read the results
            Dim counts(6) As Integer
            For Each r As MTGMatchResult In test

                counts(r.turns(0).turnnumber) += 1

            Next

            Dim ret As New StringBuilder
            '' store the maximum victories
            Dim percentage As Integer = counts(3) * 8 + counts(4) * 4 + counts(5) * 2 + counts(6)
            If results.percentage < percentage Then

                results.percentage = percentage
                ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
                ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
                ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
                ret.AppendLine("chiusure di sesto: " + counts(6).ToString)
                ret.AppendLine()
                ret.AppendLine(mdeck.ToString)

                results.deck = ret.ToString
                Me.deck.Text = results.deck
                Me.deck.Refresh()

            End If

            ret = New StringBuilder
            ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
            ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
            ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
            ret.AppendLine("chiusure di sesto: " + counts(6).ToString)
            ret.AppendLine()
            ret.AppendLine(mdeck.ToString)
            RichTextBox1.Text = ret.ToString
            RichTextBox1.Refresh()
        Next

        Me.RichTextBox1.Text = results.turn & " ---  " & results.percentage
        Me.deck.Text = results.deck

    End Sub

    ''' <summary>
    ''' generare 100 deck e testarli per estrare il migliore (quello che chiude meglio 50 match)
    '''
    ''' farlo 100 volte (a questo punto ho i 100 migliori deck generati, iniziano gli accoppiamenti)
    ''' 
    ''' prendere due deck
    ''' scegliere un taglio
    ''' sostituire deck1 da 0 a taglio con deck2 da 0 a taglio
    ''' ripetere fino ad esaurimento deck
    ''' 
    ''' integrare con deck mancanti
    ''' 
    ''' (mutazioni genetiche, ogni carta ha il 0.5% di probabilita' di mutare con una altra carta a caso. Per ogni deck.)
    ''' 
    ''' testare i nuovi deck generati per estrarre il migliore (quello che chiude meglio su 50 match)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button5_Genetic(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        Dim decks As New List(Of IMTGDeck)(100)
        Dim genetico As New MTGGenetico
        Dim results As New MTGMatchResult
        results.percentage = Integer.MinValue
        results.turn = Integer.MaxValue


        ' generare popolazione
        For index = 1 To 100

            Me.Label1.Text = index.ToString
            Me.Label1.Refresh()

            ' generare 100 deck e testarli per estrare il migliore (quello che chiude meglio su 50 match)
            decks.Add(genetico.bestDeckOutOf100)
        Next

        ' cross over
        Dim newdecks As New List(Of IMTGDeck)(100)
        newdecks.AddRange(genetico.accoppiareDeck(decks))

        ' iterate
        For indexx = 1 To Integer.Parse(iterazionigenetico.Text)
            Me.Label1.Text = indexx.ToString
            Me.Label1.Refresh()

            ' estrarre il migliore
            For index = 1 To decks.Count - 1

                ' build the deck
                If newdecks(index).algorithm Is Nothing Then newdecks(index).algorithm = New BurnPlayalgorithms
                Dim test As New LinkedList(Of MTGMatchResult)

                ' test it
                For index2 = 1 To 50
                    newdecks(index).shuffle()
                    Dim result As MTGMatchResult = newdecks(index).play
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
                    results.deck = decks(index).ToString
                    Dim tmp As New StringBuilder
                    tmp.Append("value: ")
                    tmp.AppendLine(results.percentage.ToString)
                    tmp.Append("chiusure 3: ")
                    tmp.AppendLine(counts(3).ToString)
                    tmp.Append("chiusure 4: ")
                    tmp.AppendLine(counts(4).ToString)
                    tmp.Append("chiusure 5: ")
                    tmp.AppendLine(counts(5).ToString)
                    tmp.Append("chiusure 6: ")
                    tmp.AppendLine(counts(6).ToString)
                    tmp.AppendLine()
                    tmp.AppendLine(results.deck)
                    Me.deck.Text = tmp.ToString
                    Me.deck.Refresh()

                    ' found something new, set the counter to 0. The iterations stops when no more able to find someting better.
                    indexx = 0
                End If

            Next

            ' trovato il migliore ulteriore iterazione con cross over
            Dim tmpdecks As New List(Of IMTGDeck)(newdecks.AsEnumerable)
            newdecks = New List(Of IMTGDeck)(genetico.accoppiareDeck(tmpdecks).AsEnumerable)



        Next

        


    End Sub


End Class

