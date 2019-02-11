Public Class DisplayRegionActive
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

    Public Property CommentSuffix() As String
        Get
            Return commSuffix
        End Get
        Set(ByVal Value As String)
            commSuffix = Value
        End Set
    End Property

    Dim linesNoOf, linesAlteredNoOf, txtPtr, linePtr, _
         lineStart, lineEnd, lineLength As Integer

    Dim txtLetter, line, alteredText, commSuffix As String

    Dim Txt As Text

    Dim Lines As Generic.List(Of String)

    Dim SortedLines As SortedList

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

    Public Sub Sort()
        'Subs called:- None
        'Properties Altered:- None
        ' Removes Lines that include of exclude the search string
        Dim line, keystr, currStatus, lastStatus, currRegion, lastRegion, currProg, lastProg, _
             currIMSID, lastIMSID, currTime, lastTime As String
        Dim count As Integer
        Lines = New Generic.List(Of String)
        SortedLines = New SortedList
        currTime = ""
        linesAlteredNoOf = 0
        ' Divide into lines at carriage return
        Me.DivideAfterChar(Chr(10), linesNoOf, Lines)
        For linePtr = 0 To linesNoOf - 1
            line = Lines(linePtr)
            ' Get the time for sorting
            If line.Length >= 21 Then
                If line.Substring(0, 21) = "  Start time. . . . :" Then
                    currTime = line.Substring(31, 11)
                End If
            End If
            ' So lines are sorted by Status, IMSID, REGID#, Time
            If line.Length >= 75 Then
                keystr = line.Substring(56, 17) & _
                         line.Substring(2, 4) & _
                         line.Substring(17, 3) & _
                         currTime
                ' Add the time to the line
                SortedLines(keystr) = currTime & " " & line
                linesAlteredNoOf += 1
            End If
        Next
        currStatus = ""
        currRegion = ""
        currProg = ""
        currIMSID = ""
        commSuffix = ""
        alteredText = ""
        For linePtr = 0 To SortedLines.Count - 1
            line = SortedLines.GetByIndex(linePtr)
            alteredText += line
            ' Remember Time & a space have been added so sub 12 from the following when looking at
            ' SYSOUT.txt
            currIMSID = line.Substring(14, 4)
            currRegion = line.Substring(29, 3)
            currStatus = line.Substring(68, 17)
            currProg = line.Substring(59, 8)
            If currStatus = lastStatus And currRegion = lastRegion And currProg = lastProg And _
               currIMSID = lastIMSID Then
                count += 1
                If count >= 3 Then
                    ' If the same program was active in the same region 3 times it could be looping
                    If currStatus = "ACTIVE           " Then
                        commSuffix += "Program: " & currProg & _
                        " could be looping in region ID: " & currRegion & " i.e. Jobname: " & _
                        line.Substring(33, 8) & " in IMS: " & currIMSID & _
                        " its status is: " & currStatus & Chr(13) & Chr(10)
                        ' If the same program is still in the same region and the region isnt just idle
                        ' then this program could be hung ("STATUS" is the heading "WAITING" is 
                        ' usually just idle regions)
                    ElseIf currStatus <> "STATUS           " And _
                           currStatus <> "WAITING          " Then
                        commSuffix += "Program: " & currProg & _
                        " could be hung in region ID: " & currRegion & " i.e. Jobname: " & _
                        line.Substring(33, 8) & " in IMS: " & currIMSID & _
                        " its status is: " & currStatus & Chr(13) & Chr(10)
                    End If
                End If
            End If
            If currStatus <> lastStatus Then
                count = 1
                lastStatus = currStatus
            End If
            If currRegion <> lastRegion Then
                count = 1
                lastRegion = currRegion
            End If
            If currProg <> lastProg Then
                count = 1
                lastProg = currProg
            End If
            If currIMSID <> lastIMSID Then
                count = 1
                lastIMSID = currIMSID
            End If
        Next
    End Sub

End Class

