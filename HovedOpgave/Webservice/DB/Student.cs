using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Webservice.DB
{
    [DataContract]
    public class Student : User
    {
        private int fkuserid;
        private int fkclassid;
             [DataMember]
        public int FkClassid
        {
            get { return fkclassid; }
            set { fkclassid = value; }
        }
             [DataMember]
        public int Fkuserid
        {
            get { return fkuserid; }
            set { fkuserid = value; }
        }
    }
}