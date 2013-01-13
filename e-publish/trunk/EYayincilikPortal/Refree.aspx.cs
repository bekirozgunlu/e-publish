using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*  @author Bekir Özgünlü
    @date January 2013
 */

namespace EYayincilikPortal
{
    public partial class Refree : System.Web.UI.Page
    {
        int refreeID;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["userid"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            refreeID = Convert.ToInt32( Session["userid"].ToString() ) ;
            Manager m = new Manager();
            SVC1.User r = m.GetUserByID(refreeID);            
            TextBox1.Text = r.userName.ToString();
            TextBox2.Text = r.name.ToString();
            TextBox3.Text = r.surName.ToString();                      
        }
    }
}