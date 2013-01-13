using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;
using System.Drawing;

namespace EYayincilikPortal
{
    public partial class Kayıt : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                
                // kullaniciAdi = TextBox1.Text.ToString();
                //string ad = TextBox2.ToString();
                //string Soyad = TextBox3.ToString();
                //string parola = TextBox4.ToString();


                if (DropDownList1.SelectedIndex == 0)  //okuyucu
                {
                    User u = new User();
                    u.name = TxtAdı.Text;
                    u.surName = TxtSoyadı.Text;
                    u.userName = txtKullanıcıAdı.Text;
                    u.passWord = TxtSifre.Text;
                    u.photoFilePath = TxtFoto.Text;
                    
                    u.isActive = 2;

                    Manager m = new Manager();
                    m.AddUser(u);
                    lblBilgi.Text = "Kaydınız başarıyla gerçekleştirildi.";

                    m = null;

                    
                }
                else if (DropDownList1.SelectedIndex == 1) //yazar 
                {  

                    Author aa = new Author();
                    aa.name = TxtAdı.Text;
                    aa.surName = TxtSoyadı.Text;
                    aa.userName = txtKullanıcıAdı.Text;
                    aa.resume = TxtCV.Text;
                    aa.passWord = TxtSifre.Text;
                    aa.isActive = 2;
                    aa.photoFilePath = TxtFoto.Text;

                    Manager m = new Manager() ;
                    m.AddAuthor(aa);

                    m = null;



                    lblBilgi.Text = "Kaydınız başarıyla gerçekleştirildi.";
                }
                else if (DropDownList1.SelectedIndex == 2)//moerator                
                { 
                    Moderator m = new Moderator();
                    m.name = TxtAdı.Text;
                    m.surName = TxtSoyadı.Text;
                    m.userName = txtKullanıcıAdı.Text;
                    m.passWord = TxtSifre.Text;
                    m.isActive = 2;
                    m.photoFilePath = TxtFoto.Text;



                    Manager mm = new Manager();
                    mm.AddModerator(m);


                    mm = null;

                    lblBilgi.Text = "Kaydınız başarıyla gerçekleştirildi.";
                
                }
                TxtAdı.Text = "";
                TxtSoyadı.Text = "";
                txtKullanıcıAdı.Text = "";
                TxtSifre.Text = "";
                TxtSifre2.Text = "";
                TxtCV.Text = "";
                TxtFoto.Text = "";
               
                //DropDownList1.SelectedValue = "0" ;
            }
            catch
            {
                lblBilgi.Text="Kayıt Sırasında hata oluştu.";

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "2")
            {
                TxtCV.Visible = false;
                BtnCv.Visible = false;
                LblCV.Visible = false;
            }
            if (DropDownList1.SelectedValue == "2")
            {
                TxtCV.Visible = true;
                LblCV.Visible = true;
                BtnCv.Visible = true;
            }
        }

        protected void TxtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtSifre2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}