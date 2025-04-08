using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engine.Repositories.Flights;
using Engine.Repositories.Hotels;

namespace Engine
{
    internal class HolidaySearchEngine
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IFlightsRepository _flightsRepository;

        public HolidaySearchEngine(IHotelsRepository hotelsRepository, IFlightsRepository flightsRepository)
        {
            _hotelsRepository = hotelsRepository;
            _flightsRepository = flightsRepository;
        }

        public async Task<IReadOnlyList<Holiday>> GetHolidays(HolidaySearch criteria)
        {
            ArgumentNullException.ThrowIfNull(criteria);

            var flight = await _flightsRepository.SearchFlights(criteria.DepartingFrom, criteria.TravellingTo,
                criteria.DepartureDate);
            var hotel = await _hotelsRepository.SearchHotels(criteria.TravellingTo, criteria.DepartureDate,
                criteria.Duration);

            return await Task.FromResult(Enumerable.Empty<Holiday>().ToList());
        }
    }
}
