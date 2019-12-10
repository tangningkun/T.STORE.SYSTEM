using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Store.System.Authorization.Roles;
using Store.System.Authorization.Users;
using Store.System.MultiTenancy;

namespace Store.System.EntityFrameworkCore
{
    public class SystemDbContext : AbpZeroDbContext<Tenant, Role, User, SystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {
        }
    }
}
