using System;
using Engine.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace Engine.Tests
{
    public class HotelRepositoryTests
    {
        [Test]
        public void GivenValidFile_WhenLoading_ReturnsData()
        {
            var sut = new HotelsRepository("Hotels.json");
            sut.SourceData.Value.Should().NotBeEmpty();
        }

        [Test]
        public void GivenInvalidFile_WhenLoading_Throws()
        {
            var sut = new HotelsRepository("BadHotels.json");
            var act = () => sut.SourceData.Value;
            act.Should().Throw<Exception>();
        }

        [Test]
        public void GivenMissingFile_WhenLoading_Throws()
        {
            var sut = new HotelsRepository("badfilename.json");
            var act = () => sut.SourceData.Value;
            act.Should().Throw<Exception>().WithMessage($"File not found badfilename.json");
        }
    }
}