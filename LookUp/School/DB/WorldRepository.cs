using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using School.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DB
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context,ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }        

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips;
        }


        public IEnumerable<Trip> GetAllTripsWithStops()
        {
            try {
                return _context.Trips
                    .Include(t => t.Destinations)
                    .OrderBy(o => o.Name).ToList();
            }catch(Exception exe)
            {
                _logger.LogError("Couldn't receive object because of an error", exe);
                throw;
            }
        }

        public IEnumerable<Stop> GetAllStops()
        {
            return _context.Stops;
        }

    }
}
