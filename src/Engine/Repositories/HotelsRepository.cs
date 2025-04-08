using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Engine.Repositories
{
    internal class HotelsRepository : IHotelsRepository
    {
        private readonly IList<HotelDto> _hotels;
        public HotelsRepository(string sourceFile)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            using var file = File.OpenRead(sourceFile);
            _hotels = JsonSerializer.Deserialize<List<HotelDto>>(file, options);
        }

        public async Task<IReadOnlyList<Hotel>> SearchHotels(string airport, DateOnly arrivalDate, int nights)
        {
            var result = _hotels.Select(h => new Hotel(h.Id, h.Name, h.PricePerNight)).ToList();
            return await Task.FromResult(new ReadOnlyCollection<Hotel>(result));
        }
    }
}
