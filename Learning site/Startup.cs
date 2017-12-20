using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Learning_site.Startup))]
namespace Learning_site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
