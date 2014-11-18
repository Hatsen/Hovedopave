using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.DB;

namespace Webservice.Extended
{
    public class ClassEx : Class
    {

        private List<Student> studentsList = new List<Student>();


        public List<Student> StudentsList
        {
            get { return studentsList; }
            set { studentsList = value; }
        }
    }
}