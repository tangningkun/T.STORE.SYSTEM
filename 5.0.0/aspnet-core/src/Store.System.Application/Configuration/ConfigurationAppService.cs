using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Store.System.Configuration.Dto;

namespace Store.System.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
