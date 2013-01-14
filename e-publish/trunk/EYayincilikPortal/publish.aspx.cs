using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal;

namespace EYayincilikPortal
{
    public partial class publish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if(! IsPostBack)
            {
                cmbDergi_SelectedIndexChanged(sender, e);
            }

        }

        protected void cmbDergi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager m = new Manager();
            SVC1.Paper[] pList = m.GetPaperList("", cmbDergi.SelectedValue.ToString(), "", -1, Convert.ToInt32(Session["userid"].ToString()), -1, "", "", true);
            GridView1.DataSource = pList;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            Manager m = new Manager();
            SVC1.Paper []pList= m.GetPaperList("", cmbDergi.SelectedValue.ToString(), "", -1, Convert.ToInt32(Session["userid"].ToString()), -1, "", "", true);
            GridView1.DataSource = pList;
            GridView1.DataBind();
            m = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            
            //foreach( dr )

            m.PublishMagazine(Convert.ToInt32(cmbDergi.SelectedValue.ToString()), "");
            //Button3_Click(sender, e);

            m = null;

            Response.Redirect("editor.aspx");
        }
    }
}