<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yazar.aspx.cs" Inherits="EYayincilikPortal.yazar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="MakaleEkleLink" runat="server" 
            NavigateUrl="~/makaleEkle.aspx">Yeni Makale Ekle</asp:HyperLink>
&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Default.aspx">Ana Sayfaya Dön</asp:HyperLink>
        <br />
        <br />
        <br />
         <asp:GridView ID="GridView1" runat="server" onrowcommand="GridView1_RowCommand" AutoGenerateColumns="False" 
              CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
              GridLines="None" onselectedindexchanged="GridView1_SelectedIndexChanged">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <Columns>
                   <asp:CommandField ShowSelectButton="True" SelectText="Seç" />
                   <asp:HyperLinkField DataNavigateUrlFields="id,version" 
                        DataNavigateUrlFormatString="../../upload/{0}_{1}.pdf" DataTextField="id" 
                        DataTextFormatString="Oku" HeaderText="Oku" 
                        NavigateUrl="../../upload/{0}_{1}.pdf" Target="_blank" Text="Oku" />
                   <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" 
                        SortExpression="id" />
                   <asp:BoundField DataField="AuthorName" HeaderText="Yazar" 
                        SortExpression="AuthorName" />
                   <asp:BoundField DataField="title" HeaderText="Başlık" SortExpression="title" />
                   <asp:BoundField DataField="MagazineName" HeaderText="Dergi" 
                        SortExpression="MagazineName" />
                   <asp:BoundField DataField="publisherComment" HeaderText="Editör Yorumu" 
                        SortExpression="publisherComment" />
                   <asp:BoundField DataField="PublishedMagazineID" 
                        HeaderText="ISBN" SortExpression="PublishedMagazineID" />
                   <asp:BoundField DataField="ApprovalStateText" HeaderText="Onay Durum" 
                        SortExpression="ApprovalStateText" />
                   <asp:ButtonField CommandName="Yorumlar" HeaderText="Yorumlar" 
                        ShowHeader="True" Text="Yorumları gör" />
                   <asp:ButtonField CommandName="Referanslar" 
                        HeaderText="Referanslar" ShowHeader="True" Text="Raferansları gör" />
                   <asp:ButtonField CommandName="Incele" HeaderText="İncele" ShowHeader="True" 
                        Text="İncele" />
              </Columns>
              <EditRowStyle BackColor="#999999" />
              <EmptyDataTemplate>
                   Bu yazara aitmakale bulunamadı.
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
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
              SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
              <SelectParameters>
                   <asp:Parameter Name="PublishedMagazineIDList" Type="String" />
                   <asp:Parameter Name="MagazineIDList" Type="String" />
                   <asp:Parameter Name="PaperIDList" Type="String" />
                   <asp:Parameter Name="RefereeID" Type="Int32" />
                   <asp:Parameter Name="PublisherID" Type="Int32" />
                   <asp:SessionParameter DefaultValue="" Name="AuthorID" SessionField="userid" 
                        Type="Int32" />
                   <asp:Parameter Name="category" Type="String" />
                   <asp:Parameter Name="SubCategoryIDlist" Type="String" />
                   <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
              </SelectParameters>
         </asp:ObjectDataSource>
         <br />
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
              CellPadding="4" ForeColor="#333333" 
              GridLines="None">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <Columns>
                   <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                   <asp:BoundField DataField="commentType" HeaderText="commentType" 
                        SortExpression="commentType" />
                   <asp:BoundField DataField="content" HeaderText="content" 
                        SortExpression="content" />
                   <asp:BoundField DataField="paperId" HeaderText="paperId" 
                        SortExpression="paperId" />
                   <asp:BoundField DataField="userId" HeaderText="userId" 
                        SortExpression="userId" />
                   <asp:BoundField DataField="approvalState" HeaderText="approvalState" 
                        SortExpression="approvalState" />
                   <asp:BoundField DataField="commentDate" HeaderText="commentDate" 
                        SortExpression="commentDate" />
                   <asp:BoundField DataField="ApprovalStateText" HeaderText="ApprovalStateText" 
                        SortExpression="ApprovalStateText" />
              </Columns>
              <EditRowStyle BackColor="#999999" />
              <EmptyDataTemplate>
                   Yorum bulunamadı.
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
         <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
              SelectMethod="GetCommentList" TypeName="EYayincilikPortal.Manager">
              <SelectParameters>
                   <asp:Parameter Name="PaperIDList" Type="String" />
                   <asp:Parameter DefaultValue="-1" Name="RefereeID" Type="Int32" />
                   <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
              </SelectParameters>
         </asp:ObjectDataSource>
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
              CellPadding="4" ForeColor="#333333" 
              GridLines="None">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <Columns>
                   <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" 
                        SortExpression="AuthorName" />
                   <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                   <asp:BoundField DataField="MagazineName" HeaderText="MagazineName" 
                        SortExpression="MagazineName" />
                   <asp:BoundField DataField="publisherName" HeaderText="publisherName" 
                        SortExpression="publisherName" />
              </Columns>
              <EditRowStyle BackColor="#999999" />
              <EmptyDataTemplate>
                   Referans bulunamadı.
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
         <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
              SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
              <SelectParameters>
                   <asp:Parameter Name="PublishedMagazineIDList" Type="String" />
                   <asp:Parameter Name="MagazineIDList" Type="String" />
                   <asp:Parameter DefaultValue="" Name="PaperIDList" Type="String" />
                   <asp:Parameter Name="RefereeID" Type="Int32" />
                   <asp:Parameter Name="PublisherID" Type="Int32" />
                   <asp:Parameter Name="AuthorID" Type="Int32" />
                   <asp:Parameter Name="category" Type="String" />
                   <asp:Parameter Name="SubCategoryIDlist" Type="String" />
                   <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
              </SelectParameters>
         </asp:ObjectDataSource>
&nbsp;&nbsp;&nbsp;
         <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Ana Sayfaya Dön</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
