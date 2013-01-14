﻿using System;
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
        protected void Add_Comment_Click(object sender, EventArgs e)
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
            SVC1.Paper p = new SVC1.Paper();
            p.id = paperID;
            m.ExaminePaper(p,clist.ToArray(),refreeid,null);            
        }  

        protected void Send_Publisher_Click(object sender, EventArgs e)
        {
            int paperID = Convert.ToInt32(Request.QueryString["pid"].ToString());
            Manager m = new Manager();
            int refreeid = Convert.ToInt32(Session["userid"]);
            m.SendOpinionToPublisher(paperID, refreeid, 2);           
        }      
        protected void Download_Click(object sender, EventArgs e)
        {
            string filename = p[0].title + ".pdf";            
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string path = p[0].contentPath;
            Response.TransmitFile(Server.MapPath(path));
            Response.End();            
        }

        protected void Survey_Click(object sender, EventArgs e)
        {
            int paperID = Convert.ToInt32(Request.QueryString["pid"].ToString());
            Manager m = new Manager();
            //int magazineid = p[0].MagazineID;
            int magazineid = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].id == paperID)
                    magazineid = p[i].MagazineID;
            }
            Response.Redirect("Survey.aspx?mid=" + magazineid + "&pid=" + paperID);
        }                       
    }
}