using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APIconMVC.Startup))]
namespace APIconMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
