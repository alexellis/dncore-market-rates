using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RateCalc.Engine
{
  public class Lender {
    public string Name {get;set;}
    public double Rate {get;set;}
    public double Available {get;set;}
  }

  public class LenderTable {
    private List<Lender> _lenders;

    public LenderTable(List<Lender> lenders) {
      _lenders = lenders;

    }

    public LenderTable() : this(new List<Lender>()) {

    }

    public int Count() {
      return _lenders.Count;
    }

    public Lender Get(int index) {
      return _lenders[index];
    }


    public LenderTable Sort() {
      return new LenderTable(_lenders.OrderBy(x => x.Rate).ToList<Lender>());
    }

    public void Add(string name, double rate, double available) {
      _lenders.Add(new Lender {
        Name = name,
        Rate = rate,
        Available = available
      });
    }

    public Lender GetLender(string name) {
      return _lenders.Where(l=>l.Name == name).FirstOrDefault();
    }
  }

  public class LenderRepository {
      private readonly IEnumerable<CsvLine> _entries;

      public LenderRepository(IEnumerable<CsvLine> entries) {
        _entries = entries;
      }
      
      public LenderTable Read() {
        var table = new LenderTable();
        foreach(var entry in _entries) {
          table.Add(entry.Parts[0], Convert.ToDouble(entry.Parts[1]),  Convert.ToDouble(entry.Parts[2]));
        }
       
        return table;
      }
  }
}
