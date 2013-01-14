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

            Session["user"] = null;
            Session["userid"] = null;
            Session["isEditor"] = "0";
            Session["isReferee"] = "0";
            Session["isAuthor"] = "0";
            Session["isModerator"] = "0";
            Session["isAdmin"] = "0";
            Session["isStandardUser"] = "0";
            Session["isAnonimUser"] = "0";

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
                    int []GrantList = m.GetUserTypes(u.userID);

                    


                    Session["user"] = u;
                    Session["userid"] = u.userID;



                    

                    if (GrantList.Contains<int>( Convert.ToInt32(UserType.editor)) ) 
                    {
                        Session["isEditor"] = "1";
                        //Response.Redirect("editor.aspx");
                    }
                     if (GrantList.Contains<int>( Convert.ToInt32(UserType.hakem)))
                    {
                        Session["isReferee"] = "1";
                        //Response.Redirect("hakem.aspx");
                    }
                     if (GrantList.Contains<int>( Convert.ToInt32(UserType.yazar)))
                    {
                        Session["isAuthor"] = "1";
                        //Response.Redirect("yazar.aspx");
                    }
                     if (GrantList.Contains<int>( Convert.ToInt32(UserType.moderator)))
                    {
                        Session["isModerator"] = "1";
                        //Response.Redirect("moderator.aspx");
                    }
                   
                     if (GrantList.Contains<int>( Convert.ToInt32(UserType.systemadmin)))
                    {
                        Session["isAdmin"] = "1";
                        //Response.Redirect("admin.aspx");
                    }
                     if (GrantList.Contains<int>( Convert.ToInt32(UserType.standard)))
                    {
                        Session["isStandardUser"] = "1";
                        //Response.Redirect("default.aspx");
                    }

                    if (GrantList.Contains<int>( Convert.ToInt32(UserType.anonim)))
                    {
                        Session["isAnonimUser"] = "1";
                        //Response.Redirect("default.aspx");
                    }

                    Response.Redirect("default.aspx");
                }
            }
            m = null;
        }
    }
}