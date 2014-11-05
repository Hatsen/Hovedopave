using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class User
    {
        private int id;
        private string firstname;
        private string lastname;
        private string city;
        private string address;
        private string birthdate;
        private string username;
        private string password;
        private DateTime lastlogin; // allow null.
        private int userrole;

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

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
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

        public DateTime Lastlogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }

        public int Userrole
        {
            get { return userrole; }
            set { userrole = value; }
        }
    }
}