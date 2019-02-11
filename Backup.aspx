<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Backup.aspx.vb" validateRequest="false" Inherits="HowTo.Backup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Note</title>
    <link rel="stylesheet" type="text/css" href="CSS/default.css"/>
    <script src="jquery-2.0.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#content").hover(handleMouseEnter, handleMouseLeave);
            function handleMouseEnter(e) {
                $(this).css("border", "thick solid red");
            };
            function handleMouseLeave(e) {
                $(this).css("border", "");
            }
        });
    </script> 
</head>
<body>
    <form id="Notes" runat="server">
    <div id="header">
        <!-- Note/Info Selection -->   
            <asp:RadioButton Style="z-index: 138; position: absolute; top: 8px; left: 288px; " ID="rdoNotes" runat ="server" ForeColor="White" Font-Size="Medium" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" Text="Notes" GroupName="NotesInfo" Enabled="True" Checked="True"></asp:RadioButton>
            <asp:RadioButton Style="z-index: 138; position: absolute; top: 27px; left: 288px; " ID="rdoInfo" runat ="server" ForeColor="White" Font-Size="Medium" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" Text="Info" GroupName="NotesInfo" Enabled="True"></asp:RadioButton>
             <asp:DropDownList Style="z-index: 103; position: absolute; top: 48px; left: 288px; right: 1173px;" ID="drpFilterOn" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px">
                 <asp:ListItem Value="Clear">Clear</asp:ListItem>
                 <asp:ListItem Value="Heading">Heading</asp:ListItem>
             </asp:DropDownList>
             <asp:TextBox Style="z-index: 104; position: absolute; top: 72px; left: 288px; right: 1165px;" ID="txtFilterText" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px" Height="20px" BorderColor="White"></asp:TextBox>

        <!-- Key Search -->           
             <asp:Label Style="z-index: 110; position: absolute; top: 8px; left: 568px; height: 23px;" ID="lblSearch" runat="server" ForeColor="White" Font-Size="Medium" Font-Names="Baskerville" Font-Bold="True" BackColor="Transparent">Search</asp:Label>
             <asp:Label Style="z-index: 114; position: absolute; top: 32px; left: 568px" ID="lblSearchOn" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" BackColor="Transparent">Filter</asp:Label>
             <asp:DropDownList Style="z-index: 115; position: absolute; top: 48px; left: 568px" ID="drpSearchOn" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px">
                 <asp:ListItem Value="Clear">Clear</asp:ListItem>
                 <asp:ListItem Value="Key">Key</asp:ListItem>
                 <asp:ListItem Value="Key Like">Key Like</asp:ListItem>
             </asp:DropDownList>
             <asp:TextBox Style="z-index: 117; position: absolute; top: 72px; left: 568px" ID="txtSearchFilter" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px" Height="20px"></asp:TextBox>

        <!-- Note/Info Tools -->
             <asp:Label Style="z-index: 119; position: absolute; top: 115px; left: 288px" ID="lblNoteTools" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent">Note Tools</asp:Label>
             <asp:Label Style="z-index: 119; position: absolute; top: 115px; left: 288px" ID="lblInfoTools" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent" Enabled="False" Visible="False">Info Tools</asp:Label>
             <asp:ImageButton Style="z-index: 111; position: absolute; top: 115px; left: 370px; width: 16px;" ID="btnRefresh" runat="server" ToolTip="Refresh" ImageUrl="~\images\icons\Refresh.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 111; position: absolute; top: 115px; left: 370px; width: 16px;" ID="btnRefreshInfo" runat="server" ToolTip="Refresh" ImageUrl="~\images\icons\Refresh.png" Enabled="False" Visible="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 106; position: absolute; top: 115px; left: 390px; right: 1153px;" ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~\images\icons\edit.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 106; position: absolute; top: 115px; left: 390px; right: 1153px;" ID="btnEditInfo" runat="server" ToolTip="Edit" ImageUrl="~\images\icons\edit.png" Enabled="False" Visible="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 121; position: absolute; top: 115px; left: 410px; height: 16px;" ID="btnNew" runat="server" ToolTip="New" ImageUrl="~\images\icons\New.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 121; position: absolute; top: 115px; left: 410px; height: 16px;" ID="btnNewInfo" runat="server" ToolTip="New" ImageUrl="~\images\icons\New.png" Enabled="False" Visible="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 124; position: absolute; top: 115px; left: 430px;" ID="btnNewChild" runat="server" ToolTip="New Child" ImageUrl="~\images\icons\NewChild.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 124; position: absolute; top: 115px; left: 430px;" ID="btnInfoNode" runat="server" ToolTip="Source Note" ImageUrl="~\images\icons\Back.png" Enabled="False" Visible="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 124; position: absolute; top: 140px; left: 530px;" ID="btnRestoreInfo" runat="server" ToolTip="Back To Notes" ImageUrl="~\images\icons\Back.png" Enabled="False" Visible="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 145; position: absolute; top: 115px; left: 450px" ID="btnGo" runat="server" ToolTip="Perform Text Operation" ImageUrl="~\images\icons\Go_Disabled.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 146; position: absolute; top: 115px; left: 470px" ID="btnBackOut" runat="server" ToolTip="Backout Text Operation" ImageUrl="~\images\icons\No_Disabled.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 112; position: absolute; top: 115px; left: 490px" ID="btnSave" runat="server" ToolTip="Save" ImageUrl="~\images/icons/Save_Disabled.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 112; position: absolute; top: 115px; left: 490px" ID="btnSaveInfo" runat="server" ToolTip="Save" ImageUrl="~\images/icons/Save_Disabled.png" Enabled="False" Visible="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 125; position: absolute; top: 115px; left: 510px; height: 16px;" ID="btnDown" runat="server" ToolTip="Children" ImageUrl="~\images\icons\Down.png" CssClass="ImgBtn"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 126; position: absolute; top: 115px; left: 530px" ID="btnUp" runat="server" ToolTip="Parent" ImageUrl="~\images\icons\Up.png"></asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 135px; left: 530px" ID="btnSummary" runat="server" ToolTip="Chapter Summary" ImageUrl="~\images\icons\Summary.png" CssClass="ImgBtn" Enabled="False" Visible="False"></asp:ImageButton>


             <asp:DropDownList Style="z-index: 120; position: absolute; top: 136px; left: 748px;" ID="drpPage" runat="server" ForeColor="White" BackColor="#C97C7E" Width="85px" AutoPostBack="True">
                 <asp:ListItem Value="0">Stay Here</asp:ListItem>
                 <asp:ListItem Value="1">Code</asp:ListItem>
                 <asp:ListItem Value="2">Problems</asp:ListItem>
                 <asp:ListItem Value="3">How To</asp:ListItem>
                 <asp:ListItem Value="4">Tasks</asp:ListItem>
                 <asp:ListItem Value="5">Messages</asp:ListItem>
             </asp:DropDownList>  

             <asp:DropDownList Style="z-index: 143; position: absolute; top: 136px; left: 288px;" ID="drpTxtOpr" runat="server" ForeColor="White" BackColor="#C97C7E" Width="72px" AutoPostBack="True">
                 <asp:ListItem Value="Words">Words</asp:ListItem>
                 <asp:ListItem Value="Sentences">Sentences</asp:ListItem>
                 <asp:ListItem Value="Format Text">Format Text</asp:ListItem>
                 <asp:ListItem Value="Debugging Text">Debugging Text</asp:ListItem>
                 <asp:ListItem Value="Sort">Sort</asp:ListItem>
                 <asp:ListItem Value="Remove Column">Remove Column</asp:ListItem>
             </asp:DropDownList>  
                   
             <asp:TextBox Style="z-index: 144; position: absolute; top: 136px; left: 366px;" ID="txtTxtSpecs" runat="server" ForeColor="White" BackColor="#C97C7E" Width="105px" Enabled="False"></asp:TextBox>

             <asp:DropDownList Style="z-index: 132; position: absolute; top: 136px; left: 480px;" ID="drpInfoTypes" runat="server" ForeColor="White" BackColor="#C97C7E" Width="70px" DataSourceID="srcInfoTypes" DataTextField="Label" DataValueField="TypeID" Enabled="False" Visible="False" AutoPostBack="True"></asp:DropDownList>

        <!-- Search Tools -->
             <asp:Label Style="z-index: 109; position: absolute; top: 115px; left: 568px" ID="lblSearchTools" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent" Width="104px">Search Tools</asp:Label>
             <asp:ImageButton Style="z-index: 116; position: absolute; top: 115px; left: 665px; width: 16px;" ID="btnSearchRefresh" runat="server" ToolTip="Refresh" ImageUrl="~\images\icons\Refresh.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 107; position: absolute; top: 115px; left: 686px" ID="btnSearch" runat="server" ToolTip="Search For Key" ImageUrl="~\images\icons\Search.png"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 107; position: absolute; top: 115px; left: 706px; height: 16px;" ID="btnSrchBack" runat="server" ToolTip="Restore after Search" ImageUrl="~\images\icons\Back_Disabled.png" Enabled="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 108; position: absolute; top: 115px; left: 728px" ID="btnAddKeyWord" runat="server" ToolTip="Add New Key" ImageUrl="~\images\icons\Keyword.png" Enabled="False"></asp:ImageButton>
             <asp:TextBox Style="z-index: 113; position: absolute; top: 113px; left: 748px" ID="txtKeyWord" runat="server" ForeColor="White" BackColor="Transparent" Width="80px" Height="18px" ToolTip="Add Key Text" Enabled="False"></asp:TextBox>
 
        <!-- Summary Tools -->   
             <asp:Label Style="z-index: 141; position: absolute; top: 170px; left: 5px" ID="lblSummary" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True">Summary: Size</asp:Label>
             <asp:RadioButton Style="z-index: 138; position: absolute; top: 170px; left: 88px; height: 20px;" ID="rdoSmallSumm" runat ="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" GroupName="Summary" Enabled="False"></asp:RadioButton>
             <asp:RadioButton Style="z-index: 139; position: absolute; top: 170px; left: 108px" ID="rdoLargeSumm" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" GroupName="Summary" Enabled="False"></asp:RadioButton>
             <asp:RadioButton Style="z-index: 139; position: absolute; top: 170px; left: 128px" ID="rdoLargestSumm" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" GroupName="Summary" Enabled="False"></asp:RadioButton>
             <asp:ImageButton Style="z-index: 121; position: absolute; top: 170px; left: 150px; height: 16px;" ID="btnNewSummary" runat="server" ToolTip="New" ImageUrl="~\images\icons\New.png"></asp:ImageButton>
             <asp:DropDownList Style="z-index: 122; position: absolute; top: 170px; left: 168px;" ID="drpSummaries" runat="server" AutoPostBack="True" ForeColor="White" BackColor="#C97C7E" Enabled="False" Height="18px" Width="90px">
                <asp:ListItem Value="Summary">Summary</asp:ListItem>
                <asp:ListItem Value="Comment">Comment</asp:ListItem>
                <asp:ListItem Value="Additional Info">Additional Info</asp:ListItem>
                <asp:ListItem Value="Text Refers To">Text Refers To</asp:ListItem>
                <asp:ListItem Value="Refresher On">Refresher On</asp:ListItem>
            </asp:DropDownList>
             <asp:ImageButton Style="z-index: 140; position: absolute; top: 170px; left: 260px; height: 16px;" ID="btnSaveSummary" runat="server" ToolTip="Save Summary" ImageUrl="images/icons/Save_Disabled.png"></asp:ImageButton>

        <!-- Picture Tools -->
             <asp:Label Style="z-index: 137; position: absolute; top: 170px; left: 280px" ID="lblPictures" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent" Text="Pictures: "></asp:Label>
             <asp:ImageButton Style="z-index: 135; position: absolute; top: 170px; left: 340px" ID="btnPrevPicture" runat="server" ToolTip="Previous Picture" ImageUrl="~\images\Icons\Back_Disabled.png" Enabled="False"></asp:ImageButton>
             <asp:ImageButton Style="z-index: 136; position: absolute; top: 170px; left: 363px" ID="btnNextPicture" runat="server" ToolTip="Next Picture" ImageUrl="~\images\Icons\Forward_Disabled.png" Enabled="False"></asp:ImageButton>
             <asp:Label Style="z-index: 137; position: absolute; top: 170px; left: 390px" ID="lblAddPicture" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent">Add Picture</asp:Label>
             <asp:TextBox Style="z-index: 133; position: absolute; top: 169px; left: 602px; width: 136px; height: 17px; right: 790px;" ID="txtPictureTitle" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Georgia" BackColor="#C97C7E" Enabled="False"></asp:TextBox>
             <asp:ImageButton Style="z-index: 134; position: absolute; top: 170px; left: 820px; " ID="btnSavePicture" runat="server" ToolTip="Save New Picture" ImageUrl="~\images/icons/Save_Disabled.png" Enabled="False"></asp:ImageButton>

        <!-- File Upload for Picture Tools -->
             <asp:FileUpload Style="z-index: 130; position: absolute; width: 130px; height: 20px; top: 169px; left: 463px; " ID="filUpload" runat="server" Enabled="False" />

        <!-- Drop Down List for Keys Search -->
             <asp:DropDownList Style="z-index: 129; position: absolute; top: 139px; left: 568px" ID="drpKeys" runat="server" ForeColor="White" BackColor="#C97C7E" Width="90px" AutoPostBack="True" ></asp:DropDownList>

        <!-- Picture Upload Type -->
             <asp:DropDownList Style="z-index: 132; position: absolute; top: 168px; left: 745px;" ID="drpPictureType" runat="server" ForeColor="White" BackColor="#C97C7E" Width="70px" DataSourceID="srcPictureTypes" DataTextField="Label" DataValueField="TypeID" Enabled="False"></asp:DropDownList>

        <!-- Search Keys -->
             <asp:ListBox Style="z-index: 118; position: absolute; top: 8px; left: 648px" ID="lbxKeys" runat="server" ForeColor="White" BackColor="#5280A0" Width="176px" Height="90px" AutoPostBack="True" DataTextField="KeyText" DataSource="<%# dvKeysDistinct%>"></asp:ListBox>

        <!-- Notes -->
             <asp:ListBox Style="z-index: 105; position: absolute; top: 8px; left: 367px; " ID="lbxNodes" runat="server" ForeColor="White" BackColor="#5280A0" Width="176px" Height="90px" AutoPostBack="True" DataTextField="Heading" DataSource="<%# dvNodes%>" DataValueField="NodeID"></asp:ListBox>

        <!-- Info -->
             <asp:ListBox Style="z-index: 105; position: absolute; top: 8px; left: 367px; " ID="lbxInfo" runat="server" ForeColor="White" BackColor="#5280A0" Width="176px" Height="90px" AutoPostBack="True" DataTextField="Heading" DataSource="<%# dvInfo%>" DataValueField="InfoID" Enabled="False" Visible="False"></asp:ListBox>

        <!-- Note Heading -->
             <asp:TextBox Style="z-index: 123; position: absolute; top: 115px; left: 8px" ID="txtHeading" runat="server" ForeColor="White" Font-Size="Large" Font-Names="Georgia" BackColor="#6B9396" Width="256px" TextMode="MultiLine" Height="46px" BorderColor="White"></asp:TextBox>

        <!-- Note Summary Text -->
             <asp:TextBox Style="z-index: 142; position: absolute; top: 8px; left: 860px;" ID="txtSummText" runat="server" ForeColor="White" BackColor="#8EA5B6" Width="465px" Height="85" TextMode="MultiLine" Visible="False" Font-Names="Verdana" Font-Size="Small"></asp:TextBox>
        </div>
        <div id="content">
            <!-- Note Text 
             Style="z-index: 122; position: absolute; top: 198px; left: 3px;" 
             Style="z-index: 120; position: absolute; top: 198px; right: 3px;"    
                -->
            <asp:TextBox ID="txtNodeText" Style="z-index: 122; position: absolute; top: 198px; left: 3px;" runat="server" ForeColor="White" BackColor="#8EA5B6" TextMode="MultiLine" ReadOnly="True" Font-Names="Verdana" Font-Size="Medium" CssClass="NodeText"></asp:TextBox>
                        <!-- Summarize -->
            <!-- Summarize -->
            <asp:Label ID="lblPercentReduction" runat="server" Text="" ForeColor="White" BackColor="#8EA5B6" Font-Names="Verdana" Font-Size="Medium" ></asp:Label>
            <asp:GridView Style="border: 3px solid #ccc; border-bottom-color: #eee;  border-left-color: #ddd; border-top-color: #bbb; height:95%; width: 54.7%; vertical-align: top; " ID="gvSummarize" runat="server" ForeColor="White" BackColor="#8EA5B6" Font-Names="Verdana" Font-Size="Medium" >
            </asp:GridView>
                        <asp:FormView ID="fvSummarize" runat="server">
                <ItemTemplate>
                    <asp:CheckBox ID="Include" runat="server" />
                    <asp:Label ID="Paragraph" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="SentenceNo" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="Sentence" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:FormView>
                        <asp:DetailsView ID="dvSummarize" runat="server" Height="50px" Width="125px">
            </asp:DetailsView>
            <asp:DataList Style="border: 3px solid #ccc; border-bottom-color: #eee;  border-left-color: #ddd; border-top-color: #bbb; height:95%; width: 54.7%; vertical-align: top; " ID="dlSummarize" runat="server" ForeColor="White" BackColor="#8EA5B6" Font-Names="Verdana" Font-Size="Medium">
            </asp:DataList>
            <!-- Note Picture -->
            <asp:Image ID="Picture" Style="z-index: 120; position: absolute; top: 198px; right: 3px;" runat="server" CssClass="NodePicture"></asp:Image>
        </div>
        <div id="tree"></div>
    </form>
    <asp:SqlDataSource ID="srcPictureTypes" runat="server" ConnectionString="<%$ ConnectionStrings:cnHowToDB %>" SelectCommand="SELECT * FROM [Types] WHERE Category = 'Pictures'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="srcInfoTypes" runat="server" ConnectionString="<%$ ConnectionStrings:cnHowToDB %>" SelectCommand="SELECT * FROM [Types] WHERE Category = 'Info'"></asp:SqlDataSource>

</body>
</html>


