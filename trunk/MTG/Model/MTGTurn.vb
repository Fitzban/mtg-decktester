Imports System.Text

Public Class MTGTurn
    Implements IMTGTurn

    Public turnnumber As Integer = 0
    Public totaldamage As Integer = 0
    Public damagedone As Integer = 0
    Public damages_received As Integer = 0
    Public hand As New LinkedList(Of MTGCard)
    Public playground As New LinkedList(Of MTGCard)
    Public cemetery As New LinkedList(Of MTGCard)
    Public played As New LinkedList(Of MTGCard)
    Public deck As IMTGDeck
    Public availablelands As Integer
    Private actions As New StringBuilder

    Sub New()

    End Sub

    Sub New(phand As LinkedList(Of MTGCard), mgroud As LinkedList(Of MTGCard), pc As LinkedList(Of MTGCard), _
            mdeck As IMTGDeck, mturnnumber As Integer, totaldamagedone As Integer)
        For Each c As MTGCard In phand
            hand.AddLast(c)
        Next

        For Each c As MTGCard In mgroud
            playground.AddLast(c)
        Next

        availablelands = (From x As MTGCard In playground Select x Where x.island).Count

        For Each c As MTGCard In pc
            cemetery.AddLast(c)
        Next

        deck = mdeck
        turnnumber = mturnnumber
        actions.AppendLine("turn #: " + turnnumber.ToString)
    End Sub

    Private _drawn As MTGCard
    Public Sub draw() Implements IMTGTurn.draw
        _drawn = deck.draw
        If _drawn Is Nothing Then Exit Sub
        hand.AddLast(_drawn)
        deck.remove(_drawn)
        actions.AppendLine("drawn : " + _drawn.name)
        actions.AppendLine("hand  : " + handtostring(hand))

    End Sub

    Public Sub playland() Implements IMTGTurn.playland
        Dim land As MTGCard = (From x As MTGCard In hand Select x Where x.island).FirstOrDefault
        If land Is Nothing Then Exit Sub
        playground.AddLast(land)
        hand.Remove(land)
        played.AddLast(land)
        availablelands += 1
        actions.AppendLine("lands#: " + availablelands.ToString)

    End Sub

    ReadOnly Property nextcardtoplay As MTGCard Implements IMTGTurn.nextcardtoplay
        Get
            Return (From x As MTGCard In hand Select x Where Not x.island Order By x.rateo Descending).FirstOrDefault
        End Get
    End Property

    Public Sub play(card As MTGCard) Implements IMTGTurn.play

        hand.Remove(card)
        cemetery.AddLast(card)
        played.AddLast(card)
        damagedone += card.damage
        availablelands -= card.converted_cost

    End Sub

    Public Overrides Function ToString() As String

        If turnnumber = 0 Then Return handtostring(hand)

        actions.AppendLine("played: " + playedtostring())
        actions.AppendLine("damage: " + damagedone.ToString)

        Return actions.ToString
    End Function

    ''' <summary>
    ''' string representation for the hand
    ''' </summary>
    ''' <param name="hand"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function handtostring(hand As LinkedList(Of MTGCard)) As String

        Dim ret As New StringBuilder

        For Each c As MTGCard In hand
            ret.Append(c.name)
            ret.Append(",")
        Next

        Return ret.ToString

    End Function

    Private Function playedtostring() As String
        Dim ret As New StringBuilder

        For Each c As MTGCard In played
            ret.Append(c.name)
            ret.Append(","c)
        Next

        Return ret.ToString
    End Function
End Class
