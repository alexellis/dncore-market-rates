using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using RateCalc.Engine;

namespace RateCalc.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(File.ReadAllText("market.csv"));

            CsvParser parser = new CsvParser(new DiskFileSource());
            IEnumerable<CsvLine> lines = parser.Read("market.csv");
            var lenderRepo = new LenderRepository(lines);
            LenderTable table = lenderRepo.Read();
            var loan = new Loan(table);
            double target = 1000;
            var offer = loan.Request(target);

            var projector = new LoanProjector();
            var projection = projector.Get(offer.Rate, 36, offer.Target);
            Console.WriteLine("Payment: " + projection.Payment.ToString());
            Console.WriteLine("Total: " + projection.TotalPayable.ToString());
        }
    }
}
