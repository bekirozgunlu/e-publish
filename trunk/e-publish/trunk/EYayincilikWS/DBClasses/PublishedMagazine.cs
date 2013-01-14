using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class PublishedMagazine
    {
        //public int id;
        //public int[] MagazineState; //
        //public Magazine mgzn;
        //public PublishedMagazine[] PublishedMagazineList;
        //public int PublishedMagazineCount;


        public int AddPublishedMagazine(int iMagazineID)
        {
            return DBManager.singleton().AddPublishedMagazine(this, iMagazineID);
        }

        public void DeletePublishedMagazine(int PublishedMagazineID)
        {
            DBManager.singleton().DeletePublishedMagazine(PublishedMagazineID);
        }

        public void UpdatePublishedMagazine()
        {
            DBManager.singleton().UpdatePublishedMagazine(this);


            
        }

        public void AddPaperToMagazine(Paper p) 
        {
            DBManager.singleton().AddPaperToMagazine(p,this.id);
        }

        public void PublishMagazine()
        {
            //DBManager.singleton().PublishMagazine(this.id);
        }


        public void PublishMagazineIDCreate()
        {
            //LOCAL YARAT...
            UpdatePublishedMagazine();
        }

    }
}
