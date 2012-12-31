using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class SubCategory
    {
        public int id;
        public ScienceCategory[] scienceCategoryList;
        public string name;
        public int isActive; //1 aktif,2 pasif
        public int approvalState; //1 Onay bekliyor , 2:Onaylandı ; 3:Onaylanmadı
    }
}
