using System.Collections.Generic;
using School.Model;

namespace School.DB
{
    public interface IWorldRepository
    {
        IEnumerable<Stop> GetAllStops();
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
    }
}