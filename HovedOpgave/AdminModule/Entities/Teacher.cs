

/**
* Copyright (c) 2013 Lars Skaaning Jensen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Lars Skaaning Jensen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Webservice // ændret namespace for at tilgå proxyklasserne
{
   public partial class Teacher
   {
       private string title;

       public string Title
       {
           get
           {
               if (Userrole==(int)Enums.Userrole.Teacher)
               {
                   title = "Underviser";
               }
               else if (Userrole==(int)Enums.Userrole.Principal)
               {
                   title = "Skoleleder";
               }
               else if (Userrole == (int)Enums.Userrole.Substitute)
               {
                   title = "Vikar";
               }

               return title;
           }
           set { title = value; }
       }
       
       public override string ToString()
       {
           return base.Firstname + " " + Lastname.ToString(); 
       }



    }
}
