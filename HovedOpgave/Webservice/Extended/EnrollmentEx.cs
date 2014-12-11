using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.DB;

namespace Webservice.Extended
{
    public class EnrollmentEx:Enrollment
    {

        private List<ParentEx> parentlist = new List<ParentEx>();


        public List<ParentEx> ParentList
        {
            get { return parentlist; }
            set { parentlist = value; }
        }



    }
}