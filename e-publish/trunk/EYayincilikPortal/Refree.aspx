<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refree.aspx.cs" Inherits="EYayincilikPortal.Refree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Refree"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="username"></asp:Label>
&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 10px" 
            Width="113px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
&nbsp;
        &nbsp;
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 23px" 
            Width="121px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Surname    "></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 20px" 
            Width="116px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="ObjectDataSource1" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" Width="560px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    
                    DataNavigateUrlFormatString="PaperDetail.aspx?pid={0}" 
                    Text="Go" />
                <asp:BoundField DataField="title" HeaderText="Paper" SortExpression="title" />
                <asp:BoundField DataField="uploadDate" HeaderText="Upload Date" 
                    SortExpression="uploadDate" />
                <asp:BoundField DataField="magazineName" HeaderText="Magazine" 
                    SortExpression="magazineName" />
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
                <asp:Parameter DefaultValue="&quot;&quot;" Name="PublishedMagazineIDList" 
                    Type="String" />
                <asp:Parameter DefaultValue="&quot;&quot;" Name="MagazineIDList" 
                    Type="String" />
                <asp:Parameter DefaultValue="&quot;&quot;" Name="PaperIDList" Type="String" />
                <asp:QueryStringParameter DefaultValue="-1" Name="RefereeID" 
                    QueryStringField="rid" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="AuthorID" Type="Int32" />
                <asp:Parameter DefaultValue="&quot;&quot;" Name="category" Type="String" />
                <asp:Parameter DefaultValue="&quot;&quot;" Name="SubCategoryIDlist" 
                    Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    
    </div>

    <input type="hidden" name="rid" value="<%=Request.QueryString["rid"] %>" />


    </form>
</body>
</html>
