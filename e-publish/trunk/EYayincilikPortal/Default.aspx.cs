using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;



namespace EYayincilikPortal
{
    public partial class _Default : System.Web.UI.Page
    {
        User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                sessionUser = (Session["user"] as User);
                Label1.Text = sessionUser.name + ' ' + sessionUser.surName.ToUpper();
                loginlink.Visible = false;
                if (Session["isEditor"] != null && Session["isEditor"].ToString() == "1")
                {
                    btnEditor.Visible = true;
                }

                if (Session["isModerator"] != null && Session["isModerator"].ToString() == "1")
                {
                    btnModerator.Visible = true;
                }
                if (Session["isAuthor"] != null && Session["isAuthor"].ToString() == "1")
                {
                    btnYazar.Visible = true;
                }

                if (Session["isAdmin"] != null && Session["isAdmin"].ToString() == "1")
                {
                    btnAdmin.Visible = true;
                }
                if (Session["isReferee"] != null && Session["isReferee"].ToString() == "1")
                {
                    btnHakem.Visible = true;
                }
                loginlink1.Visible = true;
            }
            else {
                loginlink1.Visible = false;
                loginlink.Visible = true;
            }
           // DataBind();
        }



      
    }
}