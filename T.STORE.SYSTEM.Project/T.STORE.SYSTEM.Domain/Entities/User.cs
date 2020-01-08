using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class User:Entity
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; }
        [Required, MaxLength(100)]
        public string Account { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        [Required, MaxLength(100)]
        public string ApiKey { get; set; }
        public Guid? departmentId { get; set; }
    }
}
