using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Webservice.DB
{
    [DataContract]
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
        private int phonenumber;
        private string email;
        private int fkschoolid;

          [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

          [DataMember]
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

          [DataMember]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
          [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
          [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
          [DataMember]
        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
          [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
          [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
          [DataMember]
        public DateTime Lastlogin
        {
            get { return lastlogin; }
            set { lastlogin = value; }
        }
          [DataMember]
        public int Userrole
        {
            get { return userrole; }
            set { userrole = value; }
        }
          [DataMember]
        public int Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber= value; }
        }

          [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

          [DataMember]
        public int Fkschoolid
        {
            get { return fkschoolid; }
            set { fkschoolid = value; }
        }
    }
}