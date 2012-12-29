using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Magazine
    {
        //public int publisherId;
        //public int id;
        //public string name;
        //public SubCategory[] subCategories;
        //public PublishedMagazine[] publishedMagazines;
        //public Paper [] ApprovedPaperList;

        public int AddMagazine()
        {
            return DBManager.singleton().AddMagazine(this);
        }

        public void DeleteMagazine(int MagazineID)
        {
            DBManager.singleton().DeleteMagazine(MagazineID);
        }

        public void UpdateMagazine()
        {
            DBManager.singleton().UpdateMagazine(this);

            
        }

        public void GetPublisheMagazineList() 
        {
            publishedMagazines = DBManager.singleton().GetPublisheMagazineList(this.id.ToString(), "", false);
        }





    }
}
