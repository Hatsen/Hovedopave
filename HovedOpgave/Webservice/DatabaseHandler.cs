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

        public bool CreateAnnouncement(int creator, string header, string message, int groupID, int classID)
        {
            bool success = false;

            try
            {
                DB.Open();
                DB.Exec("INSERT INTO [Announcement] (Creator, Header, Message, GroupId, ClassId) VALUES (" + creator + ", '" + header + "', '" + message + "', " + groupID + ", " + classID + ")");
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            finally
            {
                DB.Close();
            }

            return success;
        }

        public List<Announcement> GetAnnouncements(int groupID)
        {
            List<Announcement> announcements = new List<Announcement>();

            try
            {
                DB.Open();

                string[][] getAnc = DB.Query("SELECT * FROM [Announcement]");

                for (int i = 0; i < getAnc.Length; i++)
                {
                    Announcement anc = new Announcement();

                    anc.ID = Convert.ToInt32(getAnc[i][0]);
                    anc.Creator = Convert.ToInt32(getAnc[i][1]);
                    anc.Header = getAnc[i][2];
                    anc.Message = getAnc[i][3];
                    anc.GroupID = Convert.ToInt32(getAnc[i][4]);

                    if (anc.ClassID == null)
                    {
                        anc.ClassID = 0;
                    }
                    else
                    {
                        anc.ClassID = Convert.ToInt32(getAnc[i][5]);
                    }

                    if (Holder.Instance.Announcements.Contains(anc))
                    {
                        
                    }
                    else
                    {
                        Holder.Instance.Announcements.Add(anc);
                    }
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
                    count = Convert.ToInt32(loginDetails[0][0]) + 1; // recent could be 17 but the new id needs to be 18.
                }

            }
            catch (Exception)
            {
                Debug.Write("fejl!");
            }


            return count;


        }


        #region TeacherCRUD

        public bool InsertTeacher(Teacher teacher)
        {
            bool success = true;

            try
            {
                DB.Open();

                DB.Exec(
                    "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole) " +
                    "VALUES('" + teacher.Firstname + "','" + teacher.Lastname + "','" + teacher.City + "','" + teacher.Address + "','" + teacher.Birthdate + "','" + teacher.Username + "','" + teacher.Password + "','" + teacher.Lastlogin + "'," + teacher.Userrole + ");");
                DB.Exec("INSERT INTO [Teacher] (Id, Rank) VALUES (" + teacher.Id + ", "+teacher.Rank+");");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;
        }
        public bool UpdateTeacher(Teacher teacher)
        {
            bool success = true;

            try
            {
                DB.Open();
                DB.Exec("UPDATE [User] SET Firstname ='"+teacher.Firstname+"', Lastname='"+teacher.Lastname+"', City='"+teacher.City+"', Address='"+teacher.Address+"',"+
                  "Birthdate='"+teacher.Birthdate+"', Username='"+teacher.Username+"', Password='"+teacher.Password+"', Lastlogin ='"+teacher.Lastlogin+"', Userrole="+teacher.Userrole+" WHERE Id="+teacher.Id+";");
                DB.Exec("UPDATE [Teacher] SET [Rank]=" + teacher.Rank + " WHERE Id="+teacher.Id+";");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;
            
        }
        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                DB.Open();

                string[][] getTeachers = DB.Query("SELECT [User].Id, [USER].Firstname, [User].Lastname,[User].City, [User].Address," +
                                                  " [User].Birthdate,[User].Username, [User].Password, [User].Lastlogin, [User].Userrole,  [Teacher].Rank" +
                                                  " FROM [Teacher] INNER JOIN [User] ON  [Teacher].Id=[User].Id ORDER BY [User].Firstname;");

                for (int i = 0; i < getTeachers.Length; i++)
                {
                    Teacher teacher = new Teacher(); 

                    teacher.Id = Convert.ToInt32(getTeachers[i][0]);
                    teacher.Fkuserid = Convert.ToInt32(getTeachers[i][0]);
                    teacher.Firstname = getTeachers[i][1];
                    teacher.Lastname = getTeachers[i][2];
                    teacher.City = getTeachers[i][3];
                    teacher.Address = getTeachers[i][4];
                    teacher.Birthdate = getTeachers[i][5];
                    teacher.Username = getTeachers[i][6];
                    teacher.Password = getTeachers[i][7];
                    if (getTeachers[i][8] == "")
                    {
                        getTeachers[i][8] = DateTime.MinValue.ToString();
                    }
                    teacher.Lastlogin = Convert.ToDateTime(getTeachers[i][8]);
                    teacher.Userrole = Convert.ToInt32(getTeachers[i][9]);
                    teacher.Rank= Convert.ToInt32(getTeachers[i][10]);
                    teachers.Add(teacher);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }
            return teachers;
        }

        #endregion

        #region ParentCRUD

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
        public bool UpdateParent(Parent parent)
        {
            bool success = true;

            try
            {
                DB.Open();
                DB.Exec("UPDATE [User] SET Firstname ='" + parent.Firstname + "', Lastname='" + parent.Lastname + "', City='" + parent.City + "', Address='" + parent.Address + "'," +
                  "Birthdate='" + parent.Birthdate + "', Username='" + parent.Username + "', Password='" + parent.Password + "', Lastlogin ='" + parent.Lastlogin + "', Userrole=" + parent.Userrole + " WHERE Id=" + parent.Id + ";");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;

        }
        public List<Parent> GetParents()
        {
            List<Parent> parents = new List<Parent>();

            try
            {
                DB.Open();

                string[][] getTeachers = DB.Query("SELECT [User].Id, [USER].Firstname, [User].Lastname,[User].City, [User].Address," +
                                                  " [User].Birthdate,[User].Username, [User].Password, [User].Lastlogin, [User].Userrole" +
                                                  " FROM [Parent] INNER JOIN [User] ON  [Parent].Id=[User].Id ORDER BY [User].Firstname;");

                for (int i = 0; i < getTeachers.Length; i++)
                {
                    Parent parent = new Parent();

                    parent.Id = Convert.ToInt32(getTeachers[i][0]);
                    parent.Fkuserid = Convert.ToInt32(getTeachers[i][0]);
                    parent.Firstname = getTeachers[i][1];
                    parent.Lastname = getTeachers[i][2];
                    parent.City = getTeachers[i][3];
                    parent.Address = getTeachers[i][4];
                    parent.Birthdate = getTeachers[i][5];
                    parent.Username = getTeachers[i][6];
                    parent.Password = getTeachers[i][7];
                    if (getTeachers[i][8] == "")
                    {
                        getTeachers[i][8] = DateTime.MinValue.ToString();
                    }
                    parent.Lastlogin = Convert.ToDateTime(getTeachers[i][8]);
                    parent.Userrole = Convert.ToInt32(getTeachers[i][9]);
                    parents.Add(parent);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }
            return parents;
        }

        #endregion

        #region StudentCRUD

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
                int b = DB.Exec("INSERT INTO [Student] (Id, fk_ClassId) VALUES (" + student.Id + "," + student.FkClassid + ");");

                if (a == -1 || b == -1)
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

        #endregion

    }
}