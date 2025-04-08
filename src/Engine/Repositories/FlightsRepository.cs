using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Repositories
{
    internal class FlightsRepository : IFlightsRepository
    {
        public Task<IReadOnlyList<Flight>> SearchFlights(string departingFrom, string travellingTo, DateOnly departureDate)
        {
            throw new NotImplementedException();
        }
    }
}