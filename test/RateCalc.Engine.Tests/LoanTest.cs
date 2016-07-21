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
    public class LoanTest
    {
        // Validation could be moved via SRP into separate class. 
        [Fact]
        public void RequestedLoanMustBeIncrementOf100_Test() {
            List<CsvLine> list = new List<CsvLine>();

            var repo = new LenderRepository(list);
            LenderTable table = repo.Read();
            LenderTable sorted = table.Sort();

            var loan = new Loan(sorted);
            loan.ValidLoan(150).Should().Be(false);
        }

        [Fact]
        public void RequestedLoanCannotBeLessThan100_Test() {
            List<CsvLine> list = new List<CsvLine>();

            var repo = new LenderRepository(list);
            LenderTable table = repo.Read();
            LenderTable sorted = table.Sort();

            var loan = new Loan(sorted);
            loan.ValidLoan(99).Should().Be(false);
        }

        [Fact]
        public void GetLoanRate_Test() {
            List<CsvLine> list = new List<CsvLine>();
            var entry1 = new CsvLine();
            entry1.Parts.Add("Alex");
            entry1.Parts.Add("0.5");
            entry1.Parts.Add("150");
            list.Add(entry1);

            var entry2 = new CsvLine();
            entry2.Parts.Add("Dave");
            entry2.Parts.Add("1.0");
            entry2.Parts.Add("50");
            list.Add(entry2);

            var entry3 = new CsvLine();
            entry3.Parts.Add("Dave");
            entry3.Parts.Add("1.5");
            entry3.Parts.Add("200");
            list.Add(entry3);

            var repo = new LenderRepository(list);
            LenderTable table = repo.Read();
            LenderTable sorted = table.Sort();

            var loan = new Loan(sorted);
            var offer = loan.Request(200);

            offer.FundsAvailable.Should().Be(true);
            offer.Rate.Should().Be(table.Get(0).Rate + table.Get(1).Rate);
        }

        [Fact]
        public void TakesAvailable_FromLowestRatesfirst_Test() {
            List<CsvLine> list = new List<CsvLine>();
            var entry1 = new CsvLine();
            entry1.Parts.Add("Alex");
            entry1.Parts.Add("0.5");
            entry1.Parts.Add("150");
            list.Add(entry1);

            var entry2 = new CsvLine();
            entry2.Parts.Add("Dave");
            entry2.Parts.Add("1.0");
            entry2.Parts.Add("50");
            list.Add(entry2);

            var entry3 = new CsvLine();
            entry3.Parts.Add("Dave");
            entry3.Parts.Add("1.5");
            entry3.Parts.Add("200");
            list.Add(entry3);

            var repo = new LenderRepository(list);
            LenderTable table = repo.Read();
            LenderTable sorted = table.Sort();

            var loan = new Loan(sorted);
            loan.Request(200);

            sorted.Get(0).Available.Should().Be(0);
            sorted.Get(1).Available.Should().Be(0);
        }
    }
}