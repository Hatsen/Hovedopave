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

            switch(username.Substring(0, 2))
            {
                case "te":
                    dh.GetTeacherLogin(username, password);
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5]))
                    {
                        context.Session["name"] = Holder.Instance.LoginDetails[0][1];
                        context.Session["rank"] = Holder.Instance.LoginDetails[0][6];
                        loggedIn = true;
                    }
                    break;

                case "pa":
                    dh.GetParentLogin(username, password);
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5]))
                    {
                        context.Session["name"] = Holder.Instance.LoginDetails[0][1];
                        loggedIn = true;
                    }
                    break;

                case "st":
                    dh.GetStudentLogin(username, password);
                    if (PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails[0][5]))
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
    }
}
