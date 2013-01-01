using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class invite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user"] as User).userType[0] != Convert.ToInt32(UserType.editor)) 
            {
                Response.Redirect("Default.aspx");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

       
                Referee r = new Referee();
                r.name = txtName.Text.Trim().ToUpper();
                r.surName = txtSur.Text.Trim().ToUpper();
                r.profession = "HAKEM";
                r.resume = "HAKEM CV";
                r.userName = txtUser.Text.Trim();
                r.passWord = txtPass.Text;
                r.isActive = 2;

                Manager m = new Manager();
                m.AddReferee(r);


                Response.Redirect("editor.aspx");
            


        }
    }
}