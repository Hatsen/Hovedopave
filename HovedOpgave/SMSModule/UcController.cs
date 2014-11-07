using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for UcController
/// </summary>

namespace SMSModule
{
    public class UcController
    {
        public async Task<bool> GetLoginDetails(string username, string password)
        {
            bool result = false;
            result = await ServiceProxy.Instance.GetLoginDetails(username, password);
            return result;
        }

        public async Task<string> GetUserDetails(int number)
        {
            string result = "";
            result = await ServiceProxy.Instance.GetUserDetails(number);
            return result;
        }

        /*
        public async Task<string> GetAnnouncements(int ancGrp)
        {
            string result = "";

            result = await ServiceProxy.Instance.GetAnnouncements(ancGrp);
            return result;
        }
         */
    }
}