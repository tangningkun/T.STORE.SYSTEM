using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain.Entities
{
    public class Menu : Entity
    {
        public Guid Pid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Component { get; set; }
        public string Icon { get; set; }
        public string Sort { get; set; }
        public string IsPage { get; set; }
    }
}
