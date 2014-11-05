using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Parent : User
    {
        private int fkuserid;

        public int Fkuserid
        {
            get { return fkuserid; }
            set { fkuserid = value; }
        }
    }
}