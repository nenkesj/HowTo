Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing

Public Class NoteTree
    Inherits Tree

    Sub New(ByRef daNodes As SqlDataAdapter, _
            ByRef daInfo As SqlDataAdapter, _
            ByRef daKeys As SqlDataAdapter, _
            ByRef daKeysDistinct As SqlDataAdapter, _
            ByRef daPictures As SqlDataAdapter, _
            ByRef daSummaries As SqlDataAdapter, _
            ByRef daCategories As SqlDataAdapter, _
            ByRef dsNodes As DataSet, _
            ByRef dsInfo As DataSet, _
            ByRef dsKeys As DataSet, _
            ByRef dsKeysDistinct As DataSet, _
            ByRef dsPictures As DataSet, _
            ByRef dsSummaries As DataSet, _
            ByRef dsCategories As DataSet, _
            ByRef dtNodes As DataTable, _
            ByRef dtTempNodes As DataTable, _
            ByRef dtInfo As DataTable, _
            ByRef dtKeys As DataTable, _
            ByRef dtKeysDistinct As DataTable, _
            ByRef dvNodes As DataView, _
            ByRef dvInfo As DataView, _
            ByRef dvKeys As DataView, _
            ByRef dvKeysDistinct As DataView, _
            ByRef gvSummarize As GridView, _
            ByRef lblNoteTools As Object, _
            ByRef lblInfoTools As Object, _
            ByRef lblPercentReduction As Object, _
            ByRef lbxNodes As Object, _
            ByRef lbxInfo As Object, _
            ByRef lbxKeys As Object, _
            ByRef drpKeys As Object, _
            ByRef drpFilterOn As Object, _
            ByRef drpSearchOn As Object, _
            ByRef drpTxtOpr As Object, _
            ByRef drpInfoTypes As Object, _
            ByRef drpSummaries As Object, _
            ByRef drpPictureType As Object, _
            ByRef btnUp As Object, _
            ByRef btnDown As Object, _
            ByRef btnSummary As Object, _
            ByRef btnRefresh As Object, _
            ByRef btnRefreshInfo As Object, _
            ByRef btnEdit As Object, _
            ByRef btnEditInfo As Object, _
            ByRef btnNew As Object, _
            ByRef btnNewInfo As Object, _
            ByRef btnNewChild As Object, _
            ByRef btnInfoNode As Object, _
            ByRef btnRestoreInfo As Object, _
            ByRef btnSave As Object, _
            ByRef btnSaveInfo As Object, _
            ByRef btnAddKeyWord As Object, _
            ByRef btnNewSummary As Object, _
            ByRef btnSaveSummary As Object, _
            ByRef btnPrevPicture As Object, _
            ByRef btnNextPicture As Object, _
            ByRef btnSavePicture As Object, _
            ByRef btnGo As Object, _
            ByRef btnBackOut As Object, _
            ByRef btnSearch As Object, _
            ByRef btnSrchBack As Object, _
            ByRef rdoNotes As Object, _
            ByRef rdoInfo As Object, _
            ByRef rdoSmallSumm As Object, _
            ByRef rdoLargeSumm As Object, _
            ByRef rdoLargestSumm As Object, _
            ByRef filUpload As Object, _
            ByRef Picture As Object, _
            ByRef txtFilterText As Object, _
            ByRef txtSearchFilter As Object, _
            ByRef txtKeyWord As Object, _
            ByRef txtHeading As Object, _
            ByRef txtNodeText As Object, _
            ByRef txtPictureTitle As Object, _
            ByRef txtSummText As Object, _
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
        notedaNodes = daNodes
        notedaInfo = daInfo
        notedaKeys = daKeys
        notedaKeysDistinct = daKeysDistinct
        notedaPictures = daPictures
        notedaSummaries = daSummaries
        notedaCategories = daCategories
        notedsNodes = dsNodes
        notedsInfo = dsInfo
        notedsKeys = dsKeys
        notedsKeysDistinct = dsKeysDistinct
        notedsPictures = dsPictures
        notedsSummaries = dsSummaries
        notedsCategories = dsCategories
        notedtNodes = dtNodes
        notedtInfo = dtInfo
        notedtTempNodes = dtTempNodes
        notedtKeys = dtKeys
        notedtKeysDistinct = dtKeysDistinct
        notedvNodes = dvNodes
        notedvInfo = dvInfo
        notedvKeys = dvKeys
        notedvKeysDistinct = dvKeysDistinct
        notegvSummarize = gvSummarize
        notelblNoteTools = lblNoteTools
        notelblInfoTools = lblInfoTools
        notelblPercentReduction = lblPercentReduction
        notelbxNodes = lbxNodes
        notelbxInfo = lbxInfo
        notelbxKeys = lbxKeys
        notedrpKeys = drpKeys
        notedrpFilterOn = drpFilterOn
        notedrpSearchOn = drpSearchOn
        notedrpTxtOpr = drpTxtOpr
        notedrpInfoTypes = drpInfoTypes
        notedrpSummaries = drpSummaries
        notedrpPictureType = drpPictureType
        notebtnUp = btnUp
        notebtnDown = btnDown
        notebtnSummary = btnSummary
        notebtnRefresh = btnRefresh
        notebtnRefreshInfo = btnRefreshInfo
        notebtnEdit = btnEdit
        notebtnEditInfo = btnEditInfo
        notebtnNew = btnNew
        notebtnNewInfo = btnNewInfo
        notebtnNewChild = btnNewChild
        notebtnInfoNode = btnInfoNode
        notebtnRestoreInfo = btnRestoreInfo
        notebtnSave = btnSave
        notebtnSaveInfo = btnSaveInfo
        notebtnAddKeyWord = btnAddKeyWord
        notebtnNewSummary = btnNewSummary
        notebtnSaveSummary = btnSaveSummary
        notebtnPrevPicture = btnPrevPicture
        notebtnNextPicture = btnNextPicture
        notebtnSavePicture = btnSavePicture
        notebtnGo = btnGo
        notebtnBackOut = btnBackOut
        notebtnSearch = btnSearch
        notebtnSrchBack = btnSrchBack
        noterdoNotes = rdoNotes
        noterdoInfo = rdoInfo
        noterdoSmallSumm = rdoSmallSumm
        noterdoLargeSumm = rdoLargeSumm
        noterdoLargestSumm = rdoLargestSumm
        notefilUpload = filUpload
        notePicture = Picture
        notetxtFilterText = txtFilterText
        notetxtSearchFilter = txtSearchFilter
        notetxtKeyWord = txtKeyWord
        notetxtHeading = txtHeading
        notetxtNodeText = txtNodeText
        notetxtPictureTitle = txtPictureTitle
        notetxtSummText = txtSummText
        notetxtTxtSpecs = txtTxtSpecs
    End Sub

    Public Property HasPicture() As Boolean
        Get
            Return noteHasPicture
        End Get
        Set(ByVal Value As Boolean)
            noteHasPicture = Value
        End Set
    End Property

    Public Property HasSummary() As Boolean
        Get
            Return noteHasSummary
        End Get
        Set(ByVal Value As Boolean)
            noteHasSummary = Value
        End Set
    End Property

    Public Property NodeText() As String
        Get
            Return noteText
        End Get
        Set(ByVal Value As String)
            noteText = Value
        End Set
    End Property

    Public Property NodeAlteredText() As String
        Get
            Return noteAlteredText
        End Get
        Set(ByVal Value As String)
            noteAlteredText = Value
        End Set
    End Property

    Public Property NodeTextLength() As Integer
        Get
            Return noteTextLength
        End Get
        Set(ByVal Value As Integer)
            noteTextLength = Value
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

    Public Property NodeTextOpr() As String
        Get
            Return noteTextOpr
        End Get
        Set(ByVal Value As String)
            noteTextOpr = Value
        End Set
    End Property

    Public Property NodeTextSpecs() As String
        Get
            Return noteTextSpecs
        End Get
        Set(ByVal Value As String)
            noteTextSpecs = Value
        End Set
    End Property

    Public Property Mode() As String
        Get
            Return noteMode
        End Get
        Set(ByVal Value As String)
            noteMode = Value
        End Set
    End Property

    Public Property InfoFilter() As String
        Get
            Return noteInfoFilter
        End Get
        Set(ByVal Value As String)
            noteInfoFilter = Value
        End Set
    End Property

    Public Property InfoType() As Integer
        Get
            Return noteInfoType
        End Get
        Set(ByVal Value As Integer)
            noteInfoType = Value
        End Set
    End Property

    Public Property InfoSelectCmd() As String
        Get
            Return noteInfoSelectCmd
        End Get
        Set(ByVal Value As String)
            noteInfoSelectCmd = Value
        End Set
    End Property

    Public Property SelectedInfo() As Integer
        Get
            Return noteSelectedInfo
        End Get
        Set(ByVal Value As Integer)
            noteSelectedInfo = Value
        End Set
    End Property

    Public Property RestoreSelectedInfo() As Integer
        Get
            Return noteRestoreSelectedInfo
        End Get
        Set(ByVal Value As Integer)
            noteRestoreSelectedInfo = Value
        End Set
    End Property

    Public Property InfoNode() As Integer
        Get
            Return noteInfoNode
        End Get
        Set(ByVal Value As Integer)
            noteInfoNode = Value
        End Set
    End Property

    Public Property InfoSavedYet() As Boolean
        Get
            Return noteInfoSavedYet
        End Get
        Set(ByVal Value As Boolean)
            noteInfoSavedYet = Value
        End Set
    End Property

    Public Property EnableGo() As Boolean
        Get
            Return noteEnableGo
        End Get
        Set(ByVal Value As Boolean)
            noteEnableGo = Value
        End Set
    End Property

    Public Property InfoOperation() As String
        Get
            Return noteInfoOperation
        End Get
        Set(ByVal Value As String)
            noteInfoOperation = Value
        End Set
    End Property

    Public ReadOnly Property SummSentences As Generic.List(Of SummarizeSentence)
        Get
            Return noteSummSentences
        End Get
    End Property

    Dim notedaNodes, notedaInfo, notedaKeys, notedaKeysDistinct As SqlDataAdapter
    Dim notedaPictures, notedaSummaries, notedaCategories As SqlDataAdapter
    Dim notedsNodes, notedsInfo, notedsKeys, notedsKeysDistinct As DataSet
    Dim notedsPictures, notedsSummaries, notedsCategories As DataSet
    Dim notedtNodes, notedtInfo, notedtTempNodes, notedtKeys, notedtKeysDistinct As DataTable
    Dim notedvNodes, notedvInfo, notedvKeys, notedvKeysDistinct As DataView
    Dim notegvSummarize As GridView

    Dim notelblNoteTools, notelblInfoTools, notelblPercentReduction, notelbxNodes, notelbxInfo, _
        notelbxKeys, notedrpFilterOn, notedrpSearchOn, notedrpKeys, notedrpTxtOpr, notedrpInfoTypes, notedrpSummaries, _
        notedrpPictureType, notetxtHeading, notetxtNodeText, notetxtKeyWord, _
        notetxtFilterText, notetxtSearchFilter, _
        notetxtPictureTitle, notetxtSummText, notebtnRefresh, notebtnRefreshInfo, _
        notebtnEdit, notebtnEditInfo, notebtnNew, notebtnNewInfo, notebtnNewChild, notebtnInfoNode, notebtnRestoreInfo, _
        notebtnSave, notebtnSaveInfo, notebtnAddKeyWord, notebtnUp, notebtnDown, notebtnSummary, notebtnPrevPicture, _
        notebtnNextPicture, notebtnSavePicture, notebtnNewSummary, notebtnSaveSummary, notebtnGo, notebtnBackOut, _
        notebtnSearch, notebtnSrchBack, _
        noterdoNotes, noterdoInfo, noterdoSmallSumm, noterdoLargeSumm, noterdoLargestSumm, notefilUpload, notePicture, _
        notetxtTxtSpecs As Object

    Dim noteSelectedKey, noteSearchFilter, noteNodeFilter, noteInfoOperation, _
        noteNodeSelectCmd, noteSelectCmd, noteText, noteAlteredText, noteTextOpr, _
        noteTextSpecs, noteMode, noteInfoFilter, noteInfoSelectCmd As String

    Dim notePlainText As PlainText

    Dim noteSelectedNode, noteParentNode, noteCurrentLevel, noteCurrentTree, noteRestoreSelectedInfo, _
        noteItem, noteTextLength, noteAlteredTextLength, noteSelectedInfo, noteInfoType, noteInfoNode As Integer

    Dim noteHasPicture, noteHasSummary, noteInfoSavedYet, noteEnableGo, debug As Boolean

    Dim noteSummSentences As Generic.List(Of SummarizeSentence)

    Public Sub InitialInfoSettings(ByVal InfoSelectCommand As String)
        ' Subs called :- None
        ' Properties Altered:- NodeType, CurrentTree, DefaultSelectCmd,
        ' NodeSelectCmd, ParentNode, SelectedNode, CurrentLevel, Item,
        ' Operation, SelectedKey, NodeFilter, SearchFilter
        '
        'The initial value of these ones vary depending on the caller
        '
        ' The Initial SELECT Command used to fill the rows of the ADO 
        ' DataSet
        noteInfoSelectCmd = InfoSelectCommand
        '
        ' These ones always have the same initial value independent of caller
        '
        ' Start with the 1st info at the top of the tree
        noteSelectedInfo = 0
        ' Same with Restore Info
        noteRestoreSelectedInfo = 0
        ' Start with zero Info Node
        noteInfoNode = 0
        ' Start as though were not in the process of Editing something
        noteInfoSavedYet = True
        ' Filter the keywords listbox to only those that belong to the 
        ' current tree
        noteInfoFilter = ""
        ' Deafault info type
        noteInfoType = 18
    End Sub

    Public Sub BindPictures(ByVal Clear As Boolean, ByVal Fill As Boolean)
        'Subs called:- None
        'Properties Altered:- None
        ' Clear datasets
        If Clear Then
            notedsPictures.Clear()
        End If
        ' Fill datasets
        If Fill Then
            notedaPictures.Fill(notedsPictures)
        End If
    End Sub

    Public Sub BindSummaries(ByVal Clear As Boolean, ByVal Fill As Boolean)
        'Subs called:- None
        'Properties Altered:- None
        ' Clear datasets
        If Clear Then
            notedsSummaries.Clear()
        End If
        ' Fill datasets
        If Fill Then
            notedaSummaries.Fill(notedsSummaries)
        End If
    End Sub

    Public Sub BindInfo(ByVal Clear As Boolean, ByVal Fill As Boolean, ByVal Bind As Boolean)
        'Subs called:- None
        'Properties Altered:- None
        ' Clear datasets
        If Clear Then
            notedsInfo.Clear()
        End If
        ' Fill datasets
        If Fill Then
            notedaInfo.SelectCommand.CommandText = noteInfoSelectCmd
            notedaInfo.Fill(notedtInfo)
        End If
        ' Bind Control 
        If Bind Then
            notedvInfo.RowFilter = noteInfoFilter
            notedvInfo.Sort = "Heading"
            notelbxInfo.DataBind()
            notedrpInfoTypes.DataBind()
        End If
    End Sub

    Public Overrides Sub NodeChanged()
        'Subs called:- DisplayPicture DisplaySummary
        'Properties Altered:- Item HasPicture HasSummary
        Dim drFound() As DataRow
        Dim SelectExpression As String
        Dim SelNode As Integer
        MyBase.NodeChanged()
        ' Save looking this up more than once
        SelNode = SelectedNode
        ' Has this node got any pictures? If so display them & adjust
        ' text width
        SelectExpression = "NodeID = " & SelNode
        drFound = notedsPictures.Tables(0).Select(SelectExpression)
        If drFound.Length() < 1 Then
            noteHasPicture = False
            'Set default textbox width
            'notetxtNodeText.Width = System.Web.UI.WebControls.Unit.Percentage(55)
            notePicture.Visible = False
            notetxtPictureTitle.Text = ""
            notebtnNextPicture.Enabled = False
            notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
        Else
            noteHasPicture = True
            DisplayPicture(0, drFound)
            notePicture.Visible = True
            ' If there is more pictures enable next picture button
            If drFound.Length() > 1 Then
                notebtnNextPicture.Enabled = True
                notebtnNextPicture.ImageUrl = "images\Icons\Forward.png"
            Else
                notebtnNextPicture.Enabled = False
                notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
            End If
        End If
        ' We always display the 1st picture so always diable the Prev Picture button
        notebtnPrevPicture.Enabled = False
        notebtnPrevPicture.ImageUrl = "images\Icons\Back_Disabled.png"
        '
        If noteMode = "Info" And HasSummary Then
            noteHasSummary = False
        Else
            ' If summary exists display it 
            SelectExpression = "NodeID = " & SelNode
            drFound = notedsSummaries.Tables(0).Select(SelectExpression)
            If drFound.Length() < 1 Then
                noteHasSummary = False
                noterdoSmallSumm.Checked = False
                noterdoSmallSumm.Enabled = False
                noterdoLargeSumm.Checked = False
                noterdoLargeSumm.Enabled = False
                noterdoLargestSumm.Checked = False
                noterdoLargestSumm.Enabled = False
                notetxtSummText.Visible = False
                notedrpSummaries.Enabled = False
                notebtnNewSummary.Enabled = True
                notebtnNewSummary.Visible = True
                notebtnSaveSummary.Enabled = False
                notebtnSaveSummary.ImageUrl = "images\Icons\Save_Disabled.png"
            Else
                noteHasSummary = True
                noterdoSmallSumm.Checked = True
                noterdoSmallSumm.Enabled = True
                noterdoLargeSumm.Checked = False
                noterdoLargeSumm.Enabled = True
                noterdoLargestSumm.Checked = False
                noterdoLargestSumm.Enabled = True
                notetxtSummText.Visible = True
                notedrpSummaries.Enabled = True
                notebtnNewSummary.Enabled = False
                notebtnNewSummary.Visible = False
                notebtnSaveSummary.Enabled = True
                notebtnSaveSummary.ImageUrl = "images\Icons\Save.png"
                notetxtSummText.Width = System.Web.UI.WebControls.Unit.Percentage(42)
                notetxtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(85)
                DisplaySummary(0, drFound)
            End If
        End If
    End Sub

    Public Sub InfoChanged()
        ' Subs called:- InitialSettings BindNodes BindKeys InitPage 
        ' DisplayNoNodeFound DisplayNode FillKeysForNode AlsoChanged
        ' Properties Altered:- Operation SelectedNode ParentNode CurrentLevel
        Dim drFound() As DataRow
        Dim dr As DataRow
        Dim SelectExpression As String
        Dim SelInfo As Integer
        ' Save looking this up more than once
        SelInfo = SelectedInfo
        'Get Selected treelbxNodes Node
        If notelbxInfo.Items.Count < 1 Then
            ' If there arent any nodes in the list box reset to initial
            ' settings and display a message saying no nodes selected
            DisplayNoInfoFound()
        Else
            ' If this is a new node that's just been saved select the new 
            ' node so its displayed in the nodes listbox as opposed to 
            ' selecting the 1st node in the list
            ' If this is a new child just drop through to below which selects 1st item (New Child will always be 1st item)
            If noteInfoOperation = "NewInfo" And noteInfoSavedYet And noteSelectedInfo > 0 Then
                notelbxInfo.Items.FindByValue(noteSelectedInfo).Selected = True
            End If
            If noteInfoOperation = "EditInfo" And noteInfoSavedYet And noteSelectedInfo > 0 Then
                notelbxInfo.Items.FindByValue(noteSelectedInfo).Selected = True
            End If
            ' There are nodes in the nodes list box if none have been selected select the 1st node
            If notelbxInfo.SelectedIndex < 0 Then
                notelbxInfo.Items(0).Selected = True
            End If
            ' Given the above a node should always now be selected
            noteSelectedInfo = notelbxInfo.SelectedValue
            SelectExpression = "InfoID = " & noteSelectedInfo
            drFound = notedsInfo.Tables(0).Select(SelectExpression)
            ' Select relevant drpInfoType
            dr = drFound(0)
            noteInfoNode = dr("NodeID")
            noteInfoType = dr("TypeID")
            If noteInfoType > 0 Then
                notedrpInfoTypes.Items.FindByValue(noteInfoType).Selected = True
            End If
            ' Display 1st row with this NodeID (should only be one as NodeID is the Primary Key)
            DisplayInfo(0, drFound)
            ' Has this node got any pictures? If so display them & adjust
            ' text width
            SelectExpression = "InfoID = " & SelectedInfo
            drFound = notedsPictures.Tables(0).Select(SelectExpression)
            If drFound.Length() < 1 Then
                'Set default textbox width
                'notetxtNodeText.Width = System.Web.UI.WebControls.Unit.Percentage(55)
                notePicture.Visible = False
                notetxtPictureTitle.Text = ""
                notebtnNextPicture.Enabled = False
                notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
            Else
                DisplayPicture(0, drFound)
                notePicture.Visible = True
                ' If there is more pictures enable next picture button
                If drFound.Length() > 1 Then
                    notebtnNextPicture.Enabled = True
                    notebtnNextPicture.ImageUrl = "images\Icons\Forward.png"
                Else
                    notebtnNextPicture.Enabled = False
                    notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
                End If
            End If
            ' We always display the 1st picture so always diable the Prev Picture button
            notebtnPrevPicture.Enabled = False
            notebtnPrevPicture.ImageUrl = "images\Icons\Back_Disabled.png"
            ' Set up page in Browse Mode 
            InitPage("BrowseInfo")
        End If
    End Sub

    Public Overrides Sub InitPage(ByVal TypeID As String)
        'Subs called:- NoteReadOnly
        'Properties Altered:- None
        MyBase.InitPage(TypeID)
        Select Case TypeID
            Case "Browse"
                ' Disable Text Operations
                notedrpTxtOpr.Enabled = False
                notetxtNodeText.Visible = True
                notegvSummarize.Visible = False
                notegvSummarize.Enabled = False
                notebtnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
                notebtnBackOut.Enabled = False
                notebtnGo.ImageUrl = "images\Icons\Go_Disabled.png"
                notebtnGo.Enabled = False
                'Enable Picture Tools
                notefilUpload.Enabled = True
                notetxtPictureTitle.Enabled = True
                notetxtPictureTitle.Text = ""
                notedrpPictureType.Enabled = True
                notebtnSavePicture.Enabled = True
                notebtnSavePicture.ImageUrl = "images\Icons\Save.png"
                ' Enable New Summaries
                notebtnNewSummary.Enabled = True
                notebtnNewSummary.Visible = True
                ' Button dependent on Node or Info Mode
                noterdoNotes.Checked = True
                noterdoInfo.Checked = False
                notelblNoteTools.Visible = True
                notelblInfoTools.Visible = False
                notebtnRefreshInfo.Enabled = False
                notebtnRefreshInfo.Visible = False
                notebtnEditInfo.Enabled = False
                notebtnEditInfo.Visible = False
                notebtnNewInfo.Enabled = False
                notebtnNewInfo.Visible = False
                notebtnInfoNode.Enabled = False
                notebtnInfoNode.Visible = False
                notebtnSaveInfo.Enabled = False
                notebtnSaveInfo.Visible = False
                notedrpInfoTypes.Enabled = False
                notedrpInfoTypes.Visible = False
                notelbxInfo.Enabled = False
                notelbxInfo.Visible = False
                notelblPercentReduction.Visible = False
            Case "BrowseInfo"
                ' Disable save button
                notebtnSaveInfo.Enabled = False
                notebtnSaveInfo.ImageURL = "images\Icons\Save_Disabled.png"
                notebtnSaveInfo.Visible = True
                ' Enable edit button
                notebtnEditInfo.Enabled = True
                notebtnEditInfo.Visible = True
                ' Disable Search 
                notebtnSearch.Enabled = False
                notelbxKeys.Enabled = False
                ' Disable Add Key Word
                notebtnAddKeyWord.Enabled = False
                notetxtKeyWord.Enabled = False
                notetxtKeyWord.Text = ""
                ' Disable Text Operations
                notedrpTxtOpr.Enabled = False
                notetxtNodeText.Visible = True
                notegvSummarize.Visible = False
                notegvSummarize.Enabled = False
                notebtnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
                notebtnBackOut.Enabled = False
                notebtnGo.ImageUrl = "images\Icons\Go_Disabled.png"
                notebtnGo.Enabled = False
                'Enable Picture Tools
                notefilUpload.Enabled = True
                notetxtPictureTitle.Enabled = True
                notetxtPictureTitle.Text = ""
                notedrpPictureType.Enabled = True
                notebtnSavePicture.Enabled = True
                notebtnSavePicture.ImageUrl = "images\Icons\Save.png"
                ' Info maybe displaying a Note Summary which we want to edit however we dont want new summaries
                notebtnNewSummary.Enabled = False
                notebtnNewSummary.Visible = False
                ' Button dependent on Node of Info Mode
                noterdoNotes.Checked = False
                noterdoInfo.Checked = True
                notelblNoteTools.Visible = False
                notelblInfoTools.Visible = True
                notebtnRefresh.Enabled = False
                notebtnRefresh.Visible = False
                notebtnRefreshInfo.Enabled = True
                notebtnRefreshInfo.Visible = True
                notebtnEdit.Enabled = False
                notebtnEdit.Visible = False
                notebtnNew.Enabled = False
                notebtnNew.Visible = False
                notebtnNewInfo.Enabled = True
                notebtnNewInfo.Visible = True
                notebtnNewChild.Enabled = False
                notebtnNewChild.Visible = False
                notebtnInfoNode.Enabled = True
                notebtnInfoNode.Visible = True
                notebtnSave.Enabled = False
                notebtnSave.Visible = False
                notebtnUp.Enabled = False
                notebtnUp.Visible = False
                notebtnDown.Enabled = False
                notebtnDown.Visible = False
                notedrpInfoTypes.Enabled = True
                notedrpInfoTypes.Visible = True
                notelbxNodes.Enabled = False
                notelbxNodes.Visible = False
                notelbxInfo.Enabled = True
                notelbxInfo.Visible = True
                'Set to Browse Mode i.e. default to no updates
                SetReadOnly(True)
            Case "New"
                'Enable Text Operations (prior to Saving)
                notedrpTxtOpr.Enabled = True
                ' New Nodes dont have pictures so disabled everything related to pictures (until Save)
                noteHasPicture = False
                notePicture.Visible = False
                notebtnNextPicture.Enabled = False
                notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
                notebtnPrevPicture.Enabled = False
                notebtnPrevPicture.ImageUrl = "images\Icons\Back_Disabled.png"
                notefilUpload.Enabled = False
                notetxtPictureTitle.Enabled = False
                notetxtPictureTitle.Text = ""
                notedrpPictureType.Enabled = False
                notebtnSavePicture.Enabled = False
                notebtnSavePicture.ImageUrl = "images\Icons\Save_Disabled.png"
                ' New Notes wont have Summaries yet
                noteHasSummary = False
                notetxtSummText.Visible = False
                noterdoSmallSumm.Checked = False
                noterdoLargeSumm.Checked = False
                noterdoLargestSumm.Checked = False
                notedrpSummaries.Enabled = False
                notebtnNewSummary.Enabled = False
                notebtnNewSummary.Visible = False
                notebtnSaveSummary.Enabled = False
                notebtnSaveSummary.ImageUrl = "images\Icons\Save_Disabled.png"
            Case "NewInfo"
                ' Keep Save button disabled until InfoType drop down item selected 
                ' (easy to forget and everything will be default Info Type)
                notebtnSaveInfo.Enabled = False
                notebtnSaveInfo.ImageURL = "images\Icons\Save_Disabled.png"
                ' Disable edit button
                notebtnEditInfo.Enabled = False
                ' Disable Search (gets messy if SrchBack hit after Search if new node hasnt been saved)
                notebtnSearch.Enabled = False
                notelbxKeys.Enabled = False
                ' Disable Add Key Word (cant add Key Word until node is saved)
                notebtnAddKeyWord.Enabled = False
                notetxtKeyWord.Enabled = False
                notetxtKeyWord.Text = ""
                'Enable Text Operations (prior to Saving)
                notedrpTxtOpr.Enabled = True
                ' Info maybe displaying a Note Summary which we want to edit however we dont want new summaries
                notebtnNewSummary.Enabled = False
                notebtnNewSummary.Visible = False
                'Set to Browse Mode i.e. default to no updates
                SetReadOnly(False)
                ' Havent Saved Yet
                noteInfoSavedYet = False
            Case "NewChild"
                'Enable Text Operations (prior to Saving)
                notedrpTxtOpr.Enabled = True
                ' New Notes wont have pictures yet so disabled everything related to pictures (until Save)
                noteHasPicture = False
                notePicture.Visible = False
                notebtnNextPicture.Enabled = False
                notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
                notebtnPrevPicture.Enabled = False
                notebtnPrevPicture.ImageUrl = "images\Icons\Back_Disabled.png"
                notefilUpload.Enabled = False
                notetxtPictureTitle.Enabled = False
                notetxtPictureTitle.Text = ""
                notedrpPictureType.Enabled = False
                notebtnSavePicture.Enabled = False
                ' New Notes wont have Summaries yet
                noteHasSummary = False
                notetxtSummText.Visible = False
                noterdoSmallSumm.Checked = False
                noterdoLargeSumm.Checked = False
                noterdoLargestSumm.Checked = False
                notedrpSummaries.Enabled = False
                notebtnNewSummary.Enabled = False
                notebtnNewSummary.Visible = False
                notebtnSaveSummary.Enabled = False
                notebtnSaveSummary.ImageUrl = "images\Icons\Save_Disabled.png"
            Case "Edit"
                'Enable Text Operations (prior to Saving)
                notedrpTxtOpr.Enabled = True
                '
                ' Note we dont disable the AddKeyWord button or Picture or Summary Tool Buttons as the node were   
                ' editing is an existing node i.e. it isnt new and unsaved, so we can successfully add a key word, 
                ' Picture or Summary to the node while were editing it even if we dont save our editing changes
                '
            Case "EditInfo"
                ' Enable save button
                notebtnSaveInfo.Enabled = True
                notebtnSaveInfo.ImageURL = "images\Icons\Save.png"
                ' Disable edit button
                notebtnEditInfo.Enabled = False
                'Enable Text Operations (prior to Saving)
                notedrpTxtOpr.Enabled = True
                'Set to Edit Mode i.e. default to allow updates
                ' Info maybe displaying a Note Summary which we want to edit however we dont want new summaries
                notebtnNewSummary.Enabled = False
                notebtnNewSummary.Visible = False
                SetReadOnly(False)
                'Havent Saved Yet
                noteInfoSavedYet = False
        End Select
    End Sub

    ' Info Tools Buttons
    Public Sub RefreshInfo()
        'Subs called:- BindNodes NodeChanged
        'Properties Altered:- NodeFilter
        Select Case notedrpFilterOn.SelectedItem.Text
            Case "Heading"
                ' Display only info with headings like that specified
                noteInfoFilter = "Heading LIKE '*" & notetxtFilterText.Text & "*'"
            Case Else
                ' Clear the filter on nodes displayed
                noteInfoFilter = ""
                notetxtFilterText.Text = ""
        End Select
    End Sub

    Public Sub EditInfo()
        'Subs called:- InitPage 
        'Properties Altered:- None
        ' Note page is already displayed so dont need to call DisplayNode
        InitPage("EditInfo")
    End Sub

    Public Sub NewInfo()
        'Subs called:- InitPage DisplayNewNode
        'Properties Altered:- None
        DisplayNewInfo()
        InitPage("NewInfo")
    End Sub

    Public Sub BackToInfoNode()
        Dim drFound() As DataRow
        Dim dr As DataRow
        Dim SelectExpression As String
        Me.RestorePrevSelectedNode = Me.SelectedNode
        Me.RestorePrevParentNode = Me.ParentNode
        Me.RestorePrevCurrentLevel = Me.CurrentLevel
        Me.RestorePrevNodeFilter = Me.NodeFilter
        ' Set selected node to the node associated with this info
        Me.SelectedNode = noteInfoNode
        ' Retrieve this node & set parent & current level
        SelectExpression = "NodeID = " & noteInfoNode
        drFound = notedsNodes.Tables(0).Select(SelectExpression)
        dr = drFound(0)
        Me.ParentNode = dr("ParentNodeID")
        ' Set tree level
        Me.CurrentLevel = dr("TreeLevel")
        Me.NodeSelectCmd = Me.DefaultSelectCmd
        Me.NodeFilter = "ParentNodeID = " & Me.ParentNode
    End Sub

    Public Sub SaveInfo()
        ' Subs called:- CreateNewNode BindNodes NodeChanged BindKeys 
        ' UpdateNode InitPage  
        ' Properties Altered:- SavedYet SelectedNode ParentNode CurrentLevel
        ' NodeFilter
        Dim drFound() As DataRow
        'Dim dr As DataRow
        Dim SelectExpression As String
        Dim InfoID As Integer
        Select Case noteInfoOperation
            Case "NewInfo"
                'Create the new node
                InfoID = CreateNewInfo()
                ' Selected Node changes to the new child
                noteSelectedInfo = InfoID
                ' New Node has been Saved
                noteInfoSavedYet = True
            Case "EditInfo"
                ' Retrieve & Update the Node 
                SelectExpression = "InfoID = " & noteSelectedInfo
                drFound = notedsInfo.Tables(0).Select(SelectExpression)
                UpdateInfo(0, drFound)
                ' Edited Node has been Saved
                noteInfoSavedYet = True
        End Select
    End Sub

    ' Text Operation Buttons

    Public Sub TextOpSelected()
        NodeTextOpr = notedrpTxtOpr.SelectedItem.Text
        notetxtTxtSpecs.Enabled = True
        notebtnGo.ImageUrl = "images\Icons\Go.png"
        notebtnGo.Enabled = True
    End Sub


    Public Sub TextOperation()
        'Subs called:- 
        'Properties Altered:-
        Dim noteWordsNoOf, noteLinesNoOf, noteSentencesNoOf, noteParagraphsNoOf, ParmsNoOf, _
            lineWidth As Integer
        Dim parm As String
        Dim eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF As Boolean
        Dim noteLines, noteSentences, noteParagrphs, Parms As Generic.List(Of String)
        Dim noteSentenceInParagraph As Generic.List(Of Integer)
        Dim noteWords As SortedList
        Dim noteParagraphs As Paragraphs
        Dim noteOprSpecs As PlainText

        noteEnableGo = True
        notebtnGo.ImageUrl = "images\Icons\Go_Disabled.png"
        notebtnGo.Enabled = False
        notebtnBackOut.ImageUrl = "images\Icons\No.png"
        notebtnBackOut.Enabled = True
        notebtnSave.ImageUrl = "images\Icons\Save.png"
        notebtnSave.Enabled = True
        NodeTextSpecs = notetxtTxtSpecs.Text
        NodeText = notetxtNodeText.Text
        NodeTextLength = notetxtNodeText.Text.Length
        NodeAlteredText = ""
        NodeAlteredTextLength = 0
        Parms = New Generic.List(Of String)
        noteOprSpecs = New PlainText
        noteOprSpecs.TheText = notetxtTxtSpecs.Text
        If notetxtTxtSpecs.Text = "" Then
            lineWidth = 0
            eliminateWhiteSpace = True
            splitHeaders = False
            splitOnColon = False
            splitOnLF = False
        Else
            noteOprSpecs.DivideAfterChar(",", ParmsNoOf, Parms)
            lineWidth = 0
            eliminateWhiteSpace = True
            splitHeaders = False
            splitOnColon = False
            splitOnLF = False
            If ParmsNoOf >= 1 Then
                lineWidth = Parms(0)
            End If
            If ParmsNoOf >= 2 Then
                parm = Parms(1)
                parm = parm.Substring(0, 1)
                If parm = "T" Or parm = "t" Or parm = "Y" Or parm = "y" Then
                    debug = True
                Else
                    debug = False
                End If
            End If
            If ParmsNoOf >= 3 Then
                parm = Parms(2)
                parm = parm.Substring(0, 1)
                If parm = "T" Or parm = "t" Or parm = "Y" Or parm = "y" Then
                    eliminateWhiteSpace = True
                Else
                    eliminateWhiteSpace = False
                End If
            End If
            If ParmsNoOf >= 4 Then
                parm = Parms(3)
                parm = parm.Substring(0, 1)
                If parm = "T" Or parm = "t" Or parm = "Y" Or parm = "y" Then
                    splitHeaders = True
                Else
                    splitHeaders = False
                End If
            End If
            If ParmsNoOf >= 5 Then
                parm = Parms(4)
                parm = parm.Substring(0, 1)
                If parm = "T" Or parm = "t" Or parm = "Y" Or parm = "y" Then
                    splitOnColon = True
                Else
                    splitOnColon = False
                End If
            End If
            If ParmsNoOf >= 6 Then
                parm = Parms(4)
                parm = parm.Substring(0, 1)
                If parm = "T" Or parm = "t" Or parm = "Y" Or parm = "y" Then
                    splitOnLF = True
                Else
                    splitOnLF = False
                End If
            End If
        End If
        Select Case noteTextOpr
            Case "Format Text"
                noteParagrphs = New Generic.List(Of String)
                noteSentences = New Generic.List(Of String)
                noteSentenceInParagraph = New Generic.List(Of Integer)
                noteLines = New Generic.List(Of String)
                noteParagraphs = New Paragraphs
                noteParagraphs.TheText = noteText
                noteParagraphs.NoOfChars = noteParagraphs.TheText.Length
                noteParagraphs.Paragrphs(noteParagraphsNoOf, noteParagrphs, noteSentencesNoOf, _
                                        noteSentences, noteSentenceInParagraph, noteLinesNoOf, noteLines, lineWidth, _
                                        debug, eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF)
                noteAlteredText = noteParagraphs.TheAlteredText
                noteAlteredTextLength = noteParagraphs.TheAlteredText.Length
            Case "Words"
                noteParagraphs = New Paragraphs
                noteWords = New SortedList
                noteParagraphs.TheText = noteText
                noteParagraphs.NoOfChars = noteParagraphs.TheText.Length
                noteParagraphs.Words(noteWordsNoOf, noteWords)
                noteAlteredText = noteParagraphs.TheAlteredText
                noteAlteredTextLength = noteParagraphs.TheAlteredText.Length
            Case "Sentences"
                noteOprSpecs = New PlainText
                noteParagraphs = New Paragraphs
                noteSentences = New Generic.List(Of String)
                noteSentenceInParagraph = New Generic.List(Of Integer)
                noteParagraphs.TheText = noteText
                noteParagraphs.NoOfChars = noteParagraphs.TheText.Length
                noteParagraphs.Sentences(noteSentencesNoOf, noteSentences, noteSentenceInParagraph, lineWidth, debug, eliminateWhiteSpace, splitOnLF)
                noteAlteredText = noteParagraphs.TheAlteredText
                noteAlteredTextLength = noteParagraphs.TheAlteredText.Length
            Case "Debugging Text"
                noteParagrphs = New Generic.List(Of String)
                noteSentences = New Generic.List(Of String)
                noteSentenceInParagraph = New Generic.List(Of Integer)
                noteLines = New Generic.List(Of String)
                noteParagraphs = New Paragraphs
                lineWidth = 0
                debug = True
                eliminateWhiteSpace = True
                splitHeaders = False
                splitOnColon = False
                splitOnLF = False
                noteParagraphs.TheText = noteText
                noteParagraphs.NoOfChars = noteParagraphs.TheText.Length
                noteParagraphs.Paragrphs(noteParagraphsNoOf, noteParagrphs, noteSentencesNoOf, _
                                        noteSentences, noteSentenceInParagraph, noteLinesNoOf, noteLines, lineWidth, _
                                        debug, eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF)
                noteAlteredText = noteParagraphs.TheAlteredText
                noteAlteredTextLength = noteParagraphs.TheAlteredText.Length
            Case "Sort"
            Case "Remove Column"
        End Select
        notetxtNodeText.Text = NodeAlteredText
    End Sub

    Public Sub BackOut()
        NodeAlteredText = ""
        NodeAlteredTextLength = 0
        NodeTextSpecs = ""
    End Sub

    ' Summary Buttons

    Public Sub NewSummary()
        'Subs called:- DisplayNewSummary DisplaySummary
        'Properties Altered:- None
        ' Now has a summary
        noteHasSummary = True
        noteEnableGo = False
        ' Control Changes
        notebtnSaveSummary.ImageUrl = "images\Icons\Save.png"
        notebtnSaveSummary.Enabled = True
        notetxtSummText.Visible = True
        notetxtSummText.Enabled = True
        notetxtSummText.Height = System.Web.UI.WebControls.Unit.Percentage(90)
        notetxtSummText.Width = System.Web.UI.WebControls.Unit.Percentage(42)
        noterdoSmallSumm.Checked = False
        noterdoSmallSumm.Enabled = True
        noterdoLargeSumm.Checked = True
        noterdoLargeSumm.Enabled = True
        noterdoLargestSumm.Checked = False
        noterdoLargestSumm.Enabled = True
        notebtnNewSummary.Enabled = False
        notebtnNewSummary.Visible = False
        notedrpSummaries.Enabled = True
        notebtnSaveSummary.Enabled = True
        notebtnSaveSummary.ImageUrl = "images/icons/Save.png"
        noteText = notetxtNodeText.Text
        noteTextLength = notetxtNodeText.Text.Length
        'DisplayNewSummary()
    End Sub

    Public Sub SaveSummary()
        'Subs called:- CreateNewSummary UpdateSummary
        'Properties Altered:- None
        Dim drFound() As DataRow
        Dim SelectExpression As String
        ' Save Summ Btn always enabled (we can edit text and click save anytime)
        notebtnSaveSummary.Enabled = True
        notebtnSaveSummary.ImageUrl = "images/icons/Save.png"
        ' Determine if were dealing with a new or existing summary
        SelectExpression = "NodeID = " & Me.SelectedNode
        drFound = notedsSummaries.Tables(0).Select(SelectExpression)
        If drFound.Length() < 1 Then
            CreateNewSummary()
        Else
            UpdateSummary(0, drFound)
        End If
    End Sub

    ' Picture Buttons

    Public Sub PrevPicture()
        'Subs called:- DisplayPicture
        'Properties Altered:- Item
        Dim drFound() As DataRow
        Dim SelectExpression As String
        Item -= 1
        ' Disable Prev button if now at Picture 0
        If Item = 0 Then
            notebtnPrevPicture.Enabled = False
            notebtnPrevPicture.ImageUrl = "images\Icons\Back_Disabled.png"
        Else
            notebtnPrevPicture.Enabled = True
            notebtnPrevPicture.ImageUrl = "images\Icons\Back.png"
        End If
        ' Enable Next Picture button
        notebtnNextPicture.Enabled = True
        notebtnNextPicture.ImageUrl = "images\Icons\Forward.png"
        ' Get Pictures
        If noteMode = "Info" Then
            SelectExpression = "InfoID = " & SelectedInfo
        Else
            SelectExpression = "NodeID = " & SelectedNode
        End If
        drFound = notedsPictures.Tables(0).Select(SelectExpression)
        DisplayPicture(Item, drFound)
    End Sub

    Public Sub NextPicture()
        'Subs called:- DisplayPicture
        'Properties Altered:- Item
        Dim drFound() As DataRow
        Dim SelectExpression As String
        Dim UpperBound As Integer
        ' Get Pictures
        If noteMode = "Info" Then
            SelectExpression = "InfoID = " & SelectedInfo
        Else
            SelectExpression = "NodeID = " & SelectedNode
        End If
        drFound = notedsPictures.Tables(0).Select(SelectExpression)
        UpperBound = drFound.Length - 1
        ' Get the next Picture
        Item += 1
        ' Disable Next button if now at upperbound
        If Item = UpperBound Then
            notebtnNextPicture.Enabled = False
            notebtnNextPicture.ImageUrl = "images\Icons\Forward_Disabled.png"
        Else
            notebtnNextPicture.Enabled = True
            notebtnNextPicture.ImageUrl = "images\Icons\Forward.png"
        End If
        ' Enable Prev button
        notebtnPrevPicture.Enabled = True
        notebtnPrevPicture.ImageUrl = "images\Icons\Back.png"
        ' Display Picture
        DisplayPicture(Item, drFound)
    End Sub

    Public Sub SavePicture()
        'Subs called:- CreateNewPicture DisplayPicture
        'Properties Altered:- Item
        Dim RecordID As Integer
        Dim drFound() As DataRow
        Dim SelectExpression As String
        RecordID = CreateNewPicture(SelectedNode)
        If RecordID > 0 Then
            ' Display new picture
            SelectExpression = "PictureID = " & RecordID
            drFound = notedsPictures.Tables(0).Select(SelectExpression)
            DisplayPicture(0, drFound)
            Item += 1
            notePicture.Visible = True
            HasPicture = True
        Else
            notetxtPictureTitle = "Error: Couldnt Save Picture"
        End If
    End Sub

    ' Summary Methods

    Private Function CreateNewSummary()
        Dim RecordID As Integer
        Dim dr As DataRow
        dr = notedsSummaries.Tables(0).NewRow()
        dr("NodeID") = SelectedNode
        dr("Summary") = notetxtSummText.Text
        notedsSummaries.Tables(0).Rows.Add(dr)
        notedaSummaries.Update(notedsSummaries.Tables(0))
        RecordID = dr("SummaryID")
        Return RecordID
    End Function

    Private Sub DisplayNewSummary()
        notetxtSummText.Text = "Enter Summary Here"
    End Sub

    Public Sub DisplaySummary(ByVal i As Integer, ByRef drFound() As DataRow)
        Dim dr As DataRow
        dr = drFound(i)
        notetxtSummText.Text = dr("Summary")
    End Sub

    Public Sub SummHeading()
        Dim drFound() As DataRow
        Dim dr As DataRow
        Dim SelectExpression As String
        Dim SelInfo As Integer
        If noteMode = "Info" Then
            SelInfo = noteSelectedInfo
            SelectExpression = "InfoID = " & noteSelectedInfo
            drFound = notedsInfo.Tables(0).Select(SelectExpression)
            dr = drFound(0)
        End If
        Select Case notedrpSummaries.SelectedItem.Text
            Case "Summary"
                If noteMode = "Info" Then
                    If notetxtSummText.Text = "Enter Summary Here" Then
                        notetxtSummText.Text = "Summary: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    Else
                        notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Summary: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    End If
                Else
                    notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Summary:" + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Enter Summary Here"
                End If
            Case "Comment"
                If noteMode = "Info" Then
                    If notetxtSummText.Text = "Enter Summary Here" Then
                        notetxtSummText.Text = "Comment: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    Else
                        notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Comment: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    End If
                Else
                    notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Comment:" + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Enter Comment Here"
                End If
            Case "Additional Info"
                If noteMode = "Info" Then
                    If notetxtSummText.Text = "Enter Summary Here" Then
                        notetxtSummText.Text = "Additional Info: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    Else
                        notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Additional Info: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    End If
                Else
                    notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                        + "Additional Info:" + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Enter Additional Info Here"
                End If
            Case "Text Refers To"
                If noteMode = "Info" Then
                    If notetxtSummText.Text = "Enter Summary Here" Then
                        notetxtSummText.Text = "Text Refers To: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    Else
                        notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Text Refers To: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    End If
                Else
                    notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                        + "Text Refers To: Object" + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Enter Details Here"
                End If
            Case "Refresher On"
                If noteMode = "Info" Then
                    If notetxtSummText.Text = "Enter Summary Here" Then
                        notetxtSummText.Text = "Refresher On: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    Else
                        notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        "Refresher On: " + dr("Heading") + Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                        dr("InfoText")
                    End If
                Else
                    notetxtSummText.Text = notetxtSummText.Text + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                        + "Refresher On: Topic" + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Enter Details Here"
                End If
        End Select
    End Sub

    Private Sub UpdateSummary(ByVal i As Integer, _
        ByRef drFound() As DataRow)
        Dim dr As DataRow
        dr = drFound(i)
        dr("Summary") = notetxtSummText.Text
        notedaSummaries.Update(notedsSummaries.Tables(0))
    End Sub

    ' Picture Methods

    Private Function CreateNewPicture(ByVal RecordID As Integer)
        Dim dr As DataRow
        Dim pictureNamePtr As Integer
        pictureNamePtr = notefilUpload.PostedFile.FileName.ToString().IndexOf("images")
        If pictureNamePtr >= 0 Then
            dr = notedsPictures.Tables(0).NewRow()
            If noteMode = "Info" Then
                dr("NodeID") = 8801
            Else
                dr("NodeID") = RecordID
            End If
            dr("Picture") = notefilUpload.PostedFile.FileName.ToString().Substring(pictureNamePtr)
            dr("Title") = notetxtPictureTitle.Text
            dr("TypeID") = notedrpPictureType.SelectedItem.Value
            dr("PictureSize") = 0
            dr("DisplayAt") = 0
            dr("DisplayStopAt") = 0
            dr("DisplayStopAt") = 0
            If noteMode = "Info" Then
                dr("InfoID") = SelectedInfo
            Else
                dr("InfoID") = 0
            End If
            notedsPictures.Tables(0).Rows.Add(dr)
            notedaPictures.Update(notedsPictures.Tables(0))
            RecordID = dr("PictureID")
        Else
            RecordID = -1
        End If
        Return RecordID
    End Function

    Private Sub DisplayPicture(ByVal i As Integer, ByRef drFound() As DataRow)
        Dim dr As DataRow
        Dim filePath As String
        Dim img As Bitmap
        dr = drFound(i)
        notePicture.ImageUrl = dr("Picture")
        notetxtPictureTitle.Text = dr("Title")
        filePath = "C:\Users\Stephen\Documents\My Web Apps\HowTo\" & notePicture.ImageUrl.ToString
        img = New Bitmap(filePath)
        If img.Size.Height > 500 Then
            notePicture.Height = System.Web.UI.WebControls.Unit.Percentage(95)
        Else
            notePicture.Height = img.Size.Height
        End If
        If img.Size.Width > 650 Then
            notePicture.Width = System.Web.UI.WebControls.Unit.Percentage(42)
        Else
            notePicture.Width = img.Size.Width
        End If
        img.Dispose()
    End Sub

    ' Info Methods

    Public Function CreateNewInfo() As Object
        Dim RecordID As Integer
        Dim dr As DataRow
        dr = notedsInfo.Tables(0).NewRow()
        dr("NodeID") = Me.SelectedNode
        dr("TreeID") = Me.CurrentTree
        dr("TypeID") = noteInfoType
        dr("Heading") = notetxtHeading.Text
        dr("InfoText") = notetxtNodeText.Text
        notedsInfo.Tables(0).Rows.Add(dr)
        notedaInfo.Update(notedsInfo.Tables(0))
        RecordID = dr("InfoID")
        Return RecordID
    End Function

    Public Sub DisplayNewInfo()
        notetxtHeading.Text = "Enter Heading Here"
        notetxtNodeText.Text = "Enter Text Here"
    End Sub

    Public Sub DisplayInfo(ByVal i As Integer, ByRef drFound() As DataRow)
        Dim dr As DataRow
        dr = drFound(i)
        notetxtHeading.Text = dr("Heading")
        notetxtNodeText.Text = dr("InfoText")
    End Sub

    Public Sub DisplayNoInfoFound()
        notetxtHeading.Text = "No Info Satisfies Filter"
        notetxtNodeText.Text = "Filter Reset"
        notetxtFilterText.Text = ""
        notedrpFilterOn.SelectedIndex = 0
    End Sub

    Public Sub UpdateInfo(ByVal i As Integer, _
    ByRef drFound() As DataRow)
        Dim dr As DataRow
        dr = drFound(i)
        dr("Heading") = notetxtHeading.Text
        dr("InfoText") = notetxtNodeText.Text
        notedaInfo.Update(notedsInfo.Tables(0))
    End Sub

    Public Sub SpanBranch(ByRef Summaries As String, ByVal Node As Integer, ByRef ChapterSummNode As Integer)
        Dim drFound() As DataRow
        Dim SelectExpression, Heading As String
        Dim i As Integer
        SelectExpression = "NodeID = " & Node
        drFound = notedsNodes.Tables(0).Select(SelectExpression)
        If drFound.Length() > 0 Then
            Heading = drFound(0).Item(5)
            If Heading = "Chapter Summary" Then
                ChapterSummNode = Node
            Else
                Heading = Heading.ToUpper()
            End If
            Heading += Chr(13) + Chr(10)
        Else
            Heading = ""
        End If
        drFound = notedsSummaries.Tables(0).Select(SelectExpression)
        If drFound.Length() > 0 Then
            If drFound(0).Item(2).Substring(0, 9) = "Summary: " Then
                Summaries += Heading + drFound(0).Item(2).Substring((drFound(0).Item(2).IndexOf(Chr(10)) + 1))
            Else
                Summaries += Heading + drFound(0).Item(2)
            End If
        End If
        ' Does the Selected Node have any children? If so enable the down Button
        SelectExpression = "ParentNodeID = " & Node
        drFound = notedsNodes.Tables(0).Select(SelectExpression)
        If drFound.Length() > 0 Then
            For i = 0 To drFound.Length() - 1
                SpanBranch(Summaries, drFound(i).Item(0), ChapterSummNode)
            Next
        End If
    End Sub

End Class

