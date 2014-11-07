using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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


        public int GetMostRecentUserId()
        {
            string statement = "SELECT MAX(Id) AS RecentId FROM [User];"; // selects the highest id therefor the most recent generated id.
            int count = -1;
            /*
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(statement, connection))
                {
                    connection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            */
            try
            {
                DB.Open();
                string[][] loginDetails = DB.Query("SELECT MAX(Id) FROM [User];");


                for (int i = 0; i < loginDetails.Length; i++)
                {
                    count = Convert.ToInt32(loginDetails[0][0])+1; // recent could be 17 but the new id needs to be 18.
                }

            }
            catch (Exception)
            {
                Debug.Write("fejl!");
            }


            return count;


        }



        public bool InsertTeacher(Teacher teacher)
        {
            bool success = true;

            try
            {
                DB.Open();

                DB.Exec(
                    "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole) " +
                    "VALUES('" + teacher.Firstname + "','" + teacher.Lastname + "','" + teacher.City + "','" + teacher.Address + "','" + teacher.Birthdate + "','" + teacher.Username + "','" + teacher.Password + "','" + teacher.Lastlogin + "'," + teacher.Userrole + ");");
                DB.Exec("INSERT INTO [Teacher] (Id) VALUES (" + teacher.Id + ");");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }




            return success;
        }

       /* public List<Teacher> GetTeachers()
        {
           List<Teacher> announcements = new List<Teacher>();

            try
            {
                DB.Open();

                string[][] getAnc = DB.Query("SELECT * FROM [");

                for (int i = 0; i < getAnc.Length; i++)
                {
                    Teacher anc = new Teacher();

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
        }*/



        public bool InsertParent(Parent parent)
        {
            bool success = true;

            try
            {
                DB.Open();

                DB.Exec(
                    "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole) " +
                    "VALUES('" + parent.Firstname + "','" + parent.Lastname + "','" + parent.City + "','" + parent.Address + "','" + parent.Birthdate + "','" + parent.Username + "','" + parent.Password + "','" + parent.Lastlogin + "'," + parent.Userrole + ");");
                DB.Exec("INSERT INTO [Parent] (Id) VALUES (" + parent.Id + ");");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }




            return success;
        }






        public bool InsertStudent(Student student)
        {
            bool success = true;

            try
            {
                DB.Open();
                
                // lav en tranaction.

               int a = DB.Exec(
                    "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole) " +
                    "VALUES('" + student.Firstname + "','" + student.Lastname + "','" + student.City + "','" + student.Address + "','" + student.Birthdate + "','" + student.Username + "','" + student.Password + "','" + student.Lastlogin + "'," + student.Userrole + ");");
              int b =  DB.Exec("INSERT INTO [Student] (Id, fk_ClassId) VALUES (" + student.Id+"," + student.FkClassid+ ");");

                if (a==-1||b==-1)
                {
                    throw new Exception();
                }
            }
            catch (SqlException sqlException)
            {
                Debug.Write(sqlException.ToString());
                success = false;
            }




            return success;
        }

    }
}