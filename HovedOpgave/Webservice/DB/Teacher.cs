using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Webservice.DB
{
     [DataContract]
    public class Teacher : User
    {
        private int fkuserid;
        private int rank;

             [DataMember]
        public int Fkuserid
        {
            get { return fkuserid; }
            set { fkuserid = value; }
        }
             [DataMember]
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }

}
