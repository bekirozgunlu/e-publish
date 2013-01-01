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

            if (Request.QueryString.Count>0)
                parametre = Request.QueryString["id"].ToString();

           // TextBox1.Text = parametre;


        }
    }
}