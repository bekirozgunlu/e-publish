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
                string sSQL = "Select PortalUser.* from PortalUser where ID=" + userID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt=new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                BSClass.User u = new BSClass.User(); ;

                if (dt.Rows.Count > 0)
                {
                   // u.userID = System.Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    //u.userName = dt.Rows[0]["userName"].ToString();
                    DataRow dr = dt.Rows[0];

                    u.userID = Convert.ToInt32(dr["ID"].ToString());
                    u.userName = dr["userName"].ToString();
                    u.isActive = Convert.ToInt32(dr["isActive"].ToString());
                    u.surName = dr["surName"].ToString();
                    u.name = dr["name"].ToString();

                    if (dr["photoFilePath"] != null)
                        u.photoFilePath = dr["photoFilePath"].ToString();
                    u.userType = this.GetUserTypes(u.userID);
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
                //if(sc.State==  ConnectionState.Open) if(sc.State==  ConnectionState.Open) {sc.Close();};
                //dispose unused objects...
            }
        }


        public int AddMagazine(BSClass.Magazine m)
        {
            try
            {
                int newID = 0;
                string sSQL = @"INSERT INTO [Magazine]
                        ([PublisherUserRef],[name],[maxPaperCount])
                        VALUES
                         ("+ 
                                m.publisherId.ToString() +","+
                                "'"+m.name+"'"+","+
                                m.maxPaperCount.ToString() +                                                               
                        ")" +

                        " Select @@IDENTITY " ;

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd= new SqlCommand(sSQL, sc);
                
                object o= scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};


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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
                //dispose unused objects...
            }
        }



        public void DeleteMagazine(int magazineID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                string ssQL = " Update magazine SET isActive=2 where ID=" + magazineID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
                //dispose unused objects...
            }
        }


        public void UpdateMagazine(BSClass.Magazine m)
        {
            //Update Magazine Object in DB 
            try
            {


                string sSQL = @"UPDATE [Magazine]
               SET [PublisherUserRef] = @p1
                  ,[name] = @p2      
                  ,[modifiedDate] = @p3
                  ,[maxPaperCount] = @p4
                  ,[isActive] = @p5
                WHERE ID=" + m.id.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = m.publisherId ;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = m.name;
                scmd.Parameters.Add("p3", SqlDbType.DateTime);
                scmd.Parameters[2].Value = DateTime.Now;
                scmd.Parameters.Add("p4", SqlDbType.Int);
                scmd.Parameters[3].Value = m.maxPaperCount;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = m.isActive;
                
                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
                //dispose unused objects...
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        public int AddSubCategory(BSClass.SubCategory s)
        {
            try
            {
                int newID = 0;
                
                string sSQL = @"INSERT INTO [SubCategory] ([name],isActive)
                              VALUES(" + "'"+s.name.Trim().ToString().ToUpper()+"'" + ", 1"+") "+
                        

                        " Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
                //dispose unused objects...
            }
        }


        public void DeleteSubCategory(int SubCategoryID)
        {
            try
            {
                string ssQL = " Update SubCategory SET isActive=2 where ID=" + SubCategoryID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


        public void UpdateSubCategory(BSClass.SubCategory scx)
        {
            //updates a sub category content...
            try
            {
                string sSQL = @"UPDATE [SubCategory]
                SET [name] =" + "'" + scx.name.ToString().Trim() + "'" +
                ",[approvalState] =" + scx.approvalState.ToString() +
                " ,[isActive] = " + scx.isActive.ToString() +
                " WHERE ID=" + scx.id.ToString();

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                scmd.ExecuteNonQuery();
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }

        public int AddSubCategorytoPaper(int sId, int PaperId)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [PaperSubCategory]([PaperRef] ,[SubCategoryRef])
                              VALUES (" + PaperId.ToString() + ", " + sId.ToString() + ")";

                if (sc.State == ConnectionState.Closed) { sc.Open(); }
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if (sc.State == ConnectionState.Open) { sc.Close(); };

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
                if (sc.State == ConnectionState.Open) { sc.Close(); };
                //dispose unused objects...
            }
        }

        public int AddReferencetoPaper(int rId, int PaperId)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [PaperReferencePaper]([MainPaperRef],[ReferancePaperRef])
                              VALUES(" + PaperId.ToString() + ", " + rId.ToString() + " )";

                if (sc.State == ConnectionState.Closed) { sc.Open(); }
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if (sc.State == ConnectionState.Open) { sc.Close(); };

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
                if (sc.State == ConnectionState.Open) { sc.Close(); };
                //dispose unused objects...
            }
        }

        public int AddReferee(BSClass.Referee r)
        {
            try
            {
               

                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath])
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6 )  ;
                
                 Select @@IDENTITY ";                

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = r.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = r.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = r.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = r.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = r.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";  //r.photoFilePath.ToString();

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};
                if(sc.State==  ConnectionState.Closed) {sc.Open();}

                
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + (Convert.ToInt32 (UserType.hakem)).ToString() + ") ";
                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteReferee(int RefereeID)
        {
            try
            {
                //DeleteUser(UserID);
                
                string ssQL = " Update PortalUSer SET isActive=2 where ID=" + RefereeID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


                string sSQL = @"
                UPDATE [PortalUser]
                   SET [userName] = @p1
                      ,[passWord] = @p2
                      ,[name] = @p3
                      ,[surName] = @p4
                      ,[isActive] = @p5
                      ,[photoFilePath] = @p6
                      ,[profession] = @p7,[resume] = @p8
                      ,[modifiedDate] = @p9
                 WHERE ID=" + r.userID.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = r.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = r.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = r.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = r.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = r.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";// r.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.VarChar);
                scmd.Parameters[6].Value = r.profession.ToString();
                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                scmd.Parameters[7].Value = r.resume.ToString();
                scmd.Parameters.Add("p9", SqlDbType.DateTime);
                scmd.Parameters[8].Value = DateTime.Now;

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        public int AddAuthor(BSClass.Author a)
        {
            try
            {


                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath],[profession],[resume])                
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8 )  ;
                 Select @@IDENTITY ";


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = a.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = a.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = a.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = a.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = a.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";// a.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.VarChar);

                if (a.profession != null)
                    scmd.Parameters[6].Value = a.profession.ToString();
                else
                    scmd.Parameters[6].Value = "";

                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                 if (a.resume != null)
                 {                   
                     scmd.Parameters[7].Value = a.resume ;
                 }
                 else
                     scmd.Parameters[7].Value = "" ;

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if(sc.State==  ConnectionState.Closed) {sc.Open();}

                
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + Convert.ToInt32 (UserType.yazar) + ") ";

                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteAuthor(int AuthorID)
        {
            try
            {
                string ssQL = " Update PortalUSer SET isActive=2 where ID=" + AuthorID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


                string sSQL = @"
                UPDATE [PortalUser]
                   SET [userName] = @p1
                      ,[passWord] = @p2
                      ,[name] = @p3
                      ,[surName] = @p4
                      ,[isActive] = @p5
                      ,[photoFilePath] = @p6
                      ,[profession] = @p7,[resume] = @p8
                      ,[modifiedDate] = @p9
                 WHERE ID=" + a.userID.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = a.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = a.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = a.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = a.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = a.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";// a.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.VarChar);
                scmd.Parameters[6].Value = a.profession;
                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                scmd.Parameters[7].Value = a.resume;
                scmd.Parameters.Add("p9", SqlDbType.DateTime);
                scmd.Parameters[8].Value = DateTime.Now;

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void ApproveSubCategory(BSClass.SubCategory scx)
        {
            try
            {                
                string sSQL = " UPDATE [SubCategory] SET [approvalState] = 2 " +//onayli
                " WHERE ID= "+scx.id.ToString();

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                object o = scmd.ExecuteNonQuery();

                return;
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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public int AddScienceCategory(BSClass.ScienceCategory scx)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [ScienceCategory]([name],isActive) 
                VALUES ("+ "'"+scx.name.ToUpper().Trim()+"'"+ ", 1"+ ")" +                
                " Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}

                SqlCommand scmd = new SqlCommand(sSQL, sc);
                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteScienceCategory(int ScienceCategoryID)
        {
            try
            {
                string ssQL = " Update ScienceCategory SET isActive=2 where ID=" + ScienceCategoryID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


        public void UpdateScienceCategory(BSClass.ScienceCategory scx)
        {
            //Updates a BSClass.ScienceCategory Record with new values...
            try
            {
                string sSQL = @"UPDATE [ScienceCategory]
                       SET [name] = @p1
                          ,[isActive] =@p2
                     WHERE ID=" + scx.id.ToString(); 
                    
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = scx.name.Trim();
                scmd.Parameters.Add("p2", SqlDbType.TinyInt);
                scmd.Parameters[1].Value = scx.isActive;                
                

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        public int AddPublisher(BSClass.Publisher pp)
        {
            try
            {


                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath],[profession],[resume])                
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8 )  ;
                 Select @@IDENTITY ";


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = pp.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = pp.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = pp.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = pp.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = pp.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";// pp.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.VarChar);
                scmd.Parameters[6].Value = pp.profession.ToString();
                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                scmd.Parameters[7].Value = pp.resume.ToString();

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + Convert.ToInt32 (UserType.editor) + ") ";

                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeletePublisher(int PublisherID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                string ssQL = " Update PortalUser SET isActive=2 where ID=" + PublisherID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();

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

               
                string sSQL = @"
                UPDATE [PortalUser]
                   SET [userName] = @p1
                      ,[passWord] = @p2
                      ,[name] = @p3
                      ,[surName] = @p4
                      ,[isActive] = @p5
                      ,[photoFilePath] = @p6
                      ,[profession] = @p7,[resume] = @p8
                      ,[modifiedDate] = @p9
                 WHERE ID=" + pp.userID.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = pp.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = pp.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = pp.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = pp.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = pp.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";//pp.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.VarChar);
                scmd.Parameters[6].Value = pp.profession.ToString();
                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                scmd.Parameters[7].Value = pp.resume.ToString();
                scmd.Parameters.Add("p9", SqlDbType.DateTime);
                scmd.Parameters[8].Value = DateTime.Now;

                scmd.ExecuteNonQuery();
                
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public int AddPaper(BSClass.Paper p)
        {

            try
            {


                int newID = 0;

                string sSQL = @"INSERT INTO [Paper]
                ([AuthorUserRef],[approvalState],[contentPath],[version],
                [isActive],[title],[MagazineRef],[uploadDate])
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ;



                 Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = p.authorId;

                scmd.Parameters.Add("p2", SqlDbType.TinyInt);
                scmd.Parameters[1].Value = ApprovalState.YeniYuklendi; //p.approvalState;

                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = p.contentPath;
                scmd.Parameters.Add("p4", SqlDbType.Decimal);
                scmd.Parameters[3].Value = p.version.ToString();
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = p.isActive;
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = p.title ;
                scmd.Parameters.Add("p7", SqlDbType.Int);
                scmd.Parameters[6].Value = p.MagazineID ;
                scmd.Parameters.Add("p8", SqlDbType.DateTime);
                scmd.Parameters[7].Value = DateTime.Now ;

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());


                if (p.subCategories.Length > 0) 
                {

                    foreach (SubCategory scxx in p.subCategories) 
                    {


                        if(sc.State==  ConnectionState.Open) {sc.Close();}
                        if(sc.State==  ConnectionState.Closed) {sc.Open();}

                        sSQL="INSERT INTO [PaperSubCategory]([PaperRef],[SubCategoryRef]) "+
                             " VALUES ("+newID.ToString()+","+scxx.id.ToString()  +") " ;


                        scmd.CommandText = sSQL;
                        scmd.ExecuteNonQuery();

                        if(sc.State==  ConnectionState.Open) {sc.Close();}


                    }


                }

               
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeletePaper(int PaperID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                string ssQL = " Update Paper SET isActive=2 where ID=" + PaperID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();

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


        public void UpdatePaper(BSClass.Paper p)
        {
            //Updates a Paper Record with new values...
            try
            {


                string sSQL = @"UPDATE [Paper]
                   SET 
                       [modifiedDate] = @p2                    
                      ,[approvalState] = @p4
                      ,[contentPath] = @p5
                      ,[approvalDate] = @p6
                      ,[publishedId] = @p7
                      ,[version] = @p8
                      ,[isActive] = @p9
                      ,[title] = @p10
                      ,[MagazineRef] = @p11
                      ,[PublishedMagazineRef] = @p12      
                      ,[publisherComment] = @p13
                 WHERE ID=" + p.id.ToString();

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);


                scmd.Parameters.Add("p2", SqlDbType.DateTime);
                scmd.Parameters[0].Value = DateTime.Now;
                scmd.Parameters.Add("p4", SqlDbType.Decimal);
                scmd.Parameters[1].Value = p.approvalState;
                scmd.Parameters.Add("p5", SqlDbType.VarChar);
                scmd.Parameters[2].Value = p.contentPath;
                scmd.Parameters.Add("p6", SqlDbType.DateTime);
                scmd.Parameters[3].Value = p.approvalDate;
                scmd.Parameters.Add("p7", SqlDbType.VarChar);
                scmd.Parameters[4].Value = p.publishedId;
                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                scmd.Parameters[5].Value = p.version;
                scmd.Parameters.Add("p9", SqlDbType.TinyInt);
                scmd.Parameters[6].Value = p.isActive;
                scmd.Parameters.Add("p10", SqlDbType.VarChar);
                scmd.Parameters[7].Value = p.title;
                scmd.Parameters.Add("p11", SqlDbType.Int);
                scmd.Parameters[8].Value = p.MagazineID;

                if ((p.PublishedMagazineID > 0) && (p.PublishedMagazineID > 0))
                {
                    scmd.Parameters.Add("p12", SqlDbType.Int);
                    scmd.Parameters[9].Value = p.PublishedMagazineID;
                }
                else 
                {
                    scmd.Parameters.Add("p12", SqlDbType.Int);
                    scmd.Parameters[10].Value = DBNull.Value;
                }

                scmd.Parameters.Add("p13", SqlDbType.VarChar);
                scmd.Parameters[10].Value = p.publisherComment;
                

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
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




        public void ExaminePaper(BSClass.Paper p, BSClass.Comment[] commentlist, int RefereeID, BSClass.SurveyAnswer[] AnswerList)
        {
            //Called when a referee Examines a paper and wants to save his/her inspections...


            try
            {
                foreach(Comment c in commentlist)
                {
                    this.AddComment(c, p.id);
                }

                foreach (SurveyAnswer  sa in AnswerList)
                {
                    this.AnswerSurvey(AnswerList);
                }

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
        public void SendOpinionToPublisher(int PaperID, int RefereeID, int isApproved)
        {
            //Called when a referee Wants to send his/her opinion to a a publisher...
            try
            {
                string sSQL = @"UPDATE [RefereePaper]
                   SET  isApproved= " + isApproved.ToString() + "," +
                   " sendBackDate=getdate() " +
                   " WHERE PaperRef=" + PaperID.ToString() +
                   " AND UserRefereeRef=" + RefereeID.ToString();


                if (sc.State == ConnectionState.Closed) { sc.Open(); }
                SqlCommand scmd = new SqlCommand(sSQL, sc);


                scmd.ExecuteNonQuery();

                if (sc.State == ConnectionState.Open) { sc.Close(); };


                sSQL = @"if (Select COUNT(ID) from RefereePaper 
                where RefereePaper.PaperRef="+PaperID.ToString()+ 
                " and RefereePaper.isApproved<>2  "+
                " ) <= 0 "+
                @"
                begin
	                Update Paper SET approvalState= "+ Convert.ToInt32 (ApprovalState.Hakem_Onayli.ToString()) +
                    " where ID=" + PaperID.ToString() +
                " end ";

                if (sc.State == ConnectionState.Closed) { sc.Open(); }
                scmd = null;
                scmd = new SqlCommand(sSQL, sc);
                scmd.ExecuteNonQuery();

                if (sc.State == ConnectionState.Open) { sc.Close(); };

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
                if (sc.State == ConnectionState.Open) { sc.Close(); };
            }

        }


        public void SendPaperToReferee(int PaperID, int RefereeID, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a a referee
            //Updates a BSClass.ScienceCategory Record with new values...
            try
            {
                string sSQL = @"INSERT INTO [RefereePaper]
                ([UserRefereeRef],[PaperRef],UserPublisherRef,isApproved)
                VALUES (@p1,@p2,@p3,1) " ;


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = RefereeID;
                scmd.Parameters.Add("p2", SqlDbType.Int);
                scmd.Parameters[1].Value = PaperID;
                scmd.Parameters.Add("p3", SqlDbType.Int);
                scmd.Parameters[2].Value = PublisherID;


                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};


                sSQL = @"Update Paper SET approvalState=" + ApprovalState.Hakem_Onayinda.ToString() +
                    " where ID=" + PaperID.ToString();                
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                scmd = null;
                scmd = new SqlCommand(sSQL, sc);
                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void SendPaperBackToWriter(int PaperID, int AuthorID, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author
            //Updates a Paper Record with new values...
            try
            {


                string sSQL = @"UPDATE [Paper]
                   SET [approvalState] = "+ApprovalState.Yazar_Duzeltme.ToString()+                                                                  
                   " WHERE ID=" + PaperID.ToString();

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);


                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        public void InviteReferee(Referee passiveRefereeRecord, int PublisherID)
        {
            //Called when a publisher  Wants to send a paper to a an author

            try
            {


                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath])
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6 )  ;
                
                 Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = passiveRefereeRecord.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = passiveRefereeRecord.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = passiveRefereeRecord.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = passiveRefereeRecord.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = 2; //pasif ;
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = "";// passiveRefereeRecord.photoFilePath.ToString();

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + Convert.ToInt32 (UserType.hakem) + ") ";

                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void AnswerSurvey(BSClass.SurveyAnswer[] sAnswers)
        {
            //Called when a referee answers a set of Question
            try
            {
                //AnswerSurvey(SurveyID, sAnswers);

                foreach (SurveyAnswer sa in sAnswers) 
                {
                    string sSQL = @"INSERT INTO [SurveyAnswer]
                       ([SurveyQuestionaryRef],[answer],[PaperRef])
                       VALUES (" +
                        sa.surveyQuestionaryid + "," +
                        "'" + sa.answer + "'" + "," +
                        sa.PaperRef
                        + ")";

                    if(sc.State==  ConnectionState.Closed) {sc.Open();}
                    SqlCommand scmd = new SqlCommand(sSQL, sc);
                    object o = scmd.ExecuteScalar();
                    if(sc.State==  ConnectionState.Open) {sc.Close();};
                }

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
                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath])                
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6 )  ;
                 Select @@IDENTITY ";


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = u.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = u.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = u.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = u.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = u.isActive ;
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = ""; //u.photoFilePath.ToString();


                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + Convert.ToInt32 (UserType.standard) + ") ";

                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteUser(int UserID)
        {
            try
            {
                //DeleteUser(UserID);
                //SystemAdmin(SystemAdmin);
                string ssQL = " Update PortalUSer SET isActive=2 where ID=" + UserID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


                string sSQL = @"
                UPDATE [PortalUser]
                   SET [userName] = @p1
                      ,[passWord] = @p2
                      ,[name] = @p3
                      ,[surName] = @p4
                      ,[isActive] = @p5
                      ,[photoFilePath] = @p6
                      ,[profession] = @p7,[resume] = @p8
                      ,[modifiedDate] = @p9
                 WHERE ID=" + u.userID.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = u.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = u.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = u.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = u.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = u.isActive;
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = ""; // u.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.VarChar);
                scmd.Parameters[6].Value = "";
                scmd.Parameters.Add("p8", SqlDbType.VarChar);
                scmd.Parameters[7].Value = "";
                scmd.Parameters.Add("p9", SqlDbType.DateTime);
                scmd.Parameters[8].Value = DateTime.Now;

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }




        public int AddAnonimUser(BSClass.AnonimUser u)
        {
           
            int newID = 0;
            try{
//                string sSQL = @"INSERT INTO [PortalUser]
//                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath],[profession],[resume]])                
//                VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8 )  ;
//                 Select @@IDENTITY ";


//                if(sc.State==  ConnectionState.Closed) {sc.Open();}
//                SqlCommand scmd = new SqlCommand(sSQL, sc);
//                scmd.Parameters.Add("p1", SqlDbType.VarChar);
//                scmd.Parameters[0].Value = u.userName;
//                scmd.Parameters.Add("p2", SqlDbType.VarChar);
//                scmd.Parameters[1].Value = u.passWord;
//                scmd.Parameters.Add("p3", SqlDbType.VarChar);
//                scmd.Parameters[2].Value = u.name;
//                scmd.Parameters.Add("p4", SqlDbType.VarChar);
//                scmd.Parameters[3].Value = u.surName;
//                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
//                scmd.Parameters[4].Value = u.isActive.ToString();
//                scmd.Parameters.Add("p6", SqlDbType.VarChar);
//                scmd.Parameters[5].Value = u.photoFilePath.ToString();
//                scmd.Parameters.Add("p7", SqlDbType.VarChar);
//                scmd.Parameters[5].Value = u.profession.ToString();
//                scmd.Parameters.Add("p8", SqlDbType.VarChar);
//                scmd.Parameters[5].Value = u.resume.ToString();

//                object o = scmd.ExecuteScalar();
//                newID = Convert.ToInt32(o.ToString());
//                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteAnonimUser(int AnonimUserID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                string ssQL = " Update PortalUSer SET isActive=2 where ID=" + AnonimUserID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();

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


//                string sSQL = @"
//                UPDATE [PortalUser]
//                   SET [userName] = @p1
//                      ,[passWord] = @p2
//                      ,[name] = @p3
//                      ,[surName] = @p4
//                      ,[isActive] = @p5
//                      ,[photoFilePath] = @p6
//                      ,[profession] = @p7,[resume] = @p8
//                      ,[modifiedDate] = @p9
//                 WHERE ID=" + u.userID.ToString();


//                if(sc.State==  ConnectionState.Closed) {sc.Open();}
//                SqlCommand scmd = new SqlCommand(sSQL, sc);
//                scmd.Parameters.Add("p1", SqlDbType.VarChar);
//                scmd.Parameters[0].Value = u.userName;
//                scmd.Parameters.Add("p2", SqlDbType.VarChar);
//                scmd.Parameters[1].Value = u.passWord;
//                scmd.Parameters.Add("p3", SqlDbType.VarChar);
//                scmd.Parameters[2].Value = u.name;
//                scmd.Parameters.Add("p4", SqlDbType.VarChar);
//                scmd.Parameters[3].Value = u.surName;
//                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
//                scmd.Parameters[4].Value = u.isActive.ToString();
//                scmd.Parameters.Add("p6", SqlDbType.VarChar);
//                scmd.Parameters[5].Value = u.photoFilePath.ToString();
//                scmd.Parameters.Add("p7", SqlDbType.VarChar);
//                scmd.Parameters[6].Value = u.profession.ToString();
//                scmd.Parameters.Add("p8", SqlDbType.VarChar);
//                scmd.Parameters[7].Value = u.resume.ToString();
//                scmd.Parameters.Add("p9", SqlDbType.DateTime);
//                scmd.Parameters[8].Value = DateTime.Now;

//                scmd.ExecuteNonQuery();

//                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        public void ActivateUser(int userID)
        {
            //Activates  a BSClass.User Record 
            try
            {
                //ActivateUser(userID);
                string sSQL = @"Update [PortalUser]
                SET isActive=1 where ID=" + userID.ToString();                
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);              

                scmd.ExecuteNonQuery();                
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
                string sSQL = @"Update [PortalUser]
                SET isActive=2 where ID=" + userID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                scmd.ExecuteNonQuery();
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
                int newID = 0;

                string sSQL = @"INSERT INTO [Comment] ([commentType],[commentContent],[PaperRef],[UserRef],
                [commentDate],[modifiedDate],[approvalState])
                VALUES
                (@p1,@p2,@p3,@p4,@p5,@p6,@p7) ;
                Select @@IDENTITY ";


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.TinyInt);
                scmd.Parameters[0].Value = c.commentType;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = c.content;
                scmd.Parameters.Add("p3", SqlDbType.Int);
                scmd.Parameters[2].Value = paperID;
                scmd.Parameters.Add("p4", SqlDbType.Int);
                scmd.Parameters[3].Value = c.userId;
                scmd.Parameters.Add("p5", SqlDbType.DateTime);
                scmd.Parameters[4].Value = DateTime.Now;
                scmd.Parameters.Add("p6", SqlDbType.DateTime);
                scmd.Parameters[5].Value = DateTime.Now ;
                scmd.Parameters.Add("p7", SqlDbType.TinyInt);
                scmd.Parameters[6].Value = c.approvalState;

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteComment(int CommentID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                string ssQL = " Update Comment SET isActive=2 where ID=" + CommentID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();

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
            try
            {


                string sSQL = @"UPDATE [Comment]
                   SET [commentType] = @p1
                      ,[commentContent] = @p2
                      ,[PaperRef] = @p3
                      ,[UserRef] = @p4
                      ,[commentDate] = @p5
                      ,[modifiedDate] = @p6
                      ,[approvalState] = @p7
                      ,[isActive] = @p8
                 WHERE ID=" + c.id.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.TinyInt);
                scmd.Parameters[0].Value = c.commentType;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = c.content;
                scmd.Parameters.Add("p3", SqlDbType.Int);
                scmd.Parameters[2].Value = c.paperId;
                scmd.Parameters.Add("p4", SqlDbType.Int);
                scmd.Parameters[3].Value = c.userId;
                scmd.Parameters.Add("p5", SqlDbType.DateTime);
                scmd.Parameters[4].Value = DateTime.Now;
                scmd.Parameters.Add("p6", SqlDbType.DateTime);
                scmd.Parameters[5].Value = DateTime.Now;
                scmd.Parameters.Add("p7", SqlDbType.TinyInt);
                scmd.Parameters[5].Value = c.approvalState;

                scmd.ExecuteNonQuery();
               
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                return;
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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void ApproveComment(int CommentID)
        {
            try
            {
             
                string sSQL = "UPDATE [Comment] SET [approvalState] =2 , isActive=1 " +
                " WHERE ID=" + CommentID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                object o = scmd.ExecuteNonQuery();

                return;
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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public int AddPaperToMagazine(Paper p, int MagazineID)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [Paper]
                ([AuthorUserRef],[approvalState],[contentPath],[version],
                [isActive],[title],[MagazineRef],[uploadDate])
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ;



                 Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = p.authorId ;

                scmd.Parameters.Add("p2", SqlDbType.TinyInt);
                scmd.Parameters[1].Value = ApprovalState.YeniYuklendi; //p.approvalState;

                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = p.contentPath;
                scmd.Parameters.Add("p4", SqlDbType.Decimal);
                scmd.Parameters[3].Value = p.version;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = p.isActive;
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = p.title;
                scmd.Parameters.Add("p7", SqlDbType.Int);
                scmd.Parameters[6].Value = MagazineID ;
                scmd.Parameters.Add("p8", SqlDbType.DateTime);
                scmd.Parameters[7].Value = DateTime.Now;

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};

                return newID ;
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                //LOG ERROR
                //RETURN NULL
                return 0 ;
            }
            finally
            {
                //dispose unused objects...
                if(sc.State==  ConnectionState.Open) {sc.Close();};
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
                string s = " todo" ; //CreatePublishedPaperID();
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
                int newID = 0;

                string sSQL = @"INSERT INTO [Survey]([MagazineRef])VALUES(" +
                  MagazineID.ToString()  
                    +") "+
                " Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (s.surveyQuestionary.Length > 0) 
                {
                    SqlCommand scmd2 = new SqlCommand();
                    foreach (SurveyQuestionary sq in s.surveyQuestionary) 
                    {

                         
                        sSQL = "INSERT INTO [SurveyQuestionary]([SurveyRef],[question]) " +
                        " VALUES(@p1,@p2) ";


                        scmd2.Parameters.Add("p1", SqlDbType.Int);
                        scmd2.Parameters[0].Value = newID;
                        scmd2.Parameters.Add("p2", SqlDbType.VarChar);
                        scmd2.Parameters[1].Value = sq.question;

                        if(sc.State==  ConnectionState.Closed) {sc.Open();}
                        scmd2.ExecuteNonQuery();
                        if(sc.State==  ConnectionState.Open) {sc.Close();};                         
                    }
                }


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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteSurvey(int SurveyID)
        {
            try
            {
                string ssQL = " Update Survey SET isActive=2 where ID=" + SurveyID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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
           
            try
            {
                string sSQL = @"UPDATE [Survey]
                SET [MagazineRef] ="+s.magazineId.ToString()+ 
                " ,[isActive] ="+s.isActive.ToString()+ 
                " WHERE ID="+s.id.ToString() ;

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                scmd.ExecuteNonQuery();
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



         

        public int AddSurveyAnswer(SurveyAnswer sa)
        {
             try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [SurveyAnswer]
                ([SurveyQuestionaryRef],[answer],[PaperRef])
                VALUES ("+ 
                        sa.surveyQuestionaryid+","+
                        "'"+sa.answer+"'"+","+
                        sa.PaperRef
                         +")" ;

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                
                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());               
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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }        
        public void DeleteSurveyAnswer(int SurveyAnswerID)
        {
            try
            {
                string ssQL = " Delete FROM SurveyAnswer where ID=" + SurveyAnswerID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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

        public void UpdateSurveyAnswer(SurveyAnswer sa)
        {
            //Updates a Survey Record with new values...

            try
            {
                string sSQL = @"UPDATE [SurveyAnswer] " +
                   " SET [answer] =" + sa.answer.Trim() +
                   " WHERE ID=" + sa.id.ToString();            
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                scmd.ExecuteNonQuery();
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }

        public int AddSurveyQuestionary(BSClass.SurveyQuestionary sq, int SurveyRef)
        {
            try
            {
                int newID = 0;

                string sSQL = "INSERT INTO [SurveyQuestionary]([SurveyRef],[question]) " +
                        " VALUES(@p1,@p2) ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = SurveyRef;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = sq.question;


                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());               
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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteSurveyQuestionary(int SurveyQuestionaryID)
        {
            try
            {
                string ssQL = " Update SurveyQuestionary SET isActive=2 where ID=" + SurveyQuestionaryID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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
            try
            {
                string sSQL = @"UPDATE [SurveyQuestionary]
                    SET [SurveyRef] ="+s.id.ToString() +","+
                    " [question] ="+"'"+s.question.Trim() +"'"+
                    " [isActive] ="+s.isActive.ToString()+ 
                    " WHERE ID= "+s.id ;

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                              
                scmd.ExecuteNonQuery();                
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }

        public int AddPublishedMagazine(BSClass.PublishedMagazine pm, int MagazineID)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [PublishedMagazine]
                ([MagazineRef],[MagazinePublishState],PublishDate,MagazinePublishNo)

                VALUES(@p1,@p2,@p3,@p4) ;

                

                 Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = MagazineID ;

                scmd.Parameters.Add("p2", SqlDbType.TinyInt);
                scmd.Parameters[1].Value = pm.MagazinePublishState ; 

                scmd.Parameters.Add("p3", SqlDbType.DateTime);
                scmd.Parameters[2].Value = DateTime.Now;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString();
                


                
                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeletePublishedMagazine(int PublishedMagazineID)
        {
            //makes a AnonimUser record  passive...
            try
            {
                string ssQL = " Update PublishedMagazine SET isActive=2 where ID=" + PublishedMagazineID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();

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
                string sSQL = @"UPDATE [PublishedMagazine]
                SET 
                      ,[MagazinePublishState] = @p1
                      ,[PublishDate] = @p2
                      ,[MagazinePublishNo] = @p3
                      ,[isActive] = @p4
                 WHERE ID="+pm.id  ;

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.TinyInt);
                scmd.Parameters[0].Value = pm.MagazinePublishState;
                scmd.Parameters.Add("p2", SqlDbType.DateTime);
                scmd.Parameters[1].Value = pm.PublishDate;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = pm.MagazinePublishNo;
                scmd.Parameters.Add("p4", SqlDbType.TinyInt);
                scmd.Parameters[3].Value = pm.isActive;
               
                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        //YENI2
        //GET METHODS...

        public BSClass.Author[] GetAuthorList(string AuthorIDList,string PaperIDList)
        {

            List<Author> tList = new List<Author>();
            try
            {
                string sSQL = @"SELECT [PortalUser].* , "+
                " (Select count(ID) from Paper where Paper.AuthorUserRef=PortalUser.ID  ) as paperCount "+
                " FROM [PortalUser]  "+
                " inner join UserGrant on UserGrant.UserRef=[PortalUser].ID" +                
                " where PortalUser.isActive=1 "+
                " and UserGrant.UserType=" + Convert.ToInt32 (UserType.moderator);



                if (AuthorIDList != null && AuthorIDList.Length>0)
                {
                    sSQL = sSQL + " and [PortalUser].ID in(" + AuthorIDList + ")";
                }
                
               
                

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Author  a = new Author();
                        a.userID= Convert.ToInt32(dr["ID"].ToString());
                        a.userName = dr["userName"].ToString();
                        a.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        a.paperCount = Convert.ToInt32(dr["paperCount"].ToString());
                        a.paperList = this.GetPaperList("", "", "", -1, -1, a.userID, "", "", true);
                        a.surName = dr["surName"].ToString();
                        a.name= dr["name"].ToString();

                        if (dr["photoFilePath"]!=null)
                                a.photoFilePath = dr["photoFilePath"].ToString();
                        a.profession = dr["profession"].ToString();
                        a.resume = dr["resume"].ToString();
                        tList.Add(a);
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


        public int[] GetUserTypes(int userID) 
        {
            List<int> tList = new List<int>();
            try
            {
                string sSQL = @"SELECT [UserGrant].* "+
                " from UserGrant " +                
                " where UserRef="+userID.ToString();

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {                        
                        tList.Add(Convert.ToInt32(dr["userType"].ToString()));
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


        public BSClass.User[] GetUserList(string UserIDlist,string userName,string Passwd, bool onlyActiveRecords, DateTime minActivationDate)
        {


            List<User> tList = new List<User>();
            try
            {

                string sSQL;
                if(onlyActiveRecords==true)
                    sSQL = @"SELECT [PortalUser].*  " +
                    " FROM [PortalUser]  " +
                    " where PortalUser.isActive=1 ";
                else
                     sSQL = @"SELECT [PortalUser].*  " +
                    " FROM [PortalUser]  " +
                    " where 1=1 ";

                if (UserIDlist != null && UserIDlist.Length > 0)
                {
                    sSQL = sSQL + " and [PortalUser].ID in(" + UserIDlist + ")";
                }

                if (userName!= null && userName.Length > 0)
                {
                    sSQL = sSQL + " and [PortalUser].userName in(" +"'"+ userName+"'" + ")";
                }


                if (Passwd!= null && Passwd.Length > 0)
                {
                    sSQL = sSQL + " and [PortalUser].passWord =" + "'" + Passwd + "'" ;
                }

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        User a = new User();
                        a.userID = Convert.ToInt32(dr["ID"].ToString());
                        a.userName = dr["userName"].ToString();
                        a.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        a.surName = dr["surName"].ToString();
                        a.name = dr["name"].ToString();

                        if (dr["photoFilePath"] != null)
                                a.photoFilePath = dr["photoFilePath"].ToString();
                        a.userType= this.GetUserTypes(a.userID);
                        tList.Add(a);
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


        public BSClass.SystemAdmin[] GetSystemAdminList(string SystemAdminIDList, bool onlyActiveRecords, DateTime minActivationDate)
        {

            List<SystemAdmin> tList = new List<SystemAdmin>();
            try
            {
                string sSQL = @"SELECT [PortalUser].*  " +
                " FROM [PortalUser]  " +
                " inner join UserGrant on UserGrant.UserRef=[PortalUser].ID" +
                " where PortalUser.isActive=1 " +
                " and UserGrant.UserType=" + (Convert.ToInt32 (UserType.systemadmin)).ToString();

                if (SystemAdminIDList != null && SystemAdminIDList.Length > 0)
                {
                    sSQL = sSQL + " and [PortalUser].ID in(" + SystemAdminIDList + ")";
                }




                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        SystemAdmin a = new SystemAdmin();
                        a.userID = Convert.ToInt32(dr["ID"].ToString());
                        a.userName = dr["userName"].ToString();
                        a.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        a.surName = dr["surName"].ToString();
                        a.name = dr["name"].ToString();

                        if (dr["photoFilePath"] != null)
                                a.photoFilePath = dr["photoFilePath"].ToString();

                        tList.Add(a);
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


        public BSClass.Referee[] GetRefereeList(string RefereeIDList, bool onlyActiveRecords, string MagazineIDList, string PublishedMagazineList)
        {

            List<Referee> tList = new List<Referee>();
            try
            {
                string sSQL = @"SELECT [PortalUser].* " +
                " FROM [PortalUser]  " +
                " inner join UserGrant on UserGrant.UserRef=[PortalUser].ID" +
                " where PortalUser.isActive=1 " +
                " and UserGrant.UserType=" + (Convert.ToInt32 (UserType.hakem)).ToString();

                if (RefereeIDList != null && RefereeIDList.Length > 0)
                {
                    sSQL = sSQL + " and [PortalUser].ID in(" + RefereeIDList + ")";
                }

                if (MagazineIDList != null && MagazineIDList.Length > 0)
                {
                    //
                }

                if (PublishedMagazineList != null && PublishedMagazineList.Length > 0)
                {
                    //
                }


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Referee a = new Referee();
                        a.userID = Convert.ToInt32(dr["ID"].ToString());
                        a.userName = dr["userName"].ToString();
                        a.isActive = Convert.ToInt32(dr["isActive"].ToString());
                   //     a.paperCount = Convert.ToInt32(dr["paperCount"].ToString());
                   //     a.paperList = this.GetPaperList("", "", "", -1, -1, a.userID, "", "", true);
                        a.surName = dr["surName"].ToString();
                        a.name = dr["name"].ToString();

                        if (dr["photoFilePath"] != null)
                            a.photoFilePath = dr["photoFilePath"].ToString();
                        a.profession = dr["profession"].ToString();
                        a.resume = dr["resume"].ToString();
                        tList.Add(a);
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


        public BSClass.Moderator[] GetModeratorList(string ModeratorIDList, bool onlyActiveRecords)
        {

            List<Moderator> tList = new List<Moderator>();
            try
            {
                string sSQL = @"SELECT [PortalUser].*  " +
                " FROM [PortalUser]  " +
                " inner join UserGrant on UserGrant.UserRef=[PortalUser].ID" +
                " where PortalUser.isActive=1 " +                
                " and UserGrant.UserType=" + (Convert.ToInt32 (UserType.moderator)).ToString();

                if (ModeratorIDList != null && ModeratorIDList.Length > 0)
                {
                    sSQL = sSQL + " and [PortalUser].ID in(" + ModeratorIDList + ")";
                }




                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Moderator a = new Moderator();
                        a.userID = Convert.ToInt32(dr["ID"].ToString());
                        a.userName = dr["userName"].ToString();
                        a.isActive = Convert.ToInt32(dr["isActive"].ToString());                       
                        a.surName = dr["surName"].ToString();
                        a.name = dr["name"].ToString();

                        if (dr["photoFilePath"] != null)
                            a.photoFilePath = dr["photoFilePath"].ToString();

                        tList.Add(a);
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


        public BSClass.Magazine[] GetMagazineList(string MagazineIDList,int  PublisherID, bool onlyActiveRecords)
        {
            List<Magazine> tList = new List<Magazine>();
            try
            {
                string sSQL = @"SELECT [ID],[PublisherUserRef],[name],[createDate],[modifiedDate],
                [maxPaperCount],[isActive]
                FROM [Magazine] where 1=1";


                if (onlyActiveRecords) 
                {
                    sSQL = sSQL + " and  Magazine.isActive=1"; 
                }

                if (MagazineIDList!=null && MagazineIDList.Length > 0)
                {
                    sSQL = sSQL + " and ID in(" + MagazineIDList + ")";
                }


                if (PublisherID > 0) 
                {
                    sSQL = sSQL + " and PublisherUserRef =" + PublisherID.ToString();
                }

                sSQL = sSQL+" order by Magazine.name ASC ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};
              
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
                        if (dr["PublisherUserRef"].ToString() != "")
                            m.publisherId = Convert.ToInt32(  dr["PublisherUserRef"].ToString());

                        if (dr["maxPaperCount"].ToString() != "")
                            m.maxPaperCount=Convert.ToInt32(  dr["maxPaperCount"].ToString());                        
                        m.isActive=Convert.ToInt32(  dr["isActive"].ToString());                                                                
                        tList.Add(m);
                    }
                }



                /*
                foreach (Magazine mm in tList) 
                {                    
                    mm.publishedMagazines= this.GetPublisheMagazineList(mm.id.ToString(), "", true);
                }
                 */ 

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



        public PublishedMagazine[] GetPublisheMagazineList(string MagazineIDList, string PublishedMagazineIDList, bool onlyActiveRecords)
        {

            try
            {
                List<PublishedMagazine> tList = new List<PublishedMagazine>();
                try
                {
                    string sSQL = @"SELECT [ID]
                                  ,[MagazineRef]
                                  ,[MagazinePublishState]
                                  ,[PublishDate]
                                  ,[MagazinePublishNo]
                                  ,[isActive] ,
                                  (select count(ID) from PAper where PublishedMagazineRef=PublishedMagazine.ID ) as  paperCount 
                              FROM [PublishedMagazine] where 1=1 ";


                    if (onlyActiveRecords==true)
                    {
                        sSQL = sSQL + "  and  PublishedMagazine.isActive=1";
                    }
                    if (MagazineIDList != null && MagazineIDList.Length > 0)
                    {
                        sSQL = sSQL + "  and  MagazineRef in(" + MagazineIDList + ") ";
                    }
                    if (PublishedMagazineIDList != null && PublishedMagazineIDList.Length > 0)
                    {
                        sSQL = sSQL + "  and  ID in(" + PublishedMagazineIDList + ") ";
                    }


                    if(sc.State==  ConnectionState.Closed) {sc.Open();}
                    SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(sc.State==  ConnectionState.Open) {sc.Close();};

                    if (dt.Rows.Count < 0)
                    {
                        return null;
                    }
                    else
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            PublishedMagazine pm = new PublishedMagazine();
                            pm.id = Convert.ToInt32(dr["ID"].ToString());
                            pm.MagazinePublishNo = dr["MagazinePublishNo"].ToString();


                            if (dr["MagazinePublishState"].ToString() != "")
                                    pm.MagazinePublishState = Convert.ToInt32(dr["MagazinePublishState"].ToString());


                            pm.isActive = Convert.ToInt32(dr["isActive"].ToString());

                            if (dr["paperCount"].ToString() != "")
                                pm.paperCount = Convert.ToInt32(dr["paperCount"].ToString());

                            if (dr["PublishDate"].ToString().Length>0)
                                pm.PublishDate = Convert.ToDateTime( dr["PublishDate"]);


                            pm.MagazineRef = Convert.ToInt32(dr["MagazineRef"].ToString());
                            

                            /*
                            pm.mgzn = (this.GetMagazineList(pm.MagazineRef.ToString(), true))[0];
                            pm.paperList=(this.GetPaperList(pm.id.ToString(),"","",-1,-1,-1,"","",true));         
                            */
                            tList.Add(pm);
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
                    if(sc.State==  ConnectionState.Open) {sc.Close();};
                }
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



        public BSClass.Comment[] GetCommentList(string PaperIDList, int RefereeID, bool onlyActiveRecords)
        {
            List<Comment> tList = new List<Comment>();
            try
            {
                string sSQL;

                if (onlyActiveRecords == true)
                {
                    sSQL = @"Select C.* from Comment C
                    inner join Paper p on p.ID=C.PaperRef
                    inner join PortalUser PU on  PU.ID=C.UserRef " +
                    " where C.isActive=1 ";
                }
                else
                {
                    sSQL = @"Select C.* from Comment C
                    inner join Paper p on p.ID=C.PaperRef
                    inner join PortalUser PU on  PU.ID=C.UserRef " +
                    " where C.isActive=2 ";
                }

                if (PaperIDList != null && PaperIDList.Length > 0)
                {
                    sSQL = sSQL + " and [C].PaperRef in(" + PaperIDList + ")";                    
                }

                if (RefereeID > 0)
                {
                    sSQL = sSQL + " and [C].UserRef =" + RefereeID.ToString() +
                        " and C.commentType=2 ";
                }
                if (RefereeID <= 0)
                {
                    sSQL = sSQL + "  and C.commentType=1 ";
                }


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Comment c = new Comment();
                        c.id= Convert.ToInt32(dr["ID"].ToString());
                        c.paperId= Convert.ToInt32(dr["PaperRef"].ToString());
                        c.userId= Convert.ToInt32(dr["UserRef"].ToString());
                        c.content = dr["commentContent"].ToString();
                        c.commentType = Convert.ToInt32(dr["commentType"].ToString());

                        if(dr["commentDate"].ToString().Length>0)
                            c.commentDate =Convert.ToDateTime( dr["commentDate"]);
                        c.approvalState = Convert.ToInt32(dr["approvalState"].ToString());                        

                        tList.Add(c);
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


        public BSClass.Paper[] GetPaperList(string PublishedMagazineIDList, string MagazineIDList, string PaperIDList, int RefereeID, int PublisherID, int AuthorID, string category, string SubCategoryIDlist, bool onlyActiveRecords)
        {

            List<Paper> tList = new List<Paper>();
            try
            {
                string sSQL = @"SELECT Paper.*,M.name as MagazineName ,UPPER(PO1.name+' '+PO1.surName) as Yazar ,
                    PPX.name+' '+PPX.surName  as  publisherName
                    FROM [Paper] 
                    inner join Magazine M on M.ID=Paper.MagazineRef
                    LEFT join PortalUser PPX on M.PublisherUserRef=PPX.ID
                    LEFT join PortalUser PO1 on PO1.ID=Paper.AuthorUserRef

                    WHERE 1=1 ";


                if (PublishedMagazineIDList != null && PublishedMagazineIDList.Length > 0) 
                {
                    sSQL = sSQL + " and Paper.PublishedMagazineRef in("+ PublishedMagazineIDList + ") ";
                }

                if (PaperIDList != null && PaperIDList.Length > 0)
                {
                    sSQL = sSQL + " and Paper.ID in(" + PaperIDList + ") ";
                }


                if (AuthorID > 0) 
                {
                    sSQL = sSQL + " and Paper.AuthorUserRef in(" + AuthorID + ") ";
                }

                if (RefereeID > 0)
                {
                    //yeni SQL yaz...
                    sSQL = @"SELECT Paper.*,M.name as MagazineName ,UPPER(PO1.name+' '+PO1.surName) as Yazar,PPX.name+' '+PPX.surName  as  publisherName 
                    FROM [Paper]                     
                    inner join RefereePaper RP  on RP.PaperRef=Paper.ID
                    inner join Magazine M on M.ID=Paper.MagazineRef
                    LEFT join PortalUser PO1 on PO1.ID=Paper.AuthorUserRef
                    LEFT join PortalUser PPX on M.PublisherUserRef=PPX.ID
                    where Paper.isActive=1 " +
                    " and RP.UserRefereeRef=" + RefereeID.ToString();
                    //and RP.isApproved=2
                }

                if (PublisherID > 0) 
                {
                    sSQL = @" SELECT Paper.*,M.name as MagazineName,UPPER(PO1.name+' '+PO1.surName) as Yazar ,
                    PPX.name+' '+PPX.surName  as  publisherName
                    FROM [Paper] 
                    inner join Magazine M on M.ID=Paper.MagazineRef
                    inner join PortalUser PO on PO.ID=M.PublisherUserRef
                    LEFT join PortalUser PO1 on PO1.ID=Paper.AuthorUserRef
                    LEFT join PortalUser PPX on M.PublisherUserRef=PPX.ID
                    where Paper.isActive=1
                    and PO.ID=" + PublisherID.ToString();
                }

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Paper p = new Paper();
                        p.id = Convert.ToInt32(dr["ID"].ToString());
                        p.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        p.MagazineID = Convert.ToInt32(dr["MagazineRef"].ToString());

                        if (dr["approvalDate"].ToString().Length>0)
                            p.approvalDate= Convert.ToDateTime(  dr["approvalDate"].ToString());
                        p.approvalState= Convert.ToInt32(  dr["approvalState"].ToString());

                        p.authorId= Convert.ToInt32(  dr["AuthorUserRef"].ToString());
                        p.comments= this.GetCommentList(p.id.ToString(),-1,true);
                        p.contentPath=dr["contentPath"].ToString();
                        p.MagazineName = dr["MagazineName"].ToString();


                        try
                        {
                            if (dr["uploadDate"] != null)
                                p.uploadDate = Convert.ToDateTime(dr["uploadDate"].ToString());
                        }
                        catch (Exception ex22) 
                        {
                            p.uploadDate = DateTime.Now;
                        }

                        if (dr["publisherName"] != null)
                            p.publisherName = dr["publisherName"].ToString();
                        else
                            p.publisherName = "";

                        p.AuthorName= dr["Yazar"].ToString();

                        p.publishedId = dr["publishedId"].ToString();

                        if (dr["PublishedMagazineRef"].ToString().Length>0)
                            p.PublishedMagazineID = Convert.ToInt32(dr["PublishedMagazineRef"].ToString());
                        p.publisherComment = dr["publisherComment"].ToString();

                        p.referencePaperID = null; //TODO...

                        p.subCategories = GetSubCategoryList(true, "", p.MagazineID);

                        p.title = dr["title"].ToString();
                        p.version = Convert.ToDouble(dr["version"].ToString());
                                               
                        tList.Add(p);
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




        public BSClass.Paper[] GetRefereeNotesOnPaper(int PaperID)
        {

            List<Paper> tList = new List<Paper>();
            try
            {
                string sSQL = @"Select P.ID , RR.name+' '+RR.surName as RefereeName, 
                    case RP.isApproved when 1 then 'Onay Bekliyor'
                    when 2 then 'Hakem Onaylı'
                    when 3 then 'Hakem Reddetti'
                    end as HakemOnayDurum  , 
                    CC.commentDate , CC.commentContent as Yorum
                    from Paper P
                    LEFT join RefereePaper RP on RP.PaperRef=P.ID
                    LEFT join PortalUser RR on RR.ID=RP.UserRefereeRef 
                    LEFT Join Comment  CC on CC.UserRef=RR.ID and CC.PaperRef=P.ID and CC.commentType=2 and CC.isActive=1
                    where P.ID=" + PaperID.ToString();


                if (sc.State == ConnectionState.Closed) { sc.Open(); }
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (sc.State == ConnectionState.Open) { sc.Close(); };

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Paper p = new Paper();
                        p.id = Convert.ToInt32(dr["ID"].ToString());
                    //p.isActive = Convert.ToInt32(dr["isActive"].ToString());
                    //p.MagazineID = Convert.ToInt32(dr["MagazineRef"].ToString());

                        if (dr["commentDate"].ToString().Length > 0)
                            p.approvalDate = Convert.ToDateTime(dr["commentDate"].ToString());
                        //p.approvalState = Convert.ToInt32(dr["commentDate"].ToString());

                       // p.authorId = Convert.ToInt32(dr["AuthorUserRef"].ToString());
                        //p.comments = this.GetCommentList(p.id.ToString(), -1, true);
                        //p.contentPath = dr["contentPath"].ToString();
                        p.MagazineName = dr["Yorum"].ToString();

                        p.AuthorName = dr["RefereeName"].ToString();

                       // p.publishedId = dr["publishedId"].ToString();
                        /*
                        if (dr["PublishedMagazineRef"].ToString().Length > 0)
                            p.PublishedMagazineID = Convert.ToInt32(dr["PublishedMagazineRef"].ToString());
                        p.publisherComment = dr["publisherComment"].ToString();

                        p.referencePaperID = null; //TODO...

                        p.subCategories = GetSubCategoryList(true, "", p.MagazineID);
                        */
                        p.title = dr["HakemOnayDurum"].ToString();
                        //p.version = Convert.ToDouble(dr["version"].ToString());

                        tList.Add(p);
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



        public ScienceCategory[] GetScienceCategoryList(bool onlyActiveRecords,int SubCategoryID , int MagazineID)
        {
            List<ScienceCategory> tList = new List<ScienceCategory>();
            try
            {
                string sSQL = @"SELECT distinct  [ScienceCategory].*  FROM [ScienceCategory] ";


                if (SubCategoryID > 0)
                {
                    sSQL = sSQL + " INNER JOIN ScienceSubCategory SSC on SSC.ScienceCategoryRef=ScienceCategory.ID " +
                    " where SSC.SubCategoryRef=" + SubCategoryID.ToString() + " and ScienceCategory.isActive=1 ";
                }
                else if (MagazineID > 0)
                {
                    sSQL = @" SELECT distinct  [ScienceCategory].*  FROM [ScienceCategory]
                        LEFT join ScienceSubCategory SSC on SSC.ScienceCategoryRef=ScienceCategory.ID
                        LEFT join MagazineSubCategory MSC on MSC.SubCategoryRef=SSC.SubCategoryRef
                        where MSC.MagazineRef="+MagazineID.ToString()+" and ScienceCategory.isActive=1 ";               
                }

                else if (SubCategoryID < 0 && MagazineID < 0)
                {
                    sSQL = @"SELECT distinct  [ScienceCategory].*  FROM [ScienceCategory] WHERE ScienceCategory.isActive = 1";
                }
               


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        ScienceCategory c = new ScienceCategory();
                        c.id = Convert.ToInt32(dr["ID"].ToString());
                        c.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        c.name = dr["name"].ToString();
                        //c.subCategories = this.GetSubCategoryList
                        
                        tList.Add(c);
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


        public BSClass.SubCategory[] GetSubCategoryList(bool onlyActiveRecords,string scienceCAtegorylist,int MagazineID)
        {
            List<SubCategory> tList = new List<SubCategory>();
            try
            {
                string sSQL = @"SELECT distinct [SubCategory].* 
                FROM [SubCategory] 
                LEFT JOIN MagazineSubCategory MSC on MSC.SubCategoryRef=SubCategory.ID 
                LEFT JOIN ScienceSubCategory SSC on SSC.SubCategoryRef=SubCategory.ID  
                WHERE 1=1 AND SubCategory.isActive = 1";

                 

                if (MagazineID > 0)
                {
                    sSQL = sSQL + 
                        "  AND MSC.MagazineRef =" + MagazineID.ToString();
                }

                if (scienceCAtegorylist != null && scienceCAtegorylist.Length > 0 && scienceCAtegorylist!="\"\"")
                {
                    sSQL = sSQL + "  AND SSC.ScienceCategoryRef in(" + scienceCAtegorylist + ")";
                }



                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        SubCategory c = new SubCategory();
                        c.id = Convert.ToInt32(dr["ID"].ToString());
                        c.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        c.approvalState = Convert.ToInt32(dr["approvalState"].ToString());
                        c.name = dr["name"].ToString();
                        c.scienceCategoryList = this.GetScienceCategoryList(true, c.id,-1);
                        tList.Add(c);
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




        public BSClass.SurveyQuestionary[] GetSurveyQuestionaryList(bool onlyActiveRecords, int MagazineID, int SurveyID)
        {
            List<SurveyQuestionary> tList = new List<SurveyQuestionary>();
            try
            {
                //[ID],[SurveyRef],[question],[isActive]
                string sSQL = @"SELECT [SurveyQuestionary].* 
                FROM [SurveyQuestionary]
                inner join Survey on Survey.ID=SurveyQuestionary.SurveyRef ";              

                if (MagazineID > 0)
                {
                    sSQL = sSQL + "  inner join Magazine M on Survey.MagazineRef=M.ID ";
                }

                sSQL=sSQL+" where SurveyQuestionary.isActive = 1 " ;

                if (SurveyID>0 )
                {
                    sSQL = sSQL + " and SurveyQuestionary.SurveyRef="+SurveyID.ToString();
                }


                if (MagazineID > 0)
                {
                    sSQL = sSQL + "  and M.ID="+MagazineID.ToString();
                }

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        SurveyQuestionary c = new SurveyQuestionary();
                        c.id = Convert.ToInt32(dr["ID"].ToString());
                        c.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        c.question= dr["question"].ToString();                       
                        tList.Add(c);
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





        public BSClass.Survey[] GetSurvey(bool onlyActiveRecords, int MagazineID, int SurveyID)
        {
            List<BSClass.Survey> tList = new List<BSClass.Survey>();
            try
            {
                //[ID],[SurveyRef],[question],[isActive]
                string sSQL = @"SELECT [Survey].* 
                FROM [Survey]  where isActive=1 ";


                if (MagazineID > 0)
                {
                    sSQL = sSQL + "  AND Survey.MagazineRef="+MagazineID.ToString() ;
                }

                

                if (SurveyID > 0)
                {
                    sSQL = sSQL + " and ID =" + SurveyID.ToString();
                }



                if (sc.State == ConnectionState.Closed) { sc.Open(); }
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (sc.State == ConnectionState.Open) { sc.Close(); };

                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                else
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        Survey c = new Survey();
                        c.id = Convert.ToInt32(dr["ID"].ToString());
                        c.isActive = Convert.ToInt32(dr["isActive"].ToString());
                        c.magazineId= Convert.ToInt32(dr["MagazineRef"].ToString());
                        tList.Add(c);
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


        public int AddModerator(BSClass.Moderator m)
        {
            try
            {


                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive])                
                VALUES(@p1,@p2,@p3,@p4,@p5)  ;
                 Select @@IDENTITY ";


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = m.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = m.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = m.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = m.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = m.isActive.ToString();


                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + (Convert.ToInt32 (UserType.moderator)).ToString() + ") ";

                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteModerator(int ModeratorID)
        {
            //makes a Moderator record  passive...
            try
            {
                string ssQL = " Update PortalUSer SET isActive=2 where ID=" + ModeratorID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


        public void UpdateModerator(BSClass.Moderator pp)
        {
            //Updates a BSClass.AnonimUser Record with new values...

            try
            {


                string sSQL = @"
                UPDATE [PortalUser]
                   SET [userName] = @p1
                      ,[passWord] = @p2
                      ,[name] = @p3
                      ,[surName] = @p4
                      ,[isActive] = @p5
                      ,[photoFilePath] = @p6
                    
                      ,[modifiedDate] = @p7
                 WHERE ID=" + pp.userID.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = pp.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = pp.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = pp.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = pp.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = pp.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = pp.photoFilePath.ToString();
                scmd.Parameters.Add("p7", SqlDbType.DateTime);
                scmd.Parameters[6].Value = DateTime.Now;

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        //////////////////////////////////////////////////////////as


        public int AddSystemAdmin(BSClass.SystemAdmin sa)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [PortalUser]
                ([userName],[passWord],[name],[surName],[isActive],[photoFilePath])                
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6)  ;
                 Select @@IDENTITY ";


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = sa.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = sa.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = sa.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = sa.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = sa.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = sa.photoFilePath.ToString();

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                sSQL = @"INSERT INTO [UserGrant]([userRef],[userType])
                VALUES(" + newID.ToString() + "," + (Convert.ToInt32 (UserType.systemadmin)).ToString() + ") ";

                scmd.CommandText = sSQL;
                scmd.ExecuteScalar();

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }


        public void DeleteSystemAdmin(int SystemAdminID)
        {
            //makes a SystemAdmin record  passive...
            try
            {
                //SystemAdmin(SystemAdmin);
                string ssQL = " Update PortalUSer SET isActive=2 where ID=" + SystemAdminID.ToString();
                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(ssQL, sc);
                object o = scmd.ExecuteNonQuery();
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


                string sSQL = @"
                UPDATE [PortalUser]
                   SET [userName] = @p1
                      ,[passWord] = @p2
                      ,[name] = @p3
                      ,[surName] = @p4
                      ,[isActive] = @p5
                      ,[photoFilePath] = @p6           
                      ,[modifiedDate] = @p7
                 WHERE ID=" + sa.userID.ToString();


                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.VarChar);
                scmd.Parameters[0].Value = sa.userName;
                scmd.Parameters.Add("p2", SqlDbType.VarChar);
                scmd.Parameters[1].Value = sa.passWord;
                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = sa.name;
                scmd.Parameters.Add("p4", SqlDbType.VarChar);
                scmd.Parameters[3].Value = sa.surName;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = sa.isActive.ToString();
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = sa.photoFilePath.ToString();
               
                scmd.Parameters.Add("p7", SqlDbType.DateTime);
                scmd.Parameters[6].Value = DateTime.Now;

                scmd.ExecuteNonQuery();

                if(sc.State==  ConnectionState.Open) {sc.Close();};



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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }



        public void SubCategoryRequest(SubCategory scx,User u) 
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [SubCategory] ([name],isActive,approvalState)
                        VALUES(" + "'" + scx.name.Trim().ToString().ToUpper() + "'" + ", 2,1" + 
                        ") " +                                       

                        " Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());
                if(sc.State==  ConnectionState.Open) {sc.Close();};

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

        public void AddPaperByAuthor(int userID, Paper p)
        {
            try
            {
                int newID = 0;

                string sSQL = @"INSERT INTO [Paper]
                ([AuthorUserRef],[approvalState],[contentPath],[version],
                [isActive],[title],[MagazineRef],[uploadDate])
                VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ;



                 Select @@IDENTITY ";

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);
                scmd.Parameters.Add("p1", SqlDbType.Int);
                scmd.Parameters[0].Value = userID;

                scmd.Parameters.Add("p2", SqlDbType.TinyInt);
                scmd.Parameters[1].Value = ApprovalState.YeniYuklendi; //p.approvalState;

                scmd.Parameters.Add("p3", SqlDbType.VarChar);
                scmd.Parameters[2].Value = p.contentPath;
                scmd.Parameters.Add("p4", SqlDbType.Decimal);
                scmd.Parameters[3].Value = p.version;
                scmd.Parameters.Add("p5", SqlDbType.TinyInt);
                scmd.Parameters[4].Value = p.isActive;
                scmd.Parameters.Add("p6", SqlDbType.VarChar);
                scmd.Parameters[5].Value = p.title;
                scmd.Parameters.Add("p7", SqlDbType.Int);
                scmd.Parameters[6].Value = p.MagazineID;
                scmd.Parameters.Add("p8", SqlDbType.DateTime);
                scmd.Parameters[7].Value = DateTime.Now;

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};

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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }

         public void AddSubCategoryToScienceCategory(int SubCategoryId, int ScienceCategoryId)
        {
            try
            {
                
                int newID = 0;
                string sSQL =  @"INSERT INTO [ScienceSubCategory]([SubCategoryRef],[ScienceCategoryRef])
                                 VALUES(" + SubCategoryId.ToString() + "," + ScienceCategoryId.ToString() + ");" + 
                                 "Select @@IDENTITY ";
                

                if(sc.State==  ConnectionState.Closed) {sc.Open();}
                SqlCommand scmd = new SqlCommand(sSQL, sc);

                object o = scmd.ExecuteScalar();
                newID = Convert.ToInt32(o.ToString());

                if(sc.State==  ConnectionState.Open) {sc.Close();};

                return ;
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
                if(sc.State==  ConnectionState.Open) {sc.Close();};
            }
        }

         public void AddSubCategoryToMagazine(int SubCategoryId, int MagazineId)
         {
             try
             {

                 int newID = 0;
                 string sSQL = @"INSERT INTO [MagazineSubCategory]([SubCategoryRef],[MagazineRef])
                                 VALUES(" + SubCategoryId.ToString() + "," + MagazineId.ToString() + ");" +
                                  "Select @@IDENTITY ";


                 if (sc.State == ConnectionState.Closed) { sc.Open(); }
                 SqlCommand scmd = new SqlCommand(sSQL, sc);

                 object o = scmd.ExecuteScalar();
                 newID = Convert.ToInt32(o.ToString());

                 if (sc.State == ConnectionState.Open) { sc.Close(); };

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
                 if (sc.State == ConnectionState.Open) { sc.Close(); };
             }
         }

         public BSClass.Publisher[] GetPublisherList(string PublisherIDList, bool onlyActiveRecords)
         {

             List<Publisher> tList = new List<Publisher>();
             try
             {
                 string sSQL = @"SELECT [PortalUser].*  " +
                 " FROM [PortalUser]  " +
                 " inner join UserGrant on UserGrant.UserRef=[PortalUser].ID" +
                 " where PortalUser.isActive=1 " +
                 " and UserGrant.UserType=" + (Convert.ToInt32(UserType.editor)).ToString();

                 if (PublisherIDList != null && PublisherIDList.Length > 0)
                 {
                     sSQL = sSQL + " and [PortalUser].ID in(" + PublisherIDList + ")";
                 }




                 if (sc.State == ConnectionState.Closed) { sc.Open(); }
                 SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 if (sc.State == ConnectionState.Open) { sc.Close(); };

                 if (dt.Rows.Count < 0)
                 {
                     return null;
                 }
                 else
                 {

                     foreach (DataRow dr in dt.Rows)
                     {
                         Publisher a = new Publisher();
                         a.userID = Convert.ToInt32(dr["ID"].ToString());
                         a.userName = dr["userName"].ToString();
                         a.isActive = Convert.ToInt32(dr["isActive"].ToString());
                         a.surName = dr["surName"].ToString();
                         a.name = dr["name"].ToString();

                         if (dr["photoFilePath"] != null)
                             a.photoFilePath = dr["photoFilePath"].ToString();

                         tList.Add(a);
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

        //as
         public DataTable GetReferenceList(int MainPaperID, int ReferencedPaperId)
         {

             try
             {
                 string sSQL = @"SELECT R.* from PaperReferencePaper R

                    WHERE 1=1 ";


                 if (MainPaperID > 0)
                 {
                     sSQL = sSQL + " and PaperReferencePaper.MainPaperRef= " + MainPaperID + ") ";
                 }


                 if (ReferencedPaperId > 0)
                 {
                     sSQL = sSQL + " and PaperReferencePaper.ReferancePaperRef= " + ReferencedPaperId + ") ";
                 }

                 if (sc.State == ConnectionState.Closed) { sc.Open(); }
                 SqlDataAdapter sda = new SqlDataAdapter(sSQL, sc);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 if (sc.State == ConnectionState.Open) { sc.Close(); };

                 if (dt.Rows.Count < 0)
                 {
                     return null;
                 }
                 else
                 {
                     return dt;
                 }

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


        //as

    }


   
}