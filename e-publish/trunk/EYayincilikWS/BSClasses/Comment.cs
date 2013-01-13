using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Comment
    {
        public int id;
        public int commentType;
        public string content;
        public int paperId;
        public int userId;
        public int approvalState;

        public string ApprovalStateText
        {
            get
            {
                //1 Onay bekliyor , 2:Onaylandı ; 3:Onaylanmadı
                if (approvalState == 1) return "Onay Bekliyor";
                if (approvalState == 2) return "Onaylandı";
                if (approvalState == 3) return "Onaylanmadı";
                return " ";       
                }
            set {

                if (value == "Onay Bekliyor") approvalState = 1;
                if (value == "Onaylandı") approvalState = 2;
                if (value == "Onaylanmadı") approvalState = 3;

                }
        }


        

        public DateTime commentDate;             
         
         
    }
}
