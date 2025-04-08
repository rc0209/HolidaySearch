using System.Collections.Generic;
using Engine.Repositories.Flights;
using FluentAssertions;
using NUnit.Framework;

namespace Engine.Tests
{
    public class AirportMapperTests
    {
        [TestCase("MAN", ExpectedResult = new string[] { "MAN" })]
        [TestCase("Any Airport", ExpectedResult = new string[] { "LTN", "LGW", "MAN" })]
        [TestCase("Any London Airport", ExpectedResult = new string[] { "LTN", "LGW" })]
        public IReadOnlyList<string> GivenValidAirport_WhenMapping_ReturnsValidMappingSet(string source)
        {
            return source.MapAirports();
        }

        [Test]
        public void GivenInvalidAirport_WhenMapping_ReturnsSameValue()
        {
            "InvalidAirport".MapAirports().Should().SatisfyRespectively(a => a.Should().Be("InvalidAirport"));
        }
    }
}