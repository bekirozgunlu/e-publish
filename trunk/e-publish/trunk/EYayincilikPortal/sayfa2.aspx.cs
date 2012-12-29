using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EYayincilikPortal
{
    public partial class sayfa2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SVC1.User x = (Session["userBilgileri"] as SVC1.User);
            string str = Request.QueryString[0].ToString();

            TextBox2.Text = x.name + " " + x.surName;

            //ObjectDataSource1.D
        }
    }
}