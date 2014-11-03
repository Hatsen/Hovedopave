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
        [WebMethod (EnableSession = true)]
        public bool GetLoginDetails(string username, string password)
        {
            HttpContext context;

            switch(username.Substring(0, 2))
            {
                case "te":
                    if (PasswordHash.Equals(password)) //The fuck...
                    {
                        context.Session["name"] = Holder.Instance.LoginDetails[0][1];
                        context.Session["rank"] = Holder.Instance.LoginDetails[0][1];
                    }
                    break;
                case "pa":
                case "st":
            }
        }
    }
}
