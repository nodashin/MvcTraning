using MvcTest.Models;
using Ninject;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<MvcTestContext>(new MvcTestInitializer());
            IKernel _kernel = new StandardKernel();
            _kernel.Bind<IMemberRepository>().To<MemberRepository>();
            DependencyResolver.SetResolver(new NinjectResolver(_kernel));

        }
    }
}
