using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Student : User
    {
        private int fkuserid;
        private int fkclassid;

        public int FkClassid
        {
            get { return fkclassid; }
            set { fkclassid = value; }
        }

        public int Fkuserid
        {
            get { return fkuserid; }
            set { fkuserid = value; }
        }
    }
}