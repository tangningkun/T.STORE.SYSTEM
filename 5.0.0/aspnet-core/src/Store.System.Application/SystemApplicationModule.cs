using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Store.System.Authorization;

namespace Store.System
{
    [DependsOn(
        typeof(SystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
