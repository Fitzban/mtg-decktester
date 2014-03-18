﻿Public Class MTGCardsDatabase

    Public cards As New MTGCardSet

    Sub New()
        loadCards()
    End Sub

    Private Sub loadCards()

        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Flamebreak", 3, 3))

        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))

        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))

        cards.Add(New MTGCard("Gut Shot", 1, 0))
        cards.Add(New MTGCard("Gut Shot", 1, 0))
        cards.Add(New MTGCard("Gut Shot", 1, 0))
        cards.Add(New MTGCard("Gut Shot", 1, 0))

        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Incinerate", 3, 2))

        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Lava Spike", 3, 1))

        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))

        cards.Add(New MTGCard("Lightning Strike", 3, 2))
        cards.Add(New MTGCard("Lightning Strike", 3, 2))
        cards.Add(New MTGCard("Lightning Strike", 3, 2))
        cards.Add(New MTGCard("Lightning Strike", 3, 2))

        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))

        cards.Add(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))
        cards.Add(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))
        cards.Add(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))
        cards.Add(New MTGCard("Shard Volley", 3, 1, False, New MTGDestroyYourLandEffect(1)))

        cards.Add(New MTGCard("Searing Spear", 3, 2))
        cards.Add(New MTGCard("Searing Spear", 3, 2))
        cards.Add(New MTGCard("Searing Spear", 3, 2))
        cards.Add(New MTGCard("Searing Spear", 3, 2))

        cards.Add(New MTGCard("Skullcrack", 3, 2))
        cards.Add(New MTGCard("Skullcrack", 3, 2))
        cards.Add(New MTGCard("Skullcrack", 3, 2))
        cards.Add(New MTGCard("Skullcrack", 3, 2))

        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))

        cards.Add(New MTGCard("Thunderbolt", 3, 2))
        cards.Add(New MTGCard("Thunderbolt", 3, 2))
        cards.Add(New MTGCard("Thunderbolt", 3, 2))
        cards.Add(New MTGCard("Thunderbolt", 3, 2))

        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
    End Sub


    Private Sub addClassicCards()

        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Firebolt", 2, 1))

        cards.Add(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))
        cards.Add(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))
        cards.Add(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))
        cards.Add(New MTGCard("Kindle", 2, 2, False, New MTGKindleEffect))

        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
    End Sub

End Class
