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
            CellPadding="4" DataSourceID="ObjectDataSource1" 
            ForeColor="#333333" GridLines="None" Width="790px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="uploadDate" HeaderText="Upload Date" 
                    SortExpression="uploadDate" />
                <asp:BoundField DataField="approvalDate" HeaderText="Approval Date" 
                    SortExpression="approvalDate" />
                <asp:BoundField DataField="version" HeaderText="Version" 
                    SortExpression="version" />
                <asp:BoundField DataField="MagazineName" HeaderText="Magazine" 
                    SortExpression="MagazineName" />
                <asp:BoundField DataField="AuthorName" HeaderText="Author" 
                    SortExpression="AuthorName" />
                <asp:BoundField DataField="publisherName" HeaderText="Publisher" 
                    SortExpression="publisherName" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="PublishedMagazineIDList" 
                    Type="String" />
                <asp:Parameter DefaultValue="" Name="MagazineIDList" 
                    Type="String" />
                <asp:QueryStringParameter DefaultValue="-1" Name="PaperIDList" 
                    QueryStringField="pid" Type="String" />
                <asp:Parameter DefaultValue="-1" Name="RefereeID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="AuthorID" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="category" Type="String" />
                <asp:Parameter DefaultValue="" Name="SubCategoryIDlist" 
                    Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
        <br />
        <asp:Button ID="Download" runat="server" Text="Download paper" Width="120px" 
            onclick="Download_Click" />
        <br />
        <br />
        Your comment about this paper:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
&nbsp;<textarea id="TextArea1" name="S1" cols="20" rows="8"></textarea>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Add_Comment" runat="server" onclick="Add_Comment_Click" 
            Text="Add Comment" Width="96px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />        
        <asp:Button ID="Survey" runat="server" onclick="Survey_Click" Text="Survey" 
            Width="61px" />
        <br />
        <br />
        <asp:Button ID="Send_Publisher" runat="server" Text="Send to publisher" Height="29px" 
            onclick="Send_Publisher_Click" Width="120px" />
    
    </div>
    </form>
</body>
</html>
