using Microsoft.AspNet.Authorization;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using School.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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


        public IEnumerable<Trip> GetAllTripsWithStops(String userName)
        {
            try {
                return _context.Trips.Where(w => w.UserName == userName)
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

        //[Authorize]
        public void AddTrip(Trip tripObject)
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

        public Trip GetTripWithStopsByTripId(int tripId,string userName)
        {
            var trip = _context.Trips.Where(w => w.Id == tripId && w.UserName==userName).Include(i => i.Destinations).FirstOrDefault();
            return trip;
        }

        public IEnumerable<Trip> GetTripsForUser(string userName)
        {
            return _context.Trips.Where(w => w.UserName == userName);
        }
    }
}
