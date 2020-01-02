using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using T.STORE.SYSTEM.EntityFrameworkCore;
using T.STORE.SYSTEM.WebApi.Common;

namespace T.STORE.SYSTEM.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<AppConfigurtaion>();
            services.AddMvc().AddWebApiConventions();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //添加数据库上下文和配置数据库连接字符串
            StoreDbContext.ConnectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<StoreDbContext>();


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.1.0",
                    Title = "T.STORE.SYSTEM.WebApi",
                    Description = "商店系统框架API",
                    TermsOfService = "None",
                    //Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Tangningkunn", Email = "1209229446@qq.com", Url = "" }
                });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                //添加接口XML的路径
                var xmlPath = Path.Combine(basePath, "T.STORE.SYSTEM.WebApi.xml");
                //如果需要显示控制器注释只需将第二个参数设置为true
                c.IncludeXmlComments(xmlPath, true);
            });
            #endregion

            return AutofacConfigure.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "T.STORE.SYSTEM.WebApi");
            });
            #endregion

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
