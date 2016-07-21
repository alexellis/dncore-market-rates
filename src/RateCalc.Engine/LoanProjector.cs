using System;

namespace RateCalc.Engine {

    public class Projection {
        public double Payment {
            get; set;
        }
        public double TotalPayable {
            get;set;
        }
    }

    public class LoanProjector {
        public Projection Get(double rate, int term, double principal) {
            // Console.WriteLine(rate.ToString()+" " + term.ToString() + " " + principal.ToString());

            var monthlyRate = rate / 12;

            double amt = (double)(principal * (double)monthlyRate ) / (double)((double)1 - (Math.Pow((1+monthlyRate), -term)));
            // Console.WriteLine("Amount " + amt);
            return new Projection {
                Payment = amt,
                TotalPayable = amt * term
            };
        }
    }
}