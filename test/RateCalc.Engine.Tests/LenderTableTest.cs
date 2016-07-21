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
    public class LenderTableTest
    {
        [Fact]
        public void LenderTable_Gives_Count() {
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
            table.Count().Should().Be(2);
        }

        [Fact]
        public void LenderTable_Sorted_ByLowestRate() {
            List<CsvLine> list = new List<CsvLine>();
            var entry1 = new CsvLine();
            entry1.Parts.Add("Alex");
            entry1.Parts.Add("0.5");
            entry1.Parts.Add("480");
            list.Add(entry1);

            var entry2 = new CsvLine();
            entry2.Parts.Add("Dave");
            entry2.Parts.Add("0.251");
            entry2.Parts.Add("140");
            list.Add(entry2);

            var entry3 = new CsvLine();
            entry3.Parts.Add("Dave");
            entry3.Parts.Add("0.25");
            entry3.Parts.Add("140");
            list.Add(entry3);

            var repo = new LenderRepository(list);
            LenderTable table = repo.Read();
            LenderTable sorted = table.Sort();
            sorted.Get(0).Rate.Should().Be(0.25);
            sorted.Get(1).Rate.Should().Be(0.251);
            sorted.Get(2).Rate.Should().Be(0.5);
        }
    }
}