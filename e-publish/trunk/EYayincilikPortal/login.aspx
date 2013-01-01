<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EYayincilikPortal.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 50%;
            background-color: #FFFF99;
        }
        .style2
        {
            width: 97px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <table align="center" cellpadding="2" class="style1">
            <tr>
                <td class="style2">
                    User name</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Password</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="189px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Login" 
                        Width="114px" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
