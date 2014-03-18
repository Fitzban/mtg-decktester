Imports System.Text

Public Class MTGTurn
    Implements IMTGTurn

    Public pturnnumber As Integer = 0
    Public totaldamage As Integer = 0
    Public damagedone As Integer = 0
    Public damages_received As Integer = 0
    Protected lost As Boolean = False
    Public playground As New MTGPlayGround
    Public played As New LinkedList(Of MTGCard)
    Private actions As New StringBuilder

    Sub New()

    End Sub

    Sub New(phand As LinkedList(Of MTGCard), mgroud As LinkedList(Of MTGCard), pc As LinkedList(Of MTGCard), _
            mdeck As IMTGDeck, mturnnumber As Integer, totaldamagedone As Integer)
        For Each c As MTGCard In phand
            playground.hand.AddLast(c)
        Next

        For Each c As MTGCard In mgroud
            playground.cardsingame.AddLast(c)
        Next

        playground.availablelands = (From x As MTGCard In playground.cardsingame Select x Where x.island).Count

        For Each c As MTGCard In pc
            playground.cemetery.AddLast(c)
        Next

        playground.grimory = mdeck
        pturnnumber = mturnnumber
        actions.AppendLine("turn #: " + pturnnumber.ToString)
    End Sub

    Private _drawn As MTGCard
    Public Sub draw() Implements IMTGTurn.draw
        _drawn = playground.grimory.draw
        If _drawn Is Nothing Then Exit Sub
        playground.hand.AddLast(_drawn)
        playground.grimory.remove(_drawn)
        actions.AppendLine("drawn : " + _drawn.name)
        actions.AppendLine("hand  : " + handtostring(playground.hand))

    End Sub

    Public Sub playland() Implements IMTGTurn.playland
        Dim land As MTGCard = (From x As MTGCard In playground.hand Select x Where x.island).FirstOrDefault
        If land Is Nothing Then Exit Sub
        playground.cardsingame.AddLast(land)
        playground.hand.Remove(land)
        played.AddLast(land)
        playground.availablelands += 1
        actions.AppendLine("lands#: " + playground.availablelands.ToString)

    End Sub

    ReadOnly Property nextcardtoplay As MTGCard Implements IMTGTurn.nextcardtoplay
        Get
            Return (From x As MTGCard In playground.hand Select x Where Not x.island Order By x.rateo Descending).FirstOrDefault
        End Get
    End Property

    Public Sub play(card As MTGCard) Implements IMTGTurn.play

        playground.hand.Remove(card)
        playground.cemetery.AddLast(card)
        played.AddLast(card)
        card.play(playground)
        damagedone += card.damage
        playground.availablelands -= card.converted_cost

    End Sub

    Public Overrides Function ToString() As String

        If pturnnumber = 0 Then Return handtostring(playground.hand)

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

    Public ReadOnly Property turnnumber1 As Integer Implements IMTGTurn.turnnumber
        Get
            Return pturnnumber
        End Get
    End Property

    Public ReadOnly Property damagedone1 As Integer Implements IMTGTurn.damagedone
        Get
            Return damagedone
        End Get
    End Property

    Public ReadOnly Property deck As IMTGDeck Implements IMTGTurn.deck
        Get
            Return playground.grimory
        End Get
    End Property

    Public ReadOnly Property playground1 As MTGPlayGround Implements IMTGTurn.playground
        Get
            Return playground
        End Get
    End Property

    Public ReadOnly Property totaldamage1 As Integer Implements IMTGTurn.totaldamage
        Get
            Return totaldamage
        End Get
    End Property

    Public ReadOnly Property lost1 As Boolean Implements IMTGTurn.lost
        Get
            Return Me.lost
        End Get
    End Property
End Class
