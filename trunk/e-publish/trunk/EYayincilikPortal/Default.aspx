<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EYayincilikPortal._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:LinkButton ID="btnYazar" runat="server" PostBackUrl="~/yazar.aspx" 
                Visible="False">Yazar Ana Sayfa</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="btnEditor" runat="server" PostBackUrl="~/editor.aspx" 
                Visible="False">Editör İşlemleri</asp:LinkButton>
&nbsp;&nbsp;
            <asp:LinkButton ID="btnModerator" runat="server" PostBackUrl="~/moderator.aspx" 
                Visible="False">Moderator İşlemleri</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnAdmin" runat="server" 
                PostBackUrl="~/admin.aspx" Visible="False">Admin</asp:LinkButton>
&nbsp;
            <asp:LinkButton ID="btnHakem" runat="server" PostBackUrl="~/hakem.aspx" 
                Visible="False">Hakem İşlemleri</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />

<div style="text-align: right">
            <asp:HyperLink ID="loginlink" runat="server" NavigateUrl="~/login.aspx" 
                style="text-align: right; font-weight: 700; color: #FF3300;">Login</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;
</div>

<div>
    <asp:Label ID="Label1" runat="server" 
        style="font-weight: 700; font-style: italic; text-decoration: underline"></asp:Label>
</div>

        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:Label ID="lblDergi" runat="server" Text="Dergi Seçiniz :"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                DataSourceID="objDergiler" DataTextField="name" DataValueField="id" 
                Width="300px" DataTextFormatString="{0}">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblDergi0" runat="server" Text="Baskı Seçiniz :"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                DataSourceID="objPublishedMagazine" DataTextField="MagazinePublishNo" DataValueField="id" 
                Width="200px" DataTextFormatString="{0}">
            </asp:DropDownList>
            ,</div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;
        &nbsp;
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="objPapers" 
            ForeColor="#333333" Width="943px" Caption="DERGİYE AİT MAKALELER">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="makale.aspx?id={0}" DataTextField="id" 
                    DataTextFormatString="OKU" NavigateUrl="makale.aspx?id={0}" Text="OKU" />
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                    Visible="False" />
                <asp:BoundField DataField="MagazineName" HeaderText="Dergi" 
                    SortExpression="MagazineName" />
                <asp:BoundField DataField="AuthorName" HeaderText="Yazar" 
                    SortExpression="AuthorName" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="authorId" HeaderText="authorId" 
                    SortExpression="authorId" Visible="False" />
                <asp:BoundField DataField="approvalState" HeaderText="approvalState" 
                    SortExpression="approvalState" Visible="False" />
                <asp:BoundField DataField="contentPath" HeaderText="contentPath" 
                    SortExpression="contentPath" Visible="False" />
                <asp:BoundField DataField="approvalDate" HeaderText="Date" 
                    SortExpression="approvalDate" />
                <asp:BoundField DataField="publishedId" HeaderText="publishedId" 
                    SortExpression="publishedId" />
                <asp:BoundField DataField="version" HeaderText="Version" 
                    SortExpression="version" />
                <asp:BoundField DataField="publisherComment" HeaderText="publisherComment" 
                    SortExpression="publisherComment" Visible="False" />
                <asp:BoundField DataField="MagazineID" HeaderText="MagazineID" 
                    SortExpression="MagazineID" Visible="False" />
                <asp:BoundField DataField="PublishedMagazineID" 
                    HeaderText="PublishedMagazineID" SortExpression="PublishedMagazineID" 
                    Visible="False" />
                <asp:BoundField DataField="isActive" HeaderText="isActive" 
                    SortExpression="isActive" Visible="False" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <EmptyDataTemplate>
                <div class="style1">
                    <strong>İLGİLİ DERGİ BASIMA AİT MAKALE YOK</strong></div>
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
        <asp:ObjectDataSource ID="objPapers" runat="server" SelectMethod="GetPaperList" 
            TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList2" DefaultValue="0" 
                    Name="PublishedMagazineIDList" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" 
                    Name="MagazineIDList" PropertyName="SelectedValue" Type="String" />
                <asp:Parameter Name="PaperIDList" Type="String" />
                <asp:Parameter Name="RefereeID" Type="Int32" />
                <asp:Parameter Name="PublisherID" Type="Int32" />
                <asp:Parameter Name="AuthorID" Type="Int32" />
                <asp:Parameter Name="category" Type="String" />
                <asp:Parameter DefaultValue="" Name="SubCategoryIDlist" Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br />
       
        <asp:ObjectDataSource ID="objDergiler" runat="server" 
            SelectMethod="GetMagazineList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter Name="MagazineIDList" 
                    Type="String" DefaultValue="" />
                <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
            <asp:ObjectDataSource ID="objPublishedMagazine" runat="server" 
                SelectMethod="GetPublisheMagazineList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" 
                        Name="MagazineIDList" PropertyName="SelectedValue" Type="String" />
                    <asp:Parameter DefaultValue="" Name="PublishedMagazineIDList" Type="String" />
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
       
        <br />
        <br />
        <br />
        <br />
       
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
