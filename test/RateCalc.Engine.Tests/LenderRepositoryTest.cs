using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Xunit;
using RateCalc.Engine;
using FluentAssertions;
using Moq;

namespace RateCalc.Engine.Test
{
    public class LenderRepositoryTest
    {
        // https://github.com/dennisdoomen/fluentassertions/wiki
        [Fact]
        public void ConvertsSingleEntity_To_LenderModel_Test() 
        {
            List<CsvLine> list = new List<CsvLine>();
            var entry1 = new CsvLine();
            entry1.Parts.Add("Alex");
            entry1.Parts.Add("0.069");
            entry1.Parts.Add("480");
            list.Add(entry1);

            var repo = new LenderRepository(list);

            LenderTable table = repo.Read();

            var lender = table.GetLender("Alex");
            lender.Rate.Should().Be(0.069);
            lender.Available.Should().Be(480);
        }

        [Fact]
        public void ConvertMultipleEntities_ToLenderModel_Test() 
        {
            List<CsvLine> list = new List<CsvLine>();
            var entry1 = new CsvLine();
            entry1.Parts.Add("Alex");
            entry1.Parts.Add("0.069");
            entry1.Parts.Add("480");
            list.Add(entry1);

            var entry2 = new CsvLine();
            entry2.Parts.Add("Dave");
            entry2.Parts.Add("0.074");
            entry2.Parts.Add("140");
            list.Add(entry2);

            var repo = new LenderRepository(list);

            LenderTable table = repo.Read();

            var alexLender = table.GetLender("Alex");
            alexLender.Name.Should().Be("Alex");

            var daveLender = table.GetLender("Dave");
            daveLender.Name.Should().Be("Dave");
            daveLender.Rate.Should().Be(0.074);
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

    }
}