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

        public string ApprovalStateText
        {
            get {


                //1:Yeni Yüklendi , 2:Editor Onayında,3:Hakem Onayında;4:Yazar Düzeltme ;5:Onaylı;

                //{ YeniYuklendi, Editor_Onayinda, Hakem_Onayinda, Yazar_Duzeltme, Hakem_Onayli, Editor_Onayli } ;

                if (approvalState == 0) return "Yeni Yüklendi";
                if (approvalState == 1) return "Editor Onayında";
                if (approvalState == 2) return "Hakem Onayında";
                if (approvalState == 3) return "Yazar Düzeltme";
                if (approvalState == 4) return "Hakem_Onayli";
                if (approvalState == 5) return "Onaylı";                
                return " ";       
            
                
            }
            set {

                //if (value=="Yeni Yüklendi") approvalState = 0;
                //else if (value=="Editor Onayında") approvalState = 1 ;
                //else if (value == "Hakem Onayında") approvalState = 2;
                //else if (value == "Yazar Düzeltme") approvalState = 3;
                //else if (value == "Onaylı") approvalState = 4;        

            }
        }
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
        public string MagazineName;
        public string AuthorName;

        public string publisherName;
 	    public DateTime uploadDate; 

        public int PublishedMagazineID;
        public int isActive ;
    }
}
