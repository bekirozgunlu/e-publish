using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EYayincilikPortal
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userid"] = null;
            Session["isEditor"] = "0";
            Session["isReferee"] = "0";
            Session["isAuthor"] = "0";
            Session["isModerator"] = "0";
            Session["isAdmin"] = "0";
            Session["isStandardUser"] = "0";
            Session["isAnonimUser"] = "0";


            Response.Redirect("default.aspx");
        }
    }
}