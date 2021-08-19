using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Needed Service")]
        public string ServiceName { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
