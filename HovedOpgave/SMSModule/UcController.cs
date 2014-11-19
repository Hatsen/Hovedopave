using SMSModule.Webservice;
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
            bool result = await ServiceProxy.Instance.GetLoginDetails(username, password);
            return result;
        }

        public async Task<string> GetUserDetails(int number)
        {
            string result = await ServiceProxy.Instance.GetUserDetails(number);
            return result;
        }

        public async Task<bool> CreateAnnouncement(int creator, string header, string message, int groupID, int classID)
        {
            bool result = await ServiceProxy.Instance.CreateAnnouncement(creator, header, message, groupID, classID);
            return result;
        }

        public async Task<List<Announcement>> GetAnnouncements(int groupID, int classID)
        {
            List<Announcement> result = await ServiceProxy.Instance.GetAnnouncements(groupID, classID);
            return result;
        }

        public async Task<string> GetAnnouncementCreator(int id)
        {
            string result = await ServiceProxy.Instance.GetAnnouncementCreator(id);
            return result;
        }

        public async Task<bool> ChangePassword(int id, string oldPass, string newPass, string confirmPass)
        {
            bool result = await ServiceProxy.Instance.ChangePassword(id, oldPass, newPass, confirmPass);
            return result;
        }
    }
}