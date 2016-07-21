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
            Console.WriteLine(rate.ToString()+" " + term.ToString() + " " + principal.ToString());
            double amt =(double) (principal * rate ) / (double)((double)1 - (Math.Pow((1+rate), -term)));
            Console.WriteLine("Amount " + amt);
            return new Projection {
                Payment = amt,
                TotalPayable = amt * term
            };
        }
    }

    public class LoanOffer {
        public double Target {get;set;}
        public double Rate {get;set;}
        public bool FundsAvailable {get;set;}
    }

    public class Loan {
        private LenderTable _table;
            
        public Loan(LenderTable table) {
            _table = table;
        }

        public bool ValidLoan(double target) {
            return target >= 100 && target%100 == 0 ;
        }

        public LoanOffer Request(double target) {
            LoanOffer loan = new LoanOffer{Target=target, FundsAvailable=false};
            while(target > 0) {
                for(int i = 0; i < _table.Count() && target> 0;i++) {
                    var available = _table.Get(i).Available;
                    if(available > 0) {
                        target -= available;
                        _table.Get(i).Available -= available;
                        loan.Rate += _table.Get(i).Rate;  
                        Console.WriteLine("Taking " + available.ToString() + " off " + _table.Get(i).Name + " @ rate of " + _table.Get(i).Rate +", left= "+target);
                    }
                }
            }

            loan.FundsAvailable = true;
            return loan;
        }

    } 

}