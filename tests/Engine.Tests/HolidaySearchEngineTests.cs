using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _sut = new HolidaySearchEngine();
        }

        [Test]
        public async Task GivenInvalidValidSearchCriteria_WhenSearching_ThrowsException()
        {
            var act = async () => await _sut.GetHolidays(null!);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [TestCaseSource(nameof(BuildExampleTestCases))]
        public async Task GivenValidSearch_ReturnsSomeResults(string departingFrom, string destination, DateOnly departureDate, int duration, (int flightNumber, int hotelNumber) expectedResult)
        {
            var criteria = new HolidaySearch(departingFrom, destination, departureDate, duration);
            var results = await _sut.GetHolidays(criteria);

            results.Should().NotBeEmpty().And.HaveCount(1);
            results.Single().Flight.Id.Should().Be(expectedResult.flightNumber);
            results.Single().Hotel.Id.Should().Be(expectedResult.hotelNumber);
        }

        private static IEnumerable<TestCaseData> BuildExampleTestCases
        {
            get
            {
                yield return new TestCaseData("MAN", "AGP", new DateOnly(2023, 7, 1), 7, (flightNumber: 2, hotelNumber: 9)).SetName("Customer 1");
                yield return new TestCaseData("Any London Airport", "PMI", new DateOnly(2023, 6, 15), 10, (flightNumber: 6, hotelNumber: 5)).SetName("Customer 2");
                yield return new TestCaseData("Any Airport", "LPA", new DateOnly(2022, 11, 10), 14, (flightNumber: 7, hotelNumber: 6)).SetName("Customer 3");
            }
        }
    }
}