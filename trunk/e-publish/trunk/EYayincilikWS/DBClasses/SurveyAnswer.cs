using System;
using System.Collections.Generic;
using System.Text;

namespace BSClass
{
    public partial class SurveyAnswer
    {
        //public int id;
        //public int surveyQuestionaryid;
        //public string answer;
        //public int PaperRef;



        public int AddSurveyAnswer()
        {
            return DBManager.singleton().AddSurveyAnswer(this);
        }

        public void DeleteSurveyAnswer(int SurveyAnswerID)
        {
            DBManager.singleton().DeleteSurveyAnswer(SurveyAnswerID);
        }

        public void UpdateSurveyAnswer()
        {
            DBManager.singleton().UpdateSurveyAnswer(this);
        }

    }
}
