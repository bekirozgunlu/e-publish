<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EYayincilikPortal._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="UserGetir" style="height: 26px" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Sayfa2 ye Git" />
        <br />
        <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
&nbsp;
        <asp:Label ID="Label2" runat="server" Text="User SurName"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
            EnableModelValidation="True" Width="353px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="publisherId" HeaderText="publisherId" 
                    SortExpression="publisherId" />
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="detay.aspx?makaleID={0}" 
                    NavigateUrl="detay.aspx?makaleID={0}" Text="Detay" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetMagazineList" TypeName="EYayincilikPortal.Manager" 
            DataObjectTypeName="EYayincilikPortal.SVC1.Magazine" InsertMethod="AddMagazine">
            <SelectParameters>
                <asp:Parameter DefaultValue="&quot;&quot;" Name="MagazineIDList" 
                    Type="String" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
        <br />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
        <br />
        <br />
        <br />
       
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
