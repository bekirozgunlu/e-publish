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
