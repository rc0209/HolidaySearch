using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Repositories
{
    internal interface IFlightsRepository
    {
        Task<IReadOnlyList<Flight>> SearchFlights(string departingFrom, string travellingTo, DateOnly departureDate);
    }
}