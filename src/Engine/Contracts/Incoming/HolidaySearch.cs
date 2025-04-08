using System;

namespace Engine
{
    public record HolidaySearch(string DepartingFrom, string TravellingTo, DateOnly DepartureDate, int Duration);
}