﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.EntityFrameworkCore.EntityFramework
{
    /// <summary>
    /// EF Context线程内唯一对象
    /// </summary>
    public class DBContextFactory
    {
        //public static DbContext CReateDbContext()
        //{

        //    DbContext dbcontext = (DbContext)CallContext.GetData("dbContext");
        //    if (dbcontext == null)
        //    {
        //        dbcontext = new StoreDbContext(IApplicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()));
        //        CallContext.SetData("dbContext", dbcontext);
        //    }
        //    return dbcontext;
        //}
    }
}