using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class editor : System.Web.UI.Page
    {
        User sessionUser;


        
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Session["user"] as User);

            
            if (Session["isEditor"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (Session["isEditor"].ToString() != "1")
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnInvite_Click(object sender, EventArgs e)
        {
            Response.Redirect("invite.aspx");
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            Response.Redirect("publish.aspx");
        }
    }
}