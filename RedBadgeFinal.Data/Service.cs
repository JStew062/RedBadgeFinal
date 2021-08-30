using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Service
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        
        public virtual ICollection<Provider> ListOfProviders { get; set; }


        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
