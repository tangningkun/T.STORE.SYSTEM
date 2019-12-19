using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Core.Common;
using T.STORE.SYSTEM.Domain.Entities;

namespace T.STORE.SYSTEM.EntityFrameworkCore.Migrations.SeedData
{
    public class DbInitialization
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<StoreDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;   // 已经初始化过数据，直接返回
                }
                var userGuid = Guid.NewGuid();
                var roleGuid = Guid.NewGuid();
                var deparmentGuid = Guid.NewGuid();
                context.Users.Add(
                        new User{
                           TenantId=userGuid,
                           Account="超级管理员",
                           UserName="admin",
                           Password=Utils.EncryptDES("123qwe"),
                           CreateTime=DateTime.Now,
                           ApiKey=CreateApiKey.GetRandomCode(10)
                        }
                    );
                context.Roles.Add(
                    new Role { 
                        TenantId=roleGuid,
                        RoleName="admin",
                        IsAdmin=true,
                        IsUse=true,
                        CreateTime=DateTime.Now,
                    });
                context.UserRoles.Add(
                    new UserRole
                    {
                        RoleId=roleGuid,
                        UserId=userGuid
                    });
            }
        }
    }
}
