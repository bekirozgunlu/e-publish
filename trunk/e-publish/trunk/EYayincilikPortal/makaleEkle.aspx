<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="makaleEkle.aspx.cs" Inherits="EYayincilikPortal.detay" %>

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
        .style4
        {}
        .style7
        {
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
              height: 176px;
         }
         .style12
         {
              width: 8px;
              height: 176px;
         }
         .style13
         {
              height: 176px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                    <asp:TextBox ID="txtBaslik" runat="server" Width="300px"></asp:TextBox>
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
            <asp:DropDownList ID="cmbDergi" runat="server" AutoPostBack="True" 
                DataSourceID="objDergiler" DataTextField="name" DataValueField="id" 
                Width="300px" DataTextFormatString="{0}" 
                        onselectedindexchanged="cmbDergi_SelectedIndexChanged">
            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Ana Bilim Dalı:</td>
                <td class="style3">
                    :</td>
                <td class="style4">
                    &nbsp;
            <asp:DropDownList ID="cmbAnaKat" runat="server" AutoPostBack="True" 
                        DataTextField="name" DataValueField="id" 
                Width="300px" DataTextFormatString="{0}" 
                        onselectedindexchanged="cmbAnaKat_SelectedIndexChanged" 
                          DataSourceID="objAnaBilimDali">
            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Alt Bilim Dalı</td>
                <td class="style3">
                    :</td>
                <td class="style7">
                    <asp:ListBox ID="ListAltKategory" runat="server" DataTextField="name" 
                        DataValueField="id" Rows="8" SelectionMode="Multiple" Width="200px">
                    </asp:ListBox>
                    <asp:Button ID="btnAnaKategoriEkle1" runat="server" 
                        onclick="btnAnaKategoriEkle1_Click" Text="Ekle &gt;" />
                    <asp:Button ID="btnAnaKategoriSil" runat="server" 
                        onclick="btnAnaKategoriSil_Click" Text="&lt; Çıkar" />
                    <asp:ListBox ID="ListSecimAltKategory" runat="server" Rows="8" 
                        SelectionMode="Multiple" Width="215px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Referanslar</td>
                <td class="style12">
                    :</td>
                <td class="style13">
                    
                     <asp:ListBox ID="ListMakaleler" runat="server" DataSourceID="ObjectDataSource1" 
                          DataTextField="title" DataValueField="id" Rows="8" SelectionMode="Multiple" Width="200px">
                     </asp:ListBox>
                     <asp:Button ID="btnReferansEkle" runat="server" 
                          onclick="btnReferansEkle_Click1" Text="Ekle &gt;" />
                     <asp:Button ID="btnReferansSil" runat="server" onclick="btnReferansSil_Click1" 
                          Text="&lt; Çıkar" />
                     <asp:ListBox ID="ListSecimMakaleler" runat="server" Rows="8" 
                        SelectionMode="Multiple" Width="215px"></asp:ListBox>
                     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                          SelectMethod="GetPaperList" TypeName="EYayincilikPortal.Manager">
                          <SelectParameters>
                               <asp:QueryStringParameter DefaultValue="" Name="PublishedMagazineIDList" 
                                    QueryStringField="&gt;0" Type="String" />
                               <asp:Parameter Name="MagazineIDList" Type="String" />
                               <asp:Parameter Name="PaperIDList" Type="String" />
                               <asp:Parameter Name="RefereeID" Type="Int32" />
                               <asp:Parameter Name="PublisherID" Type="Int32" />
                               <asp:Parameter Name="AuthorID" Type="Int32" />
                               <asp:Parameter Name="category" Type="String" />
                               <asp:Parameter Name="SubCategoryIDlist" Type="String" />
                               <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                          </SelectParameters>
                     </asp:ObjectDataSource>
                    
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
       
        <asp:ObjectDataSource ID="objDergiler" runat="server" 
            SelectMethod="GetMagazineList" TypeName="EYayincilikPortal.Manager">
            <SelectParameters>
                <asp:Parameter Name="MagazineIDList" 
                    Type="String" DefaultValue="" />
                <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
    <asp:ObjectDataSource ID="objAnaBilimDali" runat="server" 
        SelectMethod="ScienceCategoryList" TypeName="EYayincilikPortal.Manager">
        <SelectParameters>
            <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            <asp:Parameter DefaultValue="-1" Name="SubCAtegoryID" Type="Int32" />
            <asp:ControlParameter ControlID="cmbDergi" DefaultValue="-1" Name="MagazineID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="objAltBilimDali" runat="server" 
        SelectMethod="GetSubCategoryList" TypeName="EYayincilikPortal.Manager">
        <SelectParameters>
            <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
            <asp:Parameter DefaultValue="-1" Name="scienceCAtegorylist" Type="String" />
            <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
       
    </form>
</body>
</html>
