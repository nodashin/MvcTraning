using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBasic.Startup))]
namespace MvcBasic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
