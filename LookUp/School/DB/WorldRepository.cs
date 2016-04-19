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

        public void SaveTrip(Trip tripObject)
        {
            _context.Add(tripObject);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void DeleteTripById(int id)
        {
            _context.Remove(_context.Trips.Where(w => w.Id == id).FirstOrDefault());
        }

        public void UpdateTrip(Trip trip)
        {
            _context.Update(trip);
        }

        public Trip GetTripWithStopsByTripId(int tripId)
        {
            var trip = _context.Trips.Where(w => w.Id == tripId).Include(i => i.Destinations).FirstOrDefault();
            return trip;
        }
    }
}
