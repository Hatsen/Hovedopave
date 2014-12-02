using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BirkealleWebsite.Startup))]
namespace BirkealleWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
