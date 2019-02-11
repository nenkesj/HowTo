Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Backup
    Inherits System.Web.UI.Page

    ' 
    ' To check the Notes page do the following
    '
    ' 1.  Select another node than the one displayed check the new node is 
    '     displayed - OK
    ' 2.  Check that the Keys drop down has been updated - OK
    ' 3.  Check Down buttons functions as expected - OK
    ' 4.  Check Up buttons functions as expected - OK
    ' 5.  Go to a node with multiple pictures Debugging .NET Problems -> 
    '     Debugging 101 -> Debug The ... Scroll forward and back through the
    '     Pictures
    ' 6.  Edit a node & Save, Go to another node come back & check the changes 
    '     are there - OK
    ' 7.  Find a node with a summary hide and reshow the summary
    ' 8.  Edit a summary and save it go to another node come back and check the
    '     summary changes are still there
    ' 9.  Filter nodes on a heading & clear filter - OK
    ' 10. Filter keys & clear filter - OK
    ' 11. Select a key click the Find button - OK
    ' 12. Filter keys, select a key and do a search on the key then clear the 
    '     search - OK
    ' 
    '     The following tests require a little more work and can be left
    '     if not convenient
    '
    ' 13. Create a new note & Save at the top level of the tree - OK
    ' 14. Create a new note & Save at a level other than the top level of the 
    '     tree
    ' 15. Create a new child node & Save - OK
    ' 16. Create a new note setting Chapter & Section Keywords for the
    '     following new note & Save
    ' 17. Create a new child node & Save setting Chapter & Section Keywords for     

    '     the following new note & Save
    ' 18. Go back to the previous new note & ensure it includes the 
    '     Chapter & Section keys - OK
    ' 19. Go back to the new child note & ensure it includes the 
    '     Chapter & Section keys - OK
    ' 20. Add a new key for a node - OK
    ' 21. Test combining a key filter with a node filter & clear both 
    '     as follows 
    '     1st select key then filter nodes then clear - OK 
    '     2nd set node filter then set search key then clear - OK
    '     3rd select key search then select another key & search then 
    '         Clear - OK
    '     4th try select keys search then search again on same key & 
    '         Clear - OK
    '
#Region " Web Form Designer Generated Code "

    Protected WithEvents cnHowToDB As System.Data.SqlClient.SqlConnection
    Protected WithEvents daNodes As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsNodes As System.Data.DataSet
    Protected WithEvents dvNodes As System.Data.DataView
    Protected WithEvents dtNodes As System.Data.DataTable
    Protected WithEvents dtTempNodes As System.Data.DataTable
    Protected WithEvents daInfo As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsInfo As System.Data.DataSet
    Protected WithEvents dvInfo As System.Data.DataView
    Protected WithEvents dtInfo As System.Data.DataTable
    Protected WithEvents daKeys As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsKeys As System.Data.DataSet
    Protected WithEvents dvKeys As System.Data.DataView
    Protected WithEvents dtKeys As System.Data.DataTable
    Protected WithEvents daKeysDistinct As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsKeysDistinct As System.Data.DataSet
    Protected WithEvents dtKeysDistinct As System.Data.DataTable
    Protected WithEvents dvKeysDistinct As System.Data.DataView
    Protected WithEvents daPictures As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsPictures As System.Data.DataSet
    Protected WithEvents dtPictures As System.Data.DataTable
    Protected WithEvents dvPictures As System.Data.DataView
    Protected WithEvents daTypes As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsTypes As System.Data.DataSet
    Protected WithEvents dvTypes As System.Data.DataView
    Protected WithEvents dtTypes As System.Data.DataTable
    Protected WithEvents daSummaries As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsSummaries As System.Data.DataSet
    Protected WithEvents dtSummaries As System.Data.DataTable
    Protected WithEvents daCategories As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents dsCategories As System.Data.DataSet
    Protected WithEvents dvCategories As System.Data.DataView
    Protected WithEvents dtCategories As System.Data.DataTable
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand4 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand5 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand6 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand7 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand8 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand8 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand8 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand8 As System.Data.SqlClient.SqlCommand

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
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
        "des WHERE (TreeID = 2)"
        Me.SqlSelectCommand1.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
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
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
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
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
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
        'Me.dsNodes = New How_To.dsNodes
        '
        Me.daNodes = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand1.ToString(), cnHowToDB)
        Me.daNodes.DeleteCommand = Me.SqlDeleteCommand1
        Me.daNodes.InsertCommand = Me.SqlInsertCommand1
        Me.daNodes.SelectCommand = Me.SqlSelectCommand1
        Me.daNodes.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Nodes", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("ParentNodeID", "ParentNodeID"), New System.Data.Common.DataColumnMapping("TreeLevel", "TreeLevel"), New System.Data.Common.DataColumnMapping("Heading", "Heading"), New System.Data.Common.DataColumnMapping("NodeText", "NodeText")})})
        Me.daNodes.UpdateCommand = Me.SqlUpdateCommand1
        '
        'dsNodes
        '
        Me.dsNodes = New DataSet()
        Me.dsNodes.DataSetName = "dsNodes"
        Me.dsNodes.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dtNodes = New DataTable()
        Me.dsNodes.Tables.Add(Me.dtNodes)
        Me.dtTempNodes = New DataTable()
        Me.dsNodes.Tables.Add(Me.dtTempNodes)
        Me.dvNodes = New System.Data.DataView(Me.dtNodes)
        'Me.dvNodes.Sort = "Heading"
        '
        ' Info
        '
        'SqlSelectCommand8
        '
        Me.SqlSelectCommand8 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand8.CommandText = "SELECT InfoID, NodeID, TreeID, TypeID, Heading, InfoText FROM In" & _
    "fo WHERE (TreeID = 2)"
        Me.SqlSelectCommand8.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand8
        '
        Me.SqlInsertCommand8 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand8.CommandText = "INSERT INTO Info(NodeID, TreeID, TypeID, Heading, InfoText) VAL" & _
        "UES (@NodeID, @TreeID, @TypeID, @Heading, @InfoText); SELECT InfoID, N" & _
        "odeID, TreeID, TypeID, Heading, InfoText FROM Info WHE" & _
        "RE (InfoID = @@IDENTITY)"
        Me.SqlInsertCommand8.Connection = Me.cnHowToDB
        Me.SqlInsertCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlInsertCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Heading", System.Data.SqlDbType.VarChar, 50, "Heading"))
        Me.SqlInsertCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InfoText", System.Data.SqlDbType.VarChar, 2147483647, "InfoText"))
        '
        'SqlUpdateCommand8
        '
        Me.SqlUpdateCommand8 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand8.CommandText = "UPDATE Info SET NodeID = @NodeID, TreeID = @TreeID, TypeID = @TypeID, " & _
        "Heading = @Heading, InfoText = @InfoText WHERE (InfoID = @Original_InfoID) AND " & _
        "(Heading = @Original_Heading) AND (NodeID = @Original_NodeID) AND " & _
        "(TreeID = @Original_TreeID) AND (TypeID = @Original_TypeID);" & _
        " SELECT InfoID, NodeID, TreeID, TypeID, " & _
        "Heading, InfoText FROM Info WHERE (InfoID = @InfoID)"
        Me.SqlUpdateCommand8.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Heading", System.Data.SqlDbType.VarChar, 50, "Heading"))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InfoText", System.Data.SqlDbType.VarChar, 2147483647, "InfoText"))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_InfoID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "InfoID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Heading", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Heading", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InfoID", System.Data.SqlDbType.Int, 4, "InfoID"))
        '
        'SqlDeleteCommand8
        '
        Me.SqlDeleteCommand8 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand8.CommandText = "DELETE FROM Info WHERE (InfoID = @Original_InfoID) AND (Heading = @Original_Head" & _
        "ing) AND (NodeID = @Original_NodeID) AND (TypeID = @Original_TypeID)"
        Me.SqlDeleteCommand8.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_InfoID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "InfoID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Heading", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Heading", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand8.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        Me.daInfo = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand8.ToString(), cnHowToDB)
        Me.daInfo.DeleteCommand = Me.SqlDeleteCommand8
        Me.daInfo.InsertCommand = Me.SqlInsertCommand8
        Me.daInfo.SelectCommand = Me.SqlSelectCommand8
        Me.daInfo.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Info", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("InfoID", "InfoID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("Heading", "Heading"), New System.Data.Common.DataColumnMapping("InfoText", "InfoText")})})
        Me.daInfo.UpdateCommand = Me.SqlUpdateCommand8
        '
        'dsInfo
        '
        Me.dsInfo = New DataSet()
        Me.dsInfo.DataSetName = "dsInfo"
        Me.dsInfo.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dtInfo = New DataTable()
        Me.dsInfo.Tables.Add(Me.dtInfo)
        Me.dvInfo = New System.Data.DataView(Me.dtInfo)
        'Me.dvInfo.Sort = "Heading"
        '
        ' Keys
        '
        'SqlSelectCommand2
        '
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand2.CommandText = "SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys"
        Me.SqlSelectCommand2.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand2
        '
        Me.SqlInsertCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand2.CommandText = "INSERT INTO Keys(TreeID, NodeID, TypeID, KeyText) VALUES (@TreeID, @NodeID, @Type" & _
        "ID, @KeyText); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (Ke" & _
        "yID = @@IDENTITY)"
        Me.SqlInsertCommand2.Connection = Me.cnHowToDB
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        '
        'SqlUpdateCommand2
        '
        Me.SqlUpdateCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand2.CommandText = "UPDATE Keys SET TreeID = @TreeID, NodeID = @NodeID, TypeID = @TypeID, KeyText = @" & _
                "KeyText WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText) AND (N" & _
                "odeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = @Origina" & _
                "l_TypeID); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (KeyID " & _
                "= @KeyID)"
        Me.SqlUpdateCommand2.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyID", System.Data.SqlDbType.Int, 4, "KeyID"))
        '
        'SqlDeleteCommand2
        '
        Me.SqlDeleteCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand2.CommandText = "DELETE FROM Keys WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText" & _
        ") AND (NodeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = " & _
        "@Original_TypeID)"
        Me.SqlDeleteCommand2.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daKeys
        '
        Me.daKeys = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand2.ToString(), cnHowToDB)
        Me.daKeys = New System.Data.SqlClient.SqlDataAdapter
        Me.daKeys.DeleteCommand = Me.SqlDeleteCommand2
        Me.daKeys.InsertCommand = Me.SqlInsertCommand2
        Me.daKeys.SelectCommand = Me.SqlSelectCommand2
        Me.daKeys.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Keys", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("KeyID", "KeyID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("KeyText", "KeyText")})})
        Me.daKeys.UpdateCommand = Me.SqlUpdateCommand2
        '
        'dsKeys
        '
        Me.dsKeys = New DataSet()
        Me.dsKeys.DataSetName = "dsKeys"
        Me.dsKeys.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dtKeys = New DataTable()
        Me.dsKeys.Tables.Add(Me.dtKeys)
        Me.dvKeys = New System.Data.DataView(Me.dtKeys)
        '
        ' Keys Dispinct
        '
        'SqlSelectCommand3
        '
        Me.SqlSelectCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand3.CommandText = "SELECT DISTINCT KeyText, TreeID FROM Keys"
        Me.SqlSelectCommand3.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand3
        '
        Me.SqlInsertCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand3.CommandText = "INSERT INTO Keys(TreeID, NodeID, TypeID, KeyText) VALUES (@TreeID, @NodeID, @Type" & _
                "ID, @KeyText); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (Ke" & _
                "yID = @@IDENTITY)"
        Me.SqlInsertCommand3.Connection = Me.cnHowToDB
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        '
        'SqlUpdateCommand3
        '
        Me.SqlUpdateCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand3.CommandText = "UPDATE Keys SET TreeID = @TreeID, NodeID = @NodeID, TypeID = @TypeID, KeyText = @" & _
        "KeyText WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText) AND (N" & _
        "odeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = @Origina" & _
        "l_TypeID); SELECT KeyID, TreeID, NodeID, TypeID, KeyText FROM Keys WHERE (KeyID " & _
        "= @KeyID)"
        Me.SqlUpdateCommand3.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TreeID", System.Data.SqlDbType.SmallInt, 2, "TreeID"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyText", System.Data.SqlDbType.VarChar, 100, "KeyText"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@KeyID", System.Data.SqlDbType.Int, 4, "KeyID"))
        '
        'SqlDeleteCommand3
        '
        Me.SqlDeleteCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand3.CommandText = "DELETE FROM Keys WHERE (KeyID = @Original_KeyID) AND (KeyText = @Original_KeyText" & _
        ") AND (NodeID = @Original_NodeID) AND (TreeID = @Original_TreeID) AND (TypeID = " & _
        "@Original_TypeID)"
        Me.SqlDeleteCommand3.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_KeyText", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "KeyText", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TreeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TreeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daKeysDistinct
        '
        Me.daKeysDistinct = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand3.ToString(), cnHowToDB)
        Me.daKeysDistinct = New System.Data.SqlClient.SqlDataAdapter
        Me.daKeysDistinct.DeleteCommand = Me.SqlDeleteCommand3
        Me.daKeysDistinct.InsertCommand = Me.SqlInsertCommand3
        Me.daKeysDistinct.SelectCommand = Me.SqlSelectCommand3
        Me.daKeysDistinct.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Keys", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("KeyID", "KeyID"), New System.Data.Common.DataColumnMapping("TreeID", "TreeID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("KeyText", "KeyText")})})
        Me.daKeysDistinct.UpdateCommand = Me.SqlUpdateCommand3
        '
        'dsKeysDistinct
        '
        Me.dsKeysDistinct = New DataSet()
        Me.dsKeysDistinct.DataSetName = "dsKeysDistinct"
        Me.dsKeys.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dtKeysDistinct = New DataTable()
        Me.dsKeysDistinct.Tables.Add(Me.dtKeysDistinct)
        Me.dvKeysDistinct = New System.Data.DataView(Me.dtKeysDistinct)

        '
        'SqlSelectCommand4
        '
        Me.SqlSelectCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand4.CommandText = "SELECT PictureID, NodeID, TypeID, Picture, Title, PictureSize, DisplayAt, Display" & _
        "StopAt FROM Pictures"
        Me.SqlSelectCommand4.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand4
        '
        Me.SqlInsertCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand4.CommandText = "INSERT INTO Pictures(NodeID, TypeID, Picture, Title, PictureSize, DisplayAt, Disp" & _
        "layStopAt) VALUES (@NodeID, @TypeID, @Picture, @Title, @PictureSize, @DisplayAt," & _
        " @DisplayStopAt); SELECT PictureID, NodeID, TypeID, Picture, Title, PictureSize," & _
        " DisplayAt, DisplayStopAt FROM Pictures WHERE (PictureID = @@IDENTITY)"
        Me.SqlInsertCommand4.Connection = Me.cnHowToDB
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarChar, 200, "Picture"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.VarChar, 100, "Title"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PictureSize", System.Data.SqlDbType.Int, 4, "PictureSize"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DisplayAt", System.Data.SqlDbType.SmallInt, 2, "DisplayAt"))
        Me.SqlInsertCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DisplayStopAt", System.Data.SqlDbType.SmallInt, 2, "DisplayStopAt"))
        '
        'SqlUpdateCommand4
        '
        Me.SqlUpdateCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand4.CommandText = "UPDATE Pictures SET NodeID = @NodeID, TypeID = @TypeID, Picture = @Picture, Title" & _
        " = @Title, PictureSize = @PictureSize, DisplayAt = @DisplayAt, DisplayStopAt = @" & _
        "DisplayStopAt WHERE (PictureID = @Original_PictureID) AND (DisplayAt = @Original" & _
        "_DisplayAt) AND (DisplayStopAt = @Original_DisplayStopAt) AND (NodeID = @Origina" & _
        "l_NodeID) AND (Picture = @Original_Picture) AND (PictureSize = @Original_Picture" & _
        "Size) AND (Title = @Original_Title) AND (TypeID = @Original_TypeID); SELECT Pict" & _
        "ureID, NodeID, TypeID, Picture, Title, PictureSize, DisplayAt, DisplayStopAt FRO" & _
        "M Pictures WHERE (PictureID = @PictureID)"
        Me.SqlUpdateCommand4.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarChar, 200, "Picture"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.VarChar, 100, "Title"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PictureSize", System.Data.SqlDbType.Int, 4, "PictureSize"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DisplayAt", System.Data.SqlDbType.SmallInt, 2, "DisplayAt"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DisplayStopAt", System.Data.SqlDbType.SmallInt, 2, "DisplayStopAt"))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PictureID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PictureID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DisplayAt", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DisplayAt", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DisplayStopAt", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DisplayStopAt", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Picture", System.Data.SqlDbType.VarChar, 200, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Picture", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PictureSize", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PictureSize", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PictureID", System.Data.SqlDbType.SmallInt, 2, "PictureID"))
        '
        'SqlDeleteCommand4
        '
        Me.SqlDeleteCommand4 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand4.CommandText = "DELETE FROM Pictures WHERE (PictureID = @Original_PictureID) AND (DisplayAt = @Or" & _
        "iginal_DisplayAt) AND (DisplayStopAt = @Original_DisplayStopAt) AND (NodeID = @O" & _
        "riginal_NodeID) AND (Picture = @Original_Picture) AND (PictureSize = @Original_P" & _
        "ictureSize) AND (Title = @Original_Title) AND (TypeID = @Original_TypeID)"
        Me.SqlDeleteCommand4.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PictureID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PictureID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DisplayAt", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DisplayAt", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_DisplayStopAt", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DisplayStopAt", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Picture", System.Data.SqlDbType.VarChar, 200, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Picture", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PictureSize", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PictureSize", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daPictures
        '
        Me.daPictures = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand4.ToString(), cnHowToDB)
        Me.daPictures.DeleteCommand = Me.SqlDeleteCommand4
        Me.daPictures.InsertCommand = Me.SqlInsertCommand4
        Me.daPictures.SelectCommand = Me.SqlSelectCommand4
        Me.daPictures.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Pictures", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("PictureID", "PictureID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("Picture", "Picture"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("PictureSize", "PictureSize"), New System.Data.Common.DataColumnMapping("DisplayAt", "DisplayAt"), New System.Data.Common.DataColumnMapping("DisplayStopAt", "DisplayStopAt")})})
        Me.daPictures.UpdateCommand = Me.SqlUpdateCommand4
        Me.dtPictures = New DataTable()
        Me.daPictures.Fill(Me.dtPictures)
        '
        'dsPictures
        '
        Me.dsPictures = New DataSet()
        Me.dsPictures.DataSetName = "dsPictures"
        Me.dsPictures.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dsPictures.Tables.Add(Me.dtPictures)
        '
        ' Types
        '
        'SqlSelectCommand5
        '
        Me.SqlSelectCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand5.CommandText = "SELECT TypeID, Label, Category FROM Types"
        Me.SqlSelectCommand5.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand5
        '
        Me.SqlInsertCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand5.CommandText = "INSERT INTO Types(Label, Category) VALUES (@Label, @Category); SELECT TypeID, Lab" & _
                "el, Category FROM Types WHERE (TypeID = @@IDENTITY)"
        Me.SqlInsertCommand5.Connection = Me.cnHowToDB
        Me.SqlInsertCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Label", System.Data.SqlDbType.VarChar, 15, "Label"))
        Me.SqlInsertCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Category", System.Data.SqlDbType.VarChar, 15, "Category"))
        '
        'SqlUpdateCommand5
        '
        Me.SqlUpdateCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand5.CommandText = "UPDATE Types SET Label = @Label, Category = @Category WHERE (TypeID = @Original_T" & _
                "ypeID) AND (Category = @Original_Category) AND (Label = @Original_Label); SELECT" & _
                " TypeID, Label, Category FROM Types WHERE (TypeID = @TypeID)"
        Me.SqlUpdateCommand5.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Label", System.Data.SqlDbType.VarChar, 15, "Label"))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Category", System.Data.SqlDbType.VarChar, 15, "Category"))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Category", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Category", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Label", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Label", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.SmallInt, 2, "TypeID"))
        '
        'SqlDeleteCommand5
        '
        Me.SqlDeleteCommand5 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand5.CommandText = "DELETE FROM Types WHERE (TypeID = @Original_TypeID) AND (Category = @Original_Cat" & _
        "egory) AND (Label = @Original_Label)"
        Me.SqlDeleteCommand5.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TypeID", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TypeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Category", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Category", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand5.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Label", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Label", System.Data.DataRowVersion.Original, Nothing))
        '
        'daTypes
        '
        Me.daTypes = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand5.ToString(), cnHowToDB)
        Me.daTypes = New System.Data.SqlClient.SqlDataAdapter
        Me.daTypes.DeleteCommand = Me.SqlDeleteCommand5
        Me.daTypes.InsertCommand = Me.SqlInsertCommand5
        Me.daTypes.SelectCommand = Me.SqlSelectCommand5
        Me.daTypes.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Types", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("Label", "Label"), New System.Data.Common.DataColumnMapping("Category", "Category")})})
        Me.daTypes.UpdateCommand = Me.SqlUpdateCommand5
        Me.dtTypes = New DataTable()
        Me.daTypes.Fill(Me.dtTypes)
        '
        'dsTypes
        '
        Me.dsTypes = New DataSet()
        Me.dsTypes.DataSetName = "dsTypes"
        Me.dsTypes.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dsTypes.Tables.Add(Me.dtTypes)
        '
        'dvTypes
        '
        Me.dvTypes = New System.Data.DataView
        Me.dvTypes.RowFilter = "Category = 'Pictures'"
        Me.dvTypes = New System.Data.DataView(Me.dtTypes)
        '
        ' Summaries
        '
        'SqlSelectCommand6
        '
        Me.SqlSelectCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand6.CommandText = "SELECT SummaryID, NodeID, Summary FROM Summaries"
        Me.SqlSelectCommand6.Connection = Me.cnHowToDB
        '
        'SqlInsertCommand6
        '
        Me.SqlInsertCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand6.CommandText = "INSERT INTO Summaries(NodeID, Summary) VALUES (@NodeID, @Summary); SELECT Summary" & _
                "ID, NodeID, Summary FROM Summaries WHERE (SummaryID = @@IDENTITY)"
        Me.SqlInsertCommand6.Connection = Me.cnHowToDB
        Me.SqlInsertCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlInsertCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Summary", System.Data.SqlDbType.VarChar, 2147483647, "Summary"))
        '
        'SqlUpdateCommand6
        '
        Me.SqlUpdateCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand6.CommandText = "UPDATE Summaries SET NodeID = @NodeID, Summary = @Summary WHERE (SummaryID = @Ori" & _
                "ginal_SummaryID) AND (NodeID = @Original_NodeID); SELECT SummaryID, NodeID, Summ" & _
                "ary FROM Summaries WHERE (SummaryID = @SummaryID)"
        Me.SqlUpdateCommand6.Connection = Me.cnHowToDB
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NodeID", System.Data.SqlDbType.Int, 4, "NodeID"))
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Summary", System.Data.SqlDbType.VarChar, 2147483647, "Summary"))
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SummaryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SummaryID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SummaryID", System.Data.SqlDbType.Int, 4, "SummaryID"))
        '
        'SqlDeleteCommand6
        '
        Me.SqlDeleteCommand6 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand6.CommandText = "DELETE FROM Summaries WHERE (SummaryID = @Original_SummaryID) AND (NodeID = @Orig" & _
        "inal_NodeID)"
        Me.SqlDeleteCommand6.Connection = Me.cnHowToDB
        Me.SqlDeleteCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SummaryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SummaryID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand6.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_NodeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NodeID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daSummaries
        '
        Me.daSummaries = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand6.ToString(), cnHowToDB)
        Me.daSummaries.DeleteCommand = Me.SqlDeleteCommand6
        Me.daSummaries.InsertCommand = Me.SqlInsertCommand6
        Me.daSummaries.SelectCommand = Me.SqlSelectCommand6
        Me.daSummaries.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Summaries", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("SummaryID", "SummaryID"), New System.Data.Common.DataColumnMapping("NodeID", "NodeID"), New System.Data.Common.DataColumnMapping("Summary", "Summary")})})
        Me.daSummaries.UpdateCommand = Me.SqlUpdateCommand6
        Me.dtSummaries = New DataTable()
        Me.daSummaries.Fill(Me.dtSummaries)
        '
        'dsSummaries
        '
        Me.dsSummaries = New DataSet()
        Me.dsSummaries.DataSetName = "dsSummaries"
        Me.dsSummaries.Locale = New System.Globalization.CultureInfo("en-AU")
        Me.dsSummaries.Tables.Add(Me.dtSummaries)
        '
        ' dvSummaries
        '
        'Me.dvSummaries = New System.Data.DataView(dtSummaries)
        '
        ' Categories
        '
        'SqlSelectCommand7
        '
        Me.SqlDeleteCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlInsertCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand7 = New System.Data.SqlClient.SqlCommand
        Me.SqlSelectCommand7.CommandText = "SELECT DISTINCT Options, CategoryID FROM Categories WHERE (Categories = @Category" & _
        ")"
        Me.SqlSelectCommand7.Connection = Me.cnHowToDB
        Me.SqlSelectCommand7.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Category", System.Data.SqlDbType.VarChar, 15, "Categories"))
        '
        'daCategories
        '
        Me.daCategories = New System.Data.SqlClient.SqlDataAdapter(Me.SqlSelectCommand7.ToString(), cnHowToDB)
        Me.daCategories.DeleteCommand = Me.SqlDeleteCommand7
        Me.daCategories.InsertCommand = Me.SqlInsertCommand7
        Me.daCategories.SelectCommand = Me.SqlSelectCommand7
        Me.daCategories.UpdateCommand = Me.SqlUpdateCommand7
        Me.dtCategories = New DataTable()
        'Me.daCategories.Fill(Me.dtCategories)
        '
        'dsCategories
        '
        Me.dsCategories = New DataSet()
        Me.dsCategories.DataSetName = "dsCategories"
        Me.dsCategories.Locale = New System.Globalization.CultureInfo("en-AU")
        '
        'dvCategories
        '
        Me.dvCategories = New System.Data.DataView(dtCategories)
        '
        CType(Me.dsNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvNodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvKeys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsKeysDistinct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvKeysDistinct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPictures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsSummaries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvCategories, System.ComponentModel.ISupportInitialize).BeginInit()

        CType(Me.dsNodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvNodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsKeys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvKeys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsKeysDistinct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvKeysDistinct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPictures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsSummaries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCategories, System.ComponentModel.ISupportInitialize).EndInit()
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

    Dim Notes As NoteTree

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim builder As New SqlConnectionStringBuilder
        Dim NodeType, TreeType As Integer
        Dim SelectCommandText, InfoSelectCommand As String
        Dim SummarizeSentences As Generic.List(Of SummarizeSentence)
        SummarizeSentences = New Generic.List(Of SummarizeSentence)

        builder.DataSource = "NENKESJLAPTOP" & "\SQL1"
        builder.InitialCatalog = "HowToDB"
        builder.IntegratedSecurity = True
        Using linkToDB As New SqlConnection(builder.ConnectionString)
            linkToDB.Open()
            Notes = New NoteTree( _
            daNodes, _
            daInfo, _
            daKeys, _
            daKeysDistinct, _
            daPictures, _
            daSummaries, _
            daCategories, _
            dsNodes, _
            dsInfo, _
            dsKeys, _
            dsKeysDistinct, _
            dsPictures, _
            dsSummaries, _
            dsCategories, _
            dtNodes, _
            dtTempNodes, _
            dtInfo, _
            dtKeys, _
            dtKeysDistinct, _
            dvNodes, _
            dvInfo, _
            dvKeys, _
            dvKeysDistinct, _
            gvSummarize, _
            lblNoteTools, _
            lblInfoTools, _
            lblPercentReduction, _
            lbxNodes, _
            lbxInfo, _
            lbxKeys, _
            drpKeys, _
            drpFilterOn, _
            drpSearchOn, _
            drpTxtOpr, _
            drpInfoTypes, _
            drpSummaries, _
            drpPictureType, _
            btnUp, _
            btnDown, _
            btnSummary, _
            btnRefresh, _
            btnRefreshInfo, _
            btnEdit, _
            btnEditInfo, _
            btnNew, _
            btnNewInfo, _
            btnNewChild, _
            btnInfoNode, _
            btnRestoreInfo, _
            btnSave, _
            btnSaveInfo, _
            btnAddKeyWord, _
            btnNewSummary, _
            btnSaveSummary, _
            btnPrevPicture, _
            btnNextPicture, _
            btnSavePicture, _
            btnGo, _
            btnBackOut, _
            btnSearch, _
            btnSrchBack, _
            rdoNotes, _
            rdoInfo, _
            rdoSmallSumm, _
            rdoLargeSumm, _
            rdoLargestSumm, _
            filUpload, _
            Picture, _
            txtFilterText, _
            txtSearchFilter, _
            txtKeyWord, _
            txtHeading, _
            txtNodeText, _
            txtPictureTitle, _
            txtSummText, _
            txtTxtSpecs)
            If Not (Page.IsPostBack) Then
                ' Initialize all settings
                ' Set height and width of Node Text textbox
                txtNodeText.Height = System.Web.UI.WebControls.Unit.Percentage(68)
                txtNodeText.Width = System.Web.UI.WebControls.Unit.Percentage(54.05)
                NodeType = 5
                TreeType = 2
                SelectCommandText = "SELECT * FROM Nodes WHERE TreeID = 2"
                Notes.InitialSettings(TreeType, NodeType, SelectCommandText)
                InfoSelectCommand = "SELECT * FROM Info"
                Notes.InitialInfoSettings(InfoSelectCommand)
                ' Bind Controls (Dont Clear, Fill and Bind)
                ' Clear: clears the content of the ADO Dataset - required when Select command for ADO dataset changes
                ' Fill: fills the ADO DataSet with the database tables - required after postback
                ' Bind: binds the ADO DataSets to the Controls - required when content when content of ADO dataset changes
                Notes.BindNodes(False, True, True)
                Notes.BindInfo(False, True, True)
                Notes.BindKeys(False, True, True)
                Notes.BindPictures(False, True)
                Notes.BindSummaries(False, True)
                Notes.NodeChanged()
                SetViewStates("Define")
                SetViewStates("All")
            Else
                ' Copy from viewstate variables
                SetViewStates("PostBack")
                ' Refill datasets (Dont Clear, Fill but Dont Bind)
                ' Its seems that after a postback the ADO datasets are empty and need to be refilled from the database
                Notes.BindNodes(False, True, False)
                Notes.BindInfo(False, True, False)
                Notes.BindKeys(False, True, False)
                Notes.BindPictures(False, True)
                Notes.BindSummaries(False, True)
            End If
        End Using

    End Sub

    Private Sub SetViewStates(ByVal TypeID As String)
        'This is all the info we dont want to lose after a postback
        Select Case TypeID
            Case "Define"
                ViewState.Add(ViewState.Count, "Mode")
                ViewState.Add(ViewState.Count, "CurrentTree")
                ViewState.Add(ViewState.Count, "NodeType")
                ViewState.Add(ViewState.Count, "InfoType")
                ViewState.Add(ViewState.Count, "SelectedNode")
                ViewState.Add(ViewState.Count, "SelectedInfo")
                ViewState.Add(ViewState.Count, "InfoNode")
                ViewState.Add(ViewState.Count, "ParentNode")
                ViewState.Add(ViewState.Count, "CurrentLevel")
                ViewState.Add(ViewState.Count, "Operation")
                ViewState.Add(ViewState.Count, "InfoOperation")
                ViewState.Add(ViewState.Count, "SearchDisplayed")
                ViewState.Add(ViewState.Count, "SelectCmd")
                ViewState.Add(ViewState.Count, "NodeSelectCmd")
                ViewState.Add(ViewState.Count, "InfoSelectCmd")
                ViewState.Add(ViewState.Count, "NodeFilter")
                ViewState.Add(ViewState.Count, "InfoFilter")
                ViewState.Add(ViewState.Count, "SearchFilter")
                ViewState.Add(ViewState.Count, "SelectedKey")
                ViewState.Add(ViewState.Count, "Item")
                ViewState.Add(ViewState.Count, "SavedYet")
                ViewState.Add(ViewState.Count, "InfoSavedYet")
                ViewState.Add(ViewState.Count, "HasPicture")
                ViewState.Add(ViewState.Count, "HasSummary")
                ViewState.Add(ViewState.Count, "NodeText")
                ViewState.Add(ViewState.Count, "NodeAlteredText")
                ViewState.Add(ViewState.Count, "NodeTextLength")
                ViewState.Add(ViewState.Count, "NodeAlteredTextLength")
                ViewState.Add(ViewState.Count, "NodeTextOpr")
                ViewState.Add(ViewState.Count, "InfoType")
                ViewState.Add(ViewState.Count, "NodeTextSpecs")
                ViewState.Add(ViewState.Count, "RestoreSelectedInfo")
                ViewState.Add(ViewState.Count, "RestoreSelectedNode")
                ViewState.Add(ViewState.Count, "RestoreParentNode")
                ViewState.Add(ViewState.Count, "RestoreCurrentLevel")
                ViewState.Add(ViewState.Count, "RestoreNodeFilter")
                ViewState.Add(ViewState.Count, "RestorePrevSelectedNode")
                ViewState.Add(ViewState.Count, "RestorePrevParentNode")
                ViewState.Add(ViewState.Count, "RestorePrevCurrentLevel")
                ViewState.Add(ViewState.Count, "RestorePrevNodeFilter")
            Case "All"
                ViewState("Mode") = Notes.Mode
                ViewState("CurrentTree") = Notes.CurrentTree
                ViewState("NodeType") = Notes.NodeType
                ViewState("InfoType") = Notes.InfoType
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("SelectedInfo") = Notes.SelectedInfo
                ViewState("InfoNode") = Notes.InfoNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("Operation") = Notes.Operation
                ViewState("InfoOperation") = Notes.InfoOperation
                ViewState("SearchDisplayed") = Notes.SearchDisplayed
                ViewState("SelectCmd") = Notes.DefaultSelectCmd
                ViewState("NodeSelectCmd") = Notes.NodeSelectCmd
                ViewState("InfoSelectCmd") = Notes.InfoSelectCmd
                ViewState("NodeFilter") = Notes.NodeFilter
                ViewState("InfoFilter") = Notes.InfoFilter
                ViewState("SearchFilter") = Notes.SearchFilter
                ViewState("SelectedKey") = Notes.SelectedKey
                ViewState("Item") = Notes.Item
                ViewState("SavedYet") = Notes.SavedYet
                ViewState("InfoSavedYet") = Notes.InfoSavedYet
                ViewState("HasPicture") = Notes.HasPicture
                ViewState("HasSummary") = Notes.HasSummary
                ViewState("NodeText") = Notes.NodeText
                ViewState("NodeAlteredText") = Notes.NodeAlteredText
                ViewState("NodeTextLength") = Notes.NodeTextLength
                ViewState("NodeAlteredTextLength") = Notes.NodeAlteredTextLength
                ViewState("NodeTextOpr") = Notes.NodeTextOpr
                ViewState("InfoType") = Notes.InfoType
                ViewState("NodeTextSpecs") = Notes.NodeTextSpecs
                ViewState("RestoreSelectedInfo") = Notes.RestoreSelectedInfo
                ViewState("RestoreSelectedNode") = Notes.RestoreSelectedNode
                ViewState("RestoreParentNode") = Notes.RestoreParentNode
                ViewState("RestoreCurrentLevel") = Notes.RestoreCurrentLevel
                ViewState("RestoreNodeFilter") = Notes.RestoreNodeFilter
                ViewState("RestorePrevSelectedNode") = Notes.RestorePrevSelectedNode
                ViewState("RestorePrevParentNode") = Notes.RestorePrevParentNode
                ViewState("RestorePrevCurrentLevel") = Notes.RestorePrevCurrentLevel
                ViewState("RestorePrevNodeFilter") = Notes.RestorePrevNodeFilter
            Case "PostBack"
                Notes.Mode = ViewState("Mode")
                Notes.CurrentTree = ViewState("CurrentTree")
                Notes.NodeType = ViewState("NodeType")
                Notes.InfoType = ViewState("InfoType")
                Notes.SelectedNode = ViewState("SelectedNode")
                Notes.SelectedInfo = ViewState("SelectedInfo")
                Notes.InfoNode = ViewState("InfoNode")
                Notes.ParentNode = ViewState("ParentNode")
                Notes.CurrentLevel = ViewState("CurrentLevel")
                Notes.Operation = ViewState("Operation")
                Notes.InfoOperation = ViewState("InfoOperation")
                Notes.SearchDisplayed = ViewState("SearchDisplayed")
                Notes.DefaultSelectCmd = ViewState("SelectCmd")
                Notes.NodeSelectCmd = ViewState("NodeSelectCmd")
                Notes.InfoSelectCmd = ViewState("InfoSelectCmd")
                Notes.NodeFilter = ViewState("NodeFilter")
                Notes.InfoFilter = ViewState("InfoFilter")
                Notes.SearchFilter = ViewState("SearchFilter")
                Notes.SelectedKey = ViewState("SelectedKey")
                Notes.Item = ViewState("Item")
                Notes.SavedYet = ViewState("SavedYet")
                Notes.InfoSavedYet = ViewState("InfoSavedYet")
                Notes.HasPicture = ViewState("HasPicture")
                Notes.HasSummary = ViewState("HasSummary")
                Notes.NodeText = ViewState("NodeText")
                Notes.NodeAlteredText = ViewState("NodeAlteredText")
                Notes.NodeTextLength = ViewState("NodeTextLength")
                Notes.NodeAlteredTextLength = ViewState("NodeAlteredTextLength")
                Notes.NodeTextOpr = ViewState("NodeTextOpr")
                Notes.InfoType = ViewState("InfoType")
                Notes.NodeTextSpecs = ViewState("NodeTextSpecs")
                Notes.RestoreSelectedInfo = ViewState("RestoreSelectedInfo")
                Notes.RestoreSelectedNode = ViewState("RestoreSelectedNode")
                Notes.RestoreParentNode = ViewState("RestoreParentNode")
                Notes.RestoreCurrentLevel = ViewState("RestoreCurrentLevel")
                Notes.RestoreNodeFilter = ViewState("RestoreNodeFilter")
                Notes.RestorePrevSelectedNode = ViewState("RestorePrevSelectedNode")
                Notes.RestorePrevParentNode = ViewState("RestorePrevParentNode")
                Notes.RestorePrevCurrentLevel = ViewState("RestorePrevCurrentLevel")
                Notes.RestorePrevNodeFilter = ViewState("RestorePrevNodeFilter")
            Case "Refresh"
                ViewState("NodeFilter") = Notes.NodeFilter
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("Operation") = Notes.Operation
                ViewState("Item") = Notes.Item
            Case "RefreshInfo"
                ViewState("InfoFilter") = Notes.InfoFilter
                ViewState("SelectedInfo") = Notes.SelectedInfo
                ViewState("InfoNode") = Notes.InfoNode
                ViewState("InfoOperation") = Notes.InfoOperation
            Case "Edit"
                ViewState("Operation") = Notes.Operation
                ViewState("SavedYet") = Notes.SavedYet
            Case "EditInfo"
                ViewState("InfoOperation") = Notes.InfoOperation
                ViewState("InfoSavedYet") = Notes.InfoSavedYet
            Case "New"
                ViewState("Operation") = Notes.Operation
                ViewState("SavedYet") = Notes.SavedYet
                ViewState("HasPicture") = Notes.HasPicture
                ViewState("HasSummary") = Notes.HasSummary
            Case "NewInfo"
                ViewState("InfoOperation") = Notes.InfoOperation
                ViewState("InfoSavedYet") = Notes.InfoSavedYet
            Case "Save"
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("NodeFilter") = Notes.NodeFilter
                ViewState("Operation") = Notes.Operation
                ViewState("SavedYet") = Notes.SavedYet
                ViewState("HasPicture") = Notes.HasPicture
                ViewState("HasSummary") = Notes.HasSummary
                ViewState("Item") = Notes.Item
                ViewState("NodeTextOpr") = Notes.NodeTextOpr
            Case "SaveInfo"
                ViewState("SelectedInfo") = Notes.SelectedInfo
                ViewState("InfoNode") = Notes.InfoNode
                ViewState("InfoFilter") = Notes.InfoFilter
                ViewState("InfoOperation") = Notes.InfoOperation
                ViewState("InfoSavedYet") = Notes.InfoSavedYet
                ViewState("NodeTextOpr") = Notes.NodeTextOpr
            Case "NodeChanged"
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("Operation") = Notes.Operation
                ViewState("Item") = Notes.Item
                ViewState("NodeFilter") = Notes.NodeFilter
            Case "InfoChanged"
                ViewState("SelectedInfo") = Notes.SelectedInfo
                ViewState("InfoNode") = Notes.InfoNode
                ViewState("InfoOperation") = Notes.InfoOperation
            Case "UpOrDown"
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("NodeSelectCmd") = Notes.NodeSelectCmd
                ViewState("SelectedKey") = Notes.SelectedKey
                ViewState("NodeFilter") = Notes.NodeFilter
                ViewState("SearchFilter") = Notes.SearchFilter
                ViewState("Operation") = Notes.Operation
                ViewState("SearchDisplayed") = Notes.SearchDisplayed
                ViewState("Item") = Notes.Item
            Case "SearchRefresh"
                ViewState("SearchFilter") = Notes.SearchFilter
            Case "Search"
                ViewState("NodeSelectCmd") = Notes.NodeSelectCmd
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("Operation") = Notes.Operation
                ViewState("SearchDisplayed") = Notes.SearchDisplayed
                ViewState("Item") = Notes.Item
            Case "SaveInfoLocation"
                ViewState("RestoreSelectedInfo") = Notes.SelectedInfo
            Case "RestoreInfoLocation"
                Notes.SelectedInfo = ViewState("RestoreSelectedInfo")
            Case "SaveNodeLocation"
                ViewState("RestoreSelectedNode") = Notes.SelectedNode
                ViewState("RestoreParentNode") = Notes.ParentNode
                ViewState("RestoreCurrentLevel") = Notes.CurrentLevel
                ViewState("RestoreNodeFilter") = Notes.NodeFilter
            Case "RestoreNodeLocation"
                Notes.SelectedNode = ViewState("RestoreSelectedNode")
                Notes.ParentNode = ViewState("RestoreParentNode")
                Notes.CurrentLevel = ViewState("RestoreCurrentLevel")
                Notes.NodeFilter = ViewState("RestoreNodeFilter")
            Case "SavePrevLocation"
                ViewState("RestorePrevSelectedNode") = ViewState("RestoreSelectedNode")
                ViewState("RestorePrevParentNode") = ViewState("RestoreParentNode")
                ViewState("RestorePrevCurrentLevel") = ViewState("RestoreCurrentLevel")
                ViewState("RestorePrevNodeFilter") = ViewState("RestoreNodeFilter")
            Case "RestorePrevLocation"
                Notes.SelectedNode = ViewState("RestorePrevSelectedNode")
                Notes.ParentNode = ViewState("RestorePrevParentNode")
                Notes.CurrentLevel = ViewState("RestorePrevCurrentLevel")
                Notes.NodeFilter = ViewState("RestorePrevNodeFilter")
            Case "SrchBack"
                ViewState("NodeSelectCmd") = Notes.NodeSelectCmd
                ViewState("SelectedKey") = Notes.SelectedKey
                ViewState("NodeFilter") = Notes.NodeFilter
                ViewState("SearchFilter") = Notes.SearchFilter
                ViewState("SelectedNode") = Notes.SelectedNode
                ViewState("ParentNode") = Notes.ParentNode
                ViewState("CurrentLevel") = Notes.CurrentLevel
                ViewState("Operation") = Notes.Operation
                ViewState("SearchDisplayed") = Notes.SearchDisplayed
                ViewState("Item") = Notes.Item
            Case "NodeTextOperation"
                ViewState("NodeText") = Notes.NodeText
                ViewState("NodeAlteredText") = Notes.NodeAlteredText
                ViewState("NodeTextLength") = Notes.NodeTextLength
                ViewState("NodeAlteredTextLength") = Notes.NodeAlteredTextLength
                ViewState("NodeTextSpecs") = Notes.NodeTextSpecs
            Case "SelectedKey"
                ViewState("SelectedKey") = Notes.SelectedKey
            Case "SelectedTextOpr"
                ViewState("NodeTextOpr") = Notes.NodeTextOpr
            Case "InfoType"
                ViewState("InfoType") = Notes.InfoType
            Case "Item"
                ViewState("Item") = Notes.Item
            Case "Summary"
                ViewState("HasSummary") = Notes.HasSummary
            Case "Mode"
                ViewState("Mode") = Notes.Mode
        End Select
    End Sub

    ' Navigation Drop Down List

    Private Sub drpPage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpPage.SelectedIndexChanged
        ' This calls:- Nothing
        Select Case drpPage.SelectedItem.Text
            Case "Code"
                Server.Transfer("Code.aspx")
            Case "Problems"
                Server.Transfer("Problem.aspx")
            Case "How To"
                Server.Transfer("HowTo.aspx")
            Case "Tasks"
                Server.Transfer("Tasks.aspx")
        End Select
    End Sub

    ' All the following happen at this level rather than being pushed down so that its all visible in one place
    '
    ' - All the NodeChanged calls 
    ' - All the SetViewStates
    ' - All the Binding of Controls
    ' - The setting of the Operation Mode i.e. Edit, New, NewChild or Browse
    ' - The setting of the Search Display Mode i.e. Search Results Displayed or Not Search Results Displayed
    ' - The resetting of Item i.e. going back to the 1st Picture (if any) when changeing nodes
    '
    ' Nodes to Info and visa versa
    '
    Protected Sub rdoNotes_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNotes.CheckedChanged
        SetViewStates("InfoChanged")
        SetViewStates("SaveInfoLocation")
        SetViewStates("RestoreNodeLocation")
        Notes.BindNodes(False, False, True)
        If Notes.SelectedNode > 0 Then
            lbxNodes.Items.FindByValue(Notes.SelectedNode).Selected = True
        End If
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        Notes.Mode = "Notes"
        SetViewStates("NodeChanged")
        SetViewStates("Mode")
    End Sub

    Protected Sub rdoInfo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInfo.CheckedChanged
        Notes.Mode = "Info"
        SetViewStates("Mode")
        SetViewStates("NodeChanged")
        SetViewStates("SaveNodeLocation")
        SetViewStates("RestoreInfoLocation")
        drpInfoTypes.ClearSelection()
        If Notes.SelectedInfo > 0 Then
            lbxInfo.Items.FindByValue(Notes.SelectedInfo).Selected = True
        End If
        Notes.InfoChanged()
        Notes.InfoOperation = "BrowseInfo"
        SetViewStates("InfoChanged")
    End Sub

    Protected Sub btnInfoNode_Click(sender As Object, e As ImageClickEventArgs) Handles btnInfoNode.Click
        SetViewStates("InfoChanged")
        SetViewStates("SaveInfoLocation")
        Notes.BackToInfoNode()
        Notes.BindNodes(False, False, True)
        If Notes.InfoNode > 0 Then
            lbxNodes.Items.FindByValue(Notes.InfoNode).Selected = True
        End If
        Notes.Mode = "Notes"
        SetViewStates("Mode")
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("NodeChanged")
        btnRestoreInfo.Enabled = True
        btnRestoreInfo.Visible = True
    End Sub

    Protected Sub btnRestoreInfo_Click(sender As Object, e As ImageClickEventArgs) Handles btnRestoreInfo.Click
        Notes.Mode = "Info"
        SetViewStates("Mode")
        SetViewStates("NodeChanged")
        SetViewStates("RestoreInfoLocation")
        SetViewStates("RestoreNodeLocation")
        drpInfoTypes.ClearSelection()
        If Notes.SelectedInfo > 0 Then
            lbxInfo.Items.FindByValue(Notes.SelectedInfo).Selected = True
        End If
        Notes.InfoChanged()
        Notes.InfoOperation = "BrowseInfo"
        SetViewStates("InfoChanged")
        btnRestoreInfo.Enabled = False
        btnRestoreInfo.Visible = False
    End Sub
    '
    ' Listboxes

    Private Sub lbxNodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxNodes.SelectedIndexChanged
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("NodeChanged")
    End Sub

    Protected Sub lbxInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxInfo.SelectedIndexChanged
        drpInfoTypes.ClearSelection()
        Notes.InfoChanged()
        Notes.InfoOperation = "BrowseInfo"
        SetViewStates("InfoChanged")
        If Notes.InfoType > 0 Then
            drpInfoTypes.Items.FindByValue(Notes.InfoType).Selected = True
        End If
    End Sub

    Private Sub lbxKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxKeys.SelectedIndexChanged
        Notes.SelectedKey = lbxKeys.SelectedItem.Text
        SetViewStates("SelectedKey")
    End Sub

    ' Drop Down Lists

    Private Sub drpTxtOpr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpTxtOpr.SelectedIndexChanged
        Notes.TextOpSelected()
        SetViewStates("SelectedTextOpr")
    End Sub

    Protected Sub drpInfoTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpInfoTypes.SelectedIndexChanged
        Notes.InfoType = drpInfoTypes.SelectedItem.Value
        btnSaveInfo.Enabled = True
        btnSaveInfo.ImageUrl = "images\Icons\Save.png"
        SetViewStates("InfoType")
    End Sub

    Protected Sub drpSummaries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSummaries.SelectedIndexChanged
        Notes.SummHeading()
    End Sub
    '
    ' Buttons
    '
    ' Node and Info Tool Buttons
    '
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRefresh.Click
        Notes.Refresh()
        Notes.BindNodes(False, False, True)
        Notes.NodeChanged()
        Notes.Item = 0
        SetViewStates("Refresh")
    End Sub

    Protected Sub btnRefreshInfo_Click(sender As Object, e As ImageClickEventArgs) Handles btnRefreshInfo.Click
        Notes.RefreshInfo()
        Notes.BindInfo(False, False, True)
        Notes.InfoChanged()
        Notes.InfoOperation = "BrowseInfo"
        If Notes.InfoType > 0 Then
            drpInfoTypes.Items.FindByValue(Notes.InfoType).Selected = True
        End If
        SetViewStates("RefreshInfo")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEdit.Click
        Notes.Operation = "Edit"
        Notes.EditNode()
        SetViewStates("Edit")
    End Sub

    Protected Sub btnEditInfo_Click(sender As Object, e As ImageClickEventArgs) Handles btnEditInfo.Click
        Notes.InfoOperation = "EditInfo"
        Notes.EditInfo()
        SetViewStates("EditInfo")
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNew.Click
        Notes.Operation = "New"
        Notes.NewNode()
        SetViewStates("New")
    End Sub

    Protected Sub btnNewInfo_Click(sender As Object, e As ImageClickEventArgs) Handles btnNewInfo.Click
        Notes.InfoOperation = "NewInfo"
        Notes.NewInfo()
        drpInfoTypes.ClearSelection()
        SetViewStates("NewInfo")
    End Sub

    Private Sub btnNewChild_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNewChild.Click
        Notes.Operation = "NewChild"
        Notes.NewChildNode()
        SetViewStates("New")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Notes.Save()
        Notes.BindNodes(False, False, True)
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("Save")
        ' Save happens in the Tree Class but cant be bothered passing all these down through NoteTree and Tree
        drpTxtOpr.ClearSelection()
        txtTxtSpecs.Enabled = False
        txtTxtSpecs.Text = ""
        btnGo.Enabled = False
        btnGo.ImageUrl = "images\Icons\Go_Disabled.png"
        btnBackOut.Enabled = False
        btnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
    End Sub

    Protected Sub btnSaveInfo_Click(sender As Object, e As ImageClickEventArgs) Handles btnSaveInfo.Click
        Notes.SaveInfo()
        Notes.BindInfo(False, False, True)
        Notes.InfoChanged()
        Notes.InfoOperation = "BrowseInfo"
        If Notes.InfoType > 0 Then
            drpInfoTypes.Items.FindByValue(Notes.InfoType).Selected = True
        End If
        Notes.InfoOperation = "BrowseInfo"
        SetViewStates("SaveInfo")
        ' Save happens in the Tree Class but cant be bothered passing all these down through NoteTree and Tree
        drpTxtOpr.ClearSelection()
        txtTxtSpecs.Enabled = False
        txtTxtSpecs.Text = ""
        btnGo.Enabled = False
        btnGo.ImageUrl = "images\Icons\Go_Disabled.png"
        btnBackOut.Enabled = False
        btnBackOut.ImageUrl = "images\Icons\No_Disabled.png"
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDown.Click
        Notes.Down()
        If Notes.SearchDisplayed Then
            Notes.SearchDisplayed = False
            Notes.BindNodes(True, True, True)
        Else
            Notes.SearchDisplayed = False
            Notes.BindNodes(False, False, True)
        End If
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("UpOrDown")
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUp.Click
        Notes.Up()
        If Notes.SearchDisplayed Then
            Notes.SearchDisplayed = False
            Notes.BindNodes(True, True, True)
        Else
            Notes.SearchDisplayed = False
            Notes.BindNodes(False, False, True)
        End If
        If Notes.SelectedNode > 0 Then
            lbxNodes.Items.FindByValue(Notes.SelectedNode.ToString).Selected = True
        End If
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("UpOrDown")
    End Sub

    ' Search Tool Buttons

    Private Sub btnSearchRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearchRefresh.Click
        Notes.SearchRefresh()
        Notes.BindKeys(False, False, True)
        SetViewStates("SearchRefresh")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        If btnSrchBack.Enabled = False Then
            SetViewStates("SaveNodeLocation")
        End If
        Notes.Search()
        Notes.SearchDisplayed = True
        Notes.BindNodes(True, True, True)
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("Search")
    End Sub

    Protected Sub btnSrchBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnSrchBack.Click
        SetViewStates("RestoreNodeLocation")
        Notes.SrchBack()
        Notes.SearchDisplayed = False
        Notes.BindNodes(True, True, True)
        Notes.BindKeys(False, False, True)
        If Notes.SelectedNode > 0 Then
            lbxNodes.Items.FindByValue(Notes.SelectedNode).Selected = True
        End If
        Notes.NodeChanged()
        Notes.Item = 0
        Notes.Operation = "Browse"
        SetViewStates("SrchBack")
        ' Same thing cant be bothered passing these down to Tree Class
        drpSearchOn.ClearSelection()
        txtSearchFilter.Text = ""
    End Sub

    Private Sub btnAddKeyWord_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddKeyWord.Click
        Notes.AddKeyWord()
        Notes.BindKeys(True, True, True)
        lbxKeys.Items.FindByText(txtKeyWord.Text).Selected = True
        txtKeyWord.Text = ""
    End Sub

    ' Text Operation Buttons

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGo.Click
        Dim SummarizeSentences As Generic.List(Of SummarizeSentence)
        SummarizeSentences = New Generic.List(Of SummarizeSentence)
        Notes.TextOperation()
        SetViewStates("NodeTextOperation")
    End Sub

    Private Sub btnBackOut_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBackOut.Click
        Notes.BackOut()
        SetViewStates("NodeTextOperation")
    End Sub

    ' Summary RDO's and Buttons

    Protected Sub rdoSmallSumm_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSmallSumm.CheckedChanged
        txtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(85)
    End Sub

    Protected Sub rdoLargeSumm_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLargeSumm.CheckedChanged
        txtSummText.Height = System.Web.UI.WebControls.Unit.Percentage(90)
    End Sub

    Protected Sub rdoLargestSumm_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLargestSumm.CheckedChanged
        txtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(685)
    End Sub

    Protected Sub btnNewSummary_Click(sender As Object, e As ImageClickEventArgs) Handles btnNewSummary.Click
        Notes.NewSummary()
        drpSummaries.ClearSelection()
        SetViewStates("Summary")
    End Sub

    Private Sub btnSaveSummary_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveSummary.Click
        Notes.SaveSummary()
    End Sub

    ' Picture Buttons

    Private Sub btnPrevPicture_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPrevPicture.Click
        Notes.PrevPicture()
        SetViewStates("Item")
    End Sub

    Private Sub btnNextPicture_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNextPicture.Click
        Notes.NextPicture()
        SetViewStates("Item")
    End Sub

    Private Sub btnSavePicture_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSavePicture.Click
        Notes.SavePicture()
        SetViewStates("Item")
    End Sub

End Class



