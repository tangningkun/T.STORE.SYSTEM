using System.Threading.Tasks;
using Abp.Application.Services;
using Store.System.Sessions.Dto;

namespace Store.System.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
