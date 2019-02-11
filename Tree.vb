Imports System.Data
Imports System.Data.SqlClient


Public Class Tree

    Sub New(ByRef daNodes As SqlDataAdapter, _
            ByRef daKeys As SqlDataAdapter, _
            ByRef daKeysDistinct As SqlDataAdapter, _
            ByRef dsNodes As DataSet, _
            ByRef dsKeys As DataSet, _
            ByRef dsKeysDistinct As DataSet, _
            ByRef dtNodes As DataTable, _
            ByRef dtTempNodes As DataTable, _
            ByRef dtKeys As DataTable, _
            ByRef dtKeysDistinct As DataTable, _
            ByRef dvNodes As DataView, _
            ByRef dvKeys As DataView, _
            ByRef dvKeysDistinct As DataView, _
            ByRef lbxNodes As Object, _
            ByRef lbxKeys As Object, _
            ByRef drpKeys As Object, _
            ByRef drpFilterOn As Object, _
            ByRef txtFilterText As Object, _
            ByRef txtKeyWord As Object, _
            ByRef txtHeading As Object, _
            ByRef txtNodeText As Object, _
            ByRef txtSearchFilter As Object, _
            ByRef drpSearchOn As Object, _
            ByRef btnRefresh As Object, _
            ByRef btnEdit As Object, _
            ByRef btnNew As Object, _
            ByRef btnNewChild As Object, _
            ByRef btnSave As Object, _
            ByRef btnAddKeyWord As Object, _
            ByRef btnSearch As Object, _
            ByRef btnSrchBack As Object, _
            ByRef btnUp As Object, _
            ByRef btnDown As Object, _
            ByRef btnSummary As Object)
        treedaNodes = daNodes
        treedaKeys = daKeys
        treedaKeysDistinct = daKeysDistinct
        treedsNodes = dsNodes
        treedsKeys = dsKeys
        treedsKeysDistinct = dsKeysDistinct
        treedtNodes = dtNodes
        treedtTempNodes = dtTempNodes
        treedtKeys = dtKeys
        treedtKeysDistinct = dtKeysDistinct
        treedvNodes = dvNodes
        treedvKeys = dvKeys
        treedvKeysDistinct = dvKeysDistinct
        treelbxNodes = lbxNodes
        treelbxKeys = lbxKeys
        treedrpKeys = drpKeys
        treedrpFilterOn = drpFilterOn
        treetxtFilterText = txtFilterText
        treetxtKeyWord = txtKeyWord
        treetxtHeading = txtHeading
        treetxtNodeText = txtNodeText
        treetxtSearchFilter = txtSearchFilter
        treedrpSearchOn = drpSearchOn
        treebtnRefresh = btnRefresh
        treebtnEdit = btnEdit
        treebtnNew = btnNew
        treebtnNewChild = btnNewChild
        treebtnSave = btnSave
        treebtnAddKeyWord = btnAddKeyWord
        treebtnSearch = btnSearch
        treebtnSrchBack = btnSrchBack
        treebtnUp = btnUp
        treebtnDown = btnDown
        treebtnSummary = btnSummary
    End Sub

    Public Property CurrentTree() As Integer
        Get
            Return treeCurrentTree
        End Get
        Set(ByVal Value As Integer)
            treeCurrentTree = Value
        End Set
    End Property

    Public Property NodeType() As Integer
        Get
            Return treeNodeType
        End Get
        Set(ByVal Value As Integer)
            treeNodeType = Value
        End Set
    End Property

    Public Property DefaultSelectCmd() As String
        Get
            Return treeDefaultSelectCmd
        End Get
        Set(ByVal Value As String)
            treeDefaultSelectCmd = Value
        End Set
    End Property

    Public Property NodeSelectCmd() As String
        Get
            Return treeNodeSelectCmd
        End Get
        Set(ByVal Value As String)
            treeNodeSelectCmd = Value
        End Set
    End Property

    Public Property ParentNode() As Integer
        Get
            Return treeParentNode
        End Get
        Set(ByVal Value As Integer)
            treeParentNode = Value
        End Set
    End Property

    Public Property SelectedNode() As Integer
        Get
            Return treeSelectedNode
        End Get
        Set(ByVal Value As Integer)
            treeSelectedNode = Value
        End Set
    End Property

    Public Property CurrentLevel() As Integer
        Get
            Return treeCurrentLevel
        End Get
        Set(ByVal Value As Integer)
            treeCurrentLevel = Value
        End Set
    End Property

    Public Property NodeFilter() As String
        Get
            Return treeNodeFilter
        End Get
        Set(ByVal Value As String)
            treeNodeFilter = Value
        End Set
    End Property

    Public Property RestoreParentNode() As Integer
        Get
            Return treeRestoreParentNode
        End Get
        Set(ByVal Value As Integer)
            treeRestoreParentNode = Value
        End Set
    End Property

    Public Property RestoreSelectedNode() As Integer
        Get
            Return treeRestoreSelectedNode
        End Get
        Set(ByVal Value As Integer)
            treeRestoreSelectedNode = Value
        End Set
    End Property

    Public Property RestoreCurrentLevel() As Integer
        Get
            Return treeRestoreCurrentLevel
        End Get
        Set(ByVal Value As Integer)
            treeRestoreCurrentLevel = Value
        End Set
    End Property

    Public Property RestoreNodeFilter() As String
        Get
            Return treeRestoreNodeFilter
        End Get
        Set(ByVal Value As String)
            treeRestoreNodeFilter = Value
        End Set
    End Property

    Public Property RestorePrevParentNode() As Integer
        Get
            Return treeRestorePrevParentNode
        End Get
        Set(ByVal Value As Integer)
            treeRestorePrevParentNode = Value
        End Set
    End Property

    Public Property RestorePrevSelectedNode() As Integer
        Get
            Return treeRestorePrevSelectedNode
        End Get
        Set(ByVal Value As Integer)
            treeRestorePrevSelectedNode = Value
        End Set
    End Property

    Public Property RestorePrevCurrentLevel() As Integer
        Get
            Return treeRestorePrevCurrentLevel
        End Get
        Set(ByVal Value As Integer)
            treeRestorePrevCurrentLevel = Value
        End Set
    End Property

    Public Property RestorePrevNodeFilter() As String
        Get
            Return treeRestorePrevNodeFilter
        End Get
        Set(ByVal Value As String)
            treeRestorePrevNodeFilter = Value
        End Set
    End Property

    Public Property Operation() As String
        Get
            Return treeOperation
        End Get
        Set(ByVal Value As String)
            treeOperation = Value
        End Set
    End Property

    Public Property Item() As Integer
        Get
            Return treeItem
        End Get
        Set(ByVal Value As Integer)
            treeItem = Value
        End Set
    End Property

    Public Property SavedYet() As Boolean
        Get
            Return treeSavedYet
        End Get
        Set(ByVal Value As Boolean)
            treeSavedYet = Value
        End Set
    End Property

    Public Property SelectedKey() As String
        Get
            Return treeSelectedKey
        End Get
        Set(ByVal Value As String)
            treeSelectedKey = Value
        End Set
    End Property

    Public Property SearchFilter() As String
        Get
            Return treeSearchFilter
        End Get
        Set(ByVal Value As String)
            treeSearchFilter = Value
        End Set
    End Property

    Public Property SearchDisplayed() As Boolean
        Get
            Return treeSearchDisplayed
        End Get
        Set(ByVal Value As Boolean)
            treeSearchDisplayed = Value
        End Set
    End Property

    Dim treedaNodes, treedaKeys, treedaKeysDistinct As SqlDataAdapter
    Dim treedsNodes, treedsKeys, treedsKeysDistinct As DataSet
    Dim treedtNodes, treedtTempNodes, treedtKeys, treedtKeysDistinct As DataTable
    Dim treedvNodes, treedvKeys, treedvKeysDistinct As DataView

    Dim treelbxNodes, treelbxKeys, _
        treedrpFilterOn, treedrpSearchOn, treedrpKeys, _
        treetxtHeading, treetxtNodeText, treetxtKeyWord, _
        treetxtFilterText, treetxtSearchFilter, _
        treebtnRefresh, treebtnEdit, treebtnNew, treebtnNewChild, treebtnSave, treebtnAddKeyWord, treebtnSearch, treebtnSrchBack, _
        treebtnUp, treebtnDown, treebtnSummary As Object

    Dim treeSelectedKey, treeSearchFilter, _
        treeNodeFilter, treeOperation, _
        treeNodeSelectCmd, treeDefaultSelectCmd, treeRestoreNodeFilter, treeRestorePrevNodeFilter As String

    Dim treeSelectedNode, treeParentNode, treeCurrentLevel, treeCurrentTree, _
        treeRestoreSelectedNode, treeRestoreParentNode, treeRestoreCurrentLevel, _
        treeRestorePrevSelectedNode, treeRestorePrevParentNode, treeRestorePrevCurrentLevel, _
        treeNodeType, treeItem As Integer

    Dim treeSavedYet, treeSearchDisplayed As Boolean

    Public Sub InitialSettings(ByVal TreeType As Integer, _
                               ByVal NodeType As Integer, _
                               ByVal SelectCommand As String)
        ' Subs called :- None
        ' Properties Altered:- NodeType, CurrentTree, DefaultSelectCmd,
        ' NodeSelectCmd, ParentNode, SelectedNode, CurrentLevel, Item,
        ' Operation, SelectedKey, NodeFilter, SearchFilter
        '
        'The initial value of these ones vary depending on the caller
        '
        ' There are several types of nodes: problem nodes, task nodes etc.
        treeNodeType = NodeType
        ' Nodes are arranged into trees, i.e. a tree of problem nodes, 
        ' a tree of task nodes etc this defines what sort of tree were 
        ' dealing with
        treeCurrentTree = TreeType
        ' The Initial SELECT Command used to fill the rows of the ADO 
        ' DataSet
        treeDefaultSelectCmd = SelectCommand
        ' The Select command changes depending on what you want displayed
        ' this is the Select Commands used to populate the Dataset
        treeNodeSelectCmd = treeDefaultSelectCmd
        '
        ' These ones always have the same initial value independent of caller
        '
        ' Nodes at the very top of the tree have no parents this is 
        ' where we start
        treeParentNode = 0
        ' Start with the 1st node at the top of the tree
        treeSelectedNode = 0
        ' Each level of the tree is numbered the top is level 1
        treeCurrentLevel = 1
        ' Assume there are no items at this stage
        treeItem = 0
        ' Set Operation to Browse as opposed to New & Edit
        treeOperation = "Browse"
        ' Set Search Results Displayed to False
        treeSearchDisplayed = False
        ' Start as though were not in the process of Editing something
        treeSavedYet = True
        ' Initial values for Restorse
        treeRestoreCurrentLevel = 1
        treeRestoreParentNode = treeParentNode
        treeRestoreSelectedNode = 0
        treeRestoreNodeFilter = "ParentNodeID = " & treeParentNode
        treeRestorePrevCurrentLevel = 1
        treeRestorePrevParentNode = treeParentNode
        treeRestorePrevSelectedNode = 0
        treeRestorePrevNodeFilter = "ParentNodeID = " & treeParentNode
        ' Dont start with a keyword search
        treeSelectedKey = ""
        ' Filter the node listbox to those that have the current parent
        treeNodeFilter = "ParentNodeID = " & treeParentNode
        ' Filter the keywords listbox to only those that belong to the 
        ' current tree
        treeSearchFilter = "TreeID = " & treeCurrentTree
    End Sub

    Public Overridable Sub BindNodes(ByVal Clear As Boolean, ByVal Fill As Boolean, _
        ByVal Bind As Boolean)
        'Subs called:- SetNodeFilter
        'Properties Altered:- None
        ' Clear treedss
        If Clear Then
            treedsNodes.Clear()
        End If
        ' Fill treedss
        If Fill Then
            treedaNodes.SelectCommand.CommandText = treeNodeSelectCmd
            treedaNodes.Fill(treedtNodes)
            If treeSearchDisplayed Then
                treedaNodes.SelectCommand.CommandText = treeDefaultSelectCmd
                treedaNodes.Fill(treedtTempNodes)
            End If
        End If
        ' Bind control
        If Bind Then
            If treeSearchDisplayed Then
                treedvNodes.RowFilter = ""
                treedvNodes.Sort = ""
            Else
                treedvNodes.RowFilter = treeNodeFilter
                If treeCurrentLevel = 1 Then
                    treedvNodes.Sort = "Heading"
                Else
                    treedvNodes.Sort = ""
                End If
            End If
            treelbxNodes.DataBind()
        End If
    End Sub

    Public Sub BindKeys(ByVal Clear As Boolean, ByVal Fill As Boolean, _
        ByVal Bind As Boolean)
        'Subs called:- None
        'Properties Altered:- None
        ' Clear treedss
        If Clear Then
            treedsKeys.Clear()
            treedsKeysDistinct.Clear()
        End If
        ' Fill treedss
        If Fill Then
            treedaKeys.Fill(treedtKeys)
            treedaKeysDistinct.Fill(treedtKeysDistinct)
        End If
        ' Bind Control 
        If Bind Then
            treedvKeysDistinct.RowFilter = treeSearchFilter
            treelbxKeys.DataBind()
        End If
    End Sub

    Public Overridable Sub NodeChanged()
        ' Subs called:- InitialSettings BindNodes BindKeys InitPage 
        ' DisplayNoNodeFound DisplayNode FillKeysForNode AlsoChanged
        ' Properties Altered:- Operation SelectedNode ParentNode CurrentLevel
        Dim drFound() As DataRow
        Dim dr As DataRow
        Dim SelectExpression As String
        'Get Selected treelbxNodes Node
        If treelbxNodes.Items.Count < 1 Then
            ' If there arent any nodes in the list box reset to initial
            ' settings and display a message saying no nodes selected
            InitialSettings(treeCurrentTree, treeNodeType, treeDefaultSelectCmd)
            DisplayNoNodeFound()
        Else
            ' If this is a new node that's just been saved select the new 
            ' node so its displayed in the nodes listbox as opposed to 
            ' selecting the 1st node in the list
            ' If this is a new child just drop through to below which selects 1st item (New Child will always be 1st item)
            If treeOperation = "New" And treeSavedYet And treeSelectedNode > 0 Then
                treelbxNodes.Items.FindByValue(treeSelectedNode).Selected = True
            End If
            If treeOperation = "Edit" And treeSavedYet And treeSelectedNode > 0 Then
                treelbxNodes.Items.FindByValue(treeSelectedNode).Selected = True
            End If
            ' There are nodes in the nodes list box if none have been selected select the 1st node
            If treelbxNodes.SelectedIndex < 0 Then
                treelbxNodes.Items(0).Selected = True
            End If
            ' Given the above a node should always now be selected
            treeSelectedNode = treelbxNodes.SelectedValue
            ' Retrieve this node & set parent & current level
            SelectExpression = "NodeID = " & treeSelectedNode
            drFound = treedsNodes.Tables(0).Select(SelectExpression)
            dr = drFound(0)
            treeParentNode = dr("ParentNodeID")
            ' Set tree level
            treeCurrentLevel = dr("TreeLevel")
            ' Display 1st row with this NodeID (should only be one as NodeID is the Primary Key)
            DisplayNode(0, drFound)
            ' Add keys that point to the selected node to the drop down list
            FillKeysForNode(treeSelectedNode)
            ' Does the Selected Node have any children? If so enable the down Button
            SelectExpression = "ParentNodeID = " & treeSelectedNode
            If treeSearchDisplayed Then
                drFound = treedsNodes.Tables(1).Select(SelectExpression)
            Else
                drFound = treedsNodes.Tables(0).Select(SelectExpression)
            End If
            If drFound.Length() > 0 Then
                treebtnDown.Enabled = True
                treebtnDown.ImageUrl = "images\Icons\Down.png"
            Else
                treebtnDown.Enabled = False
                treebtnDown.ImageUrl = "images\Icons\Down_Disabled.png"
            End If
            ' Enable the Up button if not at the top level
            If CurrentLevel > 1 Then
                treebtnUp.Enabled = True
                treebtnUp.ImageUrl = "images\Icons\Up.png"
            Else
                treebtnUp.Enabled = False
                treebtnUp.ImageUrl = "images\Icons\Up_Disabled.png"
            End If
            ' If Displaying Search Results Disable New and NewChild Buttons
            If treeSearchDisplayed Then
                treebtnNew.Enabled = False
                treebtnNewChild.Enabled = False
            Else
                treebtnNew.Enabled = True
                treebtnNewChild.Enabled = True
            End If
            ' If at Chapter Level enable Chapter Summary Button
            If treeCurrentLevel = 2 Then
                treebtnSummary.Enabled = True
                treebtnSummary.Visible = True
            Else
                treebtnSummary.Enabled = False
                treebtnSummary.Visible = False

            End If
            ' Set up page in Browse Mode 
            InitPage("Browse")
        End If
    End Sub

    Public Overridable Sub InitPage(ByVal TypeID As String)
        'Subs called:- SetReadOnly
        'Properties Altered:- Operation SavedYet
        Select Case TypeID
            Case "Browse"
                ' Disable save button
                treebtnSave.Enabled = False
                treebtnSave.Visible = True
                treebtnSave.ImageURL = "images\Icons\Save_Disabled.png"
                ' Enable edit button
                treebtnEdit.Enabled = True
                treebtnEdit.Visible = True
                ' Enable Search 
                treebtnSearch.Enabled = True
                treelbxKeys.Enabled = True
                ' Enable Add Key Word
                treebtnAddKeyWord.Enabled = True
                treetxtKeyWord.Enabled = True
                treetxtKeyWord.Text = ""
                ' Button dependent on Node or Info Mode
                treebtnRefresh.Enabled = True
                treebtnRefresh.Visible = True
                treebtnNew.Enabled = True
                treebtnNew.Visible = True
                treebtnNewChild.Enabled = True
                treebtnNewChild.Visible = True
                treebtnUp.Visible = True
                treebtnDown.Visible = True
                treelbxNodes.Enabled = True
                treelbxNodes.Visible = True
                'Set to Browse Mode i.e. default to no updates
                treeOperation = "Browse"
                SetReadOnly(True)
            Case "New"
                ' Enable Save button
                treebtnSave.Enabled = True
                treebtnSave.Visible = True
                treebtnSave.ImageURL = "images\Icons\Save.png"
                ' Disable edit button
                treebtnEdit.Enabled = False
                treebtnEdit.Visible = True
                ' Disable Search (gets messy if SrchBack hit after Search if new node hasnt been saved)
                treebtnSearch.Enabled = False
                treelbxKeys.Enabled = False
                ' Disable Add Key Word (cant add Key Word until node is saved)
                treebtnAddKeyWord.Enabled = False
                treetxtKeyWord.Enabled = False
                treetxtKeyWord.Text = ""
                'Enable Text Operations (prior to Saving)
                SetReadOnly(False)
                'Not Saved Yet
                treeSavedYet = False
            Case "NewChild"
                ' Enable Save button
                treebtnSave.Enabled = True
                treebtnSave.Visible = True
                treebtnSave.ImageURL = "images\Icons\Save.png"
                ' Disable edit button
                treebtnEdit.Enabled = False
                ' Disable Search (gets messy if SrchBack hit after Search if new node hasnt been saved)
                treebtnSearch.Enabled = False
                treelbxKeys.Enabled = False
                ' Disable Add Key Word (cant add Key Word until node is saved)
                treebtnAddKeyWord.Enabled = False
                treetxtKeyWord.Enabled = False
                treetxtKeyWord.Text = ""
                'Enable Text Operations (prior to Saving)
                SetReadOnly(False)
                'Not Saved Yet
                treeSavedYet = False
            Case "Edit"
                ' Enable Save button
                treebtnSave.Enabled = True
                treebtnSave.Visible = True
                treebtnSave.ImageURL = "images\Icons\Save.png"
                ' Disable edit button
                treebtnEdit.Enabled = False
                treebtnEdit.Visible = True
                ' Enable save button
                SetReadOnly(False)
                'Not Saved Yet
                treeSavedYet = False
        End Select
    End Sub

    Public Sub FillKeysForNode(ByVal i As Integer)
        'Subs called:- None
        'Properties Altered:- None
        Dim SelectExpression As String
        Dim drFound() As DataRow
        Dim dr As DataRow
        ' Add keys that point to the selected node to the drop down list
        SelectExpression = "NodeID = " & i
        drFound = Me.treedsKeys.Tables(0).Select(SelectExpression)
        treedrpKeys.Items.Clear()
        If drFound.Length < 1 Then
            treedrpKeys.Enabled = False
        Else
            treedrpKeys.Enabled = True
            For i = 0 To drFound.Length - 1
                dr = drFound(i)
                treedrpKeys.Items.Add(dr("KeyText"))
            Next
        End If
    End Sub

    ' Buttons Clicked

    ' Node Tools Buttons

    Public Overridable Sub Refresh()
        'Subs called:- BindNodes NodeChanged
        'Properties Altered:- NodeFilter
        Select Case treedrpFilterOn.SelectedItem.Text
            Case "Heading"
                ' Display only nodes with headings like that specified
                treeNodeFilter = "ParentNodeID = " & treeParentNode & " AND " & _
                "Heading LIKE '*" & treetxtFilterText.Text & "*'"
            Case Else
                ' Clear the filter on nodes displayed
                treeNodeFilter = "ParentNodeID = " & treeParentNode
                treetxtFilterText.Text = ""
        End Select
    End Sub

    Public Sub Down()
        'Subs called:- ResetSearch BindNodes ResetFilters NodeChanged
        'Properties Altered:- ParentNode CurrentLevel SelectedNode
        Dim drFound() As DataRow
        Dim dr As DataRow
        Dim SelectExpression As String
        ' Selected Node becomes Parent
        treeParentNode = treeSelectedNode
        ' Going down a level
        treeCurrentLevel = treeCurrentLevel + 1
        ' Get 1st child, if there werent any the down button would have been disabled
        SelectExpression = "ParentNodeID = " & treeParentNode
        If treeSearchDisplayed Then
            ResetSelectCommand()
            ResetSearchFilter()
            drFound = treedsNodes.Tables(1).Select(SelectExpression)
        Else
            drFound = treedsNodes.Tables(0).Select(SelectExpression)
        End If
        dr = drFound(0)
        ' 1st child becomes the new selected node
        treeSelectedNode = dr("NodeID")
        ' Reset the Filters as we now have a new parent which is usually
        ' what were filtering on i.e. filter to all nodes that share this parent
        ResetNodeFilter()
    End Sub

    Public Sub Up()
        'Subs called:- ResetSearch BindNodes ResetFilters NodeChanged
        'Properties Altered:- SelectedNode ParentNode CurrentLevel
        Dim drFound() As DataRow
        Dim dr As DataRow
        Dim SelectExpression As String
        ' Parent becomes Selected Node
        treeSelectedNode = treeParentNode
        ' Going up a level
        treeCurrentLevel = treeCurrentLevel - 1
        ' Get the new parent
        SelectExpression = "NodeID = " & treeSelectedNode
        If treeSearchDisplayed Then
            ResetSelectCommand()
            ResetSearchFilter()
            drFound = treedsNodes.Tables(1).Select(SelectExpression)
        Else
            drFound = treedsNodes.Tables(0).Select(SelectExpression)
        End If
        dr = drFound(0)
        treeParentNode = dr("ParentNodeID")
        ' Reset the Filters as we now have a new parent which is usually
        ' what were filtering on i.e. filter to all nodes that share this parent
        ResetNodeFilter()
    End Sub

    Public Sub ResetSelectCommand()
        'Subs called:- None
        'Properties Altered:- NodeSelectCmd
        treeNodeSelectCmd = treeDefaultSelectCmd
        treeSelectedKey = ""
    End Sub

    Public Sub ResetNodeFilter()
        'Subs called:- None
        'Properties Altered:- NodeFilter SearchFilter
        treeNodeFilter = "ParentNodeID = " & treeParentNode
        treetxtFilterText.Text = ""
    End Sub

    Public Sub ResetSearchFilter()
        'Subs called:- None
        'Properties Altered:- NodeFilter SearchFilter
        treeSearchFilter = "TreeID = " & treeCurrentTree
        treetxtSearchFilter.Text = ""
    End Sub

    Public Overridable Sub NewNode()
        'Subs called:- InitPage DisplayNewNode
        'Properties Altered:- None
        DisplayNewNode()
        InitPage("New")
    End Sub

    Public Overridable Sub NewChildNode()
        'Subs called:- InitPage DisplayNewNode
        'Properties Altered:- None
        DisplayNewNode()
        InitPage("NewChild")
    End Sub

    Public Overridable Sub EditNode()
        'Subs called:- InitPage 
        'Properties Altered:- None
        ' Note page is already displayed so dont need to call DisplayNode
        InitPage("Edit")
    End Sub

    Public Overridable Sub Save()
        ' Subs called:- CreateNewNode BindNodes NodeChanged BindKeys 
        ' UpdateNode InitPage  
        ' Properties Altered:- SavedYet SelectedNode ParentNode CurrentLevel
        ' NodeFilter
        Dim drFound() As DataRow
        'Dim dr As DataRow
        Dim SelectExpression As String
        Dim NodeID As Integer
        Select Case treeOperation
            Case "New"
                'Create the new node
                NodeID = CreateNewNode()
                ' Selected Node changes to the new child
                treeSelectedNode = NodeID
                ' New Node has been Saved
                treeSavedYet = True
            Case "NewChild"
                ' the selected node becomes the new parent 
                treeParentNode = treeSelectedNode
                ' reset nodefilter as parent changed
                treeNodeFilter = "ParentNodeID = " & treeParentNode
                ' down a level
                treeCurrentLevel = treeCurrentLevel + 1
                'Create the new node
                NodeID = CreateNewNode()
                ' Selected Node changes to the new child
                treeSelectedNode = NodeID
                ' New Node has been Saved
                treeSavedYet = True
            Case "Edit"
                ' Retrieve & Update the Node 
                SelectExpression = "NodeID = " & treeSelectedNode
                drFound = treedsNodes.Tables(0).Select(SelectExpression)
                UpdateNode(0, drFound)
                ' Edited Node has been Saved
                treeSavedYet = True
        End Select

    End Sub

    ' Search Tools Buttons

    Public Sub SearchRefresh()
        'Subs called:- ResetFilters InitialSettings BindNodes NodeChanged
        'BindKeys
        'Properties Altered:- SearchFilter
        Select Case treedrpSearchOn.SelectedItem.Text
            Case "Key Like"
                ' Only display keys like the string entered
                treeSearchFilter = "TreeID = " & treeCurrentTree & _
                    " AND KeyText LIKE '*" & treetxtSearchFilter.Text & "*'"
            Case "Key"
                ' Only display keys like the string entered
                treeSearchFilter = "TreeID = " & treeCurrentTree & _
                    " AND KeyText = '" & treetxtSearchFilter.Text & "'"
            Case Else
                ' Clear any filters on keys displayed
                ResetSearchFilter()
        End Select
    End Sub

    Public Overridable Sub Search()
        'Subs called:- BindNodes NodeChanged
        'Properties Altered:- NodeSelectCmd
        If treebtnSrchBack.Enabled = False Then
            treebtnSrchBack.ImageUrl = "images\Icons\Back.png"
            treebtnSrchBack.Enabled = True
        End If
        ' Only display nodes that match the keys entered
        treeNodeSelectCmd = "SELECT * FROM Nodes WHERE NodeID IN (" & _
            "SELECT NodeID FROM Keys WHERE KeyText = '" & _
            treeSelectedKey & "' AND TreeID = " & treeCurrentTree & ")"
    End Sub

    Public Sub SrchBack()
        'Subs called:- ResetSearch BindNodes ResetFilters NodeChanged
        'Properties Altered:- ParentNode CurrentLevel SelectedNode
        treebtnSrchBack.ImageUrl = "images\Icons\Back_Disabled.png"
        treebtnSrchBack.Enabled = False
        ResetSelectCommand()
        ResetNodeFilter()
        ResetSearchFilter()
    End Sub

    Public Sub AddKeyWord()
        'Subs called:- CreateNewKey BindKeys
        'Properties Altered:- None
        ' Create a new key
        CreateNewKey(treeSelectedNode, treetxtKeyWord.Text)
    End Sub

    ' Other Buttons

    Public Sub Insert()
        Dim Current As New Node
        ' Insert new node before selected node
        Current.InsertNewNodeBefore(treeSelectedNode)
        ' Bind Problems Control (Dont Clear, Dont Fill, Just Bind)
        BindNodes(False, False, True)
        NodeChanged()
    End Sub

    Public Sub Copy()
        Dim CurrentNode As New Node
        ' Get all the node details for the selected node
        CurrentNode.GetNode(treeSelectedNode)
        ' Create a copy of the selected node under its parent (i.e. at the same level & pointing to the same parent)
        CurrentNode.CopyNodes(treeSelectedNode, CurrentNode.ParentNodeID)
        ' Bind Problems Control (Dont Clear, Dont Fill, Just Bind)
        BindNodes(False, False, True)
        NodeChanged()
    End Sub

    ' Node Methods

    Public Function CreateNewNode() As Object
        Dim RecordID As Integer
        Dim dr As DataRow
        dr = treedsNodes.Tables(0).NewRow()
        dr("TreeID") = treeCurrentTree
        dr("TypeID") = treeNodeType
        dr("TreeLevel") = treeCurrentLevel
        dr("ParentNodeID") = treeParentNode
        dr("Heading") = treetxtHeading.Text
        dr("NodeText") = treetxtNodeText.Text
        treedsNodes.Tables(0).Rows.Add(dr)
        treedaNodes.Update(treedsNodes.Tables(0))
        RecordID = dr("NodeID")
        Return RecordID
    End Function

    Public Sub DisplayNewNode()
        treetxtHeading.Text = "Enter Heading Here"
        treetxtNodeText.Text = "Enter Text Here"
    End Sub

    Public Sub DisplayNode(ByVal i As Integer, _
    ByRef drFound() As DataRow)
        Dim dr As DataRow
        dr = drFound(i)
        treetxtHeading.Text = dr("Heading")
        treetxtNodeText.Text = dr("NodeText")
    End Sub

    Public Sub DisplayNoNodeFound()
        treetxtHeading.Text = "No Node Satisfies Filter or Keyword Search"
        treetxtNodeText.Text = "Filter & Keyword Search Reset"
        treetxtFilterText.Text = ""
        treetxtSearchFilter.Text = ""
        treedrpFilterOn.SelectedIndex = 0
        treedrpSearchOn.SelectedIndex = 0
    End Sub

    Public Sub UpdateNode(ByVal i As Integer, _
        ByRef drFound() As DataRow)
        Dim dr As DataRow
        dr = drFound(i)
        dr("Heading") = treetxtHeading.Text
        dr("NodeText") = treetxtNodeText.Text
        treedaNodes.Update(treedsNodes.Tables(0))
    End Sub

    Public Sub SetReadOnly(ByVal RdOnly As Boolean)
        Select Case RdOnly
            Case True
                treetxtHeading.ReadOnly = True
                treetxtNodeText.ReadOnly = True
            Case False
                treetxtHeading.ReadOnly = False
                treetxtNodeText.ReadOnly = False
        End Select
    End Sub

    ' Key Methods

    Public Function CreateNewKey(ByVal RecordID As Integer, _
     ByVal Key As String) As Object
        Dim dr As DataRow
        dr = treedsKeys.Tables(0).NewRow()
        dr("TreeID") = treeCurrentTree
        dr("NodeID") = RecordID
        dr("TypeID") = 7
        dr("KeyText") = Key
        treedsKeys.Tables(0).Rows.Add(dr)
        treedaKeys.Update(treedsKeys.Tables(0))
        RecordID = dr("KeyID")
        Return RecordID
    End Function

    ' Miscellaneous Methods

    Public Function Jan1753ToBlank(ByVal D As String) As String
        If DateTime.Parse(D) <> "January 1, 1753" Then
            Return D
        Else
            Return ""
        End If
    End Function

    Public Function BlankToJan1753(ByVal D As String) As String
        If D <> "" Then
            Return D
        Else
            Return "January 1, 1753"
        End If
    End Function

End Class

