using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EYayincilikPortal
{
    public partial class editor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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