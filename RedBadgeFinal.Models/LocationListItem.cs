using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Models
{
    public class LocationListItem
    {
        public int LocationId
        {
            get; set;
        }
        public string City
        {
            get; set;
        }
        public string County
        {
            get; set;
        }
        public string ZipCode
        {
            get; set;
        }
        public List<string> Services
        {
            get; set;
        }
     }
}
