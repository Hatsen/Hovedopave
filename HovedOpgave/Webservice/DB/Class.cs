using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Webservice.DB
{
    [DataContract]
    public class Class
    {

        private int id;
        private string name;
        private int fkteacherid;
        private int fkschoolid;

              [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
              [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
              [DataMember]
        public int Fkteacherid
        {
            get { return fkteacherid; }
            set { fkteacherid = value; }
        }

              [DataMember]
        public int Fkschoolid
        {
            get { return fkschoolid; }
            set { fkschoolid = value; }
        }
    }
}