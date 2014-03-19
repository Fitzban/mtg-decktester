Public Class MTGDeck
    Implements IMTGDeck

    Private _playingdeck As New LinkedList(Of MTGCard)
    Private _aggressivity As IMTGAggressivity
    Private _max_numcards As Integer ' this indicate how many cards max should we have in this deck
    Public min_lands As Integer = 15

    Public Function play() As MTGMatchResult Implements IMTGDeck.play

        Return _algo.play(Me)

    End Function

    Private _algo As IMTGAlgorithm
    Property algorithm As IMTGAlgorithm Implements IMTGDeck.algorithm
        Get
            Return _algo
        End Get
        Set(value As IMTGAlgorithm)
            _algo = value
        End Set
    End Property

    ''' <summary>
    ''' No more than 4 each.
    ''' </summary>
    ''' <param name="card"></param>
    ''' <remarks></remarks>
    Public Function Add(card As MTGCard) As Boolean Implements IMTGDeck.add

        If card.island AndAlso count_lands < 25 Then _playingdeck.AddLast(card) : Return True

        If (From x As MTGCard In _playingdeck Select x Where x.name = card.name).Count < card.max_available Then _playingdeck.AddLast(card) : Return True

        Return False

    End Function

    Public Function draw() As MTGCard Implements IMTGDeck.draw
        Dim ret As MTGCard = _playingdeck(0)
        _playingdeck.RemoveFirst()
        Return ret
    End Function

    Public Sub remove(card As MTGCard) Implements IMTGDeck.remove
        _playingdeck.Remove(card)
    End Sub

    Public Function getCardsByNAme(name As String) As System.Collections.Generic.IEnumerable(Of MTGCard) Implements IMTGDeck.getCardsByNAme
        Return From card As MTGCard In _playingdeck Select card Where card.name = name
    End Function

    Public ReadOnly Property cards As System.Collections.Generic.LinkedList(Of MTGCard) Implements IMTGDeck.cards
        Get
            Return _playingdeck
        End Get
    End Property

    Public Property aggressivity() As IMTGAggressivity Implements IMTGDeck.aggressivity
        Get
            Return _aggressivity
        End Get
        Set(value As IMTGAggressivity)
            _aggressivity = value
        End Set
    End Property

    Public ReadOnly Property count_lands As Integer Implements IMTGDeck.count_lands
        Get
            Return (From x As MTGCard In _playingdeck Select x Where x.island).Count
        End Get
    End Property

    Public ReadOnly Property count_cards As Integer
        Get
            Return _playingdeck.Count
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim ret As New System.Text.StringBuilder

        Dim enume As IEnumerable(Of MTGCard) = From x As MTGCard In _playingdeck Select x Order By x.name

        Dim lands As Integer = (From x As MTGCard In _playingdeck Select x Where x.island).Count
        ret.AppendLine(lands & " Mountains")

        For Each c As MTGCard In enume

            If Not c.island Then ret.AppendLine(c.name)

        Next

        Return ret.ToString
    End Function
    ''' <summary>
    ''' shuffle the library
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub shuffle() Implements IMTGDeck.shuffle

        Dim p1 As New LinkedList(Of LinkedList(Of MTGCard))

        ' 7 piles
        For index = 1 To 7
            p1.AddLast(New LinkedList(Of MTGCard))
        Next

        Dim i As Integer = 0
        For Each c As MTGCard In Me._playingdeck

            p1.ElementAt(i).AddLast(c)
            i = (i + 1) Mod 7

        Next
        _playingdeck.Clear()
        For Each p As LinkedList(Of MTGCard) In p1
            For Each c As MTGCard In p
                _playingdeck.AddLast(c)
            Next
        Next
        p1 = Nothing

        shuffle2()
        shuffle2()
        shuffle2()
        shuffle2()
        shuffle2()
        shuffle2()
        shuffle2()

    End Sub

    Private Sub shuffle2()
        Dim i As Integer = 0
        ' shuffle
        Dim p2 As New LinkedList(Of MTGCard)
        Dim p3 As New LinkedList(Of MTGCard)
        Dim cut As Integer = New Random().Next(_playingdeck.Count)
        For i = 0 To cut
            p2.AddLast(_playingdeck.ElementAt(i))
        Next
        While i < _playingdeck.Count
            p3.AddLast(_playingdeck.ElementAt(i))
            i += 1
        End While
        Dim top As Integer = _playingdeck.Count
        _playingdeck.Clear()

        For index = 0 To top
            If index < p2.Count Then _playingdeck.AddLast(p2.ElementAt(index))
            If index < p3.Count Then _playingdeck.AddLast(p3.ElementAt(index))
        Next
    End Sub

End Class
