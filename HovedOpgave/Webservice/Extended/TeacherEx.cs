using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.DB;

namespace Webservice.Extended
{
    public class TeacherEx:Teacher
    {

        private List<ClassEx> classList = new List<ClassEx>();


        public List<ClassEx> ClassList
        {
            get { return classList; }
            set { classList = value; }
        }
    }
}