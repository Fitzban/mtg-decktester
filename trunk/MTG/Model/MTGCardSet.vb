Imports System.Text

Public Class MTGCardSet
    Implements IMTGCardsSet

    Public library As LinkedList(Of MTGCard)

    Sub New()
        library = New LinkedList(Of MTGCard)
    End Sub

    Public Sub Add(card As MTGCard)

        library.AddLast(card)

    End Sub

    Public Function take(num As Integer) As LinkedList(Of MTGCard) Implements IMTGCardsSet.take
        shuffle()
        Dim ret As New LinkedList(Of MTGCard)(library.Take(num).ToList)
        Return ret
    End Function


    Public Overrides Function ToString() As String
        Dim ret As New StringBuilder

        Dim enume As IEnumerable(Of MTGCard) = From x As MTGCard In library Select x Order By x.name

        For Each c As MTGCard In enume

            If Not c.island Then ret.AppendLine(c.name)

        Next

        Return ret.ToString
    End Function

    ''' <summary>
    ''' shuffle the library
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub shuffle()

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
