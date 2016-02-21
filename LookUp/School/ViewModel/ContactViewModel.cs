using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.ViewModel
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string SurName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 4000, MinimumLength = 1)]
        public string Message { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} , {2} , {3}", Name ?? "", SurName ?? "", Email ?? "", Message ?? "");
        }

    }
}
