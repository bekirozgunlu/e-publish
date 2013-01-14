<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="EYayincilikPortal.Survey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 365px;
        }
        .style3
        {
            width: 100px;
        }
        .style4
        {
            width: 711px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <table style="width:100%;">
        <tr>
            <td class="style1">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
        CellPadding="4" DataSourceID="ObjectDataSource1" 
        GridLines="Horizontal" Width="354px" DataKeyNames="id">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                Visible="False" />
            <asp:TemplateField HeaderText="Answer">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="question" HeaderText="Question" 
                SortExpression="question" >
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>        
        <EmptyDataTemplate>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </EmptyDataTemplate>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetSurveyQuestionaryList" TypeName="EYayincilikPortal.Manager">
        <SelectParameters>
            <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            <asp:QueryStringParameter DefaultValue="-1" Name="MagazineID" 
                QueryStringField="mid" Type="Int32" />
            <asp:Parameter DefaultValue="-1" Name="SurveyID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="Submit" runat="server" onclick="Submit_Click" 
                    style="width: 61px" Text="Submit" />
                <br />
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
