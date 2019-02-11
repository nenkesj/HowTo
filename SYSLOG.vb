Public Class SYSLOG
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

    Dim Msgs, SortedMsgs, msgIDs, msgIDCounts, Cmds, BMPs As Generic.List(Of String)

    Public Sub OnlyMsgs(ByVal WithOrWithout As String)
        'Subs called:- None
        'Properties Altered:- None
        ' Removes Lines that include of exclude the search string
        Msgs = New Generic.List(Of String)
        Me.DivideByFieldWithNoSpaces(11, 11, linesNoOf, msgsNoOf, Msgs)
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
        ' Divide into messages
        Me.DivideByFieldWithNoSpaces(11, 11, linesNoOf, msgsNoOf, Msgs)
        ' Sort on time 
        For msgPtr = 0 To msgsNoOf - 1
            msg = Msgs(msgPtr)
            If msg.Length >= Start + Length - 1 Then
                SortedMsgs(msg.Substring(Start, Length)) = msg
                msgsAlteredNoOf += 1
            End If
        Next
        commSuffix = ""
        ' Build list of message ID's & counts
        msgIDs = New Generic.List(Of String)
        msgIDCounts = New Generic.List(Of String)
        For msgPtr = 0 To SortedMsgs.Count - 1
            msg = SortedMsgs.Item(msgPtr)
            alteredText += msg
            If msg.Length >= 43 Then
                If msg.Substring(32, 1) = "+" Or msg.Substring(33, 1) = ">" Then
                    msgID = msg.Substring(33, 8)
                Else
                    msgID = msg.Substring(32, 8)
                End If
                If msgIDs.Contains(msgID) Then
                    msgIDCounts(msgID) += 1
                Else
                    msgIDCounts(msgID) = 1
                    msgIDs(msgID) = msgID
                End If
            End If
        Next
        ' List message ID's & counts
        commSuffix = "There are " & msgIDs.Count & " different messages ID's in this SYSLOG. These are:-" & _
            Chr(13) & Chr(10)
        For msgIDPtr = 0 To msgIDs.Count - 1
            commSuffix += msgIDs.Item(msgIDPtr) & ": " & msgIDCounts.Item(msgIDPtr) & _
            Chr(13) & Chr(10)
        Next
    End Sub

    Public Sub Format()
        'Subs called:- None
        'Properties Altered:- None
        ' Formats SYSLOG lines i.e.
        ' Changes -
        '  MR0000000 194B     12172 09:00:01.43 ZN1BZ068 00000094  $HASP003 RC=(52),PO 083
        ' To      -
        ' 194B 12172 09:00:01.43 ZN1BZ068 $HASP003 RC=(52),PO 083
        Dim linesNoOf, alteredMsgsNoOf As Integer
        Dim msg As String
        Dim SyslogLines As Lines
        SyslogLines = New Lines
        SyslogLines.TheText = Me.TheText
        SyslogLines.NoOfChars = SyslogLines.TheText.Length
        SyslogLines.RemoveColumnFromAll(0, 11)
        SyslogLines.TheText = SyslogLines.TheAlteredText
        SyslogLines.NoOfChars = SyslogLines.TheText.Length
        SyslogLines.RemoveColumnFromAll(4, 4)
        SyslogLines.TheText = SyslogLines.TheAlteredText
        SyslogLines.NoOfChars = SyslogLines.TheText.Length
        SyslogLines.RemoveColumnFromAll(32, 9)
        SyslogLines.TheText = SyslogLines.TheAlteredText
        SyslogLines.NoOfChars = SyslogLines.TheText.Length
        Me.TheAlteredText = SyslogLines.TheAlteredText
    End Sub

    Public Sub ProcessFile()
        Dim line, fldTime, msg, msgID, msgPrefix, searchText, timeOfMsg As String
        Dim msgPtr, msgIDPtr, cmdPtr, msgCount, msgPrintedCount, timeIncrement As Integer
        SortedMsgs = New Generic.List(Of String)
        Msgs = New Generic.List(Of String)
        Cmds = New Generic.List(Of String)
        msgIDs = New Generic.List(Of String)
        msgIDCounts = New Generic.List(Of String)
        searchText = Me.SearchText
        FileOpen(1, "C:\Documents and Settings\Administrator\My Documents\txt & Mainframe Transfer Files\SYSLOG.txt", OpenMode.Input)
        msg = ""
        msgCount = 0
        Do Until EOF(1)
            line = LineInput(1)
            ' Ignore headers and lines that arent wide enough to include a message
            If line.IndexOf("SDSF  SYSLOG  PRINT") < 0 And line.Length > 57 Then
                ' Formats SYSLOG lines i.e.
                ' Changes -
                '  MR0000000 194B     12172 09:00:01.43 ZN1BZ068 00000094  $HASP003 RC=(52),PO 083
                ' To      -
                ' 194B 12172 09:00:01.43 ZN1BZ068 $HASP003 RC=(52),PO 083
                line = line.Remove(0, 11)
                ' This was something annoying for some SYSLOG lines that required some cleanup
                If line.Substring(2, 9) = "       20" Then
                    Select Case line.Substring(0, 2)
                        Case "1A"
                            line = "194" & line.Substring(1, 1) & "     " & line.Substring(11)
                        Case "1B"
                            line = "194" & line.Substring(1, 1) & "     " & line.Substring(11)
                        Case "1C"
                            line = "194" & line.Substring(1, 1) & "     " & line.Substring(11)
                        Case "2A"
                            line = "296" & line.Substring(1, 1) & "     " & line.Substring(11)
                        Case "2C"
                            line = "292" & line.Substring(1, 1) & "     " & line.Substring(11)
                    End Select
                End If
                line = line.Remove(4, 4)
                line = line.Remove(32, 9)
                ' Note the time
                fldTime = line.Substring(11, 11)
                ' if its not a time treat this line as a continuation of the message in the last line
                If AnySpaces(fldTime) Then
                    If msgCount > 0 Then
                        msg += Chr(13) & Chr(10) & line
                    End If
                Else
                    ' its a new message
                    msgCount += 1
                    If msgCount > 1 Then
                        timeIncrement = 0
                        ' just incase the times are the same however ignores messages after 10 all 
                        ' with the same time. Keys in sorted array must be unique.
                        Do Until Not SortedMsgs.Contains(timeOfMsg) Or timeIncrement > 9
                            timeIncrement += 1
                            timeOfMsg = timeOfMsg & timeIncrement
                        Loop
                        SortedMsgs(timeOfMsg) = msg
                    End If
                    msg = line
                    timeOfMsg = fldTime
                    ' Build a list of commands issued prefixed by time and LPAR
                    If line.Length >= 38 Then
                        If ((msg.Substring(34, 1) = " " Or _
                            (msg.Substring(33, 3) = "IMS" And msg.Substring(33, 4) <> "IMS/")) Or _
                            (msg.Substring(33, 1) = "-")) And _
                            (msg.Substring(33, 1) <> "+") Then
                            Cmds(fldTime) = fldTime & " " & msg.Substring(0, 4) & " " & msg.Substring(33)
                        End If
                    End If
                    ' Build a list of Message ID's with counts
                    If line.Length >= 43 Then
                        If msg.Substring(33, 1) = "+" Then
                            msgID = msg.Substring(34, 8)
                        Else
                            msgID = msg.Substring(33, 8)
                        End If
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
        'Last Iteration
        timeIncrement = 0
        Do Until Not SortedMsgs.Contains(timeOfMsg) Or timeIncrement > 9
            timeIncrement += 1
            timeOfMsg = timeOfMsg & timeIncrement
        Loop
        SortedMsgs(timeOfMsg) = msg
        FileClose(1)
        ' Create Sorted SYSLOG in SYSLOG Sorted.txt
        FileOpen(1, "C:\Documents and Settings\Administrator\My Documents\txt & Mainframe Transfer Files\SYSLOG Sorted.txt", OpenMode.Output)
        alteredText = ""
        msgsAlteredNoOf = 0
        msgPrintedCount = 0
        For msgPtr = 0 To SortedMsgs.Count - 1
            msg = SortedMsgs.Item(msgPtr)
            'Extract Message ID and Message Prefix
            If msg.Length >= 42 Then
                If msg.Substring(33, 1) <> "+" Then
                    msgID = msg.Substring(33, 8)
                    msgPrefix = msg.Substring(33, 3)
                Else
                    msgID = msg.Substring(34, 8)
                    msgPrefix = msg.Substring(34, 3)
                End If
            End If
            ' The Operation Specs can be used to filter the messages
            Select Case searchText
                Case "Subsystems"
                    ' Only IMS (excluding 2 annoying ones), CICS, DB2, IMS Connect, MQSeries messages
                    If (msgPrefix = "DFS" And msgID <> "DFS0540I" And msgID <> "DFS0542I") Or _
                       msgPrefix = "DFH" Or msgPrefix = "DSN" Or msgPrefix = "IST" Or _
                       msgPrefix = "HWS" Or msgPrefix = "CSQ" Then
                        PrintLine(1, msg)
                        msgsAlteredNoOf += 1
                        If msgPrintedCount <= 1000 Then
                            msgPrintedCount += 1
                            alteredText += msg & Chr(13) & Chr(10)
                        End If
                    End If
                Case "IMS"
                    ' Only IMS messages (excluding 2 annoying ones)
                    If msgPrefix = "DFS" And msgID <> "DFS0540I" And msgID <> "DFS0542I" Then
                        PrintLine(1, msg)
                        msgsAlteredNoOf += 1
                        If msgPrintedCount <= 1000 Then
                            msgPrintedCount += 1
                            alteredText += msg & Chr(13) & Chr(10)
                        End If
                    End If
                Case "CICS"
                    ' Only CICS messages
                    If msgPrefix = "DFH" Then
                        PrintLine(1, msg)
                        msgsAlteredNoOf += 1
                        If msgPrintedCount <= 1000 Then
                            msgPrintedCount += 1
                            alteredText += msg & Chr(13) & Chr(10)
                        End If
                    End If
                Case "DB2"
                    ' Only DB2 messages
                    If msgPrefix = "DSN" Then
                        PrintLine(1, msg)
                        msgsAlteredNoOf += 1
                        If msgPrintedCount <= 1000 Then
                            msgPrintedCount += 1
                            msgCount += 1
                            alteredText += msg & Chr(13) & Chr(10)
                        End If
                    End If
                Case "MQSeries"
                    ' Only MQSeries messages
                    If msgPrefix = "CSQ" Then
                        PrintLine(1, msg)
                        msgsAlteredNoOf += 1
                        If msgPrintedCount <= 1000 Then
                            msgPrintedCount += 1
                            alteredText += msg & Chr(13) & Chr(10)
                        End If
                    End If
                Case "IMS Connect"
                    ' Only IMS Connect messages
                    If msgPrefix = "HWS" Then
                        PrintLine(1, msg)
                        msgsAlteredNoOf += 1
                        If msgPrintedCount <= 1000 Then
                            msgPrintedCount += 1
                            alteredText += msg & Chr(13) & Chr(10)
                        End If
                    End If
                Case Else
                    ' Otherwise everything
                    PrintLine(1, msg)
                    msgsAlteredNoOf += 1
                    If msgPrintedCount <= 1000 Then
                        msgPrintedCount += 1
                        alteredText += msg & Chr(13) & Chr(10)
                    End If
            End Select
        Next
        FileClose(1)
        ' List of message ID's & counts
        commSuffix += "There are " & msgIDs.Count & " different messages ID's in this SYSLOG. These are:-" & _
            Chr(13) & Chr(10)
        For msgIDPtr = 0 To msgIDs.Count - 1
            commSuffix += msgIDs.Item(msgIDPtr) & ": " & msgIDCounts.Item(msgIDPtr) & _
            Chr(13) & Chr(10)
        Next
        ' List of commands issued
        commSuffix += "There were " & Cmds.Count & " commands issued in this SYSLOG. These are:-" & _
            Chr(13) & Chr(10)
        For cmdPtr = 0 To Cmds.Count - 1
            commSuffix += Cmds.Item(cmdPtr) & Chr(13) & Chr(10)
        Next
    End Sub

    Public Sub ChkBMPs()
        Dim line, index, fldTime, timeOfMsg, msgID As String
        Dim linePtr, timeIncrement As Integer
        Dim previousLineDFS0540I As Boolean
        BMPs = New Generic.List(Of String)
        SortedMsgs = New Generic.List(Of String)
        alteredText = ""
        msgsAlteredNoOf = 1
        previousLineDFS0540I = False
        FileOpen(1, "C:\Documents and Settings\Administrator\My Documents\txt & Mainframe Transfer Files\SYSLOG.txt", OpenMode.Input)
        Do Until EOF(1)
            line = LineInput(1)
            If line.IndexOf("SDSF  SYSLOG  PRINT") < 0 And line.Length > 65 Then
                line = line.Remove(0, 11)
                line = line.Remove(4, 4)
                line = line.Remove(32, 9)
                If line.Length >= 65 Then
                    If line.Substring(33, 1) = "+" Then
                        msgID = line.Substring(34, 31)
                    Else
                        msgID = line.Substring(33, 31)
                    End If
                End If
                If msgID = "DFS0540I  *EXTENDED CHECKPOINT*" Then
                    fldTime = line.Substring(11, 11)
                    If Not AnySpaces(fldTime) Then
                        msg = line
                        timeOfMsg = fldTime
                        previousLineDFS0540I = True
                    End If
                End If
                If previousLineDFS0540I And msgID <> "DFS0540I  *EXTENDED CHECKPOINT*" Then
                    msg += Chr(13) & Chr(10) & line
                    timeIncrement = 0
                    Do Until Not SortedMsgs.Contains(timeOfMsg) Or timeIncrement > 9
                        timeIncrement += 1
                        timeOfMsg = timeOfMsg & timeIncrement
                    Loop
                    SortedMsgs(timeOfMsg) = msg
                    previousLineDFS0540I = False
                End If
            End If
        Loop
        FileClose(1)
        For msgPtr = 0 To SortedMsgs.Count - 1
            msg = SortedMsgs.Item(msgPtr)
            index = msg.Substring(74, 8) & " " & msg.Substring(167, 4) & " " & msg.Substring(140, 4)
            If BMPs.Contains(index) Then
                BMPs(index) += 1
            Else
                BMPs(index) = 1
            End If
        Next
        alteredText = "The Following are the counts of BMP Checkpoints :-" & Chr(13) & Chr(10)
        For linePtr = 0 To BMPs.Count - 1
            alteredText += BMPs.Item(linePtr).ToString() & " " & BMPs.Item(linePtr) & _
            Chr(13) & Chr(10)
            msgsAlteredNoOf += 1
        Next
    End Sub
End Class

