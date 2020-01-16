using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Core.AutoMapper;

namespace T.STORE.SYSTEM.WebApi.Common
{
    public class AutofacConfigure
    {
        public static AutofacServiceProvider Register(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);

            //注册所有控制器
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();

            //注册ServiceModule组件[第五步新添加]
            builder.RegisterModule<ServiceModule>();
            //注册RepositoryModule组件[第五步新添加]
            builder.RegisterModule<RepositoryModule>();
            //创建容器
            IContainer container = builder.Build();

            // AutoMapper的配置初始化
            new AutoMapperStartupTask().Execute();

            return new AutofacServiceProvider(container);
        }
    }


    public class RepositoryModule : Autofac.Module
    {
        //重写Autofac管道中的Load方法，在这里注入注册的内容
        protected override void Load(ContainerBuilder builder)
        {
            //注册Autofac.DAL中以Repository结尾的类
            builder.RegisterAssemblyTypes(AutofacHelper.GetAssemblyByName("T.STORE.SYSTEM.Repository")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }
    }

    public class ServiceModule : Autofac.Module
    {
        //重写Autofac管道中的Load方法，在这里注入注册的内容
        protected override void Load(ContainerBuilder builder)
        {
            //注册Autofac.BLL中以Service结尾的类
            builder.RegisterAssemblyTypes(AutofacHelper.GetAssemblyByName("T.STORE.SYSTEM.Application")).Where(a => a.Name.EndsWith("AppService")).AsImplementedInterfaces();
        }
    }

    public class AutofacHelper
    {
        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssemblyByName(String AssemblyName)
        {
            return Assembly.Load(AssemblyName);
        }
    }
}
