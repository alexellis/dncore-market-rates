using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using RateCalc.Engine;

namespace RateCalc.App
{
    public class Program
    {
        private class LenderActivity {
            public LoanOffer GetLoanOffer(string fileName, double target) {
                CsvParser parser = new CsvParser(new DiskFileSource());
                IEnumerable<CsvLine> lines = parser.Read(fileName);
                var lenderRepo = new LenderRepository(lines);
                LenderTable table = lenderRepo.Read();
                var loan = new Loan(table);

                return loan.Request(target);
            }
        }

        public static void Main(string[] args)
        {
            var activity = new LenderActivity();

            // TODO: Parse from command-line.
            double target = 1000;
            var offer = activity.GetLoanOffer("market.csv", target);

            var projector = new LoanProjector();
            var projection = projector.Get(offer.Rate, 36, offer.Target);

            // Could move formatting into class for sake of SRP / testability.
            Console.WriteLine("Rate: " + String.Format("{0:0.0}",(offer.Rate*100)) +" target=" + offer.Target);
            Console.WriteLine("Payment: " + String.Format("{0:0.00}", projection.Payment));
            Console.WriteLine("Total: " + String.Format("{0:0.00}", projection.TotalPayable));
        }
    }
}
