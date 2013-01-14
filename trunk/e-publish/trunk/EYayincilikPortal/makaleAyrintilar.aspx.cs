using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
     public partial class makaleAyrintilar : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               Manager m = new Manager();
               Paper[] p = m.GetPaperList(null, null, (Session["currentPaperId"]).ToString(), -1, -1, -1, null, null, true);
               Paper paper = p[0];
               User sessionUser = Session["user"] as User;
               txtYazarAdi.Text = sessionUser.name + " " + sessionUser.surName;
               txtBaslik.Text = paper.title;
               TextBox1.Text = paper.MagazineName;
               
               
          }

           protected void Button1_Click(object sender, EventArgs e)
        {

            string uploadFolder ="C:/inetpub/wwwroot/upload/";
            if (FileUpload1.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (extension.ToLower() == ".pdf")
                {
                    Manager m =new Manager();
                    Paper [] p = m.GetPaperList(null,null,(Session["currentPaperId"]).ToString(),-1,-1,-1,null,null,true);
                    Paper paper = p[0];
                     paper.version++;

                     FileUpload1.SaveAs(uploadFolder + paper.id + "_" + paper.version.ToString() + ".pdf");
                    paper.contentPath = paper.id + "_" + paper.version.ToString() + ".pdf";
                    m.UpdatePaper(paper);

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
     }
}