<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Problem.aspx.vb" Inherits="HowTo._Problem" validateRequest=false%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>Problems</title>
        <link rel="stylesheet" type="text/css" href="CSS/default.css"/>
</head>
<body>
    <div id='tree'></div>
    <div id='header'></div>
    <form id="form1" runat="server">
    <asp:textbox style="Z-INDEX: 101; POSITION: absolute; TOP: 201px; LEFT: 8px" id="txtSolution" runat="server" ReadOnly="True" ForeColor="White" Width="256px" Height="64px" TextMode="MultiLine" BackColor="#8EA5B6"></asp:textbox>
    <asp:dropdownlist style="Z-INDEX: 154; POSITION: absolute; TOP: 136px; LEFT: 568px" id="drpKeys" runat="server"	ForeColor="White" Width="125px" BackColor="#C97C7E"></asp:dropdownlist>
    <asp:label style="Z-INDEX: 118; POSITION: absolute; TOP: 477px; LEFT: 8px" id="lblDetails" runat="server" ForeColor="White" Font-Bold="True" BorderColor="Transparent" Font-Names="Garamond" Font-Size="Medium">Details</asp:label>
    <asp:label style="Z-INDEX: 116; POSITION: absolute; TOP: 280px; LEFT: 8px" id="lblSolution" runat="server" ForeColor="White" BackColor="Transparent" Font-Bold="True" Font-Names="Garamond" Font-Size="Medium">Solution</asp:label>
    <asp:textbox style="Z-INDEX: 102; POSITION: absolute; TOP: 201px; LEFT: 288px" id="txtComments"	runat="server" ReadOnly="True" ForeColor="White" Width="546px" Height="64px" TextMode="MultiLine" BackColor="#8EA5B6"></asp:textbox>
    <asp:textbox style="Z-INDEX: 103; POSITION: absolute; TOP: 313px; LEFT: 8px" id="txtDetails" runat="server" ReadOnly="True" ForeColor="White" Width="256px" Height="150px" TextMode="MultiLine" BackColor="#8EA5B6"></asp:textbox>
    <asp:textbox style="Z-INDEX: 104; POSITION: absolute; TOP: 313px; LEFT: 285px" id="txtObservations"	runat="server" ReadOnly="True" ForeColor="White" Width="548px" Height="150px" TextMode="MultiLine" BackColor="#8EA5B6" Wrap="False"></asp:textbox>
    <asp:label style="Z-INDEX: 105; POSITION: absolute; TOP: 117px; LEFT: 8px" id="lblHeading" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Georgia" Font-Size="X-Large">Problem</asp:label>
    <asp:label style="Z-INDEX: 106; POSITION: absolute; TOP: 168px; LEFT: 8px" id="lblTitle" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Medium">Title:</asp:label>
    <asp:label style="Z-INDEX: 107; POSITION: absolute; TOP: 168px; LEFT: 288px" id="lblOccurred" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Small">When:</asp:label>
    <asp:label style="Z-INDEX: 108; POSITION: absolute; TOP: 168px; LEFT: 426px" id="lblWhere" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Small">Where:</asp:label>
    <asp:label style="Z-INDEX: 109; POSITION: absolute; TOP: 168px; LEFT: 696px" id="lblImpacts" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Small" Enabled="False">Impacts:</asp:label>
    <asp:imagebutton style="Z-INDEX: 110; POSITION: absolute; TOP: 115px; LEFT: 424px" id="btnEdit" runat="server" ImageUrl="~\images\icons\edit.png" ToolTip="Edit"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 111; POSITION: absolute; TOP: 115px; LEFT: 687px" id="btnSearch" runat="server" ImageUrl="~\images\icons\Search.png" ToolTip="Search For Key"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 111; POSITION: absolute; TOP: 115px; LEFT: 707px" id="btnSrchBack" runat="server" ImageUrl="~\images\icons\Back_Disabled.png" ToolTip="Restore from Search" Enabled="False"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 112; POSITION: absolute; TOP: 136px; LEFT: 496px" id="btnSave" runat="server" ImageUrl="images/icons/Save_Disabled.png" ToolTip="Save"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 113; POSITION: absolute; TOP: 115px; LEFT: 728px" id="btnAddKeyWord" runat="server" ImageUrl="~\images\icons\Keyword.png" ToolTip="Add New Key"></asp:imagebutton>
    <asp:label style="Z-INDEX: 114; POSITION: absolute; TOP: 115px; LEFT: 288px" id="lblTreeTools" runat="server" ForeColor="White" BackColor="Transparent" Font-Bold="True" Font-Names="Garamond" Font-Size="Small">Problem Tools</asp:label>
    <asp:label style="Z-INDEX: 115; POSITION: absolute; TOP: 115px; LEFT: 568px" id="lblSearchTools" runat="server" ForeColor="White" Width="104px" BackColor="Transparent" Font-Bold="True" Font-Names="Garamond" Font-Size="Small">Search Tools</asp:label>
    <asp:label style="Z-INDEX: 117; POSITION: absolute; TOP: 280px; LEFT: 288px" id="lblComments" runat="server" ForeColor="White" Font-Bold="True" BorderColor="Transparent" Font-Names="Garamond" Font-Size="Medium">Comments</asp:label>
    <asp:label style="Z-INDEX: 119; POSITION: absolute; TOP: 477px; LEFT: 288px" id="lblObservations" runat="server" ForeColor="White" BackColor="Transparent" Font-Bold="True" Font-Names="Garamond" Font-Size="Medium">Observations</asp:label>
    <asp:dropdownlist style="Z-INDEX: 120; POSITION: absolute; TOP: 48px; LEFT: 288px" id="drpFilterOn"	runat="server" ForeColor="White" Width="72px" BackColor="#5280A0">
				<asp:ListItem Value="Clear">Clear</asp:ListItem>
				<asp:ListItem Value="6">Client</asp:ListItem>
				<asp:ListItem Value="4">Where</asp:ListItem>
				<asp:ListItem Value="5">Impacts</asp:ListItem>
				<asp:ListItem Value="3">When &gt;=</asp:ListItem>
				<asp:ListItem Value="When &lt;">When &lt;</asp:ListItem>
				<asp:ListItem Value="2">Title</asp:ListItem>
				<asp:ListItem Value="0">Type</asp:ListItem>
				<asp:ListItem Value="1">No.</asp:ListItem>
	</asp:dropdownlist>
    <asp:textbox style="Z-INDEX: 121; POSITION: absolute; TOP: 72px; LEFT: 288px" id="txtFilterText"	runat="server" ForeColor="White" Width="72px" Height="20px" BackColor="#5280A0"></asp:textbox>
    <asp:dropdownlist style="Z-INDEX: 122; POSITION: absolute; TOP: 136px; LEFT: 288px" id="drpPage" runat="server"	ForeColor="White" Width="72px" BackColor="#C97C7E" AutoPostBack="True">
				<asp:ListItem Value="0">Stay Here</asp:ListItem>
				<asp:ListItem Value="1">Code</asp:ListItem>
				<asp:ListItem Value="2">Notes</asp:ListItem>
				<asp:ListItem Value="3">How To</asp:ListItem>
				<asp:ListItem Value="4">Tasks</asp:ListItem>
				<asp:ListItem Value="5">Messages</asp:ListItem>
	</asp:dropdownlist>
    <asp:label style="Z-INDEX: 123; POSITION: absolute; TOP: 5px; LEFT: 288px" id="lblNodes" runat="server"	ForeColor="White" Font-Bold="True" Font-Names="Baskerville" Font-Size="Medium">Problems</asp:label>
    <asp:label style="Z-INDEX: 124; POSITION: absolute; TOP: 5px; LEFT: 568px" id="lblSearch" runat="server" ForeColor="White" BackColor="Transparent" Font-Bold="True" Font-Names="Baskerville" Font-Size="Medium">Search</asp:label>
    <asp:dropdownlist style="Z-INDEX: 125; POSITION: absolute; TOP: 48px; LEFT: 568px" id="drpSearchOn"	runat="server" ForeColor="White" Width="72px" BackColor="#5280A0">
				<asp:ListItem Value="Clear">Clear</asp:ListItem>
				<asp:ListItem Value="Key">Key</asp:ListItem>
	</asp:dropdownlist>
    <asp:textbox style="Z-INDEX: 126; POSITION: absolute; TOP: 72px; LEFT: 568px" id="txtSearchFilter" runat="server" ForeColor="White" Width="72px" Height="20px" BackColor="#5280A0"></asp:textbox>
    <asp:listbox style="Z-INDEX: 127; POSITION: absolute; TOP: 5px; LEFT: 648px" id=lbxKeys runat="server" ForeColor="White" Width="176px" Height="88px" BackColor="#5280A0" AutoPostBack="True" DataSource="<%# dvKeys %>" DataTextField="KeyText"></asp:listbox>
    <asp:textbox style="Z-INDEX: 128; POSITION: absolute; TOP: 168px; LEFT: 56px" id="txtTitle" runat="server" ForeColor="White" Width="209px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:textbox style="Z-INDEX: 129; POSITION: absolute; TOP: 168px; LEFT: 336px" id="txtWhen" runat="server" ForeColor="White" Width="70px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:textbox style="Z-INDEX: 130; POSITION: absolute; TOP: 168px; LEFT: 478px" id="txtWhere" runat="server" ForeColor="White" Width="70px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:textbox style="Z-INDEX: 131; POSITION: absolute; TOP: 168px; LEFT: 760px" id="txtImpacts" runat="server" ForeColor="White" Width="70px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:label style="Z-INDEX: 132; POSITION: absolute; TOP: 117px; LEFT: 136px" id="lblType" runat="server" ForeColor="White" BackColor="Transparent" Font-Bold="True" Font-Names="Garamond">Type</asp:label>
    <asp:label style="Z-INDEX: 133; POSITION: absolute; TOP: 136px; LEFT: 136px" id="lblRecdNo"	runat="server" ForeColor="White" BackColor="Transparent" Font-Bold="True" Font-Names="Garamond">No.</asp:label>
    <asp:textbox style="Z-INDEX: 134; POSITION: absolute; TOP: 114px; LEFT: 176px" id="txtType" runat="server" ForeColor="White" Width="88px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:textbox style="Z-INDEX: 135; POSITION: absolute; TOP: 136px; LEFT: 176px" id="txtNo" runat="server" ForeColor="White" Width="88px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:imagebutton style="Z-INDEX: 136; POSITION: absolute; TOP: 115px; LEFT: 400px" id="btnRefresh" runat="server" ImageUrl="~\images\icons\Refresh.png" ToolTip="Refresh"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 137; POSITION: absolute; TOP: 136px; LEFT: 400px" id="btnNewChild" runat="server" ImageUrl="~\images\icons\NewChild.png" ToolTip="New Problem" Enabled="False" Visible="False"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 137; POSITION: absolute; TOP: 136px; LEFT: 424px" id="btnNew" runat="server" ImageUrl="~\images\icons\New.png" ToolTip="New Problem"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 138; POSITION: absolute; TOP: 480px; LEFT: 398px" id="btnNewObservation" runat="server" ImageUrl="~\images\icons\New.png" ToolTip="New Observation/Comment"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 139; POSITION: absolute; TOP: 480px; LEFT: 446px" id="btnSaveObservation" runat="server" ImageUrl="images/icons/Save_Disabled.png" ToolTip="Save Observation &amp; Comment"></asp:imagebutton>
    <asp:label style="Z-INDEX: 140; POSITION: absolute; TOP: 28px; LEFT: 288px" id="lblFilterOn" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Small">Filter</asp:label>
    <asp:listbox style="Z-INDEX: 141; POSITION: absolute; TOP: 4px; LEFT: 368px" id="lbxNodes" runat="server" ForeColor="White" Width="176px" Height="88px" BackColor="#5280A0" AutoPostBack="True" DataSource="<%# dvNodes%>" DataTextField="Heading" DataValueField="NodeID"></asp:listbox>
    <asp:imagebutton style="Z-INDEX: 142; POSITION: absolute; TOP: 480px; LEFT: 494px" id="btnNextObservation" runat="server" ImageUrl="~\images\icons\Forward.png" ToolTip="Next Observation"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 143; POSITION: absolute; TOP: 480px; LEFT: 470px" id="btnPrevObservation" runat="server" ImageUrl="~\images\icons\Back.png" ToolTip="Prev Observation"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 144; POSITION: absolute; TOP: 480px; LEFT: 422px" id="btnEditObservation" runat="server" ImageUrl="~\images\icons\edit.png" ToolTip="Edit Observation"></asp:imagebutton>
    <asp:label style="Z-INDEX: 145; POSITION: absolute; TOP: 168px; LEFT: 568px" id="lblClient"	runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Small">Client</asp:label>
    <asp:textbox style="Z-INDEX: 146; POSITION: absolute; TOP: 168px; LEFT: 612px" id="txtClient" runat="server" ForeColor="White" Width="70px" Height="20px" BackColor="Transparent"></asp:textbox>
    <asp:textbox style="Z-INDEX: 147; POSITION: absolute; TOP: 115px; LEFT: 748px" id="txtKeyWord" runat="server" ForeColor="White" Width="84px" Height="20px" BackColor="#C97C7E" ToolTip="Add Key Text"></asp:textbox>
    <asp:label style="Z-INDEX: 148; POSITION: absolute; TOP: 28px; LEFT: 568px" id="lblSearchOn" runat="server" ForeColor="White" BackColor="Transparent" Font-Names="Garamond" Font-Size="Small">Filter</asp:label>
    <asp:imagebutton style="Z-INDEX: 149; POSITION: absolute; TOP: 115px; LEFT: 667px" id="btnSearchRefresh" runat="server" ImageUrl="~\images\icons\Refresh.png" ToolTip="Refresh"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 150; POSITION: absolute; TOP: 115px; LEFT: 448px" id="btnCopy" runat="server" BackColor="Transparent" ImageUrl="~\images\icons\Copy.png" ToolTip="Copy"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 151; POSITION: absolute; TOP: 136px; LEFT: 448px" id="btnInsert" runat="server" BackColor="Transparent" ImageUrl="~\images\icons\Insert.png" ToolTip="Insert"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 152; POSITION: absolute; TOP: 115px; LEFT: 496px" id="btnDown" runat="server" BackColor="Transparent" ImageUrl="~\images\icons\Down.png" ToolTip="Children"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 153; POSITION: absolute; TOP: 115px; LEFT: 520px" id="btnUp" runat="server" BackColor="Transparent" ImageUrl="~\images\icons\Up.png" ToolTip="Parent"></asp:imagebutton>
    <asp:ImageButton Style="position: absolute; top: 135px; left: 530px" ID="btnSummary" runat="server" ToolTip="Chapter Summary" ImageUrl="~\images\icons\Summary.png" CssClass="ImgBtn" Enabled="False" Visible="False"></asp:ImageButton>

    <asp:dropdownlist style="Z-INDEX: 155; POSITION: absolute; TOP: 476px; LEFT: 518px; right: 871px;" id="drpTxtType"
				runat="server" ForeColor="White" Width="82px" BackColor="#C97C7E" AutoPostBack="True">
				<asp:ListItem Value="0">Text Type</asp:ListItem>
				<asp:ListItem Value="1">Lines</asp:ListItem>
				<asp:ListItem Value="2">SYSLOG</asp:ListItem>
				<asp:ListItem Value="3">JESMSGLG</asp:ListItem>
				<asp:ListItem Value="4">DISACTREG</asp:ListItem>
    </asp:dropdownlist>
    <asp:dropdownlist style="Z-INDEX: 156; POSITION: absolute; TOP: 476px; LEFT: 606px" id="drpTxtOpr" runat="server" ForeColor="White" Width="82px" BackColor="#C97C7E" AutoPostBack="True" Enabled="False" DataSource="<%# dvCategories %>" DataMember="Table" DataTextField="Options" DataValueField="CategoryID">
    </asp:dropdownlist><asp:textbox style="Z-INDEX: 157; POSITION: absolute; TOP: 476px; LEFT: 694px" id="txtTxtSpecs" runat="server" ForeColor="White" Width="100px" BackColor="#C97C7E" Enabled="False">Opr'n Spec's</asp:textbox>
    <asp:imagebutton style="Z-INDEX: 158; POSITION: absolute; TOP: 480px; LEFT: 798px" id="btnGo" runat="server" ImageUrl="~\images\icons\Go_Disabled.png" ToolTip="Perform Text Operation"></asp:imagebutton>
    <asp:imagebutton style="Z-INDEX: 159; POSITION: absolute; TOP: 480px; LEFT: 820px" id="btnBackOut" runat="server" ImageUrl="~\~\images\icons\No_Disabled.png" ToolTip="Backout Text Operation"></asp:imagebutton>
    </form>
</body>
</html>


