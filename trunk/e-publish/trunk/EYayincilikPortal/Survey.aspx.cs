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
    public partial class Survey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }       

        protected void Submit_Click(object sender, EventArgs e)
        {            
            List<SVC1.SurveyAnswer> answerlist = new List<SVC1.SurveyAnswer>();
            int i = 0;
            GridViewRow answer;
            for (i = 0; i < GridView1.Rows.Count; i++)
            {
                answer = GridView1.Rows[i];
                SVC1.SurveyAnswer sc = new SVC1.SurveyAnswer();
                sc.answer = ((TextBox)answer.FindControl("TextBox1")).Text;
                sc.surveyQuestionaryid = Convert.ToInt32(GridView1.DataKeys[i].Value);                                                            
                sc.PaperRef = Convert.ToInt32(Request.QueryString["pid"]);
                answerlist.Add(sc);
            }
            Manager m = new Manager();                                                           
            m.AnswerSurvey(answerlist.ToArray());
            Response.Redirect("PaperDetail.aspx?pid=" + Request.QueryString["pid"].ToString());   
        }
    }
} 