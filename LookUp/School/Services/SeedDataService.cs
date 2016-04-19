using Microsoft.AspNet.Identity;
using School.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public class SeedDataService
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public SeedDataService(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            
            if (await _userManager.FindByEmailAsync("davutg@acme.com") == null)
            {
                var user = new WorldUser()
                {
                    UserName = "CowBoy",
                    Email = "CowBoy@acme.com"
                };
                await _userManager.CreateAsync(user, "X");
            }
            if (!_context.Trips.Any())
            {
                Trip t = new Trip()
                {
                    Created = DateTime.UtcNow,
                    Name = "Cappadocia",
                    UserName = "CowBoy",
                    Destinations = new List<Stop>
                    {
                        new Stop() {
                            Arrival=DateTime.UtcNow,
                            Order=1,
                            Name="Uchisar",
                            Latitude=0.123,
                            Longitude=0.321
                        },
                            new Stop() {
                            Arrival=DateTime.UtcNow,
                            Order=2,
                            Name="Ortahisar",
                            Latitude=2.123,
                            Longitude=2.321
                        },
                            new Stop() {
                            Arrival=DateTime.UtcNow,
                            Order=3,
                            Name="Göreme",
                            Latitude=3.123,
                            Longitude=3.321
                        },
                            new Stop() {
                            Arrival=DateTime.UtcNow,
                            Order=4,
                            Name="Ürgüp",
                            Latitude=4.123,
                            Longitude=4.321
                        }
                    }
                };
                _context.Trips.Add(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
