using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Webservice.DB;
using Webservice.Extended;

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
                    anc.ClassID = Convert.ToInt32(getAnc[i][5]);

                    //if (Holder.Instance.Announcements.Any(announcement => announcement.ID != anc.ID))
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

        public string GetAnnouncementCreator(int id)
        {
            string name = "";
            try
            {
                DB.Open();
                string[][] getCreator = DB.Query("SELECT * FROM [user] WHERE id =" + id);
                name = getCreator[0][1] + " " + getCreator[0][2];
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
            }

            return name;
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

        public bool ChangePassword(int id, string password)
        {
            bool success = false;

            try
            {
                DB.Open();
                DB.Exec("UPDATE [user] SET Password = '" + password + "' WHERE Id = " + id);
                success = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
            }
            return success;
        }

        /*public int GetMostRecentUserId()
        {
            string statement = "SELECT MAX(Id) AS RecentId FROM [User];"; // selects the highest id therefor the most recent generated id.
            int count = -1;

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
        }*/


        #region TeacherCRUD

        public bool InsertTeacher(Teacher teacher)
        {
            bool success = true;
            int result;


            DB.Open();
            // this works very well !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            result = DB.Exec("BEGIN TRANSACTION BEGIN TRY DECLARE @Id INT INSERT INTO [User](Firstname, Lastname,City,Address,Birthdate,Username,Password,Lastlogin,Userrole,PhoneNumber,fk_SchoolId)" +
                "VALUES('" + teacher.Firstname + "','" + teacher.Lastname + "','" + teacher.City + "','" + teacher.Address + "','" + teacher.Birthdate + "','" + 1 + "','" + teacher.Password + "','" + teacher.Lastlogin.ToString() + "'," + teacher.Userrole + ", " + teacher.Phonenumber + "," + 1 + ");" +
                "  SET @Id = SCOPE_IDENTITY() UPDATE [User] SET [User].Username='Te_'+CAST(@Id AS NVARCHAR) WHERE [User].Id=@Id; INSERT INTO [Teacher](Id)VALUES(@Id) COMMIT TRANSACTION   END TRY  BEGIN CATCH  ROLLBACK TRANSACTION  END CATCH");

            /*  BEGIN TRANSACTION
BEGIN TRY
DECLARE @Id INT
INSERT INTO [User](Firstname, Lastname,City,Address,Birthdate,Username,Password,Lastlogin,Userrole,PhoneNumber,fk_SchoolId)
VALUES('1','1','1','1','1','1','1','1',1,111,1)
SET @Id = SCOPE_IDENTITY()
INSERT INTO [Parent](Id)VALUES(@Id)
COMMIT TRANSACTION 
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH*/


            /*  DB.Exec(
                  "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole, PhoneNumber, fk_SchoolId) " +
                  "VALUES('" + teacher.Firstname + "','" + teacher.Lastname + "','" + teacher.City + "','" + teacher.Address + "','" + teacher.Birthdate + "','" + teacher.Username + "','" + teacher.Password + "','" + teacher.Lastlogin.ToString() + "'," + teacher.Userrole + ", " + teacher.Phonenumber + "," + 1 + ");");
              DB.Exec("INSERT INTO [Teacher] (Id, Rank) VALUES (" + teacher.Id + ", " + teacher.Rank + ");");
              */
            /*   id = DB.ExecAndGetId("INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole, PhoneNumber, fk_SchoolId) " +
                   "VALUES('" + teacher.Firstname + "','" + teacher.Lastname + "','" + teacher.City + "','" + teacher.Address + "','" + teacher.Birthdate + "','" + teacher.Username + "','" + teacher.Password + "','" + teacher.Lastlogin.ToString() + "'," + teacher.Userrole + ", " + teacher.Phonenumber + "," + 1 + ");");
               teacher.Id = id;
               DB.Exec("INSERT INTO [Teacher] (Id, Rank) VALUES (" + teacher.Id + ", " + teacher.Rank + ");");*/


            if (result == -1)
            {
                success = false;
            }
            return success;
        }
        public bool UpdateTeacher(TeacherEx teacher)
        {
            bool success = true;

            try
            {
                DB.Open();
                DB.Exec("UPDATE [User] SET Firstname ='" + teacher.Firstname + "', Lastname='" + teacher.Lastname + "', City='" + teacher.City + "', Address='" + teacher.Address + "'," +
                  "Birthdate='" + teacher.Birthdate + "', Username='" + teacher.Username + "', Password='" + teacher.Password + "', Lastlogin ='" + teacher.Lastlogin.ToString() + "', Userrole=" + teacher.Userrole + ", PhoneNumber=" + teacher.Phonenumber + " WHERE Id=" + teacher.Id + ";");
                DB.Exec("UPDATE [Teacher] SET [Rank]=" + teacher.Rank + " WHERE Id=" + teacher.Id + ";");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;

        }
        public List<TeacherEx> GetTeachers()
        {
            List<TeacherEx> teachers = new List<TeacherEx>();

            try
            {
                DB.Open();

                string[][] getTeachers = DB.Query("SELECT [User].Id, [USER].Firstname, [User].Lastname,[User].City, [User].Address," +
                                                  " [User].Birthdate,[User].Username, [User].Password, [User].Lastlogin, [User].Userrole, [User].PhoneNumber, [Teacher].Rank" +
                                                  " FROM [Teacher] INNER JOIN [User] ON  [Teacher].Id=[User].Id ORDER BY [User].Firstname;");

                for (int i = 0; i < getTeachers.Length; i++)
                {
                    TeacherEx teacher = new TeacherEx();

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
                    if (getTeachers[i][10] == "")
                    {
                        getTeachers[i][10] = "-1";
                    }
                    teacher.Phonenumber = Convert.ToInt32(getTeachers[i][10]);
                    teacher.Rank = Convert.ToInt32(getTeachers[i][11]);
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

        public bool DeleteUser(int id, string tableName)
        {

            int result;
            bool success = true;

            DB.Open();

            //transaktion her vil gå ind og lave en 
            result =
                DB.Exec("BEGIN TRANSACTION BEGIN TRY DELETE FROM [" + tableName + "] WHERE Id = " + id + " DELETE FROM [User] WHERE Id=" + id + " COMMIT" +
                " TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH");

            // det kan ske at der ikke bliver påvirket rækker hvis den brækker sig. Det er fordi den laver rollback og derfor ikke påvirke nogle rækker.
            if (result == -1 || result == 0)
            {
                success = false;
            }

            return success;

        }

        #endregion

        #region ParentCRUD

        public int InsertParent(Parent parent)
        {
            bool success = true;
            int result;

          
            DB.Open();

            string[][] getTeachers = DB.Query("BEGIN TRANSACTION BEGIN TRY DECLARE @Id INT INSERT INTO [User](Firstname, Lastname,City,Address,Birthdate,Username,Password,Lastlogin,Userrole,PhoneNumber,fk_SchoolId)" +
                "VALUES('" + parent.Firstname + "','" + parent.Lastname + "','" + parent.City + "','" + parent.Address + "','" + parent.Birthdate + "','" + 1 + "','" + parent.Password + "','" + parent.Lastlogin.ToString() + "'," + parent.Userrole + ", " + parent.Phonenumber + "," + 1 + ");" +
                "  SET @Id = SCOPE_IDENTITY() UPDATE [User] SET [User].Username='Pa_'+CAST(@Id AS NVARCHAR) WHERE [User].Id=@Id; INSERT INTO [Parent](Id)VALUES(@Id) SELECT @Id  COMMIT TRANSACTION   END TRY  BEGIN CATCH  ROLLBACK TRANSACTION  END CATCH");


            int generatedId = Convert.ToInt32(getTeachers[0][0]);


            return generatedId;
        }
        public bool UpdateParent(Parent parent)
        {
            bool success = true;
            int result;

            DB.Open();
            result = DB.Exec("UPDATE [User] SET Firstname ='" + parent.Firstname + "', Lastname='" + parent.Lastname + "', City='" + parent.City + "', Address='" + parent.Address + "'," +
             "Birthdate='" + parent.Birthdate + "', Username='" + parent.Username + "', Password='" + parent.Password + "', Lastlogin ='" + parent.Lastlogin.ToString() + "', Userrole=" + parent.Userrole + ", PhoneNumber=" + parent.Phonenumber + " WHERE Id=" + parent.Id + ";");

            if (result == -1)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;

        }
        public List<ParentEx> GetParents()
        {
            List<ParentEx> parents = new List<ParentEx>();

            try
            {
                DB.Open();

                string[][] getTeachers = DB.Query("SELECT [User].Id, [USER].Firstname, [User].Lastname,[User].City, [User].Address," +
                                                  " [User].Birthdate,[User].Username, [User].Password, [User].Lastlogin, [User].Userrole, [User].PhoneNumber" +
                                                  " FROM [Parent] INNER JOIN [User] ON  [Parent].Id=[User].Id ORDER BY [User].Firstname;");

                for (int i = 0; i < getTeachers.Length; i++)
                {
                    ParentEx parent = new ParentEx();

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
                    if (getTeachers[i][10] == "")
                    {
                        getTeachers[i][10] = "-1";
                    }
                    parent.Phonenumber = Convert.ToInt32(getTeachers[i][10]);
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
        /* public bool DeleteParent(int id)
         {

             return true;
         }*/



        public List<Student> FindParentsChildren(int id)
        {
            List<Student> childrenList = new List<Student>();

            try
            {
                DB.Open(); //SELECT fk_StudentId, fk_ParentId FROM [StudentParent] INNER JOIN [Parent] ON Parent.Id = StudentParent.fk_ParentId
                string[][] getChildren = DB.Query("SELECT * FROM StudentParent");

                for (int i = 0; i < getChildren.Length; i++)
                {
                    if (Convert.ToInt32(getChildren[i][1]) == id)
                    {
                        int studentID = Convert.ToInt32(getChildren[i][0]);
                        string[][] getStudentInfo = DB.Query("SELECT * FROM [User] WHERE Id=" + studentID);
                        string[][] getClass = DB.Query("SELECT * from [Student] WHERE Id = " + studentID);

                        Student student = new Student();
                        student.Id = Convert.ToInt32(getStudentInfo[i][0]);
                        student.Firstname = getStudentInfo[i][1];
                        student.Lastname = getStudentInfo[i][2];
                        student.City = getStudentInfo[i][3];
                        student.Address = getStudentInfo[i][4];
                        student.Birthdate = getStudentInfo[i][5];
                        student.Username = getStudentInfo[i][6];
                        student.Password = getStudentInfo[i][7];
                        student.Lastlogin = Convert.ToDateTime(getStudentInfo[i][8]);
                        student.Userrole = Convert.ToInt32(getStudentInfo[i][9]);
                        student.Phonenumber = Convert.ToInt32(getStudentInfo[i][10]);
                        student.FkClassid = Convert.ToInt32(getClass[i][1]);

                        childrenList.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            finally
            {
                DB.Close();
            }
            return childrenList;
        }





        #endregion

        #region StudentCRUD

        public bool InsertStudent(Student student)
        {
            bool success = true;
            int result = 0;
            try
            {
                DB.Open();

                // lav en tranaction.

                result = DB.Exec("BEGIN TRANSACTION BEGIN TRY DECLARE @Id INT INSERT INTO [User](Firstname, Lastname,City,Address,Birthdate,Username,Password,Lastlogin,Userrole,PhoneNumber,fk_SchoolId)" +
                 "VALUES('" + student.Firstname + "','" + student.Lastname + "','" + student.City + "','" + student.Address + "','" + student.Birthdate + "','" + 1 + "','" + student.Password + "','" + student.Lastlogin.ToString() + "'," + student.Userrole + ", " + student.Phonenumber + "," + 1 + ");" +
                 "  SET @Id = SCOPE_IDENTITY() UPDATE [User] SET [User].Username='St_'+CAST(@Id AS NVARCHAR) WHERE [User].Id=@Id; INSERT INTO [Student](Id, fk_ClassId)VALUES(@Id," + student.FkClassid + ") COMMIT TRANSACTION   END TRY  BEGIN CATCH  ROLLBACK TRANSACTION  END CATCH");




                /*  int a = DB.Exec(
                       "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole) " +
                       "VALUES('" + student.Firstname + "','" + student.Lastname + "','" + student.City + "','" + student.Address + "','" + student.Birthdate + "','" + student.Username + "','" + student.Password + "','" + student.Lastlogin.ToString() + "'," + student.Userrole + ");");
                  int b = DB.Exec("INSERT INTO [Student] (Id, fk_ClassId) VALUES (" + student.Id + "," + student.FkClassid + ");");*/

                if (result == -1)
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

        public bool UpdateStudent(Student student)
        {
            bool success = true;
            int result;

            DB.Open();
            result = DB.Exec("BEGIN TRANSACTION BEGIN TRY UPDATE [User] SET Firstname ='" + student.Firstname + "', Lastname='" + student.Lastname + "', City='" + student.City + "', Address='" + student.Address + "'," +
             "Birthdate='" + student.Birthdate + "', Username='" + student.Username + "', Password='" + student.Password + "', Lastlogin ='" + student.Lastlogin.ToString() + "', Userrole=" + student.Userrole + ", PhoneNumber=" + student.Phonenumber + " WHERE Id =" + student.Id + " UPDATE [Student] SET fk_ClassId=" + student.FkClassid + " WHERE Id=" + student.Id + "  COMMIT TRANSACTION END TRY  BEGIN CATCH  ROLLBACK TRANSACTION  END CATCH");

            if (result == -1)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;
        }

        public List<Student> GetStudents()
        {
            List<Student> parents = new List<Student>();

            try
            {
                DB.Open();

                string[][] getTeachers = DB.Query("SELECT [User].Id, [USER].Firstname, [User].Lastname,[User].City, [User].Address," +
                                                  " [User].Birthdate,[User].Username, [User].Password, [User].Lastlogin, [User].Userrole, [User].PhoneNumber, [Student].fk_ClassId" +
                                                  " FROM [Student] INNER JOIN [User] ON  [Student].Id=[User].Id ORDER BY [User].Firstname;");

                for (int i = 0; i < getTeachers.Length; i++)
                {
                    Student parent = new Student();

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
                    if (getTeachers[i][10] == "")
                    {
                        getTeachers[i][10] = "-1";
                    }
                    parent.Phonenumber = Convert.ToInt32(getTeachers[i][10]);
                    parent.FkClassid = Convert.ToInt32(getTeachers[i][11]);
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

        public bool DeleteStudent(int id)
        {

            return true;
        }

        #endregion

        #region ClassCRUD

        public bool InsertClass(ClassEx theClass)
        {
            bool success = true;
            int result;

            DB.Open();
            // this works very well !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            result = DB.Exec("BEGIN TRANSACTION BEGIN TRY INSERT INTO [Class](Name, fk_TeacherId, fk_SchoolId)" +
                "VALUES('" + theClass.Name + "'," + theClass.Fkteacherid + "," + 1 + ");" +
                " COMMIT TRANSACTION   END TRY  BEGIN CATCH  ROLLBACK TRANSACTION  END CATCH");


            if (result == -1)
            {

                success = false;

            }


            return success;
        }

        public bool UpdateClass(ClassEx theClass)
        {
            bool success = true;

            try
            {
                DB.Open();
                DB.Exec("UPDATE [Class] SET Name ='" + theClass.Name + "', fk_TeacherId=" + theClass.Fkteacherid + " WHERE Id=" + theClass.Id + ";");
            }
            catch (Exception)
            {
                Debug.Write("Fejl!");
                success = false;
            }

            return success;

        }

        public List<ClassEx> GetClasses()
        {
            List<ClassEx> classes = new List<ClassEx>();

            try
            {
                DB.Open();

                string[][] getClasses = DB.Query("SELECT [Class].Id, [Class].Name, [Class].fk_TeacherId,[Class].fk_SchoolId" +
                                                  " FROM [Class]");

                for (int i = 0; i < getClasses.Length; i++)
                {
                    ClassEx theClass = new ClassEx();
                    theClass.Id = Convert.ToInt32(getClasses[i][0]);
                    theClass.Name = (getClasses[i][1]);
                    theClass.Fkteacherid = Convert.ToInt32((getClasses[i][2]));
                    theClass.Fkschoolid = Convert.ToInt32(getClasses[i][3]);
                    classes.Add(theClass);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }
            return classes;
        }

        public bool DeleteClass(int classId)
        {

            int result;
            bool success = true;

            DB.Open();

            //transaktion her vil gå ind og lave en 
            result =
                DB.Exec("BEGIN TRANSACTION BEGIN TRY DELETE FROM [Class] WHERE Id = " + classId + " COMMIT" +
                " TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH");

            // det kan ske at der ikke bliver påvirket rækker hvis den brækker sig. Det er fordi den laver rollback og derfor ikke påvirke nogle rækker.
            if (result == -1 || result == 0)
            {
                success = false;
            }

            return success;
        }

        #endregion

        public int GetTheUserrole(int id)
        {
            int userrole = -1;

            try
            {
                DB.Open();

                string[][] getTableName = DB.Query("SELECT [User].Userrole FROM [User] WHERE [User].Id=" + id);

                for (int i = 0; i < getTableName.Length; i++)
                {
                    userrole = Convert.ToInt32(getTableName[i][0]);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }

            return userrole;
        }


        public bool InsertIntoStudentParent(StudentParent studentParent)
        {
            bool success = true;
            int result = 0;
            try
            {
                DB.Open();

                // lav en tranaction.

                result = DB.Exec("BEGIN TRANSACTION BEGIN TRY INSERT INTO [StudentParent](fk_StudentId, fk_ParentId)" +
                 "VALUES(" + studentParent.Fkstudentid + "," + studentParent.Fkparentid + "); COMMIT TRANSACTION END TRY  BEGIN CATCH  ROLLBACK TRANSACTION  END CATCH");




                /*  int a = DB.Exec(
                       "INSERT INTO [User] (Firstname, Lastname, City, Address, Birthdate, Username, Password, Lastlogin, Userrole) " +
                       "VALUES('" + student.Firstname + "','" + student.Lastname + "','" + student.City + "','" + student.Address + "','" + student.Birthdate + "','" + student.Username + "','" + student.Password + "','" + student.Lastlogin.ToString() + "'," + student.Userrole + ");");
                  int b = DB.Exec("INSERT INTO [Student] (Id, fk_ClassId) VALUES (" + student.Id + "," + student.FkClassid + ");");*/

                if (result == -1)
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