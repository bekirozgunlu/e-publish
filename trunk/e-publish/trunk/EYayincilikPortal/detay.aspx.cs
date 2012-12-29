using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EYayincilikPortal
{
    public partial class detay : System.Web.UI.Page
    {
        string parametre = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            parametre = Request.QueryString["makaleID"].ToString();

            TextBox1.Text = parametre;


            SVC1.Magazine[] mm;


            mm = Session["MZ"] as SVC1.Magazine[] ;

            string aa;

        }
    }
}