using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.DB;

namespace Webservice.Extended
{
    public class ParentEx : Parent
    {
        private List<Student> childrenIdList = new List<Student>();


        public List<Student> ChildrenList
        {
            get { return childrenIdList; }
            set { childrenIdList = value; }
        }

    }
}