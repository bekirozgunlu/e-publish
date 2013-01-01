using System;
using System.Collections.Generic;
using System.Text;


namespace EYayincilikPortal
{

    public class Manager
    {

        //private static Manager p_singleton;
        private static SVC1.Service1 svc = new SVC1.Service1();

        //private Manager() 
        //{
        //    //sdsf
        //    SVC1.Service1 svc = new SVC1.Service1();  //initializes web service...
        //}

        //public static Manager singleton()
        //{
        //    if (p_singleton == null)
        //        p_singleton = new Manager();
        //    return p_singleton;
        //}


        
        public SVC1.User GetUserByID(int userID)
        {

            try
            {
                SVC1.Service1 svc = new SVC1.Service1(); 
                SVC1.User u = svc.GetUserByID(userID);
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

        
        public int AddMagazine(SVC1.Magazine m)
        {
            try
            {
                int newID = svc.AddMagazine(m);
                return newID;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return 0  ;
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
                svc.DeleteMagazine(magazineID);
                return ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return ;
            }
            finally
            {
                //dispose unused objects...
            }
        }

        
        public void UpdateMagazine(SVC1.Magazine m)
        {
            //Update Magazine Object in DB 
            try
            {
                svc.UpdateMagazine(m);
                return ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return ;
            }
            finally
            {
                //dispose unused objects...
            }
        }


        
        public int AddSubCategory(SVC1.SubCategory s)
        {
            try
            {
                int newID = svc.AddSubCategory(s);
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
                svc.DeleteSubCategory(SubCategoryID);
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

        
        public void UpdateSubCategory(SVC1.SubCategory sc)
        {
            //updates a sub category content...
            try
            {
                svc.UpdateSubCategory(sc);
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

        
        public int AddReferee(SVC1.Referee r)
        {
            try
            {
                int newID = svc.AddReferee(r);
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
                svc.DeleteReferee(RefereeID);
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

        
        public void UpdateReferee(SVC1.Referee r)
        {
            //Updates a Referee Record with new values...
            try
            {
                svc.UpdateReferee(r);
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


        
        public int AddAuthor(SVC1.Author a)
        {
            try
            {
                int newID = svc.AddAuthor(a);
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
                svc.DeleteAuthor(AuthorID);
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

        
        public void UpdateAuthor(SVC1.Author a)
        {
            //Updates a Author Record with new values...
            try
            {
                svc.UpdateAuthor(a);
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

        
        public void ApproveSubCategory(SVC1.SubCategory sc)
        {
            try
            {
                svc.ApproveSubCategory(sc);
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

        
        public int AddScienceCategory(SVC1.ScienceCategory sc)
        {
            try
            {
                int newID = svc.AddScienceCategory(sc);
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

        
        public void DeleteScienceCategory(int ScienceCategoryID)
        {
            try
            {
                svc.DeleteScienceCategory(ScienceCategoryID);
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

        
        public void UpdateScienceCategory(SVC1.ScienceCategory sc)
        {
            //Updates a SVC1.ScienceCategory Record with new values...
            try
            {
                svc.UpdateScienceCategory(sc);
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


        
        public int AddPublisher(SVC1.Publisher pp)
        {
            try
            {
                int newID = svc.AddPublisher(pp);
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
            //makes a SVC1.Publisher record  passive...
            try
            {
                svc.DeletePublisher(PublisherID);
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

        
        public void UpdatePublisher(SVC1.Publisher pp)
        {
            //Updates a Publisher Record with new values...
            
            try
            {
                svc.UpdatePublisher(pp);
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

        
        public int AddPaper(SVC1.Paper p)
        {
            try
            {
                int newID = svc.AddPaper(p);
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
            //makes a SVC1.Publisher record  passive...
            try
            {
                svc.DeletePaper(PaperID);
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

        
        public void UpdatePaper(SVC1.Paper pp)
        {
            //Updates a Paper Record with new values...

            try
            {
                svc.UpdatePaper(pp);
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
                svc.BackUpDB();
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



        
        public void ExaminePaper(SVC1.Paper p, SVC1.Comment[] commentlist, int RefereeID, SVC1.Survey[] surveyList)
        {
            //Called when a referee Examines a paper and wants to save his/her inspections...


            try
            {
                svc.ExaminePaper(p,commentlist,RefereeID,surveyList);
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
                svc.SendOpinionToPublisher(PaperID,RefereeID,PublisherID);
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
                svc.SendPaperToReferee(PaperID, RefereeID, PublisherID);
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
                svc.SendPaperBackToWriter(PaperID, AuthorID, PublisherID);
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


        
        public void InviteReferee(SVC1.Referee passiveRefereeRecord, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author


            try
            {
                svc.InviteReferee(passiveRefereeRecord, PublisherID);
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

        
        public void AnswerSurvey(SVC1.SurveyAnswer[] sAnswers)
        {
            //Called when a referee answers a set of Question


            try
            {
                svc.AnswerSurvey(sAnswers);
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

        
        public int AddUser(SVC1.User u)
        {
            try
            {
                int newID = svc.AddUser(u);
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
                svc.DeleteUser(UserID);
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

        
        public void UpdateUser(SVC1.User u)
        {
            //Updates a SVC1.User Record with new values...

            try
            {
                svc.UpdateUser(u);
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



        
        public int AddAnonimUser(SVC1.AnonimUser u)
        {
            try
            {
                int newID = svc.AddAnonimUser(u);
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
                svc.DeleteAnonimUser(AnonimUserID);
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

        
        public void UpdateAnonimUser(SVC1.AnonimUser u)
        {
            //Updates a SVC1.AnonimUser Record with new values...

            try
            {
                svc.UpdateAnonimUser(u);
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
            //Activates  a SVC1.User Record 
            try
            {
                svc.ActivateUser(userID);
                return ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return ;
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
                svc.DeactivateUser(userID);
                return ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN NULL
                return ;
            }
            finally
            {
                //dispose unused objects...
            }
        }

        
        public int AddComment(SVC1.Comment c, int paperID)
        {
            try
            {
                int newID = svc.AddComment(c,paperID);
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
                svc.DeleteComment(CommentID);
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

        
        public void UpdateComment(SVC1.Comment c)
        {
            //Updates a SVC1.Comment Record with new values...
            try
            {
                svc.UpdateComment(c);
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
            //Updates a SVC1.Comment Record with new values...
            try
            {
                svc.ApproveComment(CommentID);
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

        
        public int AddPaperToMagazine(SVC1.Paper p, int MagazineID)
        {
            try
            {
                svc.AddPaperToMagazine(p,MagazineID);
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
                svc.PublishMagazine(MagazineID);
                return ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return ;
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
                string s =svc.CreatePublishedPaperID();
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

        
        public int AddSurvey(SVC1.Survey s, int MagazineID)
        {
            try
            {
                int newID = svc.AddSurvey(s, MagazineID);
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
                svc.DeleteSurvey(SurveyID);
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

        
        public void UpdateSurvey(SVC1.Survey s)
        {
            //Updates a Survey Record with new values...
        }


        public int AddSurveyQuestionary(SVC1.SurveyQuestionary sq, int SurveyRef)
        {
            try
            {
                int newID = svc.AddSurveyQuestionary(sq, SurveyRef);
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
            //makes a SVC1.SurveyQuestionary record  passive...

            try
            {
                svc.DeleteSurveyQuestionary(SurveyQuestionaryID);
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

        
        public void UpdateSurveyQuestionary(SVC1.SurveyQuestionary s)
        {
            //Updates a SVC1.SurveyQuestionary Record with new values...
        }
        
        public int AddPublishedMagazine(SVC1.PublishedMagazine pm, int MagazineID)
        {
            try
            {
                int newID = svc.AddPublishedMagazine(pm, MagazineID);
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
                svc.DeletePublishedMagazine(PublishedMagazineID);
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

        
        public void UpdatePublishedMagazine(SVC1.PublishedMagazine pm)
        {
           
            try
            {
                svc.UpdatePublishedMagazine(pm);
                return ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return ;
            }
            finally
            {
                //dispose unused objects...
            }
        }



        //YENI2
        //GET METHODS...
        
        public SVC1.Author[] GetAuthorList(string AuthorIDList, string MagazineIDList, string PaperIDList, string PublishedMagazineIDList)
        {
           
            try
            {
                return svc.GetAuthorList(AuthorIDList, MagazineIDList, PaperIDList, PublishedMagazineIDList);
                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //LOG ERROR
                //RETURN 
                return null ;
            }
            finally
            {
                //dispose unused objects...
            }
        }

        
        public SVC1.User[] GetUserList(string UserIDlist, bool onlyActiveRecords, DateTime minActivationDate)
        {
           
            try
            {
                return svc.GetUserList(UserIDlist, onlyActiveRecords, minActivationDate);

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

        
        public SVC1.SystemAdmin[] GetSystemAdminList(string SystemAdminIDList, bool onlyActiveRecords, DateTime minActivationDate)
        {
           
            try
            {
                return svc.GetSystemAdminList(SystemAdminIDList, onlyActiveRecords, minActivationDate);

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

        
        public SVC1.Referee[] GetRefereeList(string RefereeIDList, bool onlyActiveRecords, string MagazineIDList, string PublishedMagazineList)
        {
           
            try
            {
                return svc.GetRefereeList(RefereeIDList, onlyActiveRecords, MagazineIDList, PublishedMagazineList);

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

        
        public SVC1.Moderator[] GetModeratorList(string ModeratorIDList, bool onlyActiveRecords)
        {
           
            try
            {
                return svc.GetModeratorList(ModeratorIDList, onlyActiveRecords);

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

        
        public SVC1.Magazine[] GetMagazineList(string MagazineIDList, bool onlyActiveRecords)
        {
           
            try
            {
                return svc.GetMagazineList(MagazineIDList, onlyActiveRecords);

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


        
        public SVC1.PublishedMagazine[] GetPublisheMagazineList(string MagazineIDList, string PublishedMagazineIDList, bool onlyActiveRecords)
        {
           
            try
            {
                return svc.GetPublisheMagazineList(MagazineIDList, PublishedMagazineIDList, onlyActiveRecords);

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


        
        public SVC1.Comment[] GetCommentList(string PaperIDList, int RefereeID, bool onlyActiveRecords)
        {
          
            try
            {
                return svc.GetCommentList(PaperIDList, RefereeID, onlyActiveRecords);

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

        
        public SVC1.Paper[] GetPaperList(string PublishedMagazineIDList,string MagazineIDList, string PaperIDList, int RefereeID, int PublisherID, int AuthorID, string category, string SubCategoryIDlist, bool onlyActiveRecords)
        {
            
            try
            {
                return svc.GetPaperList(PublishedMagazineIDList, MagazineIDList, PaperIDList, RefereeID, PublisherID,AuthorID, category, SubCategoryIDlist, onlyActiveRecords);

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

        
        public SVC1.ScienceCategory[] ScienceCategoryList(bool onlyActiveRecords,int SubCAtegoryID)
        {
            try
            {
                return svc.GetScienceCategoryList(onlyActiveRecords, SubCAtegoryID);

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


        public SVC1.SubCategory[] GetSubCategoryList(bool onlyActiveRecords, string scienceCAtegorylist,int MagazineID)
        {
            try
            {
                return svc.GetSubCategoryList(onlyActiveRecords,scienceCAtegorylist,MagazineID);

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



        /*
        public SVC1.Survey[] GetSurveyList(bool onlyActiveRecords, int MagazineID)
        {
            try
            {
                //return svc.GetSurveyList(onlyActiveRecords, MagazineID);

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
         * */


        
        public SVC1.SurveyQuestionary[] GetSurveyQuestionaryList(bool onlyActiveRecords, int MagazineID, int SurveyID)
        {
            try
            {
                return svc.GetSSurveyQuestionaryList(onlyActiveRecords, MagazineID, SurveyID);

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

    }
}
