﻿Public Class MTGCard

    Public _name, _price, _rarity As String
    Public damage, converted_cost, cardnumber, idProduct As Integer
    Public island As Boolean
    Public max_available As Integer = 4
    Private _effect As IMTGCardEffect

    Public Property rarity As String
        Get
            Return _rarity
        End Get
        Set(value As String)
            _rarity = value
        End Set
    End Property
    Public Property price As String
        Get
            Return _price
        End Get
        Set(value As String)
            _price = value
        End Set
    End Property
    Public Property name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    ReadOnly Property rateo As Double
        Get
            If island Then Return 0
            Return (damage / (converted_cost * 1.5 + 1))
        End Get
    End Property

    Sub New(pname As String, pcardnumber As Integer)
        name = pname
        cardnumber = pcardnumber
    End Sub

    Sub New(pname As String, pdamage As Integer, pconverted_cost As Integer, Optional pisland As Boolean = False, Optional effect As IMTGCardEffect = Nothing)
        name = pname
        damage = pdamage
        converted_cost = pconverted_cost
        island = pisland
    End Sub

    ''' <summary>
    ''' this is called to let the card implements its effects on the playgroud.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub play(playground As MTGPlayGround)

        If _effect Is Nothing Then Exit Sub
        _effect.applyOn(playground)

    End Sub

End Class
