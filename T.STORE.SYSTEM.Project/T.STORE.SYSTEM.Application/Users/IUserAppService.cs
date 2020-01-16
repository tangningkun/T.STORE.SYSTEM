using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Application.Base;
using T.STORE.SYSTEM.Application.Users.dto;
using T.STORE.SYSTEM.Domain.Entities;

namespace T.STORE.SYSTEM.Application.Users
{
    public interface IUserAppService: IBaseAppService<User>
    {
        Task<User> CheckLoginUser(LoginUserDto loginUserDto);
    }
}
