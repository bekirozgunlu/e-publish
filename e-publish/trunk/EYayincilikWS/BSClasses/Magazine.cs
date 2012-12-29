using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Magazine
    {
        public int publisherId;
        public int id;
        public string name;
        public SubCategory[] subCategories;
        public PublishedMagazine[] publishedMagazines;
        public Paper [] ApprovedPaperList;
        public int maxPaperCount;
    }
}
