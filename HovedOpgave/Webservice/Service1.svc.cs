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
        DatabaseHandler dh = new DatabaseHandler();

        [WebMethod (EnableSession = true)]
        public bool GetLoginDetails(string username, string password)
        {
            HttpContext context = HttpContext.Current;
            bool loggedIn = false;

            dh.GetLoginDetails(username);
            if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails.Password))
            {
                context.Session["fornavn"] = Holder.Instance.LoginDetails.Firstname;
                context.Session["efternavn"] = Holder.Instance.LoginDetails.Lastname;
                context.Session["userrole"] = Holder.Instance.LoginDetails.Userrole;

                loggedIn = true;
            }
            else
            {
                loggedIn = false;
            }
            return loggedIn;
        }
        /*
        public bool GetLoginDetails(string username, string password)
        {
            HttpContext context = HttpContext.Current;
            bool loggedIn = false;

            switch(username.Substring(0, 2))
            {
                case "te":
                    Holder.Instance.LoginDetails = dh.GetTeacherLogin(username);
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][6])) //The fuck...
                    {
                        context.Session["fornavn"] = Holder.Instance.LoginDetails[0][1];
                        context.Session["efternavn"] = Holder.Instance.LoginDetails[0][2];
                        context.Session["rank"] = Holder.Instance.LoginDetails[0][6];
                        loggedIn = true;
                    }
                    break;

                case "pa":
                    Holder.Instance.LoginDetails = dh.GetParentLogin(username);
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5])) //The fuck...
                    {
                        context.Session["fornavn"] = Holder.Instance.LoginDetails[0][1];
                        context.Session["efternavn"] = Holder.Instance.LoginDetails[0][2];
                        loggedIn = true;
                    }
                    break;

                case "st":
                    Holder.Instance.LoginDetails = dh.GetStudentLogin(username);
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5])) //The fuck...
                    {
                        context.Session["fornavn"] = Holder.Instance.LoginDetails[0][1];
                        context.Session["efternavn"] = Holder.Instance.LoginDetails[0][2];
                        loggedIn = true;
                    }
                    break;

                default:
                    break;
            }
            return loggedIn;
        }
        */



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


    }
}
