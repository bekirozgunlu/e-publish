using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class SubCategory
    {
        //public int id;
        //public ScienceCategory[] scienceCategoryList;
        //public string name;



        public int AddSubCategory()
        {
            return DBManager.singleton().AddSubCategory(this);
        }

        public void DeleteSubCategory(int SubCategoryID)
        {
            DBManager.singleton().DeleteSubCategory(SubCategoryID);
        }

        public void UpdateSubCategory( )
        {
            DBManager.singleton().UpdateSubCategory(this);
        }

    }
}
