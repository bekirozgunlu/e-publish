<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="EYayincilikPortal.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="height: 2825px; margin-bottom: 208px">
    <form id="form1" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Ana Sayfaya Dön</asp:HyperLink>
    </p>
    <div style="height: 2770px">
    
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
            <asp:ListItem Value="bilimDaliDuzenle">Bilim Dalı Düzenle</asp:ListItem>
            <asp:ListItem Value="bilimDaliSil">Bilim Dalı Sil</asp:ListItem>
            <asp:ListItem Value="altKategoriEkle">Alt Kategori Ekle</asp:ListItem>
            <asp:ListItem Value="altKategoriDuzenle">Alt Kategori Düzenle</asp:ListItem>
            <asp:ListItem Value="altKategoriSil">Alt Kategori Sil</asp:ListItem>
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="secButton" runat="server" onclick="secButton_Click" Text="Seç" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="MesajLabel" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Panel ID="DergiEklePanel" runat="server" Height="224px" Visible="False" 
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
            <br />
            Bağlı olan alt kategorileri seçin:<asp:CheckBoxList 
                ID="DergiEkleAltKategoriCheckBoxList" runat="server" 
                DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id">
            </asp:CheckBoxList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetSubCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="" Name="scienceCAtegorylist" Type="String" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel 
            ID="AltKategoriEklePanel" runat="server" Height="211px" Visible="False" 
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
        <asp:Panel ID="EditorSilPanel" runat="server" Height="270px" Width="412px" 
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
        <asp:Panel ID="ModeratorSilPanel" runat="server" Height="194px" Visible="False" 
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
        <asp:Panel ID="DergiSilPanel" runat="server" Height="280px" Visible="False" 
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
        <asp:Panel ID="BilimDaliSilPanel" runat="server" Height="259px" Visible="False" 
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
        <asp:Panel ID="AltKategoriSilPanel" runat="server" Height="253px" 
            Visible="False" Width="410px">
            Silinecek Alt Kategoriyi Seçin:<br />
            <asp:RadioButtonList ID="AltkategoriSilRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource6" DataTextField="name" DataValueField="id">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
                SelectMethod="GetSubCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="" Name="scienceCAtegorylist" Type="String" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="BilimDaliEklePanel" runat="server" Height="28px" Visible="False" 
            Width="411px">
            <asp:Label ID="BilimDaliLabel" runat="server" Text="Bilim Dalı Adı: "></asp:Label>
            <asp:TextBox ID="BilimDaliTextBox" runat="server" Height="25px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="BilimDaliDüzenlePanel" runat="server" Height="348px" 
            Visible="False" Width="410px">
            <asp:Label ID="BilimDaliDuzenleBilimDaliLabel" runat="server" 
                Text="Düzenlemek istediğiniz bilim dalını seçin:"></asp:Label>
            <br />
            <asp:RadioButtonList ID="BilimDaliDuzenleRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource8" DataTextField="name" DataValueField="id">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" 
                SelectMethod="ScienceCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="-1" Name="SubCAtegoryID" Type="Int32" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:Label ID="BilimDaliDuzenleBilimDaliAdiLabel" runat="server" 
                Text="Bilim Dalı adı:" Visible="False"></asp:Label>
            <asp:TextBox ID="BilimDaliDuzenleBilimDaliAdiTextBox" runat="server" 
                Visible="False"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="AltKategoriDuzenlePanel" runat="server" Height="337px" 
            Visible="False" Width="410px">
            Düzenlemek istediğiniz alt kategoriyi seçin:<br />
            <asp:RadioButtonList ID="AltKategoriDuzenleRadioButtonList" runat="server" 
                DataSourceID="ObjectDataSource9" DataTextField="name" DataValueField="id">
            </asp:RadioButtonList>
            <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" 
                SelectMethod="GetSubCategoryList" TypeName="EYayincilikPortal.Manager">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="onlyActiveRecords" Type="Boolean" />
                    <asp:Parameter DefaultValue="" Name="scienceCAtegorylist" Type="String" />
                    <asp:Parameter DefaultValue="-1" Name="MagazineID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:Label ID="AltKateGoriDuzenleAltKategoriAdiLabel" runat="server" 
                Text="Alt Kategori Adı:" Visible="False"></asp:Label>
            <asp:TextBox ID="AltKategoriDuzenleAltKategoriAdiTextbox" runat="server" 
                Visible="False"></asp:TextBox>
        </asp:Panel>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DuzenleButton" runat="server" onclick="DuzenleButton_Click" 
            Text="Düzenle" Visible="False" />
        <asp:Button 
            ID="SilButton" runat="server" onclick="SilButton_Click" Text="Sil" 
            Visible="False" Width="57px" />
        <asp:Button ID="EkleButton" runat="server" onclick="EkleButton_Click" 
            Text="Ekle" Width="69px" Visible="False" />
    
        <asp:Button ID="KaydetButton" runat="server" onclick="KaydetButton_Click" 
            Text="Kaydet" Visible="False" Width="56px" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="IptalButton" runat="server" onclick="IptalButton_Click" 
            Text="İptal" Width="73px" Visible="False" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
    </div>
    </form>
</body>
</html>
