using AdminModule.ViewModels;
using AdminModule.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule
{
   public class ServiceProxy
    {
       Service1Client service = new Service1Client();

       private static ServiceProxy instance;

       private ServiceProxy() { }

       public static ServiceProxy Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = new ServiceProxy();
               }
               return instance;
           }

       }


/*       public Task<Teacher> GetTeacher()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<Teacher>();
           EventHandler<GetTeacherCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.GetTeacherCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.GetTeacherCompleted += handler;
           service.GetTeacherAsync(tcs);

           return tcs.Task;
       }
*/


      /* public List<Teacher> GetTeachers()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<Teacher>>();
      

           service.GetTeachersAsync(tcs);

           return tcs.Task;
       }*/


        public  Task<List<Teacher>> GetTeachers()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<Teacher>>();
           EventHandler<GetTeachersCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                  
                   service.GetTeachersCompleted -= handler;               
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                 
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                  
                   }

               }
             
           };
          // viewModel.RaiseOnselectedPersonChanged("Underviser");
           service.GetTeachersCompleted += handler;
           service.GetTeachersAsync(tcs);
      

           return tcs.Task;
          
       }



       public Task<List<Student>> GetStudents()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<Student>>();
           EventHandler<GetStudentsCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.GetStudentsCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.GetStudentsCompleted += handler;
           service.GetStudentsAsync(tcs);

           return tcs.Task;
       }



       public Task<List<Parent>> GetParents()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<Parent>>();
           EventHandler<GetParentsCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.GetParentsCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.GetParentsCompleted += handler;
           service.GetParentsAsync(tcs);

           return tcs.Task;
       }



       public Task<bool> InsertTeacher(Teacher teacher)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<bool>();
           EventHandler<InsertTeacherCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.InsertTeacherCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.InsertTeacherCompleted += handler;
           service.InsertTeacherAsync(teacher, tcs);

           return tcs.Task;
       }



        #region ParentMethods




       public Task<bool> InsertParent(Parent parent)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<bool>();
           EventHandler<InsertParentCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.InsertParentCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.InsertParentCompleted += handler;
           service.InsertParentAsync(parent, tcs);

           return tcs.Task;
       }
 
        #endregion 

       #region Class

       public Task<bool> InsertClass(Class theClass)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<bool>();
           EventHandler<InsertClassCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.InsertClassCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.InsertClassCompleted += handler;
           service.InsertClassAsync(theClass, tcs);

           return tcs.Task;
       }




       public Task<List<Class>> GetClasses()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<Class>>();
           EventHandler<GetClassesCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.GetClassesCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.GetClassesCompleted += handler;
           service.GetClassesAsync(tcs);

           return tcs.Task;
       }


       #endregion


       #region ParentMethods




       public Task<bool> InsertStudent(Student student)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<bool>();
           EventHandler<InsertStudentCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.InsertStudentCompleted -= handler;
                   if (args.Error != null)
                   {
                       tcs.TrySetException(args.Error);
                   }
                   else if (args.Cancelled)
                   {
                       tcs.TrySetCanceled();
                   }
                   else
                   {
                       tcs.TrySetResult(args.Result);
                   }

               }
           };

           service.InsertStudentCompleted += handler;
           service.InsertStudentAsync(student, tcs);

           return tcs.Task;
       }
    
        #endregion 




    }
}
