using Ninject;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;

namespace Softtek.Academy2018.Demo.Console
{
    public static class FactoryDependency
    {
        public static IKernel GetKernel()
        {
            StandardKernel kernel = new StandardKernel();

            //Bindings
            kernel.Bind<IUserRepository>().To<UserDataRepository>();
            //kernel.Bind<IUserRepository>().To<UserFakeRepository>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IProjectRepository>().To<ProjectDataRepository>();
            kernel.Bind<IProjectService>().To<ProjectService>();

            return kernel;
        }
    }

}
