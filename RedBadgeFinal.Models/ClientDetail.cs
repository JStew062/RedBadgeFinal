using RedBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class ClientDetail
    {
        [Required]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int LocationId { get; set; }
        
        public string CaseMgr { get; set; }
    }
}
