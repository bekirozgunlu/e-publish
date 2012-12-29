using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Author 
    {
        //public string profession;
        //public int paperCount;
        //public string resume;
        //public Paper[] paperList;

        public int AddAuthor()
        {
            return DBManager.singleton().AddAuthor(this);
        }

        public void DeleteAuthor(int AuthorID)
        {
            DBManager.singleton().DeleteAuthor(AuthorID);
        }

        public void UpdateAuthor()
        {
            DBManager.singleton().UpdateAuthor(this);
        }


        public void AddPaper(Paper p) 
        {
            DBManager.singleton().AddPaperByAuthor(this.userID, p);
        }





        

    }
}
