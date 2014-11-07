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
           Create = 0,
           Edit = 1
       };

       public enum Rank
       {
           Principal = 0,
           Teacher = 1,
           Substitute = 2
       };

       public enum Userrole
       {
           Teacher = 0,
           Parent = 1,
           Student = 2
       };


       public enum ViewstateObject
       {
           Teacher = 0,
           Student = 1,
           Parent = 2,

       };

   }
}
