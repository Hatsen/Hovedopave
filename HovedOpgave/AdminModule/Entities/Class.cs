﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Webservice
{
    public partial class Class
    {

        public override string ToString()
        {
            
            return Name+"\tUnderviser:"+Fkteacherid;
        }


    }
}
