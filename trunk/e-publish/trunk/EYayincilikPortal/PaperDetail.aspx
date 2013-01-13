<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperDetail.aspx.cs" Inherits="EYayincilikPortal.PaperDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1
        {
            height: 104px;
            width: 335px;
        }
    </style>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Paper"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" EnableModelValidation="True" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" Width="668px">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="version" HeaderText="Version" 
                    SortExpression="version" />
                <asp:BoundField DataField="uploadDate" HeaderText="Upload Date" 
                    SortExpression="uploadDate" />
                <asp:BoundField DataField="approvalDate" HeaderText="Approval Date" 
                    SortExpression="approvalDate" />
                <asp:BoundField DataField="magazineName" HeaderText="Magazine" 
                    SortExpression="magazineName" />
                <asp:BoundField DataField="publisherName" HeaderText="Publisher" 
                    SortExpression="publisherName" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter DefaultValue="&quot;&quot;" Name="PublishedMagazineIDList" 
                    Type="String" />
                <asp:Parameter DefaultValue="&quot;&quot;" Name="MagazineIDList" 
                    Type="String" />
                <asp:QueryStringParameter DefaultValue="" Name="PaperIDList" 
                    QueryStringField="pid" Type="String" />
                <asp:Parameter DefaultValue="-1" Name="RefereeID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="AuthorID" Type="Int32" />
                <asp:Parameter DefaultValue="&quot;" Name="category" Type="String" />
                <asp:Parameter DefaultValue="&quot;" Name="SubCategoryIDlist" Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
        <br />
        <asp:Button ID="Button4" runat="server" Text="Download paper" Width="120px" 
            onclick="Button4_Click" />
        <br />
        <br />
        Your comment about this paper:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
&nbsp;<textarea id="TextArea1" name="S1" cols="20" rows="8"></textarea>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Add Comment" Width="96px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />        
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Survey" 
            Width="61px" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Send to publisher" Height="29px" 
            onclick="Button1_Click" Width="120px" />
    
    </div>
    </form>
</body>
</html>
