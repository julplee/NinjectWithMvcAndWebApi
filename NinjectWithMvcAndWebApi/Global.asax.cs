using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NinjectWithMvcAndWebApi
{
    using Ninject;

    using NinjectWithMvcAndWebApi.Models;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IKernel kernel = new StandardKernel();
            RegisterServices(kernel);

            // Create resolver for MVC controllers
            NinjectMvcDependencyResolver ninjectMvcDependencyResolver = new NinjectMvcDependencyResolver(kernel);
            DependencyResolver.SetResolver(ninjectMvcDependencyResolver);

            // Create resolver for WebApi controllers
            NinjectWebApiDependencyResolver ninjectWebApiDependencyResolver = new NinjectWebApiDependencyResolver(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = ninjectWebApiDependencyResolver;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>();
        }  
    }
}