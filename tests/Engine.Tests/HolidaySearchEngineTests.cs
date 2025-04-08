using System;
using System.Threading.Tasks;
using FluentAssertions;
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
    }
}