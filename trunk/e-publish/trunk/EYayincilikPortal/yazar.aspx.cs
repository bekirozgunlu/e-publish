﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class yazar : System.Web.UI.Page
    {

        User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Session["user"] as User);
            if (Session["isAuthor"] == null) 
            {
                Response.Redirect("login.aspx");
                return;
            }

            if ( Session["isAuthor"].ToString()!= "1")
            {
                Response.Redirect("login.aspx");
            } 
        }
    }
}