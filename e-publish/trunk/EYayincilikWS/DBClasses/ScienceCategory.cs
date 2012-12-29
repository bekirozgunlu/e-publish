using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class ScienceCategory
    {
        //public int id;
        //public string name;
        //public SubCategory[] subCategories;


        public int AddScienceCategory()
        {
            return DBManager.singleton().AddScienceCategory(this);
        }

        public void DeleteScienceCategory(int ScienceCategoryID)
        {
            DBManager.singleton().DeleteScienceCategory(ScienceCategoryID);
        }

        public void UpdateScienceCategory( )
        {
            DBManager.singleton().UpdateScienceCategory(this);
        }

        public void GetSubCategoryList() 
        {
            DBManager.singleton().GetSubCategoryList(false);
        }
    }
}
