using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace EYayincilikPortal
{
    public partial class _Default : System.Web.UI.Page
    {
        //EYWS.User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           
                SVC1.User x = Manager.singleton().GetUserByID(2);
                TextBox1.Text = x.userID.ToString();
                TextBox2.Text = x.userName.ToUpper() ;

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SVC1.Service1 svc = new SVC1.Service1();
            
            
            Response.Redirect("sayfa2.aspx?tt=21");
        }
    }
}