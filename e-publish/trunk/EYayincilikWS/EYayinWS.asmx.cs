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
            User u = new User();
            return u;
        }

        [WebMethod]
        public int AddMagazine(Magazine m) 
        {
            //SAVE NEW MAGAZINE TO DB

            

            int newID = 0;
            return newID;
        }
        

        [WebMethod]
        public void DeleteMagazine(int magazineID) 
        {
            //SET MAGAZINE STATUS TO PASSIVE 
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
            int newID = 0;
            return newID;

            
        }

        [WebMethod]
        public void DeleteSubCategory(int SubCategoryID)
        {
            //makes a sub category passive...
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
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteReferee(int RefereeID)
        {
            //makes a Referee record  passive...
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
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteAuthor(int AuthorID)
        {
            //makes a Author record  passive...
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
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteScienceCategory(int ScienceCategoryID)
        {
            //makes a ScienceCategory record  passive...
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
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeletePublisher(int PublisherID)
        {
            //makes a Publisher record  passive...
        }

        [WebMethod]
        public void UpdatePublisher(Publisher pp)
        {
            //Updates a ScienceCategory Record with new values...
        }

        [WebMethod]
        public int  AddPaper(Paper p)
        {
            //adds a  new Paper
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeletePaper(int PaperID)
        {
            //makes a Paper record  passive...
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
        public void AnswerSurvey(int SurveyID,SurveyQuestionary [] sAnswers)
        {
            //Called when a referee answers a set of Question
        }

        [WebMethod]
        public int  AddUser(User u)
        {
            //adds a new User
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteUser(int UserID)
        {
            //makes a User record  passive...
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
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteAnonimUser(int AnonimUserID)
        {
            //makes a AnonimUser record  passive...
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
            return;
        }


        [WebMethod]
        public void DeactivateUser(int userID)
        {
            //Makes  a User Record passive
        }

        [WebMethod]
        public int  AddComment(Comment c, int paperID)
        {
            //adds a new Comment to a Paper
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteComment(int CommentID)
        {
            //makes a Comment record  passive...
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
        }

        [WebMethod]
        public int  AddPaperToMagazine(Paper p, int MagazineID) 
        {
            //Adds a paper to a magazine..
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void PublishMagazine(int MagazineID)
        {
            //Pubslihes a magazine..
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
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteSurvey(int SurveyID)
        {
            //makes a Survey record  passive...
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
        public int  AddSurveyQuestionary(SurveyQuestionary sq, int MagazineID)
        {
            //adds a new SurveyQuestionary for a Survey
            int newID = 0;
            return newID;
        }

        [WebMethod]
        public void DeleteSurveyQuestionary(int SurveyQuestionaryID)
        {
            //makes a SurveyQuestionary record  passive...
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
            int newID =0;
            return newID;
        }

        [WebMethod]
        public void DeletePublishedMagazine(int PublishedMagazineID)
        {
            //makes a PublishedMagazine record  passive...
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
        }

        //YENI2
        //GET METHODS...
        [WebMethod]
        public Author[] GetAuthorList(string AuthorIDList, string MagazineIDList, string PaperIDList,string PublishedMagazineIDList) 
        {
            Author a1 = new Author();
            Author a2= new Author(); 
            List<Author> tList = new List<Author>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public User[] GetUserList(string UserIDlist, bool onlyActiveRecords, DateTime minActivationDate)
        {
            User a1 = new User();
            User a2 = new User();
            List<User> tList = new List<User>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public SystemAdmin[] GetSystemAdminList(string SystemAdminIDList, bool onlyActiveRecords, DateTime minActivationDate)
        {
            SystemAdmin a1 = new SystemAdmin();
            SystemAdmin a2 = new SystemAdmin();
            List<SystemAdmin> tList = new List<SystemAdmin>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public Referee[] GetRefereeList(string RefereeIDList, bool onlyActiveRecords, string MagazineIDList, string PublishedMagazineList)
        {
            Referee a1 = new Referee();
            Referee a2 = new Referee();
            List<Referee> tList = new List<Referee>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public Moderator[] GetModeratorList(string ModeratorIDList, bool onlyActiveRecords)
        {
            Moderator a1 = new Moderator ();
            Moderator a2 = new Moderator();
            List<Moderator> tList = new List<Moderator>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public Magazine[] GetMagazineList(string MagazineIDList, bool onlyActiveRecords)
        {
            Magazine a1 = new Magazine();
            Magazine a2 = new Magazine();
            List<Magazine> tList = new List<Magazine>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }


        [WebMethod]
        public PublishedMagazine[] GetPublisheMagazineList(string MagazineIDList, string PublishedMagazineIDList, bool onlyActiveRecords)
        {
            PublishedMagazine a1 = new PublishedMagazine();
            PublishedMagazine a2 = new PublishedMagazine();
            List<PublishedMagazine> tList = new List<PublishedMagazine>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }


        [WebMethod]
        public Comment[] GetCommentList(string MagazineIDList, string PaperIDList,int RefereeID, bool onlyActiveRecords)
        {
            Comment a1 = new Comment();
            Comment a2 = new Comment();
            List<Comment> tList = new List<Comment>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public Paper[] GetPaperList(string MagazineIDList,string PaperIDList, int RefereeID,int PublisherID,int AuthorID,string category,string subCategory, bool onlyActiveRecords)
        {
            Paper a1 = new Paper();            
            Paper a2 = new Paper();
            List<Paper> tList = new List<Paper>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public ScienceCategory[] ScienceCategoryList(bool onlyActiveRecords)
        {
            ScienceCategory a1 = new ScienceCategory();
            ScienceCategory a2 = new ScienceCategory();
            List<ScienceCategory> tList = new List<ScienceCategory>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }

        [WebMethod]
        public SubCategory[] SubCategoryList(bool onlyActiveRecords)
        {
            SubCategory a1 = new SubCategory();
            SubCategory a2 = new SubCategory();
            List<SubCategory> tList = new List<SubCategory>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }



        [WebMethod]
        public Survey[] GetSurveyList(bool onlyActiveRecords,int MagazineID)
        {
            Survey a1 = new Survey();            
            Survey a2 = new Survey();
            List<Survey> tList = new List<Survey>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }


        [WebMethod]
        public SurveyQuestionary[] GetSSurveyQuestionaryList(bool onlyActiveRecords, int MagazineID,int SurveyID)
        {
            SurveyQuestionary a1 = new SurveyQuestionary();
            SurveyQuestionary a2 = new SurveyQuestionary();
            List<SurveyQuestionary> tList = new List<SurveyQuestionary>();
            tList.Add(a1);
            tList.Add(a2);
            return tList.ToArray();
        }




    }
}