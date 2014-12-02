using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}