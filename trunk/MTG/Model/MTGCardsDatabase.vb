Public Class MTGCardsDatabase

    Public cards As New LinkedList(Of MTGCard)

    Sub New()
        loadCards()
    End Sub

    Private Sub loadCards()

        cards.AddLast(New MTGCard("Flamebreak", 3, 3))
        cards.AddLast(New MTGCard("Flamebreak", 3, 3))
        cards.AddLast(New MTGCard("Flamebreak", 3, 3))
        cards.AddLast(New MTGCard("Flamebreak", 3, 3))

        cards.AddLast(New MTGCard("Burst Lightning", 2, 1))
        cards.AddLast(New MTGCard("Burst Lightning", 2, 1))
        cards.AddLast(New MTGCard("Burst Lightning", 2, 1))
        cards.AddLast(New MTGCard("Burst Lightning", 2, 1))

        cards.AddLast(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.AddLast(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.AddLast(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.AddLast(New MTGCard("Flames of the Blood Hand", 4, 3))

        cards.AddLast(New MTGCard("Gut Shot", 1, 0))
        cards.AddLast(New MTGCard("Gut Shot", 1, 0))
        cards.AddLast(New MTGCard("Gut Shot", 1, 0))
        cards.AddLast(New MTGCard("Gut Shot", 1, 0))

        cards.AddLast(New MTGCard("Incinerate", 3, 2))
        cards.AddLast(New MTGCard("Incinerate", 3, 2))
        cards.AddLast(New MTGCard("Incinerate", 3, 2))
        cards.AddLast(New MTGCard("Incinerate", 3, 2))

        cards.AddLast(New MTGCard("Lava Spike", 3, 1))
        cards.AddLast(New MTGCard("Lava Spike", 3, 1))
        cards.AddLast(New MTGCard("Lava Spike", 3, 1))
        cards.AddLast(New MTGCard("Lava Spike", 3, 1))

        cards.AddLast(New MTGCard("Lightning Bolt", 3, 1))
        cards.AddLast(New MTGCard("Lightning Bolt", 3, 1))
        cards.AddLast(New MTGCard("Lightning Bolt", 3, 1))
        cards.AddLast(New MTGCard("Lightning Bolt", 3, 1))

        cards.AddLast(New MTGCard("Lightning Strike", 3, 2))
        cards.AddLast(New MTGCard("Lightning Strike", 3, 2))
        cards.AddLast(New MTGCard("Lightning Strike", 3, 2))
        cards.AddLast(New MTGCard("Lightning Strike", 3, 2))

        cards.AddLast(New MTGCard("Magma Jet", 2, 2))
        cards.AddLast(New MTGCard("Magma Jet", 2, 2))
        cards.AddLast(New MTGCard("Magma Jet", 2, 2))
        cards.AddLast(New MTGCard("Magma Jet", 2, 2))

        cards.AddLast(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))
        cards.AddLast(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))
        cards.AddLast(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))
        cards.AddLast(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))

        cards.AddLast(New MTGCard("Searing Spear", 3, 2))
        cards.AddLast(New MTGCard("Searing Spear", 3, 2))
        cards.AddLast(New MTGCard("Searing Spear", 3, 2))
        cards.AddLast(New MTGCard("Searing Spear", 3, 2))

        cards.AddLast(New MTGCard("Skullcrack", 3, 2))
        cards.AddLast(New MTGCard("Skullcrack", 3, 2))
        cards.AddLast(New MTGCard("Skullcrack", 3, 2))
        cards.AddLast(New MTGCard("Skullcrack", 3, 2))

        cards.AddLast(New MTGCard("Rift Bolt", 3, 1))
        cards.AddLast(New MTGCard("Rift Bolt", 3, 1))
        cards.AddLast(New MTGCard("Rift Bolt", 3, 1))
        cards.AddLast(New MTGCard("Rift Bolt", 3, 1))

        cards.AddLast(New MTGCard("Thunderbolt", 3, 2))
        cards.AddLast(New MTGCard("Thunderbolt", 3, 2))
        cards.AddLast(New MTGCard("Thunderbolt", 3, 2))
        cards.AddLast(New MTGCard("Thunderbolt", 3, 2))

        cards.AddLast(New MTGCard("Volcanic Fallout", 3, 2))
        cards.AddLast(New MTGCard("Volcanic Fallout", 3, 2))
        cards.AddLast(New MTGCard("Volcanic Fallout", 3, 2))
        cards.AddLast(New MTGCard("Volcanic Fallout", 3, 2))
    End Sub


    Private Sub addClassicCards()

        cards.AddLast(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.AddLast(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.AddLast(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.AddLast(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.AddLast(New MTGCard("Chain of Plasma", 3, 2))
        cards.AddLast(New MTGCard("Chain of Plasma", 3, 2))
        cards.AddLast(New MTGCard("Chain of Plasma", 3, 2))
        cards.AddLast(New MTGCard("Chain of Plasma", 3, 2))
        cards.AddLast(New MTGCard("Price of Progress", 2, 2))
        cards.AddLast(New MTGCard("Price of Progress", 2, 2))
        cards.AddLast(New MTGCard("Price of Progress", 2, 2))
        cards.AddLast(New MTGCard("Price of Progress", 2, 2))
        cards.AddLast(New MTGCard("Chain Lightning", 3, 1))
        cards.AddLast(New MTGCard("Chain Lightning", 3, 1))
        cards.AddLast(New MTGCard("Chain Lightning", 3, 1))
        cards.AddLast(New MTGCard("Chain Lightning", 3, 1))
        cards.AddLast(New MTGCard("Barbarian Ring", 2, 1))
        cards.AddLast(New MTGCard("Barbarian Ring", 2, 1))
        cards.AddLast(New MTGCard("Barbarian Ring", 2, 1))
        cards.AddLast(New MTGCard("Barbarian Ring", 2, 1))
        cards.AddLast(New MTGCard("Fireblast", 4, 2))
        cards.AddLast(New MTGCard("Fireblast", 4, 2))
        cards.AddLast(New MTGCard("Fireblast", 4, 2))
        cards.AddLast(New MTGCard("Fireblast", 4, 2))
        cards.AddLast(New MTGCard("Firebolt", 2, 1))
        cards.AddLast(New MTGCard("Firebolt", 2, 1))
        cards.AddLast(New MTGCard("Firebolt", 2, 1))
        cards.AddLast(New MTGCard("Firebolt", 2, 1))

        cards.AddLast(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))
        cards.AddLast(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))
        cards.AddLast(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))
        cards.AddLast(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))

        cards.AddLast(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.AddLast(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.AddLast(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.AddLast(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.AddLast(New MTGCard("Flame Rift", 4, 2))
        cards.AddLast(New MTGCard("Flame Rift", 4, 2))
        cards.AddLast(New MTGCard("Flame Rift", 4, 2))
        cards.AddLast(New MTGCard("Flame Rift", 4, 2))
    End Sub

End Class
