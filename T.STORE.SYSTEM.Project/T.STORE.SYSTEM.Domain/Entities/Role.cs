using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class Role : Entity
    {
        [Required, MaxLength(50)]
        public string RoleName { get; set; }
        [MaxLength(1000)]
        public string MenuIds { get; set; }
        public bool IsUse { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
