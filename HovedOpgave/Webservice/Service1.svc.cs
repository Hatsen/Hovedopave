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

        public int GetUserCount()
        {
            return DatabaseHandler.Instance.GetUserCount();
        }


    }
}
