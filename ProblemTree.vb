Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing

Public Class ProblemTree
    Inherits Tree

    Sub New(ByRef daNodes As System.Data.SqlClient.SqlDataAdapter, _
            ByRef daKeys As System.Data.SqlClient.SqlDataAdapter, _
            ByRef daKeysDistinct As System.Data.SqlClient.SqlDataAdapter, _
            ByRef daProblems As System.Data.SqlClient.SqlDataAdapter, _
            ByRef daObservations As System.Data.SqlClient.SqlDataAdapter, _
            ByRef daNodesProblemsJoin As System.Data.SqlClient.SqlDataAdapter, _
            ByRef daCategories As System.Data.SqlClient.SqlDataAdapter, _
            ByRef dsNodes As System.Data.DataSet, _
            ByRef dsKeys As System.Data.DataSet, _
            ByRef dsKeysDistinct As System.Data.DataSet, _
            ByRef dsProblems As System.Data.DataSet, _
            ByRef dsObservations As System.Data.DataSet, _
            ByRef dsNodesProblemsJoin As System.Data.DataSet, _
            ByRef dsCategories As System.Data.DataSet, _
            ByRef dvNodes As System.Data.DataView, _
            ByRef dvKeys As System.Data.DataView, _
            ByRef dvKeysDistinct As System.Data.DataView, _
            ByRef dvCategories As System.Data.DataView, _
            ByRef dtNodes As System.Data.DataTable, _
            ByRef dtTempNodes As System.Data.DataTable, _
            ByRef dtKeys As System.Data.DataTable, _
            ByRef dtKeysDistinct As System.Data.DataTable, _
            ByRef dtCategories As System.Data.DataTable, _
            ByRef lbxNodes As Object, _
            ByRef lbxKeys As Object, _
            ByRef drpKeys As Object, _
            ByRef drpFilterOn As Object, _
            ByRef drpSearchOn As Object, _
            ByRef drpTxtType As Object, _
            ByRef drpTxtOpr As Object, _
            ByRef btnUp As Object, _
            ByRef btnDown As Object, _
            ByRef btnSummary As Object, _
            ByRef btnRefresh As Object, _
            ByRef btnEdit As Object, _
            ByRef btnNew As Object, _
            ByRef btnNewChild As Object, _
            ByRef btnSave As Object, _
            ByRef btnAddKeyWord As Object, _
            ByRef btnSaveObservation As Object, _
            ByRef btnPrevObservation As Object, _
            ByRef btnNextObservation As Object, _
            ByRef btnGo As Object, _
            ByRef btnBackOut As Object, _
            ByRef btnSearch As Object, _
            ByRef btnSrchBack As Object, _
            ByRef txtFilterText As Object, _
            ByRef txtSearchFilter As Object, _
            ByRef txtKeyWord As Object, _
            ByRef txtHeading As Object, _
            ByRef txtType As Object, _
            ByRef txtNo As Object, _
            ByRef txtWhen As Object, _
            ByRef txtWhere As Object, _
            ByRef txtClient As Object, _
            ByRef txtImpacts As Object, _
            ByRef txtNodeText As Object, _
            ByRef txtDetails As Object, _
            ByRef txtComments As Object, _
            ByRef txtObservations As Object, _
            ByRef txtTxtSpecs As Object)
        MyBase.New(daNodes, _
           daKeys, _
           daKeysDistinct, _
           dsNodes, _
           dsKeys, _
           dsKeysDistinct, _
           dtNodes, _
           dtTempNodes, _
           dtKeys, _
           dtKeysDistinct, _
           dvNodes, _
           dvKeys, _
           dvKeysDistinct, _
           lbxNodes, _
           lbxKeys, _
           drpKeys, _
           drpFilterOn, _
           txtFilterText, _
           txtKeyWord, _
           txtHeading, _
           txtNodeText, _
           txtSearchFilter, _
           drpSearchOn, _
           btnRefresh, _
           btnEdit, _
           btnNew, _
           btnNewChild, _
           btnSave, _
           btnAddKeyWord, _
           btnSearch, _
           btnSrchBack, _
           btnUp, _
           btnDown, _
           btnSummary)
        problemdaNodes = daNodes
        problemdaKeys = daKeys
        problemdaKeysDistinct = daKeysDistinct
        problemdaProblems = daProblems
        problemdaObservations = daObservations
        problemdaNodesProblemsJoin = daNodesProblemsJoin
        problemdaCategories = daCategories
        problemdsNodes = dsNodes
        problemdsKeys = dsKeys
        problemdsKeysDistinct = dsKeysDistinct
        problemdsProblems = dsProblems
        problemdsObservations = dsObservations
        problemdsNodesProblemsJoin = dsNodesProblemsJoin
        problemdsCategories = dsCategories
        problemdvNodes = dvNodes
        problemdvKeys = dvKeys
        problemdvKeysDistinct = dvKeysDistinct
        problemdvCategories = dvCategories
        problemdtNodes = dtNodes
        problemdtTempNodes = dtTempNodes
        problemdtKeys = dtKeys
        problemdtKeysDistinct = dtKeysDistinct
        problemdtCategories = dtCategories
        problemlbxNodes = lbxNodes
        problemlbxKeys = lbxKeys
        problemdrpKeys = drpKeys
        problemdrpFilterOn = drpFilterOn
        problemdrpSearchOn = drpSearchOn
        problemdrpTxtType = drpTxtType
        problemdrpTxtOpr = drpTxtOpr
        problembtnUp = btnUp
        problembtnDown = btnDown
        problembtnSummary = btnSummary
        problembtnRefresh = btnRefresh
        problembtnEdit = btnEdit
        problembtnNew = btnNew
        problembtnNewChild = btnNewChild
        problembtnSave = btnSave
        problembtnAddKeyWord = btnAddKeyWord
        problembtnSaveObservation = btnSaveObservation
        problembtnPrevObservation = btnPrevObservation
        problembtnNextObservation = btnNextObservation
        problembtnGo = btnGo
        problembtnBackOut = btnBackOut
        problembtnSearch = btnSearch
        problembtnSrchBack = btnSrchBack
        problemtxtFilterText = txtFilterText
        problemtxtSearchFilter = txtSearchFilter
        problemtxtKeyWord = txtKeyWord
        problemtxtHeading = txtHeading
        problemtxtType = txtType
        problemtxtNo = txtNo
        problemtxtWhen = txtWhen
        problemtxtWhere = txtWhere
        problemtxtClient = txtClient
        problemtxtImpacts = txtImpacts
        problemtxtNodeText = txtNodeText
        problemtxtDetails = txtDetails
        problemtxtComments = txtComments
        problemtxtObservations = txtObservations
        problemtxtTitle = txtHeading
        problemtxtSolution = txtNodeText
        problemtxtTxtSpecs = txtTxtSpecs
    End Sub

    Public Property ObservationOperation() As String
        Get
            Return problemObservationOperation
        End Get
        Set(ByVal Value As String)
            problemObservationOperation = Value
        End Set
    End Property

    Public Property ObservationText() As String
        Get
            Return problemObservationText
        End Get
        Set(ByVal Value As String)
            problemObservationText = Value
        End Set
    End Property

    Public Property ObservationAlteredText() As String
        Get
            Return problemObservationAlteredText
        End Get
        Set(ByVal Value As String)
            problemObservationAlteredText = Value
        End Set
    End Property

    Public Property ObservationTextLength() As Integer
        Get
            Return problemObservationTextLength
        End Get
        Set(ByVal Value As Integer)
            problemObservationTextLength = Value
        End Set
    End Property

    Public Property ObservationTextNoOfLines() As Integer
        Get
            Return problemObservationTextNoOfLines
        End Get
        Set(ByVal Value As Integer)
            problemObservationTextNoOfLines = Value
        End Set
    End Property

    Public Property ObservationTextNoOfMsgs() As Integer
        Get
            Return problemObservationTextNoOfMsgs
        End Get
        Set(ByVal Value As Integer)
            problemObservationTextNoOfMsgs = Value
        End Set
    End Property

    Public Property ObservationAlteredTextLength() As Integer
        Get
            Return problemObservationAlteredTextLength
        End Get
        Set(ByVal Value As Integer)
            problemObservationAlteredTextLength = Value
        End Set
    End Property

    Public Property ObservationAlteredTextNoOfLines() As Integer
        Get
            Return problemObservationAlteredTextNoOfLines
        End Get
        Set(ByVal Value As Integer)
            problemObservationAlteredTextNoOfLines = Value
        End Set
    End Property

    Public Property ObservationAlteredTextNoOfMsgs() As Integer
        Get
            Return problemObservationAlteredTextNoOfMsgs
        End Get
        Set(ByVal Value As Integer)
            problemObservationAlteredTextNoOfMsgs = Value
        End Set
    End Property

    Public Property ObservationTextType() As String
        Get
            Return problemObservationTextType
        End Get
        Set(ByVal Value As String)
            problemObservationTextType = Value
        End Set
    End Property

    Public Property ObservationTextOpr() As String
        Get
            Return problemObservationTextOpr
        End Get
        Set(ByVal Value As String)
            problemObservationTextOpr = Value
        End Set
    End Property

    Public Property ObservationTextSpecs() As String
        Get
            Return problemObservationTextSpecs
        End Get
        Set(ByVal Value As String)
            problemObservationTextSpecs = Value
        End Set
    End Property

    Public Property ObservationCommentSuffix() As String
        Get
            Return problemObservationCommentSuffix
        End Get
        Set(ByVal Value As String)
            problemObservationCommentSuffix = Value
        End Set
    End Property

    Public Property ObservationCommentSaved() As String
        Get
            Return problemObservationCommentSaved
        End Get
        Set(ByVal Value As String)
            problemObservationCommentSaved = Value
        End Set
    End Property

    Dim problemdaNodes, problemdaKeys, problemdaKeysDistinct As System.Data.SqlClient.SqlDataAdapter
    Dim problemdaProblems, problemdaObservations, problemdaNodesProblemsJoin As System.Data.SqlClient.SqlDataAdapter
    Dim problemdaCategories As System.Data.SqlClient.SqlDataAdapter
    Dim problemdsNodes, problemdsKeys, problemdsKeysDistinct As System.Data.DataSet
    Dim problemdsProblems, problemdsObservations, problemdsNodesProblemsJoin As System.Data.DataSet
    Dim problemdsCategories As System.Data.DataSet
    Dim problemdvNodes, problemdvKeys, problemdvKeysDistinct, problemdvCategories As System.Data.DataView
    Dim problemdtNodes, problemdtTempNodes, problemdtKeys, problemdtKeysDistinct, problemdtCategories As System.Data.DataTable

    Dim problemlbxNodes, problemlbxKeys, _
        problemdrpFilterOn, problemdrpSearchOn, problemdrpKeys, _
        problemdrpTxtType, problemdrpTxtOpr, _
        problemtxtHeading, problemtxtNodeText, problemtxtKeyWord, _
        problemtxtFilterText, problemtxtSearchFilter, _
        problemtxtTitle, problemtxtSolution, problemtxtType, _
        problemtxtNo, problemtxtWhen, problemtxtWhere, _
        problemtxtClient, problemtxtImpacts, problemtxtDetails, _
        problemtxtComments, problemtxtObservations, problemtxtTxtSpecs, _
        problembtnRefresh, problembtnEdit, problembtnNew, problembtnNewChild, problembtnSave, problembtnAddKeyWord, problembtnSaveObservation, _
        problembtnPrevObservation, problembtnNextObservation, _
        problembtnUp, problembtnDown, problembtnSummary, problembtnGo, problembtnBackOut, problembtnSearch, problembtnSrchBack As Object

    Dim problemSelectedKey, problemSearchFilter, problemNodeFilter, _
    problemOperation, problemNodeSelectCmd, problemSelectCmd, _
    problemObservationOperation, problemObservationTextType, problemObservationTextOpr, _
    problemObservationTextSpecs, problemObservationText, problemObservationAlteredText, _
    problemObservationCommentSaved, problemObservationCommentSuffix As String

    Dim problemSelectedNode, problemParentNode, problemCurrentLevel, _
    problemCurrentTree, problemObservationTextLength, problemObservationAlteredTextLength, _
    problemObservationTextNoOfLines, problemObservationTextNoOfMsgs, _
    problemObservationAlteredTextNoOfLines, problemObservationAlteredTextNoOfMsgs As Integer

    Public Overrides Sub BindNodes(ByVal Clear As Boolean, ByVal Fill As Boolean, _
        ByVal Bind As Boolean)
        'Subs called:- SetNodeFilter
        'Properties Altered:- None
        ' Clear datasets
        If Clear Then
            problemdsNodes.Clear()
            problemdsProblems.Clear()
            problemdsObservations.Clear()
            problemdsNodesProblemsJoin.Clear()
            'problemdsCategories.Clear()
        End If
        ' Fill datasets
        If Fill Then
            problemdaNodes.Fill(problemdsNodes)
            problemdaProblems.Fill(problemdsProblems)
            problemdaObservations.Fill(problemdsObservations)
            problemdaNodesProblemsJoin.SelectCommand.CommandText = NodeSelectCmd
            problemdaNodesProblemsJoin.Fill(problemdsNodesProblemsJoin)
            'problemdaCategories.SelectCommand.Parameters("@Category").Value = "Text Type"
            'problemdaCategories.Fill(problemdsCategories)
        End If
        ' Bind control
        If Bind Then
            'SetNodeFilter("Heading", "Heading DESC")
            problemlbxNodes.DataBind()
            problemdrpTxtOpr.DataBind()
        End If
    End Sub

    Public Sub BindCategories(ByVal Clear As Boolean, ByVal Fill As Boolean, _
        ByVal Bind As Boolean)
        'Subs called:- SetNodeFilter
        'Properties Altered:- None
        ' Clear datasets
        If Clear Then
            problemdsCategories.Clear()
        End If
        ' Fill datasets
        If Fill Then
            problemdaCategories.SelectCommand.Parameters("@Category").Value = "Text Type"
            problemdaCategories.Fill(problemdsCategories)
        End If
        ' Bind control
        If Bind Then
            problemdrpTxtOpr.DataBind()
        End If
    End Sub

    Public Overrides Sub NodeChanged()
        'Subs called:- DisplayProblem InitPageProblem DisplayObservation 
        'InitPageObservation 
        'Properties Altered:- Item
        Dim drFound() As System.Data.DataRow
        Dim dr As System.Data.DataRow
        Dim SelectExpression As String
        Dim i, SelNode As Integer
        MyBase.NodeChanged()
        ' Set OI to 0 whenever we display a new node
        Item = 0
        ' So that we only look this up once
        SelNode = SelectedNode
        ' Retrieve & display problem associated with this node (node to problem is 1 to 1)
        SelectExpression = "NodeID = " & SelNode
        drFound = problemdsProblems.Tables(0).Select(SelectExpression)
        DisplayProblem(0, drFound)
        InitPageProblem("Browse")
        ' Retrieve the Observation table row that points to this Node (Observation to node 
        ' is many to 1 but we just display the 1st Observation the user can scroll through 
        ' the Attempts if there is more than one)
        dr = drFound(0)
        SelectExpression = "ProblemID = " & dr("ProblemID")
        drFound = problemdsObservations.Tables(0).Select(SelectExpression)
        DisplayObservation(0, drFound)
        InitPageObservation("Browse")
        ' Enable Next Observation Button if more than one disable Prev
        If drFound.Length > 1 Then
            problembtnNextObservation.Enabled = True
            problembtnNextObservation.ImageUrl = "images\Icons\Forward.png"
        Else
            problembtnNextObservation.Enabled = False
            problembtnNextObservation.ImageUrl = "images\Icons\Forward_Disabled.png"
        End If
        problembtnPrevObservation.Enabled = False
        problembtnPrevObservation.ImageUrl = "images\Icons\Back_Disabled.png"
        ' Does the Selected Node have any children? If so enable the 
        ' down Button
        SelectExpression = "ParentNodeID = " & SelNode
        drFound = problemdsNodes.Tables(0).Select(SelectExpression)
        If drFound.Length() > 0 Then
            problembtnDown.Enabled = True
            problembtnDown.ImageUrl = "images\Icons\Down.png"
        Else
            problembtnDown.Enabled = False
            problembtnDown.ImageUrl = "images\Icons\Down_Disabled.png"
        End If
        ' Enable the Up button if not at the top level
        If CurrentLevel > 1 Then
            problembtnUp.Enabled = True
            problembtnUp.ImageUrl = "images\Icons\Up.png"
        Else
            problembtnUp.Enabled = False
            problembtnUp.ImageUrl = "images\Icons\Up_Disabled.png"
        End If
    End Sub

    Public Overrides Sub Refresh()
        'Subs called:- BindNodes NodeChanged
        'Properties Altered:- NodeFilter
        ' This calls:- 
        Dim AndFilter As String
        ' If nothing in the node filter dont prefix it with an AND
        If NodeFilter = "" Then
            AndFilter = ""
        Else
            AndFilter = " AND "
        End If
        ' Add to node filter as specified by the user, clear resets the 
        ' node filter
        Select Case problemdrpFilterOn.SelectedItem.Text
            Case "Client"
                NodeFilter += AndFilter & _
                    "Client = '" & problemtxtFilterText.Text & "'"
            Case "Impacts"
                NodeFilter += AndFilter & _
                    "Impacts = '" & problemtxtFilterText.Text & "'"
            Case "Where"
                NodeFilter += AndFilter & _
                    "Lpar = '" & problemtxtFilterText.Text & "'"
            Case "Type"
                NodeFilter += AndFilter & _
                    "ProblemSystem = '" & problemtxtFilterText.Text & "'"
            Case "Title"
                NodeFilter += AndFilter & _
                    "Title LIKE '*" & problemtxtFilterText.Text & "*'"
            Case "When >="
                ' Date Filter for DataViews has to be in mm/dd/yyyy format
                NodeFilter += AndFilter & _
                    "Occurred >= #" & _
                    problemtxtFilterText.Text.Substring(3, 2) & "/" & _
                    problemtxtFilterText.Text.Substring(0, 2) & "/" & _
                    problemtxtFilterText.Text.Substring(6, 4) & "#"
            Case "When <"
                ' Date Filter for DataViews has to be in mm/dd/yyyy format
                NodeFilter += AndFilter & _
                    "Occurred < #" & _
                    problemtxtFilterText.Text.Substring(3, 2) & "/" & _
                    problemtxtFilterText.Text.Substring(0, 2) & "/" & _
                    problemtxtFilterText.Text.Substring(6, 4) & "#"
            Case "No."
                NodeFilter += AndFilter & _
                    "ProblemNo = " & _
                    Integer.Parse(problemtxtFilterText.Text)
            Case Else
                NodeFilter = "ParentNodeID = 0"
                problemtxtFilterText.Text = ""
        End Select
        BindNodes(False, False, True)
        NodeChanged()
    End Sub

    Public Overrides Sub NewNode()
        'Subs called:- InitPage DisplayNewNode InitPageObservation
        'DisplayNewObservation InitPageProblem DisplayNewProblem
        'Properties Altered:- None
        InitPage("New")
        DisplayNewNode()
        InitPageObservation("New")
        DisplayNewObservation()
        ' Does problem after observation as problem disables observation
        ' save, prev & next buttons
        InitPageProblem("New")
        DisplayNewProblem()
    End Sub

    Public Sub Edit()
        'Subs called:- InitPage InitPageProblem InitPageObservation
        'Properties Altered:- None
        ' Note page is already display so dont need to call DisplayNode
        InitPage("Edit")
        InitPageProblem("Edit")
        InitPageObservation("Browse")
    End Sub

    Public Overrides Sub Save()
        'Subs called:- CreateNewNode CreateNewProblem CreateNewObservation
        'BindNodes NodeChanged UpdateNode UpdateProblem InitPage
        'InitPageProblem InitPageObservation
        'Properties Altered:- SavedYet
        Dim drFound() As System.Data.DataRow
        Dim dr As System.Data.DataRow
        Dim SelectExpression As String
        Dim RecordID, ProblemNodeID As Integer
        Select Case Operation
            Case "New"
                'Create the new node
                RecordID = CreateNewNode()
                ' Selected Node changes to the new child
                SelectedNode = RecordID
                ' Create new problem entry
                RecordID = CreateNewProblem(RecordID)
                ' Create new observation
                RecordID = CreateNewObservation(RecordID)
                ' Refresh the node listbox to include the new node
                BindNodes(True, True, True)
                SavedYet = True
                NodeChanged()
            Case "Edit"
                ' Retrieve node row
                SelectExpression = "NodeID = " & SelectedNode
                drFound = problemdsNodes.Tables(0).Select(SelectExpression)
                UpdateNode(0, drFound)
                ' Retrieve & Update the problem associated with this node
                ' (Problem to Node is 1 to 1)
                drFound = problemdsProblems.Tables(0).Select(SelectExpression)
                UpdateProblem(0, drFound)
                ' Go back to browse mode when save button clicked after 
                ' editing, observation not required as it is edited 
                ' separately
                InitPage("Browse")
                SavedYet = True
                InitPageProblem("Browse")
                InitPageObservation("Browse")
        End Select
    End Sub

    ' Search Tool Buttons

    Public Overrides Sub Search()
        'Subs called:- BindNodes NodeChanged
        'Properties Altered:- NodeSelectCmd
        ' Only display nodes that match the keys entered
        NodeSelectCmd = DefaultSelectCmd & _
            " WHERE Nodes.NodeID IN (" & _
            "SELECT Keys.NodeID FROM Keys WHERE KeyText = '" & _
            SelectedKey & "' AND TreeID = " & CurrentTree & ")"
        ' Rebind the Notes Control (Clear, Fill & Bind)
        BindNodes(True, True, True)
        NodeChanged()
    End Sub

    ' Observation Buttons

    Public Sub PrevObservation()
        'Subs called:- DisplayObservation InitPageObservation
        'Properties Altered:- Item
        Dim drFound() As System.Data.DataRow
        Dim dr As System.Data.DataRow
        Dim SelectExpression As String
        ' Get ProblemID
        SelectExpression = "NodeID = " & SelectedNode
        drFound = problemdsProblems.Tables(0).Select(SelectExpression)
        dr = drFound(0)
        ' Retrieve & display previous observation
        SelectExpression = "ProblemID = " & dr("ProblemID")
        drFound = problemdsObservations.Tables(0).Select(SelectExpression)
        Item -= 1
        DisplayObservation(Item, drFound)
        ' Disable Prev button if now at observation 0
        If Item = 0 Then
            problembtnPrevObservation.Enabled = False
            problembtnPrevObservation.ImageUrl = "images\Icons\Back_Disabled.png"
        Else
            problembtnPrevObservation.Enabled = True
            problembtnPrevObservation.ImageUrl = "images\Icons\Back.png"
        End If
        ' Enable Next Observation button
        problembtnNextObservation.Enabled = True
        problembtnNextObservation.ImageUrl = "images\Icons\Forward.png"
        InitPageObservation("Browse")
    End Sub

    Public Sub NextObservation()
        'Subs called:- DisplayObservation InitPageObservation
        'Properties Altered:- Item
        Dim drFound() As System.Data.DataRow
        Dim dr As System.Data.DataRow
        Dim SelectExpression As String
        Dim UpperBound As Integer
        ' Get Problem
        SelectExpression = "NodeID = " & SelectedNode
        drFound = problemdsProblems.Tables(0).Select(SelectExpression)
        dr = drFound(0)
        ' Get number of observations
        SelectExpression = "ProblemID = " & dr("ProblemID")
        drFound = problemdsObservations.Tables(0).Select(SelectExpression)
        UpperBound = drFound.Length - 1
        ' Get the next observation
        Item += 1
        ' Display Observation
        DisplayObservation(Item, drFound)
        ' Disable Next button if now at upperbound
        If Item = UpperBound Then
            problembtnNextObservation.Enabled = False
            problembtnNextObservation.ImageUrl = "images\Icons\Forward_Disabled.png"
        Else
            problembtnNextObservation.Enabled = True
            problembtnNextObservation.ImageUrl = "images\Icons\Forward.png"
        End If
        ' Enable Prev button
        problembtnPrevObservation.Enabled = True
        problembtnPrevObservation.ImageUrl = "images\Icons\Back.png"
        InitPageObservation("Browse")
    End Sub

    Public Sub NewObservation()
        'Subs called:- InitPageObservation DisplayNewObservation
        'Properties Altered:- None
        InitPageObservation("New")
        DisplayNewObservation()
    End Sub

    Public Sub EditObservation()
        'Subs called:- InitPageObservation
        'Properties Altered:- None
        InitPageObservation("Edit")
    End Sub

    Public Sub SaveObservation()
        'Subs called:- CreateNewObservation InitPageObservation
        'UpdateObservation
        'Properties Altered:- Item
        Dim dr As System.Data.DataRow
        Dim drFound() As System.Data.DataRow
        Dim SelectExpression As String
        Dim ProblemID, ObservationID, UpperBound As Integer
        Select Case ObservationOperation
            Case "New"
                ' Get Problem associated with selected node
                SelectExpression = "NodeID = " & SelectedNode
                drFound = problemdsProblems.Tables(0).Select(SelectExpression)
                dr = drFound(0)
                ObservationID = CreateNewObservation(dr("ProblemID"))
                ' Get observations including new one
                SelectExpression = "ProblemID = " & dr("ProblemID")
                drFound = problemdsObservations.Tables(0).Select(SelectExpression)
                ' Set Observation to new one which will be the last
                Item = drFound.Length - 1
                ' Enable Prev button if more than one observation
                If Item > 0 Then
                    problembtnPrevObservation.Enabled = True
                    problembtnPrevObservation.ImageUrl = "images\Icons\Back.png"
                Else
                    problembtnPrevObservation.Enabled = False
                    problembtnPrevObservation.ImageUrl = "images\Icons\Back_Disabled.png"
                End If
                problembtnNextObservation.Enabled = False
                problembtnNextObservation.ImageUrl = "images\Icons\Forward_Disabled.png"
                ' Disable Save buttons etc. after save complete
                InitPageObservation("Browse")
            Case "Edit"
                ' Get problem associated with selected node
                SelectExpression = "NodeID = " & SelectedNode
                drFound = problemdsProblems.Tables(0).Select(SelectExpression)
                dr = drFound(0)
                ' Get observations associated with this problem
                SelectExpression = "ProblemID = " & dr("ProblemID")
                drFound = problemdsObservations.Tables(0).Select(SelectExpression)
                ' Update currently displayed Observation
                UpdateObservation(Item, drFound)
                ' Disable Save buttons etc. after edit complete
                InitPageObservation("Browse")
        End Select
    End Sub

    Public Sub ObservationTextOperation()
        'Subs called:- 
        'Properties Altered:-
        Dim problemObservationLines As Lines
        Dim problemObservationSyslog As SYSLOG
        Dim problemObservationJesmsglg As JESMSGLG
        Dim problemObservationDisregact As DisplayRegionActive
        Select Case problemObservationTextType
            Case "Lines"
                problemObservationLines = New Lines
                problemObservationLines.TheText = problemObservationText
                problemObservationLines.NoOfChars = problemObservationTextLength
                problemObservationLines.SearchText = problemObservationTextSpecs
                Select Case problemObservationTextOpr
                    Case "Only With"
                        problemObservationLines.OnlyLines("With")
                    Case "Only Without"
                        problemObservationLines.OnlyLines("Without")
                    Case "Sort"
                        problemObservationLines.Sort(0, 10)
                    Case "Remove Column"
                        problemObservationLines.RemoveColumnFromAll(0, 10)
                End Select
                problemObservationAlteredText = problemObservationLines.TheAlteredText
                problemObservationAlteredTextLength = problemObservationLines.TheAlteredText.Length
                problemObservationAlteredTextNoOfLines = problemObservationLines.AlteredNoOfLines
            Case "SYSLOG"
                problemObservationSyslog = New SYSLOG
                problemObservationSyslog.TheText = problemObservationText
                problemObservationSyslog.NoOfChars = problemObservationTextLength
                problemObservationSyslog.SearchText = problemObservationTextSpecs
                Select Case problemObservationTextOpr
                    Case "Only With"
                        problemObservationSyslog.OnlyMsgs("With")
                    Case "Only Without"
                        problemObservationSyslog.OnlyMsgs("Without")
                    Case "Sort"
                        problemObservationSyslog.Sort(5, 17)
                    Case "Format"
                        problemObservationSyslog.Format()
                    Case "Process File"
                        problemObservationSyslog.ProcessFile()
                    Case "Check BMPs"
                        problemObservationSyslog.ChkBMPs()
                End Select
                problemObservationAlteredText = problemObservationSyslog.TheAlteredText
                problemObservationAlteredTextLength = problemObservationSyslog.TheAlteredText.Length
                problemObservationAlteredTextNoOfMsgs = problemObservationSyslog.AlteredNoOfMsgs
                problemObservationCommentSuffix = problemObservationSyslog.CommentSuffix
            Case "JESMSGLG"
                problemObservationJesmsglg = New JESMSGLG
                problemObservationJesmsglg.TheText = problemObservationText
                problemObservationJesmsglg.NoOfChars = problemObservationTextLength
                problemObservationJesmsglg.SearchText = problemObservationTextSpecs
                Select Case problemObservationTextOpr
                    Case "Only With"
                        problemObservationJesmsglg.OnlyMsgs("With")
                    Case "Only Without"
                        problemObservationJesmsglg.OnlyMsgs("Without")
                    Case "Sort"
                        problemObservationJesmsglg.Sort(1, 8)
                    Case "Process File"
                        problemObservationJesmsglg.ProcessFile()
                    Case "Check BMPs"
                        problemObservationJesmsglg.ChkBMPs()
                End Select
                problemObservationAlteredText = problemObservationJesmsglg.TheAlteredText
                problemObservationAlteredTextLength = problemObservationJesmsglg.TheAlteredText.Length
                problemObservationAlteredTextNoOfMsgs = problemObservationJesmsglg.AlteredNoOfMsgs
                problemObservationCommentSuffix = problemObservationJesmsglg.CommentSuffix
            Case "DISACTREG"
                problemObservationDisregact = New DisplayRegionActive
                problemObservationDisregact.TheText = problemObservationText
                problemObservationDisregact.NoOfChars = problemObservationTextLength
                problemObservationDisregact.SearchText = problemObservationTextSpecs
                Select Case problemObservationTextOpr
                    Case "Only With"
                        problemObservationDisregact.OnlyLines("With")
                    Case "Only Without"
                        problemObservationDisregact.OnlyLines("Without")
                    Case "Sort"
                        problemObservationDisregact.Sort()
                End Select
                problemObservationAlteredText = problemObservationDisregact.TheAlteredText
                problemObservationAlteredTextLength = problemObservationDisregact.TheAlteredText.Length
                problemObservationAlteredTextNoOfLines = problemObservationDisregact.AlteredNoOfLines
                problemObservationCommentSuffix = problemObservationDisregact.CommentSuffix
        End Select
    End Sub


    ' Display, Edit & Create new Problems

    Public Sub DisplayProblem(ByVal i As Integer, _
        ByRef drFound() As System.Data.DataRow)
        Dim dr As System.Data.DataRow
        dr = drFound(i)
        problemtxtType.Text = dr("ProblemSystem")
        problemtxtNo.Text = dr("ProblemNo")
        problemtxtWhen.Text = dr("Occurred")
        problemtxtWhere.Text = dr("Lpar")
        problemtxtClient.Text = dr("Client")
        problemtxtImpacts.Text = dr("Impacts")
        problemtxtDetails.Text = dr("Details")
    End Sub

    Public Sub DisplayNewProblem()
        problemtxtType.Text = ""
        problemtxtNo.Text = "0"
        problemtxtWhen.Text = DateTime.Now.ToString
        problemtxtWhere.Text = ""
        problemtxtClient.Text = ""
        problemtxtImpacts.Text = ""
        problemtxtTitle.Text = "Enter Brief Problem Description"
        problemtxtSolution.Text = "No Solution Yet"
        problemtxtDetails.Text = "No Details Yet"
    End Sub

    Public Sub UpdateProblem(ByVal i As Integer, _
        ByRef drFound() As System.Data.DataRow)
        Dim dr As System.Data.DataRow
        dr = drFound(i)
        dr("ProblemSystem") = problemtxtType.Text
        dr("ProblemNo") = problemtxtNo.Text
        dr("Title") = problemtxtTitle.Text
        dr("Occurred") = BlankToJan1753(problemtxtWhen.Text)
        dr("Lpar") = problemtxtWhere.Text
        dr("Client") = problemtxtClient.Text
        dr("Impacts") = problemtxtImpacts.Text
        dr("Details") = problemtxtDetails.Text
        problemdaProblems.Update(problemdsProblems.Tables(0))
    End Sub

    Public Function CreateNewProblem(ByVal RecordID As Integer)
        Dim dr As System.Data.DataRow
        ' BlankToJan1753 is the reverse of Jan1753ToBlank if dates
        ' are blank sub's 01/01/1753 DB will only accept valid 
        ' DateTimes
        dr = problemdsProblems.Tables(0).NewRow()
        dr("NodeID") = RecordID
        dr("ProblemSystem") = problemtxtType.Text
        dr("ProblemNo") = Integer.Parse(problemtxtNo.Text)
        dr("Title") = problemtxtTitle.Text
        dr("Occurred") = BlankToJan1753(problemtxtWhen.Text)
        dr("Lpar") = problemtxtWhere.Text
        dr("Client") = problemtxtClient.Text
        dr("Impacts") = problemtxtImpacts.Text
        dr("Details") = problemtxtDetails.Text
        problemdsProblems.Tables(0).Rows.Add(dr)
        problemdaProblems.Update(problemdsProblems.Tables(0))
        RecordID = dr("ProblemID")
        Return RecordID
    End Function

    Public Sub InitPageProblem(ByVal TypeID As String)
        'Subs called:- ProblemReadOnly
        'Properties Altered:- None
        Select Case TypeID
            Case "Browse"
                'Set to Browse Mode i.e. default to no updates
                ProblemReadOnly(True)
            Case "New"
                ' Dont want Observation Save button enabled
                problembtnSaveObservation.Enabled = False
                problembtnSaveObservation.ImageUrl = "images\Icons\Save_Disabled.png"
                problembtnPrevObservation.Enabled = False
                problembtnPrevObservation.ImageUrl = "images\Icons\Back_Disabled.png"
                problembtnNextObservation.Enabled = False
                problembtnNextObservation.ImageUrl = "images\Icons\Forward_Disabled.png"
                'Set to Edit Mode i.e. default to updates allowed
                ProblemReadOnly(False)
            Case "Edit"
                ' Dont want Observation Save button enabled
                problembtnSaveObservation.Enabled = False
                problembtnSaveObservation.ImageUrl = "images\Icons\Save_Disabled.png"
                'Set to Edit Mode i.e. default to updates allowed
                ProblemReadOnly(False)
        End Select
    End Sub

    Public Sub ProblemReadOnly(ByVal RdOnly As Boolean)
        Select Case RdOnly
            Case True
                problemtxtType.ReadOnly = True
                problemtxtNo.ReadOnly = True
                problemtxtWhen.ReadOnly = True
                problemtxtWhere.ReadOnly = True
                problemtxtClient.ReadOnly = True
                problemtxtImpacts.ReadOnly = True
                problemtxtDetails.ReadOnly = True
            Case False
                problemtxtType.ReadOnly = False
                problemtxtNo.ReadOnly = False
                problemtxtWhen.ReadOnly = False
                problemtxtWhere.ReadOnly = False
                problemtxtClient.ReadOnly = False
                problemtxtImpacts.ReadOnly = False
                problemtxtDetails.ReadOnly = False
        End Select
    End Sub

    ' Display, Edit & Create new Observations

    Public Sub DisplayObservation(ByVal i As Integer, _
        ByRef drFound() As System.Data.DataRow)
        Dim dr As System.Data.DataRow
        dr = drFound(i)
        problemtxtComments.Text = dr("Comment")
        problemtxtObservations.Text = dr("Observation")
    End Sub

    Public Sub DisplayNewObservation()
        problemtxtComments.Text = "Enter Observation Comment Here"
        problemtxtObservations.Text = "Enter Problem Observation Here"
    End Sub

    Public Sub UpdateObservation(ByVal i As Integer, _
        ByRef drFound() As System.Data.DataRow)
        Dim dr As System.Data.DataRow
        dr = drFound(i)
        dr("Comment") = problemtxtComments.Text
        dr("Observation") = problemtxtObservations.Text
        problemdaObservations.Update(problemdsObservations.Tables(0))
    End Sub

    Public Function CreateNewObservation(ByVal RecordID As Integer)
        Dim dr As System.Data.DataRow
        ' BlankToJan1753 is the reverse of Jan1753ToBlank if dates
        ' are blank sub's 01/01/1753 DB will only accept valid 
        ' DateTimes
        dr = problemdsObservations.Tables(0).NewRow()
        dr("ProblemID") = RecordID
        dr("Observation") = problemtxtObservations.Text
        dr("Comment") = problemtxtComments.Text
        problemdsObservations.Tables(0).Rows.Add(dr)
        problemdaObservations.Update(problemdsObservations.Tables(0))
        RecordID = dr("ObservationID")
        Return RecordID
    End Function

    Public Sub InitPageObservation(ByVal TypeID As String)
        'Subs called:- None
        'Properties Altered:- ObservationReadOnly
        Select Case TypeID
            Case "Browse"
                ' Disable save button
                problembtnSaveObservation.Enabled = False
                problemdrpTxtOpr.Enabled = False
                problemtxtTxtSpecs.Enabled = False
                problembtnGo.Enabled = False
                problembtnBackOut.Enabled = False
                problembtnSaveObservation.ImageUrl = "images\Icons\Save_Disabled.png"
                problembtnGo.ImageUrl = "images\Icons\Go_Disabled.png"
                problembtnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
                problemObservationOperation = "Browse"
                'Set to Browse Mode i.e. default to no updates
                ObservationReadOnly(True)
            Case "New"
                ' Enable Save button
                problembtnSaveObservation.Enabled = True
                problemdrpTxtOpr.Enabled = False
                problemtxtTxtSpecs.Enabled = False
                problembtnGo.Enabled = False
                problembtnBackOut.Enabled = False
                problembtnSaveObservation.ImageUrl = "images\Icons\Save.png"
                problembtnGo.ImageUrl = "images\Icons\Go_Disabled.png"
                problembtnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
                problemObservationOperation = "New"
                'Set to Edit Mode i.e. default to updates allowed
                ObservationReadOnly(False)
            Case "Edit"
                ' Enable Save button
                problembtnSaveObservation.Enabled = True
                problemdrpTxtOpr.Enabled = False
                problemtxtTxtSpecs.Enabled = False
                problembtnGo.Enabled = False
                problembtnBackOut.Enabled = False
                problembtnSaveObservation.ImageUrl = "images\Icons\Save.png"
                problembtnGo.ImageUrl = "images\Icons\Go_Disabled.png"
                problembtnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
                problemObservationOperation = "Edit"
                'Set to Edit Mode i.e. default to updates allowed
                ObservationReadOnly(False)
        End Select
        problemtxtTxtSpecs.Text = ""
        problemdrpTxtType.SelectedIndex() = 0
        'BindCategories(True, True, True)
    End Sub

    Public Sub ObservationReadOnly(ByVal RdOnly As Boolean)
        Select Case RdOnly
            Case True
                problemtxtComments.ReadOnly = True
                problemtxtObservations.ReadOnly = True
            Case False
                problemtxtComments.ReadOnly = False
                problemtxtObservations.ReadOnly = False
        End Select
    End Sub

End Class
