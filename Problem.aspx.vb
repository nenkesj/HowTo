Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class _Problem
    Inherits System.Web.UI.Page
    '
    ' To check the Problems page do the following
    '
    ' 1.  Select another node than the one displayed check the new node is 
    '     displayed - OK 
    ' 2.  Check that the Keys drop down has been updated - OK  
    ' 3.  Select a problem with Down button enabled DFSnnnn SELECTIVE ...
    ' 4.  Check Down buttons functions as expected - OK
    ' 5.  Check Up buttons functions as expected - OK
    ' 6.  Select a problem with more than one observation
    ' 7.  Scroll back and forth between the 1st & 2nd observations - OK
    ' 8.  Edit a problem & Save, Go to another problem come back & check the 
    '     changes are there - OK
    ' 9.  Edit an observation & Save, Go to another observation come back & 
    '     check the changes are there - OK
    ' 9.  Filter problems on title & clear filter - OK 
    ' 10. Filter problems on title, before date & after date & clear - OK
    ' 11. Filter keys & clear filter - OK 
    ' 12. Search for nodes after selecting a keyword, clear the search - OK 
    ' 13. Filter the keys select one and search on it then clear - OK
    ' 
    ' The following require a little more trouble and can be skipped
    '
    ' 14. Create a new problem & Save  
    ' 15. Create a 2nd observation for the new problem & Save 
    ' 16. Add a new key for a node (there's no reversing this so make it a 
    '     valid one)
    ' 17. Test combining a key filter with a node filter & clear both 
    '     as follows 
    '     1st select key then filter nodes then clear 
    '     2nd set node filter then set search key then clear 
    '     3rd select key search then select another key & search then 
    '         Clear 
    '     4th try select keys search then search again on same key & 
    '         Clear 
    '
    Protected WithEvents btnNextObservation As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPrevObservation As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnEditObservation As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblClient As System.Web.UI.WebControls.Label
    Protected WithEvents txtClient As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKeyWord As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAddKeyWord As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblSearchOn As System.Web.UI.WebControls.Label
    Protected WithEvents btnSearchRefresh As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpSearchOn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEdit As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnCopy As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnInsert As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDown As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnUp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lbxNodes As System.Web.UI.WebControls.ListBox
    Protected WithEvents drpTxtType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpTxtOpr As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTxtSpecs As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnBackOut As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpKeys As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtSolution As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComments As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDetails As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservations As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblOccurred As System.Web.UI.WebControls.Label
    Protected WithEvents lblWhere As System.Web.UI.WebControls.Label
    Protected WithEvents lblImpacts As System.Web.UI.WebControls.Label
    Protected WithEvents btnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnSearchBrowse As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnSearchEdit As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblTreeTools As System.Web.UI.WebControls.Label
    Protected WithEvents lblSearchTools As System.Web.UI.WebControls.Label
    Protected WithEvents lblSolution As System.Web.UI.WebControls.Label
    Protected WithEvents lblComments As System.Web.UI.WebControls.Label
    Protected WithEvents lblDetails As System.Web.UI.WebControls.Label
    Protected WithEvents lblObservations As System.Web.UI.WebControls.Label
    Protected WithEvents lbxTreeNodes As System.Web.UI.WebControls.ListBox
    Protected WithEvents drpFilterOn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFilterText As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTrees As System.Web.UI.WebControls.Label
    Protected WithEvents lblSearch As System.Web.UI.WebControls.Label
    Protected WithEvents txtSearchFilter As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbxKeys As System.Web.UI.WebControls.ListBox
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWhen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWhere As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImpacts As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecdNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtType As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRefresh As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnNew As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnNewObservation As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnSaveObservation As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblNodes As System.Web.UI.WebControls.Label
    Protected WithEvents lblFilterOn As System.Web.UI.WebControls.Label
    Protected WithEvents drpPage As System.Web.UI.WebControls.DropDownList

    Protected WithEvents cnHowToDB As System.Data.SqlClient.SqlConnection
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daNodes As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsNodes As System.Data.DataSet
    Protected WithEvents dvNodes As System.Data.DataView
    Protected WithEvents dtNodes As System.Data.DataTable
    Protected WithEvents dtTempNodes As System.Data.DataTable
    Protected WithEvents SqlSelectCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daObservations As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsObservations As System.Data.DataSet
    Protected WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daProblems As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsProblems As System.Data.DataSet
    Protected WithEvents SqlSelectCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daKeys As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsKeys As System.Data.DataSet
    Protected WithEvents dvKeys As System.Data.DataView
    Protected WithEvents dtKeys As System.Data.DataTable
    Protected WithEvents SqlSelectCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daKeysDistinct As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsKeysDistinct As System.Data.DataSet
    Protected WithEvents dvKeysDistinct As System.Data.DataView
    Protected WithEvents dtKeysDistinct As System.Data.DataTable
    Protected WithEvents SqlSelectCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daNodesProblemsJoin As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsNodesProblemsJoin As System.Data.DataSet
    Protected WithEvents SqlSelectCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daCategories As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsCategories As System.Data.DataSet
    Protected WithEvents dvCategories As System.Data.DataView
    Protected WithEvents dtCategories As System.Data.DataTable

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.cnHowToDB = New System.Data.SqlClient.SqlConnection
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.daNodes = New System.Data.SqlClient.SqlDataAdapter
        Me.dsNodes = New System.Data.DataSet
        Me.dtNodes = New System.Data.DataTable
        Me.dvNodes = New System.Data.DataView
        Me.SqlSelectCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand3 = New System.Data.SqlClient.SqlCommand
        Me.daObservations = New System.Data.SqlClient.SqlDataAdapter
        Me.dsObservations = New System.Data.DataSet
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand2 = New System.Data.SqlClient.SqlCommand
        Me.daProblems = New System.Data.SqlClient.SqlDataAdapter
        Me.dsProblems = New System.Data.DataSet
        Me.daNodesProblemsJoin = New System.Data.SqlClient.SqlDataAdapter
        Me.dsNodesProblemsJoin = New System.Data.DataSet
        Me.SqlSelectCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand4 = New System.Data.SqlClient.SqlCommand
        Me.daKeys = New System.Data.SqlClient.SqlDataAdapter
        Me.dsKeys = New System.Data.DataSet
        Me.dvKeys = New System.Data.DataView
        Me.dtKeys = New System.Data.DataTable
        Me.SqlSelectCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand5 = New System.Data.SqlClient.SqlCommand
        Me.daKeysDistinct = New System.Data.SqlClient.SqlDataAdapter
        Me.dsKeysDistinct = New System.Data.DataSet
        Me.dvKeysDistinct = New System.Data.DataView
        Me.dtKeysDistinct = New System.Data.DataTable
        Me.SqlDeleteCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand7 = New System.Data.SqlClient.SqlCommand
        Me.daCategories = New System.Data.SqlClient.SqlDataAdapter
        Me.dsCategories = New System.Data.DataSet
        Me.dvCategories = New System.Data.DataView
        Me.dtCategories = New System.Data.DataTable
        CType(Me.dsNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsObservations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsProblems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsNodesProblemsJoin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsKeysDistinct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvKeysDistinct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'cnHowToDB
        '
        Dim builder As New SqlClient.SqlConnectionStringBuilder
        builder.DataSource = "NENKESJLAPTOP" & "\SQL1"
        builder.InitialCatalog = "HowToDB"
        builder.IntegratedSecurity = True
        Me.cnHowToDB = New System.Data.SqlClient.SqlConnection
        Me.cnHowToDB.ConnectionString = builder.ConnectionString
        '
        ' Nodes
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand1.CommandText = "SELECT NodeID, TreeID, TypeID, ParentNodeID, TreeLevel, Heading, NodeText FROM No" & _
        "des WHERE (TreeID = 3)"
        Me.SqlSelectCommand1.Connection = Me.cnHowToDB
        '
        'SqlSelectCommand1
        '
        'Me.SqlSelectCommand1.CommandText = "SELECT NodeID, TreeID, TypeID, ParentNodeID, TreeLevel, Heading, NodeText FROM No" & _
        '"des"
        'Me.SqlSelectCommand1.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO Nodes(TreeID, TypeID, ParentNodeID, TreeLevel, Heading, NodeText) VAL" & _
        "UES (@TreeID, @TypeID, @ParentNodeID, @TreeLevel, @Heading, @NodeText); SELECT N" & _
        "odeID, TreeID, TypeID, ParentNodeID, TreeLevel, Heading, NodeText FROM Nodes WHE" & _
        "RE (NodeID = @@IDENTITY)"
        Me.SqlInsertCommand1.Connection = Me.cnHowToDB
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ParentNodeID", System.Data.SqlDbType.Int, 4, "ParentNodeID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeLevel", System.Data.SqlDbType.SmallInt, 2, "TreeLevel"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Heading", System.Data.SqlDbType.VarChar, 50, "Heading"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeText", System.Data.SqlDbType.VarChar, 2147483647, "NodeText"))
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE Nodes SET TreeID = @TreeID, TypeID = @TypeID, ParentNodeID = @ParentNodeID" & _
        ", TreeLevel = @TreeLevel, Heading = @Heading, NodeText = @NodeText WHERE (NodeID" & _
        " = @Original_NodeID) AND (Heading = @Original_Heading) AND (ParentNodeID = @Orig" & _
        "inal_ParentNodeID) AND (TreeID = @Original_TreeID) AND (TreeLevel = @Original_Tr" & _
        "eeLevel) AND (TypeID = @Original_TypeID); SELECT NodeID, TreeID, TypeID, ParentN" & _
        "odeID, TreeLevel, Heading, NodeText FROM Nodes WHERE (NodeID = @NodeID)"
        Me.SqlUpdateCommand1.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ParentNodeID", System.Data.SqlDbType.Int, 4, "ParentNodeID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeLevel", System.Data.SqlDbType.SmallInt, 2, "TreeLevel"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Heading", System.Data.SqlDbType.VarChar, 50, "Heading"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeText", System.Data.SqlDbType.VarChar, 2147483647, "NodeText"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Heading", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Heading", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ParentNodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ParentNodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeLevel", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM Nodes WHERE (NodeID = @Original_NodeID) AND (Heading = @Original_Head" & _
        "ing) AND (ParentNodeID = @Original_ParentNodeID) AND (TreeID = @Original_TreeID)" & _
        " AND (TreeLevel = @Original_TreeLevel) AND (TypeID = @Original_TypeID)"
        Me.SqlDeleteCommand1.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Heading", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Heading", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ParentNodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ParentNodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeLevel", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daNodes
        '
        Me.daNodes.DeleteCommand = Me.SqlDeleteCommand1
        Me.daNodes.InsertCommand = Me.SqlInsertCommand1
        Me.daNodes.SelectCommand = Me.SqlSelectCommand1
        Me.daNodes.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Nodes", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("ParentNodeID", "ParentNodeID"), New System.Data.Common.DataColumnMapping("TreeLevel", "TreeLevel"), New System.Data.Common.DataColumnMapping("Heading", "Heading"), New System.Data.Common.DataColumnMapping("NodeText", "NodeText")})})
        Me.daNodes.UpdateCommand = Me.SqlUpdateCommand1
        '
        'dsNodes
        '
        Me.dsNodes.DataSetName = "dsNodes"
        Me.dsNodes.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'dvNodes
        '
        Me.dtNodes = New DataTable()
        Me.dsNodes.Tables.Add(Me.dtNodes)
        Me.dvNodes = New System.Data.DataView(Me.dtNodes)
        'Me.dvNodes.Sort = "Heading"
        '
        'SqlSelectCommand3
        '
        Me.SqlSelectCommand3.CommandText = "SELECT ObservationID, ProblemID, Observation, Comment FROM Observations"
        Me.SqlSelectCommand3.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand3
        '
        Me.SqlInsertCommand3.CommandText = "INSERT INTO Observations(ProblemID, Observation, Comment) VALUES (@ProblemID, @Ob" & _
        "servation, @Comment); SELECT ObservationID, ProblemID, Observation, Comment FROM" & _
        " Observations WHERE (ObservationID = @@IDENTITY)"
        Me.SqlInsertCommand3.Connection = Me.cnHowToDB
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemID", System.Data.SqlDbType.Int, 4, "ProblemID"))
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observation", System.Data.SqlDbType.VarChar, 2147483647, "Observation"))
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.VarChar, 2147483647, "Comment"))
        '
        'SqlUpdateCommand3
        '
        Me.SqlUpdateCommand3.CommandText = "UPDATE Observations SET ProblemID = @ProblemID, Observation = @Observation, Comme" & _
        "nt = @Comment WHERE (ObservationID = @Original_ObservationID) AND (ProblemID = @" & _
        "Original_ProblemID); SELECT ObservationID, ProblemID, Observation, Comment FROM " & _
        "Observations WHERE (ObservationID = @ObservationID)"
        Me.SqlUpdateCommand3.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemID", System.Data.SqlDbType.Int, 4, "ProblemID"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observation", System.Data.SqlDbType.VarChar, 2147483647, "Observation"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.VarChar, 2147483647, "Comment"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ObservationID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ObservationID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ObservationID", System.Data.SqlDbType.SmallInt, 2, "ObservationID"))
        '
        'SqlDeleteCommand3
        '
        Me.SqlDeleteCommand3.CommandText = "DELETE FROM Observations WHERE (ObservationID = @Original_ObservationID) AND (Pro" & _
        "blemID = @Original_ProblemID)"
        Me.SqlDeleteCommand3.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ObservationID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ObservationID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daObservations
        '
        Me.daObservations.DeleteCommand = Me.SqlDeleteCommand3
        Me.daObservations.InsertCommand = Me.SqlInsertCommand3
        Me.daObservations.SelectCommand = Me.SqlSelectCommand3
        Me.daObservations.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Observations", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ObservationID", "ObservationID"), New System.Data.Common.DataColumnMapping("ProblemID", "ProblemID"), New System.Data.Common.DataColumnMapping("Observation", "Observation"), New System.Data.Common.DataColumnMapping("Comment", "Comment")})})
        Me.daObservations.UpdateCommand = Me.SqlUpdateCommand3
        '
        'dsObservations
        '
        Me.dsObservations.DataSetName = "dsObservations"
        Me.dsObservations.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'SqlSelectCommand2
        '
        Me.SqlSelectCommand2.CommandText = "SELECT ProblemID, NodeID, Title, Occurred, Impacts, Details, ProblemSystem, Probl" & _
        "emNo, Client, Lpar FROM Problems"
        Me.SqlSelectCommand2.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand2
        '
        Me.SqlInsertCommand2.CommandText = "INSERT INTO Problems(NodeID, Title, Occurred, Impacts, Details, ProblemSystem, Pr" & _
        "oblemNo, Client, Lpar) VALUES (@NodeID, @Title, @Occurred, @Impacts, @Details, @" & _
        "ProblemSystem, @ProblemNo, @Client, @Lpar); SELECT ProblemID, NodeID, Title, Occ" & _
        "urred, Impacts, Details, ProblemSystem, ProblemNo, Client, Lpar FROM Problems WH" & _
        "ERE (ProblemID = @@IDENTITY)"
        Me.SqlInsertCommand2.Connection = Me.cnHowToDB
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.VarChar, 50, "Title"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Occurred", System.Data.SqlDbType.DateTime, 8, "Occurred"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impacts", System.Data.SqlDbType.VarChar, 50, "Impacts"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Details", System.Data.SqlDbType.VarChar, 2147483647, "Details"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemSystem", System.Data.SqlDbType.VarChar, 50, "ProblemSystem"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemNo", System.Data.SqlDbType.Int, 4, "ProblemNo"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Client", System.Data.SqlDbType.VarChar, 50, "Client"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lpar", System.Data.SqlDbType.VarChar, 50, "Lpar"))
        '
        'SqlUpdateCommand2
        '
        Me.SqlUpdateCommand2.CommandText = "UPDATE Problems SET NodeID = @NodeID, Title = @Title, Occurred = @Occurred, Impac" & _
        "ts = @Impacts, Details = @Details, ProblemSystem = @ProblemSystem, ProblemNo = @" & _
        "ProblemNo, Client = @Client, Lpar = @Lpar WHERE (ProblemID = @Original_ProblemID" & _
        ") AND (Client = @Original_Client) AND (Impacts = @Original_Impacts) AND (Lpar = " & _
        "@Original_Lpar) AND (NodeID = @Original_NodeID) AND (Occurred = @Original_Occurr" & _
        "ed) AND (ProblemNo = @Original_ProblemNo) AND (ProblemSystem = @Original_Problem" & _
        "System) AND (Title = @Original_Title); SELECT ProblemID, NodeID, Title, Occurred" & _
        ", Impacts, Details, ProblemSystem, ProblemNo, Client, Lpar FROM Problems WHERE (" & _
        "ProblemID = @ProblemID)"
        Me.SqlUpdateCommand2.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.VarChar, 50, "Title"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Occurred", System.Data.SqlDbType.DateTime, 8, "Occurred"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impacts", System.Data.SqlDbType.VarChar, 50, "Impacts"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Details", System.Data.SqlDbType.VarChar, 2147483647, "Details"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemSystem", System.Data.SqlDbType.VarChar, 50, "ProblemSystem"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemNo", System.Data.SqlDbType.Int, 4, "ProblemNo"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Client", System.Data.SqlDbType.VarChar, 50, "Client"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lpar", System.Data.SqlDbType.VarChar, 50, "Lpar"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Client", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Client", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Impacts", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Impacts", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Lpar", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Lpar", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Occurred", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Occurred", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemNo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemNo", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemSystem", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemSystem", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProblemID", System.Data.SqlDbType.Int, 4, "ProblemID"))
        '
        'SqlDeleteCommand2
        '
        Me.SqlDeleteCommand2.CommandText = "DELETE FROM Problems WHERE (ProblemID = @Original_ProblemID) AND (Client = @Origi" & _
        "nal_Client) AND (Impacts = @Original_Impacts) AND (Lpar = @Original_Lpar) AND (N" & _
        "odeID = @Original_NodeID) AND (Occurred = @Original_Occurred) AND (ProblemNo = @" & _
        "Original_ProblemNo) AND (ProblemSystem = @Original_ProblemSystem) AND (Title = @" & _
        "Original_Title)"
        Me.SqlDeleteCommand2.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Client", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Client", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Impacts", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Impacts", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Lpar", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Lpar", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Occurred", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Occurred", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemNo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemNo", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProblemSystem", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProblemSystem", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        '
        'daProblems
        '
        Me.daProblems.DeleteCommand = Me.SqlDeleteCommand2
        Me.daProblems.InsertCommand = Me.SqlInsertCommand2
        Me.daProblems.SelectCommand = Me.SqlSelectCommand2
        Me.daProblems.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Problems", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ProblemID", "ProblemID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("Occurred", "Occurred"), New System.Data.Common.DataColumnMapping("Impacts", "Impacts"), New System.Data.Common.DataColumnMapping("Details", "Details"), New System.Data.Common.DataColumnMapping("ProblemSystem", "ProblemSystem"), New System.Data.Common.DataColumnMapping("ProblemNo", "ProblemNo"), New System.Data.Common.DataColumnMapping("Client", "Client"), New System.Data.Common.DataColumnMapping("Lpar", "Lpar")})})
        Me.daProblems.UpdateCommand = Me.SqlUpdateCommand2
        '
        'dsProblems
        '
        Me.dsProblems.DataSetName = "dsProblems"
        Me.dsProblems.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'SqlSelectCommand4
        '
        Me.SqlSelectCommand4.CommandText = "SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys"
        Me.SqlSelectCommand4.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand4
        '
        Me.SqlInsertCommand4.CommandText = "INSERT INTO Keys(TreeID, NodeID, TypeID, KeyText) VALUES (@TreeID, @NodeID, @Type" & _
        "ID, @KeyText); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (Ke" & _
        "yID = @@IDENTITY)"
        Me.SqlInsertCommand4.Connection = Me.cnHowToDB
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        '
        'SqlUpdateCommand4
        '
        Me.SqlUpdateCommand4.CommandText = "UPDATE Keys SET TreeID = @TreeID, NodeID = @NodeID, TypeID = @TypeID, KeyText = @" & _
        "KeyText WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText) AND (N" & _
        "odeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = @Origina" & _
        "l_TypeID); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (KeyID " & _
        "= @KeyID)"
        Me.SqlUpdateCommand4.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyID", System.Data.SqlDbType.Int, 4, "KeyID"))
        '
        'SqlDeleteCommand4
        '
        Me.SqlDeleteCommand4.CommandText = "DELETE FROM Keys WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText" & _
        ") AND (NodeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = " & _
        "@Original_TypeID)"
        Me.SqlDeleteCommand4.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daKeys
        '
        Me.daKeys.DeleteCommand = Me.SqlDeleteCommand4
        Me.daKeys.InsertCommand = Me.SqlInsertCommand4
        Me.daKeys.SelectCommand = Me.SqlSelectCommand4
        Me.daKeys.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Keys", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("KeyID", "KeyID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("KeyText", "KeyText")})})
        Me.daKeys.UpdateCommand = Me.SqlUpdateCommand4
        '
        'dsKeys
        '
        Me.dsKeys.DataSetName = "dsKeys"
        Me.dsKeys.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'dvKeys
        '
        Me.dtKeys = New DataTable()
        Me.dsKeys.Tables.Add(Me.dtKeys)
        Me.dvKeys = New System.Data.DataView(Me.dtKeys)
        'Me.dvKeys.Sort = "KeyText"
        '
        'SqlSelectCommand5
        '
        Me.SqlSelectCommand5.CommandText = "SELECT DISTINCT KeyText, TreeID FROM Keys"
        Me.SqlSelectCommand5.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand5
        '
        Me.SqlInsertCommand5.CommandText = "INSERT INTO Keys(TreeID, NodeID, TypeID, KeyText) VALUES (@TreeID, @NodeID, @Type" & _
        "ID, @KeyText); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (Ke" & _
        "yID = @@IDENTITY)"
        Me.SqlInsertCommand5.Connection = Me.cnHowToDB
        Me.SqlInsertCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlInsertCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        '
        'SqlUpdateCommand5
        '
        Me.SqlUpdateCommand5.CommandText = "UPDATE Keys SET TreeID = @TreeID, NodeID = @NodeID, TypeID = @TypeID, KeyText = @" & _
        "KeyText WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText) AND (N" & _
        "odeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = @Origina" & _
        "l_TypeID); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (KeyID " & _
        "= @KeyID)"
        Me.SqlUpdateCommand5.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyID", System.Data.SqlDbType.Int, 4, "KeyID"))
        '
        'SqlDeleteCommand5
        '
        Me.SqlDeleteCommand5.CommandText = "DELETE FROM Keys WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText" & _
        ") AND (NodeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = " & _
        "@Original_TypeID)"
        Me.SqlDeleteCommand5.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daKeysDistinct
        '
        Me.daKeysDistinct.DeleteCommand = Me.SqlDeleteCommand5
        Me.daKeysDistinct.InsertCommand = Me.SqlInsertCommand5
        Me.daKeysDistinct.SelectCommand = Me.SqlSelectCommand5
        Me.daKeysDistinct.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Keys", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("KeyID", "KeyID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("KeyText", "KeyText")})})
        Me.daKeysDistinct.UpdateCommand = Me.SqlUpdateCommand5
        '
        'dsKeysDistinct
        '
        Me.dsKeysDistinct.DataSetName = "dsKeysDistinct"
        Me.dsKeysDistinct.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'dvKeysDistinct
        '
        Me.dtKeysDistinct = New DataTable()
        Me.dsKeysDistinct.Tables.Add(Me.dtKeysDistinct)
        Me.dvKeysDistinct = New System.Data.DataView(Me.dtKeysDistinct)
        'Me.dvKeysDistinct.Sort = "KeyText"
        '
        'SqlDeleteCommand6
        '
        Me.SqlDeleteCommand6.CommandText = "DELETE FROM Nodes WHERE (NodeID = @Original_NodeID) AND (Heading = @Original_Head" & _
        "ing)"
        Me.SqlDeleteCommand6.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Heading", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Heading", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlInsertCommand6
        '
        Me.SqlInsertCommand6.CommandText = "INSERT INTO Nodes(Heading) VALUES (@Heading)"
        Me.SqlInsertCommand6.Connection = Me.cnHowToDB
        Me.SqlInsertCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Heading", System.Data.SqlDbType.VarChar, 50, "Heading"))
        '
        'SqlSelectCommand6
        '
        Me.SqlSelectCommand6.CommandText = "SELECT * FROM Nodes INNER JOIN Problems ON Nodes.NodeID = Problems.NodeID"
        Me.SqlSelectCommand6.Connection = Me.cnHowToDB
        '
        'SqlUpdateCommand6
        '
        Me.SqlUpdateCommand6.CommandText = "UPDATE Nodes SET Heading = @Heading WHERE (NodeID = @Original_NodeID) AND (Headin" & _
        "g = @Original_Heading)"
        Me.SqlUpdateCommand6.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Heading", System.Data.SqlDbType.VarChar, 50, "Heading"))
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Heading", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Heading", System.Data.DataRowVersion.Original, Nothing))
        '
        'daNodesProblemsJoin
        '
        Me.daNodesProblemsJoin.DeleteCommand = Me.SqlDeleteCommand6
        Me.daNodesProblemsJoin.InsertCommand = Me.SqlInsertCommand6
        Me.daNodesProblemsJoin.SelectCommand = Me.SqlSelectCommand6
        Me.daNodesProblemsJoin.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Nodes", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("Heading", "Heading")})})
        Me.daNodesProblemsJoin.UpdateCommand = Me.SqlUpdateCommand6
        '
        'dsNodesProblemsJoin
        '
        Me.dsNodesProblemsJoin.DataSetName = "dsNodesProblemsJoin"
        Me.dsNodesProblemsJoin.Locale = New System.Globalization.CultureInfo("en-AU")        '
        'SqlSelectCommand7
        '
        Me.SqlSelectCommand7.CommandText = "SELECT DISTINCT Options, CategoryID FROM Categories WHERE (Categories = @Category" & _
        ")"
        Me.SqlSelectCommand7.Connection = Me.cnHowToDB
        Me.SqlSelectCommand7.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Category", System.Data.SqlDbType.VarChar, 15, "Categories"))
        '
        'daCategories
        '
        Me.daCategories.DeleteCommand = Me.SqlDeleteCommand7
        Me.daCategories.InsertCommand = Me.SqlInsertCommand7
        Me.daCategories.SelectCommand = Me.SqlSelectCommand7
        Me.daCategories.UpdateCommand = Me.SqlUpdateCommand7
        '
        'dsCategories
        '
        Me.dsCategories.DataSetName = "dsCategories"
        Me.dsCategories.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'dvCategories
        '
        Me.dtCategories = New DataTable()
        Me.dsCategories.Tables.Add(Me.dtCategories)
        Me.dvCategories = New System.Data.DataView(Me.dtCategories)
        'Me.dvCategories.Sort = "CategoryID"

        CType(Me.dsNodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsObservations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsProblems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsNodesProblemsJoin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsKeys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsKeysDistinct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCategories, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvNodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvKeys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvKeysDistinct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvCategories, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim Problem As ProblemTree
    Dim NodeType, TreeType As Integer
    Dim SelectCommandText As String

    Dim ObservationOperation As String
    Dim ObservationItem As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim builder As New SqlConnectionStringBuilder
        Dim NodeType, TreeType As Integer
        Dim SelectCommandText As String

        builder.DataSource = "NENKESJLAPTOP" & "\SQL1"
        builder.InitialCatalog = "HowToDB"
        builder.IntegratedSecurity = True
        Using linkToDB As New SqlConnection(builder.ConnectionString)
            linkToDB.Open()
            Problem = New ProblemTree(daNodes, _
                     daKeys, _
                     daKeysDistinct, _
                     daProblems, _
                     daObservations, _
                     daNodesProblemsJoin, _
                     daCategories, _
                     dsNodes, _
                     dsKeys, _
                     dsKeysDistinct, _
                     dsProblems, _
                     dsObservations, _
                     dsNodesProblemsJoin, _
                     dsCategories, _
                     dvNodes, _
                     dvKeys, _
                     dvKeysDistinct, _
                     dvCategories, _
                     dtNodes, _
                     dtTempNodes, _
                     dtKeys, _
                     dtKeysDistinct, _
                     dtCategories, _
                     lbxNodes, _
                     lbxKeys, _
                     drpKeys, _
                     drpFilterOn, _
                     drpSearchOn, _
                     drpTxtType, _
                     drpTxtOpr, _
                     btnUp, _
                     btnDown, _
                     btnSummary, _
                     btnRefresh, _
                     btnEdit, _
                     btnNew, _
                     btnNewChild, _
                     btnSave, _
                     btnAddKeyWord, _
                     btnSaveObservation, _
                     btnPrevObservation, _
                     btnNextObservation, _
                     btnGo, _
                     btnBackOut, _
                     btnSearch, _
                     btnSrchBack, _
                     txtFilterText, _
                     txtSearchFilter, _
                     txtKeyWord, _
                     txtTitle, _
                     txtType, _
                     txtNo, _
                     txtWhen, _
                     txtWhere, _
                     txtClient, _
                     txtImpacts, _
                     txtSolution, _
                     txtDetails, _
                     txtComments, _
                     txtObservations, _
                     txtTxtSpecs)
            If Not (Page.IsPostBack) Then
                ' Initialize all settings
                NodeType = 6
                TreeType = 3
                SelectCommandText = "SELECT * FROM Nodes INNER JOIN Problems ON Nodes.NodeID = Problems.NodeID"
                'SelectCommandText = "SELECT * FROM Nodes WHERE TreeID = 3"
                Problem.InitialSettings(TreeType, NodeType, SelectCommandText)
                ' Bind Controls (Dont Clear, Fill and Bind)
                Problem.BindNodes(False, True, True)
                Problem.BindKeys(False, True, True)
                'Problem.BindCategories(False, True, True)
                Problem.NodeChanged()
                SetViewStates("Define")
                SetViewStates("All")
            Else
                ' Copy from viewstate variables
                SetViewStates("PostBack")
                ' Refill datasets (Dont Clear, Fill but Dont Bind)
                Problem.BindNodes(False, True, False)
                Problem.BindKeys(False, True, False)
                'Problem.BindCategories(False, True, False)
            End If
        End Using
    End Sub

    Private Sub SetViewStates(ByVal TypeID As String)
        Select Case TypeID
            Case "Define"
                ViewState.Add(ViewState.Count, "CurrentTree")
                ViewState.Add(ViewState.Count, "NodeType")
                ViewState.Add(ViewState.Count, "SelectedNode")
                ViewState.Add(ViewState.Count, "ParentNode")
                ViewState.Add(ViewState.Count, "CurrentLevel")
                ViewState.Add(ViewState.Count, "Operation")
                ViewState.Add(ViewState.Count, "SelectCmd")
                ViewState.Add(ViewState.Count, "NodeSelectCmd")
                ViewState.Add(ViewState.Count, "NodeFilter")
                ViewState.Add(ViewState.Count, "SearchFilter")
                ViewState.Add(ViewState.Count, "SelectedKey")
                ViewState.Add(ViewState.Count, "Item")
                ViewState.Add(ViewState.Count, "SavedYet")
                ViewState.Add(ViewState.Count, "ObservationOperation")
                ViewState.Add(ViewState.Count, "ObservationText")
                ViewState.Add(ViewState.Count, "ObservationAlteredText")
                ViewState.Add(ViewState.Count, "ObservationTextLength")
                ViewState.Add(ViewState.Count, "ObservationAlteredTextLength")
                ViewState.Add(ViewState.Count, "ObservationTextType")
                ViewState.Add(ViewState.Count, "ObservationTextOpr")
                ViewState.Add(ViewState.Count, "ObservationTextSpecs")
                ViewState.Add(ViewState.Count, "ObservationCommentSaved")
                ViewState.Add(ViewState.Count, "ObservationCommentSuffix")
            Case "All"
                ViewState("CurrentTree") = Problem.CurrentTree
                ViewState("NodeType") = Problem.NodeType
                ViewState("SelectedNode") = Problem.SelectedNode
                ViewState("ParentNode") = Problem.ParentNode
                ViewState("CurrentLevel") = Problem.CurrentLevel
                ViewState("Operation") = Problem.Operation
                ViewState("SelectCmd") = Problem.DefaultSelectCmd
                ViewState("NodeSelectCmd") = Problem.NodeSelectCmd
                ViewState("NodeFilter") = Problem.NodeFilter
                ViewState("SearchFilter") = Problem.SearchFilter
                ViewState("SelectedKey") = Problem.SelectedKey
                ViewState("Item") = Problem.Item
                ViewState("SavedYet") = Problem.SavedYet
                ViewState("ObservationOperation") = Problem.ObservationOperation
                ViewState("ObservationText") = Problem.ObservationText
                ViewState("ObservationAlteredText") = Problem.ObservationAlteredText
                ViewState("ObservationTextLength") = Problem.ObservationTextLength
                ViewState("ObservationAlteredTextLength") = Problem.ObservationAlteredTextLength
                ViewState("ObservationTextType") = Problem.ObservationTextType
                ViewState("ObservationTextOpr") = Problem.ObservationTextOpr
                ViewState("ObservationTextSpecs") = Problem.ObservationTextSpecs
                ViewState("ObservationCommentSaved") = Problem.ObservationCommentSaved
                ViewState("ObservationCommentSuffix") = Problem.ObservationCommentSuffix
            Case "PostBack"
                Problem.CurrentTree = ViewState("CurrentTree")
                Problem.NodeType = ViewState("NodeType")
                Problem.SelectedNode = ViewState("SelectedNode")
                Problem.ParentNode = ViewState("ParentNode")
                Problem.CurrentLevel = ViewState("CurrentLevel")
                Problem.Operation = ViewState("Operation")
                Problem.DefaultSelectCmd = ViewState("SelectCmd")
                Problem.NodeSelectCmd = ViewState("NodeSelectCmd")
                Problem.NodeFilter = ViewState("NodeFilter")
                Problem.SearchFilter = ViewState("SearchFilter")
                Problem.SelectedKey = ViewState("SelectedKey")
                Problem.Item = ViewState("Item")
                Problem.SavedYet = ViewState("SavedYet")
                Problem.ObservationOperation = ViewState("ObservationOperation")
                Problem.ObservationText = ViewState("ObservationText")
                Problem.ObservationAlteredText = ViewState("ObservationAlteredText")
                Problem.ObservationTextLength = ViewState("ObservationTextLength")
                Problem.ObservationAlteredTextLength = ViewState("ObservationAlteredTextLength")
                Problem.ObservationTextType = ViewState("ObservationTextType")
                Problem.ObservationTextOpr = ViewState("ObservationTextOpr")
                Problem.ObservationTextSpecs = ViewState("ObservationTextSpecs")
                Problem.ObservationCommentSaved = ViewState("ObservationCommentSaved")
                Problem.ObservationCommentSuffix = ViewState("ObservationCommentSuffix")
            Case "Op"
                ViewState("Operation") = Problem.Operation
                ViewState("SavedYet") = Problem.SavedYet
                ViewState("ObservationOperation") = Problem.ObservationOperation
            Case "SelectedKey"
                ViewState("SelectedKey") = Problem.SelectedKey
            Case "SelectedTextType"
                ViewState("ObservationTextType") = Problem.ObservationTextType
            Case "SelectedTextOpr"
                ViewState("ObservationTextOpr") = Problem.ObservationTextOpr
            Case "ObservationTextOperation"
                ViewState("ObservationText") = Problem.ObservationText
                ViewState("ObservationAlteredText") = Problem.ObservationAlteredText
                ViewState("ObservationTextLength") = Problem.ObservationTextLength
                ViewState("ObservationAlteredTextLength") = Problem.ObservationAlteredTextLength
                ViewState("ObservationTextSpecs") = Problem.ObservationTextSpecs
                ViewState("ObservationTextType") = Problem.ObservationTextType
                ViewState("ObservationCommentSaved") = Problem.ObservationCommentSaved
                ViewState("ObservationCommentSuffix") = Problem.ObservationCommentSuffix
            Case "Item"
                ViewState("Item") = Problem.Item
            Case "ObservationOperation"
                ViewState("ObservationOperation") = Problem.ObservationOperation
        End Select
    End Sub

    ' Drop down list items changed

    Private Sub drpPage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpPage.SelectedIndexChanged
        Select Case drpPage.SelectedItem.Text
            Case "Code"
                Server.Transfer("Code.aspx")
            Case "Notes"
                Server.Transfer("Default.aspx")
            Case "How To"
                Server.Transfer("HowTo.aspx")
            Case "Tasks"
                Server.Transfer("Tasks.aspx")
            Case "Messages"
                Server.Transfer("Messages.aspx")
        End Select
    End Sub

    Private Sub drpTxtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpTxtType.SelectedIndexChanged
        Problem.ObservationTextType = drpTxtType.SelectedItem.Text
        SetViewStates("SelectedTextType")
        ' Fill control with subcategories for this category
        dsCategories.Clear()
        daCategories.SelectCommand.Parameters("@Category").Value = Problem.ObservationTextType
        daCategories.Fill(dsCategories)
        drpTxtOpr.Enabled = True
        txtTxtSpecs.Enabled = True
        drpTxtOpr.DataBind()
        btnGo.ImageUrl = "images\Icons\Go.png"
        btnGo.Enabled = True
    End Sub

    Private Sub drpTxtOpr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpTxtOpr.SelectedIndexChanged
        Problem.ObservationTextOpr = drpTxtOpr.SelectedItem.Text
        SetViewStates("SelectedTextOpr")
    End Sub

    Private Sub lbxNodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxNodes.SelectedIndexChanged
        Problem.NodeChanged()
        SetViewStates("All")
    End Sub

    Private Sub lbxKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxKeys.SelectedIndexChanged
        Problem.SelectedKey = lbxKeys.SelectedItem.Text
        SetViewStates("SelectedKey")
    End Sub

    ' Buttons Clicked

    ' Problem Tools Buttons

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRefresh.Click
        ' This calls:- SetViewStates BindProblems NodeChanged
        Problem.Refresh()
        SetViewStates("All")
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDown.Click
        Problem.Down()
        SetViewStates("All")
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUp.Click
        Problem.Up()
        SetViewStates("All")
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNew.Click
        Problem.NewNode()
        SetViewStates("Op")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEdit.Click
        Problem.Edit()
        SetViewStates("Op")
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnInsert.Click
        Problem.Insert()
        SetViewStates("Op")
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCopy.Click
        Problem.Copy()
        SetViewStates("Op")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Problem.Save()
        SetViewStates("All")
    End Sub

    ' Search Tools Buttons

    Private Sub btnSearchRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearchRefresh.Click
        Problem.SearchRefresh()
        SetViewStates("All")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        Problem.Search()
        SetViewStates("All")
    End Sub

    Private Sub btnAddKeyWord_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddKeyWord.Click
        Problem.AddKeyWord()
    End Sub

    ' Observation Buttons

    Private Sub btnPrevObservation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPrevObservation.Click
        Problem.PrevObservation()
        SetViewStates("Item")
        SetViewStates("ObservationOperation")
    End Sub

    Private Sub btnNextObservation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNextObservation.Click
        Problem.NextObservation()
        SetViewStates("Item")
        SetViewStates("ObservationOperation")
    End Sub

    Private Sub btnNewObservation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNewObservation.Click
        Problem.NewObservation()
        SetViewStates("Item")
        SetViewStates("ObservationOperation")
    End Sub

    Private Sub btnEditObservation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEditObservation.Click
        Problem.EditObservation()
        SetViewStates("ObservationOperation")
    End Sub

    Private Sub btnSaveObservation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveObservation.Click
        Problem.SaveObservation()
        SetViewStates("Item")
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGo.Click
        Problem.ObservationTextSpecs = txtTxtSpecs.Text
        Problem.ObservationText = txtObservations.Text
        Problem.ObservationTextLength = txtObservations.Text.Length
        Problem.ObservationTextNoOfLines = 0
        Problem.ObservationTextNoOfMsgs = 0
        Problem.ObservationAlteredText = ""
        Problem.ObservationAlteredTextLength = 0
        Problem.ObservationAlteredTextNoOfLines = 0
        Problem.ObservationAlteredTextNoOfMsgs = 0
        Problem.ObservationCommentSuffix = ""
        Problem.ObservationCommentSaved = txtComments.Text
        Problem.ObservationTextOperation()
        txtObservations.Text = Problem.ObservationAlteredText
        Select Case Problem.ObservationTextType
            Case "Lines"
                Problem.ObservationCommentSuffix = _
                        "Altered Text Length - " & Problem.ObservationAlteredTextLength & _
                        " No of Lines - " & Problem.ObservationAlteredTextNoOfLines & _
                        Chr(13) & Chr(10) & Problem.ObservationCommentSuffix
            Case "SYSLOG"
                Problem.ObservationCommentSuffix = _
                        "Altered Text Length - " & Problem.ObservationAlteredTextLength & _
                        " No of Messages - " & Problem.ObservationAlteredTextNoOfMsgs & _
                        Chr(13) & Chr(10) & Problem.ObservationCommentSuffix
            Case "JESMSGLG"
                Problem.ObservationCommentSuffix = _
                        "Altered Text Length - " & Problem.ObservationAlteredTextLength & _
                        " No of Messages - " & Problem.ObservationAlteredTextNoOfMsgs & _
                        Chr(13) & Chr(10) & Problem.ObservationCommentSuffix
        End Select
        txtComments.Text = Problem.ObservationCommentSuffix & Chr(13) & Chr(10) & txtComments.Text
        SetViewStates("ObservationTextOperation")
        btnBackOut.ImageUrl = "images\Icons\No.png"
        btnBackOut.Enabled = True
    End Sub

    Private Sub btnBackOut_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBackOut.Click
        txtObservations.Text = Problem.ObservationText
        txtComments.Text = Problem.ObservationCommentSaved
        SetViewStates("ObservationTextOperation")
        btnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
        btnBackOut.Enabled = False
        Problem.ObservationAlteredText = ""
        Problem.ObservationAlteredTextLength = 0
        Problem.ObservationTextSpecs = ""
    End Sub
End Class