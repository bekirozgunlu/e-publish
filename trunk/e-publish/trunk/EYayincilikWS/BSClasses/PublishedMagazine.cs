using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class PublishedMagazine
    {
        public int id;
        public int MagazinePublishState; //
        public string MagazinePublishNo; //2012/3 , 2012/5 vs.
        public DateTime PublishDate;
        public Magazine mgzn;
        public Paper[] paperList;
        public int paperCount;
        public int isActive;
        public int MagazineRef;

        /*
        void AddPaperToMagazine(Paper p) 
        {                        
            Manager.singleton().AddPaperToMagazine(p);     //       
        }
         */ 

        /*
        void AddPaperToMagazine(Paper p)
        {
            Manager.singleton().AddPaperToMagazine(p);
        }
        */


    }
}
