using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Engine.Repositories.Hotels
{
    internal class HotelsRepository : RepositoryBase<HotelDto>, IHotelsRepository
    {
        public HotelsRepository(string sourceFile) : base(sourceFile)
        {
        }

        public async Task<IReadOnlyList<Hotel>> SearchHotels(string airport, DateOnly arrivalDate, int nights)
        {
            var result = SourceData.Value
                .Where(h => h.LocalAirports.Contains(airport, StringComparer.InvariantCultureIgnoreCase) &&
                            h.ArrivalDate.Equals(arrivalDate) && h.Nights.Equals(nights))
                .Select(h => new Hotel(h.Id, h.Name, h.PricePerNight)).ToList();

            return await Task.FromResult(new ReadOnlyCollection<Hotel>(result));
        }
    }
}
