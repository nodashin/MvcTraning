using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcTest.Models;
using Ninject;

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

            //標準的なカーネルに紐づけ情報を登録
            IKernel _kernel = new StandardKernel();
            _kernel.Bind<IMemberRepository>().To<MemberRepository>();

            //依存性リボルバーを登録
            DependencyResolver.SetResolver(new NinjectResolver(_kernel));
        }
    }
}
