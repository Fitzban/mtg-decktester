Public Class MTGPlayGround

    Public hand As New LinkedList(Of MTGCard)
    Public cardsingame As New LinkedList(Of MTGCard) ' tha cards in play (land, creatures, enchantments, artifacts, ...)
    Public cemetery As New LinkedList(Of MTGCard)
    Public availablelands As Integer ' the amount of unused mana
    Public grimory As IMTGDeck

End Class
