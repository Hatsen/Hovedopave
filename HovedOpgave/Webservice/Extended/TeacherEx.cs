using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Webservice.DB;

namespace Webservice.Extended
{
    [DataContract]
    public class TeacherEx:Teacher
    {

        private List<ClassEx> classList = new List<ClassEx>();

             [DataMember]
        public List<ClassEx> ClassList
        {
            get { return classList; }
            set { classList = value; }
        }
    }
}