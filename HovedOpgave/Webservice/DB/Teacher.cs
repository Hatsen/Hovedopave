using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Teacher
    {
        private int id;
        private string firstname;
        private string lastname;
        private string city;
        private string adress;
        private string birhtdate;
        private int rank;
        private string username;
        private string password;
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

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string Birhtdate
        {
            get { return birhtdate; }
            set { birhtdate = value; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
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
    }

}
