<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="EYayincilikPortal.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 1921px; margin-bottom: 208px">
    <form id="form1" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Ana Sayfaya Dön</asp:HyperLink>
    </p>
    <div style="height: 1865px">
    
    &nbsp;<br />
        <asp:Label ID="Label1" runat="server" Text="Yapılacak işi seçin: "></asp:Label>
&nbsp;<asp:DropDownList ID="isListesi" runat="server">
            <asp:ListItem Value="editorEkle">Editör Ekle</asp:ListItem>
            <asp:ListItem Value="editorSil">Editör sil</asp:ListItem>
            <asp:ListItem Value="modEkle">Moderatör Ekle</asp:ListItem>
            <asp:ListItem Value="modSil">Moderatör sil</asp:ListItem>
            <asp:ListItem Value="dergiEkle">Dergi Ekle</asp:ListItem>
            <asp:ListItem Value="dergiSil">Dergi Sil</asp:ListItem>
            <asp:ListItem Value="bilimDaliEkle">Bilim Dalı Ekle</asp:ListItem>
            <asp:ListItem Value="bilimDaliSil">Bilim Dalı Sil</asp:ListItem>
            <asp:ListItem Value="altKategoriEkle">Alt Kategori Ekle</asp:ListItem>
            <asp:ListItem Value="altKategoriSil">Alt Kategori Sil</asp:ListItem>
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="secButton" runat="server" onclick="secButton_Click" Text="Seç" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="MesajLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Panel ID="DergiEklePanel" runat="server" Height="134px" Visible="False" 
            Width="352px">
            <asp:Label ID="DergiAdiLabel" runat="server" Text="Dergi adı:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="DergiAdiTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="MaxMakaleLabel" runat="server" Text="Maksimum makale sayısı:  "></asp:Label>
&nbsp;<asp:TextBox ID="MaxMakaleTextBox" runat="server" 
                ontextchanged="MaxMakaleTextBox_TextChanged"></asp:TextBox>
            <br />
            <asp:Label ID="EditorIdLabel" runat="server" Text="Editör ID: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EditorIdTextBox" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel 
            ID="AltKategoriEklePanel" runat="server" Height="112px" Visible="False" 
            Width="414px">
            <asp:Label ID="AltKategoriAdiLabel" runat="server" Text="Alt kategori adı:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="AltKategoriAdiTextBox" runat="server"></asp:TextBox>
            <br />
            Bağlı olan bilim dallarını seçin:
            <asp:CheckBoxList ID="BilimDaliCheckBoxList" runat="server" 
                DataSourceID="ObjectDataSource2" DataTextField="name" DataValueField="id">
            </asp:CheckBoxList>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                SelectMethod="ScienceCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="-1" Name="SubCAtegoryID" Type="Int32" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="EditorEklePanel" runat="server" Height="105px" Visible="False" 
            Width="412px">
            Adı:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EditorEkleAdiTextBox" runat="server"></asp:TextBox>
            <br />
            Soyadı:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EditorEkleSoyadiTextBox" runat="server"></asp:TextBox>
            <br />
            Kullanıcı adı:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EditorEkleKullaniciAdiTextBox" runat="server"></asp:TextBox>
            <br />
            Şifresi:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EditorEkleSifreTextBox" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="ModeratorEklePanel" runat="server" Height="105px" Width="416px" 
            Visible="False">
            Adı:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ModeratorEkleAdiTextBox" runat="server"></asp:TextBox>
            <br />
            Soyadı:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ModeratorEkleSoyadiTextBox" runat="server"></asp:TextBox>
            <br />
            Kullanıcı adı:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ModeratorEkleKullaniciAdiTextBox" runat="server"></asp:TextBox>
            <br />
            Şifresi:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ModeratorEkleSifreTextBox" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="EditorSilPanel" runat="server" Height="180px" Width="412px" 
            Visible="False">
            Silinecek Editörü Seçin:<br />
            <asp:RadioButtonList ID="EditorSilRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource7" DataTextField="name" DataValueField="userID"/>
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" 
                SelectMethod="GetPublisherList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="PublisherIDList" Type="String" />
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="ModeratorSilPanel" runat="server" Height="152px" Visible="False" 
            Width="411px">
            Silinecek Moderatörü Seçin:<br />
            <asp:RadioButtonList ID="ModeratorSilRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource3" DataTextField="userName" 
                DataValueField="userID">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                SelectMethod="GetModeratorList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="ModeratorIDList" 
                        Type="String" />
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="DergiSilPanel" runat="server" Height="172px" Visible="False" 
            Width="411px">
            Silinecek Dergiyi Seçin:<br />
            <asp:RadioButtonList ID="DergiSilRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource4" DataTextField="name" DataValueField="id">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                SelectMethod="GetMagazineList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="MagazineIDList" 
                        Type="String" />
                    <asp:Parameter DefaultValue="-1" Name="PublisherID" Type="Int32" />
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="BilimDaliSilPanel" runat="server" Height="137px" Visible="False" 
            Width="410px">
            Silinecek Bilim Dalını Seçin:<br />
            <asp:RadioButtonList ID="BilimDaliSilRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource5" DataTextField="name" DataValueField="id">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
                SelectMethod="ScienceCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="-1" Name="SubCAtegoryID" Type="Int32" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="AltKategoriSilPanel" runat="server" Height="134px" 
            Visible="False" Width="410px">
            Silinecek Alt Kategoriyi Seçin:<br />
            <asp:RadioButtonList ID="AltkategoriSilRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource6" DataTextField="name" DataValueField="id">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
                SelectMethod="GetSubCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="-1" Name="scienceCAtegorylist" Type="String" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="BilimDaliEklePanel" runat="server" Height="23px" Visible="False" 
            Width="407px">
            <asp:Label ID="BilimDaliLabel" runat="server" Text="Bilim Dalı Adı: "></asp:Label>
            <asp:TextBox ID="BilimDaliTextBox" runat="server" Height="16px"></asp:TextBox>
        </asp:Panel>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
            ID="SilButton" runat="server" onclick="SilButton_Click" Text="Sil" 
            Visible="False" Width="57px" />
        <asp:Button ID="EkleButton" runat="server" onclick="EkleButton_Click" 
            Text="Ekle" Width="69px" Visible="False" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="IptalButton" runat="server" onclick="IptalButton_Click" 
            Text="İptal" Width="73px" Visible="False" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
    </div>
    </form>
</body>
</html>
