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
    Public Sub shuffle() Implements IMTGDeck.shuffle

        Dim p1 As New LinkedList(Of LinkedList(Of MTGCard))

        ' 7 piles
        For index = 1 To 7
            p1.AddLast(New LinkedList(Of MTGCard))
        Next

        Dim i As Integer = 0
        For Each c As MTGCard In Me.library

            p1.ElementAt(i).AddLast(c)
            i = (i + 1) Mod 7

        Next
        library.Clear()
        For Each p As LinkedList(Of MTGCard) In p1
            For Each c As MTGCard In p
                library.AddLast(c)
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
        Dim cut As Integer = New Random().Next(library.Count)
        For i = 0 To cut
            p2.AddLast(library.ElementAt(i))
        Next
        While i < library.Count
            p3.AddLast(library.ElementAt(i))
            i += 1
        End While
        Dim top As Integer = library.Count
        library.Clear()

        For index = 0 To top
            If index < p2.Count Then library.AddLast(p2.ElementAt(index))
            If index < p3.Count Then library.AddLast(p3.ElementAt(index))
        Next
    End Sub
End Class
