using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class ClientEdit
    {
        [Required]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int LocationId { get; set; }

        public string CaseMgr { get; set; }
    }
}
