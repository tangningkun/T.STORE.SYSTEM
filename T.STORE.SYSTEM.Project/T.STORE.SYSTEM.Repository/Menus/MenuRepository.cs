using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Domain.Entities;
using T.STORE.SYSTEM.EntityFrameworkCore.EntityFramework;

namespace T.STORE.SYSTEM.Repository.Menus
{
    public class MenuRepository : StoreSystemRepositoryBase<Menu, int>, IMenuRepository
    {
    }
}
