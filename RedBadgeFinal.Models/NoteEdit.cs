using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class NoteEdit
    {
        public int NoteId { get; set; }
        public string Content { get; set; }
        public string ServiceNote { get; set; }
        public string Service { get; set; }
    }
}
