using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.Academy2018.Demo.Console
{
    public static class FactoryDependency
    {
        public static IKernel GetKernel()
        {
            StandardKernel kernel = new StandardKernel();

            //Bindings
            //kernel.Bind<IUserRepository>().To<IUserRepository>();
            //kernel.Bind<IUserRepository>().To<UserFakeRepository>();
            //kernel.Bind<IUserService>().To<UserService>();

            return kernel;
        }
    }
}
