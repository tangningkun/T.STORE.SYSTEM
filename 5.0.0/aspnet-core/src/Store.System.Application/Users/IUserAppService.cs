using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Store.System.Roles.Dto;
using Store.System.Users.Dto;

namespace Store.System.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
