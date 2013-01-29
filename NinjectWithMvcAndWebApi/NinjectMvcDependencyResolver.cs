using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectWithMvcAndWebApi
{
    using Ninject;

    public class NinjectMvcDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectMvcDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // TODO to be consistent with GetService method, this method should be protected too
            return kernel.GetAll(serviceType);
        }
    }
}