using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class UserRole:Entity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
