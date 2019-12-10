using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Store.System.Configuration;
using Store.System.Web;

namespace Store.System.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SystemDbContextFactory : IDesignTimeDbContextFactory<SystemDbContext>
    {
        public SystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SystemConsts.ConnectionStringName));

            return new SystemDbContext(builder.Options);
        }
    }
}
