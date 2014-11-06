using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Webservice.DB;

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

        /// <summary>
        /// Gets a users informations from the database, and returns it as an User Object.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public User GetLoginDetails(string username)
        {
            User user = new User();

            try
            {
                DB.Open();
                string[][] loginDetails = DB.Query("SELECT * FROM [User] WHERE username = '" + username + "'");

                for (int i = 0; i < loginDetails.Length; i++)
                {
                    user.Id = Convert.ToInt32(loginDetails[0][0]);
                    user.Firstname = Convert.ToString(loginDetails[0][1]);
                    user.Lastname = Convert.ToString(loginDetails[0][2]);
                    user.City = Convert.ToString(loginDetails[0][3]);
                    user.Address = Convert.ToString(loginDetails[0][4]);
                    user.Birthdate = Convert.ToString(loginDetails[0][5]);
                    user.Username = Convert.ToString(loginDetails[0][6]);
                    user.Password = Convert.ToString(loginDetails[0][7]);
                    user.Lastlogin = Convert.ToDateTime(loginDetails[0][8]);
                    user.Userrole = Convert.ToInt32(loginDetails[0][9]);

                    Holder.Instance.LoginDetails = user;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
            }
            return user;
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