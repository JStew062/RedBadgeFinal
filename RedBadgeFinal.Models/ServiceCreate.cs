using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class ServiceCreate
    {
            [Required]
            public int ServiceId { get; set; }
            [Required]
            public string ServiceName { get; set; }
            public int ProvId { get; set; }
            public string ProviderName { get; set; }
    }
}
