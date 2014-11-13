using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Webservice // ændret namespace for at tilgå proxyklasserne
{
   public partial class Teacher
    {
       public override string ToString()
       {
           return base.Firstname + " " + Lastname.ToString();
       }
    }
}
