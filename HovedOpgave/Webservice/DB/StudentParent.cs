using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class StudentParent
    {

        private int fkstudentid;
        private int fkparentid;

        public int Fkstudentid
        {
            get { return fkstudentid; }
            set { fkstudentid = value; }
        }

        public int Fkparentid
        {
            get { return fkparentid; }
            set { fkparentid = value; }
        }
    }
}