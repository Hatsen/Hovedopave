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
       // DatabaseHandler databaseHandler = new DatabaseHandler();

        [WebMethod (EnableSession = true)]
        public bool GetLoginDetails(string username, string password)
        {
            HttpContext context = HttpContext.Current;
            bool loggedIn = false;

            DatabaseHandler.Instance.GetLoginDetails(username);
            if (Holder.Instance.LoginDetails != null && PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails.Password) == true)
            {
                try
                {
                    context.Session["firstname"] = Holder.Instance.LoginDetails.Firstname;
                    context.Session["lastname"] = Holder.Instance.LoginDetails.Lastname;
                    context.Session["username"] = Holder.Instance.LoginDetails.Username;
                    context.Session["userrole"] = Holder.Instance.LoginDetails.Userrole;
                    loggedIn = true;
                }
                catch (Exception ex)
                {
                    loggedIn = false;
                }
            }
            else
            {
                loggedIn = false;
            }
            return loggedIn;
        }

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

        public List<Student> GetStudents()
        {
            List<Student> listen = new List<Student>();

            for (int i = 0; i < 100; i++)
            {
                Student t = new Student();
                t.Id = i;
                t.Fkuserid = i;
                t.Firstname = "sssss " + i;
                t.Address = "sssssssssaasasas" + i;

                listen.Add(t);
            }
            return listen;
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
               // teacher.Username = "Te_" + recentId;
                success = DatabaseHandler.Instance.InsertTeacher(teacher); // will insert into User and Teacher.
            }
            return success;
        }

        public string GetUserDetails(int number)
        {
            string[] userInformations = new string[5];

            userInformations[0] = Convert.ToString(Holder.Instance.LoginDetails.Id);
            userInformations[1] = Holder.Instance.LoginDetails.Firstname;
            userInformations[2] = Holder.Instance.LoginDetails.Lastname;
            userInformations[3] = Holder.Instance.LoginDetails.Username;
            userInformations[4] = Convert.ToString(Holder.Instance.LoginDetails.Userrole);

            Holder.Instance.UserDetails = userInformations;

            return userInformations[number].ToString();
        }

        public bool CreateAnnounement(string announcement, int group)
        {

        }
    }
}
