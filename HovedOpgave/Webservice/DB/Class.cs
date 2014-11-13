using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Class
    {

        private int id;
        private string name;
        private int fkteacherid;
        private int fkschoolid;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Fkteacherid
        {
            get { return fkteacherid; }
            set { fkteacherid = value; }
        }


        public int Fkschoolid
        {
            get { return fkschoolid; }
            set { fkschoolid = value; }
        }
    }
}