using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return plane.flights.SelectMany(p => p.tickets)
                .Select(t => t.passenger)
                .Distinct()
                .ToList();
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderBy(p => p.planeId).TakeLast(n).SelectMany(p => p .flights).OrderBy(p => p.flightDate).ToList();
            //return GetAll().OrderByDescending(p => p.planeId).Take(n).SelectMany(p => p.flights).OrderBy(p => p.flightDate).ToList();
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {
            //var capacity = flight.plane.capacity;
            //var tickets = flight.tickets.Count();
            //return capacity - tickets>n;

            //Méthode 1 : var plane = GetAll().Where(p => p.flights.Contains(flight) == true).FirstOrDefault();
            //Méthode 2 : 
            var plane = Get(p => p.flights.Contains(flight) == true);

            var capacity = plane.capacity;
            var f = plane.flights.Single(j => j.flightId == flight.flightId);
            var ticket = flight.tickets.Count();
            return capacity - ticket > n;
        }

        public void DeletePlane()
        {
            //var planes = GetAll().Where(p => (DateTime.Now - p.manufactureDate).TotalDays>3650);
            //foreach (var plane in planes)
            //{
            //    Delete(plane);
            //}
            //Commit();

            Delete(p => (DateTime.Now - p.manufactureDate).TotalDays > 3650);
        }
    }
}
