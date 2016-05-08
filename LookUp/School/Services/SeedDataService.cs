using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using School.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public class SeedDataService
    {
        private WorldContext _context;
        private ILogger<SeedDataService> _logger;
        private UserManager<WorldUser> _userManager;

        public SeedDataService(WorldContext context, UserManager<WorldUser> userManager,ILogger<SeedDataService> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task EnsureSeedDataAsync()
        {
            
            if (await _userManager.FindByEmailAsync("cowboy@acme.com") == null)
            {
                var user = new WorldUser()
                {
                    UserName = "cowboy",
                    Email = "cowboy@acme.com"
                };
               var result= await _userManager.CreateAsync(user, "X");
                Debug.WriteLine(result);
                _logger.LogDebug(String.Format("Default user creation result:{0} {1}",result.Succeeded,result.Errors));
            }
            if (!_context.Trips.Any())
            {
                Trip t = new Trip()
                {
                    Created = DateTime.UtcNow,
                    Name = "Cappadocia",
                    UserName = "cowboy",
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
