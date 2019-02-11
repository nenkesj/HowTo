Imports System.Collections.Generic

Public Class Paragraphs
    Inherits Text

    Sub New()
        MyBase.New()
    End Sub

    Public Property NoOfParagraphs() As Integer
        Get
            Return paragraphsNoOf
        End Get
        Set(ByVal Value As Integer)
            paragraphsNoOf = Value
        End Set
    End Property

    Public Property TheAlteredText() As String
        Get
            Return alteredText
        End Get
        Set(ByVal Value As String)
            alteredText = Value
        End Set
    End Property

    Public Property AlteredNoOfParagraphs() As Integer
        Get
            Return paragraphsAlteredNoOf
        End Get
        Set(ByVal Value As Integer)
            paragraphsAlteredNoOf = Value
        End Set
    End Property

    Dim paragraphsNoOf, paragraphsAlteredNoOf, txtPtr, linePtr, _
        paragraphStart, paragraphEnd, paragraphLength As Integer

    Dim txtLetter, paragraph, alteredText, debugText As String

    Dim Txt As Text

    Dim Paragraphs As Generic.List(Of String)

    Public Sub Words(ByRef WordsNoOf As Integer, ByRef Words As SortedList)
        'Subs called:- None
        'Properties Altered:- None
        Dim wordPtr As Integer
        Dim word As String
        Dim wordsDistinct As SortedList
        wordsDistinct = New SortedList
        alteredText = ""
        WordsNoOf = 0
        Me.DivideIntoWords(Me.TheText, WordsNoOf, Words)
        For wordPtr = 0 To Words.Count - 1
            word = Words(wordPtr).ToString
            If wordsDistinct.Contains(word) Then
                wordsDistinct(word) += 1
            Else
                wordsDistinct(word) = 1
            End If
        Next
        alteredText = "There were " & Words.Count & _
                    " words in text with the following frequencies:-" & _
                    Chr(13) & Chr(10) & Chr(13) & Chr(10)
        For wordPtr = 0 To wordsDistinct.Count - 1
            alteredText += wordsDistinct.GetKey(wordPtr) & ": " & wordsDistinct.GetByIndex(wordPtr) & Chr(13) & Chr(10)
        Next
    End Sub

    Public Sub Sentences(ByRef SentencesNoOf As Integer, _
                         ByRef Sentences As Generic.List(Of String), _
                         ByRef SentenceInParagraph As Generic.List(Of Integer), _
                         ByVal LineWidth As Integer, _
                         ByVal Debug As Boolean, _
                         ByVal EliminateWhiteSpace As Boolean, _
                         ByVal SplitOnLF As Boolean)

        'Subs called:- None
        'Properties Altered:- None
        Dim sentencePtr, ParagraphsNoOf, LinesNoOf As Integer
        Dim debugText, SentenceNo, Sentence, Paragraph As String
        Dim Paragraphs, Lines As Generic.List(Of String)
        Paragraphs = New Generic.List(Of String)
        Lines = New Generic.List(Of String)
        SentenceInParagraph = New Generic.List(Of Integer)
        SentencesNoOf = 0
        debugText = ""
        Me.DivideText(ParagraphsNoOf, Paragraphs, SentencesNoOf, Sentences, SentenceInParagraph, LinesNoOf, Lines, debugText, LineWidth, Debug, True, True, False, SplitOnLF)
        alteredText = "There were " & SentencesNoOf.ToString() & _
                    " sentences in text these are:-" & _
                    Chr(13) & Chr(10)
        sentencePtr = 0
        alteredText = "There were " & Sentences.Count & _
            " Sentences in text" & _
            Chr(13) & Chr(10) & Chr(13) & Chr(10)
        For i = 0 To SentencesNoOf - 1
            SentenceNo = i.ToString()
            Sentence = Sentences(i)
            Paragraph = SentenceInParagraph(i)
            alteredText += SentenceNo & " - " & Sentence & Chr(13) & Chr(10) & "This Sentence is in paragraph # " & Paragraph & Chr(13) & Chr(10) & Chr(13) & Chr(10)
        Next i
        If Debug Then
            alteredText += "Debug Text : -" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & debugText & Chr(13) & Chr(10) & Chr(13) & Chr(10)
        End If
    End Sub

    Public Sub Paragrphs(ByRef ParagraphsNoOf As Integer, _
                         ByRef Paragraphs As Generic.List(Of String), _
                         ByRef SentencesNoOf As Integer, _
                         ByRef Sentences As Generic.List(Of String), _
                         ByRef SentenceInParagraph As Generic.List(Of Integer), _
                         ByRef LinesNoOf As Integer, _
                         ByRef Lines As Generic.List(Of String), _
                         ByVal LineWidth As Integer, _
                         ByVal Debug As Boolean, _
                         ByVal EliminateWhiteSpace As Boolean, _
                         ByVal SplitHeaders As Boolean, _
                         ByVal SplitOnColon As Boolean, _
                         ByVal SplitOnLF As Boolean)
        'Subs called:- None
        'Properties Altered:- None
        Dim paragraphPtr, sentencePtr, linePtr As Integer
        Dim debugText As String
        linePtr = 0
        sentencePtr = 0
        paragraphPtr = 0
        ParagraphsNoOf = 0
        SentencesNoOf = 0
        LinesNoOf = 0
        debugText = ""
        Me.DivideText(ParagraphsNoOf, Paragraphs, SentencesNoOf, Sentences, SentenceInParagraph, LinesNoOf, Lines, debugText, _
                      LineWidth, Debug, EliminateWhiteSpace, SplitHeaders, SplitOnColon, SplitOnLF)
        ' alteredText = "There were " & Paragraphs.Count & _
        '             " paragraphs in text these are:-" & _
        '             Chr(13) & Chr(10) & Chr(13) & Chr(10)
        If Debug Then
            alteredText += "There were " & Paragraphs.Count & _
            " Paragraphs in text" & _
            Chr(13) & Chr(10) & Chr(13) & Chr(10)
        End If
        For Each paragraph As String In Paragraphs
            paragraphPtr += 1
            If Debug Then
                alteredText += paragraphPtr.ToString() & " - " & paragraph.ToString() & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            Else
                alteredText += paragraph.ToString() & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            End If
        Next
        If Debug Then
            alteredText += "Debug Text : -" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & debugText & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            alteredText += "There were " & Sentences.Count & _
            " Sentences in text" & _
            Chr(13) & Chr(10) & Chr(13) & Chr(10)
            For Each sentence As String In Sentences
                sentencePtr += 1
                alteredText += sentencePtr.ToString() & " - " & sentence.ToString() & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            Next
        End If
        If Debug Then
            alteredText += "There were " & Lines.Count & _
            " Lines in text" & _
            Chr(13) & Chr(10) & Chr(13) & Chr(10)
            For Each line As String In Lines
                linePtr += 1
                alteredText += linePtr.ToString() & " - " & line.ToString() & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            Next
        End If
    End Sub

End Class


