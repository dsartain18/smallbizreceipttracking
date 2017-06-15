using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using System.Configuration;
using System.Web;
using System.Web.Http;

using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.WebApi;

using SmallBizReceiptTrackingAPI.Entities.Entities;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SmallBizReceiptTrackingAPI.SmallBizReceiptTrackingAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SmallBizReceiptTrackingAPI.SmallBizReceiptTrackingAPI.App_Start.NinjectWebCommon), "Stop")]

namespace SmallBizReceiptTrackingAPI.SmallBizReceiptTrackingAPI.App_Start
{
    /// <summary>
    /// Sets the ninject properties
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            ConfigurationSettingsEntity configurationSettings = new ConfigurationSettingsEntity(ConfigurationManager.AppSettings);
            var modules = new INinjectModule[] { new DependencyResolution.DependencyRegistrar(configurationSettings) };
            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);                
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }        
    }
}