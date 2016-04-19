using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.ViewModel
{
    public class StopViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public String Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
       
        public DateTime Arrival { get; set; }
    }
}
