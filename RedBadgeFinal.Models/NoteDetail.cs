using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class NoteDetail
    {
        public int NoteId { get; set; }
        public string Content { get; set; }
        public string ServiceNote { get; set; }
        public string Service { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public List<string> Services { get; set; }
    }
}
