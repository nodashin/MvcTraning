using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcController.Startup))]
namespace MvcController
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
