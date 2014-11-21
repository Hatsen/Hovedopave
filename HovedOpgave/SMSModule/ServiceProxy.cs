using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SMSModule.Webservice;

/// <summary>
/// Summary description for ServiceProxy
/// </summary>

namespace SMSModule
{
    public class ServiceProxy
    {
        Service1Client service = new Service1Client();
        private static ServiceProxy instance;

        public Service1Client Service
        {
            get { return service; }
            set { service = value; }
        }

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

        public Task<bool> GetLoginDetails(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            EventHandler<GetLoginDetailsCompletedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                if (args.UserState == tcs)
                {
                    service.GetLoginDetailsCompleted -= handler;
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

            service.GetLoginDetailsCompleted += handler;
            service.GetLoginDetailsAsync(username, password, tcs);

            return tcs.Task;
        }

         public Task<string> GetUserDetails(int number)
         {
             var tcs = new TaskCompletionSource<string>();
             EventHandler<GetUserDetailsCompletedEventArgs> handler = null;
             handler = (sender, args) =>
             {
                 if (args.UserState == tcs)
                 {
                     service.GetUserDetailsCompleted -= handler;
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
 
             service.GetUserDetailsCompleted += handler;
             service.GetUserDetailsAsync(number, tcs);
 
             return tcs.Task;
         }

         public Task<List<ClassEx>> GetClassDetails(int id, int userrole)
         {
             var tcs = new TaskCompletionSource<List<ClassEx>>();
             EventHandler<GetClassDetailsCompletedEventArgs> handler = null;
             handler = (sender, args) =>
             {
                 if (args.UserState == tcs)
                 {
                     service.GetClassDetailsCompleted -= handler;
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

             service.GetClassDetailsCompleted += handler;
             service.GetClassDetailsAsync(id, userrole, tcs);
 
             return tcs.Task;
         }

        
         public Task<bool> CreateAnnouncement(int creator, string header, string message, int group, int classID)
         {
             var tcs = new TaskCompletionSource<bool>();
             EventHandler<CreateAnnouncementCompletedEventArgs> handler = null;
             handler = (sender, args) =>
             {
                 if (args.UserState == tcs)
                 {
                     service.CreateAnnouncementCompleted -= handler;
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

             service.CreateAnnouncementCompleted += handler;
             service.CreateAnnouncementAsync(creator, header, message, group, classID, tcs);

             return tcs.Task;
         }

        public Task<List<Announcement>> GetAnnouncements(int groupID, int classID)
         {
             var tcs = new TaskCompletionSource<List<Announcement>>();
             EventHandler<GetAnnouncementsCompletedEventArgs> handler = null;
             handler = (sender, args) =>
             {
                 if (args.UserState == tcs)
                 {
                     service.GetAnnouncementsCompleted -= handler;
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

             service.GetAnnouncementsCompleted += handler;
             service.GetAnnouncementsAsync(groupID, classID, tcs);

             return tcs.Task;
         }

        public Task<string> GetAnnouncementCreator(int id)
        {
            var tcs = new TaskCompletionSource<string>();
            EventHandler<GetAnnouncementCreatorCompletedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                if (args.UserState == tcs)
                {
                    service.GetAnnouncementCreatorCompleted -= handler;
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

            service.GetAnnouncementCreatorCompleted += handler;
            service.GetAnnouncementCreatorAsync(id, tcs);

            return tcs.Task;
        }

        public Task<bool> ChangePassword(int id, string oldPass, string newPass, string confirmPass)
        {
            var tcs = new TaskCompletionSource<bool>();
            EventHandler<ChangePasswordCompletedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                if (args.UserState == tcs)
                {
                    service.ChangePasswordCompleted -= handler;
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

            service.ChangePasswordCompleted += handler;
            service.ChangePasswordAsync(id, oldPass, newPass, confirmPass, tcs);

            return tcs.Task;
        }
    }
}
