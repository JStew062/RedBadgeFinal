using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class ServiceDetail
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        public int ProvId { get; set; }
        public string ProvName { get; set; }

        //public int NoteId { get; set; }


        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public List<string> Services { get; set; }
        public List<string> Notes { get; set; }
    }
}
