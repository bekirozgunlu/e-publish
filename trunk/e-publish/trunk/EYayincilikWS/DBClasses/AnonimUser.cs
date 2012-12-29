using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class AnonimUser
    {
        //public string sip;      // IP of loggined user

        public int AddAnonimUser() 
        {
            return DBManager.singleton().AddAnonimUser(this);
        }

        public void DeleteAnonimUser(int AnonimUserID) 
        {
            DBManager.singleton().DeleteAnonimUser(AnonimUserID);
        }

        public void UpdateAnonimUser() 
        {
            DBManager.singleton().UpdateAnonimUser(this);
        }

    }
}
