using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.WebApi.Common
{
    public class AutofacConfigure
    {
        public static AutofacServiceProvider Register(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<User>().As<IUser>().PropertiesAutowired();直接对类进行注册

            Assembly repositoryAss = Assembly.Load("T.STORE.SYSTEM.Repository"); //对Repository这个类库进行里的类进行集体注册
            Type[] repositorytypes = repositoryAss.GetTypes();
            builder.RegisterTypes(repositorytypes).AsImplementedInterfaces().PropertiesAutowired();


            Assembly applicationAss = Assembly.Load("T.STORE.SYSTEM.Application");//对Application这个类库进行里的类进行集体注册
            Type[] applicationtypes = applicationAss.GetTypes();
            builder.RegisterTypes(applicationtypes).AsImplementedInterfaces().PropertiesAutowired();

            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
