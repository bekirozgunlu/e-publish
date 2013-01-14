<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editordetay.aspx.cs" Inherits="EYayincilikPortal.editordetay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 156px;
        }
        .style4
        {
            width: 151px;
        }
        .style5
        {
            width: 287px;
        }
        .style6
        {
            width: 287px;
            height: 37px;
        }
        .style7
        {
            width: 156px;
            height: 37px;
        }
        .style8
        {
            width: 151px;
            height: 37px;
        }
        .style9
        {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Button ID="btnDownload" runat="server" onclick="btnDownload_Click" 
            Text="Görüntüle (İndir)" Width="132px" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Caption="Makale Onay Durum" CellPadding="4" DataSourceID="objRefereePaper" 
            ForeColor="#333333" Width="820px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                    Visible="False" />
                <asp:BoundField DataField="title" HeaderText="Onay Durum" 
                    SortExpression="title" />
                <asp:BoundField DataField="AuthorName" HeaderText="Hakem" 
                    SortExpression="AuthorName" />
                <asp:BoundField DataField="approvalDate" HeaderText="Yorum Tarihi" 
                    SortExpression="approvalDate" />
                <asp:BoundField DataField="MagazineName" HeaderText="Yorum" 
                    SortExpression="MagazineName" />
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
        <asp:Button ID="btnSendToAuthor" runat="server" onclick="btnSendToAuthor_Click" 
            Text="Yazara Geri Gönder" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" 
            style="font-weight: 700; text-decoration: underline" Text="Editör Yorumu"></asp:Label>
        <br />
        <asp:TextBox ID="txtYorum" runat="server" Width="749px"></asp:TextBox>
        <br />
        <asp:Button ID="btnEditorYorum" runat="server" onclick="btnEditorYorum_Click" 
            Text="Editor Yorumu Ekle" />
        <br />
        <table class="style1">
            <tr>
                <td class="style6">
                    <asp:DropDownList ID="cmbReferee" runat="server" DataSourceID="objRefereelist" 
                        DataTextField="userName" DataValueField="userID" Height="26px" 
                        Width="263px" Font-Size="Medium">
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    <asp:Button ID="btnSendToReferee" runat="server" 
                        onclick="btnSendToReferee_Click" Text="Hakeme Gönder" />
                </td>
                <td class="style8">
                    </td>
                <td class="style9">
                    </td>
                <td class="style9">
                    </td>
                <td class="style9">
                    </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Button ID="btnOnayla" runat="server" onclick="btnOnayla_Click" 
                        Text="Makaleyi Onayla" Width="132px" />
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:ObjectDataSource ID="objRefereePaper" runat="server" 
            SelectMethod="GetRefereeNotesOnPaper" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="PaperID" QueryStringField="id" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="objRefereelist" runat="server" 
            SelectMethod="GetRefereeList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter Name="RefereeIDList" Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                <asp:Parameter DefaultValue="" Name="MagazineIDList" Type="String" />
                <asp:Parameter Name="PublishedMagazineList" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
