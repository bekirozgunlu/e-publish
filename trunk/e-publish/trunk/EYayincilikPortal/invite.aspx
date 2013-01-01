<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invite.aspx.cs" Inherits="EYayincilikPortal.invite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 41%;
        }
        .style2
        {
        }
        .style3
        {
            width: 7px;
        }
        .style4
        {
            color: #000099;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Hakem Adı
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="176px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Hakem Soyadı
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtSur" runat="server" Width="176px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Kullanıcı Adıı</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" Width="176px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Şifre</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="176px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    E-mail</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" Width="176px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Hakem Davet ET" Width="117px" />
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="3">
                    <strong>Hakem başarı ile davet edilirse ana sayfaya yönlendirileceksiniz.</strong></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
