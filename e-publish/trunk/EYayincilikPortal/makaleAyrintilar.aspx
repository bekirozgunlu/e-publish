<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="makaleAyrintilar.aspx.cs" Inherits="EYayincilikPortal.makaleAyrintilar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">

        .style1
        {
            width: 91%;
        }
        .style2
        {
            width: 103px;
        }
        .style3
        {
            width: 8px;
        }
         .style8
        {
            width: 103px;
            height: 23px;
        }
        .style9
        {
            width: 8px;
            height: 23px;
        }
        .style10
        {
            height: 23px;
        }
          .style11
          {
               width: 103px;
               height: 168px;
          }
          .style12
          {
               width: 8px;
               height: 168px;
          }
          .style13
          {
               height: 168px;
          }
         </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    Yazar</td>
                <td class="style3">
                    :</td>
                <td>
                    <asp:TextBox ID="txtYazarAdi" runat="server" Width="300px" BackColor="#CCCCCC" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Başlık</td>
                <td class="style3">
                    :</td>
                <td>
                    <asp:TextBox ID="txtBaslik" runat="server" Width="300px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Dergi</td>
                <td class="style3">
                    :</td>
                <td>
                     <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                     &nbsp;</td>
                <td class="style3">
                     &nbsp;</td>
                <td class="style4">
                     &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Alt Bilim Dalları</td>
                <td class="style3">
                    :</td>
                <td class="style7">
                    &nbsp;<asp:ListBox ID="ListBox1" 
                          runat="server" Height="129px" Width="197px" DataTextField="name" 
                          DataValueField="id">
                     </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                     Referenslar</td>
                <td class="style12">
                     :</td>
                <td class="style13">
                    
                     <asp:ListBox ID="ListBox2" runat="server" DataTextField="title" 
                          DataValueField="id" Height="153px" Width="198px"></asp:ListBox>
                    
                </td>
            </tr>
            <tr>
                <td class="style2">
                     Makale Dosyası</td>
                <td class="style3">
                    :</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td class="style8">
                    </td>
                <td class="style9">
                    :</td>
                <td class="style10">
                    <asp:Label ID="Label1" runat="server" 
                        style="font-weight: 700; font-style: italic; color: #FF0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    :</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    :</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    :</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Dergi Editörüne Gönder" Width="184px" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    :</td>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                &nbsp;<br />
                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/yazar.aspx">Yazar Ana Sayfa</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
       
    </form>
</body>
</html>
