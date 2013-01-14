using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYayincilikPortal.SVC1;

namespace EYayincilikPortal
{
    public partial class dergisoru : System.Web.UI.Page
    {
        
        SVC1.User sessionUser;
        int iMagazineID;
        int iSurveyID ;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Session["user"] as User);            

            if (Session["isEditor"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (Session["isEditor"].ToString() != "1")
            {
                Response.Redirect("login.aspx");
            }

            if (Session["SurveyID"] != null) 
            {
                iSurveyID = Convert.ToInt32(Session["SurveyID"].ToString());
            }


            if (!IsPostBack)
                DropDownList1.DataBind();

            GridView1.DataBind();

            if(! IsPostBack)
                DropDownList1_SelectedIndexChanged(sender, e);
            

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {

            Manager m = new Manager();

            if (iSurveyID <= 0) 
            {
                DropDownList1_SelectedIndexChanged(sender, e);
            }
                                               
            SurveyQuestionary sq = new SurveyQuestionary();
            sq.isActive = 1;
            sq.question = TextBox1.Text.Trim();

            m.AddSurveyQuestionary(sq, iSurveyID);

            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            iMagazineID = Convert.ToInt32(DropDownList1.SelectedValue.ToString());


            Manager m = new Manager();
            SVC1.Survey [] mySurveyList = m.GetSurvey(true, iMagazineID, -1);

            if (mySurveyList != null && mySurveyList.GetLength(0)>0)
            {
               
                iSurveyID = mySurveyList[0].id;
                Session["SurveyID"] = iSurveyID;
            }
            else
            {
                SVC1.Survey s=new SVC1.Survey();
                s.magazineId=iMagazineID ;
                s.isActive=1 ;
                iSurveyID= m.AddSurvey(s, iMagazineID);

                Session["SurveyID"] = iSurveyID;
            }
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {

                int rIndex = Convert.ToInt32(e.CommandArgument);
                string id = GridView1.DataKeys[rIndex].Value.ToString();

                Manager m = new Manager();
                m.DeleteSurveyQuestionary(Convert.ToInt32(id));
                m = null;
                GridView1.DataBind();
            }
        }
    }
}