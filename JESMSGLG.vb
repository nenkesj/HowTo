Public Class JESMSGLG
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

    Public Property NoOfMsgs() As Integer
        Get
            Return msgsNoOf
        End Get
        Set(ByVal Value As Integer)
            msgsNoOf = Value
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

    Public Property AlteredNoOfMsgs() As Integer
        Get
            Return msgsAlteredNoOf
        End Get
        Set(ByVal Value As Integer)
            msgsAlteredNoOf = Value
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

    Dim msgsNoOf, linesNoOf, msgsAlteredNoOf, txtPtr, msgPtr, _
        msgStart, msgEnd, msgLength As Integer

    Dim txtLetter, msg, alteredText, commSuffix As String

    Dim Txt As Text

    Dim Msgs, SortedMsgs, msgIDs, msgIDCounts, Cmds, BMPs, BMPCounts As Generic.List(Of String)

    Public Sub OnlyMsgs(ByVal WithOrWithout As String)
        'Subs called:- None
        'Properties Altered:- None
        Msgs = New Generic.List(Of String)
        ' Divide text into messages, messages start with a time at char position 1 and are 8 chars
        ' long so the test for is new messages is no spaces from 2nd to 9th characters
        Me.DivideByFieldWithNoSpaces(1, 8, linesNoOf, msgsNoOf, Msgs)
        ' Exclude or Include messages
        If WithOrWithout = "Without" Then
            Me.ExcludeSegments(msgsNoOf, msgsAlteredNoOf, Me.SearchText, Msgs, alteredText)
        Else
            Me.IncludeSegments(msgsNoOf, msgsAlteredNoOf, Me.SearchText, Msgs, alteredText)
        End If
    End Sub

    Public Sub Sort(ByVal Start As Integer, ByVal Length As Integer)
        'Subs called:- None
        'Properties Altered:- None
        ' Removes Lines that include of exclude the search string
        Dim msgPtr, msgIDPtr As Integer
        Dim msg, msgID As String
        alteredText = ""
        msgsAlteredNoOf = 0
        Msgs = New Generic.List(Of String)
        SortedMsgs = New Generic.List(Of String)
        ' Divide text into messages, messages start with a time at char position 1 and are 8 chars
        ' long so the test for is new messages is no spaces from 2nd to 9th characters
        Me.DivideByFieldWithNoSpaces(1, 8, linesNoOf, msgsNoOf, Msgs)
        ' Sort the messages on the chars specified by the parms
        For msgPtr = 0 To msgsNoOf - 1
            msg = Msgs(msgPtr)
            If msg.Length >= Start + Length - 1 Then
                SortedMsgs(msg.Substring(Start, Length)) = msg
                msgsAlteredNoOf += 1
            End If
        Next
        ' Create the new sorted text and count the number of occurances of each message id
        commSuffix = ""
        msgIDs = New Generic.List(Of String)
        msgIDCounts = New Generic.List(Of String)
        For msgPtr = 0 To SortedMsgs.Count - 1
            msg = SortedMsgs.Item(msgPtr)
            ' Create new sorted text
            alteredText += msg
            ' Message ID's start in column 20 and finish in col 26 if 7 chars in length or 27
            ' if 8 chars in length
            If msg.Length >= 27 Then
                msgID = msg.Substring(20, 8)
                ' If a message weve hit before or a new one
                If msgIDs.Contains(msgID) Then
                    msgIDCounts(msgID) += 1
                Else
                    msgIDCounts(msgID) = 1
                    msgIDs(msgID) = msgID
                End If
            End If
        Next
        ' Build Observation Comment to be added prior to existing comnments, basically messages 
        ' and their counts
        commSuffix = "There are " & msgIDs.Count & " different messages ID's in this JESMSGLG. These are:-" & _
            Chr(13) & Chr(10)
        For msgIDPtr = 0 To msgIDs.Count - 1
            commSuffix += msgIDs.Item(msgIDPtr) & ": " & msgIDCounts.Item(msgIDPtr) & _
            Chr(13) & Chr(10)
        Next
    End Sub

    Public Sub ProcessFile()
        Dim line, fldTime, msg, msgID, timeOfMsg, msgPrefix As String
        Dim msgPtr, msgIDPtr, msgCount, timeIncrement, msgPrintedCount, cmdPtr As Integer
        SortedMsgs = New Generic.List(Of String)
        Msgs = New Generic.List(Of String)
        Cmds = New Generic.List(Of String)
        msgIDs = New Generic.List(Of String)
        msgIDCounts = New Generic.List(Of String)
        SearchText = Me.SearchText
        alteredText = ""
        msgsAlteredNoOf = 0
        FileOpen(1, "C:\Documents and Settings\Administrator\My Documents\txt & Mainframe Transfer Files\JESMSGLG.txt", OpenMode.Input)
        Do Until EOF(1)
            line = LineInput(1)
            ' Ignore any lines that arent long enough to have a time in them
            If line.Length >= 9 Then
                fldTime = line.Substring(1, 8)
                ' If the message doesnt start with a time treat it as a continuation of the previous
                ' message
                If AnySpaces(fldTime) Then
                    If msgCount > 0 Then
                        msg += Chr(13) & Chr(10) & line
                    End If
                Else
                    ' Were onto a new message
                    msgCount += 1
                    'Sort the messages
                    If msgCount > 1 Then
                        timeIncrement = 0
                        ' If the time field is the same as a previous message add an increment
                        ' as Sorted Arrays have to have unique keys, if theres more than 10 with the
                        ' same time ignore those after the 10th. Nasty but what else can you do??
                        Do Until Not SortedMsgs.Contains(timeOfMsg) Or timeIncrement > 9
                            timeIncrement += 1
                            timeOfMsg = timeOfMsg & timeIncrement
                        Loop
                        SortedMsgs(timeOfMsg) = msg
                    End If
                    msg = line
                    timeOfMsg = fldTime
                    ' Here were building a list of IMS Commands that have been issued prefixed by
                    ' the time and the Started Task/Job/TSO User that issued the command
                    If line.Length >= 24 Then
                        If msg.Substring(21, 1) = " " Or _
                           msg.Substring(21, 3) = "IMS" Then
                            Cmds(fldTime) = fldTime & " " & msg.Substring(10, 8) & " " & _
                            msg.Substring(20)
                        End If
                    End If
                    ' Here were building the list of messages and their counts
                    If line.Length >= 29 Then
                        If msg.Substring(20, 1) = "+" Then
                            msgID = msg.Substring(21, 8)
                        Else
                            msgID = msg.Substring(20, 8)
                        End If
                        ' Check the message ID contains alphanumeric & no spaces in the 1st 6 chars
                        ' of the message (some are only 6 chars in length) otherwise ignore it
                        If (msgID.Substring(1, 1) >= "A" And msgID.Substring(1, 1) <= "Z") And _
                               (msgID.Substring(5, 1) >= "0" And msgID.Substring(5, 1) <= "9") Then
                            If Not AnySpaces(msgID.Substring(0, 6)) Then
                                If msgIDs.Contains(msgID) Then
                                    msgIDCounts(msgID) += 1
                                Else
                                    msgIDCounts(msgID) = 1
                                    msgIDs(msgID) = msgID
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Loop
        ' Last Iteration
        timeIncrement = 0
        Do Until Not SortedMsgs.Contains(timeOfMsg) Or timeIncrement > 9
            timeIncrement += 1
            timeOfMsg = timeOfMsg & timeIncrement
        Loop
        SortedMsgs(timeOfMsg) = msg
        FileClose(1)
        FileOpen(1, "C:\Documents and Settings\Administrator\My Documents\txt & Mainframe Transfer Files\JESMSGLG Sorted.txt", OpenMode.Output)
        ' Build the new JESMSGLG Sorted text file 
        alteredText = ""
        msgsAlteredNoOf = 0
        For msgPtr = 0 To SortedMsgs.Count - 1
            msg = SortedMsgs.Item(msgPtr)
            ' Get the message ID
            If msg.Length >= 29 Then
                If msg.Substring(20, 1) <> "+" Then
                    msgID = msg.Substring(20, 8)
                Else
                    msgID = msg.Substring(21, 8)
                End If
            End If
            ' If the Text Operation Specs have a message ID only include those messages otherwise
            ' include all messages. Limit the number of messages in the Observation to 1000 however
            ' include all messages in the Sorted Text file
            If SearchText <> "" Then
                If SearchText = msgID.Substring(0, SearchText.Length) Then
                    PrintLine(1, msg)
                    msgsAlteredNoOf += 1
                    If msgPrintedCount <= 1000 Then
                        msgPrintedCount += 1
                        alteredText += msg & Chr(13) & Chr(10)
                    End If
                End If
            Else
                PrintLine(1, msg)
                msgsAlteredNoOf += 1
                If msgPrintedCount <= 1000 Then
                    msgPrintedCount += 1
                    alteredText += msg & Chr(13) & Chr(10)
                End If
            End If
        Next
        FileClose(1)
        commSuffix += "There are " & msgIDs.Count & " different messages ID's in this JESMSGLG. These are:-" & _
            Chr(13) & Chr(10)
        For msgIDPtr = 0 To msgIDs.Count - 1
            commSuffix += msgIDs.Item(msgIDPtr) & ": " & msgIDCounts.Item(msgIDPtr) & _
            Chr(13) & Chr(10)
        Next
        commSuffix += "There were " & Cmds.Count & " commands issued in this JESMSGLG. These are:-" & _
            Chr(13) & Chr(10)
        For cmdPtr = 0 To Cmds.Count - 1
            commSuffix += Cmds.Item(cmdPtr) & Chr(13) & Chr(10)
        Next
    End Sub

    Public Sub ChkBMPs()
        Dim line, index As String
        Dim linePtr As Integer
        BMPs = New Generic.List(Of String)
        BMPCounts = New Generic.List(Of String)
        alteredText = ""
        msgsAlteredNoOf = 2
        FileOpen(1, "C:\Documents and Settings\Administrator\My Documents\txt & Mainframe Transfer Files\JESMSGLG Sorted.txt", OpenMode.Input)
        Do Until EOF(1)
            line = LineInput(1)
            ' Ignore lines which are less that 84 chars as they cant be DFS551I or DFS552I msgs
            If line.Length >= 84 Then
                ' For BMP start 
                If line.Substring(20, 13) = "DFS551I BATCH" Then
                    ' Sorted by IMSID & BMP Jobname
                    index = line.Substring(80, 4) & " " & line.Substring(43, 8)
                    BMPs(index) = "STARTED: " & line.Substring(1, 8)
                    If BMPs.Contains(index) Then
                        BMPCounts(index) += 1
                    Else
                        BMPCounts(index) = 1
                    End If
                End If
                ' BMP Finished - Note were ignoring those that finish that havent got a start msg
                If line.Substring(20, 13) = "DFS552I BATCH" Then
                    ' Sorted by IMSID & BMP Jobname
                    index = line.Substring(80, 4) & " " & line.Substring(43, 8)
                    If BMPs.Contains(index) Then
                        BMPs(index) += " STOPPED: " & line.Substring(1, 8)
                    End If
                End If
            End If
        Loop
        FileClose(1)
        ' List those that started but dont have a finished message
        alteredText = "The Following BMP's Started but havent Stopped yet :-" & Chr(13) & Chr(10)
        For linePtr = 0 To BMPs.Count - 1
            line = BMPs.Item(linePtr)
            If line.Length <= 17 Then
                alteredText += BMPs.Item(linePtr).ToString() & " " & line & Chr(13) & Chr(10)
                msgsAlteredNoOf += 1
            End If
        Next
        ' List each BMP that started and finished with the count of the times it ran on each IMS
        ' in the plex, note the start and the stop time will be for the last time it ran if it ran
        ' more than once. These entries are listed in IMSID Jobname order
        alteredText += "The Following BMP's started & completed :-" & Chr(13) & Chr(10)
        For linePtr = 0 To BMPs.Count - 1
            line = BMPs.Item(linePtr)
            alteredText += BMPs.Item(linePtr).ToString() & " " & line & " this BMP ran " & _
                           BMPCounts.Item(linePtr) & " times" & Chr(13) & Chr(10)
            msgsAlteredNoOf += 1
        Next
    End Sub

End Class

