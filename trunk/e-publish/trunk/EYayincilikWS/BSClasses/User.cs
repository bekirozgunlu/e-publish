using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class User : AnonimUser
    {
        public int userID;
        public string userName;
        public string passWord;
        public string name;
        public string surName;
        public int isActive;
        public string photoFilePath;
        public int []userType;


        public string isActiveText
        {
            get
            {
                //1 Aktif ,2 pasif
                if (isActive == 1) return "Aktif";
                else return "Pasif";                
             
            }
            set
            {

            }
        }


    }
}
