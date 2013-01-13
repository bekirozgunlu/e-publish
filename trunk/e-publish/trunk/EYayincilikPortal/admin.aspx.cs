using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Gorunmez_Yap()
        {
            DergiEklePanel.Visible = false;
            AltKategoriEklePanel.Visible = false;
            EditorEklePanel.Visible = false;
            ModeratorEklePanel.Visible = false;
            EditorSilPanel.Visible = false;
            ModeratorSilPanel.Visible = false;
            DergiSilPanel.Visible = false;
            BilimDaliSilPanel.Visible = false;
            AltKategoriSilPanel.Visible = false;
            BilimDaliEklePanel.Visible = false;
            EkleButton.Visible = false;
            IptalButton.Visible = false;
            SilButton.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void secButton_Click(object sender, EventArgs e)
        {
            Gorunmez_Yap();
            if(isListesi.SelectedValue.CompareTo("editorEkle")==0)
            {
                EditorEklePanel.Visible = true;
                EditorEkleAdiTextBox.Text = "";
                EditorEkleKullaniciAdiTextBox.Text = "";
                EditorEkleSoyadiTextBox.Text = "";
                EditorEkleSifreTextBox.Text = "";
                EkleButton.Visible = true;
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("editorSil") == 0)
            {
                EditorSilPanel.Visible = true;
                SilButton.Visible = true;
                EditorSilRadioButtonList.ClearSelection();
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("modEkle") == 0)
            {
                ModeratorEklePanel.Visible = true;
                ModeratorEkleAdiTextBox.Text = "";
                ModeratorEkleSoyadiTextBox.Text = "";
                ModeratorEkleKullaniciAdiTextBox.Text = "";
                ModeratorEkleSifreTextBox.Text = "";
                EkleButton.Visible = true;
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("modSil") == 0)
            {
                ModeratorSilPanel.Visible = true;
                SilButton.Visible = true;
                ModeratorSilRadioButtonList.ClearSelection();
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("dergiEkle") == 0)
            {
                DergiAdiTextBox.Text = "";
                MaxMakaleTextBox.Text = "";
                EditorIdTextBox.Text = "";
                DergiEklePanel.Visible = true;
                EkleButton.Visible = true;
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("dergiSil") == 0)
            {
                DergiSilPanel.Visible = true;
                SilButton.Visible = true;
                DergiSilRadioButtonList.ClearSelection();
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("bilimDaliEkle") == 0)
            {
                BilimDaliEklePanel.Visible = true;
                BilimDaliTextBox.Text = "";
                EkleButton.Visible = true;
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("bilimDaliSil") == 0)
            {
                BilimDaliSilPanel.Visible = true;
                SilButton.Visible = true;
                BilimDaliSilRadioButtonList.ClearSelection();
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("altKategoriEkle") == 0)
            {
                AltKategoriAdiTextBox.Text = "";
                AltKategoriEklePanel.Visible = true;
                BilimDaliCheckBoxList.ClearSelection();
                EkleButton.Visible = true;
                IptalButton.Visible = true;
            }
            else if (isListesi.SelectedValue.CompareTo("altKategoriSil") == 0)
            {
                AltKategoriSilPanel.Visible = true;
                AltkategoriSilRadioButtonList.ClearSelection();
                SilButton.Visible = true;
                IptalButton.Visible = true;
            }
            MesajLabel.Text = "";
        }

        protected void EkleButton_Click(object sender, EventArgs e)
        {
            try
            {
                Manager mngr = new Manager();
                if (isListesi.SelectedValue.CompareTo("editorEkle") == 0)
                {
                    Publisher p = new Publisher();
                    p.name = EditorEkleAdiTextBox.Text;
                    p.surName = EditorEkleSoyadiTextBox.Text;
                    p.userName = EditorEkleKullaniciAdiTextBox.Text;
                    p.passWord = EditorEkleSifreTextBox.Text;
                    p.isActive = 1;
                    p.profession = "";
                    p.resume = "";
                    int i = mngr.AddPublisher(p);
                    if (i > 0)
                    {
                        MesajLabel.Text = "Editör ekleme işlemi başarılı!";
                    }
                    else
                    {
                        MesajLabel.Text = "İşlem Başarısız!";
                    }

                }
                else if (isListesi.SelectedValue.CompareTo("modEkle") == 0)
                {
                    Moderator m = new Moderator();
                    m.name = ModeratorEkleAdiTextBox.Text;
                    m.surName = ModeratorEkleSoyadiTextBox.Text;
                    m.userName = ModeratorEkleKullaniciAdiTextBox.Text;
                    m.passWord = ModeratorEkleSifreTextBox.Text;
                    m.isActive = 1;
                    int i = mngr.AddModerator(m);
                    if (i > 0)
                    {
                        MesajLabel.Text = "Moderatör ekleme işlemi başarılı!";
                    }
                    else
                    {
                        MesajLabel.Text = "İşlem Başarısız!";
                    }
                }
                else if (isListesi.SelectedValue.CompareTo("dergiEkle") == 0)//dergi
                {
                    Magazine m = new Magazine();
                    m.name = DergiAdiTextBox.Text;
                    m.maxPaperCount = Convert.ToInt32(MaxMakaleTextBox.Text.Trim());
                    m.publisherId = Convert.ToInt32(EditorIdTextBox.Text.Trim());
                    int i = mngr.AddMagazine(m);
                    List<int> checkedId = new List<int>();
                    foreach (ListItem item in DergiEkleAltKategoriCheckBoxList.Items)
                    {
                        if (item.Selected)
                        {
                            checkedId.Add(Convert.ToInt32(item.Value));
                        }
                    }
                    foreach (int SubScienceId in checkedId)
                    {
                        mngr.AddSubCategoryToMagazine(SubScienceId,i);
                        //mngr.AddSubCategoryToScienceCategory(SubScienceId, i);
                    }
                    if (i > 0)
                    {
                        MesajLabel.Text = "Dergi ekleme işlemi başarılı!";
                    }
                    else
                    {
                        MesajLabel.Text = "İşlem Başarısız!";
                    }
                }
                else if (isListesi.SelectedValue.CompareTo("bilimDaliEkle") == 0)//bilim dalı
                {
                    ScienceCategory sc = new ScienceCategory();
                    sc.name = BilimDaliTextBox.Text;
                    int i = mngr.AddScienceCategory(sc);
                    if (i > 0)
                    {
                        MesajLabel.Text = "Bilim dalı ekleme işlemi başarılı!";
                    }
                    else
                    {
                        MesajLabel.Text = "İşlem Başarısız!";
                    }
                }
                else if (isListesi.SelectedValue.CompareTo("altKategoriEkle") == 0)//alt kategori
                {
                    List<int> checkedId = new List<int>();
                    foreach (ListItem item in BilimDaliCheckBoxList.Items)
                    {
                        if (item.Selected)
                        {
                            checkedId.Add(Convert.ToInt32(item.Value));
                        }
                    }
                    SubCategory sc = new SubCategory();
                    sc.name = AltKategoriAdiTextBox.Text;
                    sc.id = mngr.AddSubCategory(sc);
                    mngr.ApproveSubCategory(sc);
                    foreach (int ScienceId in checkedId)
                    {
                        mngr.AddSubCategoryToScienceCategory(sc.id, ScienceId);
                    }
                    if (sc.id > 0)
                    {
                        //MesajLabel.Text = "Bilim dalı alt kategorisi ekleme işlemi başarılı!";
                        MesajLabel.Text = sc.id.ToString() ;
                    }
                    else
                    {
                        MesajLabel.Text = "İşlem Başarısız!";
                    }

                }
                isListesi.ClearSelection();
                Gorunmez_Yap();
                DataBind();
            }
            catch(FormatException ex)
            {
                string error = ex.Message;
            }
        }

        protected void MaxMakaleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SilButton_Click(object sender, EventArgs e)
        {
            try
            {
                Manager mngr = new Manager();
                if (isListesi.SelectedValue.CompareTo("editorSil") == 0)
                {
                    mngr.DeletePublisher(Convert.ToInt32(EditorSilRadioButtonList.SelectedValue));
                }
                else if (isListesi.SelectedValue.CompareTo("modSil") == 0)
                {
                    mngr.DeleteModerator(Convert.ToInt32(ModeratorSilRadioButtonList.SelectedValue));
                }
                else if (isListesi.SelectedValue.CompareTo("dergiSil") == 0)
                {
                   mngr.DeleteMagazine(Convert.ToInt32(DergiSilRadioButtonList.SelectedValue));
                }
                else if (isListesi.SelectedValue.CompareTo("bilimDaliSil") == 0)
                {
                   mngr.DeleteScienceCategory(Convert.ToInt32(BilimDaliSilRadioButtonList.SelectedValue));
                }
                else if (isListesi.SelectedValue.CompareTo("altKategoriSil") == 0)
                {
                    mngr.DeleteSubCategory(Convert.ToInt32(AltkategoriSilRadioButtonList.SelectedValue));
                }
                isListesi.ClearSelection();
                Gorunmez_Yap();
                DataBind();
            }
            catch(FormatException ex)
            {
                string error = ex.Message;
            }
        
        }

        protected void IptalButton_Click(object sender, EventArgs e)
        {
            isListesi.ClearSelection();
            Gorunmez_Yap();
        }
    }
}