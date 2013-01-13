using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using BSClass;

namespace EYayincilikWS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";            
        }

        [WebMethod]
        public User GetUserByID(int userID)
        {

            User u = new User();
            u.GetUserByID(userID);
            return u;
        }

        [WebMethod]
        public User CheckUserPass(string userName, string Password) 
        {
            //Verilen kullanıcı adı ve parola ile eslesen User kaydını getir...

            User[] Userlist = DBManager.singleton().GetUserList("", userName, Password, true, DateTime.Now);

            if (Userlist.GetLength(0) == 1)
                return Userlist[0];
            else
                return null;
        }

        [WebMethod]
        public int AddMagazine(Magazine m) 
        {
            //SAVE NEW MAGAZINE TO DB

            int newID = m.AddMagazine();            
            return newID;
        }
        

        [WebMethod]
        public void DeleteMagazine(int magazineID) 
        {
            //SET MAGAZINE STATUS TO PASSIVE 
            DBManager.singleton().DeleteMagazine(magazineID);
        }

        [WebMethod]
        public void UpdateMagazine(Magazine m)
        {
            
            
            //SET MAGAZINE STATUS TO WANTED 
        }


        [WebMethod]
        public int AddSubCategory(SubCategory s) 
        {
            //add news sub category
            int newID = s.AddSubCategory();
            return newID;

            
        }

        [WebMethod]
        public void DeleteSubCategory(int SubCategoryID)
        {
            //makes a sub category passive...
            DBManager.singleton().DeleteSubCategory(SubCategoryID);
        }

        [WebMethod]
        public void UpdateSubCategory(SubCategory ss)
        {
            //updates a sub category content...
        }

        [WebMethod]
        public  int AddReferee(Referee r)
        {
            //add  new Referee
            int newID = r.AddReferee();
            return newID;
        }

        [WebMethod]
        public void DeleteReferee(int RefereeID)
        {
            //makes a Referee record  passive...
            DBManager.singleton().DeleteReferee(RefereeID);
        }

        [WebMethod]
        public void UpdateReferee(Referee r)
        {
            //Updates a Referee Record with new values...
        }


        [WebMethod]
        public int AddAuthor(Author a)
        {
            //add  new Author
            int newID = a.AddAuthor();
            return newID;
        }

        [WebMethod]
        public void DeleteAuthor(int AuthorID)
        {
            //makes a Author record  passive...
            DBManager.singleton().DeleteAuthor(AuthorID);
        }

        [WebMethod]
        public void UpdateAuthor(Author a)
        {
            //Updates a Author Record with new values...
        }

        [WebMethod]
        public void ApproveSubCategory(SubCategory sc)
        {
            //Converts a sub category request to a Sub Category
        }

        [WebMethod]
        public int AddScienceCategory(ScienceCategory sc)
        {
            //adds a  new ScienceCategory
            int newID = sc.AddScienceCategory();
            return newID;
        }

        [WebMethod]
        public void DeleteScienceCategory(int ScienceCategoryID)
        {
            //makes a ScienceCategory record  passive..
              DBManager.singleton().DeleteScienceCategory(ScienceCategoryID);
        }

        [WebMethod]
        public void UpdateScienceCategory(ScienceCategory sc)
        {
            //Updates a ScienceCategory Record with new values...
        }


        [WebMethod]
        public int AddPublisher(Publisher pp)
        {
            //adds a  new Publisher
            int newID = pp.AddPublisher();
            return newID;
        }

        [WebMethod]
        public void DeletePublisher(int PublisherID)
        {
            //makes a Publisher record  passive...
            DBManager.singleton().DeletePublisher(PublisherID);
        }

        [WebMethod]
        public void UpdatePublisher(Publisher pp)
        {
            //Updates a Publisher Record with new values...
            DBManager.singleton().UpdatePublisher(pp);
        }


        [WebMethod]
        public int AddModerator(Moderator pp)
        {
            //adds a  new Moderator
            int newID = pp.AddModerator();
            return newID;
        }

        [WebMethod]
        public void DeleteModerator(int ModeratorID)
        {
            //makes a Moderator record  passive...
            DBManager.singleton().DeleteModerator(ModeratorID);
        }

        [WebMethod]
        public void UpdateModerator(Moderator pp)
        {
            //Updates a Moderator Record with new values...
            DBManager.singleton().UpdateModerator(pp);
        }

        [WebMethod]
        public int  AddPaper(Paper p)
        {
            //adds a  new Paper
            int newID = p.AddPaper();
            return newID;
        }

        [WebMethod]
        public void DeletePaper(int PaperID)
        {
            //makes a Paper record  passive...
            DBManager.singleton().DeletePaper(PaperID);
        }

        [WebMethod]
        public void UpdatePaper(Paper pp)
        {
            //Updates a Paper Record with new values...

        }

        [WebMethod]
        public void BackUpDB()
        {
            //Gets a DB BACKUP and saves Backup to file System...
        }



        [WebMethod]
        public void ExaminePaper(Paper p, Comment[] commentlist, int RefereeID, Survey[] surveyList)
        {
            //Called when a referee Examines a paper and wants to save his/her inspections...
        }

        [WebMethod]
        public void SendOpinionToPublisher(int PaperID, int RefereeID, int PublisherID)
        {
            //Called when a referee Wants to send his/her opinion to a a publisher...
        }

        [WebMethod]
        public void SendPaperToReferee(int PaperID, int RefereeID, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a a referee
        }

        [WebMethod]
        public void SendPaperBackToWriter(int PaperID, int AuthorID, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author
        }


        [WebMethod]
        public void InviteReferee(Referee passiveRefereeRecord, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author
        }

        [WebMethod]
        public void AnswerSurvey(SurveyAnswer [] sAnswers)
        {
            DBManager.singleton().AnswerSurvey( sAnswers);
        }

        [WebMethod]
        public int  AddUser(User u)
        {
            //adds a new User
            int newID = u.AddUser();
            return newID;
        }

        [WebMethod]
        public void DeleteUser(int UserID)
        {
            //makes a User record  passive...
            DBManager.singleton().DeleteUser(UserID);
        }

        [WebMethod]
        public void UpdateUser(User u)
        {
            //Updates a User Record with new values...
        }



        [WebMethod]
        public int AddAnonimUser(AnonimUser u)
        {
            //adds a new AnonimUser
            int newID = u.AddAnonimUser();
            return newID;
        }

        [WebMethod]
        public void DeleteAnonimUser(int AnonimUserID)
        {
            //makes a AnonimUser record  passive...
            DBManager.singleton().DeleteAnonimUser(AnonimUserID);
        }

        [WebMethod]
        public void UpdateAnonimUser(AnonimUser u)
        {
            //Updates a AnonimUser Record with new values...
        }


        [WebMethod]
        public void ActivateUser(int userID)
        {
            //Activates  a User Record 
            DBManager.singleton().ActivateUser(userID);
            return;
        }


        [WebMethod]
        public void DeactivateUser(int userID)
        {
            //Makes  a User Record passive
            DBManager.singleton().DeactivateUser(userID);
        }

        [WebMethod]
        public int  AddComment(Comment c, int paperID)
        {
            //adds a new Comment to a Paper
            int newID = c.AddComment(paperID);
            return newID;
        }

        [WebMethod]
        public void DeleteComment(int CommentID)
        {
            //makes a Comment record  passive...
            DBManager.singleton().DeleteComment(CommentID);
        }

        [WebMethod]
        public void UpdateComment(Comment c)
        {
            //Updates a Comment Record with new values...
        }

        [WebMethod]
        public void ApproveComment(int CommentID)
        {
            //Updates a Comment Record with new values...
            DBManager.singleton().ApproveComment(CommentID);
        }

        [WebMethod]
        public int  AddPaperToMagazine(Paper p, int MagazineID) 
        {
            //Adds a paper to a magazine..
            int newID = DBManager.singleton().AddPaperToMagazine(p, MagazineID);
            return newID;
        }

        [WebMethod]
        public void PublishMagazine(int MagazineID)
        {
            //Pubslihes a magazine
            DBManager.singleton().PublishMagazine(MagazineID);
        }

        [WebMethod]
        public string CreatePublishedPaperID() 
        {
            //creates a unique paper ID for published Papers..
            return "";
        }

        //YENI

        [WebMethod]
        public int AddSurvey(Survey s,int MagazineID)
        {
            //adds a new Survey for a Magazine
            int newID = s.AddSurvey(MagazineID);
            return newID;
        }

        [WebMethod]
        public void DeleteSurvey(int SurveyID)
        {
            //makes a Survey record  passive...
            DBManager.singleton().DeleteSurvey(SurveyID);
        }

        [WebMethod]
        public void UpdateSurvey(Survey s)
        {
            //Updates a Survey Record with new values...
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="MagazineID"></param>

        [WebMethod]
        public int  AddSurveyQuestionary(SurveyQuestionary sq, int SurveyRef)
        {
            //adds a new SurveyQuestionary for a Survey
            int newID = sq.AddSurveyQuestionary(SurveyRef);
            return newID;
        }

        [WebMethod]
        public void DeleteSurveyQuestionary(int SurveyQuestionaryID)
        {
            //makes a SurveyQuestionary record  passive...
            DBManager.singleton().DeleteSurveyQuestionary(SurveyQuestionaryID);
        }

        [WebMethod]
        public void UpdateSurveyQuestionary(SurveyQuestionary s)
        {
            //Updates a SurveyQuestionary Record with new values...
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sq"></param>
        /// <param name="MagazineID"></param>
        [WebMethod]
        public int AddPublishedMagazine(PublishedMagazine pm, int MagazineID)
        {
            //adds a new SurveyQuestionary for a PublishedMagazine
            int newID = pm.AddPublishedMagazine(MagazineID);
            return newID;
        }

        [WebMethod]
        public void DeletePublishedMagazine(int PublishedMagazineID)
        {
            //makes a PublishedMagazine record  passive...
            DBManager.singleton().DeletePublishedMagazine(PublishedMagazineID);
        }

        [WebMethod]
        public void UpdatePublishedMagazine(PublishedMagazine pm)
        {
            //Updates a PublishedMagazine Record with new values...
        }


        [WebMethod]
        public void AddPaperByAuthor(int userID, Paper p)
        {
            //BSClass.DBManager.singleton().AddPaperByAuthor(userID, p);
            DBManager.singleton().AddPaperByAuthor(userID, p);
            return;
        }

        //YENI2
        //GET METHODS...

        [WebMethod]
        public int[] GetUserTypes(int userID) 
        {
            return DBManager.singleton().GetUserTypes(userID);
        }

        [WebMethod]
        public Author[] GetAuthorList(string AuthorIDList, string MagazineIDList, string PaperIDList,string PublishedMagazineIDList) 
        {
            return  DBManager.singleton().GetAuthorList(AuthorIDList, PaperIDList);
        }

        [WebMethod]
        public User[] GetUserList(string UserIDlist, bool onlyActiveRecords, DateTime minActivationDate)
        {
            return DBManager.singleton().GetUserList(UserIDlist, "", "", onlyActiveRecords, DateTime.Now);
        }

        [WebMethod]
        public SystemAdmin[] GetSystemAdminList(string SystemAdminIDList, bool onlyActiveRecords, DateTime minActivationDate)
        {
            return DBManager.singleton().GetSystemAdminList(SystemAdminIDList, onlyActiveRecords, DateTime.Now);
        }

        [WebMethod]
        public Referee[] GetRefereeList(string RefereeIDList, bool onlyActiveRecords, string MagazineIDList, string PublishedMagazineList)
        {
            return DBManager.singleton().GetRefereeList(RefereeIDList, onlyActiveRecords, MagazineIDList, PublishedMagazineList);
        }

        [WebMethod]
        public Moderator[] GetModeratorList(string ModeratorIDList, bool onlyActiveRecords)
        {
            return DBManager.singleton().GetModeratorList(ModeratorIDList, onlyActiveRecords);
        }

        [WebMethod]
        public Magazine[] GetMagazineList(string MagazineIDList,int PublisherID, bool onlyActiveRecords)
        {
            return DBManager.singleton().GetMagazineList(MagazineIDList, PublisherID ,onlyActiveRecords);
        }


        [WebMethod]
        public PublishedMagazine[] GetPublisheMagazineList(string MagazineIDList, string PublishedMagazineIDList, bool onlyActiveRecords)
        {
            return DBManager.singleton().GetPublisheMagazineList(MagazineIDList, PublishedMagazineIDList,onlyActiveRecords);
        }


        [WebMethod]
        public Comment[] GetCommentList(string PaperIDList,int RefereeID, bool onlyActiveRecords)
        {
            return DBManager.singleton().GetCommentList(PaperIDList, RefereeID, onlyActiveRecords);
        }

        [WebMethod]
        public Paper[] GetPaperList(string PublishedMagazineIDList,string MagazineIDList, string PaperIDList, int RefereeID, int PublisherID, int AuthorID, string category, string subCategory, bool onlyActiveRecords)
        {
            return DBManager.singleton().GetPaperList(PublishedMagazineIDList, MagazineIDList, PaperIDList, RefereeID, PublisherID, AuthorID, category, subCategory, onlyActiveRecords);
        }

        [WebMethod]
        public ScienceCategory[] GetScienceCategoryList(bool onlyActiveRecords, int SubCategoryID, int MagazineID)
        {
            return DBManager.singleton().GetScienceCategoryList(onlyActiveRecords,SubCategoryID,MagazineID);
        }

        [WebMethod]
        public SubCategory[] GetSubCategoryList(bool onlyActiveRecords,string scienceCAtegorylist,int MagazineID)
        {
            return DBManager.singleton().GetSubCategoryList(onlyActiveRecords, scienceCAtegorylist, MagazineID);
        }


        /*
        [WebMethod]
        public Survey[] GetSurveyList(bool onlyActiveRecords,int MagazineID)
        {
            return DBManager.singleton().GetSurveyQuestionaryList(onlyActiveRecords, scienceCAtegorylist, MagazineID);
        }
         * */


        [WebMethod]
        public SurveyQuestionary[] GetSSurveyQuestionaryList(bool onlyActiveRecords, int MagazineID,int SurveyID)
        {
            return DBManager.singleton().GetSurveyQuestionaryList(onlyActiveRecords, MagazineID, SurveyID);
        }


         [WebMethod]
        public int AddSurveyAnswer(SurveyAnswer sa)
        {
            return sa.AddSurveyAnswer();
        }


         [WebMethod]
        public void DeleteSurveyAnswer(int SurveyAnswerID)
        {

            DBManager.singleton().DeleteSurveyAnswer(SurveyAnswerID);
        }

        public void UpdateSurveyAnswer(SurveyAnswer sa)
        {
            sa.UpdateSurveyAnswer() ;
        }


        [WebMethod]
        public void AddSubCategoryToScienceCategory(int SubCategoryId, int ScienceCategoryId)
        {
            DBManager.singleton().AddSubCategoryToScienceCategory(SubCategoryId, ScienceCategoryId);
        }

        [WebMethod]
        public void AddSubCategoryToMagazine(int SubCategoryId, int MagazineId)
        {
            DBManager.singleton().AddSubCategoryToMagazine(SubCategoryId, MagazineId);
        }

        [WebMethod]
        public Publisher[] GetPublisherList(string PublisherIDList, bool onlyActiveRecords)
        {
            return DBManager.singleton().GetPublisherList(PublisherIDList, onlyActiveRecords);
        }



    }
}