using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcRoute.Startup))]
namespace MvcRoute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
