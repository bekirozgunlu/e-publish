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
        public DateTime commentDate;
    }
}
