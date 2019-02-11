Imports System
Imports System.Collections.Generic

Public Class Text

    Dim txtNoOfChars, txtAlteredNoOfChars As Integer

    Dim txtLetter, txtText, txtAlteredText, txtSearch As String

    Sub New()
        txtNoOfChars = 0
        txtAlteredNoOfChars = 0
    End Sub

    Public Property TheText() As String
        Get
            Return txtText
        End Get
        Set(ByVal Value As String)
            txtText = Value
        End Set
    End Property

    Public Property SearchText() As String
        Get
            Return txtSearch
        End Get
        Set(ByVal Value As String)
            txtSearch = Value
        End Set
    End Property

    Public Property NoOfChars() As Integer
        Get
            Return txtNoOfChars
        End Get
        Set(ByVal Value As Integer)
            txtNoOfChars = Value
        End Set
    End Property

    Public Function AnySpaces(ByVal txt As String) As Boolean
        'Any Spaces in the sting True or False?
        Dim Any As Boolean
        Dim txtPtr As Integer
        Any = False
        txtPtr = 0
        Do Until txtPtr >= txt.Length - 1 Or Any = True
            If txt.Substring(txtPtr, 1) = " " Then
                Any = True
            End If
            txtPtr += 1
        Loop
        Return Any
    End Function

    Public Function AllBlanks(ByVal txt As String) As Boolean
        'Is the string all blank True or False?
        Dim AllBlank As Boolean
        Dim txtPtr As Integer
        AllBlank = True
        txtPtr = 0
        Do Until txtPtr >= txt.Length - 1 Or AllBlank = False
            If txt.Substring(txtPtr, 1) > Chr(32) Then
                AllBlank = False
            End If
            txtPtr += 1
        Loop
        Return AllBlank
    End Function

    Public Function WheresNextEndOfLine(ByVal txt As String) As Integer
        ' Note: CHAR(10) is the character represented by ASCII code 10, which is a Line Feed (\n) so its a new line. 
        ' (Although its not the windows standard new line which is Carriage Return + Line Feed CHAR(13)+CHAR(10) )
        ' So this returns an integer pointer to the Line Feed Character or -1 if it doesnt exist
        Dim ptrChr10 As Integer
        Dim txtPtr As Integer
        ptrChr10 = -1
        txtPtr = 0
        Do Until txtPtr >= txt.Length - 1 Or ptrChr10 <> -1
            If txt.Substring(txtPtr, 1) = Chr(10) Then
                ptrChr10 = txtPtr
            End If
            txtPtr += 1
        Loop
        If txtPtr >= txt.Length - 1 Then
            ptrChr10 = txt.Length - 1
        End If
        Return ptrChr10
    End Function

    Public Sub AnalyseWord(ByRef txt As String, _
                           ByRef WordEndsWithDelimiter As Boolean, _
                           ByRef WordEndsWithFullStop As Boolean, _
                           ByRef WordIsAInteger As Boolean, _
                           ByRef WordIsAHexNumber As Boolean, _
                           ByRef WordAllCapitals As Boolean)
        'Determines if the string has the above qualities i.e. ends in delimiter or full stop etc.
        Dim charPtr, charsToCheck, wordLength As Integer
        Dim ptrChar, lastChar As Char
        WordEndsWithDelimiter = False
        WordEndsWithFullStop = False
        WordIsAInteger = False
        WordIsAHexNumber = False
        WordAllCapitals = False
        wordLength = txt.Length
        If wordLength > 1 Then
            lastChar = txt.Substring(wordLength - 1, 1)
            If lastChar = "." Or lastChar = ":" Or lastChar = ";" Or lastChar = "-" Then
                WordEndsWithDelimiter = True
                If lastChar = "." Then
                    WordEndsWithFullStop = True
                End If
            End If
        End If
        If wordLength > 0 Then
            If WordEndsWithDelimiter Then
                charsToCheck = wordLength - 1
            Else
                charsToCheck = wordLength
            End If
            WordIsAInteger = True
            WordIsAHexNumber = True
            WordAllCapitals = True
            charPtr = 0
            Do Until charPtr > charsToCheck - 1
                ptrChar = txt.Substring(charPtr, 1)
                If Not (ptrChar >= "0" And ptrChar <= "9") Then
                    WordIsAInteger = False
                End If
                If Not (ptrChar >= "0" And ptrChar <= "9") And _
                   Not (ptrChar >= "A" And ptrChar <= "F") Then
                    WordIsAHexNumber = False
                End If
                If ptrChar < "A" Or ptrChar > "Z" Then
                    WordAllCapitals = False
                End If
                charPtr += 1
            Loop
        End If
    End Sub

    Public Sub AnalyseFirstWord(ByRef txt As String, _
                                ByRef FirstWordPtr As Integer, _
                                ByRef SecondWordPtr As Integer, _
                                ByRef FirstWordLength As Integer, _
                                ByRef FirstWordAllCapitals As Boolean, _
                                ByRef FirstWordHasDelimiter As Boolean)
        Dim charPtr As Integer
        Dim ptrChar As Char
        Dim atFirstWord, atSecondWord, nothingYet As Boolean
        FirstWordLength = 0
        FirstWordPtr = 0
        SecondWordPtr = 0
        charPtr = 0
        FirstWordHasDelimiter = False
        FirstWordAllCapitals = False
        If txt.Length > 0 Then
            ptrChar = txt.Substring(charPtr, 1)
            atFirstWord = False
            atSecondWord = False
            nothingYet = True
            Do Until atSecondWord Or charPtr > txt.Length - 1
                ' Everything less than Chr(32) i.e. a space is a non printable character e.g. null or esc
                ' that is we've reached the end of the 1st word
                ' if atFirstWork is false these characters are before the 1st word so skip them
                If atFirstWord Then
                    If ptrChar <= Chr(32) Then
                        atFirstWord = False
                        FirstWordLength = FirstWordLength
                    End If
                End If
                ' GT Chr(32) is all the printable characters weve arrived at the first word
                If nothingYet And ptrChar > Chr(32) Then
                    FirstWordAllCapitals = True
                    atFirstWord = True
                    nothingYet = False
                    FirstWordPtr = charPtr
                End If
                If ptrChar = ":" And atFirstWord Then
                    FirstWordHasDelimiter = True
                End If
                If ptrChar = "-" And atFirstWord Then
                    ' If this isnt the last character in the string
                    If charPtr < txt.Length - 2 Then
                        ' And the next character is a space
                        If txt.Substring(charPtr + 1, 1) = " " Then
                            ' Treat the - as a delimiter
                            FirstWordHasDelimiter = True
                        End If
                    End If
                End If
                If atFirstWord And _
                   (txt.Substring(charPtr, 1) < "A" Or txt.Substring(charPtr, 1) > "Z") Then
                    FirstWordAllCapitals = False
                End If
                ' What if there are chars that are < Chr(32) preceding the 1st word
                If Not atFirstWord And _
                   Not nothingYet And _
                   txt.Substring(charPtr, 1) > Chr(32) And _
                   txt.Substring(charPtr, 1) <> ":" And _
                   txt.Substring(charPtr, 1) <> "-" Then
                    atSecondWord = True
                    SecondWordPtr = charPtr
                Else
                    charPtr += 1
                    If charPtr <= txt.Length - 1 Then
                        ptrChar = txt.Substring(charPtr, 1)
                        If atFirstWord Then
                            FirstWordLength += 1
                        End If
                    End If
                End If
            Loop
        End If
    End Sub

    Public Sub AnalyseLastWord(ByRef txt As String, _
                                ByRef LastWordPtr As Integer, _
                                ByRef LastWordLength As Integer, _
                                ByRef LastWordHasDelimiter As Boolean, _
                                ByRef LastWordIsAInteger As Boolean, _
                                ByRef LastWordIsAHexNumber As Boolean)
        Dim charPtr As Integer
        Dim ptrChar As Char
        Dim atLastWord, beforeLastWord, nothingYet As Boolean
        LastWordLength = 0
        LastWordPtr = 0
        LastWordHasDelimiter = False
        LastWordIsAInteger = False
        LastWordIsAHexNumber = False
        charPtr = txt.Length - 1
        If txt.Length > 0 Then
            ptrChar = txt.Substring(charPtr, 1)
            atLastWord = False
            beforeLastWord = False
            nothingYet = True
            LastWordHasDelimiter = False
            Do Until beforeLastWord Or charPtr < 0
                If ptrChar <= Chr(32) Then
                    If atLastWord Then
                        atLastWord = False
                        beforeLastWord = True
                        LastWordPtr = charPtr + 1
                        LastWordLength = LastWordLength - 1
                    End If
                Else
                    If nothingYet Then
                        If ptrChar = ":" Or ptrChar = "-" Then
                            LastWordHasDelimiter = True
                        Else
                            LastWordIsAInteger = True
                            LastWordIsAHexNumber = True
                            atLastWord = True
                            nothingYet = False
                        End If
                    End If
                    If atLastWord Then
                        LastWordLength += 1
                        If Not (ptrChar >= "0" And ptrChar <= "9") Then
                            LastWordIsAInteger = False
                        End If
                        If Not (ptrChar >= "0" And ptrChar <= "9") And _
                           Not (ptrChar >= "A" And ptrChar <= "F") Then
                            LastWordIsAHexNumber = False
                        End If
                    End If
                End If
                If Not beforeLastWord Then
                    charPtr -= 1
                    If charPtr >= 0 Then
                        ptrChar = txt.Substring(charPtr, 1)
                    End If
                End If
            Loop
        End If
    End Sub

    Public Sub IncludeSegments(ByVal SegmentsNoOf As Integer, ByRef SegmentsAlteredNoOf As Integer, _
                            ByVal MatchText As String, _
                            ByRef Segments As Generic.List(Of String), ByRef AlteredText As String)
        Dim segPtr As Integer
        Dim seg As String
        AlteredText = ""
        SegmentsAlteredNoOf = 0
        For segPtr = 0 To SegmentsNoOf - 1
            seg = Segments(segPtr)
            If seg.Length >= MatchText.Length Then
                If seg.IndexOf(MatchText) >= 0 Then
                    AlteredText += seg
                    SegmentsAlteredNoOf += 1
                End If
            End If
        Next
    End Sub

    Public Sub ExcludeSegments(ByVal SegmentsNoOf As Integer, ByRef SegmentsAlteredNoOf As Integer, _
                            ByVal MatchText As String, _
                            ByRef Segments As Generic.List(Of String), ByRef AlteredText As String)
        Dim segPtr As Integer
        Dim seg As String
        AlteredText = ""
        SegmentsAlteredNoOf = 0
        For segPtr = 0 To SegmentsNoOf - 1
            seg = Segments(segPtr)
            If seg.Length >= MatchText.Length Then
                If seg.IndexOf(MatchText) < 0 Then
                    AlteredText += seg
                    SegmentsAlteredNoOf += 1
                End If
            End If
        Next
    End Sub

    Public Sub DivideAfterChar(ByVal Divider As Char, ByRef SegmentsNoOf As Integer, _
                                  ByRef Segments As Generic.List(Of String))
        ' This divides the text into Segments at he defined by a single character divider
        ' Segments appear to include the divider at the end of the segment
        Dim txtPtr, noOfChars, segStart, segLength As Integer
        Dim theText As String
        Dim txtLetter As Char
        theText = Me.TheText
        noOfChars = Me.TheText.Length
        segStart = 0
        SegmentsNoOf = 0
        For txtPtr = 0 To noOfChars - 1
            txtLetter = theText.Substring(txtPtr, 1)
            If txtLetter = Divider Then
                SegmentsNoOf += 1
                segLength = txtPtr - segStart + 1
                Segments.Add(theText.Substring(segStart, segLength))
                segStart = txtPtr + 1
            End If
        Next
        ' Final Segment
        If txtLetter <> Divider Then
            SegmentsNoOf += 1
            segLength = txtPtr - segStart
            Segments.Add(theText.Substring(segStart, segLength))
            segStart = txtPtr + 1
        End If
    End Sub

    Public Sub DivideByFieldWithNoSpaces(ByVal DividerStart As Integer, _
                                         ByVal DividerLength As Integer, _
                                         ByRef LinesNoOf As Integer, _
                                         ByRef SegmentsNoOf As Integer, _
                                         ByRef Segments As Generic.List(Of String))
        ' Seems to create segments where segments are continuously concatenated lines until a line has no spaces in the
        ' divider area in which case a new segment is started!! What is this used for??
        Dim linePtr, noOfChars As Integer
        Dim theText, fldTime As String
        Dim Lines As Generic.List(Of String)
        Lines = New Generic.List(Of String)
        noOfChars = Me.NoOfChars
        theText = Me.TheText
        ' First up divide text into lines
        LinesNoOf = 0
        ' Chr(10) is the line feed character which is the last character on every line
        DivideAfterChar(Chr(10), LinesNoOf, Lines)
        SegmentsNoOf = 0
        For Each line As String In Lines
            If line.Length >= DividerLength Then
                fldTime = line.Substring(DividerStart, DividerLength)
                If AnySpaces(fldTime) Then
                    Segments(SegmentsNoOf) += line
                Else
                    SegmentsNoOf += 1
                    Segments(SegmentsNoOf) = line
                End If
            End If
        Next
    End Sub

    Public Sub DivideIntoWords(ByRef txtText As String, ByRef WordsNoOf As Integer, _
                               ByRef Words As SortedList)
        Dim txtPtr, noOfChars, wordStart, wordLength As Integer
        Dim currChar, lastChar As Char
        noOfChars = txtText.Length
        wordStart = 0
        wordLength = 0
        WordsNoOf = 0
        lastChar = " "
        For txtPtr = 0 To noOfChars - 1
            currChar = txtText.Substring(txtPtr, 1)
            ' if the current char isnt alphabetic or numeric but the last char is weve reached
            ' the end of the word
            If Not ((currChar >= "a" And currChar <= "z") Or _
                    (currChar >= "A" And currChar <= "Z") Or _
                    (currChar >= "0" And currChar <= "9") Or _
                    (currChar = "'" Or currChar = "-" Or currChar = "/" Or currChar = "’")) And _
                   ((lastChar >= "a" And lastChar <= "z") Or _
                    (lastChar >= "A" And lastChar <= "Z") Or _
                    (lastChar >= "0" And lastChar <= "9")) Then
                WordsNoOf += 1
                wordLength = txtPtr - wordStart
                Words(WordsNoOf - 1) = txtText.Substring(wordStart, wordLength).ToLower
            End If
            If ((currChar >= "a" And currChar <= "z") Or _
                (currChar >= "A" And currChar <= "Z") Or _
                (currChar >= "0" And currChar <= "9")) And _
                (Not ((lastChar >= "a" And lastChar <= "z") Or _
                      (lastChar >= "A" And lastChar <= "Z") Or _
                      (lastChar >= "0" And lastChar <= "9") Or _
                      (lastChar = "'" Or lastChar = "-" Or lastChar = "/" Or lastChar = "’"))) Then
                wordStart = txtPtr
            End If
            lastChar = currChar
        Next
        If (lastChar >= "a" And lastChar <= "z") Or _
           (lastChar >= "A" And lastChar <= "Z") Or _
           (lastChar >= "0" And lastChar <= "9") Then
            WordsNoOf += 1
            wordLength = txtPtr - wordStart
            Words(WordsNoOf - 1) = txtText.Substring(wordStart, wordLength).ToLower
        End If
    End Sub

    Public Sub StartNewParagraph(ByRef ParagraphsNoOf As Integer, ByRef Paragraphs As Generic.List(Of String), _
                    ByRef sentence As String, ByRef paragraph As String, ByRef currChar As Char, ByRef ParagraphLength As Integer, _
                    ByRef Debug As Boolean, ByRef DebugText As String, ByRef Format As Boolean)
        If Debug Then
            DebugText += Chr(13) & Chr(10) & Chr(13) & Chr(10) & " - Its a new paragraph - Old Paragraph Length = " & ParagraphLength.ToString() & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            DebugText += currChar
        End If
        Paragraphs.Add(paragraph)
        ParagraphsNoOf += 1
        paragraph = currChar
        ParagraphLength = 1
    End Sub

    Public Sub StartNewSentence(ByRef ParagraphsNoOf As Integer, ByRef SentencesNoOf As Integer, _
                ByRef Sentences As Generic.List(Of String), ByRef SentenceInParagraph As Generic.List(Of Integer), _
                ByRef sentence As String, ByRef SentenceLength As Integer, ByRef currChar As Char, _
                ByRef Debug As Boolean, ByRef DebugText As String, ByRef Format As Boolean)
        If Debug Then
            DebugText += " - Its a new sentence - Old Sentence Length = " & SentenceLength.ToString() & " "
        End If
        SentencesNoOf += 1
        Sentences.Add(sentence)
        SentenceInParagraph.Add(ParagraphsNoOf)
        sentence = currChar
        SentenceLength = 1
    End Sub


    Private Sub StartNewLine(ByRef LinesNoOf As Integer, ByRef Lines As Generic.List(Of String), _
                             ByRef line As String, ByRef currChar As Char, ByRef LineLength As Integer, _
                             ByRef Debug As Boolean, ByRef DebugText As String)
        If Debug Then
            DebugText += " - Its a new line - Old Line Length = " & LineLength.ToString() & " "
        End If
        LinesNoOf += 1
        Lines.Add(line)
        line = currChar
        LineLength = 1
    End Sub


    Public Sub DivideText(ByRef ParagraphsNoOf As Integer, _
                          ByRef Paragraphs As Generic.List(Of String), _
                          ByRef SentencesNoOf As Integer, _
                          ByRef Sentences As Generic.List(Of String), _
                          ByRef SentenceInParagraph As Generic.List(Of Integer), _
                          ByRef LinesNoOf As Integer, _
                          ByRef Lines As Generic.List(Of String), _
                          ByRef DebugText As String, _
                          ByVal LineWidth As Integer, _
                          ByVal Debug As Boolean, _
                          ByVal EliminateWhiteSpace As Boolean, _
                          ByVal SplitHeaders As Boolean, _
                          ByVal SplitOnColon As Boolean, _
                          ByVal SplitOnLF As Boolean)
        Dim txtPtr, noOfChars, oldLineLength, _
            LineLength, SentenceLength, ParagraphLength, firstWordPtr, secondWordPtr, firstWordLength, lineEnd As Integer
        Dim currChar, lastChar, nextChar, firstWord1stChr As Char
        Dim line, newLine, sentence, paragraph, firstWord As String
        Dim endOfSentence, endOfParagraph, endOfLine, ItsAList, _
            HitAColon, FirstLine, firstWordAllCapitals, delimited, LastLineWasAHeading, _
            SkipNextCharacter, WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, _
            WordIsAHexNumber, WordAllCapitals, Format, HitTextYet As Boolean
        '
        ' Get the text that were formatting
        '
        txtText = Me.TheText
        noOfChars = txtText.Length
        '
        ' First up")." is the preferred end of a sentence not ".)" etc
        '
        txtText = txtText.Replace(".)", ").")
        txtText = txtText.Replace("?)", ")?")
        txtText = txtText.Replace("!)", ")!")
        txtText = txtText.Replace(".}", "}.")
        txtText = txtText.Replace("?}", "}?")
        txtText = txtText.Replace("!}", "}!")
        txtText = txtText.Replace(".]", "].")
        txtText = txtText.Replace("?]", "]?")
        txtText = txtText.Replace("!]", "]!")
        '
        ' Initial values
        '
        FirstLine = True
        endOfLine = False
        endOfSentence = False
        endOfParagraph = False
        HitAColon = False
        LastLineWasAHeading = False
        ItsAList = False
        Format = True
        HitTextYet = False
        lastChar = Chr(10)
        paragraph = ""
        sentence = ""
        line = ""
        oldLineLength = 0
        LineLength = 0
        ParagraphsNoOf = 0
        SentencesNoOf = 0
        LinesNoOf = 1
        '
        ' Each Character one at a time
        '
        For txtPtr = 0 To noOfChars - 1
            currChar = txtText.Substring(txtPtr, 1)
            '
            ' Some of the decisions below need to know what the next char is
            '
            If txtPtr < noOfChars - 1 Then
                nextChar = txtText.Substring(txtPtr + 1, 1)
            Else
                nextChar = ""
            End If
            '
            ' Is this character a printable character
            '
            If currChar > Chr(32) Then
                HitTextYet = True
            End If
            ' Dont format from <~ to ~>
            '
            ' Start Formatting Paragraphs and Sentences
            '
            If lastChar = "~" And currChar = ">" Then
                If Debug Then
                    DebugText += " - Hitting ~> skipping > Format - "
                End If
                Format = True
                SkipNextCharacter = True
                endOfSentence = True
                HitTextYet = False
                endOfParagraph = True
            End If
            '
            ' Stop Formatting Text into Paragraphs and Sentences however keep Formatting it into Lines as 
            ' this doesnt actually change the text of the line
            '
            If lastChar = "<" And currChar = "~" Then
                If Debug Then
                    DebugText += " - Hitting <~ skipping ~ Dont Format - "
                End If
                Format = False
                SkipNextCharacter = True
                endOfSentence = True
                HitTextYet = False
                endOfParagraph = True
            End If
            If currChar = "~" And nextChar = ">" Then
                SkipNextCharacter = True
                If Debug Then
                    DebugText += " - Hitting ~> skipping ~ - "
                End If
            End If
            If currChar = "<" And nextChar = "~" Then
                SkipNextCharacter = True
                If Debug Then
                    DebugText += " - Hitting <~ skipping < - "
                End If
            End If
            '
            ' Skip Character in these situations
            '
            ' Dont include white space if where eliminating white space and the current char is a space and 
            ' the last character was a space
            '
            If EliminateWhiteSpace And (currChar = " " And lastChar = " ") And Format Then
                SkipNextCharacter = True
                If Debug Then
                    DebugText += " - skippng white space - "
                End If
            End If
            '
            ' If the current character isnt printable skip it this includes CR and LF
            ' 
            ' If debugging let us know we skipped them
            '
            ' Display LF's and CR's when debugging
            '
            If currChar = Chr(10) And Debug Then
                DebugText += " - chr is line feed - "
            End If
            If currChar = Chr(13) And Debug Then
                DebugText += " - chr is carriage return - "
            End If
            '
            ' We only want to include CR's & LF's when were not formatting & after we've hit the 1st printable character
            ' Also dont skip tabs
            '
            If currChar < Chr(32) Then
                If HitTextYet And Not Format Then
                    SkipNextCharacter = False
                Else
                    If currChar = Chr(9) Then
                        SkipNextCharacter = False
                        'Convert tabs to spaces on list entries
                        If ItsAList Then
                            currChar = " "
                        End If
                        If Debug Then
                            DebugText += " - Hit a Tab - "
                        End If
                    Else
                        If currChar = Chr(10) Then
                            If SplitOnLF Then
                                SkipNextCharacter = False
                            Else
                                SkipNextCharacter = True
                                If Debug Then
                                    DebugText += " - skippng line feed - "
                                End If
                            End If
                        End If
                        If currChar = Chr(13) Then
                            If SplitOnLF Then
                                SkipNextCharacter = False
                            Else
                                SkipNextCharacter = True
                                If Debug Then
                                    DebugText += " - skippng carriage return - "
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            '
            ' The characters we want
            '
            If Not SkipNextCharacter Then
                '
                ' If lastChar is LF were now at a new non blank line
                '
                If lastChar = Chr(10) Then
                    If Debug Then
                        DebugText += " - hit new non blank line - "
                    End If
                    If Format Then
                        ItsAList = False
                        lineEnd = WheresNextEndOfLine(txtText.Substring(txtPtr))
                        newLine = txtText.Substring(txtPtr, lineEnd + 1)
                        AnalyseFirstWord(newLine, firstWordPtr, secondWordPtr, _
                         firstWordLength, firstWordAllCapitals, delimited)
                        ' these are the positions in the whole text not just the next line
                        firstWordPtr += txtPtr
                        secondWordPtr += txtPtr
                        firstWord1stChr = txtText.Substring(firstWordPtr, 1)
                        firstWord = txtText.Substring(firstWordPtr, firstWordLength)
                        AnalyseWord(firstWord, WordEndsWithDelimiter, WordEndsWithFullStop, _
                        WordIsAInteger, WordIsAHexNumber, WordAllCapitals)
                        If Debug Then
                            DebugText += " - first word is - " & firstWord & " - first word 1st char is - " & firstWord1stChr.ToString & " "
                        End If
                        '
                        ' Is It A List
                        '
                        If (firstWord = "•" Or firstWord = "o" Or firstWord = "-" Or firstWord = "v" Or firstWord = "*") Then
                            ItsAList = True
                        End If
                        If WordIsAInteger And WordEndsWithFullStop Then
                            ItsAList = True
                        End If
                        If (firstWord1stChr >= "a" And firstWord1stChr <= "z") And delimited And firstWordLength = 2 Then
                            ItsAList = True
                        End If
                        If Not FirstLine And Format And ItsAList Then
                            endOfParagraph = True
                            endOfSentence = True
                            endOfLine = True
                            If Debug Then
                                DebugText += " - its a list - "
                            End If
                        End If
                        If Not FirstLine And Format And _
                            currChar = ":" And (lastChar >= "a" And lastChar <= "z") And SplitOnColon Then
                            endOfParagraph = True
                            endOfSentence = True
                            endOfLine = True
                            If Debug Then
                                DebugText += " - split on colon - "
                            End If
                        End If
                        ' Is this new line a new paragraph (and hence a new sentence)
                        If Not FirstLine And Format And HitTextYet And _
                            (oldLineLength + firstWordLength < LineWidth Or oldLineLength > LineWidth Or LineWidth = 0) And _
                            (firstWord1stChr >= "A" And firstWord1stChr <= "Z") Then
                            endOfParagraph = True
                            endOfSentence = True
                            endOfLine = True
                            If Debug Then
                                DebugText += " - its a new paragraph - "
                            End If
                        End If
                    End If
                    ' End of all the stuff we do if we are formatting the text
                    '
                    ' Next LF wont be on the First Line
                    '
                    If FirstLine Then
                        FirstLine = False
                    Else
                        If Debug Then
                            DebugText += " - old line length = " & LineLength.ToString() & " "
                        End If
                        endOfLine = True
                        oldLineLength = LineLength
                    End If
                End If
                'End of Last Char was a LF so we do the following for every character
                '
                ' Start Newline if we've reached the end of a line
                '
                If endOfLine Then
                    endOfLine = False
                    StartNewLine(LinesNoOf, Lines, line, currChar, LineLength, Debug, DebugText)
                Else
                    line += currChar
                    LineLength += 1
                End If
                If endOfSentence And HitTextYet Then
                    endOfSentence = False
                    StartNewSentence(ParagraphsNoOf, SentencesNoOf, Sentences, SentenceInParagraph, sentence, SentenceLength, currChar, Debug, DebugText, Format)
                Else
                    sentence += currChar
                    SentenceLength += 1
                End If
                '
                ' Start New Pragraph if we've reached the 1st printable character after the end of the last paragraph
                '
                If endOfParagraph And HitTextYet Then
                    endOfParagraph = False
                    StartNewParagraph(ParagraphsNoOf, Paragraphs, sentence, paragraph, currChar, ParagraphLength, Debug, DebugText, Format)
                Else
                    paragraph += currChar
                    ParagraphLength += 1
                    If Debug Then
                        DebugText += currChar
                    End If
                End If
                '
                ' Have we reached the end of a sentence
                '
                If Format And (currChar = "." And nextChar <= Chr(32)) And Not ItsAList And _
                   ((lastChar >= "a" And lastChar <= "z") Or _
                    (lastChar >= "A" And lastChar <= "Z") Or _
                    (lastChar >= "0" And lastChar <= "9") Or _
                     lastChar = ")" Or lastChar = "}" Or lastChar = "]") Then
                    endOfSentence = True
                    HitTextYet = False
                    If Debug Then
                        DebugText += " - hit full stop at end of sentence - "
                    End If
                End If
            End If
            'End of Dont skip this character
            lastChar = currChar
            SkipNextCharacter = False
        Next
        If paragraph.Length > 0 Then
            Paragraphs.Add(paragraph)
            If Debug Then
                DebugText += " - Adding Last Paragraph - "
            End If
        End If
        If sentence.Length > 0 Then
            SentencesNoOf += 1
            Sentences.Add(sentence)
            SentenceInParagraph.Add(ParagraphsNoOf)
            If Debug Then
                DebugText += " - Adding Last Sentence - "
            End If
        End If
        If line.Length > 0 Then
            Lines.Add(line)
            If Debug Then
                DebugText += " - Adding Last Line - "
            End If
        End If
    End Sub

End Class

