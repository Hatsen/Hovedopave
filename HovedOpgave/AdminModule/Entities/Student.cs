using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Webservice
{
    public partial class Student
    {
        public override string ToString()
        {
            return this.Firstname+" "+Lastname;
        }


    }
}
