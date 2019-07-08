using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcOther.Startup))]
namespace MvcOther
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
