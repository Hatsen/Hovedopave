using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class ParentEnrollment
    {

        private int fkenrollmentid;
        private int fkparentid;

        public int FkEnrollmentid
        {
            get { return fkenrollmentid; }
            set { fkenrollmentid = value; }
        }

        public int Fkparentid
        {
            get { return fkparentid; }
            set { fkparentid = value; }
        }



    }
}