﻿Public Class MTGCard

    Public name As String
    Public damage, converted_cost As Integer
    Public island As Boolean
    Public max_available As Integer = 4
    Private _effect As IMTGCardEffect

    ReadOnly Property rateo As Double
        Get
            If island Then Return 0
            Return (damage / (converted_cost * 1.5 + 1))
        End Get
    End Property

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
