<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moderator.aspx.cs" Inherits="EYayincilikPortal.moderator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Yorumları listele" />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
=======
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Ana Sayfaya Dön</asp:HyperLink>
>>>>>>> .r33
    </form>
</body>
</html>
