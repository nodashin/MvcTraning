using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace MvcTest.Models
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel _kernel;

        //Ninjectのカーネルを準備
        public NinjectResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        //単一のサービスを解決
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        //複数のサービスを解決
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}