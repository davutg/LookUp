using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Model
{
    public class Trip
    {
        public int Id { get; set; }        
        public DateTime Created { get; set; }
        public String Name { get; set; }
        public String UserName { get; set; }

        public ICollection<Stop> Destinations { get; set; }
    }
}
