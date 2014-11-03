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
        private string year;
        private int fkteacherid;


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

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Fkteacherid
        {
            get { return fkteacherid; }
            set { fkteacherid = value; }
        }
    }
}