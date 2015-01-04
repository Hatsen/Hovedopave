

/**
* Copyright (c) 2013 Patrick Larsen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Patrick Larsen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.DB;

namespace Webservice
{
    public class Holder
    {
        private static Holder instance;
        public DatabaseHandler databaseHandler;

        private List<Announcement> announcements = new List<Announcement>();
        private User loginDetails;

        public List<Announcement> Announcements
        {
            get { return announcements; }
            set { announcements = value; }
        }

        public User LoginDetails
        {
            get { return loginDetails; }
            set { loginDetails = value; }
        }

        private Holder()
        {
            // databaseHandler = new DatabaseHandler();
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