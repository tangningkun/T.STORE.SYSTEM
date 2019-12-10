using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Store.System.MultiTenancy.Dto;

namespace Store.System.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

