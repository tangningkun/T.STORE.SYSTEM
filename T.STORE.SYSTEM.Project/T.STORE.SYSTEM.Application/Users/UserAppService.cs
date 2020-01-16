using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Application.Base;
using T.STORE.SYSTEM.Application.Users.dto;
using T.STORE.SYSTEM.Core.Common;
using T.STORE.SYSTEM.Domain.Entities;
using T.STORE.SYSTEM.Repository.Users;

namespace T.STORE.SYSTEM.Application.Users
{
    public class UserAppService:BaseAppService<User>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CheckLoginUser(LoginUserDto loginUserDto)
        {
            var user = new User();
            try
            {
                loginUserDto.Password = Utils.DecryptDES(loginUserDto.Password);
                if (await _userRepository.CountAsync(x => x.Account == loginUserDto.UserName) == 0)
                {
                    throw new Exception($"用户名{loginUserDto.UserName}错误或该用户名不存在！");
                }
                else
                {
                    if (await _userRepository.CountAsync(x => x.Account == loginUserDto.UserName && x.Password == loginUserDto.Password) == 0)
                    {
                        throw new Exception($"用户密码有误！");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await _userRepository.FirstOrDefaultAsync(x => x.Account == loginUserDto.UserName && x.Password == loginUserDto.Password);
        }
    }
}
