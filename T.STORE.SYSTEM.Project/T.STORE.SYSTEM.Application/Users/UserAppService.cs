using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Application.Base;
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
    }
}
