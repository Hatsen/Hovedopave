using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Webservice
{
    public class DatabaseHandler
    {
        SQLDatabase DB = new SQLDatabase("SchoolDB.mdf", "LocalDB", "", "");
        //string connectionString = "data source=LocalDB;initial catalog=SchoolDB;integrated security=SSPI"; // brug configuration manager her..
       // private string connectionString =
          //  "Data Source=(local);initial catalog=SchoolDB;Integrated Security=True";

        private string connectionString = "Server=(local);Database=SchoolDB;Trusted_Connection=True;";
        private static DatabaseHandler instance;


        private DatabaseHandler()
        {
       
        }

        public static DatabaseHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseHandler();
                }
                return instance;
            }
        }

        
        
        public List<Announcement> GetAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();

            try
            {
                DB.Open();

                string[][] getAnc = DB.Query("SELECT * FROM announcements");

                for (int i = 0; i < getAnc.Length; i++)
                {
                    Announcement anc = new Announcement();

                    anc.ID = Convert.ToInt32(getAnc[i][0]);
                    anc.Message = getAnc[i][1];
                    //anc.ancGroup = Convert.ToInt32(getAnc[i][2]);

                    Holder.Instance.Announcements.Add(anc);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }
            return announcements;
        }

        public string[][] GetTeacherLogin(string username)
        {
            string[][] loginDetails = null;

            try
            {
                DB.Open();
                loginDetails = DB.Query("SELECT * FROM Teacher WHERE username = '" + username + "'");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
                Holder.Instance.LoginDetails = loginDetails;
            }
            return loginDetails;
        }

        public string[][] GetParentLogin(string username)
        {
            string[][] loginDetails = null;

            try
            {
                DB.Open();
                loginDetails = DB.Query("SELECT * FROM Parent WHERE username = '" + username + "'");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
                Holder.Instance.LoginDetails = loginDetails;
            }
            return loginDetails;
        }

        public string[][] GetStudentLogin(string username)
        {
            string[][] loginDetails = null;

            try
            {
                DB.Open();
                loginDetails = DB.Query("SELECT * FROM Student WHERE username = '" + username + "'");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
                Holder.Instance.LoginDetails = loginDetails;
            }
            return loginDetails;
        }


        public int GetUserCount()
        {
            string statement = "USE SchoolDB SELECT COUNT(*) FROM User";
            int count = 0;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(statement, connection))
                {
                    connection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }



            return count;
            

        }



    }
}