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

        public IList<Flight> Flights = new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        {

            //Foreach  : méthode classique 
            //IList<DateTime> result = new List<DateTime>();

            //foreach (var item in Flights)

            //    if (item.Destination.Equals(destination))

            //    {
            //        result.Add(item.FlightDate);
            //    }

            //return result;


            //le langage Linq = langage de requetage couplé entre SQL et C#
            // Syntaxe 
            // var query = from instance in Source ( instance a, x, p )
            // where condition
            //select 
            // return query 


            // a = flight

            var query = from A in Flights
                        where A.Destination.Equals(destination)
                        select A.FlightDate;
            return query.ToList();                
        }

       

        public void ShowFlightDetails(Plane plane)
        {

            var query = from a in Flights
                        where a.Plane.Equals(plane)
                        select new { a.Destination, a.FlightDate };

            foreach (var item in query)
            {
                Console.WriteLine("FlightDate" +item.FlightDate + "Destination "+item.Destination );
            }


        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from a in Flights
                        where (startDate - a.FlightDate).TotalDays < 7
                        select a;
            return query.Count();

        }

        public double DurationAverage(string destination)
        {
           return
                (from a in Flights
                 where a.Destination == destination
             select a.EstimatedDuration
             ).Average();
           
        }
    }
}
