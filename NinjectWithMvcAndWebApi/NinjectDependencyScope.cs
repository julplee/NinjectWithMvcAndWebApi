using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectWithMvcAndWebApi
{
    using System.Web.Http.Dependencies;

    using Ninject;
    using Ninject.Syntax;

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolutionRoot;

        private IResolutionRoot ResolutionRoot
        {
            get
            {
                if (resolutionRoot == null)
                    throw new ObjectDisposedException("resolutionRoot", "The resolution is already disposed!");

                return resolutionRoot;
            }
        }

        public NinjectDependencyScope(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public object GetService(Type serviceType)
        {
            return ResolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // TODO to be consistent with GetService method, this method should be protected too
            return ResolutionRoot.GetAll(serviceType);
        }

        public void Dispose()
        {
            var root = this.resolutionRoot as IDisposable;
            if (root != null)
                root.Dispose();

            resolutionRoot = null;
        }
    }
}