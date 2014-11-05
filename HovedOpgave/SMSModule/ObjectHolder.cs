using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ObjectHolder
/// </summary>
/// 

namespace SMSModule
{
    public class ObjectHolder
    {
        private static ObjectHolder instance;
        private UcController ucController = new UcController();

        private ObjectHolder() { }

        public static ObjectHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectHolder();
                }
                return instance;
            }
        }

        public UcController UcController 
        {
            get { return ucController; }
            set { ucController = value; }
        }
    }
}