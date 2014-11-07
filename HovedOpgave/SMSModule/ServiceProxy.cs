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
    }
}
