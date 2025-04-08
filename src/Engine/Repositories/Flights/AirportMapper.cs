using System.Collections.Generic;
using System.Linq;

namespace Engine.Repositories.Flights
{
    internal static class AirportMapper
    {
        private static readonly IReadOnlyList<string> LondonAirports = new List<string> { "LTN", "LGW" };
        private static readonly IReadOnlyList<string> OtherAirports = new List<string> { "MAN" };
        private static IReadOnlyList<string> AllAirports => LondonAirports.Union(OtherAirports).ToList();

        internal static IReadOnlyList<string> MapAirports(this string airport)
        {
            return airport switch
            {
                "Any London Airport" => LondonAirports, "Any Airport" => AllAirports,
                _ => new List<string> { airport }
            };
        }
    }
}