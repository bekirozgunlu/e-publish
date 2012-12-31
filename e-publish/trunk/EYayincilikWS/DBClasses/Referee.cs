using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Referee 
    {
        
        //public Paper[] papers;

        public int AddReferee()
        {
            return DBManager.singleton().AddReferee(this);
        }

        public void DeleteReferee(int RefereeID)
        {
            DBManager.singleton().DeleteReferee(RefereeID);
        }

        public void UpdateReferee()
        {
            DBManager.singleton().UpdateReferee(this);
        }

        public void ExaminePaper(BSClass.Paper p, BSClass.Comment[] commentlist, BSClass.SurveyAnswer[] answerList) 
        {
            DBManager.singleton().ExaminePaper(p, commentlist, this.userID, answerList);
        }

        public void ListPapers() 
        {
            papers = DBManager.singleton().GetPaperList("", "", "",this.userID, -1, -1, "", "", false);
        }

        public void SendOpinionToPublisher(int PaperID, int isApproved) 
        {
            DBManager.singleton().SendOpinionToPublisher (PaperID ,this.userID, isApproved );
        }


    }
}
