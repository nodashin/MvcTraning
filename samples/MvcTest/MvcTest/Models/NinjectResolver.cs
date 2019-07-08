using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcTest.Models
{
  class NinjectResolver : IDependencyResolver
  {
    private IKernel _kernel;

    public NinjectResolver(IKernel k)	
    {
      _kernel = k;
    }

    public object GetService(Type serviceType)
    {
      return _kernel.TryGet(serviceType);	
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return _kernel.GetAll(serviceType);
    }
  }
}