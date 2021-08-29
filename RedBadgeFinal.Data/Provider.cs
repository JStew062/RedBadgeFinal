using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Provider
    {
        [Key]
        public int ProvId { get; set; }
        public string ProvName { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }



        public virtual ICollection<Service> ListOfServices { get; set; }

            public Provider()
        {
            ListOfServices = new HashSet<Service>();
        }
    }
    
}
