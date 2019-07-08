using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcView.Startup))]
namespace MvcView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
