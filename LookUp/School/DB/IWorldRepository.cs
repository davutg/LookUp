using System.Collections.Generic;
using School.Model;

namespace School.DB
{
    public interface IWorldRepository
    {
        IEnumerable<Stop> GetAllStops();
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripsForUser(string userName);
        IEnumerable<Trip> GetAllTripsWithStops(string userName);
        void AddTrip(Trip tripObject);
        bool SaveAll();
        void DeleteTripById(int id);
        void UpdateTrip(Trip trip);        
        Trip GetTripWithStopsByTripId(int tripId, string userName);
        void DeleteStopById(int stopid);
    }
}