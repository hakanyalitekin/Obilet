using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete
{
    public class BusLocationResult
    {
        public string Status { get; set; }
        public List<BusLocationData> BusLocations { get; set; }
    }

     public class BusLocationData
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
    }
}
