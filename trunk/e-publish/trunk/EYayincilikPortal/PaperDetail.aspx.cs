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
    public partial class PaperDetail : System.Web.UI.Page
    {
        static SVC1.Paper[] p;        
        protected void Page_Load(object sender, EventArgs e)
        {
            string paperID = Request.QueryString["pid"].ToString();
            Manager m = new Manager();        
            p = m.GetPaperList("","",paperID,-1,-1,-1,"","",true);           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int paperID = Convert.ToInt32(Request.QueryString["pid"].ToString());
            Manager m = new Manager();           
            List<SVC1.Comment> clist = new List<SVC1.Comment>();
            SVC1.Comment c = new SVC1.Comment();
            int refreeid = Convert.ToInt32(Session["userid"]);
            c.content = Request.Form["S1"].ToString();
            c.paperId = paperID;
            c.userId = refreeid;
            c.approvalState = 1;
            c.commentType = 1;
            clist.Add(c);                        
            m.ExaminePaper(null,clist.ToArray(),-1,null);
            Response.Redirect("Default.aspx?code=200");         
        }  

        protected void Button1_Click(object sender, EventArgs e)
        {
            int paperID = Convert.ToInt32(Request.QueryString["pid"].ToString());
            Manager m = new Manager();
            int refreeid = Convert.ToInt32(Session["userid"]);
            m.SendOpinionToPublisher(paperID, refreeid, 2);
            Response.Redirect("Default.aspx?code=200");   
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int paperID = Convert.ToInt32(Request.QueryString["pid"].ToString());
            Manager m = new Manager();
            //int magazineid = p[0].MagazineID;
            int magazineid = 0;
            for ( int i = 0 ; i < p.Length;  i++){
                if (p[i].id == paperID)
                    magazineid = p[i].MagazineID;
            }
            Response.Redirect("Survey.aspx?mid=" + magazineid+"&pid="+paperID);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string filename = p[0].title + ".pdf";            
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string path = p[0].contentPath;
            Response.TransmitFile(Server.MapPath(path));
            Response.End();            
        }               
    }
}