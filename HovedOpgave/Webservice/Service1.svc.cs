using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;
//using System.Services;
using System.ServiceModel.Web;
using System.Text;
using Crypto;
using Webservice.DB;
using Webservice.Extended;

namespace Webservice
{
    public class Service1 : IService1
    {

        public bool GetLoginDetails(string username, string password)
        {
            HttpContext context = HttpContext.Current;
            bool loggedIn = false;

            DatabaseHandler.Instance.GetLoginDetails(username);
            if (Holder.Instance.LoginDetails != null && PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails.Password) == true)
            {
                loggedIn = true;
            }
            else
            {
                loggedIn = false;
            }
            return loggedIn;
        }

        public string GetUserDetails(int number)
        {
            string[] userDetails = new string[6];

            userDetails[0] = Convert.ToString(Holder.Instance.LoginDetails.Id);
            userDetails[1] = Holder.Instance.LoginDetails.Firstname;
            userDetails[2] = Holder.Instance.LoginDetails.Lastname;
            userDetails[3] = Holder.Instance.LoginDetails.Username;
            userDetails[4] = Convert.ToString(Holder.Instance.LoginDetails.Userrole);

            switch (Holder.Instance.LoginDetails.Userrole) //Her skal vi finde ud af hvilken klasse personen tilhører.
            {
                case 1: //Skoleleder
                    userDetails[5] = "0";
                    break;

                case 2: //Teacher

                    break;

                case 3: //Vikar

                    break;

                case 4: //Parent
                    userDetails[5] = Convert.ToString(FindParentsChildren(Holder.Instance.LoginDetails.Id));
                    break;

                case 5: //Student

                    break;
            }

            return userDetails[number];
        }

        public List<int> FindParentsChildren(int id)
        {
            return DatabaseHandler.Instance.FindParentsChildren(id);
        }

        public bool CreateAnnouncement(int creator, string header, string message, int groupID, int classID)
        {
            if (DatabaseHandler.Instance.CreateAnnouncement(creator, header, message, groupID, classID) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Announcement> GetAnnouncements(int groupID, int classID)
        {
            DatabaseHandler.Instance.GetAnnouncements(groupID);
            List<Announcement> announcements = new List<Announcement>();

            foreach (Announcement anc in Holder.Instance.Announcements)
            {
                if (groupID == 1 || groupID == anc.GroupID || classID == anc.ClassID || groupID == 0)
                {
                    announcements.Add(anc); //Hvis han er skoleleder, gruppen passer til ham, klassen passer til ham eller beskeden er til alle, skal den tilføjes til listen.
                }
            }

            return announcements;
        }

        public bool ChangePassword(int id, string oldPass, string newPass, string confirmPass)
        {
            bool success = false;

            if (Holder.Instance.LoginDetails.Id == id)
            {
                if (newPass.Equals(confirmPass) && PasswordHash.ValidatePassword(oldPass, Holder.Instance.LoginDetails.Password) == true)
                {
                    DatabaseHandler.Instance.ChangePassword(id, PasswordHash.CreateHash(confirmPass));
                    success = true;
                }
            }
            return success;
        }


        #region TeacherMethods

        /*    public Teacher GetTeacher()
        {
            Teacher t = new Teacher();
            t.Id = 1; t.Firstname = "Hr Jensen";

            return t;
        }*/
        public List<TeacherEx> GetTeachers()
        {
            List<TeacherEx> listOfTeacherExs = DatabaseHandler.Instance.GetTeachers();
            List<ClassEx> listOfClasses = DatabaseHandler.Instance.GetClasses();
            listOfTeacherExs = DatabaseHandler.Instance.GetTeachers();

            foreach (TeacherEx teacherEx in listOfTeacherExs)
            {
                foreach (ClassEx classEx in listOfClasses)
                {
                    if (classEx.Fkteacherid == teacherEx.Id)
                    {
                        teacherEx.ClassList.Add(classEx);
                    }
                }
            }
            return listOfTeacherExs;
        }


        /*    public int GetMostRecentUserId()
            {
                return DatabaseHandler.Instance.GetMostRecentUserId();
            }*/


        public bool InsertTeacher(TeacherEx teacher)
        {
            bool success = false;

            if (teacher.Id != 0) // update
            {
                success = DatabaseHandler.Instance.UpdateTeacher(teacher);
            }

            else
            {
                success = DatabaseHandler.Instance.InsertTeacher(teacher); // will insert into User and Teacher.
            }
            return success;
        }

        public string DeleteUser(int id)
        {
            string returnMessage = "";
            int userrole = DatabaseHandler.Instance.GetTheUserrole(id);
            string tableName = "";
            // delete user. Du har user tabel og evt. teacher, student eller parent.

            if (userrole == (int)EnumsWeb.Userrole.Teacher)
            {
                tableName = "Teacher";
                bool result = DatabaseHandler.Instance.DeleteUser(id, tableName);

                if (!result && tableName == "Teacher")
                {
                    returnMessage =
                        "Før du kan fjerne teahcer skal du fjerne klasse eller klasser, der er tilknyttet underviseren." +
                        "Underviseren er ikke blevet slettet." +
                        "Du bedes kontakte support.";
                }
            }

            if (userrole == (int)EnumsWeb.Userrole.Parent)
            {
                tableName = "Parent";
                bool result = DatabaseHandler.Instance.DeleteUser(id, tableName);

                if (!result && tableName == "Parent")
                {
                    returnMessage =
                        "Noget gik galt under sletningen af forældre. Forældren er ikke blevet slettet." +
                        "Du bedes kontakte support.";
                }

            }


            if (userrole == (int)EnumsWeb.Userrole.Student)
            {
                tableName = "Student";
                bool result = DatabaseHandler.Instance.DeleteUser(id, tableName);

                if (!result && tableName == "Student")
                {
                    returnMessage =
                        "Noget gik galt under sletningen af elev. Eleven er ikke blevet slettet." +
                        "Du bedes kontakte support.";
                }

            }

            return returnMessage;
        }

        #endregion



        #region ParentMethods

        public bool CreateParent(ParentEx parent)
        {

            return true;
        }

        public bool InsertParent(ParentEx parent)
        {

            bool success = false;

            if (parent.Id != 0) // update
            {
                success = DatabaseHandler.Instance.UpdateParent(parent);
            }

            else
            {
                //int recentId = DatabaseHandler.Instance.GetMostRecentUserId();

                // if (recentId != -1)
                //{
                /*   parent.Id = recentId;
                   parent.Fkuserid = recentId;
                   parent.Username = "Pa_" + recentId;*/
                success = DatabaseHandler.Instance.InsertParent(parent);
                //}
            }
            return success;
        }


        public List<ParentEx> GetParents()
        {
            // søg efter children i studentparent table
            //ParentEx.Children = FindParentsChildren();
            List<ParentEx> parentExlist = new List<ParentEx>();
            parentExlist = DatabaseHandler.Instance.GetParents();

            foreach (ParentEx parent in parentExlist)
            {
              /*  List<Student> id = DatabaseHandler.Instance.FindParentsChildren(parent.Id);
                if (id.Count != 0)
                {
                    foreach (int i in id)
                    {
                        parent.ChildrenIdList.Add(i);
                    }
                }*/

            }

            return parentExlist;
        }


        /* public bool DeleteParent(int id)
         {

             return DatabaseHandler.Instance.DeleteParent(id);
         }*/

        #endregion

        #region StudentMethods


        public bool InsertStudent(Student student)
        {

            bool success = false;

            if (student.Id != 0)
            {
                success = DatabaseHandler.Instance.UpdateStudent(student);
            }
            else
            {
                //int recentId = DatabaseHandler.Instance.GetMostRecentUserId();

                // if (recentId != -1)
                //{
                /*  student.Id = recentId;
                  student.Fkuserid = recentId;
                  student.Username = "St_" + recentId;*/
                success = DatabaseHandler.Instance.InsertStudent(student); // will insert into User and Teacher.
                //  }
            }
            return success;

        }


        public List<Student> GetStudents()
        {


            return DatabaseHandler.Instance.GetStudents();

        }

        public bool DeleteStudent(int id)
        {

            return DatabaseHandler.Instance.DeleteStudent(id);
        }

        #endregion



        #region Class


        public List<ClassEx> GetClasses()
        {
            List<ClassEx> listOfClassExs = new List<ClassEx>();
            List<Student> listOfStudents = DatabaseHandler.Instance.GetStudents();
            // her bliver studerende sat ind i listen:
            listOfClassExs = DatabaseHandler.Instance.GetClasses();

            foreach (ClassEx classEx in listOfClassExs)
            {
                foreach (Student student in listOfStudents)
                {
                    if (student.FkClassid == classEx.Id)
                    {
                        classEx.StudentsList.Add(student);
                    }
                }
            }

            return listOfClassExs;
        }

        public bool InsertClass(ClassEx theClass)
        {
            bool success;

            if (theClass.Id != 0) // update
            {
                success = DatabaseHandler.Instance.UpdateClass(theClass);
            }

            else
            {
                success = DatabaseHandler.Instance.InsertClass(theClass);
            }

            return success;
        }

        public bool DeleteClass(int classId)
        {
            return DatabaseHandler.Instance.DeleteClass(classId);
        }

        #endregion


    }
}
