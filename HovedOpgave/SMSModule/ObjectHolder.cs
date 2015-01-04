

/**
* Copyright (c) 2013 Patrick Larsen, Lars Skaaning Jensen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Patrick Larsen, Lars Skaaning Jensen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/

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