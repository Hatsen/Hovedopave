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
        [WebMethod (EnableSession = true)]
        public bool GetLoginDetails(string username, string password)
        {
            HttpContext context = HttpContext.Current;
            bool loggedIn = false;

            switch(username.Substring(0, 2))
            {
                case "te":
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5])) //The fuck...
                    {
                        context.Session["name"] = Holder.Instance.LoginDetails[0][1];
                        context.Session["rank"] = Holder.Instance.LoginDetails[0][6];
                        loggedIn = true;
                    }
                    break;

                case "pa":
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5])) //The fuck...
                    {
                        context.Session["name"] = Holder.Instance.LoginDetails[0][1];
                        loggedIn = true;
                    }
                    break;

                case "st":
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5])) //The fuck...
                    {
                        context.Session["name"] = Holder.Instance.LoginDetails[0][1];
                        loggedIn = true;
                    }
                    break;

                default:
                    loggedIn = false;
                    break;
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
                t.Id = i; t.Firstname = "sssss " + i;
                t.Adress = "sssssssssaasasas" + i;

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
                t.Id = i; t.Firstname = "Hr "+i;
                t.Lastname = "lol" + i;

                listen.Add(t);
            }

           

            return listen;

        }


    }
}
