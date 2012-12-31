using System;
using System.Collections.Generic;
using System.Text;


namespace BSClass
{
    public partial class Paper
    {
        //public int id;
        //public int authorId;
        //public SubCategory[] subCategories;
        //public int approvalState;
        //public string content;      //keeps pdf path
        //public DateTime approvalDate;
        //public Referee[] referees;
        //public string [] referencePaperID;   
        //public int publishedId;
        //public double version;
        //public Survey survey;
        //public string title;
        //public Comment[] comments;


        public int AddPaper()
        {
            return DBManager.singleton().AddPaper(this);
        }

        public void DeletePaper(int PaperID)
        {
            DBManager.singleton().DeletePaper(PaperID);
        }

        public void UpdatePaper()
        {
            DBManager.singleton().UpdatePaper(this);
        }


        public void ListComments()
        {
            comments = DBManager.singleton().GetCommentList(this.id.ToString(), -1, false);
        }

    }
}
