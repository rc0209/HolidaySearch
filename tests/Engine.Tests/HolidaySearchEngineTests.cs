using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Engine.Repositories;
using Engine.Repositories.Flights;
using Engine.Repositories.Hotels;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Engine.Tests
{
    public class HolidaySearchEngineTests
    {
        private HolidaySearchEngine _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new HolidaySearchEngine(new HotelsRepository("TestData//Hotels.json"), new FlightsRepository("TestData//Flights.json"));
        }

        [Test]
        public async Task GivenInvalidValidSearchCriteria_WhenSearching_ThrowsException()
        {
            var act = async () => await _sut.GetHolidays(null!);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [TestCaseSource(nameof(BuildExampleTestCases))]
        public async Task GivenValidSearch_WhenMatchesExist_ReturnsSomeResults(string departingFrom, string destination, DateOnly departureDate, int duration, (int flightNumber, int hotelNumber, string totalPrice, string departingFrom, string travellingTo) expectedResult)
        {
            var criteria = new HolidaySearch(departingFrom, destination, departureDate, duration);
            var results = await _sut.GetHolidays(criteria);

            results.Should().NotBeEmpty();
            results.First().TotalPrice.Should().Be(expectedResult.totalPrice);
            results.First().Flight.Id.Should().Be(expectedResult.flightNumber);
            results.First().Flight.DepartingFrom.Should().Be(expectedResult.departingFrom);
            results.First().Flight.TravellingTo.Should().Be(expectedResult.travellingTo);
            results.First().Hotel.Id.Should().Be(expectedResult.hotelNumber);
            
        }

        [TestCaseSource(nameof(BuildBadExampleTestCases))]
        public async Task GivenValidSearch_WhenNoMatchesExist_ReturnsNoResults(string departingFrom, string destination, DateOnly departureDate, int duration)
        {
            var criteria = new HolidaySearch(departingFrom, destination, departureDate, duration);
            var results = await _sut.GetHolidays(criteria);

            results.Should().BeEmpty();
        }

        private static IEnumerable<TestCaseData> BuildBadExampleTestCases
        {
            get
            {
                yield return new TestCaseData("", "AGP", new DateOnly(2023, 7, 1), 7).SetName("Bad source airport");
                yield return new TestCaseData("MAN", "", new DateOnly(2023, 7, 1), 7).SetName("Bad destination airport");
                yield return new TestCaseData("MAN", "", null, 7).SetName("Null Date");
                yield return new TestCaseData("MAN", "", new DateOnly(2023, 7, 1), 0).SetName("Zero duration");
                yield return new TestCaseData("MAN", "", new DateOnly(2023, 7, 1), -1).SetName("Negative duration");
            }
        }

        private static IEnumerable<TestCaseData> BuildExampleTestCases
        {
            get
            {
                yield return new TestCaseData("MAN", "AGP", new DateOnly(2023, 7, 1), 7,
                        (flightNumber: 2, hotelNumber: 9, totalPrice: "£826.00", departingFrom: "MAN",
                            travellingTo: "AGP"))
                    .SetName("Customer 1");
                yield return new TestCaseData("Any London Airport", "PMI", new DateOnly(2023, 6, 15), 10,
                        (flightNumber: 6, hotelNumber: 5, totalPrice: "£675.00", departingFrom: "LGW", travellingTo: "PMI"))
                    .SetName("Customer 2");
                yield return new TestCaseData("Any Airport", "LPA", new DateOnly(2022, 11, 10), 14,
                        (flightNumber: 7, hotelNumber: 6, totalPrice: "£1175.00", departingFrom: "MAN", travellingTo: "LPA"))
                    .SetName("Customer 3");
            }
        }
    }
}