Public Class Lines
    Inherits Text

    Sub New()
        MyBase.New()
    End Sub

    Public Property NoOfLines() As Integer
        Get
            Return linesNoOf
        End Get
        Set(ByVal Value As Integer)
            linesNoOf = Value
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

    Public Property AlteredNoOfLines() As Integer
        Get
            Return linesAlteredNoOf
        End Get
        Set(ByVal Value As Integer)
            linesAlteredNoOf = Value
        End Set
    End Property

    Dim linesNoOf, linesAlteredNoOf, txtPtr, linePtr, _
        lineStart, lineEnd, lineLength As Integer

    Dim txtLetter, line, alteredText As String

    Dim Txt As Text

    Dim Lines, SortedLines As Generic.List(Of String)

    Public Sub OnlyLines(ByVal WithOrWithout As String)
        'Subs called:- None
        'Properties Altered:- None
        ' Removes Lines that include of exclude the search string
        Lines = New Generic.List(Of String)
        Me.DivideAfterChar(Chr(10), linesNoOf, Lines)
        If WithOrWithout = "Without" Then
            Me.ExcludeSegments(linesNoOf, linesAlteredNoOf, Me.SearchText, Lines, alteredText)
        Else
            Me.IncludeSegments(linesNoOf, linesAlteredNoOf, Me.SearchText, Lines, alteredText)
        End If
    End Sub

    Public Sub Sort(ByVal Start As Integer, ByVal Length As Integer)
        'Subs called:- None
        'Properties Altered:- None
        ' Removes Lines that include of exclude the search string
        Dim line As String
        alteredText = ""
        linesAlteredNoOf = 0
        Lines = New Generic.List(Of String)
        SortedLines = New Generic.List(Of String)
        Me.DivideAfterChar(Chr(10), linesNoOf, Lines)
        For linePtr = 0 To linesNoOf - 1
            line = Lines(linePtr)
            If line.Length >= Start + Length - 1 Then
                SortedLines(line.Substring(Start, Length)) = line
                linesAlteredNoOf += 1
            End If
        Next
        For linePtr = 0 To SortedLines.Count - 1
            alteredText += SortedLines.Item(linePtr)
        Next
    End Sub

    Public Sub RemoveColumnFromAll(ByVal Start As Integer, ByVal Length As Integer)
        'Subs called:- None
        'Properties Altered:- None
        ' Removes Lines that include of exclude the search string
        Dim linePtr As Integer
        Dim line As String
        alteredText = ""
        linesAlteredNoOf = 0
        Lines = New Generic.List(Of String)
        Me.DivideAfterChar(Chr(10), linesNoOf, Lines)
        For linePtr = 0 To linesNoOf - 1
            line = Lines(linePtr)
            If line.Length >= Start + Length - 1 Then
                If line.Length >= Start + Length - 1 Then
                    line = line.Remove(Start, Length)
                    alteredText += line
                    linesAlteredNoOf += 1
                End If
            End If
        Next
    End Sub

End Class

