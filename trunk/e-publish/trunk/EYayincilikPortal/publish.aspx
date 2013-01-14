<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publish.aspx.cs" Inherits="EYayincilikPortal.publish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Dergi Seçiniz :
            <asp:DropDownList ID="cmbDergi" runat="server" 
                DataSourceID="objDergiler" DataTextField="name" DataValueField="id" 
                Width="300px" DataTextFormatString="{0}">
            </asp:DropDownList>
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="SEC" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" Width="762px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="approvalDate" HeaderText="approvalDate" 
                    SortExpression="approvalDate" />
                <asp:BoundField DataField="publishedId" HeaderText="publishedId" 
                    SortExpression="publishedId" Visible="False" />
                <asp:BoundField DataField="version" HeaderText="version" 
                    SortExpression="version" />
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="publisherComment" HeaderText="Yorum" 
                    SortExpression="publisherComment" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" 
                    SortExpression="AuthorName" />
                <asp:BoundField DataField="uploadDate" HeaderText="upload Date" 
                    SortExpression="uploadDate" />
                <asp:BoundField DataField="ApprovalStateText" HeaderText="Onay Durum" 
                    SortExpression="ApprovalStateText" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
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
        <br />
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#FF0066"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Text="MAKALELERİ YAYINLA" 
            Width="238px" onclick="Button2_Click" />
        <br />
        <br />
        <br />
        <asp:ObjectDataSource ID="obj_makaleler" runat="server" 
            SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="PublishedMagazineIDList" Type="String" />
                <asp:ControlParameter ControlID="cmbDergi" DefaultValue="0" 
                    Name="MagazineIDList" PropertyName="SelectedValue" Type="String" />
                <asp:Parameter DefaultValue="" Name="PaperIDList" Type="String" />
                <asp:Parameter DefaultValue="-1" Name="RefereeID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="AuthorID" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="category" Type="String" />
                <asp:Parameter Name="SubCategoryIDlist" Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" Width="194px" />
        <br />
        <br />
        <br />
    
    </div>
       
        <asp:ObjectDataSource ID="objDergiler" runat="server" 
            SelectMethod="GetMagazineList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter Name="MagazineIDList" 
                    Type="String" DefaultValue="" />
                <asp:SessionParameter DefaultValue="" Name="PublisherID" SessionField="userID" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
    </form>
</body>
</html>
