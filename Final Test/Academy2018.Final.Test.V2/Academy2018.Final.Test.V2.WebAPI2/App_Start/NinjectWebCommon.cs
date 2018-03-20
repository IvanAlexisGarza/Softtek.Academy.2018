using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web.Common.WebHost;
using Ninject;
using Ninject.Web.Common;
using Academy2018.Final.Test.V2.WebAPI2.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Academy2018.Final.Test.V2.Data.Implementations;
using Academy2018.Final.Test.V2.Data.Contracts;
using Academy2018.Final.Test.Business.Contracts;
using Academy2018.Final.Test.Business.Implementation;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Academy2018.Final.Test.V2.WebAPI2.App_Start
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));

            kernel.Bind<IAnswerRepository>().To<AnswerRepository>();
            kernel.Bind<IQuestionRepository>().To<QuestionRepository>();
            kernel.Bind<ISurveyRepository>().To<SurveyRepository>();

            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<ISurveyService>().To<SurveyService>();
        }
    }
}