using System.Threading.Tasks;
using Store.System.Configuration.Dto;

namespace Store.System.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
