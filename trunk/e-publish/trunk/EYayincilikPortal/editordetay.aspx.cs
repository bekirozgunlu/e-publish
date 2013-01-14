using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class editordetay : System.Web.UI.Page
    {
        User sessionUser;
        int paperID;

        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Session["user"] as User);

            paperID =Convert.ToInt32(Request.QueryString["id"].ToString());


            if (Session["isEditor"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (Session["isEditor"].ToString() != "1")
            {
                Response.Redirect("login.aspx");
            }



            if (paperID > 0 && (!IsPostBack) )
            {
                Manager m = new Manager();
                Paper[] plist = m.GetPaperList("", "", paperID.ToString(), -1, -1, -1, "", "", true);
                txtYorum.Text = plist[0].publisherComment;
                m = null;
            }


        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            
            Paper[] plist = m.GetPaperList("", "", paperID.ToString(), -1, -1, -1, "", "", true);

            string path ="../upload/" + paperID.ToString() + "_" + plist[0].version.ToString()+".pdf";
            Response.Redirect(path);
        }

        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            Paper[] plist = m.GetPaperList("", "", paperID.ToString(), -1, -1, -1, "", "", true);

            plist[0].approvalState = Convert.ToInt32(ApprovalState.Editor_Onayli);
            m.UpdatePaper(plist[0]);

            m = null;

            Response.Redirect("editor.aspx");


        }

        protected void btnSendToReferee_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            m.SendPaperToReferee(paperID, Convert.ToInt32( cmbReferee.SelectedValue.ToString()), sessionUser.userID);
            m = null;
            GridView1.DataBind();
        }

        protected void btnEditorYorum_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            Paper[] plist = m.GetPaperList("", "", paperID.ToString(), -1, -1, -1, "", "", true);

            plist[0].publisherComment = txtYorum.Text;
            m.UpdatePaper(plist[0]);

            m = null;
        }

        protected void btnSendToAuthor_Click(object sender, EventArgs e)
        {
            Manager m = new Manager();
            Paper[] plist = m.GetPaperList("", "", paperID.ToString(), -1, -1, -1, "", "", true);

            plist[0].publisherComment = txtYorum.Text;
            plist[0].approvalState = Convert.ToInt32(ApprovalState.Yazar_Duzeltme);

            m.UpdatePaper(plist[0]);

            m = null;

            Response.Redirect("editor.aspx");
        }
    }
}