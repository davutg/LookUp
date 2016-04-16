using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.ViewModel
{
    public class TripViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="Minimum 3 chars")]
        [MaxLength(255,ErrorMessage ="Maximum length exceeded")]
        public String Name { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
