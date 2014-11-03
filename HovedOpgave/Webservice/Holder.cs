﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice
{
    public class Holder
    {
        private static Holder instance;
        public DatabaseHandler dh;
        private List<Announcement> announcements;

        public List<Announcement> Announcements
        {
            get { return announcements; }
            set { announcements = value; }
        }

        private Holder()
        {
            dh = new DatabaseHandler();
        }

        public static Holder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Holder();
                }
                return instance;
            }
        }
    }
}