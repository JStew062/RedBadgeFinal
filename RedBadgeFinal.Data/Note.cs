using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid OwnerId { get; set; }

        [Required]
        public string Content { get; set; }

/*        [ForeignKey(nameof(Service))]
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }*/

        public virtual ICollection<ServiceNote> Services { get; set; } = new List<ServiceNote>();


        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

      
    }
}
