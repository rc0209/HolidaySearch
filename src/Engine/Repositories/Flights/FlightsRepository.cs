using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Repositories.Flights
{
    internal class FlightsRepository : RepositoryBase<FlightDto>, IFlightsRepository
    {
        public FlightsRepository(string sourceFile) : base(sourceFile)
        {
        }

        public async Task<IReadOnlyList<Flight>> SearchFlights(string departingFrom, string travellingTo, DateOnly departureDate)
        {
            var result = SourceData.Value
                .Where(f => departingFrom.MapAirports().Contains(f.From, StringComparer.InvariantCultureIgnoreCase) &&
                            f.To.Equals(travellingTo, StringComparison.InvariantCultureIgnoreCase) &&
                            f.DepartureDate.Equals(departureDate))
                .OrderBy(f=>f.Price)
                .Select(f => new Flight(f.Id, f.From, f.To, f.Price))
                .ToList();
            return await Task.FromResult(new ReadOnlyCollection<Flight>(result));
        }
    }
}