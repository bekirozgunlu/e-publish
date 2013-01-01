using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            User u = m.CheckUserPass(txtUser.Text.Trim(), txtPass.Text.Trim());
            if (u == null)
                lblError.Text = "HATA !!! ";
            else 
            {
                if (u.userType.Length == 0) 
                {
                    lblError.Text = "Kullanıcı Yetki Verilmemiş !!! ";
                }
                if (u.userType.Length >0 )
                {

                    Session["user"] = u;
                    Session["userid"] = u.userID;

                    if (u.userType[0] == Convert.ToInt32(UserType.editor) ) 
                    {
                        Response.Redirect("editor.aspx");
                    }
                    else if (u.userType[0] == Convert.ToInt32(UserType.hakem))
                    {
                        Response.Redirect("hakem.aspx");
                    }
                    else if (u.userType[0] == Convert.ToInt32(UserType.yazar))
                    {
                        Response.Redirect("yazar.aspx");
                    }
                    else if (u.userType[0] == Convert.ToInt32(UserType.moderator))
                    {
                        Response.Redirect("moderator.aspx");
                    }
                   
                    else if (u.userType[0] == Convert.ToInt32(UserType.systemadmin))
                    {
                        Response.Redirect("admin.aspx");
                    }
                    else if (u.userType[0] == Convert.ToInt32(UserType.standard))
                    {
                        Response.Redirect("default.aspx");
                    }

                    if (u.userType[0] == Convert.ToInt32(UserType.anonim))
                    {
                        Response.Redirect("default.aspx");
                    }
                }
            }
            m = null;
        }
    }
}