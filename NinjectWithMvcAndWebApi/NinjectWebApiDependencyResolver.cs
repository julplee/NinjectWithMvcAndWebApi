using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectWithMvcAndWebApi
{
    using Ninject;

    public class NinjectWebApiDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectWebApiDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}