Public Class SummarizeSentenceManager

    Public Property NodeAlteredText() As String
        Get
            Return noteAlteredText
        End Get
        Set(ByVal Value As String)
            noteAlteredText = Value
        End Set
    End Property

    Public Property NodeAlteredTextLength() As Integer
        Get
            Return noteAlteredTextLength
        End Get
        Set(ByVal Value As Integer)
            noteAlteredTextLength = Value
        End Set
    End Property

    Public ReadOnly Property SummarizeSentences As Generic.List(Of SummarizeSentence)
        Get
            Return Sentnces
        End Get
    End Property

    Public ReadOnly Property Sentences As Generic.List(Of SummarizeSentence)
        Get
            Return Sentnces
        End Get
    End Property

    Dim noteWordsNoOf, noteLinesNoOf, noteSentencesNoOf, noteParagraphsNoOf, noteAlteredTextLength As Integer
    Dim noteText, noteAlteredText As String
    Dim noteLines, noteSentences, noteParagrphs, Parms As Generic.List(Of String)
    Dim noteSentenceInParagraph As Generic.List(Of Integer)
    Dim Sentnces As Generic.List(Of SummarizeSentence)
    Dim tempSummarize As SummarizeSentence
    Dim noteParagraphs As Paragraphs

    Sub New()
        Sentnces = New Generic.List(Of SummarizeSentence)
        Dim SummSentences As SummarizeSentence() = New SummarizeSentence() {
            New SummarizeSentence With {.Include = True, .Paragraph = 1, .SentenceNo = 1, .Sentence = "Your code can' consume Microsoft Language Integrated Query (LINQ) queries in several ways. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 1, .SentenceNo = 1, .Sentence = "When writing 'the user interface (UI) code layer, you might want to use a LINQ query to bind data to a UI element. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 1, .SentenceNo = 1, .Sentence = "This process is' called data binding. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 1, .SentenceNo = 1, .Sentence = "In this chapter, you will see how to use a LINQ query for data binding. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 1, .SentenceNo = 1, .Sentence = "One huge 'advantage of data binding with LINQ is that the queries are independent of which LINQ provider processes 'them."},
            New SummarizeSentence With {.Include = True, .Paragraph = 2, .SentenceNo = 1, .Sentence = "Because most of' the sections are independent of each other, you can read just those that apply to you. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 2, .SentenceNo = 1, .Sentence = "However, if you' are interested in WPF or Silverlight, those sections should be read in sequence."},
            New SummarizeSentence With {.Include = True, .Paragraph = 3, .SentenceNo = 1, .Sentence = "ASP.NET has two controls that implement the DataSource control pattern: the LinqDataSource and the EntityDataSource. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 3, .SentenceNo = 1, .Sentence = "Through these controls, you can use a LINQ query to data bind any bindable rendering control using an .aspx declarative approach. "},
            New SummarizeSentence With {.Include = True, .Paragraph = 3, .SentenceNo = 1, .Sentence = "For example, you can use a LinqDataSource or an EntityDataSource control to bind a DataGrid, GridView, Repeater, DataList, or ListView control."}}
        For i = 0 To 9
            tempSummarize = New SummarizeSentence
            tempSummarize.Include = False
            tempSummarize.Paragraph = SummSentences(i).Paragraph + 1
            tempSummarize.SentenceNo = i + 1
            tempSummarize.Sentence = SummSentences(i).Sentence
            Sentnces.Add(tempSummarize)
        Next i
    End Sub

    Sub New(ByRef notetext As String)
        Sentnces = New Generic.List(Of SummarizeSentence)
        noteParagrphs = New Generic.List(Of String)
        noteSentences = New Generic.List(Of String)
        noteSentenceInParagraph = New Generic.List(Of Integer)
        noteLines = New Generic.List(Of String)
        noteParagraphs = New Paragraphs
        noteParagraphs.TheText = notetext
        noteParagraphs.NoOfChars = noteParagraphs.TheText.Length
        noteParagraphs.Sentences(noteSentencesNoOf, noteSentences, noteSentenceInParagraph, 0, False, False, True)
        noteAlteredText = noteParagraphs.TheAlteredText
        noteAlteredTextLength = noteParagraphs.TheAlteredText.Length
        For i = 0 To noteSentencesNoOf - 1
            tempSummarize = New SummarizeSentence
            tempSummarize.Include = False
            tempSummarize.Paragraph = noteSentenceInParagraph(i)
            tempSummarize.SentenceNo = i
            tempSummarize.Sentence = noteSentences(i)
            Sentnces.Add(tempSummarize)
        Next i
    End Sub

End Class

