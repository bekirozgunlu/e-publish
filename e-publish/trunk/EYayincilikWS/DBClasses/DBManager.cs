using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using System.Data ; 
using System.Data.SqlClient  ;


namespace BSClass
{

    public partial class DBManager
    {

        private static DBManager p_singleton;
        private static SqlConnection sc;

        private DBManager()
        {

        }
        public static DBManager singleton()
        {
            if (p_singleton == null)
            {
                p_singleton = new DBManager();
                sc = new SqlConnection();
                sc.ConnectionString = WebConfigurationManager.ConnectionStrings["Portal"].ToString();
            }

            
            return p_singleton;
        }





        public BSClass.User GetUserByID(int userID)
        {

            try
            {
                string sSQL = "Select * from PortalUser where ID="+userID.ToString();
                sc.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt=new DataTable();
                sda.Fill(dt);
                sc.Close();

                BSClass.User u = new BSClass.User(); ;

                if (dt.Rows.Count > 0)
                {
                    u.userID = System.Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    u.userName = dt.Rows[0]["userName"].ToString();
                }
                else
                {
                    u = null;

                }
                return u;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddMagazine(BSClass.Magazine m)
        {
            try
            {
                int newID = 0;
                string sSQL = "";
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public void DeleteMagazine(int magazineID)
        {
            try
            {
                
                string sSQL = "";
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateMagazine(BSClass.Magazine m)
        {
            //Update Magazine Object in DB 
            try
            {
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public int AddSubCategory(BSClass.SubCategory s)
        {
            try
            {
                int newID = 0;
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteSubCategory(int SubCategoryID)
        {
            try
            {
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateSubCategory(BSClass.SubCategory sc)
        {
            //updates a sub category content...
            try
            {
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddReferee(BSClass.Referee r)
        {
            try
            {
                int newID = 0;
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteReferee(int RefereeID)
        {
            try
            {
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateReferee(BSClass.Referee r)
        {
            //Updates a Referee Record with new values...
            try
            {
               
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public int AddAuthor(BSClass.Author a)
        {
            try
            {
                int newID = 0;
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteAuthor(int AuthorID)
        {
            try
            {
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateAuthor(BSClass.Author a)
        {
            //Updates a Author Record with new values...
            try
            {
              
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void ApproveSubCategory(BSClass.SubCategory sc)
        {
            try
            {
               
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddScienceCategory(BSClass.ScienceCategory sc)
        {
            try
            {
                
                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteScienceCategory(int ScienceCategoryID)
        {
            try
            {
                
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateScienceCategory(BSClass.ScienceCategory sc)
        {
            //Updates a BSClass.ScienceCategory Record with new values...
            try
            {
               
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public int AddPublisher(BSClass.Publisher pp)
        {
            try
            {
                int newID = 0 ;               //AddPublisher(pp);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeletePublisher(int PublisherID)
        {
            //makes a BSClass.Publisher record  passive...
            try
            {
                //DeletePublisher(PublisherID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdatePublisher(BSClass.Publisher pp)
        {
            //Updates a Publisher Record with new values...

            try
            {
                //UpdatePublisher(pp);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddPaper(BSClass.Paper p)
        {
            try
            {
                int newID = 0 ;               //AddPaper(p);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeletePaper(int PaperID)
        {
            //makes a BSClass.Publisher record  passive...
            try
            {
                //DeletePaper(PaperID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdatePaper(BSClass.Paper pp)
        {
            //Updates a Paper Record with new values...

            try
            {
                //UpdatePaper(pp);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }

        }


        public void BackUpDB()
        {
            //Gets a DB BACKUP and saves Backup to file System...


            try
            {
                //BackUpDB();
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }

        }




        public void ExaminePaper(BSClass.Paper p, BSClass.Comment[] commentlist, int RefereeID, BSClass.Survey[] surveyList)
        {
            //Called when a referee Examines a paper and wants to save his/her inspections...


            try
            {
                //ExaminePaper(p, commentlist, RefereeID, surveyList);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }

        }


        public void SendOpinionToPublisher(int PaperID, int RefereeID, int PublisherID)
        {
            //Called when a referee Wants to send his/her opinion to a a publisher...

            try
            {
                //SendOpinionToPublisher(PaperID, RefereeID, PublisherID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }

        }


        public void SendPaperToReferee(int PaperID, int RefereeID, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a a referee

            try
            {
                //SendPaperToReferee(PaperID, RefereeID, PublisherID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void SendPaperBackToWriter(int PaperID, int AuthorID, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author


            try
            {
                //SendPaperBackToWriter(PaperID, AuthorID, PublisherID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public void InviteReferee(BSClass.Referee passiveRefereeRecord, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author


            try
            {
                //InviteReferee(passiveRefereeRecord, PublisherID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void AnswerSurvey(int SurveyID, BSClass.SurveyQuestionary[] sAnswers)
        {
            //Called when a referee answers a set of Question


            try
            {
                //AnswerSurvey(SurveyID, sAnswers);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddUser(BSClass.User u)
        {
            try
            {
                int newID = 0 ;               //AddUser(u);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteUser(int UserID)
        {
            try
            {
                //DeleteUser(UserID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateUser(BSClass.User u)
        {
            //Updates a BSClass.User Record with new values...

            try
            {
                //UpdateUser(u);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }




        public int AddAnonimUser(BSClass.AnonimUser u)
        {
            try
            {
                int newID = 0 ;               //AddAnonimUser(u);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteAnonimUser(int AnonimUserID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                //DeleteAnonimUser(AnonimUserID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateAnonimUser(BSClass.AnonimUser u)
        {
            //Updates a BSClass.AnonimUser Record with new values...

            try
            {
                //UpdateAnonimUser(u);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public void ActivateUser(int userID)
        {
            //Activates  a BSClass.User Record 
            try
            {
                //ActivateUser(userID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public void DeactivateUser(int userID)
        {
            try
            {
                //DeactivateUser(userID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddComment(BSClass.Comment c, int paperID)
        {
            try
            {
                int newID = 0 ;               //AddComment(c, paperID);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteComment(int CommentID)
        {
            //makes a Comment record  passive...

            try
            {
                //DeleteComment(CommentID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateComment(BSClass.Comment c)
        {
            //Updates a BSClass.Comment Record with new values...
            try
            {
                //UpdateComment(c);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void ApproveComment(int CommentID)
        {
            //Updates a BSClass.Comment Record with new values...
            try
            {
                //ApproveComment(CommentID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddPaperToMagazine(BSClass.Paper p, int MagazineID)
        {
            try
            {
                //AddPaperToMagazine(p, MagazineID);
                return 0;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void PublishMagazine(int MagazineID)
        {
            //Pubslihes a agazine..

            try
            {
                //PublishMagazine(MagazineID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public string CreatePublishedPaperID()
        {
            try
            {
                string s = " todo" ;CreatePublishedPaperID();
                return s;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return "";
            }
            finally
            {
                //dispose unused objects...
            }
        }

        //YENI


        public int AddSurvey(BSClass.Survey s, int MagazineID)
        {
            try
            {
                int newID = 0 ;               //AddSurvey(s, MagazineID);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteSurvey(int SurveyID)
        {
            //makes a .Survey record  passive...

            try
            {
                //DeleteSurvey(SurveyID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }

        }


        public void UpdateSurvey(BSClass.Survey s)
        {
            //Updates a Survey Record with new values...
        }


        public int AddSurveyQuestionary(BSClass.SurveyQuestionary sq, int MagazineID)
        {
            try
            {
                int newID = 0 ;               //AddSurveyQuestionary(sq, MagazineID);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteSurveyQuestionary(int SurveyQuestionaryID)
        {
            //makes a BSClass.SurveyQuestionary record  passive...

            try
            {
                //DeleteSurveyQuestionary(SurveyQuestionaryID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateSurveyQuestionary(BSClass.SurveyQuestionary s)
        {
            //Updates a BSClass.SurveyQuestionary Record with new values...
        }

        public int AddPublishedMagazine(BSClass.PublishedMagazine pm, int MagazineID)
        {
            try
            {
                int newID = 0 ;               //AddPublishedMagazine(pm, MagazineID);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeletePublishedMagazine(int PublishedMagazineID)
        {
            //makes a PublishedMagazine record  passive...

            try
            {
                //DeletePublishedMagazine(PublishedMagazineID);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdatePublishedMagazine(BSClass.PublishedMagazine pm)
        {

            try
            {
                //UpdatePublishedMagazine(pm);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        //YENI2
        //GET METHODS...

        public BSClass.Author[] GetAuthorList(string AuthorIDList, string MagazineIDList, string PaperIDList, string PublishedMagazineIDList)
        {

            try
            {

                Author a1 = new Author();
                Author a2 = new Author();
                List<Author> tList = new List<Author>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray(); 

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.User[] GetUserList(string UserIDlist, bool onlyActiveRecords, DateTime minActivationDate)
        {

            try
            {
                User a1 = new User();
                User a2 = new User();
                List<User> tList = new List<User>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.SystemAdmin[] GetSystemAdminList(string SystemAdminIDList, bool onlyActiveRecords, DateTime minActivationDate)
        {

            try
            {
                SystemAdmin a1 = new SystemAdmin();
                SystemAdmin a2 = new SystemAdmin();
                List<SystemAdmin> tList = new List<SystemAdmin>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray(); ; //GetSystemAdminList(SystemAdminIDList, onlyActiveRecords, minActivationDate);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.Referee[] GetRefereeList(string RefereeIDList, bool onlyActiveRecords, string MagazineIDList, string PublishedMagazineList)
        {

            try
            {
                Referee a1 = new Referee();
                Referee a2 = new Referee();
                List<Referee> tList = new List<Referee>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray(); ; //GetSystemAdminList(SystemAdminIDList, onlyActiveRecords, minActivationDate);   ; //GetRefereeList(RefereeIDList, onlyActiveRecords, MagazineIDList, PublishedMagazineList);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.Moderator[] GetModeratorList(string ModeratorIDList, bool onlyActiveRecords)
        {

            try
            {
                Moderator a1 = new Moderator();
                Moderator a2 = new Moderator();
                List<Moderator> tList = new List<Moderator>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray(); 

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.Magazine[] GetMagazineList(string MagazineIDList, bool onlyActiveRecords)
        {
             List<Magazine> tList = new List<Magazine>();
            try
            {
                string sSQL = @"SELECT Magazine.ID,PublisherUserRef,Magazine.name,Magazine.createDate,Magazine.modifiedDate,
		                    maxPaperCount,UPPER(PortalUser.name+' '+PortalUser.surName) as EditorAdi
                            FROM Magazine
                            inner join PortalUser on PortalUser.ID=Magazine.PublisherUserRef "  ;


                sc.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sc.Close();

              

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows) 
                    {
                        Magazine m = new Magazine();
                        m.id = Convert.ToInt32(  dr["ID"].ToString());
                        m.name = dr["name"].ToString();                        
                        tList.Add(m);
                    }
                }
                
                return tList.ToArray(); 

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public BSClass.PublishedMagazine[] GetPublisheMagazineList(string MagazineIDList, string PublishedMagazineIDList, bool onlyActiveRecords)
        {

            try
            {
                PublishedMagazine a1 = new PublishedMagazine();
                PublishedMagazine a2 = new PublishedMagazine();
                List<PublishedMagazine> tList = new List<PublishedMagazine>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();
                

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public BSClass.Comment[] GetCommentList(string MagazineIDList, string PaperIDList, int RefereeID, bool onlyActiveRecords)
        {

            try
            {
                Comment a1 = new Comment();
                Comment a2 = new Comment();
                List<Comment> tList = new List<Comment>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.Paper[] GetPaperList(string MagazineIDList, string PaperIDList, int RefereeID, int PublisherID, int AuthorID, string category, string SubCategoryIDlist, bool onlyActiveRecords)
        {

            try
            {
                Paper a1 = new Paper();
                Paper a2 = new Paper();
                List<Paper> tList = new List<Paper>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.ScienceCategory[] ScienceCategoryList(bool onlyActiveRecords)
        {
            try
            {
                ScienceCategory a1 = new ScienceCategory();
                ScienceCategory a2 = new ScienceCategory();
                List<ScienceCategory> tList = new List<ScienceCategory>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public BSClass.SubCategory[] GetSubCategoryList(bool onlyActiveRecords)
        {
            try
            {
                SubCategory a1 = new SubCategory();
                SubCategory a2 = new SubCategory();
                List<SubCategory> tList = new List<SubCategory>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }




        public BSClass.SurveyQuestionary[] GetSurveyQuestionaryList(bool onlyActiveRecords, int MagazineID, int SurveyID)
        {
            try
            {

                BSClass.SurveyQuestionary a1 = new SurveyQuestionary();
                BSClass.SurveyQuestionary a2 = new SurveyQuestionary();
                List<SurveyQuestionary> tList = new List<SurveyQuestionary>();
                tList.Add(a1);
                tList.Add(a2);
                return tList.ToArray();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public int AddModerator(BSClass.Moderator m)
        {
            try
            {
                int newID = 0;               //Moderator(u);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteModerator(int ModeratorID)
        {
            //makes a Moderator record  passive...
            try
            {
                //Moderator(Moderator);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateModerator(BSClass.Moderator m)
        {
            //Updates a BSClass.AnonimUser Record with new values...

            try
            {
                //UpdateAnonimUser(u);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        //////////////////////////////////////////////////////////as


        public int AddSystemAdmin(BSClass.SystemAdmin sa)
        {
            try
            {
                int newID = 0;               //SystemAdmin(u);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void DeleteSystemAdmin(int SystemAdminID)
        {
            //makes a SystemAdmin record  passive...
            try
            {
                //SystemAdmin(SystemAdmin);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        public void UpdateSystemAdmin(BSClass.SystemAdmin sa)
        {
            //Updates a BSClass.AnonimUser Record with new values...

            try
            {
                //UpdateAnonimUser(u);
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        public void SubCategoryRequest(SubCategory sc,User u) 
        {
            try
            {
                //string ssql = "insert into subcategory ... values () ";
                return;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
               
                return;
            }
            finally
            {
                
            }

        }

        public void AddPaperByAuthor(int userID, Paper p)
        {
            //
        }

    }
}