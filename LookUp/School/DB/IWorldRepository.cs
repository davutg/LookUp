using System.Collections.Generic;
using School.Model;

namespace School.DB
{
    public interface IWorldRepository
    {
        IEnumerable<Stop> GetAllStops();
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void SaveTrip(Trip tripObject);
        bool SaveAll();
        void DeleteTripById(int id);
        void UpdateTrip(Trip trip);
        Trip GetTripWithStopsByTripId(int tripId);
    }
}