using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.DB
{
    public class Parent
    {
        private int id;
        private string name;
        private string adress;
        private string postcode;
        private string username;
        private string password;
        private DateTime lastlogin;

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

        public DateTime Lastlogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }

    }
}