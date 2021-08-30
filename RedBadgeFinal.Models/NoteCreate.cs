using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class NoteCreate
    {
        [Required]
        public string Content { get; set; }
        public string ServiceNote { get; set; }
        public string Services { get; set; }
    }
}
