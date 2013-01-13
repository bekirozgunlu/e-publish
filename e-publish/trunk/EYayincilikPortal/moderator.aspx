<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moderator.aspx.cs" Inherits="EYayincilikPortal.moderator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
&nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
        DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        onrowcommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="Onay" DataTextField="id" 
                DataTextFormatString="Onayla" Text="Button" />
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
            <asp:BoundField DataField="MakaleAdi" HeaderText="MakaleAdi" 
                SortExpression="MakaleAdi" />
            <asp:BoundField DataField="YorumuYazan" HeaderText="YorumuYazan" 
                SortExpression="YorumuYazan" />
            <asp:BoundField DataField="content" HeaderText="Yorum" SortExpression="content">
            <HeaderStyle Width="500px" />
            <ItemStyle Width="500px" />
            </asp:BoundField>
            <asp:BoundField DataField="commentDate" HeaderText="commentDate" 
                SortExpression="commentDate" />
            <asp:BoundField DataField="ApprovalStateText" HeaderText="ApprovalStateText" 
                SortExpression="ApprovalStateText" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetCommentList" TypeName="EYayincilikPortal.Manager">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="PaperIDList" Type="String" />
            <asp:Parameter DefaultValue="-1" Name="RefereeID" Type="Int32" />
            <asp:Parameter DefaultValue="false" Name="onlyActiveRecords" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Ana Sayfaya Dön</asp:HyperLink>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="userID" 
        DataSourceID="objUser" ForeColor="#333333" GridLines="None" 
        onrowcommand="GridView2_RowCommand" PageSize="20" Width="733px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="onay" Text="Onay" />
            <asp:ButtonField CommandName="red" Text="İptal" />
            <asp:BoundField DataField="userID" HeaderText="userID" SortExpression="userID" 
                Visible="False" />
            <asp:BoundField DataField="userName" HeaderText="userName" 
                SortExpression="userName" />
            <asp:BoundField DataField="passWord" HeaderText="passWord" 
                SortExpression="passWord" Visible="False" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="surName" HeaderText="surName" 
                SortExpression="surName" />
            <asp:BoundField DataField="isActive" HeaderText="isActive" 
                SortExpression="isActive" Visible="False" />
            <asp:BoundField DataField="photoFilePath" HeaderText="photoFilePath" 
                SortExpression="photoFilePath" Visible="False" />
            <asp:BoundField DataField="isActiveText" HeaderText="Aktif Mi" 
                SortExpression="isActiveText" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <asp:ObjectDataSource ID="objUser" runat="server" SelectMethod="GetUserList" 
        TypeName="EYayincilikPortal.Manager">
        <SelectParameters>
            <asp:Parameter Name="UserIDlist" Type="String" />
            <asp:Parameter DefaultValue="false" Name="onlyActiveRecords" Type="Boolean" />
            <asp:Parameter Name="minActivationDate" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    </form>
</body>
</html>
