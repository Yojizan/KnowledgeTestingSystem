using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using BLL.Interfaces;
using BLL.Configuration;
using BLL.Services;
using Ninject;
using System.Web.Configuration;
using Ninject.Web.Common.OwinHost;

//[assembly: OwinStartup(typeof(PL.App_Start.Startup))]

namespace PL.App_Start
{
    public class Startup
    {
        private IKernel kernel = null;

        public void Configuration(IAppBuilder app)
        {
            kernel = CreateKernel();
            app.UseNinjectMiddleware(() => kernel);
            app.CreatePerOwinContext(CreateKernel);
            /*app.CreatePerOwinContext<IUserService>((option, context) =>
            {
                var kernl = context.Get<IKernel>();

            });*/
        }

        public IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<IUserService>().To<UserService>();
                kernel.Bind<ITestingService>().To<TestingService>();
                string connectionString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                kernel.Load(new BusinessServicesModule(connectionString));
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