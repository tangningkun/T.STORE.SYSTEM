using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Store.System.EntityFrameworkCore
{
    public static class SystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
