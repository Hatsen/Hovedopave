using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice
{
    public class Announcement
    {
        private int id;
        private string headline;
        private string message;
        private DateTime created;
        private DateTime edited;
        //private int ancgroup;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Headline
        {
            get { return headline; }
            set { headline = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        public DateTime Edited
        {
            get { return edited; }
            set { edited = value; }
        }

        /*
        public int ancGroup
        {
            get { return ancgroup; }
            set { ancgroup = value; }
        }
         */
    }
}