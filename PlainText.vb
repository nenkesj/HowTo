Public Class PlainText
    Inherits Text

    Sub New()
        MyBase.New()
    End Sub

    Public Property TheAlteredText() As String
        Get
            Return alteredText
        End Get
        Set(ByVal Value As String)
            alteredText = Value
        End Set
    End Property

    Dim txtPtr As Integer

    Dim txtLetter, oldText, alteredText As String

    Dim Txt As Text


    Public Sub QuickClean()
        Dim Tab As Char

        '
        ' First up")." is the preferred end of a sentence not ".)" etc
        '
        Me.TheAlteredText = Me.TheText
        Me.TheAlteredText.Replace(".)", ").")
        Me.TheAlteredText.Replace("?)", ")?")
        Me.TheAlteredText.Replace("!)", ")!")
        Me.TheAlteredText.Replace(".}", "}.")
        Me.TheAlteredText.Replace("?}", "}?")
        Me.TheAlteredText.Replace("!}", "}!")
        Me.TheAlteredText.Replace(".]", "].")
        Me.TheAlteredText.Replace("?]", "]?")
        Me.TheAlteredText.Replace("!]", "]!")
        '
        ' Replace Tabs with spaces
        '
        Tab = Chr(9)
        Me.TheAlteredText.Replace(Tab, " ")
    End Sub

End Class


