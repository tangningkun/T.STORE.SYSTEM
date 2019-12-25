using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Repository.EntityFramework;
using T.STORE.SYSTEM.Domain.Entities;

namespace T.STORE.SYSTEM.Repository.Users
{
    public class UserRepository:StoreSystemRepositoryBase<User>, IUserRepository
    {
    }
}
