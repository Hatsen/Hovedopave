using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Student
    {
        private int id;
        private string firstname;
        private string lastname;
        private string adress;
        private string postcode;
        private string username;
        private string password;
        private int fkclassid;
        private DateTime lastlogin;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }



        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int FkClassid
        {
            get { return fkclassid; }
            set { fkclassid = value; }
        }

        public DateTime Lastlogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }
    }
}