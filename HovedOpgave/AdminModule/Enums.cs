using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule
{
   public class Enums
   {
       public enum ViewState
       {
           Create = 1,
           Edit = 2
       };

       public enum Rank
       {
           Principal = 1,
           Teacher = 2,
           Substitute = 3
       };

       public enum Userrole
       {
           Principal = 1,
           Teacher = 2,
           Substitute = 3,
           Parent = 4,
           Student = 5
       };


       public enum ViewstateObject
       {
           Teacher = 1,
           Student = 2,
           Parent = 3,
           Class = 4,
       };

   }
}
