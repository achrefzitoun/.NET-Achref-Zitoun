using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>(); // Création d'une liste 

        // 6 + 7 
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();  
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].destination == destination)
            //    {
            //        dates.Add(Flights[i].flightDate);
            //    }
            //}
            //return dates;
            foreach (var flight in Flights) 
            {
                if (flight.destination == destination)
                {
                    dates.Add(flight.flightDate);
                }
            }
            return dates;
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> f = new List<Flight>();

            if(filterType.Equals("destination"))
            {
                foreach (var flight in Flights)
                {
                    if (flight.destination.Equals(filterValue))
                    {
                        f.Add(flight);
                    }
                }
            }

            if (filterType.Equals("departure"))
            {
                foreach (var flight in Flights)
                {
                    if (flight.departure.Equals(filterValue))
                    {
                        f.Add(flight);
                    }
                }
            }

            if (filterType.Equals("estimatedDuration"))
            {
                foreach (var flight in Flights)
                {
                    if (flight.estimatedDuration.Equals(filterValue))
                    {
                        f.Add(flight);
                    }
                }
            }

            if (filterType.Equals("flightDate"))
            {
                foreach (var flight in Flights)
                {
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Parse(filterValue);
                    if (flight.flightDate==dateTime)
                    {
                        f.Add(flight);
                    }
                }
            }

            if (filterType.Equals("effectiveArrival"))
            {
                foreach (var flight in Flights)
                {
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Parse(filterValue);
                    if (flight.effectiveArrival == dateTime)
                    {
                        f.Add(flight);
                    }
                }
            }

            if (filterType.Equals("flightId"))
            {
                foreach (var flight in Flights)
                {
                    int k = int.Parse(filterValue);
                    if (flight.flightId == k)
                    {
                        f.Add(flight);
                    }
                }
            }
            
            return f;
        }
    }
}
