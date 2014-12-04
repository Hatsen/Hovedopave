using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Enrollment
    {


        private int id;
        private string childfirstname;
        private string childlastname;
        private string childcity;
        private string childaddress;
        private string childbirthdate;
        private int childphonenumber;
        private string notes;
        private string datecreated;
        private int fkschoolid;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string ChildFirstname
        {
            get { return childfirstname; }
            set { childfirstname = value; }
        }

        public string ChildLastname
        {
            get { return childlastname; }
            set { childlastname = value; }
        }

        public string ChildCity
        {
            get { return childcity; }
            set { childcity = value; }
        }

        public string ChildAddress
        {
            get { return childaddress; }
            set { childaddress = value; }
        }

        public string ChildBirthdate
        {
            get { return childbirthdate; }
            set { childbirthdate = value; }
        }



        public int ChildPhonenumber
        {
            get { return childphonenumber; }
            set { childphonenumber = value; }
        }



        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public string DateCreated
        {
            get { return datecreated; }
            set { datecreated = value; }
        }


        public int Fkschoolid
        {
            get { return fkschoolid; }
            set { fkschoolid = value; }
        }





    }
}