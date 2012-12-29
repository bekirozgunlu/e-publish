using System;
using System.Collections.Generic;
using System.Text;
using BSClass;

namespace BSClass
{
    public partial class User
    {
        //public int userID;
        //public string userName;
        //public string passWord;
        //public string name;
        //public string surName;
        //public bool isActive;
        //public string photoFilePath;
        //public int userType;
        
       

        void SubCategoryRequest(string CategoryName) 
        {
            //DBManager.singleton().re
        }

        public int AddUser()
        {
            return DBManager.singleton().AddUser(this);
        }

        public void DeleteUser(int UserID)
        {
            DBManager.singleton().DeleteUser(UserID);
        }

        public void UpdateUser()
        {
            DBManager.singleton().UpdateUser(this);
        }

        public void GetUserByID(int userID) 
        {
            User u = DBManager.singleton().GetUserByID(userID);
            this.userID = u.userID;
            this.userName = u.userName;
            this.userType = u.userType;
            this.surName = u.surName;          
            this.photoFilePath = u.photoFilePath;
            this.passWord = u.passWord;
            this.name = u.name;
            this.isActive = u.isActive;
        }


        public void SubCategoryRequest(SubCategory sc ) 
        {
            DBManager.singleton().SubCategoryRequest(sc, this);
        }



    }
}
