using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public string MenuIds { get; set; }
        public bool? IsUse { get; set; }
        public bool IsAdmin { get; set; }
    }
}
