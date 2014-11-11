using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice
{
    public class Announcement
    {
        private int id;
        private int creator;
        private string header;
        private string message;
        private int groupId;
        private int classId;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public int GroupID
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public int ClassID
        {
            get { return classId; }
            set { classId = value; }
        }
    }
}