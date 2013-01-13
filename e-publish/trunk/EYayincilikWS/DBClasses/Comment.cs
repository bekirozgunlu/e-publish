using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Comment
    {
        //public int id;
        //public int commentType;
        //public string content;
        //public int CommentId;
        //public int userId;
        //public int approvalState;
        //public DateTime commentDate;

        public string YorumuYazan
        {
            get
            {
                return DBManager.singleton().GetUserByID(this.userId).userName; 
            }
            set
            {
            }
        }


        public string MakaleAdi
        {
            get
            {
                return DBManager.singleton().GetPaperList("", "", this.paperId.ToString(), -1, -1, -1, "", "", true)[0].title;
            }
            set
            {
            }
        }


        public int AddComment(int paperID)
        {
            return DBManager.singleton().AddComment(this,paperID);
        }

        public void DeleteComment(int CommentID)
        {
            DBManager.singleton().DeleteComment(CommentID);
        }

        public void UpdateComment()
        {
            DBManager.singleton().UpdateComment(this);
        }

    }
}
