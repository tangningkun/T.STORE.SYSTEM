using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Store.System.Controllers
{
    public abstract class SystemControllerBase: AbpController
    {
        protected SystemControllerBase()
        {
            LocalizationSourceName = SystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
