using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using T.STORE.SYSTEM.EntityFrameworkCore;
using T.STORE.SYSTEM.WebApi.CommonUtils;

namespace T.STORE.SYSTEM.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            try {

                using (IServiceScope scope = host.Services.CreateScope())
                {
                    IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                    //获取到appsettings.json中的连接字符串
                    string sqlString = configuration.GetSection("ConnectionStrings:Default").Value;
                    //确保NLog.config中连接字符串与appsettings.json中同步
                    NLogUtil.EnsureNlogConfig("nlog.config", sqlString);
                }
                //throw new Exception("测试异常");//for test
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = new StoreDbContext();
                        context.Database.Migrate();
                        //DbInitialization.Initialize(services);
                        NLogUtil.WriteDBLog(NLog.LogLevel.Trace, LogType.DataBase, "数据库连接成功");
                    }
                    catch (Exception e)
                    {
                        NLogUtil.WriteDBLog(NLog.LogLevel.Trace, LogType.DataBase, "数据库连接失败");
                    }
                }



                //其他项目启动时需要做的事情
                //code
                NLogUtil.WriteDBLog(NLog.LogLevel.Trace, LogType.ApiRequest, "接口启动成功");
                host.Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                //使用nlog写到本地日志文件（万一数据库没创建/连接成功）
                string errorMessage = "网站启动初始化数据异常";
                NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.ApiRequest, errorMessage, new Exception(errorMessage, ex));
                NLogUtil.WriteDBLog(NLog.LogLevel.Error, LogType.ApiRequest, errorMessage, new Exception(errorMessage, ex));
                throw;
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging(logging => {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            }).UseNLog();
    }
}
