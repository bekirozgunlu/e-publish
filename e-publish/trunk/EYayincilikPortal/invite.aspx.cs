﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;
using System.Web.Mail;

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
                int RefereeID=m.AddReferee(r);


                try
                {

                    string from = "sagirlibas@gmail.com";
                    string to = txtMail.Text.Trim();
                    string subject = "E-Yayıncılık Hakemlik Davetiyesi !";
                    string body = " Hakemliği kabul etmek için http://eyayincilik/invite.aspx?invitation="+RefereeID.ToString()+" linkine tıklayınız  ";
                    System.Web.Mail.SmtpMail.SmtpServer = "LocalHost";
                    System.Web.Mail.SmtpMail.Send(from, to, subject, body);

                    Response.Redirect("editor.aspx");
                }
                catch(Exception ex)
                {
                    Label1.Text = "mail gönderilemedi:" + ex.Message;
                }

                
            


        }
    }
}