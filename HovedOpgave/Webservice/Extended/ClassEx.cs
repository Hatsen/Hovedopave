using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Webservice.DB;

namespace Webservice.Extended
{
    [DataContract]
    public class ClassEx : Class
    {

        private List<Student> studentsList = new List<Student>();

          [DataMember]
        public List<Student> StudentsList
        {
            get { return studentsList; }
            set { studentsList = value; }
        }
    }
}