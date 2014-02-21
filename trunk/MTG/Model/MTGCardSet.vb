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
        Dim ret As New LinkedList(Of MTGCard)(library.Take(num).ToList)
        Return ret
    End Function


    Public Overrides Function ToString() As String
        Dim ret As New StringBuilder


        For Each c As MTGCard In library

            If Not c.island Then ret.AppendLine(c.name)

        Next

        Return ret.ToString
    End Function
End Class
