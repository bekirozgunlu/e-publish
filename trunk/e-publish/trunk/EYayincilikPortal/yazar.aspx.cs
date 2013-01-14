using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class yazar : System.Web.UI.Page
    {

        User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Session["user"] as User);
            if (Session["isAuthor"] == null) 
            {
                Response.Redirect("login.aspx");
                return;
            }

            if ( Session["isAuthor"].ToString()!= "1")
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {


             if (e.CommandName.CompareTo("Yorumlar") == 0 ||
                 e.CommandName.CompareTo("Referanslar") == 0 ||
                 e.CommandName.CompareTo("Incele") == 0)
             {
                  string pID = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                       //Convert.ToInt32(GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                  if (e.CommandName.CompareTo("Yorumlar") == 0)
                  {
                       Manager m = new Manager();
                       Paper[] p = m.GetPaperList(null, null, pID, -1, -1, -1, null, null, true);
                       Paper paper = p[0];
                       GridView2.DataSource = paper.comments;
                       GridView2.DataBind();
                       m = null;

                  }
                  if (e.CommandName.CompareTo("Incele") == 0) 
                  {
                       Session["currentPaperId"] = pID;
                       Response.Redirect("~/makaleAyrintilar.aspx");
                  }
                  if (e.CommandName.CompareTo("Referanslar") == 0)
                  {
                       // TODO references
                       Manager m = new Manager();
                       DataTable comments = m.GetReferenceList(Convert.ToInt32(pID), -1);
                       GridView3.DataSource = comments;
                     //  GridView3.DataBind();
                  }
                  
             }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}