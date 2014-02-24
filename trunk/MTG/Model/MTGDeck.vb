Public Class MTGDeck
    Inherits MTGCardSet
    Implements IMTGDeck

    Private _playingdeck As List(Of MTGCard)

    Public Function play() As MTGMatchResult Implements IMTGDeck.play

        If _algo Is Nothing Then Return Nothing
        _playingdeck = New List(Of MTGCard)(library.Count)

        For Each c As MTGCard In library
            _playingdeck.Add(c)
        Next

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


    Public Sub addRange(pcards As List(Of MTGCard)) Implements IMTGDeck.addRange

        For Each c As MTGCard In pcards
            library.AddLast(c)
        Next

    End Sub

    Public Function draw() As MTGCard Implements IMTGDeck.draw
        Dim ret As MTGCard = _playingdeck(0)
        _playingdeck.RemoveAt(0)
        Return ret
    End Function

    Public Sub remove(card As MTGCard) Implements IMTGDeck.remove
        _playingdeck.Remove(card)
    End Sub

    ''' <summary>
    ''' shuffle the library
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub shuffle2() Implements IMTGDeck.shuffle
        shuffle()
    End Sub

    Public Function getCardsByNAme(name As String) As System.Collections.Generic.IEnumerable(Of MTGCard) Implements IMTGDeck.getCardsByNAme
        Return From card As MTGCard In _playingdeck Select card Where card.name = name
    End Function
End Class
