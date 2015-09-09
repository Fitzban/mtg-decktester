Public Class MTGJson

    ' this map contains all the sets.
    Dim sets As Dictionary(Of String, MagicSetJason)

    ''' <summary>
    ''' this map links the cardname to the sets to which belongs to [cardname, [set1, set2, set3]]
    ''' </summary>
    ''' <remarks></remarks>
    Public fromCardToSet As Dictionary(Of String, ICollection(Of MagicSetJason))

    Public cardnameIndex As Dictionary(Of String, MagicJason)

    Sub New()
        Dim s As New System.IO.StreamReader("..\..\..\Databases\AllSets.json")
        Dim data As String = s.ReadToEnd()
        s.Close()

        sets = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, MagicSetJason))(data)
        ' The stupid data structure doesn't keep a reference to the sets from the card. We have to generate a map then.
        fromCardToSet = New Dictionary(Of String, ICollection(Of MagicSetJason))
        buildCardSetMap()
        buildCardTExtMap()

    End Sub

    ''' <summary>
    ''' The stupid data structure doesn't keep a reference to the sets from the card. We have to generate a map then.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub buildCardSetMap()

        For Each key As String In sets.Keys

            Dim jsonset As MagicSetJason = sets(key)

            For Each jsoncard In jsonset.cards

                If fromCardToSet.Keys.Contains(jsoncard.name) Then
                    fromCardToSet(jsoncard.name).Add(jsonset)
                Else
                    fromCardToSet(jsoncard.name) = New List(Of MagicSetJason)
                    fromCardToSet(jsoncard.name).Add(jsonset)
                End If

            Next

        Next


    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub buildCardTExtMap()

        cardnameIndex = New Dictionary(Of String, MagicJason)
        For Each key As String In sets.Keys

            Dim jsonset As MagicSetJason = sets(key)

            For Each jsoncard In jsonset.cards

                If cardnameIndex.Keys.Contains(jsoncard.name) Then Continue For
                cardnameIndex(jsoncard.name) = jsoncard
                
            Next

        Next

    End Sub
End Class

Public Enum Colors
    White
    Blue
    Black
    Green
    Red
End Enum

Public Class MagicJason
    Public Property name As String
    Public Property manaCost As String
    Public Property cmc As Double

    Public Property colors As Colors()
    Public Property type As String
    Public Property supertypes As String()
    Public Property types As String()
    Public Property subtypes As String()

    Public Property rarity As String
    Public Property text As String

    Public Property flavor As String

    Public Property artist As String
    Public Property number As String

    Public Property power As String
    Public Property toughness As String

    Public Property layout As String
    Public Property multiverseid As Integer
    Public Property imageName As String
End Class

Public Class MagicSetJason
    Public Property name As String
    Public Property code As String
    Public Property gathererCode As String
    Public Property releaseDate As Date
    Public Property border As String
    Public Property type As String
    Public Property block As String
    Public Property cards As MagicJason()
End Class