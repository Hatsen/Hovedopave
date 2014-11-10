using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Teacher : User
    {
        private int fkuserid;
        private int rank;
     

        public int Fkuserid
        {
            get { return fkuserid; }
            set { fkuserid = value; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }

}
