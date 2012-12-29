using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class SystemAdmin 
    {

        public int AddSystemAdmin()
        {
            return DBManager.singleton().AddSystemAdmin(this);
        }

        public void DeleteSystemAdmin(int SystemAdminID)
        {
            DBManager.singleton().DeleteSystemAdmin(SystemAdminID);
        }

        public void UpdateSystemAdmin( )
        {
            DBManager.singleton().UpdateSystemAdmin(this);
        }

        public void Backup() 
        {
            DBManager.singleton().BackUpDB();
        }
    }
}
