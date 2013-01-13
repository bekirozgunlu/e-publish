using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class moderator : System.Web.UI.Page
    {
        User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            sessionUser = (Session["user"] as User);
            if (Session["isModerator"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (Session["isModerator"].ToString() != "1")
            {
                Response.Redirect("login.aspx");
            }
             * */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rIndex = Convert.ToInt32 (e.CommandArgument) ;

            string id = GridView1.DataKeys[rIndex].Value.ToString();

            Manager m = new Manager();
            m.ApproveComment(Convert.ToInt32( id));
            m = null;

            DataBind();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "onay")
            {
                            
                 int rIndex = Convert.ToInt32 (e.CommandArgument) ;
                  string id = GridView2.DataKeys[rIndex].Value.ToString();

                  Manager m = new Manager();
                  m.ActivateUser(Convert.ToInt32( id));
                  m = null;
                  DataBind();
            }
            else if (e.CommandName == "red")
            {
                 int rIndex = Convert.ToInt32 (e.CommandArgument) ;
                 string id = GridView2.DataKeys[rIndex].Value.ToString();

                  Manager m = new Manager();
                  m.DeactivateUser(Convert.ToInt32( id));
                  m = null;
                  DataBind();
            }

        }

      
        

        
    }
}