using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class Survey
    {
        //public int id;
        //public int magazineId;
        //public SurveyQuestionary[] surveyQuestionary;


        public int AddSurvey(int iMagazineID)
        {
            return DBManager.singleton().AddSurvey(this, iMagazineID);
        }

        public void DeleteSurvey(int SurveyID)
        {
            DBManager.singleton().DeleteSurvey(SurveyID);
        }

        public void UpdateSurvey()
        {
            DBManager.singleton().UpdateSurvey(this);            
        }


        public void AnswerSurvey(SurveyAnswer []surveyAnswerslist)
        {
            DBManager.singleton().AnswerSurvey(surveyAnswerslist);
        }

        public void AddQuestion(SurveyQuestionary sq)
        {
            DBManager.singleton().AddSurveyQuestionary(sq,this.magazineId);
        }

        public void DeleteQuestion(int SurveyQuestionaryID)
        {
            DBManager.singleton().DeleteSurveyQuestionary(SurveyQuestionaryID);
        }

        public void UpdateQuestion(SurveyQuestionary sq)
        {
            DBManager.singleton().UpdateSurveyQuestionary(sq);
        }


    }
}
