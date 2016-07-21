using System;
using System.Linq;

using Xunit;
using RateCalc.Engine;
using FluentAssertions;
using Moq;

namespace RateCalc.Engine.Test
{
    public class CsvParserTest
    {
        // https://github.com/dennisdoomen/fluentassertions/wiki
        [Fact]
        public void IgnoreHeaderOnFirstLine_Test() 
        {
            var fileSource = new Mock<IFileSource>();
            fileSource.Setup(m => m.Read(It.IsAny<string>())).Returns("Lender,Rate,Available\nAlex,101,55.5");

            var sut = new CsvParser(fileSource.Object);
            var parts = sut.Read("market.csv");

            parts.Should().NotBeNull();
            var first = parts.First();
            first.Should().NotBeNull();
            first.Parts.Count.Should().BeGreaterThan(2);
            first.Parts[0].Should().Be("Alex");
            first.Parts[1].Should().Be("101");
            first.Parts[2].Should().Be("55.5");
        }

        [Fact]
        public void ReturnEmptyGivenNoDataLines_WithTrailingNewLine_Test() 
        {
            var fileSource = new Mock<IFileSource>();
            fileSource.Setup(m => m.Read(It.IsAny<string>())).Returns("Lender,Rate,Available\n");

            var sut = new CsvParser(fileSource.Object);
            var parts = sut.Read("market.csv");

            parts.Should().BeEmpty();
        }

        [Fact]
        public void ReturnEmptyGivenNoDataLines_Test() 
        {
            var fileSource = new Mock<IFileSource>();
            fileSource.Setup(m => m.Read(It.IsAny<string>())).Returns("Lender,Rate,Available");

            var sut = new CsvParser(fileSource.Object);
            var parts = sut.Read("market.csv");

            parts.Should().BeEmpty();
        }
    }
}
