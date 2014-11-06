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




       public Task<Teacher> GetTeacher()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
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


       //SKAL NOK FJERNES. DU KAN IKKE VÆRE SIKKER PÅ AT DU FÅR DEN MOSTRECENT ID NÅR DU HAR HENTET DET. ALTSÅ SKAL ID, USERNAME OG PASSWORD GENERES PÅ WEBSERVICEN.
     /*  public Task<int> GetMostRecentUserId()//man gør dette fordi man vil have synkrone kald og ikke asykrone kald.
       {
           var tcs = new TaskCompletionSource<int>();
           EventHandler<GetUserCountCompletedEventArgs> handler = null;
           handler = (sender, args) =>
           {
               if (args.UserState == tcs)
               {
                   service.GetUserCountCompleted -= handler;
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

           service.GetUserCountCompleted += handler;
           service.GetUserCountAsync();

           return tcs.Task;
       }*/  



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








    }
}
