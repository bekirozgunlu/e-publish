using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1 ;


namespace EYayincilikPortal
{
    public partial class detay : System.Web.UI.Page
    {
        int PaperID = 0;
        bool YeniMakaleMi = true;
        bool isEditor = false;
        bool isAuthor = false;
        bool isReferee = false;
        User sessionUser;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.Count>0)
                PaperID = Convert.ToInt32(Request.QueryString["id"].ToString());


            if (PaperID > 0) 
            {
                YeniMakaleMi =false;   
            }

            if (Session["isAuthor"].ToString() != "1") 
            {
                Response.Redirect("default.aspx");
                return;
            }



            sessionUser = Session["user"] as User;
            txtYazarAdi.Text = sessionUser.name + " " + sessionUser.surName;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string uploadFolder ="C:/inetpub/wwwroot/upload/";
            if (FileUpload1.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (extension.ToLower() == ".pdf")
                {

                    Paper p = new Paper();
                    p.approvalState = Convert.ToInt32(ApprovalState.YeniYuklendi);
                    p.authorId = sessionUser.userID;
                    p.contentPath = "TODO";
                    p.MagazineID = Convert.ToInt32( cmbDergi.SelectedValue.ToString());
                    p.title = txtBaslik.Text.Trim();
                    p.isActive = 1;


                    List<SubCategory> scList = new List<SubCategory>(); 
                    foreach (ListItem lt in ListSecimAltKategory.Items) 
                    {
                        SubCategory scx=new SubCategory();
                        scx.id=Convert.ToInt32(lt.Value.ToString()) ;
                        scx.name=lt.Text ;


                        scList.Add(scx);
                    }



                    Manager m = new Manager();

                    p.subCategories = scList.ToArray();

                    int newID= m.AddPaper(p);
                    


                    FileUpload1.SaveAs(uploadFolder + p.title+"_"+newID.ToString()+".pdf" );
                    p.contentPath = p.title + "_" + newID.ToString() + ".pdf";
                    m.UpdatePaper(p);
                    m = null;


                    

                    Label1.Text = "Makale Gönderildi : " + FileUpload1.PostedFile.FileName;
                  

                }
                else
                {
                    Label1.Text = "This file extension not permitted: " + extension;
                }
            }
            else
            {
                Label1.Text = "Please select a file.";
            }  

          
        }

        protected void cmbAnaKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager m=new Manager();
            
            SubCategory[] sList = m.GetSubCategoryList(true, cmbAnaKat.SelectedValue.ToString(), Convert.ToInt32(cmbDergi.SelectedValue));
            ListAltKategory.DataSource = sList;
            ListAltKategory.DataBind();
            m = null;
        }

        protected void cmbDergi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager m = new Manager();

            ScienceCategory[] sList = m.ScienceCategoryList(true, -1, Convert.ToInt32(cmbDergi.SelectedValue));
            cmbAnaKat.DataSource = sList;
            cmbAnaKat.DataBind();
            m = null;
        }

        protected void btnAnaKategoriEkle1_Click(object sender, EventArgs e)
        {
            if (ListAltKategory.SelectedIndex >= 0 && ListSecimAltKategory.Items.IndexOf(ListAltKategory.SelectedItem)<0) 
            {                
                ListSecimAltKategory.Items.Add(ListAltKategory.SelectedItem);
            }
        }

        protected void btnAnaKategoriSil_Click(object sender, EventArgs e)
        {
            if (ListSecimAltKategory.SelectedIndex >= 0)
            {
                ListSecimAltKategory.Items.Remove(ListSecimAltKategory.SelectedItem);
            }
        }
    }
}