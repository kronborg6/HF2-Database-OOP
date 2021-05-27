using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLVape
{
    public abstract class EntityBase
    {
        public bool HasChanges { get; set; }
        public bool IsNew { get; set; }
        public bool IsValid => Validate();
        public abstract bool Validate();
    }
}
