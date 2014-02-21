Public Class MTGCard

    Public name As String
    Public damage, converted_cost As Integer
    Public island As Boolean

    ReadOnly Property rateo As Double
        Get
            If island Then Return 0
            If converted_cost = 0 And damage > 0 Then Return Double.MaxValue
            Return damage / converted_cost
        End Get
    End Property

    Sub New(pname As String, pdamage As Integer, pconverted_cost As Integer, Optional pisland As Boolean = False)
        name = pname
        damage = pdamage
        converted_cost = pconverted_cost
        island = pisland
    End Sub

End Class
