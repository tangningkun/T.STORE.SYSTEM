using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class User:Entity
    {
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public Guid? departmentId { get; set; }
    }
}
