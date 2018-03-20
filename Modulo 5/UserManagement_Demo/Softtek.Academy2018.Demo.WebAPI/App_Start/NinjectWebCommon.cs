using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly:
    WebActivatorEx.PreApplicationStartMethod(
    typeof(Softtek.Academy2018.Demo.WebAPI.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(
    typeof(Softtek.Academy2018.Demo.WebAPI.NinjectWebCommon), "Stop")]

namespace Softtek.Academy2018.Demo.WebAPI
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Rebind<HttpConfiguration>().ToMethod(
                context => GlobalConfiguration.Configuration);

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<UserDataRepository>();
            kernel.Bind<IProjectRepository>().To<ProjectDataRepository>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IProjectService>().To<ProjectService>();
            kernel.Bind<IProjectUserService>().To<ProjectUserService>();
        }
    }
}