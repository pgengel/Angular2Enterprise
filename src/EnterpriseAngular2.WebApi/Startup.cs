using System;
using System.Collections.Generic;
using System.Linq;
using EnterpriseAngular2.Data.Contexts;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;

[assembly: OwinStartup(typeof(EnterpriseAngular2.WebApi.Startup))]

namespace EnterpriseAngular2.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var container = new UnityContainer();

            container.RegisterType<IBusinessContext, BusinessContext>();
            //container.RegisterType<MainViewModel>();

            //var window = new MainWindow
            //{
            //    DataContext = container.Resolve<MainViewModel>()
            //};

            ConfigureAuth(app);
        }
    }
}
