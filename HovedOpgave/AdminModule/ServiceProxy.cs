using AdminModule.ViewModels;
//using AdminModule.Webservice;
using AdminModule.WebServiceDeployed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdminModule
{
   public class ServiceProxy
    {
       WebServiceDeployed.Service1Client service = new Service1Client();
       //Service1Client service = new Service1Client();

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


       public Task<List<TeacherEx>> GetTeachers()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<TeacherEx>>();
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



       public Task<List<ParentEx>> GetParents()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<ParentEx>>();
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



       public Task<bool> InsertTeacher(TeacherEx teacher)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
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




       public Task<bool> InsertParent(ParentEx parent)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
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

       public Task<bool> InsertClass(ClassEx theClass)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
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




       public Task<List<ClassEx>> GetClasses()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<ClassEx>>();
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


       public Task<bool> DeleteClass(int classId)
       {
           var tcs = new TaskCompletionSource<bool>();
           EventHandler<DeleteClassCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.DeleteClassCompleted -= handler;
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

           service.DeleteClassCompleted += handler;
           service.DeleteClassAsync(classId, tcs);

           return tcs.Task;
       }

       #endregion


       #region ParentMethods




       public Task<bool> InsertStudent(Student student, EnrollmentEx enrollment = null)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
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
           service.InsertStudentAsync(student,enrollment, tcs);

           return tcs.Task;
       }
    
        #endregion 


       

       public Task<string> DeleteUserById(int id)//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<string>();
           EventHandler<DeleteUserCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.DeleteUserCompleted -= handler;
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

           service.DeleteUserCompleted += handler;
           service.DeleteUserAsync(id, tcs);

           return tcs.Task;
       }





       public Task<List<EnrollmentEx>> GetEnrollments()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<List<EnrollmentEx>>();
           EventHandler<GetEnrollmentsCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.GetEnrollmentsCompleted -= handler;
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

           service.GetEnrollmentsCompleted += handler;
           service.GetEnrollmentsAsync(tcs);

           return tcs.Task;
       }






    }
}
