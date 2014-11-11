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

        public string GetUserDetails (int number)
        {
            string[] userDetails = new string[5];

            userDetails[0] = Convert.ToString(Holder.Instance.LoginDetails.Id);
            userDetails[1] = Holder.Instance.LoginDetails.Firstname;
            userDetails[2] = Holder.Instance.LoginDetails.Lastname;
            userDetails[3] = Holder.Instance.LoginDetails.Username;
            userDetails[4] = Convert.ToString(Holder.Instance.LoginDetails.Userrole);

            return userDetails[number];
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
                if (groupID <= anc.GroupID || classID == anc.ClassID)
                {
                    announcements.Add(anc);
                }
            }

            return announcements;
        }

        //lsj
        public bool CreateTeacher()
        {
            return true;
        }

        public Teacher GetTeacher()
        {
            Teacher t = new Teacher();
            t.Id = 1; t.Firstname = "Hr Jensen";

            return t;
        }


        public List<Teacher> GetTeachers()
        {
            List<Teacher> listen = new List<Teacher>();


            for (int i = 0; i < 100; i++)
            {
                Teacher t = new Teacher();
                t.Id = i;
                t.Fkuserid = i;
                t.Firstname = "Hr "+i;
                t.Lastname = "lol" + i;

                listen.Add(t);
            }
            return listen;


           return DatabaseHandler.Instance.GetTeachers();
        }

        public int GetMostRecentUserId()
        {
            return DatabaseHandler.Instance.GetMostRecentUserId();
        }

        public bool InsertTeacher(Teacher teacher)
        {

            bool success = false;

            int recentId =  DatabaseHandler.Instance.GetMostRecentUserId();

            if (recentId != -1)
            {
                teacher.Id = recentId;
                teacher.Fkuserid = recentId;
                teacher.Username = "Te_" + recentId;
                success = DatabaseHandler.Instance.InsertTeacher(teacher); // will insert into User and Teacher.
            }

            return success;

        }

        #region ParentMethods



        public bool InsertParent(Parent parent)
        {

            bool success = false;

            int recentId = DatabaseHandler.Instance.GetMostRecentUserId();

            if (recentId != -1)
            {
                parent.Id = recentId;
                parent.Fkuserid = recentId;
                parent.Username = "Pa_" + recentId;
                success = DatabaseHandler.Instance.InsertParent(parent); // will insert into User and Teacher.
            }

            return success;

        }


        public List<Parent> GetParents()
        {
            List<Parent> listen = new List<Parent>();


            for (int i = 0; i < 100; i++)
            {
                Parent t = new Parent();
                t.Id = i;
                t.Fkuserid = i;
                t.Firstname = "Hr " + i;
                t.Lastname = "lol" + i;

                listen.Add(t);
            }
            return listen;
        }


        #endregion

        #region StudentMethods



        public bool InsertStudent(Student student)
        {

            bool success = false;

            int recentId = DatabaseHandler.Instance.GetMostRecentUserId();

            if (recentId != -1)
            {
                student.Id = recentId;
                student.Fkuserid = recentId;
                student.Username = "St_" + recentId;
                success = DatabaseHandler.Instance.InsertStudent(student); // will insert into User and Teacher.
            }

            return success;

        }


        public List<Student> GetStudents()
        {
            List<Student> listen = new List<Student>();


            for (int i = 0; i < 100; i++)
            {
                Student t = new Student();
                t.Id = i;
                t.Fkuserid = i;
                t.Firstname = "Hr " + i;
                t.Lastname = "lol" + i;

                listen.Add(t);
            }
            return listen;
        }


        #endregion



    }
}
