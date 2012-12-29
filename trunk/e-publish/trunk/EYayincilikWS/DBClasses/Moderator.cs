using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Moderator 
    {
        public int AddModerator()
        {
            return DBManager.singleton().AddModerator(this);
        }

        public void DeleteModerator(int ModeratorID)
        {
            DBManager.singleton().DeleteModerator(ModeratorID);
        }

        public void UpdateModerator()
        {
            DBManager.singleton().UpdateModerator(this);
        }


        public void ActivateUser(int pUserID) 
        {
            DBManager.singleton().ActivateUser(pUserID);
        }

        public void DeActivateUser(int pUserID)
        {
            DBManager.singleton().DeactivateUser(pUserID);
        }


        public void ApproveComment(int CommentID)
        {
            DBManager.singleton().ApproveComment(CommentID);
        }

        public void DeleteComment(int CommentID)
        {
            DBManager.singleton().ApproveComment(CommentID);
        }
    }
}
