using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Engine.Repositories.Hotels
{
    internal record HotelDto
    {
        [JsonPropertyName("id")] public int Id { get; init; }
        [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
        [JsonPropertyName("arrival_date")] public string ArrivalDate { get; init; } = string.Empty;
        [JsonPropertyName("price_per_night")] public int PricePerNight { get; init; }
        [JsonPropertyName("local_airports")] public List<string> LocalAirports { get; init; } = [];
        public int Nights { get; init; }
    }
}