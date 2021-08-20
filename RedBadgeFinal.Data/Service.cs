using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Service
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }
        public virtual ICollection<ServiceNote> Notes { get; set; } = new List<ServiceNote>();
    }
}
