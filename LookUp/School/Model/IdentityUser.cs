using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Model
{
    public class WorldUser:IdentityUser
    {
        public DateTime CreateDate { get; set; }
    }
}
