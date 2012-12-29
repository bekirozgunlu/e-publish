using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Publisher 
    {
        //public Magazine[] magazines;



        public int AddPublisher()
        {
            return DBManager.singleton().AddPublisher(this);
        }

        public void DeletePublisher(int PublisherID)
        {
            DBManager.singleton().DeletePublisher(PublisherID);
        }

        public void UpdatePublisher()
        {
            DBManager.singleton().UpdatePublisher(this);
        }

        public void InviteReferee(Referee r) 
        {
            DBManager.singleton().InviteReferee(r, this.userID);
        }


        public void SendPaperBackToWriter(int PaperID, int AuthorID)
        {
            DBManager.singleton().SendPaperBackToWriter(PaperID,AuthorID,this.userID);
        }


    }
}
