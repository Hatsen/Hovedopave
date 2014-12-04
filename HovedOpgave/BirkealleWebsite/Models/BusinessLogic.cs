using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BirkealleWebsite.WebService;

namespace BirkealleWebsite.Models
{
    public class BusinessLogic
    {
        private static BusinessLogic instance;
        private BusinessLogic() { }

        public static BusinessLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BusinessLogic();
                }
                return instance;
            }

        }

        public async Task<bool> GetLoginDetails(string username, string password)
        {
            if (await ServiceProxy.Instance.GetLoginDetails(username, password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetUserDetails(int number)
        {
            string result = await ServiceProxy.Instance.GetUserDetails(number);
            return result;
        }

        public async Task<List<ClassEx>> GetClasses()
        {
            List<ClassEx> result = await ServiceProxy.Instance.GetClasses();
            return result;
        }

        public async Task<List<ClassEx>> GetClassDetails(int id, int groupID)
        {
            List<ClassEx> result = await ServiceProxy.Instance.GetClassDetails(id, groupID);
            return result;
        }
    }
}