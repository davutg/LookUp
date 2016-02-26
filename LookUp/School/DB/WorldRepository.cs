using Microsoft.Data.Entity;
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

        public WorldRepository(WorldContext context)
        {
            _context = context;

        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips;
        }


        public IEnumerable<Trip> GetAllTripsWithStops()
        {
            return _context.Trips
                .Include(t=>t.Destinations)
                .OrderBy(o=>o.Name).ToList();
        }

        public IEnumerable<Stop> GetAllStops()
        {
            return _context.Stops;
        }

    }
}
