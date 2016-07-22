using System;
using System.Collections;
using System.Collections.Generic;

namespace RateCalc.Engine {
    
    // Could be moved to .Model namespace and or directory
    public class LoanOffer {
        public double Target {get;set;}
        public double Rate {get;set;}
        public bool FundsAvailable {get;set;}
    }
    
    public class Loan {

        private class LoanAggregate {
            public double Amount { get;set; }
            public double Rate { get;set; }
            public double WeightedValue { 
                get {
                    return Amount * Rate*12; 
                }
            }
        }
        
        private LenderTable _table;
            
        public Loan(LenderTable table) {
            _table = table;
        }

        public bool ValidLoan(double target) {
            return target >= 100 && target % 100 == 0;
        }

        public LoanOffer Request(double target) {
            List<LoanAggregate> aggregates = new List<LoanAggregate>();
            LoanOffer loan = new LoanOffer { Target = target, FundsAvailable = false };

            while(target > 0) {
                for(int i = 0; i < _table.Count() && target> 0;i++) {
                    var available = _table.Get(i).Available;
                    if(available > 0) {
                        target -= available;
                        _table.Get(i).Available -= available;
 
                        Console.WriteLine("Taking " + available.ToString() + " off " + _table.Get(i).Name + " @ rate of " + _table.Get(i).Rate +", left= "+target);

                        var loaner = _table.Get(i);
                        aggregates.Add( new LoanAggregate { Amount = available, Rate = loaner.Rate });
                    }
                }
            }

            // https://www.edvisors.com/repay-student-loans/federal/consolidation/calculate-weighted-average-interest-rates/
            double totalLoan = 0;
            double weightedTotal = 0;
            foreach(var aggregate in aggregates) {
                totalLoan += aggregate.Amount;
                weightedTotal += aggregate.WeightedValue;
            }
            loan.Rate = weightedTotal / totalLoan;
            loan.Target = totalLoan;
            //Console.WriteLine("total="+totalLoan+" weightedTotal="+weightedTotal+" Rate="+loan.Rate );
            loan.FundsAvailable = true;
            
            return loan;
        }

    } 

}