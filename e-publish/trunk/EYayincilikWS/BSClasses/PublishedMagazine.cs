using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class PublishedMagazine
    {
        public int id;
        public int MagazinePublishState; //
        public Magazine mgzn;
        public Paper[] paperList;
        public int paperCount;

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
