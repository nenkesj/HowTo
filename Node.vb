Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports BaseSubsystem
Imports DBAccessSubsystem

Public Class Node
    Inherits BaseClass

    Dim fldNodeID, fldTreeID, fldTypeID, fldTreeLevel, _
        fldParentNodeID As Integer
    Dim fldHeading, fldNodeText As String
    Dim AccDB As AccessDB

    Sub New()
        fldNodeID = 0
        fldTreeID = 1
        fldTypeID = 21
        fldTreeLevel = 1
        fldParentNodeID = 0
        fldHeading = ""
        fldNodeText = ""
        CreateObjects()
    End Sub

    Sub New(ByVal environment As String)
        fldNodeID = 0
        fldTreeID = 1
        fldTypeID = 21
        fldTreeLevel = 1
        fldParentNodeID = 0
        fldHeading = ""
        fldNodeText = ""
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub New(ByVal NID As Integer, ByVal TID As Integer, _
            ByVal TyID As Integer, ByVal TL As Integer, _
            ByVal PNID As Integer, ByVal H As String, ByVal NT As String)
        fldNodeID = NID
        fldTreeID = TID
        fldTypeID = TyID
        fldTreeLevel = TL
        fldParentNodeID = PNID
        fldHeading = H
        fldNodeText = NT
        CreateObjects()
    End Sub

    Sub New(ByVal NID As Integer, ByVal TID As Integer, _
            ByVal TyID As Integer, ByVal TL As Integer, _
            ByVal PNID As Integer, ByVal H As String, _
            ByVal NT As String, ByVal environment As String)
        fldNodeID = NID
        fldTreeID = TID
        fldTypeID = TyID
        fldTreeLevel = TL
        fldParentNodeID = PNID
        fldHeading = H
        fldNodeText = NT
        Me.Environment = environment
        CreateObjects()
    End Sub

    Sub CreateObjects()
        Me.AccDB = New AccessDB
        Me.AccDB.Environment = Me.Environment
    End Sub

    Public Property NodeID() As Integer
        Get
            Return fldNodeID
        End Get
        Set(ByVal Value As Integer)
            fldNodeID = Value
        End Set
    End Property

    Public Property TreeID() As Integer
        Get
            Return fldTreeID
        End Get
        Set(ByVal Value As Integer)
            fldTreeID = Value
        End Set
    End Property

    Public Property TypeID() As Integer
        Get
            Return fldTypeID
        End Get
        Set(ByVal Value As Integer)
            fldTypeID = Value
        End Set
    End Property

    Public Property TreeLevel() As Integer
        Get
            Return fldTreeLevel
        End Get
        Set(ByVal Value As Integer)
            fldTreeLevel = Value
        End Set
    End Property

    Public Property ParentNodeID() As Integer
        Get
            Return fldParentNodeID
        End Get
        Set(ByVal Value As Integer)
            fldParentNodeID = Value
        End Set
    End Property

    Public Property Heading() As String
        Get
            Return fldHeading
        End Get
        Set(ByVal Value As String)
            fldHeading = Value
        End Set
    End Property

    Public Property NodeText() As String
        Get
            Return fldNodeText
        End Get
        Set(ByVal Value As String)
            fldNodeText = Value
        End Set
    End Property

    Sub AssignFlds(ByRef AccDB As AccessDB, ByVal recd As Integer)
        If (AccDB.Succeeded) Then
            Me.NodeID = Integer.Parse(AccDB.Records(recd, 0))
            Me.TreeID = Integer.Parse(AccDB.Records(recd, 1))
            Me.TypeID = Integer.Parse(AccDB.Records(recd, 2))
            Me.ParentNodeID = Integer.Parse(AccDB.Records(recd, 3))
            Me.TreeLevel = Integer.Parse(AccDB.Records(recd, 4))
            Me.Heading = AccDB.Records(recd, 5)
            Me.NodeText = AccDB.Records(recd, 6)
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub AssignFld(ByRef AccDB As AccessDB, ByVal recd As Integer, _
            ByVal FldName As String)
        If (AccDB.Succeeded) Then
            Select Case FldName
                Case "NodeID"
                    Me.NodeID = Integer.Parse(AccDB.Records(recd, 0))
                Case "TreeID"
                    Me.TreeID = Integer.Parse(AccDB.Records(recd, 1))
                Case "TypeID"
                    Me.TypeID = Integer.Parse(AccDB.Records(recd, 2))
                Case "ParentNodeID"
                    Me.ParentNodeID = Integer.Parse(AccDB.Records(recd, 3))
                Case "TreeLevel"
                    Me.TreeLevel = Integer.Parse(AccDB.Records(recd, 4))
                Case "Heading"
                    Me.Heading = AccDB.Records(recd, 5)
                Case "NodeText"
                    Me.NodeText = AccDB.Records(recd, 6)
            End Select
        Else
            Me.AccumulateErrors(AccDB.ErrorMsgs, AccDB.NoOfErrorMsgs)
        End If
    End Sub

    Sub Check()
        Try
            Me.AccDB.SelectWithKey(Me.TypeID, "TypeID", "Types")
            If (Not Me.AccDB.Succeeded) Then
                Throw New Exception("Node Check Failed: Invalid " & _
                 "Node Type specified")
            End If
            If (Me.Heading = "") Then
                Throw New Exception("Node Check Failed: Heading " & _
                 "not specified")
            End If
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Public Sub Copy(ByRef Node As Node)
        Me.NodeID = Node.NodeID
        Me.TreeID = Node.TreeID
        Me.TypeID = Node.TypeID
        Me.ParentNodeID = Node.ParentNodeID
        Me.TreeLevel = Node.TreeLevel
        Me.Heading = Node.Heading
        Me.NodeText = Node.NodeText
    End Sub

    Sub GetNode(ByVal NodeID As Integer)
        Me.AccDB.SelectWithKey(NodeID, "NodeID", "Nodes")
        AssignFlds(Me.AccDB, 0)
    End Sub

    Public Sub Insert()

        Try
            Check()
            If (Not Me.Succeeded) Then
                Throw New Exception("Node Checks Failed")
            End If

            Me.AccDB.WorkStation = _
            CType(ConfigurationSettings.AppSettings.GetValues("WorkStation")(0), String)

            If (Me.Environment <> "Test") Then
                Me.AccDB.DBName = _
                CType(ConfigurationSettings.AppSettings.GetValues("DBName")(0), String)
            Else
                Me.AccDB.DBName = _
                CType(ConfigurationSettings.AppSettings.GetValues("tstDBName")(0), String)
            End If

            Me.AccDB.Command.CommandText = "INSERT INTO Nodes(" & _
                "TreeID, TypeID, ParentNodeID, TreeLevel, " & _
                "Heading, NodeText) " & _
                "VALUES (" & _
                "@TreeID, @TypeID, @ParentNodeID, @TreeLevel, " & _
                "@Heading, @NodeText)"
            Me.AccDB.Command.Parameters.Clear()
            Me.AccDB.Command.Parameters.Add("@TreeID", SqlDbType.SmallInt)
            Me.AccDB.Command.Parameters.Add("@TypeID", SqlDbType.SmallInt)
            Me.AccDB.Command.Parameters.Add("@ParentNodeID", SqlDbType.Int)
            Me.AccDB.Command.Parameters.Add("@TreeLevel", SqlDbType.SmallInt)
            Me.AccDB.Command.Parameters.Add("@Heading", SqlDbType.VarChar)
            Me.AccDB.Command.Parameters.Add("@NodeText", SqlDbType.Text)
            Me.AccDB.Command.Parameters("@TreeID").Value = fldTreeID
            Me.AccDB.Command.Parameters("@TypeID").Value = fldTypeID
            Me.AccDB.Command.Parameters("@ParentNodeID").Value = fldParentNodeID
            Me.AccDB.Command.Parameters("@TreeLevel").Value = fldTreeLevel
            Me.AccDB.Command.Parameters("@Heading").Value = fldHeading
            Me.AccDB.Command.Parameters("@NodeText").Value = fldNodeText
            Me.AccDB.ExecNonQuery()
        Catch
            Me.AccumulateErrors(Me.AccDB.ErrorMsgs, _
              Me.AccDB.NoOfErrorMsgs, Err.Description)
        End Try
    End Sub

    Sub GetBranchHeadings(ByVal NodeID As Integer, _
            ByRef Headings As String)
        Dim i As Integer
        Dim Current As New Node
        Dim AccDB As New AccessDB

        AccDB.SelectWithKey(NodeID, "ParentNodeID", "Nodes")
        If AccDB.NoOfRecords > 0 Then
            For i = 0 To AccDB.NoOfRecords - 1
                Current.AssignFlds(AccDB, i)
                Headings += Current.Heading & vbCrLf
                GetBranchHeadings(Current.NodeID, Headings)
            Next
        End If
    End Sub

    Sub IncreaseTreeLevel(ByVal NodeID As Integer)
        Dim i As Integer
        Dim Current As New Node
        Dim AccDB As New AccessDB
        Dim AccDB1 As New AccessDB

        AccDB1.SelectWithKey(NodeID, "ParentNodeID", "Nodes")

        Current.GetNode(NodeID)
        Current.TreeLevel = Current.TreeLevel + 1
        AccDB.UpdateFldToWithKey(Current.NodeID, "NodeID", _
            Current.TreeLevel, "TreeLevel", "Nodes")

        If AccDB1.NoOfRecords > 0 Then
            For i = 0 To AccDB1.NoOfRecords - 1
                Current.AssignFlds(AccDB1, i)
                IncreaseTreeLevel(Current.NodeID)
            Next
        End If
    End Sub

    Sub InsertNewNodeAfter(ByVal NodeID As Integer)
        Dim i, NewNodeID, NewTaskID, NewProblemID As Integer
        Dim Current As New Node
        Dim NewNode As Node
        Dim NewTask As New Task
        Dim NewAttempt As New Attempt
        Dim NewProblem As New Problem
        Dim NewObservation As Observation
        Dim AccDB As New AccessDB
        Dim AccDB1 As New AccessDB

        AccDB.SelectWithKey(NodeID, "ParentNodeID", "Nodes")

        Current.GetNode(NodeID)
        NewNode = New Node(0, Current.TreeID, Current.TypeID, _
            Current.TreeLevel + 1, Current.NodeID, "New Inserted Node", _
            "Enter Node Text Here")
        NewNode.Insert()
        AccDB1.IDOfLastInsert("Nodes")
        NewNodeID = AccDB1.IntResult

        Select Case Current.TypeID
            Case 6
                NewProblem = New Problem(0, NewNodeID, "New Problem", _
                    DateTime.Now, "None", "Enter Details Here", "iTAM", _
                    0, "Telstra", "A01")
                NewProblem.Insert()
                AccDB1.IDOfLastInsert("Problems")
                NewProblemID = AccDB1.IntResult
                NewObservation = New Observation(0, NewProblemID, _
                    "Enter Observation Description Here", _
                    "Enter Comments Here")
                NewObservation.Insert()
            Case 21
                NewTask = New Task(0, NewNodeID, "iTAM", 0, "All", "Telstra", _
                    DateTime.Now, DateTime.Now.AddMinutes(15.0))
                NewTask.Insert()
                AccDB1.IDOfLastInsert("Tasks")
                NewTaskID = AccDB1.IntResult
                NewAttempt = New Attempt(0, NewTaskID, _
                    "Enter Attempt Description Here", _
                    "Enter Outcome Description Here", _
                    False, DateTime.Now.AddMinutes(15.0))
                NewAttempt.Insert()
        End Select

        If AccDB.NoOfRecords > 0 Then
            For i = 0 To AccDB.NoOfRecords - 1
                Current.AssignFlds(AccDB, i)
                AccDB1.UpdateFldToWithKey(Current.NodeID, "NodeID", _
                    NewNodeID, "ParentNodeID", "Nodes")
                IncreaseTreeLevel(Current.NodeID)
            Next
        End If
    End Sub

    Sub InsertNewNodeBefore(ByVal NodeID As Integer)
        Dim i, NewNodeID, NewTaskID, NewProblemID As Integer
        Dim Current As New Node
        Dim NewNode As Node
        Dim NewTask As New Task
        Dim NewAttempt As New Attempt
        Dim NewProblem As New Problem
        Dim NewObservation As Observation
        Dim AccDB As New AccessDB
        Dim AccDB1 As New AccessDB

        AccDB.SelectWithKey(NodeID, "ParentNodeID", "Nodes")

        Current.GetNode(NodeID)

        NewNode = New Node(0, Current.TreeID, Current.TypeID, _
            Current.TreeLevel, Current.ParentNodeID, "New Inserted Node", _
            "Enter Node Text Here")
        NewNode.Insert()
        AccDB1.IDOfLastInsert("Nodes")
        NewNodeID = AccDB1.IntResult
        AccDB1.UpdateFldToWithKey(Current.NodeID, "NodeID", _
            NewNodeID, "ParentNodeID", "Nodes")
        AccDB1.UpdateFldToWithKey(Current.NodeID, "NodeID", _
            Current.TreeLevel + 1, "TreeLevel", "Nodes")

        Select Case Current.TypeID
            Case 6
                NewProblem = New Problem(0, NewNodeID, "New Problem", _
                    DateTime.Now, "None", "Enter Details Here", "iTAM", _
                    0, "Telstra", "A01")
                NewProblem.Insert()
                AccDB1.IDOfLastInsert("Problems")
                NewProblemID = AccDB1.IntResult
                NewObservation = New Observation(0, NewProblemID, _
                    "Enter Observation Description Here", _
                    "Enter Comments Here")
                NewObservation.Insert()
            Case 21
                NewTask = New Task(0, NewNodeID, "iTAM", 0, "All", "Telstra", _
                    DateTime.Now, DateTime.Now.AddMinutes(15.0))
                NewTask.Insert()
                AccDB1.IDOfLastInsert("Tasks")
                NewTaskID = AccDB1.IntResult
                NewAttempt = New Attempt(0, NewTaskID, _
                    "Enter Attempt Description Here", _
                    "Enter Outcome Description Here", _
                    False, DateTime.Now.AddMinutes(15.0))
                NewAttempt.Insert()
        End Select

        If AccDB.NoOfRecords > 0 Then
            For i = 0 To AccDB.NoOfRecords - 1
                Current.AssignFlds(AccDB, i)
                IncreaseTreeLevel(Current.NodeID)
            Next
        End If
    End Sub

    Sub CopyNodes(ByVal NodeID As Integer, ByVal ParentNodeID As Integer)
        Dim i, NewNodeID, NewTaskID, NewAttemptID, NewProblemID As Integer
        Dim CurrentNode As New Node
        Dim NewNode As New Node
        Dim CurrentTask As New Task
        Dim NewTask As New Task
        Dim CurrentKey As New SearchKey
        Dim NewKey As New SearchKey
        Dim NewAttempt As New Attempt
        Dim CurrentProblem As New Problem
        Dim NewProblem As New Problem
        Dim CurrentObservation As New Observation
        Dim NewObservation As New Observation
        Dim AccDB As New AccessDB
        Dim AccDB1 As New AccessDB

        CurrentNode.GetNode(NodeID)
        NewNode.Copy(CurrentNode)
        NewNode.ParentNodeID = ParentNodeID
        NewNode.Insert()
        AccDB1.IDOfLastInsert("Nodes")
        NewNodeID = AccDB1.IntResult

        AccDB1.SelectWithKey(NodeID, "NodeID", "Keys")
        If AccDB1.NoOfRecords > 0 Then
            For i = 0 To AccDB1.NoOfRecords - 1
                CurrentKey.AssignFlds(AccDB1, i)
                NewKey.Copy(CurrentKey)
                NewKey.NodeID = NewNodeID
                NewKey.Insert()
            Next
        End If

        Select Case CurrentNode.TypeID
            Case 6
                AccDB1.SelectWithKey(NodeID, "NodeID", "Problems")
                CurrentProblem.AssignFlds(AccDB1, 0)
                NewProblem.Copy(CurrentProblem)
                NewProblem.Occurred = DateTime.Now
                NewProblem.ProblemNo = "0"
                NewProblem.NodeID = NewNodeID
                NewProblem.Insert()
                AccDB1.IDOfLastInsert("Problems")
                NewProblemID = AccDB1.IntResult
                NewObservation = New Observation(0, _
                    NewProblemID, _
                    "Enter Observation Description Here", _
                    "Enter Comments Here")
                NewObservation.Insert()
            Case 21
                AccDB1.SelectWithKey(NodeID, "NodeID", "Tasks")
                CurrentTask.AssignFlds(AccDB1, 0)
                NewTask.Copy(CurrentTask)
                NewTask.RequestNo = "0"
                NewTask.StartedOn = DateTime.Now
                NewTask.CompletedOn = "January 1, 1753"
                NewTask.NodeID = NewNodeID
                NewTask.Insert()
                AccDB1.IDOfLastInsert("Tasks")
                NewTaskID = AccDB1.IntResult
                NewAttempt = New Attempt(0, _
                    NewTaskID, _
                    "Enter Attempt Description Here", _
                    "Enter Outcome Description Here", _
                    False, _
                    "January 1, 1753")
                NewAttempt.Insert()
        End Select

        AccDB.SelectWithKey(NodeID, "ParentNodeID", "Nodes")
        If AccDB.NoOfRecords > 0 Then
            For i = 0 To AccDB.NoOfRecords - 1
                CurrentNode.AssignFlds(AccDB, i)
                CopyNodes(CurrentNode.NodeID, NewNodeID)
            Next
        End If
    End Sub

    Sub MergeNodeTxt(ByVal NodeID As Integer, ByVal FileWhat As String, ByRef CumText As String)
        Dim CurrentNode As New Node
        Dim CurrentTask As New Task
        Dim CurrentAttempt As New Attempt
        Dim CurrentProblem As New Problem
        Dim CurrentObservation As New Observation
        Dim AccDB As New AccessDB
        Dim AccDB1 As New AccessDB
        Dim i, j, k, l As Integer
        AccDB.SelectWithKey(NodeID, "ParentNodeID", "Nodes")
        If AccDB.NoOfRecords > 0 Then
            For i = 0 To AccDB.NoOfRecords - 1
                CurrentNode.AssignFlds(AccDB, i)
                j = i + 1
                CumText = CumText & vbCrLf & _
                          CurrentNode.TreeLevel.ToString & "." & _
                          j.ToString & " " & CurrentNode.Heading & vbCrLf
                If FileWhat = "All" Or FileWhat = "Outcomes" Or FileWhat = "Details" Then
                    CumText = CumText & vbCrLf & CurrentNode.NodeText & vbCrLf
                End If
                If FileWhat = "All" Or FileWhat = "Outcomes" Then
                    AccDB1.SelectWithKey(CurrentNode.NodeID, "NodeID", "Tasks")
                    CurrentTask.AssignFlds(AccDB1, 0)
                    AccDB1.SelectWithKey(CurrentTask.TaskID, "TaskID", "Attempts")
                    CurrentAttempt.AssignFlds(AccDB1, 0)
                    If AccDB1.NoOfRecords > 0 Then
                        For k = 0 To AccDB1.NoOfRecords - 1
                            CurrentAttempt.AssignFlds(AccDB1, k)
                            l = k + 1
                            If CurrentAttempt.AttemptCompletedOn.ToString = "1/01/1753 12:00:00 AM" Then
                                CumText = CumText & vbCrLf & "OutCome: " & _
                                          l.ToString & ". " & vbCrLf
                            Else
                                CumText = CumText & vbCrLf & "OutCome: " & _
                                          l.ToString & ". " & "Completed On - " & _
                                          CurrentAttempt.AttemptCompletedOn.ToString & _
                                          vbCrLf
                            End If
                            CumText = CumText & vbCrLf & _
                                      CurrentAttempt.Outcome.ToString & vbCrLf
                            If FileWhat = "All" Then
                                CumText = CumText & vbCrLf & "Attempt: " & _
                                          l.ToString & ". " & vbCrLf
                                CumText = CumText & vbCrLf & _
                                          CurrentAttempt.Attempt.ToString & vbCrLf
                            End If
                        Next
                    End If
                End If
            Next
        End If
        If AccDB.NoOfRecords > 0 Then
            For i = 0 To AccDB.NoOfRecords - 1
                CurrentNode.AssignFlds(AccDB, i)
                MergeNodeTxt(CurrentNode.NodeID, FileWhat, CumText)
            Next
        End If
    End Sub

End Class


