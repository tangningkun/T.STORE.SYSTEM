using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class Menu : Entity
    {
        [Required]
        public Guid Pid { get; set; }
        [Required, MaxLength(50)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int? Component { get; set; }
        public string Icon { get; set; }
        public string Sort { get; set; }
        [Required, MaxLength(50)]
        public string IsPage { get; set; }
    }
}
