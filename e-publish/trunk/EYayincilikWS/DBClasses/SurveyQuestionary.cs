using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class SurveyQuestionary
    {
       // public int id;
       // public string question;
       // public string answer;



        public int AddSurveyQuestionary(int MagazineID)
        {
            return DBManager.singleton().AddSurveyQuestionary(this, MagazineID);
        }

        public void DeleteSurveyQuestionary(int SurveyQuestionaryID)
        {
            DBManager.singleton().DeleteSurveyQuestionary(SurveyQuestionaryID);
        }

        public void UpdateSurveyQuestionary( )
        {
            DBManager.singleton().UpdateSurveyQuestionary(this);
        }

    }
}
