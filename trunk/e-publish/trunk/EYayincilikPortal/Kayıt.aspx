<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kayıt.aspx.cs" Inherits="EYayincilikPortal.Kayıt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #00FFFF;
            
        }
        .style2
        {
        }
        .style3
        {
            width: 81px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style1" colspan="2">
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                   <asp:Label  runat="server" 
                        Font-Bold="True" Font-Size="XX-Large" ID="lbltitle">KULLANICI KAYIT</asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                </tr>

            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="lblBilgi" runat="server" BackColor="Red" BorderColor="Red" 
                        Font-Bold="False" Font-Size="Larger"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Kullanıcı Adı:</td>
                <td>
                    <asp:TextBox ID="txtKullanıcıAdı" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtKullanıcıAdı" 
                        ErrorMessage="Lütfen Kullanıcı Adı Giriniz.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Adı:</td>
                <td>
                    <asp:TextBox ID="TxtAdı" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtAdı" ErrorMessage="Lütfen Adınızı Giriniz.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Soyadı:</td>
                <td>
                    <asp:TextBox ID="TxtSoyadı" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TxtSoyadı" ErrorMessage="Lütfen Soyadınızı Giriniz.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Type:</td>
                <td>
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True" Width="150px">
        <asp:ListItem Selected="True" Value="1">Okuyucu</asp:ListItem>
        <asp:ListItem Value="2">Yazar</asp:ListItem>
        <asp:ListItem Value="3">Moderator</asp:ListItem>
    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Şifre:</td>
                <td>
                    <asp:TextBox ID="TxtSifre" runat="server" ontextchanged="TxtSifre_TextChanged" 
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtSifre" ErrorMessage="Lütfen Şifrenizi Giriniz." 
                        TabIndex="6">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Şifre(Tekrar):</td>
                <td>
                    <asp:TextBox ID="TxtSifre2" runat="server" 
                        ontextchanged="TxtSifre2_TextChanged" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TxtSifre" ControlToValidate="TxtSifre2" 
                        ErrorMessage="Şifreler Uyuşmuyor.">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Fotograf:</td>
                <td>
                    <asp:TextBox ID="TxtFoto" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFto" runat="server" Text="Upload" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LblCV" runat="server" Text="CV:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtCV" runat="server" Visible="False"></asp:TextBox>
                    <asp:Button ID="BtnCv" runat="server" Text="Upload" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnKaydet" runat="server" onclick="BtnKaydet_Click" 
                        Text="Kaydet" />
                    <asp:Button ID="Btntemizle" runat="server" Text="Temizle" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
