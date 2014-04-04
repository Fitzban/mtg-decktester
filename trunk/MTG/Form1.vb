Imports System.Text
Imports System.IO

Public Class Form1

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

        mdeck = buildCapodanno()
        deck.Text = mdeck.ToString
        Me.Refresh()
        Dim numtests As Integer = Integer.Parse(MaskedTextBox1.Text)

        For index = 1 To numtests

            mdeck.shuffle()

            mdeck.algorithm = New BurnPlayalgorithms
            Dim result As MTGMatchResult = mdeck.play
            test.AddLast(result)

            mdeck = buildCapodanno()
        Next

        Dim counts(7) As Integer
        For Each r As MTGMatchResult In test

            counts(r.turns(0).turnnumber) += 1

        Next

        Dim ret As New StringBuilder
        ret.AppendLine("chiusure di 4: " + counts(4).ToString)
        ret.AppendLine("chiusure di 5: " + counts(5).ToString)
        ret.AppendLine("chiusure di 6: " + counts(6).ToString)
        ret.AppendLine("chiusure di 7: " + counts(7).ToString)
        ret.AppendLine("value: " + (counts(4) * 8 + counts(5) * 4 + counts(6) * 2 + counts(7)).ToString + " out of " + (8 * numtests).ToString)


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


        mdeck = _deckbuilder.buildDeck(19, 60)
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


    ''' <summary>
    ''' generare 100 deck e testarli per estrare il migliore (quello che chiude meglio nei test)
    '''
    ''' farlo N volte (a questo punto ho i 100 migliori deck generati, iniziano gli accoppiamenti)
    ''' 
    ''' prendere due deck
    ''' scegliere un taglio
    ''' sostituire deck1 da 0 a taglio con deck2 da 0 a taglio
    ''' ripetere fino ad esaurimento deck
    ''' 
    ''' (mutazioni genetiche, ogni carta ha il 0.5% di probabilita' di mutare con una altra carta a caso. Per ogni deck.)
    ''' 
    ''' testare i nuovi deck generati per estrarre il migliore (quello che chiude meglio nei test)
    ''' 
    ''' iterare finche per T volte non migliora il best deck.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button5_Genetic(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        Dim num_deck As Integer = Integer.Parse(in_num_deck.Text)
        Dim num_tests As Integer = Integer.Parse(in_num_deck_test.Text)
        Dim numero_iterazioni As Integer = Integer.Parse(in_num_iterazioni_max.Text)
        Dim numero_popolazioni As Integer = Integer.Parse(num_popolazioni.Text)

        Dim genetico As New MTGGenetico
        genetico.run(num_deck, num_tests, numero_iterazioni, numero_popolazioni, turn_log.Checked)

    End Sub


    Private Sub mtgolibrarydownloader_Click(sender As System.Object, e As System.EventArgs) Handles mtgolibrarydownloader.Click

        Dim trader As New MTGTRader
        trader.getPrices(Me.setcode.Text, Integer.Parse(Me.num_carte_set.Text))
        


    End Sub

  

    Private Sub pick_directory_Click(sender As System.Object, e As System.EventArgs) Handles pick_directory.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()


        fd.Title = "Open File Dialog"
        fd.InitialDirectory = ".\"
        fd.Filter = "HTML files (*.html)|*.html|HTML files (*.html)|*.html"
        fd.FilterIndex = 2
        fd.Multiselect = True
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Dim traderan As New MTGTraderDownloadedCardAnalyzer
            traderan.analyze(fd.FileNames, Me.RichTextBox1)
        End If

        
    End Sub
End Class

