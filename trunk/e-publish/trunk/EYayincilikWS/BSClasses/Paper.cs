using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Paper
    {
        public int id;
        public int authorId;
        public SubCategory[] subCategories;
        public int approvalState;
        public string contentPath;      //keeps pdf path
        public DateTime approvalDate;
        public Referee[] referees;
        public string [] referencePaperID;   
        public string publishedId;
        public double version;
        public Survey survey;
        public string title;
        public string publisherComment;
        public Comment[] comments;
        public int MagazineID ;
        public int PublishedMagazineID;
        public int isActive ;
    }
}
