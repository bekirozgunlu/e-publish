<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editor.aspx.cs" Inherits="EYayincilikPortal.editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="btnInvite" runat="server" onclick="btnInvite_Click">HAKEM DAVET ET</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="btnPublish" runat="server" onclick="btnPublish_Click">DERGİ YAYINLA</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" Caption="ONAY BEKLEYEN MAKALELER" CellPadding="4" 
            DataSourceID="ObjectPaper" ForeColor="#333333" Width="974px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                    Visible="False" />
                <asp:BoundField DataField="AuthorName" HeaderText="Yazar" 
                    SortExpression="AuthorName" />
                <asp:BoundField DataField="MagazineName" HeaderText="Dergi " 
                    SortExpression="MagazineName" />
                <asp:BoundField DataField="title" HeaderText="Makale" SortExpression="title" />
                <asp:BoundField DataField="ApprovalStateText" HeaderText="Onay Durum" 
                    SortExpression="ApprovalStateText" />
                <asp:BoundField DataField="publishedId" HeaderText="publishedId" 
                    SortExpression="publishedId" />
                <asp:BoundField DataField="version" HeaderText="Version" 
                    SortExpression="version" />
                <asp:BoundField DataField="approvalDate" HeaderText="Onay Tarihi" 
                    SortExpression="approvalDate" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <EmptyDataTemplate>
                ONAY BEKLEYEN MAKALE YOK
            </EmptyDataTemplate>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectPaper" runat="server" 
            SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter Name="PublishedMagazineIDList" Type="String" />
                <asp:Parameter Name="MagazineIDList" Type="String" />
                <asp:Parameter Name="PaperIDList" Type="String" />
                <asp:Parameter Name="RefereeID" Type="Int32" />
                <asp:SessionParameter Name="PublisherID" SessionField="userID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="AuthorID" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="category" Type="String" />
                <asp:Parameter Name="SubCategoryIDlist" Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
