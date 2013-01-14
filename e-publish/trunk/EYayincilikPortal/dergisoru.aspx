<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dergisoru.aspx.cs" Inherits="EYayincilikPortal.dergisoru" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/editor.aspx">Editör Ana Sayfaya Dön</asp:HyperLink>
        <br />
        <br />
        Dergi :
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="objDergi" DataTextField="name" DataValueField="id" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="500px">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="id" DataSourceID="objSorular" ForeColor="#333333" 
            onrowcommand="GridView1_RowCommand" onrowcreated="GridView1_RowCreated" 
            Width="611px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="sil" Text="Sil">
                <HeaderStyle Width="50px" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                    Visible="False" />
                <asp:BoundField DataField="question" HeaderText="Soru" 
                    SortExpression="question" />
                <asp:BoundField DataField="isActive" HeaderText="isActive" 
                    SortExpression="isActive" Visible="False" />
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
        <asp:ObjectDataSource ID="objSorular" runat="server" 
            SelectMethod="GetSurveyQuestionaryList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" 
                    Name="MagazineID" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="SurveyID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Soru"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="109px" TextMode="MultiLine" 
            Width="618px"></asp:TextBox>
        <br />
        <asp:Button ID="btnEkle" runat="server" onclick="btnEkle_Click" 
            Text="Yeni Soru Ekle" />
        <br />
        <asp:ObjectDataSource ID="objDergi" runat="server" 
            SelectMethod="GetMagazineList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter Name="MagazineIDList" Type="String" />
                <asp:SessionParameter Name="PublisherID" SessionField="userid" Type="Int32" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
